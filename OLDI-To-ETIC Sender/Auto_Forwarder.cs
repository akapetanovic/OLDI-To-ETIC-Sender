using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace OLDI_To_ETIC_Sender
{
    public partial class Auto_Forwarder : Form
    {
        public Auto_Forwarder()
        {
            InitializeComponent();
        }

        private void Auto_Forwarder_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress address = IPAddress.Parse(this.textBoxPartnerAddress.Text);
                IPEndPoint serverEndPoint = new IPEndPoint(address, int.Parse(textBoxPortNumber.Text));
                IPAddress Local_address = IPAddress.Parse(this.comboBoxNetworkInterface.SelectedItem.ToString());

                Socket tcpSocket =
                    new Socket(
                        address.AddressFamily,
                        SocketType.Stream,
                        ProtocolType.Tcp);
                try
                {
                    tcpSocket.Bind(new IPEndPoint(Local_address, int.Parse(textBoxPortNumber.Text)));
                    tcpSocket.Connect(serverEndPoint);
               
                    StreamReader reader = null;
                    try
                    {
                        NetworkStream networkStream =
                            new NetworkStream(tcpSocket);
                        reader = new StreamReader(networkStream);
                        string serverMessage = reader.ReadLine();
                        listBoxReceivedData.Items.Add(serverMessage);
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Close();
                    }

                }
                catch (SocketException ex)
                {
                    if (tcpSocket != null)
                        tcpSocket.Close();

                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
            }
        }

        private void Auto_Forwarder_VisibleChanged(object sender, EventArgs e)
        {
            comboBoxNetworkInterface.Items.Clear();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            comboBoxNetworkInterface.Items.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            if (comboBoxNetworkInterface.Items.Count > 0)
                comboBoxNetworkInterface.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Visible = false;
        }
    }
}
