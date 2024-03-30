// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Diagnostics;

using WinFormium.Properties;
using WinFormium.WebResource;

namespace WinFormium;

public sealed class WinFormiumApp
{
    private const string COMMON_DATA_DIR_NAME = @"WinFormium";

    public static AppBuilder CreateBuilder()
    {
        if (Current != null)
        {
            throw new ApplicationException(Messages.Exception_WinFormiumInitializationFailed);
        };

        return new AppBuilder();
    }
    public static WinFormiumApp? Current { get; private set; }

    public PlatformArchitecture Architecture
    {
        get;
    }

    public CultureInfo CurrentCulture => CultureInfo.GetCultureInfo(Properties.GetValue<string>(nameof(AppBuilder.UseCulture)) ?? Application.CurrentCulture.Name);

    public ProcessType ProcessType { get; }

    internal WinFormiumLogger Logger => Services.GetRequiredService<WinFormiumLogger>();

    public IServiceProvider Services { get; private set; }

    public PropertyManager Properties => Services.GetRequiredService<PropertyManager>();

    internal bool EnableDevTools => Properties.GetValue<bool>(nameof(AppBuilder.UseDevToolsMenu));

    internal string CommonDataDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), COMMON_DATA_DIR_NAME);

    internal string DefaultAppDataDirectory => Path.Combine(CommonDataDirectory, AppName);

    internal string AppDataDirectory { get; private set; }

    public string AppName { get; }

    public int BrowserProcessId { get; }

    private ChromiumEnvironment _env => Services.GetRequiredService<ChromiumEnvironment>();

    private IWinFormiumStartup _startup => Services.GetRequiredService<IWinFormiumStartup>();

    internal WinFormiumApp(ProcessType processType, PlatformArchitecture architecture, IServiceCollection services, string? appName = null)
    {
        if (Current != null)
        {
            // WinFormiumApp 已经初始化，只允许运行一个实例。
            throw new ApplicationException(Messages.Exception_WinFormiumInitializationFailed);
        }

        Current = this;

        ProcessType = processType;
        Architecture = architecture;
        AppName = appName ?? Application.ProductName ?? "WinFormium App";

        AppDataDirectory = DefaultAppDataDirectory;

        DefaultLogger defaultLogger = new DefaultLogger { Log = new WinFormiumLogger(Path.Combine(AppDataDirectory, $"{nameof(WinFormium).ToLower()}.log"), true) };


        services.AddSingleton(provider =>
        {
            return (WinFormiumLogger)Logging.Logger.Instance.Log;
        });

        if (processType == ProcessType.Renderer)
        {
            var args = Environment.GetCommandLineArgs();

            var processIdArg = args.FirstOrDefault(x => x.StartsWith("--host-process-id")) ?? string.Empty;

            BrowserProcessId = int.Parse(Regex.Replace(processIdArg, "--host-process-id=", string.Empty));

            if (BrowserProcessId == 0)
                throw new ApplicationException(Messages.Exception_WinFormiumInitializationFailed);
        }
        else
        {
            BrowserProcessId = Process.GetCurrentProcess().Id;
        }


        Services = services.BuildServiceProvider();
    }

    private CefSettings GetDefaultCefSettings()
    {
        return new CefSettings
        {
            LogSeverity = CefLogSeverity.Error,
            ResourcesDirPath = _env.ResourceFilePath,
            LocalesDirPath = _env.LocaleFilePath,
            Locale = CurrentCulture.ToString(),
            JavaScriptFlags = "--expose-gc",
            UserDataPath = Path.Combine(AppDataDirectory, "User Data"),
            RootCachePath = AppDataDirectory,
            CachePath = _env.UseInMemoryUserData ? string.Empty : Path.Combine(AppDataDirectory, "Cache"),
            LogFile = Path.Combine(AppDataDirectory, $"{nameof(WinFormium).ToLower()}-cef.log"),
            MultiThreadedMessageLoop = true,
            ExternalMessagePump = false,
            NoSandbox = true,
            PersistSessionCookies = true,
            PersistUserPreferences = true,
            WindowlessRenderingEnabled = true,
        };
    }


    private bool Load(CefMainArgs args, CefApp app, [Optional] out int exitCode)
    {
        if (ProcessType == ProcessType.Main)
        {
            var useSingleton = Properties.GetValue<Action<OnApplicationInstanceRunningHandler>>(nameof(AppBuilder.UseSingleApplicationInstanceMode));

            if (useSingleton != null)
            {
                var thisProcess = Process.GetCurrentProcess();

                foreach (var process in Process.GetProcessesByName(thisProcess.ProcessName))
                {
                    if (process.Id != thisProcess.Id && process.HandleCount > 0)
                    {
                        useSingleton?.Invoke(new OnApplicationInstanceRunningHandler(process.Id));

                        Environment.Exit(0);
                        exitCode = 0;
                        return false;
                    }
                }
            }


        }

        if (_env.UserDataPath != null && !Directory.Exists(_env.UserDataPath))
        {
            var userDataDir = _env.UserDataPath;

            try
            {
                Directory.CreateDirectory(userDataDir);

                AppDataDirectory = userDataDir;
            }
            catch
            {
                AppDataDirectory = DefaultAppDataDirectory;
            }
        }

        try
        {
            Application.CurrentCulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentCulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CurrentCulture;

            var shouldClearCache = Properties.GetValue<bool?>(nameof(AppBuilder.ClearCache)) ?? false;

            if (shouldClearCache)
            {
                try
                {
                    if (Directory.Exists(AppDataDirectory))
                    {
                        Directory.Delete(AppDataDirectory,true);
                    }
                }
                catch(IOException)
                {

                }
            }

            CefRuntime.Load(_env.LibCefPath);

            if (!_env.DisableHiDpiSupport)
            {
                CefRuntime.EnableHighDpiSupport();
            }



            exitCode = CefRuntime.ExecuteProcess(args, app, IntPtr.Zero);


            if (exitCode != -1)
            {
                Environment.Exit(exitCode);

                Debug.WriteLine($"ExecuteProcess() expected to return -1 but returned {exitCode}");

                Logger.LogInformation($"ExecuteProcess() expected to return -1 but returned {exitCode}");

                return false;
            }

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith("--type="))
                {

                    exitCode = -2;
                    Environment.Exit(exitCode);

                    Debug.WriteLine($"ExecuteProcess() expected to return -1 but returned {exitCode}");

                    Logger.LogInformation($"ExecuteProcess() expected to return -1 but returned {exitCode}");

                    return false;
                }
            }


            Debug.WriteLine($"ExecuteProcess() returns {exitCode}");

            Logger.LogInformation($"ExecuteProcess() returns {exitCode}");
        }
        catch (CefVersionMismatchException ex)
        {
            var title = Messages.Exception_LibCefLoadFailed_Title;
            var msg = Messages.Exception_LibCefLoadFailed_NotFoundOrArchError;

            Logger.LogError(ex);

            Debug.WriteLine(ex);

            MessageBox.Show($"{msg}", title, MessageBoxButtons.OK, MessageBoxIcon.Error);

            exitCode = -2;

            return false;

        }
        catch (DllNotFoundException ex)
        {
            var title = Messages.Exception_LibCefLoadFailed_Title;
            var msg = Messages.Exception_LibCefLoadFailed_NotFoundOrArchError;

            Debug.WriteLine(ex);

            Logger.LogError(ex);


            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

            exitCode = -2;

            return false;

        }
