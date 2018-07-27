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

namespace WinXPSupportDemoApp
{
	public partial class Form1 : Formium
	{
		public Form1()
			: base("http://res.app.local/index.html")
		{
			InitializeComponent();

			GlobalObject.AddFunction("showDevTools").Execute += (func, args) => Chromium.ShowDevTools();

		}
	}
}
