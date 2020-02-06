using Chromium;
using NetDimension.NanUI.ResourceHandler;
using NetDimension.NanUI.RestfulService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI
{
    internal class RestfulServiceResource : CustomResource
    {
        public RestfulServiceResource(ResourceHandlerScheme scheme, string domain)
            : base(scheme, domain)
        {
            //RouteCollection.Add(new Route(Method.None, "controller/info", (request) =>
            //{
            //    var info = @"{""message"":""Welcome to NanUI!""}";

            //    var response = new FormiumResponse()
            //    {
            //        MimeType = "application/json",
            //        ContentStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(info)),
                    
            //    };

            //    response.Headers["Access-Control-Allow-Origin"] = new string[] { "*" };

            //    return response;
            //}));
        }
        protected override ResourceHandlerBase GetResourceHandler(string schemeName, CfxBrowser browser, CfxFrame frame, CfxRequest request)
        {
            return new RestfulServiceResourceHandler();
        }
    }
}
