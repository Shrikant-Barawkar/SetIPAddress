using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Management;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Net.NetworkInformation;

namespace SetIPAddress
{
    public partial class frmIPSet : Form
    {

        public frmIPSet()
        {
            InitializeComponent();
        }


        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" + Application.StartupPath + "\\SetIP.mdb;";

        string interfaceName;  // Change to your actual interface name
        string newIP;    // New IP Address
        string subnetMask;// Subnet Mask
        string gateway;   // Default Gateway

        public OleDbConnection DBConnection;
        public OleDbCommand DBCommand;
        public OleDbDataReader DBReader;
        private void LoadComboBoxData()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                cmbPTselection.Items.Clear();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM SetIP", conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbPTselection.Items.Add(reader["HostName"].ToString());
                }
                cmbPTselection.SelectedValue = null;
            }

            btnSave.Visible = false;


            //Adding availabel interface names in combox selection of interface name.
            cmbInterfaceName.Items.Clear(); // Clear existing items

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Add all interface names
                cmbInterfaceName.Items.Add(nic.Name);
            }

            // Optionally select the first item
            //if (cmbInterfaceName.Items.Count > 0)
            //    cmbInterfaceName.SelectedIndex = 0;
        }
        private void LoadSelectedHostDetails(string hostname)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM SetIP WHERE HostName = @hostname", conn);
                cmd.Parameters.AddWithValue("@hostname", hostname);

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxHostName.Text = reader["HostName"].ToString();
                    //textBoxInterfaceName.Text = reader["InterfaceName"].ToString();
                    cmbInterfaceName.Text = reader["InterfaceName"].ToString();
                    textBoxNewIP.Text = reader["IPaddress"].ToString();
                    textBoxGateway.Text = reader["DefaultGateway"].ToString();
                    textBoxSubnetMask.Text = reader["SubnetMask"].ToString();

                    // Disable text boxes to prevent editing
                    EnableTextBoxes(false);
                }
            }
        }
        private void ClearTextBoxes()
        {
            //textBoxInterfaceName.Clear();
            cmbInterfaceName.SelectedIndex=-1;
            textBoxNewIP.Clear();
            textBoxGateway.Clear();
            textBoxSubnetMask.Clear();
        }

        private void EnableTextBoxes(bool newStatus)
        {
            //textBoxInterfaceName.Enabled = newStatus;
            cmbInterfaceName.Enabled = newStatus;
            textBoxNewIP.Enabled = newStatus;
            textBoxGateway.Enabled = newStatus;
            textBoxSubnetMask.Enabled = newStatus;
        }

        // Function to change IP address using netsh
        static void ChangeIPAddress(string interfaceName, string newIP, string subnetMask, string gateway)
        {
            //string command = string.Format("netsh interface ip set address \\{0}\\static {1} {2} {3}", interfaceName, newIP, subnetMask, gateway);
            string command = $"netsh interface ip set address {interfaceName} static {newIP} {subnetMask} {gateway}";

            //string command = $"netsh interface ip set address \"{interfaceName}\" static {newIP} {subnetMask} {gateway}";
            ExecuteCommand(command);
        }

        // Function to verify the IP address change
        static void VerifyIPAddress(string expectedIP)
        {
            string[] ipSplit = expectedIP.Split('.');
            expectedIP = string.Format("{0}.{1}.{2}.{3}", int.Parse(ipSplit[0]), int.Parse(ipSplit[1]), int.Parse(ipSplit[2]), int.Parse(ipSplit[3]));
            string command = "ipconfig";
            string output = ExecuteCommand(command);
            Thread.Sleep(5000);
            MessageBox.Show(expectedIP + "\n\n" + output);
            if (output.Contains(expectedIP))
            {
                MessageBox.Show(string.Format("IP Address successfully changed to: {0}", expectedIP));
            }
            else
            {
                MessageBox.Show("Failed to change the IP address.");
            }
        }

        // Execute a command and return the output
        static string ExecuteCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processStartInfo))
            using (System.IO.StreamReader reader = process.StandardOutput)
            {
                return reader.ReadToEnd();
            }
        }

        private void frmIPSet_Load(object sender, EventArgs e)
        {
            // Check if the application is running with administrator privileges
            if (!IsRunningAsAdministrator())
            {
                // Restart the application with administrator privileges
                RestartWithAdminRights();
                MessageBox.Show("Not with administrator privileges.");
            }
            else
            {
                // Your code that requires elevated privileges
                MessageBox.Show("Running with administrator privileges.");
            }

            LoadComboBoxData();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            //setIP(mtxtIP.Text, mtxtSubnet.Text);
            //ChangeIPAddress(textBoxInterfaceName.Text, textBoxNewIP.Text, textBoxSubnetMask.Text, textBoxGateway.Text);
            ChangeIPAddress(cmbInterfaceName.Text, textBoxNewIP.Text, textBoxSubnetMask.Text, textBoxGateway.Text);
            Thread.Sleep(5000);
            //        // Verify if the IP address was changed successfully
            VerifyIPAddress(textBoxNewIP.Text);
        }

        private void cmbPTselection_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cmbPTselection.Text == "TRIO")
            //{
            //    // Call the function to change the IP address
            //    interfaceName = "Ethernet";  // Change to your actual interface name
            //    newIP = "192.168.0.250";    // New IP Address
            //    subnetMask = "255.255.255.0"; // Subnet Mask
            //    gateway = "192.168.0.10";   // Default Gateway
            //}
            //else if (cmbPTselection.Text == "PMAC")
            //{
            //    // Call the function to change the IP address
            //    interfaceName = "Ethernet";  // Change to your actual interface name
            //    newIP = "192.168.1.250";    // New IP Address
            //    subnetMask = "255.255.255.0"; // Subnet Mask
            //    gateway = "192.168.0.10";   // Default Gateway
            //}
            //else if (cmbPTselection.Text == "Work")
            //{
            //    // Call the function to change the IP address
            //    interfaceName = "Ethernet";  // Change to your actual interface name
            //    newIP = "10.32.0.178";    // New IP Address
            //    subnetMask = "255.255.255.0"; // Subnet Mask
            //    gateway = "10.32.0.10";   // Default Gateway
            //}
            //else if (cmbPTselection.Text == "Personal")
            //{
            //    // Call the function to change the IP address
            //    interfaceName = "Ethernet";  // Change to your actual interface name
            //    newIP = "192.148.0.200";    // New IP Address
            //    subnetMask = "255.255.255.0"; // Subnet Mask
            //    gateway = "192.148.0.100";   // Default Gateway
            //}
            //else if (cmbPTselection.Text == "---NEW---")
            //{

            //}
            if (cmbPTselection.SelectedItem.ToString() == "--New--")
            {
                // Clear text boxes for new entry
                textBoxHostName.Clear();
                //textBoxInterfaceName.Clear();
                cmbInterfaceName.SelectedIndex = -1;
                textBoxNewIP.Clear();
                textBoxGateway.Clear();
                textBoxSubnetMask.Clear();

                // Enable text boxes for input
                EnableTextBoxes(true);
                btnSave.Visible = true;
            }
            else
            {
                // Load selected host details if not adding new
                LoadSelectedHostDetails(cmbPTselection.SelectedItem.ToString());
                btnSave.Visible = false;
            }

        }


        // Check if the application is running with administrator privileges
        static bool IsRunningAsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // Restart the application with administrator privileges
        static void RestartWithAdminRights()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Verb = "runas";  // This will trigger the UAC prompt
            startInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Process.Start(startInfo);
            Environment.Exit(0);  // Exit the current process
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPTselection.SelectedItem.ToString() == "--NEW--")
            {
                // Save new host entry
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO SetIP (HostName, InterfaceName, IPaddress, DefaultGateway, SubnetMask) VALUES (@hostname, @interfaceName, @ip, @gateway, @subnet)", conn);
                    cmd.Parameters.AddWithValue("@hostname", textBoxHostName.Text); // Use the selected value as hostname
                    //cmd.Parameters.AddWithValue("@interfaceName", textBoxInterfaceName.Text);
                    cmd.Parameters.AddWithValue("@interfaceName", cmbInterfaceName.Text);
                    cmd.Parameters.AddWithValue("@ip", textBoxNewIP.Text);
                    cmd.Parameters.AddWithValue("@gateway", textBoxGateway.Text);
                    cmd.Parameters.AddWithValue("@subnet", textBoxSubnetMask.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New entry saved successfully.");

                    // Reload combo box data
                    LoadComboBoxData();
                }
            }
        }
    }
}
