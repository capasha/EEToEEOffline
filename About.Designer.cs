namespace UsernameScraper
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.EELVLLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EELevelLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EESDKLinkLabel = new System.Windows.Forms.LinkLabel();
            this.FodyLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to EE Worlds to EE Offline Worlds converter.\r\nThis tool is made by Capash" +
    "a and Mochio.";
            // 
            // EELVLLinkLabel
            // 
            this.EELVLLinkLabel.AutoSize = true;
            this.EELVLLinkLabel.Location = new System.Drawing.Point(71, 75);
            this.EELVLLinkLabel.Name = "EELVLLinkLabel";
            this.EELVLLinkLabel.Size = new System.Drawing.Size(122, 13);
            this.EELVLLinkLabel.TabIndex = 1;
            this.EELVLLinkLabel.TabStop = true;
            this.EELVLLinkLabel.Text = "EELVL parser by LukeM";
            this.EELVLLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Clicked_LinkClicked);
            this.EELVLLinkLabel.MouseEnter += new System.EventHandler(this.LinkLabel_MouseHover);
            this.EELVLLinkLabel.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            // 
            // EELevelLinkLabel
            // 
            this.EELevelLinkLabel.AutoSize = true;
            this.EELevelLinkLabel.Location = new System.Drawing.Point(71, 98);
            this.EELevelLinkLabel.Name = "EELevelLinkLabel";
            this.EELevelLinkLabel.Size = new System.Drawing.Size(129, 13);
            this.EELevelLinkLabel.TabIndex = 2;
            this.EELevelLinkLabel.TabStop = true;
            this.EELevelLinkLabel.Text = "EE Level API by Atillabyte";
            this.EELevelLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Clicked_LinkClicked);
            this.EELevelLinkLabel.MouseEnter += new System.EventHandler(this.LinkLabel_MouseHover);
            this.EELevelLinkLabel.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            // 
            // EESDKLinkLabel
            // 
            this.EESDKLinkLabel.AutoSize = true;
            this.EESDKLinkLabel.Location = new System.Drawing.Point(71, 123);
            this.EESDKLinkLabel.Name = "EESDKLinkLabel";
            this.EESDKLinkLabel.Size = new System.Drawing.Size(129, 13);
            this.EESDKLinkLabel.TabIndex = 3;
            this.EESDKLinkLabel.TabStop = true;
            this.EESDKLinkLabel.Text = "PlayerIO SDK by PlayerIO";
            this.EESDKLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Clicked_LinkClicked);
            this.EESDKLinkLabel.MouseEnter += new System.EventHandler(this.LinkLabel_MouseHover);
            this.EESDKLinkLabel.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            // 
            // FodyLinkLabel
            // 
            this.FodyLinkLabel.AutoSize = true;
            this.FodyLinkLabel.Location = new System.Drawing.Point(71, 150);
            this.FodyLinkLabel.Name = "FodyLinkLabel";
            this.FodyLinkLabel.Size = new System.Drawing.Size(90, 13);
            this.FodyLinkLabel.TabIndex = 4;
            this.FodyLinkLabel.TabStop = true;
            this.FodyLinkLabel.Text = "Fody DLL Packer";
            this.FodyLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Clicked_LinkClicked);
            this.FodyLinkLabel.MouseEnter += new System.EventHandler(this.LinkLabel_MouseHover);
            this.FodyLinkLabel.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 189);
            this.Controls.Add(this.FodyLinkLabel);
            this.Controls.Add(this.EESDKLinkLabel);
            this.Controls.Add(this.EELevelLinkLabel);
            this.Controls.Add(this.EELVLLinkLabel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel EELVLLinkLabel;
        private System.Windows.Forms.LinkLabel EELevelLinkLabel;
        private System.Windows.Forms.LinkLabel EESDKLinkLabel;
        private System.Windows.Forms.LinkLabel FodyLinkLabel;
    }
}