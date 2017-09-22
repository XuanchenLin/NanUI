using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace BorderlessFormStyleDemoApp
{
	public partial class Form1 : Formium
	{
		public Form1()
			: base("http://res.app.local/asserts/index.html")
		{
			InitializeComponent();

			LoadHandler.OnLoadStart += LoadHandler_OnLoadStart;

			//this.Left = 0;
			//this.Top = 0;


			var form2 = new Form2();
			//form2.Left = Screen.AllScreens[1].WorkingArea.Left;
			//form2.Top = Screen.AllScreens[1].WorkingArea.Top;

			form2.Show(this);

		}

		private void LoadHandler_OnLoadStart(object sender, Chromium.Event.CfxOnLoadStartEventArgs e)
		{
#if DEBUG
			Chromium.ShowDevTools();
#endif
		}
	}
}
