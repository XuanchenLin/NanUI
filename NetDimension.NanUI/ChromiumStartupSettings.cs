using Chromium;
using Chromium.Event;
using NetDimension.NanUI.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public class ChromiumStartupSettings
	{

		public const string CURRENT_CEF_VERSION = "3.2526.1373";
		public static string FrameworkDownloadUrl { get; set; }

		internal static List<GCHandle> SchemeHandlerGCHandles = new List<GCHandle>();


		internal static string FrameworkDir = null;
		internal static string LocalesDir = null;
		internal static string ResourcesDir = null;
		internal static readonly string ApplicationDataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Net Dimension Studio\NanUI\");
		internal static readonly string CommonRuntimeDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Net Dimension Studio\NanUI\");

		internal static readonly RuntimeArch PlatformArch = CfxRuntime.PlatformArch == CfxPlatformArch.x64 ? RuntimeArch.x64 : RuntimeArch.x86;
		internal static bool EnableFlashSupport { get; set; }

        public ChromiumStartupSettings()
        {
            FrameworkDownloadUrl = null;
            EnableFlashSupport = false;
        }
		public static bool PrepareRuntime()
		{

			if (!System.IO.Directory.Exists(CommonRuntimeDir))
			{
				System.IO.Directory.CreateDirectory(CommonRuntimeDir);
			}

			if (IsLocalRuntimeExisits() == false)
			{
				if (IsRuntimeExists() == false)
				{
					var downloadForm = new RuntimeDownloadForm(CommonRuntimeDir, CURRENT_CEF_VERSION, FrameworkDownloadUrl, PlatformArch, EnableFlashSupport);

					if (downloadForm.ShowDialog() != DialogResult.OK || !IsRuntimeExists())
					{
						return false;
					}

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

			return true;
		}




		private static bool IsLocalRuntimeExisits()
		{
			var localRuntimeDir = Application.StartupPath;

			var libCfxName = "libcfx.dll";

			if (PlatformArch == RuntimeArch.x64)
				libCfxName = "libcfx64.dll";



			if (PlatformArch == RuntimeArch.x64)
				FrameworkDir = System.IO.Path.Combine(localRuntimeDir, System.IO.Path.Combine(@"fx\", @"x64"));
			else
				FrameworkDir = System.IO.Path.Combine(localRuntimeDir, System.IO.Path.Combine(@"fx\", @"x86"));

			LocalesDir = System.IO.Path.Combine(localRuntimeDir, System.IO.Path.Combine(@"fx\", @"Resources\locales"));
			ResourcesDir = System.IO.Path.Combine(localRuntimeDir, System.IO.Path.Combine(@"fx\", @"Resources"));

			var cfxDllFile = System.IO.Path.Combine(FrameworkDir, libCfxName);

			var environmentDetectResults = new Dictionary<string, bool>()
			{
				{"en-US.pak", System.IO.File.Exists(System.IO.Path.Combine(LocalesDir, "en-US.pak"))},
				{"zh-CN.pak", System.IO.File.Exists(System.IO.Path.Combine(LocalesDir, "zh-CN.pak"))},
				{"cef.pak", System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "cef.pak"))},
				{"cef_extensions.pak", System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "cef_extensions.pak"))},
				{"devtools_resources.pak", System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "devtools_resources.pak"))},
				{"icudtl.dat", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "icudtl.dat"))},
				{"libcfx", System.IO.File.Exists(cfxDllFile)},
				{"libcef.dll", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "libcef.dll"))},
				{"natives_blob.bin", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "natives_blob.bin"))},
				{"snapshot_blob.bin", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "snapshot_blob.bin"))}
			};

			if (EnableFlashSupport)
			{
				environmentDetectResults["manifest.json"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "PepperFlash\\manifest.json"));
				environmentDetectResults["pepflashplayer.dll"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "PepperFlash\\pepflashplayer.dll"));
			}

			return environmentDetectResults.Count(p => p.Value == true) == environmentDetectResults.Count;

		}



		private static bool IsRuntimeExists()
		{

			var libCfxName = "libcfx.dll";

			if (PlatformArch == RuntimeArch.x64)
				libCfxName = "libcfx64.dll";



			if (PlatformArch == RuntimeArch.x64)
				FrameworkDir = System.IO.Path.Combine(CommonRuntimeDir, System.IO.Path.Combine(@"fx\", System.IO.Path.Combine(CURRENT_CEF_VERSION, @"x64")));
			else
				FrameworkDir = System.IO.Path.Combine(CommonRuntimeDir, System.IO.Path.Combine(@"fx\", System.IO.Path.Combine(CURRENT_CEF_VERSION, @"x86")));

			LocalesDir = System.IO.Path.Combine(CommonRuntimeDir, System.IO.Path.Combine(@"fx\", System.IO.Path.Combine(CURRENT_CEF_VERSION, @"Resources\locales")));
			ResourcesDir = System.IO.Path.Combine(CommonRuntimeDir, System.IO.Path.Combine(@"fx\", System.IO.Path.Combine(CURRENT_CEF_VERSION, @"Resources")));

			var cfxDllFile = System.IO.Path.Combine(FrameworkDir, libCfxName);

			var environmentDetectResults = new Dictionary<string, bool>()
			{
				{"en-US.pak", System.IO.File.Exists(System.IO.Path.Combine(LocalesDir, "en-US.pak"))},
				{"zh-CN.pak", System.IO.File.Exists(System.IO.Path.Combine(LocalesDir, "zh-CN.pak"))},
				{"cef.pak", System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "cef.pak"))},
				{"cef_extensions.pak", System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "cef_extensions.pak"))},
				{"devtools_resources.pak", System.IO.File.Exists(System.IO.Path.Combine(ResourcesDir, "devtools_resources.pak"))},
				{"icudtl.dat", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "icudtl.dat"))},
				{"libcfx", System.IO.File.Exists(cfxDllFile)},
				{"libcef.dll", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "libcef.dll"))},
				{"natives_blob.bin", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "natives_blob.bin"))},
				{"snapshot_blob.bin", System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "snapshot_blob.bin"))}
			};

			if (EnableFlashSupport)
			{
				environmentDetectResults["manifest.json"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "PepperFlash\\manifest.json"));
				environmentDetectResults["pepflashplayer.dll"] = System.IO.File.Exists(System.IO.Path.Combine(FrameworkDir, "PepperFlash\\pepflashplayer.dll"));
			}

			return environmentDetectResults.Count(p => p.Value == true) == environmentDetectResults.Count;

		}
	}
}
