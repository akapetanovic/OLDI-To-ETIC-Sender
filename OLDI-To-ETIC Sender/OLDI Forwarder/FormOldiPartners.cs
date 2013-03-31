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
    public partial class OldiPartners : Form
    {
        public OldiPartners()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.P_ID1 = this.textBoxP_ID1.Text;
            Properties.Settings.Default.P_ID2 = this.textBoxP_ID2.Text;
            Properties.Settings.Default.P_ID3 = this.textBoxP_ID3.Text;
            Properties.Settings.Default.P_ADDR1 = this.textBoxP_IP1.Text;
            Properties.Settings.Default.P_ADDR2 = this.textBoxP_IP2.Text;
            Properties.Settings.Default.P_ADDR3 = this.textBoxP_IP3.Text;
            Properties.Settings.Default.P_PORT1 = this.textBoxP_Port1.Text;
            Properties.Settings.Default.P_PORT2 = this.textBoxP_Port2.Text;
            Properties.Settings.Default.P_PORT3 = this.textBoxP_Port3.Text;
        }

        private void OldiPartners_Load(object sender, EventArgs e)
        {
            this.textBoxP_ID1.Text = Properties.Settings.Default.P_ID1;
            this.textBoxP_ID2.Text = Properties.Settings.Default.P_ID2;
            this.textBoxP_ID3.Text = Properties.Settings.Default.P_ID3;
            this.textBoxP_IP1.Text = Properties.Settings.Default.P_ADDR1;
            this.textBoxP_IP2.Text = Properties.Settings.Default.P_ADDR2;
            this.textBoxP_IP3.Text = Properties.Settings.Default.P_ADDR3;
            this.textBoxP_Port1.Text = Properties.Settings.Default.P_PORT1;
            this.textBoxP_Port2.Text = Properties.Settings.Default.P_PORT2;
            this.textBoxP_Port3.Text = Properties.Settings.Default.P_PORT3;
        }
    }
}
