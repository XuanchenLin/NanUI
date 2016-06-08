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
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{



	public class HtmlUILauncher
	{
		private static List<GCHandle> SchemeHandlerGCHandles = new List<GCHandle>();
		
		public static string FrameworkDownloadUrl { get; set; } = null;

		public static bool EnableFlashSupport { get; set; } = false;

		private static string FrameworkDir = null;
		private static string LocalesDir = null;
		private static string ResourcesDir = null;
		private static readonly string RuntimeDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Net Dimension Studio\NanUI\");

		private static readonly RuntimeArch PlatformArch = CfxRuntime.PlatformArch == CfxPlatformArch.x64 ? RuntimeArch.x64 : RuntimeArch.x86;

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
			var handler = OnBeforeCommandLineProcessing;
			if (handler != null)
			{
				handler(e);
			}
		}

		internal static event OnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes;
		internal static void RaiseOnRegisterCustomSchemes(CfxOnRegisterCustomSchemesEventArgs e)
		{
			var handler = OnRegisterCustomSchemes;
			if (handler != null)
			{
				handler(e);
			}
		}

		internal static event RemoteProcessCreatedEventHandler RemoteProcessCreated;
		internal static void RaiseRemoteProcessCreated(CfrRenderProcessHandler renderProcessHandler)
		{
			var ev = RemoteProcessCreated;
			if (ev != null)
			{
				ev(new RemoteProcessCreatedEventArgs(renderProcessHandler));
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





		private static bool IsRuntimeExists()
		{

			var libCfxName = "libcfx.dll";

			if (PlatformArch == RuntimeArch.x64)
				libCfxName = "libcfx64.dll";



			if (PlatformArch == RuntimeArch.x64)
				FrameworkDir = System.IO.Path.Combine(RuntimeDir, @"fx\x64");
			else
				FrameworkDir = System.IO.Path.Combine(RuntimeDir, @"fx\x86");

			LocalesDir = System.IO.Path.Combine(RuntimeDir, @"fx\Resources\locales");
			ResourcesDir = System.IO.Path.Combine(RuntimeDir, @"fx\Resources");

			var cfxDllFile = System.IO.Path.Combine(FrameworkDir, libCfxName);

			var environmentDetectResults = new Dictionary<string, bool>()
			{
				["en-US.pak"] = System.IO.File.Exists(System.IO.Path.Combine(LocalesDir, "en-US.pak")),
				["zh-CN.pak"] = System.IO.File.Exists(System.IO.Path.Combine(LocalesDir, "zh-CN.pak")),
				["cef.pak"] = System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "cef.pak")),
				["cef_extensions.pak"] = System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "cef_extensions.pak")),
				["devtools_resources.pak"] = System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "devtools_resources.pak")),
				["icudtl.dat"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "icudtl.dat")),
				["libcfx"] = System.IO.File.Exists(cfxDllFile),
				["libcef.dll"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "libcef.dll")),
				["natives_blob.bin"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "natives_blob.bin")),
				["snapshot_blob.bin"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "snapshot_blob.bin"))
			};

			return environmentDetectResults.Count(p => p.Value == true) == environmentDetectResults.Count;

		}


		public static bool InitializeChromium(Action<OnBeforeCfxInitializeEventArgs> BeforeChromiumInitialize = null, Action<CfxOnBeforeCommandLineProcessingEventArgs> BeforeCommandLineProcessing = null)
		{


			if (!System.IO.Directory.Exists(RuntimeDir))
			{
				System.IO.Directory.CreateDirectory(RuntimeDir);
			}

			if (IsRuntimeExists() == false)
			{
				var downloadForm = new RuntimeDownloadForm(RuntimeDir, FrameworkDownloadUrl, PlatformArch, EnableFlashSupport);

				if (downloadForm.ShowDialog() != DialogResult.OK || !IsRuntimeExists())
				{
					return false;
				}

			}

			CfxRuntime.LibCefDirPath = FrameworkDir;

			Application.ApplicationExit += (sender, args) =>
			{
				foreach (var handle in SchemeHandlerGCHandles)
				{
					handle.Free();
				}

				CfxRuntime.Shutdown();
			};


			OnBeforeCfxInitialize += (args) =>
			{
				var cachePath = System.IO.Path.Combine(RuntimeDir, Application.ProductName, "Cache");
				if (!System.IO.Directory.Exists(cachePath))
					System.IO.Directory.CreateDirectory(cachePath);


				args.Settings.LocalesDirPath = LocalesDir; 
				args.Settings.ResourcesDirPath = ResourcesDir;
				args.Settings.Locale = "zh-CN";
				args.Settings.CachePath = cachePath;
				args.Settings.LogSeverity = CfxLogSeverity.Disable;

				BeforeChromiumInitialize?.Invoke(args);
			};

			OnBeforeCommandLineProcessing += (args) =>
			{
				Console.WriteLine("处理命令行参数。。。");


				BeforeCommandLineProcessing?.Invoke(args);



				if (EnableFlashSupport)
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

				return true;

			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("初始化系统失败。\r\n{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				//TODO:加入下载逻辑
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





		public static void RegisterEmbeddedScheme(System.Reflection.Assembly assembly, string schemeName = "embedded", string domainName = null)
		{
			if (string.IsNullOrEmpty(schemeName))
			{
				throw new ArgumentNullException("schemeName", "必须为scheme指定名称。");
			}

			var embedded = new EmbeddedSchemeHandlerFactory(schemeName, assembly);
			var gchandle = GCHandle.Alloc(embedded);

			SchemeHandlerGCHandles.Add(gchandle);


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
