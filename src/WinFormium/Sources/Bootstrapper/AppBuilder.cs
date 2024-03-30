// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public sealed class AppBuilder
{

    public IServiceCollection Services { get; }
    public PropertyManager Properties { get; }

    public ProcessType ProcessType { get; }

    private const string TYPE_ARG_PREFIX = "--type=";
    internal const string SETTINGS_ENABLE_EMBEDDED_BROWSER = "EnableEmbeddedBrowser";

    private Action<ChromiumEnvironmentBuiler>? _configureChromium;

    internal List<Action<AppBuilder>> UseExtensions { get; } = new();

    internal AppBuilder()
    {
        Services = new ServiceCollection();

        Properties = new PropertyManager();

        Services.AddSingleton(Properties);

        var args = Environment.GetCommandLineArgs();

        ProcessType = args.FirstOrDefault(x => x.StartsWith(TYPE_ARG_PREFIX)) == null ? ProcessType.Main : ProcessType.Renderer;
    }

    internal PlatformArchitecture Architecture
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
                    throw new NotSupportedException(WinFormium.Properties.Messages.Exception_UnkownPlatformArchitecture);
            }
        }
    }

    public AppBuilder ConfigureChromium(Action<ChromiumEnvironmentBuiler> configureDelegate)
    {
        _configureChromium += configureDelegate;

        return this;
    }

    public AppBuilder UseWinFormiumApp<TApp>() where TApp : notnull, WinFormiumStartup
    {
        Services.AddSingleton<IWinFormiumStartup, TApp>();

        return this;
    }

    public AppBuilder UseCulture(string culture)
    {
        Configure(@this =>
        {
            @this.Properties.SetValue(nameof(UseCulture), culture);
        });

        return this;
    }

    public AppBuilder UseDevToolsMenu()
    {
        Configure(@this =>
        {
            @this.Properties.SetValue(nameof(UseDevToolsMenu), true);
        });

        return this;
    }

    public AppBuilder UseEmbeddedBrowser()
    {
        Configure(@this =>
        {
            @this.Properties.SetValue(nameof(UseEmbeddedBrowser), true);
        });

        return this;
    }

    public AppBuilder ClearCache()
    {
        Configure(@this =>
        {
            @this.Properties.SetValue(nameof(ClearCache), true);
        });

        return this;
    }

    public AppBuilder UseSingleApplicationInstanceMode(Action<OnApplicationInstanceRunningHandler>? onApplicationInstanceRunning = null)
    {
        Configure(@this =>
        {
            @this.Properties.SetValue(nameof(UseSingleApplicationInstanceMode), onApplicationInstanceRunning ?? new Action<OnApplicationInstanceRunningHandler>(_ => { }));
        });

        return this;
    }

    public AppBuilder UseServices(Action<IServiceCollection> action)
    {
        action.Invoke(Services);

        return this;
    }


    public AppBuilder Configure(Action<AppBuilder> useExtension)
    {
        UseExtensions.Add(useExtension);

        return this;
    }

    public WinFormiumApp Build()
    {
        foreach (var extension in UseExtensions)
        {
            extension.Invoke(this);
        }

        var chromiumConfig = ChromiumEnvironmentBuiler.Create(this);





        if (ProcessType == ProcessType.Main)
        {
            var tempServiceProvider = Services.BuildServiceProvider();

            var startup = tempServiceProvider.GetRequiredService<IWinFormiumStartup>();

            _configureChromium += startup.ConfigureChromiumEmbeddedFramework;

            startup.WinFormiumMain(Environment.GetCommandLineArgs());

            startup.ConfigureServices(Services);

            var mainWindowOpts = new MainWindowOptions(Services)!;

            Services.AddSingleton(mainWindowOpts);


            var createAction = startup.UseMainWindow(mainWindowOpts);

            if (createAction != null)
            {
                Services.AddSingleton(mainWindowOpts);

                Services.AddSingleton(createAction);
            }
        }

        if (_configureChromium != null)
        {
            _configureChromium.Invoke(chromiumConfig);
        }

        var env = chromiumConfig.Build();

        Services.AddSingleton(env);

        Services.AddSingleton(services =>
        {
            return new WinFormiumApp(ProcessType, Architecture, Services);
        });

        var app = Services.BuildServiceProvider().GetRequiredService<WinFormiumApp>();

        return app;
    }
}