#if DEBUG
        var buildType = "DEBUG";
#else
        var buildType = "RELEASE";
#endif
        var license = string.Format(Resources.License, DateTime.Now.Year);

        var copyrightInfo = $"""
* Welcome to WinFormium ({buildType}); Chromium Embedded/{CefRuntime.ChromeVersion}; WinFormium/{Assembly.GetExecutingAssembly().GetName().Version}_{Architecture};
Copyrights (C) 2012-{DateTime.Now.Year} Xuanchen Lin all rights reserved. Made in Kunming, China.
{Resources.ASCII}
This project is under MIT License.

https://github.com/XuanchenLin/WinFormium/blob/master/LICENCE

""";

        var info = $"""
{copyrightInfo}
{license}

""";


        Debug.WriteLine($"\n{info}");

        Console.WriteLine(info);



        return true;
    }

    //Resource.EmbeddedFileResourceSchemeHandlerFactory? InternalPagesResourceSchemeHandlerFactory { get; set; }
    //Resource.EmbeddedFileResourceSchemeHandlerFactory? AboutFormResourceSchemeHandlerFactory { get; set; }


    public void Run()
    {
        var args = new CefMainArgs(Environment.GetCommandLineArgs());

        var app = new BrowserApp(this);

        if (Load(args, app, out _))
        {
            var settings = GetDefaultCefSettings();

            _env.ConfigureSettings?.Invoke(settings);

            var subprocessRetval = ConfigureSubprcess(settings);

            if (subprocessRetval == false)
            {
                MessageBox.Show(Messages.WinFormiumApp_Subprocess_NotFound_Text, Messages.WinFormiumApp_Subprocess_NotFound_Title, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Shutdown();

                Environment.Exit(-2);

                return;
            }


            CefRuntime.Initialize(args, settings, app, IntPtr.Zero);

            //_startup.WinFormiumMain(Environment.GetCommandLineArgs());



            var resourceSchemeHandlerFactories = Services.GetServices<ResourceSchemeHandlerFactory>();

            foreach (var factory in resourceSchemeHandlerFactories)
            {
                factory.ResourceSchemeHandlerRegister(Services);

                CefRuntime.RegisterSchemeHandlerFactory(factory.Scheme, factory.DomainName, factory);
            }

            var internalPagesResourceSchemeHandlerFactory = new EmbeddedFileResourceSchemeHandlerFactory(new EmbeddedFileResourceOptions
            {
                Scheme = "formium",
                DomainName = "pages",
                ResourceAssembly = typeof(WinFormiumApp).Assembly,
                OnFallback = (url) => "/index.html",
                EmbeddedResourceDirectoryName = "Resources/WebRoot/InternalPages",
                DefaultNamespace = "WinFormium.Ultimate"
            });

            var aboutFormResourceSchemeHandlerFactory = new EmbeddedFileResourceSchemeHandlerFactory(new EmbeddedFileResourceOptions
            {
                Scheme = "formium",
                DomainName = "about",
                ResourceAssembly = typeof(WinFormiumApp).Assembly,
                OnFallback = (url) => "/index.html",
                EmbeddedResourceDirectoryName = "Resources/WebRoot/AboutForm",
                DefaultNamespace = "WinFormium.Ultimate"
            });

            CefRuntime.RegisterSchemeHandlerFactory(internalPagesResourceSchemeHandlerFactory.Scheme, internalPagesResourceSchemeHandlerFactory.DomainName, internalPagesResourceSchemeHandlerFactory);

            CefRuntime.RegisterSchemeHandlerFactory(aboutFormResourceSchemeHandlerFactory.Scheme, aboutFormResourceSchemeHandlerFactory.DomainName, aboutFormResourceSchemeHandlerFactory);



            //var appContext = new ApplicationContext();
            //var createMainWindowOpts = new MainWindowOptions(appContext);


            try
            {
                var createMainWindowAction = Services.GetRequiredService<MainWindowCreationAction>();
                var mainWindowOptions = Services.GetRequiredService<MainWindowOptions>();

                createMainWindowAction.Invoke(Services);

                createMainWindowAction.Dispose();

                Application.Run(mainWindowOptions.Context);


            }
            finally
            {
                CefRuntime.Shutdown();

            }


        }
    }


    public void RunWithoutContext()
    {
        var args = new CefMainArgs(Environment.GetCommandLineArgs());

        var app = new BrowserApp(this);

        if (Load(args, app, out _))
        {
            var settings = GetDefaultCefSettings();

            _env.ConfigureSettings?.Invoke(settings);

            var subprocessRetval = ConfigureSubprcess(settings);

            if (subprocessRetval == false)
            {
                MessageBox.Show(Messages.WinFormiumApp_Subprocess_NotFound_Text, Messages.WinFormiumApp_Subprocess_NotFound_Title, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Shutdown();

                Environment.Exit(-2);

                return;
            }

            CefRuntime.Initialize(args, settings, app, IntPtr.Zero);
        }
    }

    public void RunAsSubprocess()
    {
        var args = new CefMainArgs(Environment.GetCommandLineArgs());

        var app = new BrowserApp(this);

        if (Load(args, app, out var exitCode))
        {
            Environment.Exit(exitCode);
        }
    }

    private bool ConfigureSubprcess(CefSettings settings)
    {
        if (_env.ConfigureSubprocess != null)
        {
            var options = new SubprocessOptions { Architecture = _env.Architecture };
            _env.ConfigureSubprocess.Invoke(options);

            if (options.SubprocessFilePath != null && File.Exists(options.SubprocessFilePath))
            {
                var fileInfo = new FileInfo(options.SubprocessFilePath);

                settings.BrowserSubprocessPath = fileInfo.FullName;

                return true;
            }
            else
            {
                var retval = options.SubprocessNotExists?.Invoke(_env.Architecture, options.SubprocessFilePath) ?? false;


                return retval;
            }
        }

        return true;
    }

    public static void Shutdown()
    {

        CefRuntime.Shutdown();
    }
}
