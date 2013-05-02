using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace ToolzWin32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (internet_Connection_Check())
            {
                toolStripStatusLabel1.Text = "Internet Connected @ Startup: YES";
            }
            else
            {
                toolStripStatusLabel1.Text = "Internet Connected @ Startup: NO";
            }
        }

        public bool internet_Connection_Check()
        {
            var urls = "www.bbc.co.uk";
            Ping p = new Ping();
            PingReply v = p.Send(urls,2000);
            if (v.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (internet_Connection_Check())
            {
                toolStripStatusLabel1.Text = "Internet Connected: YES";
            }
            else
            {
                toolStripStatusLabel1.Text = "Internet Connected: NO";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckIfRunning();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();           
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Process.GetProcessesByName("ToolzWin32").Count() > 1)
            {
                DialogResult dr = MessageBox.Show("Already Running", "ToolzWin32.exe is running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    seletabletoclose = false;
                    e.Cancel = true;
                    base.OnFormClosing(e);
                    Application.ExitThread();
                }
            }
            else
            {
                if (seletabletoclose)
                {
                    e.Cancel = false;
                }
                else
                {
                    this.Hide();
                    e.Cancel = true;
                }
                base.OnFormClosing(e);
            }
        }

        bool seletabletoclose;

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Equals("showToolStripMenuItem"))
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                seletabletoclose = true;
            }
        }

        private void CheckIfRunning()
        {
            if (Process.GetProcessesByName("ToolzWin32").Count() > 1)
            {
                seletabletoclose = false;
                Application.Exit();
                Application.ExitThread();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = ComputerStats(); 
        }

        private static List<string> ComputerStats()
        {
            List<string> computerINFO = new List<string>();
            computerINFO.Add("Logical Drives on PC: " + string.Join(" | ", Environment.GetLogicalDrives().Select(x => x)));
            computerINFO.Add(Environment.CurrentDirectory);
            computerINFO.Add("Is Operating System x64: " + Environment.Is64BitOperatingSystem);
            computerINFO.Add("Machine Name: " + Environment.MachineName);
            computerINFO.Add("OS: " + Environment.OSVersion);
            computerINFO.Add("Processor Count: " + Environment.ProcessorCount);
            computerINFO.Add("Domain Name: " + Environment.UserDomainName);
            computerINFO.Add("User Name: " + Environment.UserName);
            computerINFO.Add(".Net CLR Version: " + Environment.Version);
            computerINFO.Add("UI Culture (Installed): " + System.Globalization.CultureInfo.InstalledUICulture);
            computerINFO.Add("UI Culture (Current): " + System.Globalization.CultureInfo.CurrentUICulture);
            return computerINFO;
        } 
    }
}
