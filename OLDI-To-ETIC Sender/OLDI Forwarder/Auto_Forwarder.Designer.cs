namespace OLDI_To_ETIC_Sender
{
    partial class Auto_Forwarder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.comboBoxNetworkInterface = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partnersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxPartnerIP = new System.Windows.Forms.ComboBox();
            this.comboBoxP_Port = new System.Windows.Forms.ComboBox();
            this.comboBoxP_ID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLocal_ID = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 639);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(70, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxNetworkInterface
            // 
            this.comboBoxNetworkInterface.FormattingEnabled = true;
            this.comboBoxNetworkInterface.Location = new System.Drawing.Point(12, 49);
            this.comboBoxNetworkInterface.Name = "comboBoxNetworkInterface";
            this.comboBoxNetworkInterface.Size = new System.Drawing.Size(188, 21);
            this.comboBoxNetworkInterface.TabIndex = 27;
            this.comboBoxNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.comboBoxNetworkInterface_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Local/Sniffer  Interface";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Src Partner IP";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Src Partner Port";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(475, 639);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(12, 76);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(538, 557);
            this.treeView.TabIndex = 33;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Expand";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(169, 639);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "Collapse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(250, 643);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 17);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "Auto Frwd to ETIC";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partnersToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.toolsToolStripMenuItem.Text = "Settings";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // partnersToolStripMenuItem
            // 
            this.partnersToolStripMenuItem.Name = "partnersToolStripMenuItem";
            this.partnersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.partnersToolStripMenuItem.Text = "OLDI Partners";
            this.partnersToolStripMenuItem.Click += new System.EventHandler(this.partnersToolStripMenuItem_Click);
            // 
            // comboBoxPartnerIP
            // 
            this.comboBoxPartnerIP.FormattingEnabled = true;
            this.comboBoxPartnerIP.Location = new System.Drawing.Point(206, 49);
            this.comboBoxPartnerIP.Name = "comboBoxPartnerIP";
            this.comboBoxPartnerIP.Size = new System.Drawing.Size(188, 21);
            this.comboBoxPartnerIP.TabIndex = 38;
            this.comboBoxPartnerIP.SelectedIndexChanged += new System.EventHandler(this.comboBoxPartnerIP_SelectedIndexChanged);
            this.comboBoxPartnerIP.Click += new System.EventHandler(this.comboBoxPartnerIP_Click);
            // 
            // comboBoxP_Port
            // 
            this.comboBoxP_Port.FormattingEnabled = true;
            this.comboBoxP_Port.Location = new System.Drawing.Point(401, 49);
            this.comboBoxP_Port.Name = "comboBoxP_Port";
            this.comboBoxP_Port.Size = new System.Drawing.Size(77, 21);
            this.comboBoxP_Port.TabIndex = 39;
            this.comboBoxP_Port.SelectedIndexChanged += new System.EventHandler(this.comboBoxP_Port_SelectedIndexChanged);
            // 
            // comboBoxP_ID
            // 
            this.comboBoxP_ID.FormattingEnabled = true;
            this.comboBoxP_ID.Location = new System.Drawing.Point(484, 49);
            this.comboBoxP_ID.Name = "comboBoxP_ID";
            this.comboBoxP_ID.Size = new System.Drawing.Size(66, 21);
            this.comboBoxP_ID.TabIndex = 40;
            this.comboBoxP_ID.SelectedIndexChanged += new System.EventHandler(this.comboBoxP_ID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Src Partner ID";
            // 
            // labelLocal_ID
            // 
            this.labelLocal_ID.AutoSize = true;
            this.labelLocal_ID.Location = new System.Drawing.Point(443, 5);
            this.labelLocal_ID.Name = "labelLocal_ID";
            this.labelLocal_ID.Size = new System.Drawing.Size(73, 13);
            this.labelLocal_ID.TabIndex = 42;
            this.labelLocal_ID.Text = "Local ID: N/A";
            // 
            // Auto_Forwarder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 674);
            this.Controls.Add(this.labelLocal_ID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxP_ID);
            this.Controls.Add(this.comboBoxP_Port);
            this.Controls.Add(this.comboBoxPartnerIP);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNetworkInterface);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Auto_Forwarder";
            this.Text = "Auto Forwarder";
            this.Load += new System.EventHandler(this.Auto_Forwarder_Load);
            this.VisibleChanged += new System.EventHandler(this.Auto_Forwarder_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox comboBoxNetworkInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partnersToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxPartnerIP;
        private System.Windows.Forms.ComboBox comboBoxP_Port;
        private System.Windows.Forms.ComboBox comboBoxP_ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLocal_ID;
    }
}