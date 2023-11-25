// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;



public sealed class ChromiumEnvironmentBuiler
{
    //TODO: change this to the latest version
    internal const string CHROMIUM_VERSION = "109.0.5414";
    //internal const string CHROMIUM_VERSION = "110.0.5481";
    //internal const string CHROMIUM_VERSION = "100.0.4896";
    //internal const string CHROMIUM_VERSION = "90.0.4430";



    internal static ChromiumEnvironmentBuiler Create(AppBuilder builder) => new (builder);


    const string RESOURCE_DIR = "Resources";
    const string LOCALES_DIR = "locales";
    const string ANY_CPU_RUNTIME_DIR = "runtimes";
    const string UP_LEVEL_DIR = "..";
    const string DEFAULT_CEF_DIR = "fx";



    public static string CommonCefRuntimeDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"WinFormium\", CHROMIUM_VERSION);

    public static string ApplicationRunningDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    private string? _libCefDir = string.Empty;
    private string? _resourceDir;
    private string? _userDataDir;

    private Action<CefCommandLine>? _configureCommandLine;
    private Action<CefSettings>? _configureSettings;
    private Action<CefBrowserSettings>? _configureBrowserSettings;
    private Action<CustomCefDistributionPathOption>? _useCustomCefDistributionPath;
    private Action<CustomCefDistributionPathOption>? _useDistributionNotFoundHandler;
    private Action<CefSchemeRegistrar>? _configureCustomSchemes;
    private Action<SubprocessOptions>? _configureSubprocess;

    private bool disableHiDpiSupport = false;

    private bool useInMemoryUserData = false;

    internal AppBuilder Builder { get; }

    private ChromiumEnvironmentBuiler(AppBuilder builder)
    {
        Builder = builder;
    }

    public ChromiumEnvironmentBuiler DisableHiDpiSupport()
    {
        disableHiDpiSupport = true;
        return this;
    }

    public ChromiumEnvironmentBuiler ConfigureSubprocess(Action<SubprocessOptions> configureDelegate)
    {
        _configureSubprocess = configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;

    }

    public ChromiumEnvironmentBuiler UseCustomDistributionDirectory(Action<CustomCefDistributionPathOption> configureDelegate)
    {
        _useCustomCefDistributionPath = configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;
    }

    public ChromiumEnvironmentBuiler ConfigureCustomSchemes(Action<CefSchemeRegistrar> configureDelegate)
    {
        _configureCustomSchemes += configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;
    }

    public ChromiumEnvironmentBuiler UseInMemoryUserData()
    {
        useInMemoryUserData = true;
        return this;
    }

    public ChromiumEnvironmentBuiler UseCustomUserDataDirectory(string userDataPath)
    {
        _userDataDir = userDataPath;
        return this;
    }

    public ChromiumEnvironmentBuiler ConfigureCommandLineArguments(Action<CefCommandLine> configureDelegate)
    {
        _configureCommandLine += configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;
    }

    public ChromiumEnvironmentBuiler ConfigureDefaultSettings(Action<CefSettings> configureDelegate)
    {
        _configureSettings += configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;
    }

    public ChromiumEnvironmentBuiler ConfigureDefaultBrowserSettings(Action<CefBrowserSettings> configureDelegate)
    {
        _configureBrowserSettings += configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;
    }

