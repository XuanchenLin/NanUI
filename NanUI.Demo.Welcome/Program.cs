using NetDimension.NanUI;
using System;
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

			if (HtmlUILauncher.InitializeChromium((args=> {
				args.Settings.LogSeverity = Chromium.CfxLogSeverity.Default;
			})))
			{
				// (1) 注册本地文件资源
				// 第1个参数指定使用http协议(schemeName)
				// 第2个参数指定网页存放的文件夹(等价于domainName)
				// 例如: http://www/index.html 等价于 ${当前工作路径}\www\index.html
				// 注意: cef3官方文档强烈建议不要使用local、file等scheme，也不建议自定义scheme，
				//        最好是使用builtin(内置)的scheme，比如: http、https。
				//        因为自定义的scheme有些时候可能会收不到POST的数据以及其它问题!!!
				//HtmlUILauncher.RegisterLocalScheme("http", "www");

				// (2) 注册程序集内嵌资源
				// 第1个参数指定使用http协议(schemeName)
				// 第2个参数指定网页存放的文件夹(等价于domainName)
				// 例如: http://www/index.html 等价于 ${程序集根目录}\www\index.html
				HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly(), "http", "www");

				//启动主窗体
				Application.Run(new frmWelcome());
			}
		}
	}
}
