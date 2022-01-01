namespace NetDimension.NanUI;

internal sealed class RuntimeBuilderOptions
{
    public RuntimeBuilderContext Context { get; }
    public IDictionary<object, object> Properties => Context.Properties;

    public ApplicationConfiguration ApplicationConfiguration
    {
        get
        {
            if (!Properties.ContainsKey(typeof(ApplicationConfiguration)))
                return null;

            return (ApplicationConfiguration)Properties[typeof(ApplicationConfiguration)];
        }
    }
    public ChromiumEnvironment ChromiumEnvironment
    {
        get
        {
            if (!Properties.ContainsKey(typeof(ChromiumEnvironment)))
                return null;

            return (ChromiumEnvironment)Properties[typeof(ChromiumEnvironment)];
        }
    }

    public ServiceContainer Container
    {
        get
        {
            if (!Properties.ContainsKey(typeof(ServiceContainer)))
                return null;

            return (ServiceContainer)Properties[typeof(ServiceContainer)];
        }
    }
    public RuntimeBuilderOptions(RuntimeBuilderContext context)
    {
        Context = context;
    }

}
