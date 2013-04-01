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
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelReceivingUnit = new System.Windows.Forms.Label();
            this.labelSendingUnit = new System.Windows.Forms.Label();
            this.textBoxSourcePort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.radioButtonServer = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
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
            this.comboBoxNetworkInterface.Location = new System.Drawing.Point(12, 25);
            this.comboBoxNetworkInterface.Name = "comboBoxNetworkInterface";
            this.comboBoxNetworkInterface.Size = new System.Drawing.Size(188, 21);
            this.comboBoxNetworkInterface.TabIndex = 27;
            this.comboBoxNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.comboBoxNetworkInterface_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Local/Sniffer  Interface";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Source Port";
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
            this.treeView.Location = new System.Drawing.Point(12, 106);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(538, 527);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(250, 639);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 43;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Receiving (Server) Unit:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Sending (Client) Unit :";
            // 
            // labelReceivingUnit
            // 
            this.labelReceivingUnit.AutoSize = true;
            this.labelReceivingUnit.Location = new System.Drawing.Point(138, 78);
            this.labelReceivingUnit.Name = "labelReceivingUnit";
            this.labelReceivingUnit.Size = new System.Drawing.Size(14, 13);
            this.labelReceivingUnit.TabIndex = 45;
            this.labelReceivingUnit.Text = "X";
            // 
            // labelSendingUnit
            // 
            this.labelSendingUnit.AutoSize = true;
            this.labelSendingUnit.Location = new System.Drawing.Point(138, 55);
            this.labelSendingUnit.Name = "labelSendingUnit";
            this.labelSendingUnit.Size = new System.Drawing.Size(14, 13);
            this.labelSendingUnit.TabIndex = 44;
            this.labelSendingUnit.Text = "X";
            // 
            // textBoxSourcePort
            // 
            this.textBoxSourcePort.Location = new System.Drawing.Point(212, 26);
            this.textBoxSourcePort.Name = "textBoxSourcePort";
            this.textBoxSourcePort.Size = new System.Drawing.Size(60, 20);
            this.textBoxSourcePort.TabIndex = 48;
            this.textBoxSourcePort.TextChanged += new System.EventHandler(this.textBoxSourcePort_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonServer);
            this.groupBox1.Controls.Add(this.radioButtonClient);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(290, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 91);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Forward to ETIC (batch mode)";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "None";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Location = new System.Drawing.Point(6, 42);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(51, 17);
            this.radioButtonClient.TabIndex = 1;
            this.radioButtonClient.TabStop = true;
            this.radioButtonClient.Text = "Cilent";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            // 
            // radioButtonServer
            // 
            this.radioButtonServer.AutoSize = true;
            this.radioButtonServer.Location = new System.Drawing.Point(6, 65);
            this.radioButtonServer.Name = "radioButtonServer";
            this.radioButtonServer.Size = new System.Drawing.Size(56, 17);
            this.radioButtonServer.TabIndex = 2;
            this.radioButtonServer.TabStop = true;
            this.radioButtonServer.Text = "Server";
            this.radioButtonServer.UseVisualStyleBackColor = true;
            // 
            // Auto_Forwarder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 674);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxSourcePort);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelReceivingUnit);
            this.Controls.Add(this.labelSendingUnit);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNetworkInterface);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Auto_Forwarder";
            this.Text = "Auto Forwarder";
            this.Load += new System.EventHandler(this.Auto_Forwarder_Load);
            this.VisibleChanged += new System.EventHandler(this.Auto_Forwarder_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox comboBoxNetworkInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelReceivingUnit;
        private System.Windows.Forms.Label labelSendingUnit;
        private System.Windows.Forms.TextBox textBoxSourcePort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonServer;
        private System.Windows.Forms.RadioButton radioButtonClient;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}