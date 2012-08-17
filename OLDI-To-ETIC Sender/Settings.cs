using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OLDI_To_ETIC_Sender
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.labelSelectedFolder.Text = GlobalDataAndSettings.Etic_Dir;
            this.textBoxCOM1_Name.Text = GlobalDataAndSettings.Sender;
            this.textBoxCOM2_Name.Text = GlobalDataAndSettings.Receiver;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Validate the data and save them to the global settings
            if ((this.textBoxCOM1_Name.TextLength > 0) || (this.textBoxCOM2_Name.TextLength > 0))
            {
                GlobalDataAndSettings.Sender = this.textBoxCOM1_Name.Text;
                GlobalDataAndSettings.Receiver = this.textBoxCOM2_Name.Text;
                GlobalDataAndSettings.Etic_Dir = this.labelSelectedFolder.Text;
                GlobalDataAndSettings.Data_Dir = this.labelDataDirectory.Text;
                this.Close();
               
            }
            else
            {
                MessageBox.Show("Please fill out all parameters before saving");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Just close the form and do nothing.
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Here use the folder broswer dialog
            folderBrowserDialog1.ShowDialog();

            // Set the selected path to the user selected path
            this.labelSelectedFolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonBrowseDataDir_Click(object sender, EventArgs e)
        {

            // Here use the folder broswer dialog
            folderBrowserDialog1.ShowDialog();

            // Set the selected path to the user selected path
            this.labelDataDirectory.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
