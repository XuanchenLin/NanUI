using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.DataServiceResource
{
    internal class ResourceHandler : ResourceHandlerBase
    {


        protected override bool DisableCORS => true;

        public ResourceHandler(SchemeConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SchemeConfiguration Configuration { get; }

        protected override ResourceResponse GetResourceResponse(ResourceRequest request)
        {
            var response = new ResourceResponse(request);



            var provider = DataServiceProvider.GetDataServiceProvider(Configuration.DomainName);


            if (string.IsNullOrEmpty(request.Uri.Host))
            {

                response.HttpStatus = System.Net.HttpStatusCode.BadRequest;

                return response;
            }

            if(provider == null)
            {
                response.HttpStatus = System.Net.HttpStatusCode.NotFound;
                return response;
            }

            var relativePath = request.Uri.LocalPath;
            relativePath = relativePath.Trim('/');


            

            if(request.Method == Method.OPTIONS && provider?.Routes.SingleOrDefault(x=>x.RoutePath.Equals( relativePath, StringComparison.CurrentCultureIgnoreCase)) != null)
            {
                //if (!string.IsNullOrEmpty(request.Headers.Get("origin")))
                //{
                //    response.Headers.Set(ACCESS_CONTROL_ALLOW_ORIGIN, request.Headers.Get("origin"));
                //    response.Headers.Set(ACCESS_CONTROL_MAX_AGE, "3600");
                //}

                return response;
            }

            var route = provider?.Routes.SingleOrDefault(x => x.RoutePath.Equals(relativePath, StringComparison.CurrentCultureIgnoreCase) && (x.RouteMethod == request.Method || x.RouteMethod == Method.None));


            if(route == null)
            {
                response.HttpStatus = System.Net.HttpStatusCode.NotFound;
                return response;
            }



            try
            {
                response = route.Execute(request);

                if (response == null)
                {
                    response = new ResourceResponse();
                    response.HttpStatus = System.Net.HttpStatusCode.InternalServerError;
                }
            }
            catch(Exception ex)
            {
                response = new ResourceResponse();
                response.HttpStatus = System.Net.HttpStatusCode.InternalServerError;
                response.TextContent(ex.ToString());
            }

            //response.Headers.Set(ACCESS_CONTROL_ALLOW_HEADERS, "*");
            //response.Headers.Set(ACCESS_CONTROL_ALLOW_METHODS, "*");

            //if (!string.IsNullOrEmpty(request.Headers.Get("origin")))
            //{
            //    response.Headers.Set(ACCESS_CONTROL_ALLOW_ORIGIN, request.Headers.Get("origin"));
            //    response.Headers.Set(ACCESS_CONTROL_MAX_AGE, "3600");
            //}


            return response;
        }
    }
}
