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
	public class HtmlUILauncher
	{


		private static CfxBrowserSettings defaultBrowserSettings;

		/// <summary>
		/// 
		/// </summary>
		public static CfxBrowserSettings DefaultBrowserSettings
		{
			get
			{
				if (defaultBrowserSettings == null)
				{
					defaultBrowserSettings = new CfxBrowserSettings();
				}
				return defaultBrowserSettings;
			}
		}

		public static bool EnableFlashSupport
		{
			get
			{
				return ChromiumStartupSettings.EnableFlashSupport;
			}
			set
			{
				ChromiumStartupSettings.EnableFlashSupport = value;
			}
		}

		internal static event OnBeforeCfxInitializeEventHandler OnBeforeCfxInitialize;
		internal static void RaiseOnBeforeCfxInitialize(CfxSettings settings, CfxBrowserProcessHandler processHandler)
		{
			var handler = OnBeforeCfxInitialize;
			if (handler != null)
			{
				var e = new OnBeforeCfxInitializeEventArgs(settings, processHandler);
				handler(e);
			}
		}


		internal static event OnBeforeCommandLineProcessingEventHandler OnBeforeCommandLineProcessing;
		internal static void RaiseOnBeforeCommandLineProcessing(CfxOnBeforeCommandLineProcessingEventArgs e)
		{
            if(OnBeforeCommandLineProcessing != null)
            {
			    OnBeforeCommandLineProcessing.Invoke(e);
            }
		}

		internal static event OnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes;
		internal static void RaiseOnRegisterCustomSchemes(CfxOnRegisterCustomSchemesEventArgs e)
		{
            if(OnRegisterCustomSchemes != null)
            {
			    OnRegisterCustomSchemes.Invoke(e);
            }
		}

		internal static event RemoteProcessCreatedEventHandler RemoteProcessCreated;
		internal static void RaiseRemoteProcessCreated(CfrRenderProcessHandler renderProcessHandler)
		{
            if(RemoteProcessCreated != null)
            {
			    RemoteProcessCreated.Invoke(new RemoteProcessCreatedEventArgs(renderProcessHandler));
            }
		}

		internal static void Initialize()
		{
			BrowserProcess.Initialize();
		}



		public static void Shutdown()
		{
			CfxRuntime.Shutdown();
		}

		public static CfxBrowserProcessHandler BrowserProcessHandler
		{
			get
			{
				return BrowserProcess.processHandler;
			}
		}

		private static readonly Dictionary<int, IChromiumWebBrowser> browsers = new Dictionary<int, IChromiumWebBrowser>();
		internal static Dictionary<int, IChromiumWebBrowser> CurrentBrowsers
		{
			get
			{
				return browsers;
			}
		}

		internal static IChromiumWebBrowser GetBrowser(int id)
		{
			IChromiumWebBrowser wb;
			CurrentBrowsers.TryGetValue(id, out wb);
			return wb;
		}





		public static bool InitializeChromium(Action<OnBeforeCfxInitializeEventArgs> BeforeChromiumInitialize, Action<CfxOnBeforeCommandLineProcessingEventArgs> BeforeCommandLineProcessing)
		{

			if (ChromiumStartupSettings.PrepareRuntime())
			{



				OnBeforeCfxInitialize += (args) =>
				{
					var cachePath = System.IO.Path.Combine(ChromiumStartupSettings.ApplicationDataDir, System.IO.Path.Combine(Application.ProductName, "Cache"));
					if (!System.IO.Directory.Exists(cachePath))
						System.IO.Directory.CreateDirectory(cachePath);

					args.Settings.LocalesDirPath = ChromiumStartupSettings.LocalesDir;
					args.Settings.ResourcesDirPath = ChromiumStartupSettings.ResourcesDir;
					args.Settings.Locale = "zh-CN";
					args.Settings.CachePath = cachePath;
					args.Settings.LogSeverity = CfxLogSeverity.Disable;

                    if(BeforeChromiumInitialize != null)
                    {
					    BeforeChromiumInitialize.Invoke(args);
                    }
				};

				OnBeforeCommandLineProcessing += (args) =>
				{
					Console.WriteLine("处理命令行参数。。。");

                    if(BeforeCommandLineProcessing != null)
                    {
					    BeforeCommandLineProcessing.Invoke(args);
                    }



					if (ChromiumStartupSettings.EnableFlashSupport)
					{
						SetFlashSupport(args);
					}

					Console.WriteLine(args.CommandLine.CommandLineString);

				};




				OnRegisterCustomSchemes += args =>
				{
					args.Registrar.AddCustomScheme("embedded", false, false, false);
				};


				try
				{
					Initialize();


					RegisterLocalScheme();
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



		private static void SetFlashSupport(CfxOnBeforeCommandLineProcessingEventArgs args)
		{
			var flashSupportPath = System.IO.Path.Combine(CfxRuntime.LibCefDirPath, "PepperFlash");
			var manifestPath = System.IO.Path.Combine(flashSupportPath, "manifest.json");
			var libPath = System.IO.Path.Combine(flashSupportPath, "pepflashplayer.dll");
			if (!System.IO.File.Exists(manifestPath) || !System.IO.File.Exists(libPath))
			{
				return;
			}

			var match = System.Text.RegularExpressions.Regex.Match(System.IO.File.ReadAllText(manifestPath), @"""version"":.""(?<version>.+?)""");
			if (match.Success)
			{
				var version = match.Groups["version"].Value;

				args.CommandLine.AppendSwitchWithValue("ppapi-flash-version", version);
				args.CommandLine.AppendSwitchWithValue("ppapi-flash-path", libPath);

			}


		}

		private static void RegisterLocalScheme()
		{
			var scheme = new LocalSchemeHandlerFactory();
			var gchandle = GCHandle.Alloc(scheme);
			ChromiumStartupSettings.SchemeHandlerGCHandles.Add(gchandle);

			RegisterScheme("local", null, scheme);
		}




		public static void RegisterEmbeddedScheme(System.Reflection.Assembly assembly, string schemeName, string domainName)
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
