namespace UsernameScraper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.NicknameTextBox = new System.Windows.Forms.TextBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordtextBox = new System.Windows.Forms.TextBox();
            this.EERadioButton = new System.Windows.Forms.RadioButton();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.emailtextBox = new System.Windows.Forms.TextBox();
            this.emaillabel = new System.Windows.Forms.Label();
            this.myworldsradioButton = new System.Windows.Forms.RadioButton();
            this.fromNickradioButton = new System.Windows.Forms.RadioButton();
            this.logrichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBLike = new System.Windows.Forms.CheckBox();
            this.cBFav = new System.Windows.Forms.CheckBox();
            this.worldIDRadioButton = new System.Windows.Forms.RadioButton();
            this.worldidGroupBox = new System.Windows.Forms.GroupBox();
            this.worldidTextBox = new System.Windows.Forms.TextBox();
            this.worldidLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.worldidGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Location = new System.Drawing.Point(6, 22);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(55, 13);
            this.NicknameLabel.TabIndex = 0;
            this.NicknameLabel.Text = "Nickname";
            // 
            // NicknameTextBox
            // 
            this.NicknameTextBox.Location = new System.Drawing.Point(9, 38);
            this.NicknameTextBox.Name = "NicknameTextBox";
            this.NicknameTextBox.Size = new System.Drawing.Size(127, 20);
            this.NicknameTextBox.TabIndex = 1;
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(125, 266);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(75, 23);
            this.ScanButton.TabIndex = 2;
            this.ScanButton.Text = "Download";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NicknameLabel);
            this.groupBox1.Controls.Add(this.NicknameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(358, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 122);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download worlds by nickname.";
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordtextBox);
            this.groupBox2.Controls.Add(this.EERadioButton);
            this.groupBox2.Controls.Add(this.passwordlabel);
            this.groupBox2.Controls.Add(this.emailtextBox);
            this.groupBox2.Controls.Add(this.emaillabel);
            this.groupBox2.Location = new System.Drawing.Point(13, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 161);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download your own worlds.";
            // 
            // passwordtextBox
            // 
            this.passwordtextBox.Location = new System.Drawing.Point(22, 121);
            this.passwordtextBox.Name = "passwordtextBox";
            this.passwordtextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordtextBox.TabIndex = 2;
            this.passwordtextBox.UseSystemPasswordChar = true;
            // 
            // EERadioButton
            // 
            this.EERadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.EERadioButton.AutoSize = true;
            this.EERadioButton.Checked = true;
            this.EERadioButton.Image = global::UsernameScraper.Properties.Resources.ee_icon;
            this.EERadioButton.Location = new System.Drawing.Point(25, 23);
            this.EERadioButton.Name = "EERadioButton";
            this.EERadioButton.Size = new System.Drawing.Size(22, 22);
            this.EERadioButton.TabIndex = 20;
            this.EERadioButton.TabStop = true;
            this.EERadioButton.UseVisualStyleBackColor = true;
            this.EERadioButton.CheckedChanged += new System.EventHandler(this.EERadioButton_CheckedChanged);
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Location = new System.Drawing.Point(19, 105);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(56, 13);
            this.passwordlabel.TabIndex = 2;
            this.passwordlabel.Text = "Password:";
            this.passwordlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emailtextBox
            // 
            this.emailtextBox.Location = new System.Drawing.Point(22, 76);
            this.emailtextBox.Name = "emailtextBox";
            this.emailtextBox.Size = new System.Drawing.Size(100, 20);
            this.emailtextBox.TabIndex = 1;
            // 
            // emaillabel
            // 
            this.emaillabel.AutoSize = true;
            this.emaillabel.Location = new System.Drawing.Point(19, 60);
            this.emaillabel.Name = "emaillabel";
            this.emaillabel.Size = new System.Drawing.Size(38, 13);
            this.emaillabel.TabIndex = 0;
            this.emaillabel.Text = "E-mail:";
            // 
            // myworldsradioButton
            // 
            this.myworldsradioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.myworldsradioButton.AutoSize = true;
            this.myworldsradioButton.Checked = true;
            this.myworldsradioButton.Location = new System.Drawing.Point(11, 22);
            this.myworldsradioButton.Name = "myworldsradioButton";
            this.myworldsradioButton.Size = new System.Drawing.Size(112, 23);
            this.myworldsradioButton.TabIndex = 3;
            this.myworldsradioButton.TabStop = true;
            this.myworldsradioButton.Text = "Read from Account.";
            this.myworldsradioButton.UseVisualStyleBackColor = true;
            this.myworldsradioButton.CheckedChanged += new System.EventHandler(this.MyworldsradioButton_CheckedChanged);
            // 
            // fromNickradioButton
            // 
            this.fromNickradioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.fromNickradioButton.AutoSize = true;
            this.fromNickradioButton.Location = new System.Drawing.Point(11, 100);
            this.fromNickradioButton.Name = "fromNickradioButton";
            this.fromNickradioButton.Size = new System.Drawing.Size(125, 23);
            this.fromNickradioButton.TabIndex = 6;
            this.fromNickradioButton.Text = "Read from Nicknames.";
            this.fromNickradioButton.UseVisualStyleBackColor = true;
            this.fromNickradioButton.CheckedChanged += new System.EventHandler(this.FromNickradioButton_CheckedChanged);
            // 
            // logrichTextBox
            // 
            this.logrichTextBox.Location = new System.Drawing.Point(6, 23);
            this.logrichTextBox.Name = "logrichTextBox";
            this.logrichTextBox.ReadOnly = true;
            this.logrichTextBox.Size = new System.Drawing.Size(317, 92);
            this.logrichTextBox.TabIndex = 11;
            this.logrichTextBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logrichTextBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 121);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 419);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(329, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "World downloader to EE offline.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(359, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::UsernameScraper.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBLike);
            this.groupBox4.Controls.Add(this.cBFav);
            this.groupBox4.Controls.Add(this.worldIDRadioButton);
            this.groupBox4.Controls.Add(this.myworldsradioButton);
            this.groupBox4.Controls.Add(this.fromNickradioButton);
            this.groupBox4.Location = new System.Drawing.Point(202, 60);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 161);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // cBLike
            // 
            this.cBLike.AutoSize = true;
            this.cBLike.Location = new System.Drawing.Point(11, 76);
            this.cBLike.Name = "cBLike";
            this.cBLike.Size = new System.Drawing.Size(52, 17);
            this.cBLike.TabIndex = 5;
            this.cBLike.Text = "Liked";
            this.cBLike.UseVisualStyleBackColor = true;
            // 
            // cBFav
            // 
            this.cBFav.AutoSize = true;
            this.cBFav.Location = new System.Drawing.Point(11, 53);
            this.cBFav.Name = "cBFav";
            this.cBFav.Size = new System.Drawing.Size(69, 17);
            this.cBFav.TabIndex = 4;
            this.cBFav.Text = "Favorites";
            this.cBFav.UseVisualStyleBackColor = true;
            // 
            // worldIDRadioButton
            // 
            this.worldIDRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.worldIDRadioButton.AutoSize = true;
            this.worldIDRadioButton.Location = new System.Drawing.Point(11, 127);
            this.worldIDRadioButton.Name = "worldIDRadioButton";
            this.worldIDRadioButton.Size = new System.Drawing.Size(108, 23);
            this.worldIDRadioButton.TabIndex = 7;
            this.worldIDRadioButton.TabStop = true;
            this.worldIDRadioButton.Text = "Read from WorldID";
            this.worldIDRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.worldIDRadioButton.UseVisualStyleBackColor = true;
            this.worldIDRadioButton.CheckedChanged += new System.EventHandler(this.WorldIDRadioButton_CheckedChanged);
            // 
            // worldidGroupBox
            // 
            this.worldidGroupBox.Controls.Add(this.worldidTextBox);
            this.worldidGroupBox.Controls.Add(this.worldidLabel);
            this.worldidGroupBox.Location = new System.Drawing.Point(358, 37);
            this.worldidGroupBox.Name = "worldidGroupBox";
            this.worldidGroupBox.Size = new System.Drawing.Size(183, 122);
            this.worldidGroupBox.TabIndex = 19;
            this.worldidGroupBox.TabStop = false;
            this.worldidGroupBox.Text = "Download worlds by WorldID";
            this.worldidGroupBox.Visible = false;
            // 
            // worldidTextBox
            // 
            this.worldidTextBox.Location = new System.Drawing.Point(9, 38);
            this.worldidTextBox.Name = "worldidTextBox";
            this.worldidTextBox.Size = new System.Drawing.Size(127, 20);
            this.worldidTextBox.TabIndex = 1;
            // 
            // worldidLabel
            // 
            this.worldidLabel.AutoSize = true;
            this.worldidLabel.Location = new System.Drawing.Point(6, 22);
            this.worldidLabel.Name = "worldidLabel";
            this.worldidLabel.Size = new System.Drawing.Size(52, 13);
            this.worldidLabel.TabIndex = 0;
            this.worldidLabel.Text = "World ID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 459);
            this.Controls.Add(this.worldidGroupBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(375, 498);
            this.MinimumSize = new System.Drawing.Size(375, 498);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.worldidGroupBox.ResumeLayout(false);
            this.worldidGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NicknameLabel;
        private System.Windows.Forms.TextBox NicknameTextBox;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwordtextBox;
        private System.Windows.Forms.Label passwordlabel;
        private System.Windows.Forms.TextBox emailtextBox;
        private System.Windows.Forms.Label emaillabel;
        private System.Windows.Forms.RadioButton myworldsradioButton;
        private System.Windows.Forms.RadioButton fromNickradioButton;
        private System.Windows.Forms.RichTextBox logrichTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton worldIDRadioButton;
        private System.Windows.Forms.GroupBox worldidGroupBox;
        private System.Windows.Forms.TextBox worldidTextBox;
        private System.Windows.Forms.Label worldidLabel;
        private System.Windows.Forms.CheckBox cBFav;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RadioButton EERadioButton;
        private System.Windows.Forms.CheckBox cBLike;
    }
}

