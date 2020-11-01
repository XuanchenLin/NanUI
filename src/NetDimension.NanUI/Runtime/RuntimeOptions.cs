using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Light;

namespace NetDimension.NanUI
{
    internal class RuntimeOptions
    {
        public IDictionary<object, object> Properties => RuntimeBuilderContext.Properties;

        public RuntimeBuilderContext RuntimeBuilderContext { get; }

        public ApplicationConfiguration ApplicationConfiguration { 
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

        public SimpleContainer Container
        {
            get
            {
                if (!Properties.ContainsKey(typeof(SimpleContainer)))
                    return null;

                return (SimpleContainer)Properties[typeof(SimpleContainer)];
            }
        }
        public RuntimeOptions(RuntimeBuilderContext context)
        {
            RuntimeBuilderContext = context;
        }
    }
}
