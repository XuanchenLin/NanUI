using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Caliburn.Light;
using NetDimension.NanUI.Logging;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{
    public enum ExtensionExecutePosition
    {
        /// <summary>
        /// Browser process is starting up.
        /// </summary>
        MainProcessStartup = 0,
        
        /// <summary>
        /// Before initializing subprocesses.
        /// </summary>
        SubProcessStartup,

        /// <summary>
        /// Cef environment is initialized
        /// </summary>
        Initialized,
        
        /// <summary>
        /// Browser process is terminated.
        /// </summary>
        Terminated

    }



    

    public sealed class ApplicationConfigurationBuilder
    {

        internal class ConfigurationInitializationAction
        {
            public ConfigurationInitializationAction(ExtensionExecutePosition executePosition, Func<ApplicationConfigurationBuilder, Action<Runtime, IDictionary<string, object>>> func)
            {
                ExecutePosition = executePosition;

                Function = func;
            }

            public ExtensionExecutePosition ExecutePosition { get; }

            public Func<ApplicationConfigurationBuilder, Action<Runtime, IDictionary<string, object>>> Function { get; }
        }

        private readonly RuntimeBuilderContext _context;

        private Func<ApplicationContext, Formium> _useMainWindow;

        private Func<ApplicationContext> _useApplicationContext;


        internal readonly IDictionary<string, object> Properties = new Dictionary<string, object>();

        public ChromiumEnvironment ChromiumEnvironment { get; }

        public SimpleContainer Container { get; }

        private List<ConfigurationInitializationAction> _useExtensions = new List<ConfigurationInitializationAction>();


        internal ApplicationConfigurationBuilder(RuntimeBuilderContext runtimeBuilderContext)
        {
            _context = runtimeBuilderContext;


            ChromiumEnvironment = (ChromiumEnvironment)_context.Properties[typeof(ChromiumEnvironment)];
            Container = (SimpleContainer)_context.Properties[typeof(SimpleContainer)];
        }

        public ApplicationConfigurationBuilder Use(Func<ApplicationConfigurationBuilder, Action<Runtime, IDictionary<string, object>>> useExtensions, ExtensionExecutePosition position = ExtensionExecutePosition.Initialized)
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

        internal ApplicationConfiguration Build()
        {
            var config = new ApplicationConfiguration();

            foreach (var useExtension in _useExtensions)
            {
                var result = useExtension.Function?.Invoke(this);


                if (result != null)
                {

                    config.UseExtensions[(int)useExtension.ExecutePosition]  += result;
                }
            }

            config.UseApplicationContext = _useApplicationContext;
            config.UseMainWindow = _useMainWindow;
            return config;
        }
    }
}
