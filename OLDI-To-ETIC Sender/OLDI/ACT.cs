using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLDI_To_ETIC_Sender
{
    class ACT
    {
        // These are fields required to be filled by the
        // users.
        private string Aircraft_Identifincation;
        private string SSR_Mode_And_Code;
        private string ADEP;
        private string COP;
        private string Time_At_COP;
        private string Level_AT_COP;
        private string ADES;
        private string Aircraft_Number_and_Type;
        private string Type_Of_Flight;
        private string RWSM_Equiped;

        // To be implemented (Optional Fields)
        // Route
        // Other Flight plan

        //////////////////////////////////////////////////////////////////
        // Internal data
        //
        private bool IsPopulated = false;

        // This routine is to be called in order to populate all data
        // fileds. Once populated SendData is to be called.
        public void Populate(string Aircraft_Identifincation_IN,
                              string SSR_Mode_And_Code_IN,
                              string ADEP_IN,
                              string COP_IN,
                              string Time_At_COP_IN,
                              string Level_AT_COP_IN,
                              string ADES_IN,
                              string Aircraft_Number_and_Type_IN,
                              string Type_Of_Flight_IN,
                              string RWSM_Equiped_In)
        {

            Aircraft_Identifincation = Aircraft_Identifincation_IN;
            SSR_Mode_And_Code = SSR_Mode_And_Code_IN;
            ADEP = ADEP_IN;
            COP = COP_IN;
            Time_At_COP = Time_At_COP_IN;
            Level_AT_COP = Level_AT_COP_IN;


            ADES = ADES_IN;
            Aircraft_Number_and_Type = Aircraft_Number_and_Type_IN;
            Type_Of_Flight = Type_Of_Flight_IN;
            RWSM_Equiped = RWSM_Equiped_In;

            IsPopulated = true;

        }

        // This method accepts ACT message as a string (as recived from outside source)
        // It then parses  string 
        public void Forward_To_ETIC(string ACT_MESSAGE)
        {
            string ACT_TO_SEND = "";
            // Now build the common part and add to the front of the user data
            string Common_Part = "send " + "\"" + GlobalDataAndSettings.Sender + "-" + GlobalDataAndSettings.Receiver + "\"" + " operational ";
            ACT_TO_SEND = Common_Part + "\"" + ACT_MESSAGE + "\"";

            string ETIC_DIR = GlobalDataAndSettings.Etic_Dir + "\\test";
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

        // This routine is to be called once all data
        // items are prefilled using Populate method.
        // This routine will take care of any internals required
        // to send data.
        public void SendData()
        {
            // First make sure that data is populated
            if (IsPopulated == false)
            {

            }
            else
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Check if etic.out already exists. If so rename it to EticLogDATETIME.txt
                string FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, GlobalDataAndSettings.Etic_Out_File);
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
                // Fill out the file with the desired message
                string ACT_TO_SEND = BuildACTMessage();

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Now open up the temporary file named act.in
                // Combine the new file name with the path
                FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, GlobalDataAndSettings.Etic_Temp_File);

                // We assume the file does not exist
                System.IO.File.WriteAllText(FileName, ACT_TO_SEND);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Rename the file to give it a new name etic.in
                // Check if etic.out already exists. If so rename it to EticLogDATETIME.txt
                FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, GlobalDataAndSettings.Etic_Temp_File);
                if (System.IO.File.Exists(FileName))
                {
                    string NewName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, GlobalDataAndSettings.Etic_In_File);

                    // This is only for development purposes, will never happen in operational when ETIC si running
                    // This will also serve to makse sure that no etic.in was unprocessed between two subsequent sent 
                    // operations
                    if (System.IO.File.Exists(NewName))
                    {
                        string DateTimeNow = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string NewFileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, "etic_in" + "_" + DateTimeNow);
                        System.IO.File.Move(NewName, NewFileName);
                    }

                    System.IO.File.Move(FileName, NewName);
                }

                // Restet populate box
                IsPopulated = false;
            }

        }

        private string BuildACTMessage()
        {
            // First build the user data
            string ACT_Message_OUT =
             "\"-TITLE ACT"
             +
             " -REFDATA -SENDER -FAC " + GlobalDataAndSettings.Sender
             +
             " -RECVR -FAC " + GlobalDataAndSettings.Receiver
             +
             " -SEQNUM " + GlobalDataAndSettings.GetSequenceNumber()
             +
             " -ARCID " + Aircraft_Identifincation
             +
             " -SSRCODE " + SSR_Mode_And_Code
             +
             " -ADEP " + ADEP
             +
             " -COORDATA -PTID " + COP + " -TO " + Time_At_COP + " -TFL F" + Level_AT_COP
             +
             " -ADES " + ADES
             +
             " -ARCTYP " + Aircraft_Number_and_Type
             +
             " -FLTTYP " + Type_Of_Flight
             +
             " -BEGIN EQCST -EQPT " + RWSM_Equiped + " -END EQCST\"";


            // Now build the common part and add to the front of the user data
            string Common_Part = "send " + "\"" + GlobalDataAndSettings.Sender + "-" + GlobalDataAndSettings.Receiver + "\"" + " operational ";
            ACT_Message_OUT = Common_Part + ACT_Message_OUT;

            return ACT_Message_OUT;
        }

    }
}
