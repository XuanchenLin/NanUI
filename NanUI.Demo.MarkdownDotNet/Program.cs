using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NanUI.Demo.MarkdownDotNet
{
	using NetDimension.NanUI;

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
			if (HtmlUILauncher.InitializeChromium())
			{
				HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly(),"res");
				Application.Run(new frmMain());
			}
		}
	}
}
