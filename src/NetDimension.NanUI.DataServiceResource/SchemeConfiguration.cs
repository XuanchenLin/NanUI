using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.DataServiceResource
{
    internal class SchemeConfiguration : ResourceSchemeConfiguration
    {
        public SchemeConfiguration(string scheme, string domainName, Action<DataServiceProvider> buildDataService)
            : base(scheme, domainName)
        {
            BuildDataService = buildDataService;


        }

        protected override void OnResourceHandlerRegister()
        {
            if (BuildDataService != null)
            {
                var provider = DataServiceProvider.Create(this);

                BuildDataService.Invoke(provider);
            }
        }

        public Action<DataServiceProvider> BuildDataService { get; }

        protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) {



            var handler = new ResourceHandler(this);

            return handler;
        }
    }

    public static class ExtensionRegister
    {
        public static ApplicationConfigurationBuilder UseDataServiceResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName, Action<DataServiceProvider> buildDataService = null)
        {


            appBuilder.UseCustomResourceHandler(() => new SchemeConfiguration(scheme, domainName, buildDataService));

            return appBuilder;
        }

        public static ApplicationConfigurationBuilder UseDataServiceResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName)
        {

            appBuilder.UseCustomResourceHandler(() => new SchemeConfiguration(scheme, domainName, builder=> {
                builder.ImportDataServiceAssembly(Assembly.GetEntryAssembly());
            }));

            return appBuilder;
        }
    }
}
