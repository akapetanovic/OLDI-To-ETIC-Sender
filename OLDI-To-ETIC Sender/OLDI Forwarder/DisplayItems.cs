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
    public partial class DisplayItems : Form
    {
        public DisplayItems()
        {
            InitializeComponent();
        }

        private void DisplayItmes_Load(object sender, EventArgs e)
        {
            this.checkBoxMsg_Content.Checked = Properties.Settings.Default.Msg_Content;
            this.checkBoxMsg_Length.Checked = Properties.Settings.Default.Msg_Length;
            this.checkBoxMsg_Type.Checked = Properties.Settings.Default.Msg_Type;
            this.checkBoxMsg_Version.Checked = Properties.Settings.Default.Msg_Version;
            this.checkBox_Operational.Checked = Properties.Settings.Default.Show_Operational;
            this.checkBox_System.Checked = Properties.Settings.Default.Show_System;
            this.checkBoxOperator.Checked = Properties.Settings.Default.Show_Operator;
            this.checkBox_Identification.Checked = Properties.Settings.Default.Show_Identification;
        }

        private void checkBoxMsg_Version_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Msg_Version = this.checkBoxMsg_Version.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxMsg_Length_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Msg_Length = this.checkBoxMsg_Length.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxMsg_Type_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Msg_Type = this.checkBoxMsg_Type.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxMsg_Content_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Msg_Content = this.checkBoxMsg_Content.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_Operational_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Show_Operational = this.checkBox_Operational.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxOperator_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Show_Operator = this.checkBoxOperator.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_System_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Show_System = this.checkBox_System.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_Identification_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Show_Identification = this.checkBox_Identification.Checked;
            Properties.Settings.Default.Save();
        }



    }
}
