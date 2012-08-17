namespace OLDI_To_ETIC_Sender
{
    partial class Settings
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCOM2_Name = new System.Windows.Forms.TextBox();
            this.textBoxCOM1_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSelectedFolder = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDataDirectory = new System.Windows.Forms.Label();
            this.buttonBrowseDataDir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sender";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCOM2_Name);
            this.groupBox1.Controls.Add(this.textBoxCOM1_Name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comm partners";
            // 
            // textBoxCOM2_Name
            // 
            this.textBoxCOM2_Name.Location = new System.Drawing.Point(207, 37);
            this.textBoxCOM2_Name.Name = "textBoxCOM2_Name";
            this.textBoxCOM2_Name.Size = new System.Drawing.Size(159, 20);
            this.textBoxCOM2_Name.TabIndex = 5;
            // 
            // textBoxCOM1_Name
            // 
            this.textBoxCOM1_Name.Location = new System.Drawing.Point(8, 37);
            this.textBoxCOM1_Name.Name = "textBoxCOM1_Name";
            this.textBoxCOM1_Name.Size = new System.Drawing.Size(159, 20);
            this.textBoxCOM1_Name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Receiver";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Etic directory: ";
            // 
            // labelSelectedFolder
            // 
            this.labelSelectedFolder.AutoSize = true;
            this.labelSelectedFolder.Location = new System.Drawing.Point(82, 14);
            this.labelSelectedFolder.Name = "labelSelectedFolder";
            this.labelSelectedFolder.Size = new System.Drawing.Size(28, 13);
            this.labelSelectedFolder.TabIndex = 6;
            this.labelSelectedFolder.Text = "XXX";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(4, 136);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(301, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data directory:";
            // 
            // labelDataDirectory
            // 
            this.labelDataDirectory.AutoSize = true;
            this.labelDataDirectory.Location = new System.Drawing.Point(82, 43);
            this.labelDataDirectory.Name = "labelDataDirectory";
            this.labelDataDirectory.Size = new System.Drawing.Size(28, 13);
            this.labelDataDirectory.TabIndex = 10;
            this.labelDataDirectory.Text = "XXX";
            // 
            // buttonBrowseDataDir
            // 
            this.buttonBrowseDataDir.Location = new System.Drawing.Point(304, 33);
            this.buttonBrowseDataDir.Name = "buttonBrowseDataDir";
            this.buttonBrowseDataDir.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseDataDir.TabIndex = 11;
            this.buttonBrowseDataDir.Text = "Browse";
            this.buttonBrowseDataDir.UseVisualStyleBackColor = true;
            this.buttonBrowseDataDir.Click += new System.EventHandler(this.buttonBrowseDataDir_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 166);
            this.Controls.Add(this.buttonBrowseDataDir);
            this.Controls.Add(this.labelDataDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelSelectedFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.Text = "Application Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCOM2_Name;
        private System.Windows.Forms.TextBox textBoxCOM1_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSelectedFolder;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDataDirectory;
        private System.Windows.Forms.Button buttonBrowseDataDir;
    }
}