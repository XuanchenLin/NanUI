using Chromium;
using Chromium.Event;
using Chromium.WebBrowser;
using Chromium.WebBrowser.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chromium.Remote;
using System.Runtime.InteropServices;

namespace NetDimension.NanUI
{
	public enum PlatformArch
	{
		Auto,
		x86,
		x64
	}

	public class Bootstrap
	{
		private static bool isCefInitialized = false;

		private static Action<OnBeforeCfxInitializeEventArgs> beforeCefInitializeAction = null;
		private static Action<CfxOnBeforeCommandLineProcessingEventArgs> beforeCefCommandLineProcessingAction;
		private static List<GCHandle> SchemeHandlerGCHandles = new List<GCHandle>();


		public static readonly PlatformArch PlatformArchitecture = CfxRuntime.PlatformArch == CfxPlatformArch.x64 ? PlatformArch.x64 : PlatformArch.x86;


		private static void CheckIfCefHasBeenInitialized()
		{
			if (isCefInitialized)
			{
				throw new CefException("You can not change settings after CEF runtime initialized.");
			}
		}


		public static Action<OnBeforeCfxInitializeEventArgs> BeforeCefInitialize
		{
			private get => beforeCefInitializeAction;
			set
			{

				CheckIfCefHasBeenInitialized();

				beforeCefInitializeAction = value;
			}
		}

		public static Action<CfxOnBeforeCommandLineProcessingEventArgs> BeforeCefCommandLineProcessing
		{
			private get => beforeCefCommandLineProcessingAction;
			set
			{
				CheckIfCefHasBeenInitialized();
				beforeCefCommandLineProcessingAction = value;
			}
		}

		private static string appDataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Net Dimension Studio\NanUI\", Application.ProductName);

		public static string ApplicationDataDirectory
		{
			get => appDataDir;
			set => appDataDir = value;
		}

		private static string appCacheDir;
		public static string ApplicationCacheDirectory
		{
			get => appCacheDir;
		}

		public static bool Load(PlatformArch arch = PlatformArch.Auto, string libCefPath = null, string resourcesPath = null, string localesPath = null, string cachePath = null)
		{

			

			var subprocessPath = Application.StartupPath;

			if (string.IsNullOrEmpty(libCefPath))
			{
				libCefPath = Application.StartupPath;
			}

			if (string.IsNullOrEmpty(resourcesPath))
			{
				resourcesPath = libCefPath;
			}

			if (string.IsNullOrEmpty(localesPath))
			{
				localesPath = System.IO.Path.Combine(libCefPath, "locales");
			}



			if (arch == PlatformArch.Auto)
			{
				if (PlatformArchitecture == PlatformArch.x86)
				{
					libCefPath = System.IO.Path.Combine(libCefPath, "x86");
				}
				else
				{
					libCefPath = System.IO.Path.Combine(libCefPath, "x64");
				}
			}

			CfxRuntime.LibCefDirPath = libCefPath;


			if (string.IsNullOrEmpty(cachePath))
			{
				cachePath = System.IO.Path.Combine(appDataDir, "Cache");
			}

			appCacheDir = cachePath;

			var libCfxName = "libcfx.dll";
			if (PlatformArchitecture == PlatformArch.x64)
				libCfxName = "libcfx64.dll";


			var cfxLibPath = System.IO.Path.Combine(libCefPath, libCfxName);

			BrowserCore.OnBeforeCfxInitialize += (args) =>
			{
				if (!System.IO.Directory.Exists(cachePath))
				{
					System.IO.Directory.CreateDirectory(cachePath);
				}

				args.Settings.CachePath = cachePath;

				args.Settings.LocalesDirPath = localesPath;

				args.Settings.ResourcesDirPath = resourcesPath;

				args.Settings.LogSeverity = CfxLogSeverity.Disable;

				args.Settings.LogFile = System.IO.Path.Combine(args.Settings.CachePath, "debug.log");

				args.Settings.Locale = "zh-CN;en-US";

				BeforeCefInitialize?.Invoke(args);

			};

			BrowserCore.OnBeforeCommandLineProcessing += (args) =>
			{
				BeforeCefCommandLineProcessing?.Invoke(args);
			};

			try
			{
				Application.ApplicationExit += OnApplicationExit;
				BrowserCore.Initialize();
				BrowserCore.RemoteProcessCreated += OnRemoteProcessCreated;
				isCefInitialized = true;
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.InnerException == null ? ex : ex.InnerException);
			}

			return false;
		}

		private static void OnRemoteProcessCreated(RemoteProcessCreatedEventArgs e)
		{
			e.RenderProcessHandler.OnContextCreated += RenderProcessHandler_OnContextCreated;
		}

		private static void RenderProcessHandler_OnContextCreated(object sender, Chromium.Remote.Event.CfrOnContextCreatedEventArgs e)
		{
			var obj = e.Context.Global;
			obj.SetValue("__nanui_version__", CfrV8Value.CreateString(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()), CfxV8PropertyAttribute.ReadOnly);
		}
		
		private static void OnApplicationExit(object sender, EventArgs e)
		{
			foreach (var handle in SchemeHandlerGCHandles)
			{
				handle.Free();
			}
			CfxRuntime.Shutdown();
		}


		public static void RegisterAssemblyResources(System.Reflection.Assembly assembly, string domainName = "res.app.local")
		{
			var factory = new CfxSchemeHandlerFactory();
			var gchandle = GCHandle.Alloc(factory);

			factory.Create += (_, args) =>
			{
				if (args.SchemeName == "http" && args.Browser != null)
				{
					var wb = BrowserCore.GetBrowser(args.Browser.Identifier);
					var handler = new ResourceHandler.AssemblyResourceHandler(assembly, wb, domainName);
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
			var result = CfxRuntime.RegisterSchemeHandlerFactory(schemeName, doamin, factory);
		}

	}
}
