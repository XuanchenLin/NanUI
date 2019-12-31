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
			: base("http://res.app.local/index.html")
		{
			InitializeComponent();

			//FormBorderStyle = FormBorderStyle.FixedDialog;


			GlobalObject.AddFunction("showDialog").Execute += (_, args) =>
			{
				this.RequireUIThread(() =>
				{
					var form2 = new Form2();
					form2.ShowDialog(this);
				});
			};

			GlobalObject.AddFunction("showWindow").Execute += (_, args) =>
			{
				this.RequireUIThread(() =>
				{
					var form2 = new Form2();
					form2.Show(this);
				});
			};

			GlobalObject.AddFunction("showDevTools").Execute += (func, args) => Chromium.ShowDevTools();

		}
	}
}
