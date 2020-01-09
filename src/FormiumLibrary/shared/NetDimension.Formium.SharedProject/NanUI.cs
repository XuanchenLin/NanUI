using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetDimension.Formium
{
    using Chromium;
    using ColoredConsole;
    using NetDimension.Formium.Browser;
    using NetDimension.Formium.ResourceHandler;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public enum PlatformArchitecture
    {
        x86,
        x64
    }

    public class NanUI
    {
        public const string CEF_VERSION = "77.1.18.0";

        public static NanUI CurrentContext { get; private set; } = null;





        private static CfxBrowserSettings defaultBrowserSettings;
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



        private static string libCefDir = string.Empty;
        private static string resourceDir = string.Empty;
        private static string subprocessDir = string.Empty;


        const string RES_DIR_NAME = "Resources";
        const string LOCALES_DIR_NAME = "locales";
        const string DEFAULT_CEF_DIR_NAME = "fx";
        const string UP_LEVEL_DIR = "..";

        private static readonly string ApplicationRunningDirectroy = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).LocalPath);
        private static string appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Net Dimension Studio\NanUI\", Application.ProductName);

        public static string ApplicationDataDirectory
        {
            get => appDataDir;
            internal set
            {
                if (!Directory.Exists(value))
                {
                    throw new System.IO.DirectoryNotFoundException("Data directory is not existed.");
                }

                appDataDir = value;
            }
        }

        public static string CacheDirectory
        {
            get => Path.Combine(ApplicationDataDirectory, "Cache");
        }

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

        private static bool IsLibCefLibraryExists(string dir)
        {
            return File.Exists(Path.Combine(dir, "libcef.dll"));
        }

        private static bool IsLibCefResourceDir(string dir)
        {
            return Directory.Exists(dir) && Directory.GetFiles(dir, "*.pak", SearchOption.TopDirectoryOnly).Length > 0 && Directory.Exists(Path.Combine(dir, "locales"));
        }

        public static string SubprocessPath
        {
            get
            {
                var subprocessFileName = $"Formium.BrowserSubprocess.{PlatformArchitecture}.exe";
                if (string.IsNullOrEmpty(subprocessDir))
                {

                    var searchPlaces = new List<string>();
                    searchPlaces.Add(Path.Combine(ApplicationRunningDirectroy, subprocessFileName));

                    if (!string.IsNullOrEmpty(libCefDir))
                    {
                        searchPlaces.Add(Path.Combine(libCefDir, subprocessFileName));
                    }

                    foreach (var filePath in searchPlaces)
                    {
                        if (File.Exists(filePath))
                        {
                            subprocessDir = filePath;
                            break;
                        }
                    }
                }

                return subprocessDir;
            }
        }

        public static string LibCefDirPath
        {
            get
            {
                if (string.IsNullOrEmpty(libCefDir))
                {

                    string[] searchPaths = new string[] {
                        // current directory - [APP_DIR]\
                        ApplicationRunningDirectroy,
                        // architecture name in current directory - [APP_DIR]\[ARCHITECTURE_NAME]\
                        Path.Combine(ApplicationRunningDirectroy, PlatformArchitecture.ToString()),
                        // full directroy structure of LibCef in current directroy - [APP_DIR]\cef\[ARCHITECTURE_NAME]\
                        Path.Combine(ApplicationRunningDirectroy, DEFAULT_CEF_DIR_NAME, PlatformArchitecture.ToString())
                    };

                    foreach (var path in searchPaths)
                    {
                        if (IsLibCefLibraryExists(path))
                        {
                            libCefDir = path;
                        }
                    }
                }



                return libCefDir;
            }
        }

        public static string ResourceDirPath
        {
            get
            {
                if (string.IsNullOrEmpty(resourceDir) && !string.IsNullOrEmpty(libCefDir))
                {

                    string[] searchPaths = new string[] {
                            // current directroy
                            libCefDir,
                            // if libcef in a architecture folder, search the up directroy
                             Path.Combine(libCefDir, UP_LEVEL_DIR),
                            // if libcef in a architecture folder, search the Resources folder in up directroy
                            Path.Combine(libCefDir, UP_LEVEL_DIR, RES_DIR_NAME),
                            // the Resources folder in current directory
                            Path.Combine(libCefDir, RES_DIR_NAME)
                        };

                    foreach (var path in searchPaths)
                    {
                        if (IsLibCefResourceDir(path))
                        {
                            resourceDir = Path.GetFullPath(path);
                        }
                    }

                }

                return resourceDir;
            }
        }

        static NanUI()
        {
            //Console.Title = "NanUI Console";

        }

        internal static List<Action> RegisterChromiumExtensionActions = new List<Action>();

        internal List<Action<string, CfxCommandLine>> CommandLineBuildActions = new List<Action<string, CfxCommandLine>>();

        internal List<Action<CfxSettings>> SettingBuildActions = new List<Action<CfxSettings>>();

        private List<Func<NanUI, bool>> beforeApplicationRunActions = new List<Func<NanUI, bool>>();

        private static List<Func<CustomResource>> resourceHandlers = new List<Func<CustomResource>>();

        private Action<LibCefNotFoundArgs> LibCefNotFoundHandler = null;


        private bool useDefaultBrowserSubprocess = false;



        public static void RegisterCustomResourceHandler(Func<CustomResource> resourceHandler)
        {
            if (CfxRuntime.LibrariesLoaded)
            {
                var handler = resourceHandler?.Invoke();
                if (handler != null)
                {
                    if (!CfxRuntime.RegisterSchemeHandlerFactory(handler.SchemeName, handler.DomainName, handler.SchemeHandlerFactory))
                    {
                        throw new WebBrowserException("SchemeHandlerFactory is fail to be registered.");
                    }
                }

            }
            else
            {
                resourceHandlers.Add(resourceHandler);
            }
        }


        public static NanUI Initialize()
        {
            if (CurrentContext == null)
            {
                CurrentContext = new NanUI();
            }
            else
            {
                //TODO: log error
            }

            return CurrentContext;
        }

        private NanUI()
        {
            CommandLineArgs = Environment.GetCommandLineArgs();

        }

        /// <summary>
        /// Specific a custom path of libcef binary files
        /// </summary>
        /// <param name="libCefDirPath"></param>
        /// <returns></returns>
        public NanUI WithCustomLibCefDirPath(string libCefDirPath)
        {
            if (IsLibCefLibraryExists(libCefDirPath))
            {
                var hasResourceDir = false;

                string[] searchPaths = new string[] {
                            libCefDirPath,
                            Path.Combine(libCefDirPath, UP_LEVEL_DIR),
                            Path.Combine(libCefDirPath, UP_LEVEL_DIR, RES_DIR_NAME),
                            Path.Combine(libCefDirPath, RES_DIR_NAME)
                        };
                foreach (var path in searchPaths)
                {
                    if (IsLibCefResourceDir(path))
                    {
                        hasResourceDir = true;

                        resourceDir = path;
                        break;
                    }
                }

                if (!hasResourceDir)
                {
                    throw new DirectoryNotFoundException($"The resources directroy does not exist at specific location。");
                }

                libCefDir = libCefDirPath;
            }
            else
            {
                throw new DllNotFoundException($"libcef.dll and resource files are not found in path: {libCefDirPath}");
            }




            return this;
        }

        public NanUI WithApplicationDataDirectroty(string dataDir)
        {
            appDataDir = dataDir;

            return this;
        }

        public NanUI WithChromiumCommandLineArguments(Action<string, CfxCommandLine> buildAction)
        {

            if (buildAction != null)
            {
                CommandLineBuildActions.Add(buildAction);
            }
            return this;
        }

        public NanUI WithChromiumSettings(Action<CfxSettings> buildAction)
        {
            if (buildAction != null)
            {
                SettingBuildActions.Add(buildAction);
            }
            return this;
        }

        public NanUI UseDefaultBrowserSubpress()
        {
            useDefaultBrowserSubprocess = true;
            return this;
        }

        private bool isHighDpiSupportEnabled = false;
        public NanUI WithHighDpiSupported()
        {
            isHighDpiSupportEnabled = true;
            return this;
        }

        internal static bool IsDebugModeEnabled { get; private set; } = false;

        public NanUI WithDebugModeEnabled()
        {
            IsDebugModeEnabled = true;
            return this;
        }

        public static string[] CommandLineArgs;

        public static int ExecuteProcess()
        {

            if (CommandLineArgs == null)
                CommandLineArgs = Environment.GetCommandLineArgs();
            var processType = CommandLineArgs.FirstOrDefault(x => x.StartsWith("--type="));

            if (processType == null)
            {
                return -1;
            }

            var processName = $"{processType.Replace("--type=", "")}-{PlatformArchitecture}";

            Log("[NanUI.BrowserSubprocess(".Green(), $"{processName}".Cyan(), ")]".Green(), " is processing...".Gray());

            if (IsDebugModeEnabled)
            {
                Log("Command Line Arguments ->".Gray());
                Text(string.Join(" ", CommandLineArgs));
            }

            int retval = CfxRuntime.ExecuteProcess();

            Log("[NanUI.BrowserSubprocess(".Green(), $"{processName}".Cyan(), ")]".Green(), $" has been terminated with exit code {retval}...".Gray());

            return retval;
        }

        private void RunChromiumMainProcess()
        {
            Announce();

            Log("libcfx_path".Yellow(), ":\t".Gray(), CfxRuntime.LibCfxDirPath.White());
            Log("libcef_path".Yellow(), ":\t".Gray(), LibCefDirPath.White());
            Log("resources_path".Yellow(), ":\t".Gray(), ResourceDirPath.White());
            Log("locales_path".Yellow(), ":\t".Gray(), Path.Combine(ResourceDirPath, LOCALES_DIR_NAME).White());

            var app = new NanUIApp(this);

            var settings = new CfxSettings();

            settings.JavascriptFlags = "--expose-gc";
            settings.Locale = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
            settings.AcceptLanguageList = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
            settings.CachePath = CacheDirectory;
            settings.LogFile = Path.Combine(CacheDirectory, "logs", "cef.log");
            settings.LogSeverity = CfxLogSeverity.Disable;

            foreach (var settingAction in SettingBuildActions)
            {
                settingAction?.Invoke(settings);
            }

            settings.ResourcesDirPath = ResourceDirPath;
            settings.LocalesDirPath = Path.Combine(ResourceDirPath, LOCALES_DIR_NAME);
            settings.MultiThreadedMessageLoop = true;
            settings.NoSandbox = true;
            Log(settings.UserAgent);

            if (useDefaultBrowserSubprocess && !string.IsNullOrEmpty(SubprocessPath))
            {
                settings.BrowserSubprocessPath = SubprocessPath;
            }

            if (isHighDpiSupportEnabled)
            {
                CfxRuntime.EnableHighDpiSupport();
            }


            Log($"[NanUI.MainProcess({PlatformArchitecture})]".Green(), " is processing...".Gray());

            if (!CfxRuntime.Initialize(settings, app, RenderProcess.RenderProcessMain))
                throw new WebBrowserException("Failed to initialize CEF library.");
        }

        internal void LoadCef()
        {


            if (string.IsNullOrEmpty(LibCefDirPath) || string.IsNullOrEmpty(ResourceDirPath))
            {
                var isLibCefDetected = false;


                if (LibCefNotFoundHandler != null)
                {
                    libCefDir = string.Empty;
                    resourceDir = string.Empty;

                    var args = new LibCefNotFoundArgs(PlatformArchitecture, ApplicationRunningDirectroy, ApplicationDataDirectory);
                    LibCefNotFoundHandler.Invoke(args);



                    if (!string.IsNullOrEmpty(args.libCefDir))
                    {
                        WithCustomLibCefDirPath(args.libCefDir);

                        isLibCefDetected = true;
                    }

                }

                if (!isLibCefDetected)
                {
                    libCefDir = string.Empty;
                    resourceDir = string.Empty;

                    throw new DllNotFoundException($"libcef.dll and resource files are not found. Please make sure Cef support files are in the correct place.");
                }

            }

            CfxRuntime.LibCefDirPath = LibCefDirPath;

            var retval = ExecuteProcess();

            if (retval >= 0)
            {
                Environment.Exit(retval);
                return;
            }

            RunChromiumMainProcess();
        }

        public NanUI WhenLibCefNotFound(Action<LibCefNotFoundArgs> action)
        {
            LibCefNotFoundHandler = action;


            return this;
        }

        public NanUI BeforeApplicaitonRun(Func<NanUI, bool> beforeRun)
        {
            beforeApplicationRunActions.Add(beforeRun);
            return this;
        }

        public NanUI RegisterChromiumExtension(Action register)
        {
            RegisterChromiumExtensionActions.Add(register);
            return this;
        }

        private void RunMainProcess(Form mainForm = null)
        {
            var appShouldRun = true;

            foreach (var action in beforeApplicationRunActions)
            {
                var result = action?.Invoke(this);

                if (result == false) appShouldRun = false;
            }

            if (!appShouldRun)
            {
                return;
            }

            foreach (var resourceHandler in resourceHandlers)
            {
                var handler = resourceHandler?.Invoke();
                if (handler != null)
                {
                    if (!CfxRuntime.RegisterSchemeHandlerFactory(handler.SchemeName, handler.DomainName, handler.SchemeHandlerFactory))
                    {
                        throw new WebBrowserException("SchemeHandlerFactory is fail to be registered.");
                    }
                }
            }



            if (mainForm != null)
            {
                Application.Run(mainForm);
            }
            else
            {
                Application.Run();
            }

        }

        public void Run()
        {
            try
            {
                LoadCef();

                RunMainProcess();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CustomResource.FreeGCHandles();
                CfxRuntime.Shutdown();

                ColorConsole.WriteLine("[NanUI.MainProcess]".Green(), " has been terminated.".Gray());



            }
        }

        public void Run(Func<HostWindow> runAction)
        {
            try
            {
                LoadCef();

                var runResult = runAction?.Invoke();

                var mainForm = runResult?.ContainerForm;

                RunMainProcess(mainForm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CustomResource.FreeGCHandles();
                CfxRuntime.Shutdown();

                ColorConsole.WriteLine("[NanUI.MainProcess]".Green(), " has been terminated.".Gray());



            }
        }

        public void Run(Func<Form> runAction)
        {

            try
            {
                LoadCef();

                var mainForm = runAction?.Invoke();

                RunMainProcess(mainForm);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CfxRuntime.Shutdown();
                CustomResource.FreeGCHandles();
            }

        }

        #region Logger

        public static void Announce()
        {
            Log("Welcome to ".Cyan(), " NanUI/0.7 Dev ".White().OnDarkMagenta(),

                $" ({CfxRuntime.PlatformOS} {PlatformArchitecture}; CEF/{CfxRuntime.GetCefVersion()}; Chromium/{CfxRuntime.GetChromeVersion()}; Formium/{Assembly.GetExecutingAssembly().GetName().Version.ToString()})".Gray());

            Log($"Copyright (C) 2016-{DateTime.Now.Year} ".Gray(), " Xuanchen Lin ".Black().OnGray(), " & ".Gray(), " NetDimension Studio ".Black().OnGray(), " all rights reserved under ".Gray(), " The MIT License ".Black().OnGray(), ".".Gray());
            Log();

            Log(Properties.Resources.nanui.White().OnDarkRed());
            Log();
            Log(" * Special thanks to my lovely wife ".Yellow(), "Jina".White(), " for great supports like foods, time, space, BWM, etc. 😂".Yellow());
            Log();

            Log("GITHUB: ".Cyan(), "https://github.com/NetDimension/NanUI/".White());
            Log("EMAIL: ".Cyan(), "\txuanchenlin@msn.com".White());
            Log();



        }

        public static void Text(string text)
        {
            Log(text.DarkGray());
        }

        public static void Log(params ColorToken[] tokens)
        {
            ColorConsole.WriteLine(tokens);
        }
        #endregion



    }

    public class LibCefNotFoundArgs
    {
        internal LibCefNotFoundArgs(PlatformArchitecture architecture, string applicationStartupPath, string dataPath)
        {
            Architecture = architecture;
            ApplicationStartupPath = applicationStartupPath;
            DataPath = dataPath;
        }

        public PlatformArchitecture Architecture { get; }
        public string ApplicationStartupPath { get; }
        public string DataPath { get; }

        internal string libCefDir;

        public string LibCefDir
        {
            set
            {
                libCefDir = value;
            }
        }


    }
}
