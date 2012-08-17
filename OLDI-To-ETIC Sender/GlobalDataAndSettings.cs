using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLDI_To_ETIC_Sender
{
    class GlobalDataAndSettings
    {
        // Specify a "currently active folder"
        static public string Etic_Dir = @"N/A";
        static public string Data_Dir = @"N/A";

        // ETIC etic.out file
        //static public string Etic_Out_File = "etic.out";
        static public string Etic_Out_File = "etic.out";

        // This is file that Etic will read in process it to either:

        // This one exists only during the file write process, once comleted it will be renamed
        // to etic.in to be processed
        static public string Etic_Temp_File = "etic_temp";

        //Send a message with a predefined CP
        //Wait an amount of time
        //Log an entry in the event archive
        //Exit ETIC
        //
        // Please see ETIC manual for batch processing
        static public string Etic_In_File = "etic.in";

        //
        // Define communiction partner pairs as defined in Etic
        static public string Sender = "N/A";
        static public string Receiver = "N/A";

        static private int SequenceNumber = 1;

        // This method takes care of the message sequence number.
        // It goes from 1 ... 000 (where 000 means 1000), then wraps back.
        // Make sure it is called only once per each message to be sent.
        static public string GetSequenceNumber()
        {
            string Result = Convert.ToString(SequenceNumber);

            if (SequenceNumber < 10)
            {
                Result = "00" + Result;
            }
            else if (SequenceNumber < 100)
            {
                Result = "0" + Result;
            }
            
            // Here implement the sequence number so that it wraps any time it is called.
            if (SequenceNumber == 999)
            {
                SequenceNumber = 0;
            }
            else
            {
                SequenceNumber = SequenceNumber + 1;
            }

            return Result ;
        }


    }
}
