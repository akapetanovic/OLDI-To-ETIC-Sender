using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLDI_To_ETIC_Sender
{
    public class ETIC_Forwarder
    {
        // This method accepts ACT message as a string (as recived from outside source)
        // It then parses  string 
        public static void Forward_To_ETIC_Operational_Msg(string ACT_MESSAGE)
        {
            string ACT_TO_SEND = "";
            // Now build the common part and add to the front of the user data
            string Common_Part = "send " + "\"" + GlobalDataAndSettings.Sender + "-" + GlobalDataAndSettings.Receiver + "\"" + " operational ";
            ACT_TO_SEND = Common_Part + "\"" + ACT_MESSAGE + "\"";

            // Define it here for debugging purposes...
            // When testing we need to avoid reccursive forwarding....
            string ETIC_DIR = GlobalDataAndSettings.Etic_Dir;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            // Check if etic.out already exists. If so rename it to EticLogDATETIME.txt
            string FileName = System.IO.Path.Combine(ETIC_DIR, GlobalDataAndSettings.Etic_Out_File);
            if (System.IO.File.Exists(FileName))
            {
                string DateTimeNow = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                string NewFileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, "etic_Log_" + DateTimeNow);
                try
                {
                    System.IO.File.Move(FileName, NewFileName);
                }
                catch
                {
                    try
                    {
                        System.IO.File.Move(FileName, NewFileName + "_1");
                    }
                    catch
                    {
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Now open up the temporary file named act.in
            // Combine the new file name with the path
            FileName = System.IO.Path.Combine(ETIC_DIR, GlobalDataAndSettings.Etic_Temp_File);

            // We assume the file does not exist
            System.IO.File.WriteAllText(FileName, ACT_TO_SEND);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Rename the file to give it a new name etic.in
            // Check if etic.out already exists. If so rename it to EticLogDATETIME.txt
            FileName = System.IO.Path.Combine(ETIC_DIR, GlobalDataAndSettings.Etic_Temp_File);
            if (System.IO.File.Exists(FileName))
            {
                string NewName = System.IO.Path.Combine(ETIC_DIR, GlobalDataAndSettings.Etic_In_File);

                // This is only for development purposes, will never happen in operational when ETIC si running
                // This will also serve to makse sure that no etic.in was unprocessed between two subsequent sent 
                // operations
                if (System.IO.File.Exists(NewName))
                {
                    string DateTimeNow = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    string NewFileName = System.IO.Path.Combine(ETIC_DIR, "etic_in" + "_" + DateTimeNow);
                    System.IO.File.Move(NewName, NewFileName);
                }

                System.IO.File.Move(FileName, NewName);
            }
        }
    }
}
