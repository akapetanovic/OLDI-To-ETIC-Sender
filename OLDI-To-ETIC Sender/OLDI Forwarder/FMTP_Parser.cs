using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLDI_To_ETIC_Sender
{
    class FMTP_Parser
    {
        public class FMPT_Header_and_Data
        {
            public enum Message_Type { Operational, Operator, Identification, System };

            public string version = "";
            public string reserved = "";
            public string msg_length = "";
            public Message_Type msg_type = Message_Type.System;
            public  string msg_content = "";
            public bool Valid_FMTP_Data = false;
        }

        public static FMPT_Header_and_Data FMTP_Msg_Parser (byte[] FMTP_Msh)
        {
            FMPT_Header_and_Data Data_Out = new FMPT_Header_and_Data();

           // Determine FMTP version
            Data_Out.version = FMTP_Msh[0].ToString();

            // Determine message size
            Bit_Ops BO = new Bit_Ops();
            BO.DWord[Bit_Ops.Bits0_7_Of_DWord] = FMTP_Msh[3];
            BO.DWord[Bit_Ops.Bits8_15_Of_DWord] = FMTP_Msh[2];
            int Result = BO.DWord[Bit_Ops.Bits0_15_Of_DWord];
            Data_Out.msg_length = Result.ToString();
            if (Result == 0)
            Data_Out.Valid_FMTP_Data = false;
            
            // Determine message type
            switch ((int)FMTP_Msh[4])
            {
                case 1:
                    Data_Out.msg_type = FMPT_Header_and_Data.Message_Type.Operational;
                    break;
                case 2:
                    Data_Out.msg_type = FMPT_Header_and_Data.Message_Type.Operator;
                    break;
                case 3:
                    Data_Out.msg_type = FMPT_Header_and_Data.Message_Type.Identification;
                    break;
                case 4:
                    Data_Out.msg_type = FMPT_Header_and_Data.Message_Type.System;
                    break;
                case 5:
                    Data_Out.Valid_FMTP_Data = false;
                    break;
            }

            return Data_Out;
        }
    }
}
