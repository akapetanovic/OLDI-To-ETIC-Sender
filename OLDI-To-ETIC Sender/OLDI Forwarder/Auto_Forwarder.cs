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
        private Socket mainSocket;                          //The socket which captures all incoming packets
        private byte[] byteData = new byte[4096];
        private bool bContinueCapturing = false;            //A flag to check if packets are to be captured or not

        private delegate void AddTreeNode(TreeNode node);

        string Partner_Port;
        bool Is_IPV6 = false;

        public Auto_Forwarder()
        {
            InitializeComponent();
        }

        private void Auto_Forwarder_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            UpdateSettingParametersDisplay();
        }

        private void UpdateSettingParametersDisplay()
        {
            this.labelReceivingUnit.Text = GlobalDataAndSettings.Receiver;
            this.labelSendingUnit.Text = GlobalDataAndSettings.Sender;
            textBoxSourcePort.Text = Properties.Settings.Default.SourcePort;

            this.radioButtonServer.Text = "Server" + " (" + GlobalDataAndSettings.Receiver + " )";
            this.radioButtonClient.Text = "Client" + " (" + GlobalDataAndSettings.Sender + " )";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bContinueCapturing)
                {
                    //Start capturing the packets...

                    btnStart.Text = "&Stop";

                    bContinueCapturing = true;

                    // Here determine if the selected interface is IPv6 or IPV4
                    if (comboBoxNetworkInterface.Text.Length > 15)
                    {

                        //For sniffing the socket to capture the packets has to be a raw socket, with the
                        //address family being of type internetwork, and protocol being IP
                        mainSocket = new Socket(AddressFamily.InterNetworkV6,
                            SocketType.Raw, ProtocolType.IP);

                        //Bind the socket to the selected IP address
                        mainSocket.Bind(new IPEndPoint(IPAddress.Parse(comboBoxNetworkInterface.Text), 0));

                        //Set the socket  options
                        mainSocket.SetSocketOption(SocketOptionLevel.IPv6,            //Applies only to IP packets
                                                   SocketOptionName.HeaderIncluded, //Set the include the header
                                                   true);                           //option to true

                        Is_IPV6 = true;
                    }
                    else
                    {
                        //For sniffing the socket to capture the packets has to be a raw socket, with the
                        //address family being of type internetwork, and protocol being IP
                        mainSocket = new Socket(AddressFamily.InterNetwork,
                            SocketType.Raw, ProtocolType.IP);

                        //Bind the socket to the selected IP address
                        mainSocket.Bind(new IPEndPoint(IPAddress.Parse(comboBoxNetworkInterface.Text), 0));

                        //Set the socket  options
                        mainSocket.SetSocketOption(SocketOptionLevel.IP,            //Applies only to IP packets
                                                   SocketOptionName.HeaderIncluded, //Set the include the header
                                                   true);                           //option to true

                        Is_IPV6 = false;
                    }

                    byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                    byte[] byOut = new byte[4] { 1, 0, 0, 0 }; //Capture outgoing packets

                    //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                    mainSocket.IOControl(IOControlCode.ReceiveAll,              //Equivalent to SIO_RCVALL constant
                        //of Winsock 2
                                         byTrue,
                                         byOut);

                    //Start receiving the packets asynchronously
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
                else
                {
                    btnStart.Text = "&Start";
                    bContinueCapturing = false;
                    //To stop capturing the packets close the socket
                    mainSocket.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OLDI to ETIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar);

                //Analyze the bytes received...
                ParseData(byteData, nReceived);

                if (bContinueCapturing)
                {
                    byteData = new byte[4096];

                    //Another call to BeginReceive so that we continue to receive the incoming
                    //packets
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OLDI to ETIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class Common_Header_Data
        {
            public IPAddress SourceAddress;
            public IPAddress DestinationAddress;
            public Protocol ProtocolType;
            public byte[] Data = new byte[4096];  //Data carried by the datagram
            public ushort MessageLength;
        }

        private void ParseData(byte[] byteData, int nReceived)
        {
            TreeNode rootNode = new TreeNode();
            Common_Header_Data ipHeader = new Common_Header_Data();
            IPHeader_IPV4 ipHeader_IPV4;

            if (!Is_IPV6)
            {
                ipHeader_IPV4 = new IPHeader_IPV4(byteData, nReceived);
                ipHeader.Data = ipHeader_IPV4.Data;
                ipHeader.DestinationAddress = ipHeader_IPV4.DestinationAddress;
                ipHeader.SourceAddress = ipHeader_IPV4.SourceAddress;
                ipHeader.ProtocolType = ipHeader_IPV4.ProtocolType;
                ipHeader.MessageLength = ipHeader_IPV4.MessageLength;
            }
            else
            {
                ipHeader.Data = byteData;
                ipHeader.MessageLength = (ushort)nReceived;
                ipHeader.ProtocolType = Protocol.TCP;
            }

            if (ipHeader.ProtocolType == Protocol.TCP)
            {
                TCPHeader tcpHeader = new TCPHeader(ipHeader.Data,//IPHeader.Data stores the data being carried by the IP datagram
                                                    ipHeader.MessageLength);//Length of the data field 

                if (tcpHeader.SourcePort == Properties.Settings.Default.SourcePort || tcpHeader.DestinationPort == Properties.Settings.Default.SourcePort)
                {
                    AddTreeNode addTreeNode = new AddTreeNode(OnAddTreeNode);
                    string Date_Time = DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToLongTimeString();

                    FMTP_Parser.FMPT_Header_and_Data FMTP_Data = FMTP_Parser.FMTP_Msg_Parser(tcpHeader.Data);

                    if (FMTP_Data.Valid_FMTP_Data)
                    {
                        TreeNode fmtpNode = MakeFMTPTreeNode(FMTP_Data);
                        rootNode.Nodes.Add(fmtpNode);

                        string Source;
                        string Destination;

                        if (tcpHeader.SourcePort == Properties.Settings.Default.SourcePort)
                        {
                            Destination = Properties.Settings.Default.Sender;
                            Source = Properties.Settings.Default.Receiver;
                        }
                        else
                        {
                            Source = Properties.Settings.Default.Sender;
                            Destination = Properties.Settings.Default.Receiver;
                        }

                        rootNode.Text = Date_Time + ": " + Source + "  ->  " + Destination;

                        //Thread safe adding of the nodes
                        treeView.Invoke(addTreeNode, new object[] { rootNode });

                        // Now check if Auto forward to ETIC is requested
                        //
                        // CLIENT DATA IS TO BE FORWARDED
                        if (this.radioButtonClient.Checked && (Source == Properties.Settings.Default.Sender))
                        {

                        }
                        // SERVER DATA IS TO BE FORWARDED
                        else if (this.radioButtonServer.Checked && Source == Properties.Settings.Default.Receiver)
                        {

                        }
                    }
                }
            }
        }

        //Helper function which returns the information contained in the TCP header as a
        //tree node
        private TreeNode MakeFMTPTreeNode(FMTP_Parser.FMPT_Header_and_Data FMPT_Data)
        {
            TreeNode tcpNode = new TreeNode();
            tcpNode.Text = "OLDI";
            if (Properties.Settings.Default.Msg_Version)
                tcpNode.Nodes.Add("Msg Version: " + FMPT_Data.version);
            if (Properties.Settings.Default.Msg_Length)
                tcpNode.Nodes.Add("Msg Length: " + FMPT_Data.msg_length + " bytes");
            if (Properties.Settings.Default.Msg_Type)
                tcpNode.Nodes.Add("Msg Type: " + FMPT_Data.msg_type);
            if (Properties.Settings.Default.Msg_Content)
                tcpNode.Nodes.Add("Msg Content: " + FMPT_Data.msg_content);

            return tcpNode;
        }

        private void OnAddTreeNode(TreeNode node)
        {
            treeView.Nodes.Add(node);
        }

        private void Auto_Forwarder_VisibleChanged(object sender, EventArgs e)
        {
            comboBoxNetworkInterface.Items.Clear();
            string strIP = null;
            IPHostEntry HosyEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (HosyEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in HosyEntry.AddressList)
                {
                    strIP = ip.ToString();
                    comboBoxNetworkInterface.Items.Add(strIP);
                }

                comboBoxNetworkInterface.SelectedIndex = 0;
            }

            UpdateSettingParametersDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Save();
            this.Visible = false;
        }

        private void comboBoxNetworkInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPartnerAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPortNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPartnerIP_Click(object sender, EventArgs e)
        {
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxP_Port_Leave(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
        }

        private void textBoxSourcePort_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SourcePort = textBoxSourcePort.Text;
            Properties.Settings.Default.Save();
        }
    }
}
