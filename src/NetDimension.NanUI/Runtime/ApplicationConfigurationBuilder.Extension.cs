namespace NetDimension.NanUI;

public partial class ApplicationConfigurationBuilder
{
    /// <summary>
    /// Adds a handler delegate to the application's startup pipeline.
    /// </summary>
    /// <param name="useExtensions"><see langword="abstract"/>A delegate that handles the process.</param>
    /// <param name="position">Which position will invoke this delegate.</param>
    /// <returns>Current ApplicationConfigurationBuilder instance.</returns>
    public ApplicationConfigurationBuilder Use(Func<ApplicationConfigurationBuilder, Action<RuntimeContext, IDictionary<string, object>>> useExtensions, ExtensionExecutePosition position = ExtensionExecutePosition.BrowserProcessInitialized)
    {
        var action = new ConfigurationInitializationAction(position, useExtensions);

        _useExtensions.Add(action);

        return this;
    }

    /// <summary>
    /// Adds a handler that controls startup window of the application.
    /// </summary>
    /// <param name="useMainWindow">A delegate that handles the process.</param>
    /// <returns>Current ApplicationConfigurationBuilder instance.</returns>
    /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
    public ApplicationConfigurationBuilder UseMainWindow(Func<ApplicationContext, Formium> useMainWindow)
    {
        if (_useMainWindow != null)
        {
            throw new InvalidOperationException(nameof(UseMainWindow));
        }

        _useMainWindow = useMainWindow;
        return this;
    }

    /// <summary>
    /// Sets the culture of current applicaiton instance.
    /// </summary>
    /// <param name="culture">Culture name.</param>
    /// <returns>Current ApplicationConfigurationBuilder instance.</returns>
    public ApplicationConfigurationBuilder SetCulture(string culture)
    {
        var cultureInfo = new System.Globalization.CultureInfo(culture);
        Application.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;

        return this;
    }

    /// <summary>
    /// Adds a handler that controls startup process of the application.
    /// </summary>
    /// <param name="useApplicationContext">A delegate that handles the process.</param>
    /// <returns>Current ApplicationConfigurationBuilder instance.</returns>
    /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
    public ApplicationConfigurationBuilder UseApplicationContext(Func<ApplicationContext> useApplicationContext)
    {
        if (_useApplicationContext != null)
        {
            throw new InvalidOperationException(nameof(UseApplicationContext));
        }

        _useApplicationContext = useApplicationContext;

        return this;
    }


    /// <summary>
    /// Sets the debugging state of current NanUI application.
    /// </summary>
    /// <returns>Current ApplicationConfigurationBuilder instance.</returns>
    public ApplicationConfigurationBuilder UseDebuggingMode()
    {
        Properties[nameof(UseDebuggingMode)] = true;
        return this;
    }



}
