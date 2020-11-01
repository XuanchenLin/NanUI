using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    public partial class AboutDialog : Form
    {
        //private MemoryStream _licenseContentStream;

        public AboutDialog()
        {
            InitializeComponent();
            Icon = Properties.Resources.DefaultIcon;
            Text = Resources.Messages.AboutDialog_Title;
            CloseButton.Text = Resources.Messages.AboutDialog_CloseButton;

        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            using (var licenseContentStream = new MemoryStream(Properties.Resources.Licenses))
            {
                LicenseTextBox.LoadFile(licenseContentStream, RichTextBoxStreamType.RichText);
            }

        }

        private void LicenseTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            var ps = new System.Diagnostics.ProcessStartInfo(e.LinkText)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            System.Diagnostics.Process.Start(ps);


        }
    }
}
