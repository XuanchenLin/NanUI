using Chromium;
using NetDimension.Formium.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetDimension.Formium
{
    internal class FileResource : CustomResource
    {

        private string wwwroot = null;

        public FileResource(ResourceHandlerScheme scheme, string domain, string wwwroot) 
            : base(scheme, domain)
        {
            this.wwwroot = wwwroot;

        }
        protected override ResourceHandlerBase GetResourceHandler(string schemeName, CfxBrowser browser, CfxFrame frame, CfxRequest request) => new FileResourceHandler(wwwroot);
    }
}
