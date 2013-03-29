namespace OLDI_To_ETIC_Sender
{
    partial class MainForm
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
            this.tabABI = new System.Windows.Forms.TabControl();
            this.tabPageACT = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSendACT = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxACNumandtype = new System.Windows.Forms.ComboBox();
            this.comboBoxFLAtCOP = new System.Windows.Forms.ComboBox();
            this.comboBoxCOP = new System.Windows.Forms.ComboBox();
            this.comboBoxADES = new System.Windows.Forms.ComboBox();
            this.comboBoxADEP = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeofFlight = new System.Windows.Forms.ComboBox();
            this.comboBoxRVSMEQuiped = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSSR_ModeandCode = new System.Windows.Forms.TextBox();
            this.textBoxTimeAtCOP = new System.Windows.Forms.TextBox();
            this.textBoxACID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.Label_ETIC_Directory = new System.Windows.Forms.Label();
            this.labelSendingUnit = new System.Windows.Forms.Label();
            this.labelReceivingUnit = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDataDirectory = new System.Windows.Forms.Label();
            this.checkBoxResetFields = new System.Windows.Forms.CheckBox();
            this.forwarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabABI.SuspendLayout();
            this.tabPageACT.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabABI
            // 
            this.tabABI.Controls.Add(this.tabPageACT);
            this.tabABI.Controls.Add(this.tabPage2);
            this.tabABI.Location = new System.Drawing.Point(12, 88);
            this.tabABI.Name = "tabABI";
            this.tabABI.SelectedIndex = 0;
            this.tabABI.Size = new System.Drawing.Size(457, 471);
            this.tabABI.TabIndex = 0;
            // 
            // tabPageACT
            // 
            this.tabPageACT.BackColor = System.Drawing.Color.Silver;
            this.tabPageACT.Controls.Add(this.button1);
            this.tabPageACT.Controls.Add(this.btnSendACT);
            this.tabPageACT.Controls.Add(this.groupBox1);
            this.tabPageACT.Location = new System.Drawing.Point(4, 22);
            this.tabPageACT.Name = "tabPageACT";
            this.tabPageACT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageACT.Size = new System.Drawing.Size(449, 445);
            this.tabPageACT.TabIndex = 0;
            this.tabPageACT.Text = "ACT";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSendACT
            // 
            this.btnSendACT.Enabled = false;
            this.btnSendACT.Location = new System.Drawing.Point(7, 414);
            this.btnSendACT.Name = "btnSendACT";
            this.btnSendACT.Size = new System.Drawing.Size(193, 23);
            this.btnSendACT.TabIndex = 1;
            this.btnSendACT.Text = "Send";
            this.btnSendACT.UseVisualStyleBackColor = true;
            this.btnSendACT.Click += new System.EventHandler(this.btnSendACT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxACNumandtype);
            this.groupBox1.Controls.Add(this.comboBoxFLAtCOP);
            this.groupBox1.Controls.Add(this.comboBoxCOP);
            this.groupBox1.Controls.Add(this.comboBoxADES);
            this.groupBox1.Controls.Add(this.comboBoxADEP);
            this.groupBox1.Controls.Add(this.comboBoxTypeofFlight);
            this.groupBox1.Controls.Add(this.comboBoxRVSMEQuiped);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxSSR_ModeandCode);
            this.groupBox1.Controls.Add(this.textBoxTimeAtCOP);
            this.groupBox1.Controls.Add(this.textBoxACID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 389);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACT Data";
            // 
            // comboBoxACNumandtype
            // 
            this.comboBoxACNumandtype.FormattingEnabled = true;
            this.comboBoxACNumandtype.Location = new System.Drawing.Point(128, 285);
            this.comboBoxACNumandtype.Name = "comboBoxACNumandtype";
            this.comboBoxACNumandtype.Size = new System.Drawing.Size(287, 21);
            this.comboBoxACNumandtype.TabIndex = 8;
            this.comboBoxACNumandtype.TextChanged += new System.EventHandler(this.comboBoxACNumandtype_TextChanged);
            // 
            // comboBoxFLAtCOP
            // 
            this.comboBoxFLAtCOP.FormattingEnabled = true;
            this.comboBoxFLAtCOP.Items.AddRange(new object[] {
            "100",
            "110",
            "120",
            "130",
            "140",
            "150",
            "160",
            "170",
            "180",
            "190",
            "200",
            "210",
            "220",
            "230",
            "240",
            "250",
            "260",
            "270",
            "280",
            "290",
            "300",
            "310",
            "320",
            "330",
            "340",
            "350",
            "360",
            "370",
            "380",
            "390",
            "400",
            "410",
            "420"});
            this.comboBoxFLAtCOP.Location = new System.Drawing.Point(128, 213);
            this.comboBoxFLAtCOP.Name = "comboBoxFLAtCOP";
            this.comboBoxFLAtCOP.Size = new System.Drawing.Size(287, 21);
            this.comboBoxFLAtCOP.TabIndex = 6;
            this.comboBoxFLAtCOP.TextChanged += new System.EventHandler(this.comboBoxFLAtCOP_TextChanged);
            // 
            // comboBoxCOP
            // 
            this.comboBoxCOP.FormattingEnabled = true;
            this.comboBoxCOP.Location = new System.Drawing.Point(128, 138);
            this.comboBoxCOP.Name = "comboBoxCOP";
            this.comboBoxCOP.Size = new System.Drawing.Size(287, 21);
            this.comboBoxCOP.TabIndex = 4;
            this.comboBoxCOP.TextChanged += new System.EventHandler(this.comboBoxCOP_TextChanged);
            // 
            // comboBoxADES
            // 
            this.comboBoxADES.FormattingEnabled = true;
            this.comboBoxADES.Location = new System.Drawing.Point(128, 249);
            this.comboBoxADES.Name = "comboBoxADES";
            this.comboBoxADES.Size = new System.Drawing.Size(287, 21);
            this.comboBoxADES.TabIndex = 7;
            this.comboBoxADES.TextChanged += new System.EventHandler(this.comboBoxADES_TextChanged);
            // 
            // comboBoxADEP
            // 
            this.comboBoxADEP.FormattingEnabled = true;
            this.comboBoxADEP.Location = new System.Drawing.Point(128, 105);
            this.comboBoxADEP.Name = "comboBoxADEP";
            this.comboBoxADEP.Size = new System.Drawing.Size(287, 21);
            this.comboBoxADEP.TabIndex = 3;
            this.comboBoxADEP.TextChanged += new System.EventHandler(this.comboBoxADEP_TextChanged);
            // 
            // comboBoxTypeofFlight
            // 
            this.comboBoxTypeofFlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeofFlight.FormattingEnabled = true;
            this.comboBoxTypeofFlight.Items.AddRange(new object[] {
            "S",
            "N",
            "G",
            "M",
            "X"});
            this.comboBoxTypeofFlight.Location = new System.Drawing.Point(128, 313);
            this.comboBoxTypeofFlight.Name = "comboBoxTypeofFlight";
            this.comboBoxTypeofFlight.Size = new System.Drawing.Size(287, 21);
            this.comboBoxTypeofFlight.TabIndex = 9;
            // 
            // comboBoxRVSMEQuiped
            // 
            this.comboBoxRVSMEQuiped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRVSMEQuiped.FormattingEnabled = true;
            this.comboBoxRVSMEQuiped.Items.AddRange(new object[] {
            "W/EQ",
            "N/EQ",
            "U/EQ"});
            this.comboBoxRVSMEQuiped.Location = new System.Drawing.Point(128, 349);
            this.comboBoxRVSMEQuiped.Name = "comboBoxRVSMEQuiped";
            this.comboBoxRVSMEQuiped.Size = new System.Drawing.Size(287, 21);
            this.comboBoxRVSMEQuiped.TabIndex = 10;
            this.comboBoxRVSMEQuiped.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Time at COP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "FL at COP";
            // 
            // textBoxSSR_ModeandCode
            // 
            this.textBoxSSR_ModeandCode.Location = new System.Drawing.Point(128, 68);
            this.textBoxSSR_ModeandCode.Name = "textBoxSSR_ModeandCode";
            this.textBoxSSR_ModeandCode.Size = new System.Drawing.Size(287, 20);
            this.textBoxSSR_ModeandCode.TabIndex = 2;
            this.textBoxSSR_ModeandCode.TextChanged += new System.EventHandler(this.textBoxSSR_ModeandCode_TextChanged);
            // 
            // textBoxTimeAtCOP
            // 
            this.textBoxTimeAtCOP.Location = new System.Drawing.Point(128, 173);
            this.textBoxTimeAtCOP.Name = "textBoxTimeAtCOP";
            this.textBoxTimeAtCOP.Size = new System.Drawing.Size(287, 20);
            this.textBoxTimeAtCOP.TabIndex = 5;
            this.textBoxTimeAtCOP.TextChanged += new System.EventHandler(this.textBoxTimeAtCOP_TextChanged);
            // 
            // textBoxACID
            // 
            this.textBoxACID.Location = new System.Drawing.Point(128, 33);
            this.textBoxACID.Name = "textBoxACID";
            this.textBoxACID.Size = new System.Drawing.Size(287, 20);
            this.textBoxACID.TabIndex = 1;
            this.textBoxACID.TextChanged += new System.EventHandler(this.textBoxACID_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "RVSM EQ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Type of Flight";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Aircraft number and type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Destination Aerodrome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "COP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departure Aerodrome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SSR Mode and Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aircraft Identification";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(449, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ABI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(480, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.forwarderToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.modifyToolStripMenuItem.Text = "Modify-Create New";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.importDataToolStripMenuItem.Text = "Import Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(173, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "ETIC directory: ";
            // 
            // Label_ETIC_Directory
            // 
            this.Label_ETIC_Directory.AutoSize = true;
            this.Label_ETIC_Directory.Location = new System.Drawing.Point(248, 33);
            this.Label_ETIC_Directory.Name = "Label_ETIC_Directory";
            this.Label_ETIC_Directory.Size = new System.Drawing.Size(28, 13);
            this.Label_ETIC_Directory.TabIndex = 3;
            this.Label_ETIC_Directory.Text = "XXX";
            // 
            // labelSendingUnit
            // 
            this.labelSendingUnit.AutoSize = true;
            this.labelSendingUnit.Location = new System.Drawing.Point(91, 33);
            this.labelSendingUnit.Name = "labelSendingUnit";
            this.labelSendingUnit.Size = new System.Drawing.Size(14, 13);
            this.labelSendingUnit.TabIndex = 4;
            this.labelSendingUnit.Text = "X";
            // 
            // labelReceivingUnit
            // 
            this.labelReceivingUnit.AutoSize = true;
            this.labelReceivingUnit.Location = new System.Drawing.Point(91, 60);
            this.labelReceivingUnit.Name = "labelReceivingUnit";
            this.labelReceivingUnit.Size = new System.Drawing.Size(14, 13);
            this.labelReceivingUnit.TabIndex = 5;
            this.labelReceivingUnit.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Sending Unit:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Receiving Unit:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(171, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "DATA directory:";
            // 
            // lblDataDirectory
            // 
            this.lblDataDirectory.AutoSize = true;
            this.lblDataDirectory.Location = new System.Drawing.Point(248, 60);
            this.lblDataDirectory.Name = "lblDataDirectory";
            this.lblDataDirectory.Size = new System.Drawing.Size(28, 13);
            this.lblDataDirectory.TabIndex = 9;
            this.lblDataDirectory.Text = "XXX";
            // 
            // checkBoxResetFields
            // 
            this.checkBoxResetFields.AutoSize = true;
            this.checkBoxResetFields.Checked = true;
            this.checkBoxResetFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxResetFields.Location = new System.Drawing.Point(178, 85);
            this.checkBoxResetFields.Name = "checkBoxResetFields";
            this.checkBoxResetFields.Size = new System.Drawing.Size(131, 17);
            this.checkBoxResetFields.TabIndex = 10;
            this.checkBoxResetFields.Text = "Reset fields after send";
            this.checkBoxResetFields.UseVisualStyleBackColor = true;
            // 
            // forwarderToolStripMenuItem
            // 
            this.forwarderToolStripMenuItem.Name = "forwarderToolStripMenuItem";
            this.forwarderToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.forwarderToolStripMenuItem.Text = "Forwarder";
            this.forwarderToolStripMenuItem.Click += new System.EventHandler(this.forwarderToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 564);
            this.Controls.Add(this.checkBoxResetFields);
            this.Controls.Add(this.lblDataDirectory);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelReceivingUnit);
            this.Controls.Add(this.labelSendingUnit);
            this.Controls.Add(this.Label_ETIC_Directory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabABI);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "OLDI to ETIC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabABI.ResumeLayout(false);
            this.tabPageACT.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabABI;
        private System.Windows.Forms.TabPage tabPageACT;
        private System.Windows.Forms.Button btnSendACT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxSSR_ModeandCode;
        private System.Windows.Forms.TextBox textBoxTimeAtCOP;
        private System.Windows.Forms.TextBox textBoxACID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxTypeofFlight;
        private System.Windows.Forms.ComboBox comboBoxRVSMEQuiped;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxADEP;
        private System.Windows.Forms.ComboBox comboBoxADES;
        private System.Windows.Forms.ComboBox comboBoxCOP;
        private System.Windows.Forms.ComboBox comboBoxFLAtCOP;
        private System.Windows.Forms.ComboBox comboBoxACNumandtype;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Label_ETIC_Directory;
        private System.Windows.Forms.Label labelSendingUnit;
        private System.Windows.Forms.Label labelReceivingUnit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDataDirectory;
        private System.Windows.Forms.CheckBox checkBoxResetFields;
        private System.Windows.Forms.ToolStripMenuItem forwarderToolStripMenuItem;
    }
}

