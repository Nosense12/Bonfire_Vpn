using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Bonfire_Vpn
{
    public partial class mainform : Form
    {

        int germany = 0;
        int canada = 0;
        int canada2 = 0;
        int poland = 0;
        int usa = 0;
        int usa2 = 0;
        int france = 0;
        int france2 = 0;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public mainform()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            WebClient webClient = new WebClient();
            if (!webClient.DownloadString("https://pastebin.com/raw/3zJ4fnHX").Contains("3.0"))
            {
                if (MessageBox.Show("this is old version get other Do you want Update?", "Warn", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var prs = new ProcessStartInfo("iexplore");
                    prs.Arguments = "file:///D:/bonfire/bonfire.html";
                    Process.Start(prs);
                }
            }
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("AutoRUn",Application.ExecutablePath.ToString());
            germany = 1;
            ToolStripMenuItem tool = new ToolStripMenuItem();
            tool.Image = Properties.Resources.close;
            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.BackColor = Color.FromArgb(22, 22, 22);
            this.notifyIcon1.ContextMenuStrip.ForeColor = Color.White;
            this.notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add("Show", null, this.MenuStart_Click);
            this.notifyIcon2.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon2.ContextMenuStrip.BackColor = Color.FromArgb(22, 22, 22);
            this.notifyIcon2.ContextMenuStrip.ForeColor = Color.White;
            this.notifyIcon2.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);
            this.notifyIcon2.ContextMenuStrip.Items.Add("Show", null, this.MenuStart_Click);
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Exit", new EventHandler(MenuExit_Click));
        }

        void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void MenuStart_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
        private static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
            "\\VPN\\Sources\\Connect_And_Disconnect\\");
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            newProcess.WaitForExit();
            state2.Text = "DESPROTECTED";
            state2.ForeColor = Color.Firebrick;
            notifyIcon1.Visible = true;
            notifyIcon2.Visible = false;
            notifyIcon1.BalloonTipTitle = "VPN Has Disconnected";
            notifyIcon1.BalloonTipText = "Disconnected";
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void move_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void move_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void move_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void Canada()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "ca198.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }

        private void Canada2()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "ca222.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }
        private void Germany()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "de4.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }
        private void USA()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "us1.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }
        private void USA2()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "us2.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }
        private void Poland()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "PL226.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label1.Text = "Your Ip Has: " + "{HIDDED}";
            }
            else
            {
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress address in localIP)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                        label1.Text = "Your Ip Has: " + address.ToString();
                }
            }
        }

        private void France()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "fr1.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void France2()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "fr8.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + "t2xd9YL" + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Normal;
            newProcess.WaitForExit();
            state2.Text = "PROTECTED";
            state2.ForeColor = Color.ForestGreen;
            notifyIcon1.Visible = false;
            notifyIcon2.Visible = true;
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("Done");
            notifyIcon2.BalloonTipTitle = "Vpn Has Connected";
            notifyIcon2.BalloonTipText = "Vpn Has Started Goodluck!";
            notifyIcon2.ShowBalloonTip(1000);
        }

        private void countrys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mainform_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon2_Click(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            var sb = new StringBuilder();
            sb.AppendLine("@echo off");
            sb.AppendLine("ipconfig /release");
            sb.AppendLine("ipconfig /renew");
            sb.AppendLine("exit");

            File.WriteAllText("C:/Windows/System32\reset.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = "C:/Windows/System32\reset.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 0;
            france = 0;
            poland = 0;
            canada = 0;
            canada2 = 0;
            france2 = 0;
            germany = 1;
            label4.Text = "Chossed: Germany";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            usa2 = 1;
            usa = 0;
            france = 0;
            poland = 0;
            canada = 0;
            canada2 = 0;
            france2 = 0;
            germany = 0;
            label4.Text = "Chossed: USA2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 1;
            france = 0;
            poland = 0;
            canada = 0;
            canada2 = 0;
            france2 = 0;
            germany = 0;
            label4.Text = "Chossed: USA";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 0;
            france = 0;
            poland = 1;
            canada = 0;
            canada2 = 0;
            france2 = 0;
            germany = 0;
            label4.Text = "Chossed: Poland";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 0;
            france = 0;
            poland = 0;
            canada = 0;
            canada2 = 1;
            france2 = 0;
            germany = 0;
            label4.Text = "Chossed: Canada2";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 0;
            france = 0;
            poland = 0;
            canada = 1;
            canada2 = 0;
            france2 = 0;
            germany = 0;
            label4.Text = "Chossed: Canada";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 0;
            france = 0;
            poland = 0;
            canada = 0;
            canada2 = 0;
            france2 = 1;
            germany = 0;
            label4.Text = "Chossed: France2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            usa2 = 0;
            usa = 0;
            france = 1;
            poland = 0;
            canada = 0;
            canada2 = 0;
            france2 = 0;
            germany = 0;
            label4.Text = "Chossed: France";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (germany == 1)
            {
                Germany();
            }
            if (canada == 1)
            {
                Canada();
            }
            if (canada2 == 1)
            {
                Canada2();
            }
            if (poland == 1)
            {
                Poland();
            }
            if (usa == 1)
            {
                USA();
            }
            if (usa2 == 1)
            {
                USA2();
            }
            if (france == 1)
            {
                France();
            }
            if (france2 == 1)
            {
                France2();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuColorTransition1_OnValueChange(object sender, EventArgs e)
        {

        }

        private void mainform_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void bunifuButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                bunifuButton1.PerformClick();
            }
        }

        private void bunifuButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                bunifuButton2.PerformClick();
            }
        }
    }
}