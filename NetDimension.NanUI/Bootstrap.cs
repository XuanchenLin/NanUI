using Chromium;
using Chromium.Event;
using Chromium.WebBrowser;
using Chromium.WebBrowser.Event;
using Chromium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI
{


	public static class Bootstrap
	{
		private static string libCefDir = string.Empty;
		private static string resourceDir = string.Empty;
		private static string localesDir = string.Empty;

		private static string appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Net Dimension Studio\NanUI\", Application.ProductName);
		private static string appDir = Application.StartupPath;

		private static bool isCefInitialized = false;

		private static List<GCHandle> ResourceHandlerGCHandles = new List<GCHandle>();
		public static Action<CfxSettings> SettingsBuilder { get; private set; }


		public static Action<CfxCommandLine> CommandLineHandler { get; private set; }

		public static string ApplicationDataDirectory
		{
			get => appDataDir;
			set => appDataDir = value;
		}

		public static string ApplicationCacheDirectory
		{
			get => Path.Combine(ApplicationDataDirectory, "Cache");
		}

		private static void CheckIfCefHasBeenInitialized()
		{
			if (isCefInitialized)
			{
				throw new CefException("You can not change settings after CEF runtime initialized.");
			}
		}

		public static void RegisterFolderResources(string path, string domainName = "assets.app.local")
		{
			var factory = new CfxSchemeHandlerFactory();


			factory.Create += (_, args) =>
			{
				if (args.SchemeName == "http" && args.Browser != null)
				{
					var wb = BrowserCore.GetBrowser(args.Browser.Identifier);
					var handler = new SchemeHandler.FolderResourceHandler(path, wb, domainName);
					args.SetReturnValue(handler);
				}
			};

			RegisterCustomScheme("http", domainName, factory);

		}

		public static void RegisterAssemblyResources(System.Reflection.Assembly assembly, string baseDir = null, string domainName = "res.app.local")
		{
			var factory = new CfxSchemeHandlerFactory();



			factory.Create += (_, args) =>
			{
				if (args.SchemeName == "http" && args.Browser != null)
				{
					var wb = BrowserCore.GetBrowser(args.Browser.Identifier);
					var handler = new AssemblyResourceHandler(assembly, wb, domainName, baseDir);
					args.SetReturnValue(handler);
				}
			};
			RegisterCustomScheme("http", domainName, factory);
		}

		public static void RegisterCustomScheme(string schemeName, string doamin, CfxSchemeHandlerFactory factory)
		{
			if (string.IsNullOrEmpty(schemeName))
			{
				throw new ArgumentNullException("schemeName", "必须为scheme指定名称。");
			}

			var gchandle = GCHandle.Alloc(factory);

			ResourceHandlerGCHandles.Add(gchandle);

			var result = CfxRuntime.RegisterSchemeHandlerFactory(schemeName, doamin, factory);

		}




		public static CfxPlatformArch PlatformArchitecture
		{
			get
			{
				return CfxRuntime.PlatformArch;
			}
		}


		public static string LibCefDir
		{
			get
			{

				if (string.IsNullOrEmpty(libCefDir))
				{
					libCefDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

					if (!File.Exists(Path.Combine(libCefDir, "libcef.dll")))
					{
						libCefDir = Path.Combine(libCefDir, "fx");

						if (PlatformArchitecture == CfxPlatformArch.x64)
						{
							libCefDir = Path.Combine(libCefDir, "x64");
						}
						else
						{
							libCefDir = Path.Combine(libCefDir, "x86");
						}

						if (!File.Exists(Path.Combine(libCefDir, "libcef.dll")))
						{
							throw new DllNotFoundException("libcef.dll is not found.");
						}
					}
				}


				return libCefDir;
			}

			internal set
			{

				if (File.Exists(Path.Combine(value, "libcef.dll")))
				{
					libCefDir = value;
				}
				else
				{
					throw new DllNotFoundException("libcef.dll is not found.");
				}
			}
		}
		public static string ResourcesDir
		{
			get
			{
				if (string.IsNullOrEmpty(resourceDir))
				{
					resourceDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

					if (!Directory.Exists(resourceDir) || Directory.GetFiles(resourceDir, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
					{
						resourceDir = Path.Combine(resourceDir, "fx");

						if (!Directory.Exists(resourceDir) || Directory.GetFiles(resourceDir, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
						{
							resourceDir = Path.Combine(resourceDir, "Resources");

							if (!Directory.Exists(resourceDir) || Directory.GetFiles(resourceDir, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
							{
								throw new FileNotFoundException("Can't find the resources automatically.");
							}
						}

					}
				}


				return resourceDir;
			}
			internal set
			{
				if (!Directory.Exists(value) || Directory.GetFiles(value, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
				{
					throw new FileNotFoundException("The specified directory did not exists or no resources can be found in it.");
				}

				resourceDir = value;
			}
		}
		public static string LocalesDir
		{
			get
			{
				if (string.IsNullOrEmpty(localesDir))
				{
					var appPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
					localesDir = Path.Combine(appPath, "locales");

					if (!Directory.Exists(localesDir) || Directory.GetFiles(localesDir, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
					{
						localesDir = Path.Combine(appPath, "fx\\locales");

						if (!Directory.Exists(localesDir) || Directory.GetFiles(localesDir, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
						{
							localesDir = Path.Combine(appPath, "fx\\Resources\\locales");

							if (!Directory.Exists(localesDir) || Directory.GetFiles(localesDir, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
							{
								throw new FileNotFoundException("Can't find the locales directory automatically.");
							}
						}
					}
				}


				return localesDir;
			}
			internal set
			{
				if (!Directory.Exists(value) || Directory.GetFiles(value, "*.pak", SearchOption.TopDirectoryOnly).Length == 0)
				{
					throw new FileNotFoundException("The specified directory did not exists or no locale files can be found in it.");
				}

				localesDir = value;
			}
		}




		public static bool Load(Action<CfxSettings> settingsBuildAction = null, Action<CfxCommandLine> commandLineBuildAction = null)
		{
			
			
			SettingsBuilder = settingsBuildAction;
			CommandLineHandler = commandLineBuildAction;
			CfxRuntime.LibCefDirPath = LibCefDir;


			BrowserCore.OnBeforeCfxInitialize += (args) =>
			{

				CheckIfCefHasBeenInitialized();


				if (!Directory.Exists(ApplicationCacheDirectory))
				{
					Directory.CreateDirectory(ApplicationCacheDirectory);
				}

				//This should be enabled on next NanUI version. On 2987, it will cause some issues.
				CfxRuntime.EnableHighDpiSupport();
				args.Settings.JavascriptFlags = "--expose-gc";

				args.Settings.Locale = Thread.CurrentThread.CurrentCulture.ToString();
				args.Settings.AcceptLanguageList = Thread.CurrentThread.CurrentCulture.ToString();

				args.Settings.CachePath = ApplicationCacheDirectory;

				args.Settings.LogFile = Path.Combine(ApplicationCacheDirectory, "debug.log");

				SettingsBuilder?.Invoke(args.Settings);



				args.Settings.LocalesDirPath = LocalesDir;
				args.Settings.ResourcesDirPath = ResourcesDir;

				args.Settings.SingleProcess = false;
				args.Settings.MultiThreadedMessageLoop = true;
				args.Settings.NoSandbox = false;

			};

			BrowserCore.OnBeforeCommandLineProcessing += (args) =>
			{
				CheckIfCefHasBeenInitialized();

				//This should be enabled on next NanUI version.
				//args.CommandLine.AppendSwitch("enable-experimental-web-platform-features");


				CommandLineHandler?.Invoke(args.CommandLine);

			};

			Application.ApplicationExit += (app, args) =>
			{

				foreach (var handle in ResourceHandlerGCHandles)
				{
					handle.Free();
				}

				CfxRuntime.Shutdown();
			};

			try
			{

				BrowserCore.Initialize();
				isCefInitialized = true;
				return true;
			}
			catch (Exception ex)
			{
				var exception = ex.InnerException == null ? ex : ex.InnerException;
			}


			return false;

		}

	}
}
