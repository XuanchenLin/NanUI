using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Caliburn.Light;
using NetDimension.NanUI.Browser;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using NetDimension.NanUI.Logging;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{
    public enum CefProcessType
    {
        Browser,
        Renderer,
    }

    public sealed class Runtime
    {



        internal RuntimeOptions _options;

        internal IDictionary<object, object> Properties => _options.RuntimeBuilderContext.Properties;

        internal ApplicationConfiguration ApplicationConfiguration => _options.ApplicationConfiguration;

        internal IDictionary<string, object> ApplicationProperties => ((ApplicationConfigurationBuilder)Properties[typeof(ApplicationConfigurationBuilder)]).Properties;

        internal List<ResourceSchemeConfiguration> CustomResourceHandlerConfigurations { get; } = new List<ResourceSchemeConfiguration>();

        internal bool IsRuntimeInitialized { get; private set; } = false;

        /// <summary>
        /// Gets the envrionment configurations of CEF
        /// </summary>
        public ChromiumEnvironment ChromiumEnvironment => _options.ChromiumEnvironment;

        /// <summary>
        /// Gets the IoC container
        /// </summary>
        public SimpleContainer Container => _options.Container;

        internal ILogger Logger => (ILogger)Properties[typeof(ILogger)];

        /// <summary>
        /// Gets the application is running on debugging mode.
        /// </summary>
        public bool IsDebuggingMode { get; } = false;

        /// <summary>
        /// Gets the type of current running instance.
        /// </summary>
        public CefProcessType ProcessType { get; }

        /// <summary>
        /// Gets the main process Id.
        /// </summary>
        public int BrowserProcessId { get; } = 0;


        private Runtime()
        {
            var args = Environment.GetCommandLineArgs();
            ProcessType = args.FirstOrDefault(x => x.StartsWith("--type=")) == null ? CefProcessType.Browser : CefProcessType.Renderer;

            if (ProcessType == CefProcessType.Renderer)
            {
                var processIdArg = args.FirstOrDefault(x => x.StartsWith("--host-process-id"));
                if (processIdArg != null)
                {
                    BrowserProcessId = int.Parse(Regex.Replace(processIdArg, "--host-process-id=", string.Empty));
                }
            }
        }


        internal Runtime(RuntimeOptions options) : this()
        {
            _options = options;

            if (ApplicationProperties.ContainsKey("UseDebuggingMode"))
            {
                IsDebuggingMode = true;
            }
        }

        internal int InitializeProcessOnly()
        {
            var args = Environment.GetCommandLineArgs();
            if (ProcessType == CefProcessType.Browser)
            {
                Logger.Error("This process is just only run as subprocess.");

                return -1;
            }

            CefRuntime.Load(ChromiumEnvironment.LibCefDir);

            IsRuntimeInitialized = true;

            if (!ChromiumEnvironment.ForceHighDpiSupportDisabled)
            {
                CefRuntime.EnableHighDpiSupport();
            }

            ChromiumEnvironment.CefBrowserSettingConfigurations?.Invoke(WinFormium.DefaultBrowserSettings);

            ApplicationConfiguration.UseExtensions[(int)ExtensionExecutePosition.SubProcessStartup]?.Invoke(this, ApplicationProperties);

            var cefMainArgs = new CefMainArgs(args);

            var app = new WinFormiumApp();

            var exitCode = CefRuntime.ExecuteProcess(cefMainArgs, app, IntPtr.Zero);

            return exitCode;
        }

        internal int Initialize()
        {
            var args = Environment.GetCommandLineArgs();


            if (ProcessType == CefProcessType.Browser)
            {

                var currentProcess = Process.GetCurrentProcess();



                ApplicationConfiguration.UseExtensions[(int)ExtensionExecutePosition.MainProcessStartup]?.Invoke(this, ApplicationProperties);
            }

            CefRuntime.Load(ChromiumEnvironment.LibCefDir);

            IsRuntimeInitialized = true;

            if (ProcessType == CefProcessType.Browser)
            {
                var info = $@"
Welcome to NanUI/0.8 Dev ({WinFormium.PlatformArchitecture}); Chromium/{CefRuntime.ChromeVersion}; WinFormium/{Assembly.GetExecutingAssembly().GetName().Version};
Copyrights (C) 2015-{DateTime.Now.Year} NetDimension Studio all rights reserved. Powered by Xuanchen Lin. 
{NanUI.Properties.Resources.ASCII_NanUI_Logo}
This project is under MIT License.
https://github.com/NetDimension/NanUI/blob/master/LICENCE
";

                Logger.Info(info);
            }


            if (!ChromiumEnvironment.ForceHighDpiSupportDisabled)
            {
                CefRuntime.EnableHighDpiSupport();
            }

            ChromiumEnvironment.CefBrowserSettingConfigurations?.Invoke(WinFormium.DefaultBrowserSettings);

            ApplicationConfiguration.UseExtensions[(int)ExtensionExecutePosition.SubProcessStartup]?.Invoke(this, ApplicationProperties);

            var cefMainArgs = new CefMainArgs(args);

            var app = new WinFormiumApp();

            var exitCode = CefRuntime.ExecuteProcess(cefMainArgs, app, IntPtr.Zero);

            Logger.Info(string.Format("CefRuntime.ExecuteProcess() returns {0}", exitCode));




            if (exitCode != -1)
            {
                return exitCode;
            }

            foreach (var arg in args)
            {
                if (arg.StartsWith("--type="))
                {
                    return -2;
                }
            }

            RegisterCustomResourceHandler(new ResourceHandler.InternalResource.InternalSchemeConfiguration());



            var settings = new CefSettings
            {
                LogSeverity = CefLogSeverity.Warning,
                ResourcesDirPath = ChromiumEnvironment.LibCefResourceDir,
                LocalesDirPath = ChromiumEnvironment.LibCefLocaleDir,
                Locale = Thread.CurrentThread.CurrentCulture.ToString(),
                AcceptLanguageList = Thread.CurrentThread.CurrentCulture.ToString(),
                JavaScriptFlags = "--expose-gc",
                CachePath = WinFormium.DefaultAppDataDirectory,
            };

            settings.LogFile = Path.Combine(settings.CachePath, "debug.log");

            ChromiumEnvironment.SettingConfigurations?.Invoke(settings);

            settings.MultiThreadedMessageLoop = true;

            settings.NoSandbox = true;

            if (!string.IsNullOrEmpty(ChromiumEnvironment.SubprocessPath))
            {
                settings.BrowserSubprocessPath = ChromiumEnvironment.SubprocessPath;
            }


            CefRuntime.Initialize(new CefMainArgs(args), settings, app, IntPtr.Zero);

            ApplicationConfiguration.UseExtensions[(int)ExtensionExecutePosition.Initialized]?.Invoke(this, ApplicationProperties);

            foreach (var config in CustomResourceHandlerConfigurations)
            {
                config.OnResourceHandlerRegister();

                if (!CefRuntime.RegisterSchemeHandlerFactory(config.Scheme, config.DomainName, config))
                {
                    throw new InvalidOperationException("ResouceHandler is fail to be registered");
                }
            }

            var context = GetAppContext();

            if (context == null)
            {
                context = ApplicationConfiguration.UseApplicationContext?.Invoke();

                if (context != null)
                {
                    context.ThreadExit += (_, args) =>
                    {
                        Application.Exit();
                    };
                }

            }

            if (context != null)
            {
                Application.Run(context);

                return 0;
            }


            Environment.Exit(-1);

            return -1;
        }

        private ApplicationContext GetAppContext()
        {
            var appContext = new ApplicationContext();
            var mainForm = ApplicationConfiguration.UseMainWindow?.Invoke(appContext);

            appContext.ThreadExit += (_, args) =>
            {
                Application.Exit();
            };


            if (mainForm != null || appContext.MainForm != null)
            {

                if (mainForm != null)
                {
                    appContext.MainForm = mainForm.HostWindowInternal;
                }


                return appContext;
            }

            Logger.Warn("No main window, exiting the main procedure...");

            return null;
        }

        /// <summary>
        /// Register custom ResourceHandler
        /// </summary>
        /// <param name="config"></param>
        public void RegisterCustomResourceHandler(ResourceSchemeConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException($"{nameof(ResourceSchemeConfiguration)} can't be null");
            }

            CustomResourceHandlerConfigurations.Add(config);
        }

        internal void RunAsSubprocess()
        {
            try
            {
                InitializeProcessOnly();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                throw ex;
            }
            finally
            {

                Logger.Info("Subprocess is shutting down...");
                CefRuntime.Shutdown();
                Logger.Info("Render prcoess has been down.");
                Environment.Exit(0);
            }
        }



        internal void Run()
        {
            try
            {
                Initialize();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                throw ex;
            }
            finally
            {
                if (ProcessType == CefProcessType.Browser)
                {

                    foreach (var config in CustomResourceHandlerConfigurations)
                    {
                        config.Dispose();
                    }


                    Logger.Info("Shutting down...");



                    CefRuntime.Shutdown();

                    ApplicationConfiguration.UseExtensions[(int)ExtensionExecutePosition.Terminated]?.Invoke(this, ApplicationProperties);

                    Logger.Info("Browser prcoess has been down.");
                }
                else
                {
                    CefRuntime.Shutdown();

                    Logger.Info("Render prcoess has been down.");
                }
                Environment.Exit(0);
            }

        }

    }
}
