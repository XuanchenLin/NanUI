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

        protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) => new ResourceHandler(this);

        public SchemeConfiguration(Assembly resourceAssebmly, string scheme, string domainName, string rootPath = null)
            : base(scheme, domainName)
        {
            ResourceAssebmly = resourceAssebmly;
            RootPath = rootPath;
        }
    }

    public static class ExtensionRegister
    {
        public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName, Assembly resourceAssembly, string resourceFileRootPath = null)
        {

            appBuilder.UseCustomResourceHandler(() => new SchemeConfiguration(resourceAssembly, scheme, domainName, resourceFileRootPath));

            return appBuilder;
        }

        public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName, string resourceDirectoryName)
        {

            UseEmbeddedFileResource(appBuilder, scheme, domainName, Assembly.GetEntryAssembly(), resourceDirectoryName);

            return appBuilder;
        }

        public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder appBuilder, string scheme, string domainName)
        {
            UseEmbeddedFileResource(appBuilder, scheme, domainName, Assembly.GetEntryAssembly());
            return appBuilder;
        }

        public static Runtime UseEmbeddedFileResource(this Runtime runtime, string scheme, string domainName, Assembly resourceAssembly, string resourceFileRootPath = null)
        {

            runtime.RegisterCustomResourceHandler(new SchemeConfiguration(resourceAssembly, scheme, domainName, resourceFileRootPath));

            return runtime;
        }

        public static Runtime UseEmbeddedFileResource(this Runtime runtime, string scheme, string domainName, string resourceDirectoryName)
        {

            UseEmbeddedFileResource(runtime, scheme, domainName, Assembly.GetExecutingAssembly(), resourceDirectoryName);

            return runtime;
        }

        public static Runtime UseEmbeddedFileResource(this Runtime runtime, string scheme, string domainName)
        {
            UseEmbeddedFileResource(runtime, scheme, domainName, Assembly.GetExecutingAssembly());
            return runtime;
        }



    }
}
