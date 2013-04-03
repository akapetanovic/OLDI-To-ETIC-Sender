namespace OLDI_To_ETIC_Sender
{
    partial class DisplayItems
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
            this.checkBoxMsg_Version = new System.Windows.Forms.CheckBox();
            this.checkBoxMsg_Content = new System.Windows.Forms.CheckBox();
            this.checkBoxMsg_Type = new System.Windows.Forms.CheckBox();
            this.checkBoxMsg_Length = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Identification = new System.Windows.Forms.CheckBox();
            this.checkBox_System = new System.Windows.Forms.CheckBox();
            this.checkBoxOperator = new System.Windows.Forms.CheckBox();
            this.checkBox_Operational = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxMsg_Version
            // 
            this.checkBoxMsg_Version.AutoSize = true;
            this.checkBoxMsg_Version.Location = new System.Drawing.Point(6, 19);
            this.checkBoxMsg_Version.Name = "checkBoxMsg_Version";
            this.checkBoxMsg_Version.Size = new System.Drawing.Size(84, 17);
            this.checkBoxMsg_Version.TabIndex = 0;
            this.checkBoxMsg_Version.Text = "Msg Version";
            this.checkBoxMsg_Version.UseVisualStyleBackColor = true;
            this.checkBoxMsg_Version.CheckedChanged += new System.EventHandler(this.checkBoxMsg_Version_CheckedChanged);
            // 
            // checkBoxMsg_Content
            // 
            this.checkBoxMsg_Content.AutoSize = true;
            this.checkBoxMsg_Content.Location = new System.Drawing.Point(6, 88);
            this.checkBoxMsg_Content.Name = "checkBoxMsg_Content";
            this.checkBoxMsg_Content.Size = new System.Drawing.Size(86, 17);
            this.checkBoxMsg_Content.TabIndex = 1;
            this.checkBoxMsg_Content.Text = "Msg Content";
            this.checkBoxMsg_Content.UseVisualStyleBackColor = true;
            this.checkBoxMsg_Content.CheckedChanged += new System.EventHandler(this.checkBoxMsg_Content_CheckedChanged);
            // 
            // checkBoxMsg_Type
            // 
            this.checkBoxMsg_Type.AutoSize = true;
            this.checkBoxMsg_Type.Location = new System.Drawing.Point(6, 65);
            this.checkBoxMsg_Type.Name = "checkBoxMsg_Type";
            this.checkBoxMsg_Type.Size = new System.Drawing.Size(73, 17);
            this.checkBoxMsg_Type.TabIndex = 2;
            this.checkBoxMsg_Type.Text = "Msg Type";
            this.checkBoxMsg_Type.UseVisualStyleBackColor = true;
            this.checkBoxMsg_Type.CheckedChanged += new System.EventHandler(this.checkBoxMsg_Type_CheckedChanged);
            // 
            // checkBoxMsg_Length
            // 
            this.checkBoxMsg_Length.AutoSize = true;
            this.checkBoxMsg_Length.Location = new System.Drawing.Point(6, 42);
            this.checkBoxMsg_Length.Name = "checkBoxMsg_Length";
            this.checkBoxMsg_Length.Size = new System.Drawing.Size(82, 17);
            this.checkBoxMsg_Length.TabIndex = 3;
            this.checkBoxMsg_Length.Text = "Msg Length";
            this.checkBoxMsg_Length.UseVisualStyleBackColor = true;
            this.checkBoxMsg_Length.CheckedChanged += new System.EventHandler(this.checkBoxMsg_Length_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_Identification);
            this.groupBox1.Controls.Add(this.checkBox_System);
            this.groupBox1.Controls.Add(this.checkBoxOperator);
            this.groupBox1.Controls.Add(this.checkBox_Operational);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Msg Type";
            // 
            // checkBox_Identification
            // 
            this.checkBox_Identification.AutoSize = true;
            this.checkBox_Identification.Location = new System.Drawing.Point(6, 89);
            this.checkBox_Identification.Name = "checkBox_Identification";
            this.checkBox_Identification.Size = new System.Drawing.Size(86, 17);
            this.checkBox_Identification.TabIndex = 3;
            this.checkBox_Identification.Text = "Identification";
            this.checkBox_Identification.UseVisualStyleBackColor = true;
            this.checkBox_Identification.CheckedChanged += new System.EventHandler(this.checkBox_Identification_CheckedChanged);
            // 
            // checkBox_System
            // 
            this.checkBox_System.AutoSize = true;
            this.checkBox_System.Location = new System.Drawing.Point(6, 66);
            this.checkBox_System.Name = "checkBox_System";
            this.checkBox_System.Size = new System.Drawing.Size(60, 17);
            this.checkBox_System.TabIndex = 2;
            this.checkBox_System.Text = "System";
            this.checkBox_System.UseVisualStyleBackColor = true;
            this.checkBox_System.CheckedChanged += new System.EventHandler(this.checkBox_System_CheckedChanged);
            // 
            // checkBoxOperator
            // 
            this.checkBoxOperator.AutoSize = true;
            this.checkBoxOperator.Location = new System.Drawing.Point(6, 43);
            this.checkBoxOperator.Name = "checkBoxOperator";
            this.checkBoxOperator.Size = new System.Drawing.Size(67, 17);
            this.checkBoxOperator.TabIndex = 1;
            this.checkBoxOperator.Text = "Operator";
            this.checkBoxOperator.UseVisualStyleBackColor = true;
            this.checkBoxOperator.CheckedChanged += new System.EventHandler(this.checkBoxOperator_CheckedChanged);
            // 
            // checkBox_Operational
            // 
            this.checkBox_Operational.AutoSize = true;
            this.checkBox_Operational.Location = new System.Drawing.Point(7, 20);
            this.checkBox_Operational.Name = "checkBox_Operational";
            this.checkBox_Operational.Size = new System.Drawing.Size(80, 17);
            this.checkBox_Operational.TabIndex = 0;
            this.checkBox_Operational.Text = "Operational";
            this.checkBox_Operational.UseVisualStyleBackColor = true;
            this.checkBox_Operational.CheckedChanged += new System.EventHandler(this.checkBox_Operational_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxMsg_Version);
            this.groupBox2.Controls.Add(this.checkBoxMsg_Content);
            this.groupBox2.Controls.Add(this.checkBoxMsg_Length);
            this.groupBox2.Controls.Add(this.checkBoxMsg_Type);
            this.groupBox2.Location = new System.Drawing.Point(147, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(97, 114);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Msg Content";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "---->";
            // 
            // DisplayItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 143);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DisplayItems";
            this.Text = "Display Items";
            this.Load += new System.EventHandler(this.DisplayItmes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxMsg_Version;
        private System.Windows.Forms.CheckBox checkBoxMsg_Content;
        private System.Windows.Forms.CheckBox checkBoxMsg_Type;
        private System.Windows.Forms.CheckBox checkBoxMsg_Length;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_Identification;
        private System.Windows.Forms.CheckBox checkBox_System;
        private System.Windows.Forms.CheckBox checkBoxOperator;
        private System.Windows.Forms.CheckBox checkBox_Operational;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}