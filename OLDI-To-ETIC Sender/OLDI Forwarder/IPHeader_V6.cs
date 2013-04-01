using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace OLDI_To_ETIC_Sender
{
    public class IPHeader_V6
    {
        //IP Header fields
        private byte[] Version = new byte[1];                   // 4  bits for version
        private byte[] TrafficClass = new byte[1];              // 8 bits for Traffic Class
        private byte[] TotalLength = new byte[2];               // 16 bits for total length of the datagram (header + message)
        private byte[] Protocol = new byte[1];                  // 8 bits for identification
        private byte[] SourceIPAddress = new byte[16];          // 128 bit source IP Address
        private byte[] DestinationIPAddress = new byte[16];     // 128 bit destination IP Address
        //End IP Header fields
        private byte[] IPData = new byte[4096];  //Data carried by the datagram


        public IPHeader_V6(byte[] byBuffer, int nReceived)
        {

            try
            {
                // Copy version data
                Array.Copy(byBuffer,
                           0,
                           Version, 0,
                           1);

                // Copy Payload Lenght data
                Array.Copy(byBuffer,
                           4,
                           TotalLength, 0,
                           2);

                // Copy Protocol (Next Header) data
                Array.Copy(byBuffer,
                           6,
                           Protocol, 0,
                           1);

                // Copy source address
                Array.Copy(byBuffer,
                           8,
                           SourceIPAddress, 0,
                           16);

                // Copy source address
                Array.Copy(byBuffer,
                           24,
                           DestinationIPAddress, 0,
                           16);

                // Copy payload (datagram)
                Array.Copy(byBuffer,
                           40,
                           IPData, 0,
                           MessageLength);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ETIC To OLDI IPV6 Header", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public byte[] Data
        {
            get
            {
                return IPData;
            }
        }

        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(SourceIPAddress);
            }
        }

        public IPAddress DestinationAddress
        {
            get
            {
                return new IPAddress(DestinationIPAddress);
            }
        }

        public ushort MessageLength
        {
            get
            {
                return (ushort)(Total_Lenght - 40);
            }
        }

        public ushort Total_Lenght
        {
            get
            {
                //Create MemoryStream out of the received bytes
                MemoryStream memoryStream = new MemoryStream(TotalLength, 0, 2);
                //Next we create a BinaryReader out of the MemoryStream
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                return (ushort)binaryReader.ReadInt16();
               
            }
        }

        public Common_IP_Utils.Protocol ProtocolType
        {
            get
            {
                //Create MemoryStream out of the received bytes
                MemoryStream memoryStream = new MemoryStream(Protocol, 0, 1);
                //Next we create a BinaryReader out of the MemoryStream
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                int Protocol_Type = binaryReader.ReadByte();

                //The protocol field represents the protocol in the data portion
                //of the datagram
                if (Protocol_Type == 6)        //A value of six represents the TCP protocol
                {
                    return Common_IP_Utils.Protocol.TCP;
                }
                else if (Protocol_Type == 17)  //Seventeen for UDP
                {
                    return Common_IP_Utils.Protocol.UDP;
                }
                else
                {
                    return Common_IP_Utils.Protocol.Unknown;
                }
            }
        }
    }
}
