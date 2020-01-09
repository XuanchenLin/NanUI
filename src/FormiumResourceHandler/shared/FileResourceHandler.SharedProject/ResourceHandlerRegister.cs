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
        public static NanUI UseFileResource(this NanUI _, ResourceHandlerScheme scheme, string domain, string basePath)
        {
            NanUI.RegisterCustomResourceHandler(() => new FileResource(scheme, domain, basePath));
            return _;
        }
    }
}
