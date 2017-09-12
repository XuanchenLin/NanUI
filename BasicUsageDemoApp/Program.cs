using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace BasicUsageDemoApp
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

			Bootstrap.BeforeCefInitialize = (args) => {
				//Settings for before CEF initiliazing...
				args.Settings.AcceptLanguageList = "zh-CN; en-US";
				args.Settings.LogSeverity = Chromium.CfxLogSeverity.Disable;
				
			};

			Bootstrap.BeforeCefCommandLineProcessing = (args) => {
				//Settings for CEF commnad line.
				args.CommandLine.AppendSwitch("disable-web-security");
			};

			if (Bootstrap.Load(PlatformArch.Auto, System.IO.Path.Combine(Application.StartupPath, "fx"), System.IO.Path.Combine(Application.StartupPath, "fx\\Resources"), System.IO.Path.Combine(Application.StartupPath, "fx\\Resources\\locales")))
			{
				Application.Run(new Form1());
			}

		}
	}
}
