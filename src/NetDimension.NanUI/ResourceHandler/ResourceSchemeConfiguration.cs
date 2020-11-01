using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.ResourceHandler
{
    
    public abstract class ResourceSchemeConfiguration : CefSchemeHandlerFactory, IDisposable
    {
        GCHandle _gcHandler;
        public string Scheme { get; }
        public string DomainName { get; }
        public bool IsStandardScheme
        {
            get
            {
                switch (Scheme?.ToLower())
                {
                    case "http":
                    case "https":
                    case "file":
                    case "ftp":
                    case "about":
                    case "data":
                        return true;
                }

                return false;
            }
        }



        private ResourceHandlerBase _resourceHandler;

        public ResourceSchemeConfiguration(string scheme, string domainName)
        {
            _gcHandler = GCHandle.Alloc(this);

            Scheme = scheme;
            DomainName = domainName;
        }

        protected abstract ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request);

        protected override CefResourceHandler Create(CefBrowser browser, CefFrame frame, string schemeName, CefRequest request)
        {
            _resourceHandler = GetResourceHandler(browser, frame, request);
            return _resourceHandler;
        }

        internal protected virtual void OnResourceHandlerRegister()
        {

        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _gcHandler.Free();
            }

            base.Dispose(isDisposing);

            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
