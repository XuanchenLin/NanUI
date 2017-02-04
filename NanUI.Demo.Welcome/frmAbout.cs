﻿using NetDimension.NanUI;
using System.Windows.Forms;

namespace NanUI.Demo.Welcome
{
	public partial class frmAbout : HtmlUIForm

	{
		public frmAbout()
            : base("http://www/about.html", false)
		{
			InitializeComponent();
			this.ShowInTaskbar = false;
			this.ShowIcon = false;
			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.StartPosition = FormStartPosition.CenterParent;

		
		}
	}
}
