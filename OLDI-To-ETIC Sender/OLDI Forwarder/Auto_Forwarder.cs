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

        public Auto_Forwarder()
        {
            InitializeComponent();
        }

        private void Auto_Forwarder_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            textBoxPartnerAddress.Text = Properties.Settings.Default.PartnerIP;
            textBoxPortNumber.Text = Properties.Settings.Default.PartnerPort;
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

            ////////////////////////////////////////////////////////////////////////////
            // Here check if OLDI partner IP address and Port number have been defined
            // If so then check that only applicable OLDI data is processed and rest ignored.
            // If no data is provided then process all data
            if ((textBoxPartnerAddress.Text.Length > 0) && (textBoxPortNumber.Text.Length > 0))
            {
                Process = false;
                OLDI_Check_Requested = true;

                IPAddress Partner_Address = IPAddress.Parse(textBoxPartnerAddress.Text);
                // Here we can check that address is from the expected source
                if ((ipHeader.ProtocolType == Protocol.TCP) && (Partner_Address.ToString() == ipHeader.SourceAddress.ToString()))
                {
                    Process = true;
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

                        if ((OLDI_Check_Requested == true) && (tcpHeader.SourcePort == textBoxPortNumber.Text))
                        {
                            TreeNode tcpNode = MakeTCPTreeNode(tcpHeader, OLDI_Check_Requested);
                            rootNode.Nodes.Add(tcpNode);
                        }
                        else if (OLDI_Check_Requested == false)
                        {
                            TreeNode tcpNode = MakeTCPTreeNode(tcpHeader, OLDI_Check_Requested);

                            rootNode.Nodes.Add(tcpNode);

                            //If the port is equal to 53 then the underlying protocol is DNS
                            //Note: DNS can use either TCP or UDP thats why the check is done twice
                            if (tcpHeader.DestinationPort == "53" || tcpHeader.SourcePort == "53")
                            {
                                TreeNode dnsNode = MakeDNSTreeNode(tcpHeader.Data, (int)tcpHeader.MessageLength);
                                rootNode.Nodes.Add(dnsNode);
                            }
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

                AddTreeNode addTreeNode = new AddTreeNode(OnAddTreeNode);
                string Date_Time = DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToLongTimeString();
                rootNode.Text = Date_Time + ": " + ipHeader.SourceAddress.ToString() + " to " +
                    ipHeader.DestinationAddress.ToString();
                //Thread safe adding of the nodes
                treeView.Invoke(addTreeNode, new object[] { rootNode });
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
        private TreeNode MakeTCPTreeNode(TCPHeader tcpHeader, bool OLDI_Data)
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
                /////////////////////////////////////////////////////////////////////////////////////////////////
                // This code handles OLDI data display
                //
                FMTP_Parser.FMPT_Header_and_Data Parsed_Msg = FMTP_Parser.FMTP_Msg_Parser(tcpHeader.Data);

                if (Parsed_Msg.Valid_FMTP_Data)
                {
                    tcpNode.Text = "OLDI";
                    tcpNode.Nodes.Add("Msg Version: " + Parsed_Msg.version);
                    tcpNode.Nodes.Add("Msg Length: " + Parsed_Msg.msg_length + " bytes");
                    tcpNode.Nodes.Add("Msg Type: " + Parsed_Msg.msg_type);
                    tcpNode.Nodes.Add("Msg Content: " + Parsed_Msg.msg_content);
                }
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
            Properties.Settings.Default.PartnerIP = textBoxPartnerAddress.Text;
            Properties.Settings.Default.PartnerPort = textBoxPortNumber.Text;
            Properties.Settings.Default.Save();
            this.Visible = false;
        }
    }
}
