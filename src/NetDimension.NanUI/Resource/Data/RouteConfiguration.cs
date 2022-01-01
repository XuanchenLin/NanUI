using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

internal sealed class RouteConfiguration
{
    public Method RouteMethod { get; }

    public string RoutePath { get; }
    private Func<ResourceRequest, ResourceResponse> RequestHandler { get; }

    public RouteConfiguration(Method routeMethod, string routePath, Func<ResourceRequest, ResourceResponse> handler)
    {
        RouteMethod = routeMethod;
        RoutePath = routePath;
        RequestHandler = handler;
    }

    public ResourceResponse Execute(ResourceRequest request)
    {
        return RequestHandler?.Invoke(request);
    }
}