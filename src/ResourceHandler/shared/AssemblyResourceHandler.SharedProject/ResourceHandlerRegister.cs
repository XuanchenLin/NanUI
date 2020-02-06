using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetDimension.NanUI
{
    public static class ResourceHandlerRegister
    {
        public static Bootstrap UseAssembledResource(this Bootstrap _, Assembly assembly, ResourceHandlerScheme scheme, string domain, string basePath = null)
        {
            Bootstrap.RegisterCustomResourceHandler(() => new AssembledResource(assembly, scheme, domain, basePath));
            return _;
        }
    }
}
