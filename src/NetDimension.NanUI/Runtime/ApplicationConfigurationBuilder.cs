namespace NetDimension.NanUI;

public enum ExtensionExecutePosition
{
    MainProcessInitilized,
    SubProcessInitialized,
    BrowserProcessInitialized,
    Terminated
}
public sealed partial class ApplicationConfigurationBuilder
{
    internal class ConfigurationInitializationAction
    {
        public ConfigurationInitializationAction(ExtensionExecutePosition executePosition, Func<ApplicationConfigurationBuilder, Action<RuntimeContext, IDictionary<string, object>>> func)
        {
            ExecutePosition = executePosition;

            Function = func;
        }

        public ExtensionExecutePosition ExecutePosition { get; }

        public Func<ApplicationConfigurationBuilder, Action<RuntimeContext, IDictionary<string, object>>> Function { get; }
    }

    private readonly RuntimeBuilderContext _context;

    private Func<ApplicationContext, Formium> _useMainWindow;

    private Func<ApplicationContext> _useApplicationContext;


    internal readonly IDictionary<string, object> Properties = new Dictionary<string, object>();

    public ChromiumEnvironment ChromiumEnvironment { get; }

    public ServiceContainer Container { get; }

    private readonly List<ConfigurationInitializationAction> _useExtensions = new();

    internal ApplicationConfigurationBuilder(RuntimeBuilderContext runtimeBuilderContext)
    {
        _context = runtimeBuilderContext;

        ChromiumEnvironment = (ChromiumEnvironment)_context.Properties[typeof(ChromiumEnvironment)];
        Container = (ServiceContainer)_context.Properties[typeof(ServiceContainer)];
    }




    internal ApplicationConfiguration Build()
    {
        var config = new ApplicationConfiguration();

        foreach (var useExtension in _useExtensions)
        {
            var result = useExtension.Function?.Invoke(this);


            if (result != null)
            {

                config.UseExtensions[(int)useExtension.ExecutePosition] += result;
            }
        }

        config.UseApplicationContext = _useApplicationContext;
        config.UseMainWindow = _useMainWindow;
        return config;
    }



}
