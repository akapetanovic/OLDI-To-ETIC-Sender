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

        string Local_Interface_Address;
        string Partner_IP;
        string Partner_Port;

        public Auto_Forwarder()
        {
            InitializeComponent();
        }

        private void Auto_Forwarder_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            LoadOLDIPartners();
        }

        private void LoadOLDIPartners()
        {
            this.comboBoxP_ID.Items.Clear();
            this.comboBoxPartnerIP.Items.Clear();
            this.comboBoxP_Port.Items.Clear();

            if (Properties.Settings.Default.P_ID3.Length > 0 && Properties.Settings.Default.P_ADDR3.Length > 0 && Properties.Settings.Default.P_PORT3.Length > 0)
            {
                this.comboBoxP_ID.Items.Add(Properties.Settings.Default.P_ID3);
                this.comboBoxPartnerIP.Items.Add(Properties.Settings.Default.P_ADDR3);
                this.comboBoxP_Port.Items.Add(Properties.Settings.Default.P_PORT3);
            }
            if (Properties.Settings.Default.P_ID2.Length > 0 && Properties.Settings.Default.P_ADDR2.Length > 0 && Properties.Settings.Default.P_PORT2.Length > 0)
            {
                this.comboBoxP_ID.Items.Add(Properties.Settings.Default.P_ID2);
                this.comboBoxPartnerIP.Items.Add(Properties.Settings.Default.P_ADDR2);
                this.comboBoxP_Port.Items.Add(Properties.Settings.Default.P_PORT2);
            }
            if (Properties.Settings.Default.P_ID1.Length > 0 && Properties.Settings.Default.P_ADDR1.Length > 0 && Properties.Settings.Default.P_PORT1.Length > 0)
            {
                this.comboBoxP_ID.Items.Add(Properties.Settings.Default.P_ID1);
                this.comboBoxPartnerIP.Items.Add(Properties.Settings.Default.P_ADDR1);
                this.comboBoxP_Port.Items.Add(Properties.Settings.Default.P_PORT1);
            }

            if (this.comboBoxP_ID.Items.Count > 0)
            {
                this.comboBoxP_ID.SelectedIndex = 0;
                this.comboBoxPartnerIP.SelectedIndex = 0;
                this.comboBoxP_Port.SelectedIndex = 0;
            }
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
                            SocketType.Raw, ProtocolType.IPv6);

                        //Bind the socket to the selected IP address
                        mainSocket.Bind(new IPEndPoint(IPAddress.Parse(comboBoxNetworkInterface.Text), 0));

                        //Set the socket  options
                        mainSocket.SetSocketOption(SocketOptionLevel.IPv6,            //Applies only to IP packets
                                                   SocketOptionName.HeaderIncluded, //Set the include the header
                                                   true);                           //option to true
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

        private void ParseData(byte[] byteData, int nReceived)
        {
            TreeNode rootNode = new TreeNode();

            //Since all protocol packets are encapsulated in the IP datagram
            //so we start by parsing the IP header and see what protocol data
            //is being carried by it
            IPHeader ipHeader = new IPHeader(byteData, nReceived);

            bool Process = true;
            bool OLDI_Check_Requested = false;
            bool Inhibit_Due_To_Not_Valid_FMTP = false;
            IPAddress Partner_Address = IPAddress.Parse(Partner_IP);

            ////////////////////////////////////////////////////////////////////////////
            // Here check if OLDI partner IP address and Port number have been defined
            // If so then check that only applicable OLDI data is processed and rest ignored.
            // If no data is provided then process all data
            if ((Partner_IP.Length > 0) && (Partner_Port.Length > 0))
            {
                Process = false;
                OLDI_Check_Requested = true;

                // First check if this is TCP
                if ((ipHeader.ProtocolType == Protocol.TCP))
                {
                    // Only process data going between two partners
                    if ((Local_Interface_Address == ipHeader.SourceAddress.ToString()) && (Partner_Address.ToString() == ipHeader.DestinationAddress.ToString()))
                    {
                        Process = true;
                    }
                    else if ((Partner_Address.ToString() == ipHeader.SourceAddress.ToString()) && (Local_Interface_Address.ToString() == ipHeader.DestinationAddress.ToString()))
                    {
                        Process = true;
                    }
                }
            }

            if (Process)
            {
                if (OLDI_Check_Requested == false)
                {
                    TreeNode ipNode = MakeIPTreeNode(ipHeader);
                    rootNode.Nodes.Add(ipNode);
                }

                //Now according to the protocol being carried by the IP datagram we parse 
                //the data field of the datagram
                switch (ipHeader.ProtocolType)
                {
                    case Protocol.TCP:

                        TCPHeader tcpHeader = new TCPHeader(ipHeader.Data,//IPHeader.Data stores the data being carried by the IP datagram
                                                            ipHeader.MessageLength);//Length of the data field 

                        bool Is_OLDI = ((tcpHeader.DestinationPort == Partner_Port) || (tcpHeader.SourcePort == Partner_Port));

                        if (OLDI_Check_Requested && Is_OLDI)
                        {
                            FMTP_Parser.FMPT_Header_and_Data Parsed_Msg = FMTP_Parser.FMTP_Msg_Parser(tcpHeader.Data);

                            if (Parsed_Msg.Valid_FMTP_Data == false)
                            {
                                Inhibit_Due_To_Not_Valid_FMTP = true;
                            }
                            else
                            {
                                TreeNode tcpNode = MakeTCPTreeNode(tcpHeader, OLDI_Check_Requested, Parsed_Msg);
                                rootNode.Nodes.Add(tcpNode);
                            }
                        }
                        else if (OLDI_Check_Requested == false)
                        {
                            TreeNode tcpNode = MakeTCPTreeNode(tcpHeader, OLDI_Check_Requested, new FMTP_Parser.FMPT_Header_and_Data());
                            rootNode.Nodes.Add(tcpNode);

                            //If the port is equal to 53 then the underlying protocol is DNS
                            //Note: DNS can use either TCP or UDP thats why the check is done twice
                            if (tcpHeader.DestinationPort == "53" || tcpHeader.SourcePort == "53")
                            {
                                TreeNode dnsNode = MakeDNSTreeNode(tcpHeader.Data, (int)tcpHeader.MessageLength);
                                rootNode.Nodes.Add(dnsNode);
                            }
                        }
                        else
                        {
                            Inhibit_Due_To_Not_Valid_FMTP = true;
                        }

                        break;

                    case Protocol.UDP:

                        UDPHeader udpHeader = new UDPHeader(ipHeader.Data,              //IPHeader.Data stores the data being 
                            //carried by the IP datagram
                                                           (int)ipHeader.MessageLength);//Length of the data field                    

                        TreeNode udpNode = MakeUDPTreeNode(udpHeader);

                        rootNode.Nodes.Add(udpNode);

                        //If the port is equal to 53 then the underlying protocol is DNS
                        //Note: DNS can use either TCP or UDP thats why the check is done twice
                        if (udpHeader.DestinationPort == "53" || udpHeader.SourcePort == "53")
                        {

                            TreeNode dnsNode = MakeDNSTreeNode(udpHeader.Data,
                                //Length of UDP header is always eight bytes so we subtract that out of the total 
                                //length to find the length of the data
                                                               Convert.ToInt32(udpHeader.Length) - 8);
                            rootNode.Nodes.Add(dnsNode);
                        }

                        break;

                    case Protocol.Unknown:
                        break;
                }

                if (Inhibit_Due_To_Not_Valid_FMTP == false)
                {
                    AddTreeNode addTreeNode = new AddTreeNode(OnAddTreeNode);
                    string Date_Time = DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToLongTimeString();

                    string Source = ipHeader.SourceAddress.ToString();
                    string Destination = ipHeader.DestinationAddress.ToString();

                    if (Source == Properties.Settings.Default.P_ADDR1)
                        Source = Properties.Settings.Default.P_ID1;
                    else if (Source == Properties.Settings.Default.P_ADDR2)
                        Source = Properties.Settings.Default.P_ID2;
                    else if (Source == Properties.Settings.Default.P_ADDR3)
                        Source = Properties.Settings.Default.P_ID3;
                    else if (Source == Properties.Settings.Default.P_ADDR4)
                        Source = Properties.Settings.Default.P_ID4;

                    if (Destination == Properties.Settings.Default.P_ADDR1)
                        Destination = Properties.Settings.Default.P_ID1;
                    else if (Source == Properties.Settings.Default.P_ADDR2)
                        Destination = Properties.Settings.Default.P_ID2;
                    else if (Destination == Properties.Settings.Default.P_ADDR3)
                        Destination = Properties.Settings.Default.P_ID3;
                    else if (Destination == Properties.Settings.Default.P_ADDR4)
                        Destination = Properties.Settings.Default.P_ID4;

                    rootNode.Text = Date_Time + ": " + Source + "  ->  " + Destination;
                    
                    //Thread safe adding of the nodes
                    treeView.Invoke(addTreeNode, new object[] { rootNode });
                }
            }
        }

        //Helper function which returns the information contained in the IP header as a
        //tree node
        private TreeNode MakeIPTreeNode(IPHeader ipHeader)
        {
            TreeNode ipNode = new TreeNode();

            ipNode.Text = "IP";
            ipNode.Nodes.Add("Ver: " + ipHeader.Version);
            ipNode.Nodes.Add("Header Length: " + ipHeader.HeaderLength);
            ipNode.Nodes.Add("Differntiated Services: " + ipHeader.DifferentiatedServices);
            ipNode.Nodes.Add("Total Length: " + ipHeader.TotalLength);
            ipNode.Nodes.Add("Identification: " + ipHeader.Identification);
            ipNode.Nodes.Add("Flags: " + ipHeader.Flags);
            ipNode.Nodes.Add("Fragmentation Offset: " + ipHeader.FragmentationOffset);
            ipNode.Nodes.Add("Time to live: " + ipHeader.TTL);
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:
                    ipNode.Nodes.Add("Protocol: " + "TCP");
                    break;
                case Protocol.UDP:
                    ipNode.Nodes.Add("Protocol: " + "UDP");
                    break;
                case Protocol.Unknown:
                    ipNode.Nodes.Add("Protocol: " + "Unknown");
                    break;
            }
            ipNode.Nodes.Add("Checksum: " + ipHeader.Checksum);
            ipNode.Nodes.Add("Source: " + ipHeader.SourceAddress.ToString());
            ipNode.Nodes.Add("Destination: " + ipHeader.DestinationAddress.ToString());

            return ipNode;
        }

        //Helper function which returns the information contained in the TCP header as a
        //tree node
        private TreeNode MakeTCPTreeNode(TCPHeader tcpHeader, bool OLDI_Data, FMTP_Parser.FMPT_Header_and_Data Parsed_Msg)
        {
            TreeNode tcpNode = new TreeNode();

            if (OLDI_Data == false)
            {
                tcpNode.Text = "TCP";

                tcpNode.Nodes.Add("Source Port: " + tcpHeader.SourcePort);
                tcpNode.Nodes.Add("Destination Port: " + tcpHeader.DestinationPort);
                tcpNode.Nodes.Add("Sequence Number: " + tcpHeader.SequenceNumber);

                if (tcpHeader.AcknowledgementNumber != "")
                    tcpNode.Nodes.Add("Acknowledgement Number: " + tcpHeader.AcknowledgementNumber);

                tcpNode.Nodes.Add("Header Length: " + tcpHeader.HeaderLength);
                tcpNode.Nodes.Add("Flags: " + tcpHeader.Flags);
                tcpNode.Nodes.Add("Window Size: " + tcpHeader.WindowSize);
                tcpNode.Nodes.Add("Checksum: " + tcpHeader.Checksum);

                if (tcpHeader.UrgentPointer != "")
                    tcpNode.Nodes.Add("Urgent Pointer: " + tcpHeader.UrgentPointer);
            }
            else
            {
                tcpNode.Text = "OLDI";
                if (Properties.Settings.Default.Msg_Version)
                    tcpNode.Nodes.Add("Msg Version: " + Parsed_Msg.version);
                if (Properties.Settings.Default.Msg_Length)
                    tcpNode.Nodes.Add("Msg Length: " + Parsed_Msg.msg_length + " bytes");
                if (Properties.Settings.Default.Msg_Type)
                    tcpNode.Nodes.Add("Msg Type: " + Parsed_Msg.msg_type);
                if (Properties.Settings.Default.Msg_Content)
                    tcpNode.Nodes.Add("Msg Content: " + Parsed_Msg.msg_content);
            }

            return tcpNode;
        }

        //Helper function which returns the information contained in the UDP header as a
        //tree node
        private TreeNode MakeUDPTreeNode(UDPHeader udpHeader)
        {
            TreeNode udpNode = new TreeNode();

            udpNode.Text = "UDP";
            udpNode.Nodes.Add("Source Port: " + udpHeader.SourcePort);
            udpNode.Nodes.Add("Destination Port: " + udpHeader.DestinationPort);
            udpNode.Nodes.Add("Length: " + udpHeader.Length);
            udpNode.Nodes.Add("Checksum: " + udpHeader.Checksum);

            return udpNode;
        }

        //Helper function which returns the information contained in the DNS header as a
        //tree node
        private TreeNode MakeDNSTreeNode(byte[] byteData, int nLength)
        {
            DNSHeader dnsHeader = new DNSHeader(byteData, nLength);

            TreeNode dnsNode = new TreeNode();

            dnsNode.Text = "DNS";
            dnsNode.Nodes.Add("Identification: " + dnsHeader.Identification);
            dnsNode.Nodes.Add("Flags: " + dnsHeader.Flags);
            dnsNode.Nodes.Add("Questions: " + dnsHeader.TotalQuestions);
            dnsNode.Nodes.Add("Answer RRs: " + dnsHeader.TotalAnswerRRs);
            dnsNode.Nodes.Add("Authority RRs: " + dnsHeader.TotalAuthorityRRs);
            dnsNode.Nodes.Add("Additional RRs: " + dnsHeader.TotalAdditionalRRs);

            return dnsNode;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Save();
            this.Visible = false;
        }

        private void comboBoxNetworkInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Local_Interface_Address = comboBoxNetworkInterface.Text;
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

        private void comboBoxPartnerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxP_Port.SelectedIndex = this.comboBoxPartnerIP.SelectedIndex;
            this.comboBoxP_ID.SelectedIndex = this.comboBoxPartnerIP.SelectedIndex;

            Partner_IP = this.comboBoxPartnerIP.Text;
            Partner_Port = this.comboBoxP_Port.Text;
        }

        private void partnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OldiPartners Partners = new OldiPartners();
            Partners.Show();
        }

        private void comboBoxPartnerIP_Click(object sender, EventArgs e)
        {
            LoadOLDIPartners();
        }

        private void comboBoxP_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxP_ID.SelectedIndex = this.comboBoxP_Port.SelectedIndex;
            this.comboBoxPartnerIP.SelectedIndex = this.comboBoxP_Port.SelectedIndex;

            Partner_IP = this.comboBoxPartnerIP.Text;
            Partner_Port = this.comboBoxP_Port.Text;
        }

        private void comboBoxP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxP_Port.SelectedIndex = this.comboBoxP_ID.SelectedIndex;
            this.comboBoxPartnerIP.SelectedIndex = this.comboBoxP_ID.SelectedIndex;

            Partner_IP = this.comboBoxPartnerIP.Text;
            Partner_Port = this.comboBoxP_Port.Text;
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
