using Chromium;
using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetDimension.NanUI
{
    internal class AssembledResource : CustomResource
    {

        private readonly Assembly resourceAssembly;
        private string wwwroot = null;


        public AssembledResource(Assembly assembly, ResourceHandlerScheme scheme, string domain, string wwwroot = null) 
            : base(scheme, domain)
        {
            resourceAssembly = assembly;
            this.wwwroot = wwwroot;

        }
        protected override ResourceHandlerBase GetResourceHandler(string schemeName, CfxBrowser browser, CfxFrame frame, CfxRequest request) => new AssembledResourceHandler(resourceAssembly, wwwroot);


    }
}
