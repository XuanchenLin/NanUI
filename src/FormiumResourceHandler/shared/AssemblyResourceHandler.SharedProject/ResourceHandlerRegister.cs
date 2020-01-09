using NetDimension.Formium.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetDimension.Formium
{
    public static class ResourceHandlerRegister
    {
        public static NanUI UseAssembledResource(this NanUI _, Assembly assembly, ResourceHandlerScheme scheme, string domain, string basePath = null)
        {
            NanUI.RegisterCustomResourceHandler(() => new AssembledResource(assembly, scheme, domain, basePath));
            return _;
        }
    }
}
