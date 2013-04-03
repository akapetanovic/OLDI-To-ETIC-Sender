using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLDI_To_ETIC_Sender
{
    public class OLDI_Decoder
    {
        // Decodes OLDI Message TITLE
        private static string Message_TITLE(string Msg)
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
