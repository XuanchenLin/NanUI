using NetDimension.NanUI.Browser.ResourceHandler;
using NetDimension.NanUI.JavaScript.WindowBinding;
using System.Diagnostics;
using Xilium.CefGlue;

namespace NetDimension.NanUI;

public static class ApplicationConfigurationBuilderExtensions
{
    public static ApplicationConfigurationBuilder UseApplicationDataDirectory(this ApplicationConfigurationBuilder @this, string path)
    {

        @this.Use(builder =>
        {
            builder.Properties[nameof(UseApplicationDataDirectory)] = path;



            return (runtime, props) =>
            {

                if (!props.ContainsKey(nameof(UseApplicationDataDirectory)))
                {
                    return;
                }

                var path = (string)props[nameof(UseApplicationDataDirectory)];


                runtime.ChromiumEnvironment.SettingConfigurations += new Action<CefSettings>(settings =>
                {
                    settings.CachePath = path;
                    settings.LogFile = Path.Combine(path, "debug.log");
                });
            };
        }, ExtensionExecutePosition.MainProcessInitilized);

        return @this;
    }

    /// <summary>
    /// Allows application just run one instance.
    /// </summary>
    public static ApplicationConfigurationBuilder UseSingleInstance(this ApplicationConfigurationBuilder @this, Action onProcessAlreadyExists = null)
    {
        @this.Use(builder =>
        {


            return (runtime, props) =>
            {
                var thisProcess = Process.GetCurrentProcess();

                foreach (var process in Process.GetProcessesByName(thisProcess.ProcessName))
                {
                    if (process.Id != thisProcess.Id)
                    {
                        onProcessAlreadyExists?.Invoke();

                        Environment.Exit(0);
                        return;

                    }
                }

            };
        }, ExtensionExecutePosition.MainProcessInitilized);

        return @this;
    }


    public static ApplicationConfigurationBuilder ClearCacheFile(this ApplicationConfigurationBuilder @this)
    {
        //const string CACHE_DIR = "Cache";

        @this.Use(builder =>
        {
            builder.Properties[nameof(ClearCacheFile)] = true;



            return (runtime, props) =>
            {

                var cachePath = WinFormium.DefaultAppDataDirectory;

                if (props.ContainsKey(nameof(UseApplicationDataDirectory)))
                {
                    cachePath = (string)props[nameof(UseApplicationDataDirectory)];
                }

                cachePath = Path.Combine(cachePath);

                if (Directory.Exists(cachePath))
                {
                    try
                    {
                        Directory.Delete(cachePath, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }



                WinFormium.GetLogger().Info("Cache has been cleared.");
            };
        }, ExtensionExecutePosition.MainProcessInitilized);

        return @this;
    }

    public static ApplicationConfigurationBuilder UseCustomResourceHandler(this ApplicationConfigurationBuilder @this, Func<ResourceSchemeConfiguration> getConfig)
    {
        @this.Use(builder =>
        {
            return (runtime, props) =>
            {

                var config = getConfig.Invoke();
                runtime.RegisterCustomResourceHandler(config);

            };
        }, ExtensionExecutePosition.BrowserProcessInitialized);

        return @this;
    }

    public static ApplicationConfigurationBuilder UseCustomResourceHandlerOptions(this ApplicationConfigurationBuilder @this, Action<ResourceSchemeOption> setOptionAction)
    {
        var options = @this.Container.GetInstance<ResourceSchemeOption>();

        if (options == null)
        {
            options = new ResourceSchemeOption();

            @this.Container.RegisterInstance(options);
        }

        setOptionAction?.Invoke(options);

        return @this;
    }

    public static ApplicationConfigurationBuilder RegisterJavaScriptWindowBinding(this ApplicationConfigurationBuilder @this, Func<JavaScriptWindowBindingObject> registerJavaScriptWindowBinding)
    {
        @this.Use(builder =>
        {
            return (runtime, props) =>
            {
                var extension = registerJavaScriptWindowBinding.Invoke();

                var extensionName = extension.Name.ToLower();

                if (runtime.Container.IsRegistered<JavaScriptWindowBindingObject>(extensionName))
                {
                    throw new ArgumentException($"Extension {extension.Name} already exists.");
                }

                runtime.Container.RegisterInstance(extension, extension.Name);
            };

        }, ExtensionExecutePosition.SubProcessInitialized);
        return @this;
    }
}
