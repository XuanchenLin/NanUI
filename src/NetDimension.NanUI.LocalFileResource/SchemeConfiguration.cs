using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.LocalFileResource
{
    internal class SchemeConfiguration : ResourceSchemeConfiguration
    {
        public string LocalResourceDiretory { get; }
        public Func<string, string> OnFallback { get; }


        public SchemeConfiguration(string scheme, string domainName, string localResourceDiretory, Func<string, string> onFallback = null) 
            : base(scheme, domainName)
        {
            LocalResourceDiretory = localResourceDiretory;
            OnFallback = onFallback;

        }


        protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) => new ResourceHandler(this);
    }

    public static class ExtensionRegister
    {
        public static ApplicationConfigurationBuilder UseLocalFileResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, string localFileResourceDirectory, Func<string, string> onFallback = null)
        {
            @this.UseCustomResourceHandler(() => new SchemeConfiguration(scheme, domainName, localFileResourceDirectory, onFallback));

            return @this;
        }
    }
}
