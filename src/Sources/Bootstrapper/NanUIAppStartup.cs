// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;
public abstract class NanUIAppStartup : INanUIStartup
{
    /// <summary>
    /// The main entry point for WinFormium app.
    /// This funcion will be called only main process.
    /// </summary>
    /// <param name="args">
    /// Command line arguments
    /// </param>
    protected abstract void ProgramMain(string[] args);

    /// <summary>
    /// Set how the main window will be loaded.
    /// </summary>
    /// <param name="opts">
    /// Options for set main window.
    /// </param>
    /// <returns>
    /// Returns the <see cref="MainWindowCreationAction"/> to create main window.
    /// Returns null to end the inialization of application.
    /// </returns>
    protected abstract MainWindowCreationAction? UseMainWindow(MainWindowOptions opts);

    /// <summary>
    /// Configures the Chromium Embedded Framework environment.
    /// </summary>
    /// <param name="cef">
    /// The <see cref="ChromiumEnvironmentBuiler"/> instance for settings up the cef.
    /// </param>
    protected virtual void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
    {

    }

    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">
    /// A <see cref="IServiceCollection"/> object.
    /// </param>
    protected virtual void ConfigureServices(IServiceCollection services)
    {

    }


    void INanUIStartup.ProgramMain(string[] args)
    {
        ProgramMain(args);
    }

    MainWindowCreationAction? INanUIStartup.UseMainWindow(MainWindowOptions opts)
    {
        return UseMainWindow(opts);
    }

    void INanUIStartup.ConfigureChromiumEmbeddedFramework(ChromiumEnvironmentBuiler builder)
    {
        ConfigurationChromiumEmbedded(builder);
    }

    void INanUIStartup.ConfigureServices(IServiceCollection services)
    {
        ConfigureServices(services);
    }
}

