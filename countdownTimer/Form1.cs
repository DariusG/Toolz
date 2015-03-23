using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace TimeFun
{
    public partial class Form1 : Form
    {
        public int Seconds; // Seconds.
        public int Minutes; // Minutes.
        public int Hours;   // Hours.
        public bool Paused; // State of the timer [PAUSED/WORKING].

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Countdown_Click(object sender, EventArgs e)
        {
            if (Paused != true)
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    tmrCountdown.Enabled = true;
                    btn_Pause_Countdown.Enabled = true;
                    btn_Start_Countdown.Enabled = false;
                    btn_Stop_Countdown.Enabled = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;

                    try
                    {
                        Minutes = Convert.ToInt32(textBox2.Text);
                        Seconds = Convert.ToInt32(textBox3.Text);
                        Hours = Convert.ToInt32(textBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(@"Incomplete settings!");
                }
            }
            else
            {
                tmrCountdown.Enabled = true;
                Paused = false;
                btn_Start_Countdown.Enabled = false;
                btn_Pause_Countdown.Enabled = true;
            }
        }

        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            // Verify if the time didn't pass.
            if ((Minutes == 0) && (Hours == 0) && (Seconds == 0))
            {
                // If the time is over, clear all settings and fields.
                // Also, show the message, notifying that the time is over.
                tmrCountdown.Enabled = false;
                MessageBox.Show(textBox4.Text);
                btn_Pause_Countdown.Enabled = false;
                btn_Stop_Countdown.Enabled = false;
                btn_Start_Countdown.Enabled = true;
                textBox4.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox1.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = true;
                lblHr.Text = @"00";
                lblMin.Text = @"00";
                lblSec.Text = @"00";
            }
            else
            {
                // Else continue counting.
                if (Seconds < 1)
                {
                    Seconds = 59;
                    if (Minutes == 0)
                    {
                        Minutes = 59;
                        if (Hours != 0)
                            Hours -= 1;

                    }
                    else
                    {
                        Minutes -= 1;
                    }
                }
                else
                    Seconds -= 1;
                // Display the current values of hours, minutes and seconds in
                // the corresponding fields.
                lblHr.Text = Hours.ToString(CultureInfo.InvariantCulture);
                lblMin.Text = Minutes.ToString(CultureInfo.InvariantCulture);
                lblSec.Text = Seconds.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void btn_Pause_Countdown_Click(object sender, EventArgs e)
        {
            // Pause the timer.
            tmrCountdown.Enabled = false;
            Paused = true;
            btn_Pause_Countdown.Enabled = false;
            btn_Start_Countdown.Enabled = true;
        }

        private void btn_Stop_Countdown_Click(object sender, EventArgs e)
        {
            // Stop the timer.
            Paused = false;
            tmrCountdown.Enabled = false;
            btn_Pause_Countdown.Enabled = false;
            btn_Stop_Countdown.Enabled = false;
            btn_Start_Countdown.Enabled = true;
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Enabled = true;
            lblHr.Text = @"00";
            lblMin.Text = @"00";
            lblSec.Text = @"00";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckIfRunning();
        }

        private void btn_Alarm_Set_Click(object sender, EventArgs e)
        {
            timerAlarm1.Enabled = true;   
        }

        private void timerAlarm1_Tick(object sender, EventArgs e)
        {
            var tmp = DateTime.Now.TimeOfDay;
            string alarm =  dateTimePicker1.Text;
            string currentTime = tmp.Hours + ":" + tmp.Minutes + ":" + tmp.Seconds;

            Console.WriteLine(@"Alarm Time => {0}", alarm);
            Console.WriteLine(@"Clock Time => {0}", currentTime);

            if (alarm.Equals(currentTime))
            {
                timerAlarm1.Enabled = false;
                MessageBox.Show(@"!!!! Alarm Reached !!!!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Process.GetProcessesByName("TimeFun").Count() > 1)
            {
                DialogResult dr = MessageBox.Show(@"Already Running", @"TimeFun.exe is running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    _seletabletoclose = false;
                    e.Cancel = true;
                    base.OnFormClosing(e);
                    Application.ExitThread();
                }
            }
            else
            {
                if (_seletabletoclose)
                {
                    e.Cancel = false;
                }
                else
                {
                    Hide();
                    e.Cancel = true;
                }
                base.OnFormClosing(e);
            }
        }

        bool _seletabletoclose;

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Equals("showToolStripMenuItem"))
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                _seletabletoclose = true;
            }
        }

        private void CheckIfRunning()
        {
            if (Process.GetProcessesByName("TimeFun").Count() > 1)
            {
                _seletabletoclose = false;
//                Form1.ActiveForm.Close();
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBx = new AboutBox1();
            aboutBx.ShowDialog();
        }  
    }
}
