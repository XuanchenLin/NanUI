using System;
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
			if (HtmlUILauncher.InitializeChromium(null, null))
			{
				HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly(),"http", "assets");
				Application.Run(new frmMain());
			}
		}
	}
}
