namespace UsernameScraper
{
    partial class Settingss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settingss));
            this.settingsloginlabel = new System.Windows.Forms.Label();
            this.settingspasslabel = new System.Windows.Forms.Label();
            this.settingslogintextBox = new System.Windows.Forms.TextBox();
            this.settingspasstextBox = new System.Windows.Forms.TextBox();
            this.settingsloginsavebutton = new System.Windows.Forms.Button();
            this.settingslogingroupBox = new System.Windows.Forms.GroupBox();
            this.settingslogingroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsloginlabel
            // 
            this.settingsloginlabel.AutoSize = true;
            this.settingsloginlabel.Location = new System.Drawing.Point(25, 24);
            this.settingsloginlabel.Name = "settingsloginlabel";
            this.settingsloginlabel.Size = new System.Drawing.Size(36, 13);
            this.settingsloginlabel.TabIndex = 0;
            this.settingsloginlabel.Text = "Login:";
            // 
            // settingspasslabel
            // 
            this.settingspasslabel.AutoSize = true;
            this.settingspasslabel.Location = new System.Drawing.Point(25, 63);
            this.settingspasslabel.Name = "settingspasslabel";
            this.settingspasslabel.Size = new System.Drawing.Size(56, 13);
            this.settingspasslabel.TabIndex = 1;
            this.settingspasslabel.Text = "Password:";
            // 
            // settingslogintextBox
            // 
            this.settingslogintextBox.Location = new System.Drawing.Point(28, 40);
            this.settingslogintextBox.Name = "settingslogintextBox";
            this.settingslogintextBox.Size = new System.Drawing.Size(132, 20);
            this.settingslogintextBox.TabIndex = 2;
            this.settingslogintextBox.Text = "guest";
            // 
            // settingspasstextBox
            // 
            this.settingspasstextBox.Location = new System.Drawing.Point(28, 79);
            this.settingspasstextBox.Name = "settingspasstextBox";
            this.settingspasstextBox.Size = new System.Drawing.Size(132, 20);
            this.settingspasstextBox.TabIndex = 3;
            this.settingspasstextBox.Text = "guest";
            this.settingspasstextBox.UseSystemPasswordChar = true;
            // 
            // settingsloginsavebutton
            // 
            this.settingsloginsavebutton.Location = new System.Drawing.Point(44, 105);
            this.settingsloginsavebutton.Name = "settingsloginsavebutton";
            this.settingsloginsavebutton.Size = new System.Drawing.Size(75, 23);
            this.settingsloginsavebutton.TabIndex = 4;
            this.settingsloginsavebutton.Text = "Save";
            this.settingsloginsavebutton.UseVisualStyleBackColor = true;
            this.settingsloginsavebutton.Click += new System.EventHandler(this.Settingsloginsavebutton_Click);
            // 
            // settingslogingroupBox
            // 
            this.settingslogingroupBox.Controls.Add(this.settingslogintextBox);
            this.settingslogingroupBox.Controls.Add(this.settingsloginsavebutton);
            this.settingslogingroupBox.Controls.Add(this.settingsloginlabel);
            this.settingslogingroupBox.Controls.Add(this.settingspasstextBox);
            this.settingslogingroupBox.Controls.Add(this.settingspasslabel);
            this.settingslogingroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingslogingroupBox.Name = "settingslogingroupBox";
            this.settingslogingroupBox.Size = new System.Drawing.Size(200, 134);
            this.settingslogingroupBox.TabIndex = 5;
            this.settingslogingroupBox.TabStop = false;
            this.settingslogingroupBox.Text = "Bot will login as X";
            // 
            // Settingss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 154);
            this.Controls.Add(this.settingslogingroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settingss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settingss_Load);
            this.settingslogingroupBox.ResumeLayout(false);
            this.settingslogingroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label settingsloginlabel;
        private System.Windows.Forms.Label settingspasslabel;
        private System.Windows.Forms.TextBox settingslogintextBox;
        private System.Windows.Forms.TextBox settingspasstextBox;
        private System.Windows.Forms.Button settingsloginsavebutton;
        private System.Windows.Forms.GroupBox settingslogingroupBox;
    }
}