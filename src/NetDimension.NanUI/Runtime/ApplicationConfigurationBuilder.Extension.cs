namespace NetDimension.NanUI;

public partial class ApplicationConfigurationBuilder
{
    public ApplicationConfigurationBuilder Use(Func<ApplicationConfigurationBuilder, Action<RuntimeContext, IDictionary<string, object>>> useExtensions, ExtensionExecutePosition position = ExtensionExecutePosition.BrowserProcessInitialized)
    {
        var action = new ConfigurationInitializationAction(position, useExtensions);

        _useExtensions.Add(action);

        return this;
    }

    public ApplicationConfigurationBuilder UseMainWindow(Func<ApplicationContext, Formium> useMainWindow)
    {
        if (_useMainWindow != null)
        {
            throw new InvalidOperationException(nameof(UseMainWindow));
        }

        _useMainWindow = useMainWindow;
        return this;
    }

    public ApplicationConfigurationBuilder SetCulture(string culture)
    {
        var cultureInfo = new System.Globalization.CultureInfo(culture);
        Application.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;

        return this;
    }

    public ApplicationConfigurationBuilder UseApplicationContext(Func<ApplicationContext> useApplicationContext)
    {
        if (_useApplicationContext != null)
        {
            throw new InvalidOperationException(nameof(UseApplicationContext));
        }

        _useApplicationContext = useApplicationContext;

        return this;
    }



    public ApplicationConfigurationBuilder UseDebuggingMode()
    {

        Properties[nameof(UseDebuggingMode)] = true;

        return this;
    }



}
