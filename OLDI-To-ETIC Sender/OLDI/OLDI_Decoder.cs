using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLDI_To_ETIC_Sender
{
    public class OLDI_Decoder
    {
        // Takes in OLDI Msg data in ASCII then:
        //   1. determines type of the message 
        //   2. Builds ETIC batch format
        //   3. Places ETIC batch msg in the directory
        public static void Decode_And_Forward(string OLDI_Msg)
        {
            switch (Message_Type(OLDI_Msg))
            {
                case "ACT":
                    ACT ACTtoSend = new ACT();
                    ACTtoSend.Forward_To_ETIC(OLDI_Msg);
                    break;

                case "ABI":

                    break;

                default:

                    break;
            }
        }

        private static string Message_Type(string Msg)
        {
            string Type = "UNKNOWN";

            char[] delimiterChars = { '-', ' ' };
            string[] words = Msg.Split(delimiterChars);

            bool TITLE_FOUND = false;
            foreach (string S in words)
            {
                if (S == "TITLE")
                    TITLE_FOUND = true;

                if (TITLE_FOUND && S != "TITLE")
                {
                    if (S.Length > 1)
                    {
                        Type = S;
                        break;
                    }
                }
            }

            return Type;
        }
    }
}
