using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsernameScraper
{
    public partial class Settingss : Form
    {
        private bool loaded = false;
        public Settingss()
        {
            InitializeComponent();
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(75, 75, 75);
            foreach (Control cntrl1 in this.Controls)
            {
                if (cntrl1.GetType() == typeof(GroupBox))
                {
                    cntrl1.ForeColor = Color.White;
                    cntrl1.BackColor = Color.FromArgb(75, 75, 75);
                    foreach (Control ctrl in cntrl1.Controls)
                    {
                        ctrl.ForeColor = Color.White;
                        ctrl.BackColor = Color.FromArgb(75, 75, 75);
                        if (ctrl.GetType() == typeof(Label))
                        {
                            ctrl.ForeColor = Color.White;
                        }
                        if (ctrl.GetType() == typeof(Button))
                        {
                            ctrl.BackColor = Color.FromArgb(100, 100, 100);
                            ctrl.ForeColor = Color.White;
                            ((Button)ctrl).FlatStyle = FlatStyle.Flat;
                        }
                        if (ctrl.GetType() == typeof(TextBox))
                        {
                            ((TextBox)ctrl).ForeColor = Color.White;
                            ((TextBox)ctrl).BackColor = Color.FromArgb(75, 75, 75);
                        }
                    }
                }
            }
        }

        private void Settingsloginsavebutton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.botlogin = settingslogintextBox.Text.ToLower();
            Properties.Settings.Default.botpass = settingspasstextBox.Text.ToLower();
            Properties.Settings.Default.Save();
        }


        private void Settingss_Load(object sender, EventArgs e)
        {
            loaded = true;
            settingslogintextBox.Text = Properties.Settings.Default.botlogin == string.Empty ? "marciosil@gmail.com" : Properties.Settings.Default.botlogin;
            settingspasstextBox.Text = Properties.Settings.Default.botpass == string.Empty ? "#c9uz=um???xr0x" : Properties.Settings.Default.botpass;
            loaded = false;
        }
    }
}
