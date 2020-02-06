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
        public static Bootstrap UseFileResource(this Bootstrap _, ResourceHandlerScheme scheme, string domain, string basePath)
        {
            Bootstrap.RegisterCustomResourceHandler(() => new FileResource(scheme, domain, basePath));
            return _;
        }
    }
}
