using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.EmbeddedFileResource
{
    internal class SchemeConfiguration : ResourceSchemeConfiguration
    {
        public Assembly ResourceAssebmly { get; }

        public string RootPath { get; }
        public Func<string, string> OnFallback { get; }

        protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) => new ResourceHandler(this);

        public SchemeConfiguration(Assembly resourceAssebmly, string scheme, string domainName, string rootPath = null, Func<string, string> onFallback = null)
            : base(scheme, domainName)
        {
            ResourceAssebmly = resourceAssebmly;
            RootPath = rootPath;
            OnFallback = onFallback;
        }
    }

    //public class EmbeddedFileResourceOptions
    //{
    //    public string Scheme { get; set; }

    //    public string DomainName { get; set; }

    //    public Assembly ResourceAssembly { get; set; }

    //    public string ResourceFileRootPath { get; set; }

    //    public Func<string, string> OnFallback { get; set; }

    //}



    public static class ExtensionRegister
    {
        public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName, Assembly resourceAssembly, string resourceFileRootPath = null, Func<string,string> onFallback = null)
        {

            appBuilder.UseCustomResourceHandler(() => new SchemeConfiguration(resourceAssembly, scheme, domainName, resourceFileRootPath, onFallback));

            return appBuilder;
        }

        public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName, string resourceFileRootPath, Func<string, string> onFallback = null)
        {

            UseEmbeddedFileResource(appBuilder, scheme, domainName, Assembly.GetEntryAssembly(), resourceFileRootPath, onFallback);

            return appBuilder;
        }

        public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName, Func<string, string> onFallback = null)
        {
            UseEmbeddedFileResource(appBuilder, scheme, domainName, Assembly.GetEntryAssembly(),null, onFallback);
            return appBuilder;
        }

        public static Runtime UseEmbeddedFileResource(this Runtime runtime, string scheme, string domainName, Assembly resourceAssembly, string resourceFileRootPath = null, Func<string, string> onFallback = null)
        {

            runtime.RegisterCustomResourceHandler(new SchemeConfiguration(resourceAssembly, scheme, domainName, resourceFileRootPath, onFallback));

            return runtime;
        }

        public static Runtime UseEmbeddedFileResource(this Runtime runtime, string scheme, string domainName, string resourceFileRootPath, Func<string, string> onFallback = null)
        {

            UseEmbeddedFileResource(runtime, scheme, domainName, Assembly.GetExecutingAssembly(), resourceFileRootPath,onFallback);

            return runtime;
        }

        public static Runtime UseEmbeddedFileResource(this Runtime runtime, string scheme, string domainName, Func<string, string> onFallback = null)
        {
            UseEmbeddedFileResource(runtime, scheme, domainName, Assembly.GetExecutingAssembly(),null,onFallback);
            return runtime;
        }



    }
}
