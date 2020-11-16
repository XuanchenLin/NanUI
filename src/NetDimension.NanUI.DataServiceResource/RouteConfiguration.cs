using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI.DataServiceResource
{
    internal sealed class RouteConfiguration
    {
        public Method RouteMethod { get; }

        public string RoutePath { get; }
        private Func<ResourceRequest, ResourceResponse> _requestHandler { get; }

        public RouteConfiguration(Method routeMethod, string routePath, Func<ResourceRequest, ResourceResponse> handler)
        {
            RouteMethod = routeMethod;
            RoutePath = routePath;
            _requestHandler = handler;
        }

        public ResourceResponse Execute(ResourceRequest request)
        {
            return _requestHandler?.Invoke(request);
        }

        //public Task<ResourceResponse> ExecuteAsync(ResourceRequest request)
        //{
        //    return Task.Run(() => _requestHandler?.Invoke(request));
        //}
    }
}
