using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace WinApp_Fakes_Shims_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            flyingBoxs();

        }

        /// <summary>
        /// Box's rotating in circular motion
        /// </summary>
        private void flyingBoxs()
        {
            var pictureBox = new RotatingPictureBox
            {
                Angle = Math.PI,
                Speed = Math.PI / 20,
                Distance = 50,
                BackColor = Color.Black,
                Width = 10,
                Height = 10,
                Location = new Point(100, 50)
            };
            Controls.Add(pictureBox);
            var timer = new System.Windows.Forms.Timer { Interval = 50 };
            timer.Tick += (sender, args) => pictureBox.RotateStep();
            timer.Start();

            var pictureBox2 = new RotatingPictureBox
            {
                Angle = Math.PI,
                Speed = Math.PI / 20,
                Distance = 20,
                BackColor = Color.Black,
                Width = 30,
                Height = 10,
                Location = new Point(200, 60)
            };
            Controls.Add(pictureBox2);
            var timer2 = new System.Windows.Forms.Timer { Interval = 20 };
            timer2.Tick += (sender, args) => pictureBox2.RotateStep();
            timer2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            RestartRace();

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            IPlane p1 = new Plane1(pictureBox1);   

            Task task1 = new Task(new Action( ()=> { 
                    
                    for (int i = 100; i < 200; i++)
                    {
                        p1.moveRight();
                        if (isBoundingBox_intersecting_finishline(p1))
                        {
                            MessageBox.Show("Plane 1 Won");
                            tokenSource.Cancel();
                            break;
                        }
                        else
                        {
                            Random rnd = new Random(i);
                            Thread.Sleep(rnd.Next(0,1000));
                        }                
                    }
            }),token);

            IPlane p2 = new Plane2(pictureBox2);

            Task task2 = new Task(new Action(() =>
            {

                for (int i = 0; i < 100; i++) // replicate 100 miles
                {
                    p2.moveRight();
                    if (isBoundingBox_intersecting_finishline(p2))
                    {
                        MessageBox.Show("Plane 2 Won");                        
                        tokenSource.Cancel();
                        break;
                    }
                    else
                    {
                        Random rnd = new Random(i);
                        Thread.Sleep(rnd.Next(0, 1000));
                    }
                }
            }),token);

            // run the race
            task1.Start();
            task2.Start();
            Task.WhenAny(task1, task2).ContinueWith((Action) =>
            {
                // Console.WriteLine("End");
                tokenSource.Cancel();
                button1.BeginInvoke((Action) (()=> { button1.Enabled = true; }));                
            });         
            

        }

        private void RestartRace()
        {
            pictureBox1.SetBounds(35, 98, 60, 60);
            pictureBox2.SetBounds(35, 164, 60, 60);
        }

        private bool isBoundingBox_intersecting_finishline(IPlane plane)
        {
            if (plane.getBoundingBoxRight() >= picBx_Finish_Line.Left)
            {
                return true;
            }
            return false;
        }

        #region Producer comsumer number thread .net 4.5 speed inprovements demo
        private void producer_consumer()
        {
            var items = new BufferBlock<String>(
            new DataflowBlockOptions { BoundedCapacity = 100 });

            Task.Run(async delegate
            {
                int s = 0;
                while (true)
                {
                    string item = Produce();
                    await items.SendAsync(item + s);
                    s++;
                }
            });

            Task.Run(async delegate
            {
                int s = 0;
                while (true)
                {
                    string item = await items.ReceiveAsync();
                    Process(item + " => " + s);
                    s++;
                }
            });
        }

        private string Produce()
        {
            //Thread.Sleep(2000);
            return "Produced ";
        }

        private void Process(string item)
        {
            Console.WriteLine(item + " Recieved");
        } 
        #endregion
    }

    class RotatingPictureBox : PictureBox
    {
        public double Angle { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }

        public void RotateStep()
        {
            var oldX = Math.Cos(Angle) * Distance;
            var oldY = Math.Sin(Angle) * Distance;
            Angle += Speed;
            var x = Math.Cos(Angle) * Distance - oldX;
            var y = Math.Sin(Angle) * Distance - oldY;
            Location += new Size((int)x, (int)y);
        }
    }
}
