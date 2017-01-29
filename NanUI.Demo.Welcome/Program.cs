﻿using NetDimension.NanUI;
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

            if (HtmlUILauncher.InitializeChromium((args =>
            {
                args.Settings.LogSeverity = Chromium.CfxLogSeverity.Default;
                args.Settings.BrowserSubprocessPath = "NanUI.BrowserSubprocess.exe";
            }), null))
			{
				//初始化成功，加载程序集内嵌的资源到运行时中
                HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly(), "embedded", null);

				//启动主窗体
				Application.Run(new frmWelcome());
			}
		}
	}
}
