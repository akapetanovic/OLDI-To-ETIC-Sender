using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace OLDI_To_ETIC_Sender
{
    public class Common_IP_Utils
    {
        public enum IP_Version {Unknown, IPV4, IPV6};

        public enum Protocol
        {
            TCP = 6,
            UDP = 17,
            Unknown = -1
        };

        public class IP_Header_Data
        {
            public Common_IP_Utils.Protocol ProtocolType;
            public IPAddress SourceAddress;
            public IPAddress DestinationAddress;
            public byte[] Data = new byte[4096];  //Data carried by the datagram
            public ushort MessageLength;
        }

        public static IP_Version Determine_Version(byte[] byBuffer, int nReceived)
        {
             byte byVersionAndHeaderLength;   //Eight bits for version and header length

            //Create MemoryStream out of the received bytes
            MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            //Next we create a BinaryReader out of the MemoryStream
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            //The first eight bits of the IP header contain the version and
            //header length so we read them
            byVersionAndHeaderLength = binaryReader.ReadByte();

            int Code = (byVersionAndHeaderLength >> 4);
            
            //The four bits of the IP header contain the IP version
            if (Code == 4)
            {
                return IP_Version.IPV4;
            }
            else if (Code == 6)
            {
                return IP_Version.IPV6;
            }
            else
            {
                return IP_Version.Unknown;
            }
        }
    }
}
