using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Caliburn.Light;
using NetDimension.NanUI.JavaScript;
using NetDimension.NanUI.Logging;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{
    public sealed class RuntimeBuilder
    {
        private readonly RuntimeBuilderContext _context;

        private readonly RuntimeOptions _options;

        private readonly ChromiumEnvironmentBuilder _chromiumEnvironmentBuilder;
        private readonly ApplicationConfigurationBuilder _appConfigBuilder;

        private readonly SimpleContainer _container;
        private readonly ChromiumEnvironment _env;
        private readonly ApplicationConfiguration _appConfig;



        private Dictionary<object, object> Properties = new Dictionary<object, object>();



        private RuntimeBuilder()
        {

        }

        internal RuntimeBuilder(Action<ChromiumEnvironmentBuilder> buildChromiumEnvironment = null, Action<ApplicationConfigurationBuilder> configureAppConfiguration = null)
        {
            _context = new RuntimeBuilderContext(Properties);

            _options = new RuntimeOptions(_context);

            _context.Properties[typeof(SimpleContainer)] = _container = new SimpleContainer();

            var hostExtension = new HostWindow.JavaScriptExtension.HostWindowExtension();

            _container.RegisterInstance<JavaScriptExtensionBase>(hostExtension, hostExtension.Name);


            _context.Properties[typeof(ChromiumEnvironmentBuilder)] = _chromiumEnvironmentBuilder = new ChromiumEnvironmentBuilder(_context);

            buildChromiumEnvironment?.Invoke(_chromiumEnvironmentBuilder);

            _context.Properties[typeof(ChromiumEnvironment)] = _env = _chromiumEnvironmentBuilder.Build();


            _context.Properties[typeof(ApplicationConfigurationBuilder)] = _appConfigBuilder = new ApplicationConfigurationBuilder(_context);

            configureAppConfiguration?.Invoke(_appConfigBuilder);

            _context.Properties[typeof(ApplicationConfiguration)] = _appConfig = _appConfigBuilder.Build();
        }


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

            return new WinFormium(new Runtime(_options));
        }
    }

}