    public ChromiumEnvironmentBuiler UseDistributionNotFoundHandler(Action<CustomCefDistributionPathOption> configureDelegate)
    {
        _useDistributionNotFoundHandler = configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));

        return this;

    }

    internal ChromiumEnvironment Build()
    {
        if (_useCustomCefDistributionPath == null)
        {
            AutoDetectLibCefDirectoryStructure();
        }
        else
        {
            var options = new CustomCefDistributionPathOption(Builder.Architecture);
            _useCustomCefDistributionPath.Invoke(options);


            if (EnsureLibCefExists(options.LibCefPath) && EnsureLibCefResourceDirExists(options.ResourceFilePath))
            {
                _libCefDir = options.LibCefPath;
                _resourceDir = options.ResourceFilePath;
            }
        }


        if ((string.IsNullOrEmpty(_libCefDir) || string.IsNullOrEmpty(_resourceDir)) && _useDistributionNotFoundHandler != null)
        {
            var options = new CustomCefDistributionPathOption(Builder.Architecture);
            _useDistributionNotFoundHandler.Invoke(options);

            if (EnsureLibCefExists(options.LibCefPath) && EnsureLibCefResourceDirExists(options.ResourceFilePath))
            {
                _libCefDir = options.LibCefPath;
                _resourceDir = options.ResourceFilePath;
            }
        }

        if (string.IsNullOrEmpty(_libCefDir) || string.IsNullOrEmpty(_resourceDir))
        {
            // 无法找到libcef.dll文件路径或cef运行时文件结构不正确。
            throw new FileNotFoundException(Properties.Messages.Exception_LibCefNotFound);
        }

        var env = new ChromiumEnvironment(_libCefDir!, _resourceDir!, Path.Combine(_resourceDir, LOCALES_DIR), Builder)
        {
            ConfigureCommandLine = _configureCommandLine,
            ConfigureSettings = _configureSettings,
            ConfigureBrowserSettings = _configureBrowserSettings,
            ConfigureSubprocess = _configureSubprocess,
            UserDataPath = _userDataDir,
            DisableHiDpiSupport = disableHiDpiSupport,
            UseInMemoryUserData = useInMemoryUserData,
            ConfigureCustomSchemes=_configureCustomSchemes
        };

        return env;
    }

    #region Search libcef.dll
    private static bool EnsureLibCefExists(string? path) => path!=null && File.Exists(Path.Combine(path, "libcef.dll"));
    private static bool EnsureLibCefResourceDirExists(string? path) => path != null && Directory.Exists(path) && Directory.GetFiles(path, "*.pak", SearchOption.TopDirectoryOnly).Length > 0 && Directory.Exists(Path.Combine(path, "locales")) && Directory.GetFiles(Path.Combine(path, "locales"), "*.pak", SearchOption.TopDirectoryOnly).Length > 0;


    private void AutoDetectLibCefDirectoryStructure()
    {
        DetectLibCefFilesPath();
        DetectLibCefResourceFilesPath();
    }

    private void DetectLibCefFilesPath()
    {
        var args = Environment.GetCommandLineArgs();

        var libCefPathArg = args?.FirstOrDefault(x => x.StartsWith("--libcef-dir-path"))?.Split('=');

        if (libCefPathArg != null && libCefPathArg.Length == 2 && EnsureLibCefExists(libCefPathArg[1]))
        {
            _libCefDir = libCefPathArg[1];
            return;
        }

        var searchPaths = new string[]
        {
                ApplicationRunningDirectory,
                Path.Combine(ApplicationRunningDirectory, Builder.Architecture.ToString()),
                Path.Combine(ApplicationRunningDirectory, DEFAULT_CEF_DIR, Builder.Architecture.ToString()),

                Path.Combine(ApplicationRunningDirectory, ANY_CPU_RUNTIME_DIR, $"win-{Builder.Architecture}", "native"),
                Path.Combine(CommonCefRuntimeDirectory, Builder.Architecture.ToString()),

        };

        foreach (var path in searchPaths)
        {
            if (EnsureLibCefExists(path))
            {
                _libCefDir = path;
                break;
            }
        }
    }

    private void DetectLibCefResourceFilesPath()
    {
        if (_libCefDir == null || string.IsNullOrEmpty(_libCefDir))
            return;

        var searchPaths = new string[]
        {
                _libCefDir,
                Path.GetFullPath(Path.Combine(_libCefDir, UP_LEVEL_DIR)),
                Path.GetFullPath(Path.Combine(_libCefDir, UP_LEVEL_DIR, RESOURCE_DIR)),
                Path.Combine(_libCefDir, RESOURCE_DIR)
        };

        foreach (var path in searchPaths)
        {
            if (EnsureLibCefResourceDirExists(path))
            {
                _resourceDir = path;
                break;
            }
        }
    }


    #endregion

}
