using NetDimension.NanUI.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.ResourceHandler
{
    using Chromium;
    using System.Collections.Concurrent;
    using System.Runtime.InteropServices;


    public abstract class CustomResource
    {
        private static ConcurrentBag<GCHandle> ResourceHandlerGCHandles = new ConcurrentBag<GCHandle>();

        public static void FreeGCHandles()
        {
            foreach (var handle in ResourceHandlerGCHandles)
            {
                handle.Free();
            }
        }

        public ResourceHandlerScheme Scheme { get;  }
        public string SchemeName { get => Scheme.ToString().ToLower(); }
        public string DomainName { get; }
        public CfxSchemeHandlerFactory SchemeHandlerFactory { get; }
        public CustomResource(ResourceHandlerScheme scheme, string domain)
        {
            Scheme = scheme;
            DomainName = domain.Trim('/');
            SchemeHandlerFactory = new CfxSchemeHandlerFactory();
            SchemeHandlerFactory.Create += SchemeHandlerFactory_Create;
            ResourceHandlerGCHandles.Add(GCHandle.Alloc(SchemeHandlerFactory));
        }
        protected abstract ResourceHandlerBase GetResourceHandler(string schemeName, CfxBrowser browser, CfxFrame frame, CfxRequest request);
        private void SchemeHandlerFactory_Create(object sender, Chromium.Event.CfxCreateEventArgs e)
        {
            e.SetReturnValue(GetResourceHandler(e.SchemeName, e.Browser, e.Frame, e.Request));

        }

        
    }
}
