using NetDimension.NanUI.JavaScript.WindowBinding;
using NetDimension.NanUI.Logging;

namespace NetDimension.NanUI;

public sealed class RuntimeBuilder
{
    private readonly RuntimeBuilderContext _context;
    private readonly RuntimeBuilderOptions _options;

    private readonly ChromiumEnvironmentBuilder _chromiumEnvironmentBuilder;
    private readonly ApplicationConfigurationBuilder _appConfigBuilder;


    private readonly ServiceContainer _container;

    private readonly Dictionary<object, object> Properties = new();

    private RuntimeBuilder()
    {

    }

    internal RuntimeBuilder(Action<ChromiumEnvironmentBuilder> buildChromiumEnvironment = null, Action<ApplicationConfigurationBuilder> configureAppConfiguration = null)
    {
        _context = new RuntimeBuilderContext(Properties);

        _options = new RuntimeBuilderOptions(_context);

        _context.Properties[typeof(ServiceContainer)] = _container = new ServiceContainer();

        var hostWindowBinding = new Browser.WindowBinding.FormiumObjectWindowBinding();

        _container.RegisterInstance<JavaScriptWindowBindingObject>(hostWindowBinding, hostWindowBinding.Name);

        _context.Properties[typeof(ChromiumEnvironmentBuilder)] = _chromiumEnvironmentBuilder = new ChromiumEnvironmentBuilder(_context);

        buildChromiumEnvironment?.Invoke(_chromiumEnvironmentBuilder);

        _context.Properties[typeof(ChromiumEnvironment)] =  _chromiumEnvironmentBuilder.Build();


        _context.Properties[typeof(ApplicationConfigurationBuilder)] = _appConfigBuilder = new ApplicationConfigurationBuilder(_context);

        _appConfigBuilder.UseEmbeddedFileResource("res", "formium", this.GetType().Assembly, "HostWindow/InternalResources");

        configureAppConfiguration?.Invoke(_appConfigBuilder);

        _context.Properties[typeof(ApplicationConfiguration)] =  _appConfigBuilder.Build();
    }

    /// <summary>
    /// Build the WinFormium runtime.
    /// </summary>
    /// <returns>The WinFormium instance.</returns>
    public WinFormium Build()
    {
        ILogger logger;

        if (_container.IsRegistered<ILogger>())
        {
            logger = _container.GetInstance<ILogger>();
        }
        else
        {
            logger = new DefaultLogger();
            _container.RegisterInstance(logger);
        }

        _context.Properties[typeof(ILogger)] = logger;

        return new WinFormium(new RuntimeContext(_options));
    }



}
