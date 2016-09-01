using Chromium;
using Chromium.Event;
using Chromium.Remote;
using NetDimension.NanUI.ChromiumCore;
using NetDimension.NanUI.ChromiumCore.Event;
using NetDimension.NanUI.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public class HtmlWidgetLauncher
	{
		internal static event OnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes;
		internal static void RaiseOnRegisterCustomSchemes(CfxOnRegisterCustomSchemesEventArgs e)
		{
			OnRegisterCustomSchemes?.Invoke(e);
		}

		public static bool InitializeChromium()
		{

			if (ChromiumStartupSettings.PrepareRuntime())
			{
				var exitCode = CfxRuntime.ExecuteProcess(null);
				if (exitCode >= 0)
				{
					Environment.Exit(exitCode);
				}

				var settings = new CfxSettings();
				settings.WindowlessRenderingEnabled = true;
				settings.NoSandbox = true;

				var cachePath = System.IO.Path.Combine(ChromiumStartupSettings.ApplicationDataDir, Application.ProductName, "Cache");
				if (!System.IO.Directory.Exists(cachePath))
					System.IO.Directory.CreateDirectory(cachePath);

				settings.LocalesDirPath = ChromiumStartupSettings.LocalesDir;
				settings.ResourcesDirPath = ChromiumStartupSettings.ResourcesDir;
				settings.Locale = "zh-CN";
				settings.CachePath = cachePath;
				settings.LogSeverity = CfxLogSeverity.Disable;




				OnRegisterCustomSchemes += args =>
				{
					args.Registrar.AddCustomScheme("embedded", false, false, false);
				};




				try
				{
					var app = new CfxApp();
					app.OnBeforeCommandLineProcessing += (s, e) =>
					{
						// optimizations following recommendations from issue #84
						e.CommandLine.AppendSwitch("disable-gpu");
						e.CommandLine.AppendSwitch("disable-gpu-compositing");
						e.CommandLine.AppendSwitch("disable-gpu-vsync");
					};

					if (!CfxRuntime.Initialize(settings, app))
					{
						//Environment.Exit(-1);
						return false;
					}

					Application.Idle += (sender, e) =>
					{
						CfxRuntime.DoMessageLoopWork();
					};




					return true;

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);

					Console.WriteLine(ex.InnerException);
					MessageBox.Show(string.Format("初始化系统失败。\r\n{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			return false;
		}

		public static void RegisterEmbeddedScheme(System.Reflection.Assembly assembly, string schemeName = "embedded", string domainName = null)
		{
			if (string.IsNullOrEmpty(schemeName))
			{
				throw new ArgumentNullException("schemeName", "必须为scheme指定名称。");
			}

			var embedded = new EmbeddedSchemeHandlerFactory(schemeName, assembly);
			var gchandle = GCHandle.Alloc(embedded);

			ChromiumStartupSettings.SchemeHandlerGCHandles.Add(gchandle);


			RegisterScheme(embedded.SchemeName, domainName, embedded);
		}



		public static void RegisterScheme(string schemeName, string domain, CfxSchemeHandlerFactory factory)
		{
			if (string.IsNullOrEmpty(schemeName))
			{
				throw new ArgumentNullException("schemeName", "必须为scheme指定名称。");
			}



			CfxRuntime.RegisterSchemeHandlerFactory(schemeName, domain, factory);
		}
	}
}
