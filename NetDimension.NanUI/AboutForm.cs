using System.Diagnostics;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.cnblogs.com/linxuanchen/");

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/NetDimension/NanUI");
		}
	}
}
