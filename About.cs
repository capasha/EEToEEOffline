using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UsernameScraper
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(255, 67, 67, 67);
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl.GetType() == typeof(LinkLabel))
                {
                    ((LinkLabel)cntrl).ForeColor = Color.White;
                    ((LinkLabel)cntrl).BackColor = Color.FromArgb(255, 67, 67, 67);
                    ((LinkLabel)cntrl).LinkColor = Color.Orange;
                    ((LinkLabel)cntrl).VisitedLinkColor = Color.Orange;
                    ((LinkLabel)cntrl).ActiveLinkColor = Color.Yellow;



                }
            }
        }

        private void Clicked_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = null;
            switch (((LinkLabel)sender).Name)
            {
                case "EELVLLinkLabel":
                    link = "https://gitlab.com/LukeM212/EELVL/-/tree/v2.4-legacy";
                    break;
                case "EELevelLinkLabel":
                    link = "https://github.com/atillabyte/World";
                    break;
                case "EESDKLinkLabel":
                    link = "https://playerio.com/download/";
                    break;
                case "FodyLinkLabel":
                    link = "https://github.com/Fody/Fody";
                    break;
            }
            if (MessageBox.Show("Are you sure you want to this site?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start(link);
            }
        }

        private void LinkLabel_MouseHover(object sender, EventArgs e)
        {
            ((LinkLabel)sender).LinkColor = Color.Yellow;
        }
        private void linkLabel_MouseLeave(object sender, EventArgs e)
        {
            ((LinkLabel)sender).LinkColor = Color.Orange;
        }
    }
}
