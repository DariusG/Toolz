using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;


namespace Toolz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Username = textBox1.Text;
            Password = textBox2.Text;
            allowLogin = false;

            CheckIDs();
        }

        String Username;
        String Password;
        Boolean allowLogin;

        private void CheckIDs()
        {
            //System.Management.SelectQuery Query = new System.Management.SelectQuery("Win32_Processor");
            //System.Management.ManagementObjectSearcher Searcher = new System.Management.ManagementObjectSearcher(Query);
            //System.Management.ManagementObject ManageObject = new System.Management.ManagementObject();

            //Check if the username is equal to the saved username
            if (Username.ToLower() == Properties.Settings.Default.Username.ToLower())
            {
                //Check if the password is equal to the saved password
                if (Password.ToLower() == Properties.Settings.Default.Password.ToLower())
                {
                    //Check if the user's ProcessorID is equal to the saved ProcessID
                    if (GetProcessorID() == Properties.Settings.Default.ProcessorID)
                    {
                        //A Boolean that will allow you to login
                        allowLogin = true;
                        Login();
                    }
                    else
                    {
                        //A Boolean that will not allow you to login
                        allowLogin = false;
                        Login();
                    }
                }
            }
        }

        private void Login()
        {
            if (allowLogin == true)
            {
                //Add your Login Code
                MessageBox.Show("Congrats, you have a valid licence for your computer");
            }
            else
            {
                //Do Nothing
                //Or
                //Add your Other Code
                MessageBox.Show("Illegal Copying of software is not clever !!! ");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //SelectQuery Query = new System.Management.SelectQuery("Win32_Processor");
            //ManagementObjectSearcher Searcher = new System.Management.ManagementObjectSearcher(Query);
            //ManagementObject ManageObject = new System.Management.ManagementObject();
            textBox3.Text = GetProcessorID();
            label1.Content = GetProcessorID();
        }

        public static string GetProcessorID()
        {
            var processorID = "";
            var query = "SELECT ProcessorId FROM Win32_Processor";

            var oManagementObjectSearcher = new ManagementObjectSearcher(query);

            foreach (var oManagementObject in oManagementObjectSearcher.Get())
            {
                processorID = (string)oManagementObject["ProcessorId"];
                break;
            }

            return processorID;
        } 


    }
}
