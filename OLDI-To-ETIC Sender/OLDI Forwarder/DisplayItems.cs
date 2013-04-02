using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OLDI_To_ETIC_Sender.OLDI_Forwarder
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
    }
}
