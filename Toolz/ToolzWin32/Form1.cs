using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
