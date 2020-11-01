using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.ResourceHandler.InternalResource
{
    internal class InternalSchemeConfiguration : ResourceSchemeConfiguration
    {
        public InternalSchemeConfiguration()
: base("formium", string.Empty)
        {

        }

        protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
        {
            return new InternalResourceHandler(this);
        }
    }
}
