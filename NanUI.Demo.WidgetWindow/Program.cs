using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace NanUI.Demo.WidgetWindow
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (HtmlWidgetLauncher.InitializeChromium())
			{
				//HtmlWidgetLauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly(), "http", "www");
				Application.Run(new Form1());
			}


		}
	}
}
