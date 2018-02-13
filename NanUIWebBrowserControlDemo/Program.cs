using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace NanUIWebBrowserControlDemo
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

			if (Bootstrap.Load(settings=> {

				//Settings for before CEF initiliazing...

				settings.AcceptLanguageList = "zh-CN; en-US";
				settings.LogSeverity = Chromium.CfxLogSeverity.Disable;

			}, commandline=> {
				
				//Settings for CEF commnad line.

				commandline.AppendSwitch("disable-web-security");
			}))
			{
				Application.Run(new Form1());
			}
		}
	}
}
