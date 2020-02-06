using Chromium;
using NetDimension.NanUI.ResourceHandler;
using NetDimension.NanUI.RestfulService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI
{
    public class RestfulServiceResourceHandler : ResourceHandlerBase
    {


        public RestfulServiceResourceHandler()
        {
        }

        protected override FormiumResponse GetResponse(FormiumRequest request)
        {

            var relativePath = request.Uri.LocalPath;
            relativePath = relativePath.Trim('/');


            var provider = RestfulServiceProvider.GetServiceProvider(request.Uri.Host);

            var route = provider?.Routes?.GetRoute(request.Method, relativePath);

            if(route == null)
            {
                return new FormiumResponse
                {
                    Status = (int)System.Net.HttpStatusCode.NotFound
                };
            }

            return route.Invoke(request);
        }
    }
}
