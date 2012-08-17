using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace OLDI_To_ETIC_Sender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // On this click validate the data
        private void btnSendACT_Click(object sender, EventArgs e)
        {
            ACT ACTtoSend = new ACT();

            ACTtoSend.Populate(
                //Aircraft_Identifincation_IN,
            this.textBoxACID.Text,
                // SSR_Mode_And_Code_IN,
            this.textBoxSSR_ModeandCode.Text,
                // ADEP_IN,
            this.comboBoxADEP.Text,
                // COP_IN,
            this.comboBoxCOP.Text,
                // Time_At_COP_IN
            this.textBoxTimeAtCOP.Text,
                // FL_AT_COP
            this.comboBoxFLAtCOP.Text,
                // ADES_IN,
            this.comboBoxADES.Text,
                // Aircraft_Number_and_Type_IN,
            this.comboBoxACNumandtype.Text,
                // Type_Of_Flight_IN,
            this.comboBoxTypeofFlight.Items[this.comboBoxTypeofFlight.SelectedIndex].ToString(),
                // Equipment_Capability_And_Status_IN
            this.comboBoxRVSMEQuiped.Items[this.comboBoxRVSMEQuiped.SelectedIndex].ToString());

            // Now send the data
            ACTtoSend.SendData();

            if (this.checkBoxResetFields.Checked == true)
            {
                this.textBoxACID.Text = "";

                // SSR_Mode_And_Code_IN
                this.textBoxSSR_ModeandCode.Text = "";

                // ADEP_IN
                if (this.comboBoxADEP.Items.Count > 1)
                {
                    this.comboBoxADEP.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxADEP.Text = "";
                }

                // COP_IN
                if (this.comboBoxCOP.Items.Count > 1)
                {
                    this.comboBoxCOP.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxCOP.Text = "";
                }

                // Time_At_COP_IN
                this.textBoxTimeAtCOP.Text = "";

                // FL_AT_COP
                this.comboBoxFLAtCOP.SelectedIndex = 11;

                // ADES_IN,
                if (this.comboBoxADES.Items.Count > 1)
                {
                    this.comboBoxADES.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxADES.Text = "";
                }

                // Aircraft_Number_and_Type_IN
                if (this.comboBoxACNumandtype.Items.Count > 1)
                {
                    this.comboBoxACNumandtype.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxACNumandtype.Text = "";
                }

                // Type_Of_Flight_IN
                this.comboBoxTypeofFlight.SelectedIndex = 0;

                // Equipment_Capability_And_Status_IN
                this.comboBoxRVSMEQuiped.SelectedIndex = 0;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.comboBoxRVSMEQuiped.SelectedIndex = 0;
            this.comboBoxTypeofFlight.SelectedIndex = 0;
            this.comboBoxFLAtCOP.SelectedIndex = 20;
            UpdateSettingParametersDisplay();
        }

        private void UpdateSettingParametersDisplay()
        {
            this.Label_ETIC_Directory.Text = GlobalDataAndSettings.Etic_Dir;
            this.labelReceivingUnit.Text = GlobalDataAndSettings.Receiver;
            this.labelSendingUnit.Text = GlobalDataAndSettings.Sender;
            this.lblDataDirectory.Text = GlobalDataAndSettings.Data_Dir;

            HandleSendButtonEnabledStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.textBoxACID.Text = "";
            // SSR_Mode_And_Code_IN,
            this.textBoxSSR_ModeandCode.Text = "";
            // ADEP_IN,
            this.comboBoxADEP.SelectedIndex = 0;
            // COP_IN,
            this.comboBoxCOP.SelectedIndex = 0;
            // Time_At_COP_IN
            this.textBoxTimeAtCOP.Text = "";
            // FL_AT_COP
            this.comboBoxFLAtCOP.SelectedIndex = 11;
            // ADES_IN,
            this.comboBoxADES.SelectedIndex = 0;
            // Aircraft_Number_and_Type_IN,
            this.comboBoxACNumandtype.SelectedIndex = 0;

            this.comboBoxRVSMEQuiped.SelectedIndex = 0;
            this.comboBoxTypeofFlight.SelectedIndex = 0;

        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings MySettingForm = new Settings();
            MySettingForm.Visible = false;
            MySettingForm.ShowDialog();
            MySettingForm.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);

            // Now update the settings parameters
            UpdateSettingParametersDisplay();
        }

        //
        // Handles saving of configuration files
        //
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "OLDI to ETIC Files|*.ote";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    StreamWriter wText = new StreamWriter(myStream);

                    wText.WriteLine(GlobalDataAndSettings.Etic_Dir);
                    wText.WriteLine(GlobalDataAndSettings.Data_Dir);
                    wText.WriteLine(GlobalDataAndSettings.Sender);
                    wText.WriteLine(GlobalDataAndSettings.Receiver);

                    wText.Close();
                    myStream.Close();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "OLDI to ETIC Files|*.ote";
            openFileDialog1.InitialDirectory = "Application.StartupPath";
            openFileDialog1.Title = "Open File to Read";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {

                StreamReader MyStreamReader = new StreamReader(openFileDialog1.FileName);	//Open the input file
                GlobalDataAndSettings.Etic_Dir = MyStreamReader.ReadLine();
                GlobalDataAndSettings.Data_Dir = MyStreamReader.ReadLine();
                GlobalDataAndSettings.Sender = MyStreamReader.ReadLine();
                GlobalDataAndSettings.Receiver = MyStreamReader.ReadLine();

                MyStreamReader.Close();

                // Now update the settings parameters
                UpdateSettingParametersDisplay();
            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help HelpForm = new Help();
            HelpForm.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About AboutForm = new About();
            AboutForm.Show();
        }

        // This method will check if in the etic directory one or more of the following files 
        // exist.
        //
        // 1. ADES.txt
        // 2. ADEP.txt
        // 3. COP.txt
        // 4. ACTYPE.txt
        //
        // If any of the listed files is in the ETIC directory specifed in the settings
        // then correspnding data items will be prefilled in the list box
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ImportData()
        {
            string DATA;

            // Check if ADES.txt exists
            string FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, "ADES.txt");
            if (System.IO.File.Exists(FileName))
            {
                this.comboBoxADES.Items.Clear();
                StreamReader MyStreamReader = System.IO.File.OpenText(FileName);
                while (MyStreamReader.Peek() >= 0)
                {
                    DATA = MyStreamReader.ReadLine();
                    this.comboBoxADES.Items.Add(DATA);
                }
                this.comboBoxADES.SelectedIndex = 0;
            }

            // Check if ADEP.txt exists
            FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, "ADEP.txt");
            if (System.IO.File.Exists(FileName))
            {
                this.comboBoxADEP.Items.Clear();
                StreamReader MyStreamReader = System.IO.File.OpenText(FileName);
                while (MyStreamReader.Peek() >= 0)
                {
                    DATA = MyStreamReader.ReadLine();
                    this.comboBoxADEP.Items.Add(DATA);
                }
                this.comboBoxADEP.SelectedIndex = 0;
            }

            // Check if COP.txt exists
            FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, "COP.txt");
            if (System.IO.File.Exists(FileName))
            {
                this.comboBoxCOP.Items.Clear();
                StreamReader MyStreamReader = System.IO.File.OpenText(FileName);
                while (MyStreamReader.Peek() >= 0)
                {
                    DATA = MyStreamReader.ReadLine();
                    this.comboBoxCOP.Items.Add(DATA);
                }
                this.comboBoxCOP.SelectedIndex = 0;
            }

            // Check if ACTYPE.txt exists
            FileName = System.IO.Path.Combine(GlobalDataAndSettings.Etic_Dir, "ACTYPE.txt");
            if (System.IO.File.Exists(FileName))
            {
                this.comboBoxACNumandtype.Items.Clear();
                StreamReader MyStreamReader = System.IO.File.OpenText(FileName);
                while (MyStreamReader.Peek() >= 0)
                {
                    DATA = MyStreamReader.ReadLine();
                    this.comboBoxACNumandtype.Items.Add(DATA);
                }
                this.comboBoxACNumandtype.SelectedIndex = 0;
            }
        }

        private void textBoxACID_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        void HandleSendButtonEnabledStatus()
        {
            if ((this.textBoxACID.TextLength > 0) &&
                // SSR_Mode_And_Code_IN,
            (this.textBoxSSR_ModeandCode.TextLength > 0) &&
                // ADEP_IN,
            (this.comboBoxADEP.Text != "") &&
                // COP_IN,
            (this.comboBoxCOP.Text != "") &&
                // Time_At_COP_IN
            (this.textBoxTimeAtCOP.TextLength == 4) &&
                // FL_AT_COP
            (this.comboBoxFLAtCOP.Text != "") &&
                // ADES_IN,
            (this.comboBoxADES.Text != "") &&
                // Aircraft_Number_and_Type_IN,
            (this.comboBoxACNumandtype.Text != ""))
            {

                // OK we know that all the fields are filled out, now just makse sure
                // that proper configuration is loaded as well.
                if ((GlobalDataAndSettings.Data_Dir != "N/A") &&
                    (GlobalDataAndSettings.Sender != "N/A") &&
                    (GlobalDataAndSettings.Receiver != "N/A"))
                {
                    this.btnSendACT.Enabled = true;
                }
                else
                {
                    this.btnSendACT.Enabled = false;
                }

            }
            else
            {
                this.btnSendACT.Enabled = false;
            }
        }

        private void textBoxSSR_ModeandCode_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        private void comboBoxADEP_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        private void comboBoxCOP_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        private void textBoxTimeAtCOP_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        private void comboBoxFLAtCOP_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        private void comboBoxADES_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }

        private void comboBoxACNumandtype_TextChanged(object sender, EventArgs e)
        {
            HandleSendButtonEnabledStatus();
        }
    }
}
