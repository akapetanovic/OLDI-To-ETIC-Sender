namespace OLDI_To_ETIC_Sender.OLDI_Forwarder
{
    partial class DisplayItmes
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
            this.SuspendLayout();
            // 
            // checkBoxMsg_Version
            // 
            this.checkBoxMsg_Version.AutoSize = true;
            this.checkBoxMsg_Version.Location = new System.Drawing.Point(12, 12);
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
            this.checkBoxMsg_Content.Location = new System.Drawing.Point(12, 81);
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
            this.checkBoxMsg_Type.Location = new System.Drawing.Point(12, 58);
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
            this.checkBoxMsg_Length.Location = new System.Drawing.Point(12, 35);
            this.checkBoxMsg_Length.Name = "checkBoxMsg_Length";
            this.checkBoxMsg_Length.Size = new System.Drawing.Size(82, 17);
            this.checkBoxMsg_Length.TabIndex = 3;
            this.checkBoxMsg_Length.Text = "Msg Length";
            this.checkBoxMsg_Length.UseVisualStyleBackColor = true;
            this.checkBoxMsg_Length.CheckedChanged += new System.EventHandler(this.checkBoxMsg_Length_CheckedChanged);
            // 
            // DisplayItmes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 117);
            this.Controls.Add(this.checkBoxMsg_Length);
            this.Controls.Add(this.checkBoxMsg_Type);
            this.Controls.Add(this.checkBoxMsg_Content);
            this.Controls.Add(this.checkBoxMsg_Version);
            this.Name = "DisplayItmes";
            this.Text = "Display Items";
            this.Load += new System.EventHandler(this.DisplayItmes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxMsg_Version;
        private System.Windows.Forms.CheckBox checkBoxMsg_Content;
        private System.Windows.Forms.CheckBox checkBoxMsg_Type;
        private System.Windows.Forms.CheckBox checkBoxMsg_Length;
    }
}