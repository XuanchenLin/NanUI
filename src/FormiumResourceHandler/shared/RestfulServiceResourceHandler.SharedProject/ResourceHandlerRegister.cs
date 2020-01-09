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
        public static NanUI UserRestfulService(this NanUI _, ResourceHandlerScheme scheme, string domain, Action<RestfulService.RestfulServiceProvider> provider = null)
        {


            NanUI.RegisterCustomResourceHandler(() =>
            {
                var resourceHandler = new RestfulServiceResource(scheme, domain);

                provider?.Invoke(RestfulService.RestfulServiceProvider.Create(resourceHandler));

                return resourceHandler;

            });
            return _;
        }
    }
}
