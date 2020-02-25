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
        public static Bootstrap UseRestfulService(this Bootstrap _, ResourceHandlerScheme scheme, string domain, Action<RestfulService.RestfulServiceProvider> provider = null)
        {


            Bootstrap.RegisterCustomResourceHandler(() =>
            {
                var resourceHandler = new RestfulServiceResource(scheme, domain);

                provider?.Invoke(RestfulService.RestfulServiceProvider.Create(resourceHandler));

                return resourceHandler;

            });
            return _;
        }
    }
}
