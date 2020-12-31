using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI.Logging;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{
    public enum PlatformArchitecture
    {
        x86,
        x64
    }

    public sealed class WinFormium
    {

        private const string CEF_VERSION = "80.1.15";
        private static CefBrowserSettings _defaultBrowserSettings;

        static WinFormium()
        {
            
        }



        /// <summary>
        /// 
        /// </summary>
        public static PlatformArchitecture PlatformArchitecture
        {
            get
            {
                switch (IntPtr.Size)
                {
                    case 4:
                        return PlatformArchitecture.x86;
                    case 8:
                        return PlatformArchitecture.x64;
                    default:
                        throw new NotSupportedException("Unknown platform architecture.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the default application name. Defauts is the product name. This is used for creating application data directory in %APPDATA%\Net Dimension\NanUI\
        /// </summary>
        public static string ApplicationName { get; set; } = Application.ProductName;

        /// <summary>
        /// Gets a value indicating whether the Runtime is initialized.
        /// </summary>
        public static bool IsRuntimeInitilized => Runtime != null && Runtime.IsRuntimeInitialized;

        /// <summary>
        /// Gets the instance of Runtime. If the runtime is not ready, it will return null.
        /// </summary>
        public static Runtime Runtime { get; private set; } = null;
        /// <summary>
        /// Gets the version of Chromium Embedded Framework that is used for NanUI.
        /// </summary>
        public static string PackedCefVersion => CEF_VERSION;

        /// <summary>
        /// Gets the startup directory of running application now.
        /// </summary>
        public static string ApplicationRunningDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);//Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);

        /// <summary>
        /// Gets the common data directoy for NanUI. Usually it's in %APPDATA%\Net Dimension\NanUI\
        /// </summary>
        public static string CommonDataDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Net Dimension Studio\NanUI\");

        /// <summary>
        /// Gets the public CEF runtime direcroy. Usually it's in %PROGRAMDATA%\Net Dimension\NanUI\[CEF_VERSION]\
        /// </summary>
        public static string CommonCefRuntimeDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Net Dimension Studio\NanUI\", CEF_VERSION);

        /// <summary>
        /// Gets the data directory of current application.
        /// </summary>
        public static string DefaultAppDataDirectory => Path.Combine(CommonDataDirectory, ApplicationName);

        /// <summary>
        /// Gets the default browser settings object. You can set default options with this.
        /// </summary>
        public static CefBrowserSettings DefaultBrowserSettings
        {
            get
            {
                if (_defaultBrowserSettings == null)
                {
                    _defaultBrowserSettings = new CefBrowserSettings() {
                        WindowlessFrameRate = 30,
                    };
                }
                return _defaultBrowserSettings;
            }
        }

        /// <summary>
        /// You can disalbe About Menu in System Command Menu here, but you 
        /// must follow the LICENCE of NanUI Project at https://github.com/NetDimension/NanUI/blob/master/LICENCE
        /// </summary>
        internal static bool DisableAboutMenu => false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildChromiumEnvironment"></param>
        /// <param name="buildApplicationConfiguration"></param>
        /// <returns></returns>
        public static RuntimeBuilder CreateRuntimeBuilder(Action<ChromiumEnvironmentBuilder> buildChromiumEnvironment = null, Action<ApplicationConfigurationBuilder> buildApplicationConfiguration = null)
        {
            if (IsRuntimeInitilized)
            {
                throw new InvalidOperationException("Runtime has been initialized already.");
            }

            return new RuntimeBuilder(buildChromiumEnvironment, buildApplicationConfiguration);
        }

        /// <summary>
        /// Gets the default Logger implement.
        /// </summary>
        public static ILogger GetLogger()
        {
            return Runtime?.Container?.GetInstance<ILogger>();
        }


        internal WinFormium(Runtime runtime)
        {
            if(runtime == null)
            {
                throw new ArgumentNullException();
            }

            Runtime = runtime;
        }

        /// <summary>
        /// Run the NanUI application with settings.
        /// </summary>
        public void Run()
        {
            Runtime.Run();
        }

        /// <summary>
        /// Run the NanUI subprocess.
        /// </summary>
        public void RunAsSubprocess()
        {
            Runtime.RunAsSubprocess();
        }


    }
}
