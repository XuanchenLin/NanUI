using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanUI.Demo.Welcome
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

			HtmlUILauncher.EnableFlashSupport = true;

			if (HtmlUILauncher.InitializeChromium(args =>
			{
				args.Settings.LogSeverity = Chromium.CfxLogSeverity.Default;
				//这里可以对CEF进行一些设定

			}, args =>
			{
				Console.WriteLine(args.CommandLine);
				//输出命令行开关，看看启用或是禁用了哪些功能
			}))
			{
				//初始化成功，加载程序集内嵌的资源到运行时中
				HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly());

				//启动主窗体
				Application.Run(new frmWelcome());
			}
		}
	}
}
