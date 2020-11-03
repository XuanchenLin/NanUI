using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.ResourceHandler.InternalResource
{
    internal class InternalResourceHandler : ResourceHandlerBase
    {
        public InternalResourceHandler(InternalSchemeConfiguration internalSchemeConfiguration)
        {
            Configuration = internalSchemeConfiguration;
        }

        public InternalSchemeConfiguration Configuration { get; }

        protected override ResourceResponse GetResourceResponse(ResourceRequest request)
        {
            var response = new ResourceResponse(request);
            if (request.Method != Method.GET)
            {
                response.HttpStatus = System.Net.HttpStatusCode.NotFound;

                return response;
            }

            response.TextContent("Hello NanUI!");

            return response;

        }
    }
}
