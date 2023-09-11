using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

internal sealed class RouteConfiguration
{
    public Method RouteMethod { get; }

    public string RoutePath { get; }
    private Func<ResourceRequest, ResourceResponse> RequestHandler { get; }
    public MethodInfo ActionInfo { get; }

    public RouteConfiguration(Method routeMethod, string routePath, Func<ResourceRequest, ResourceResponse> handler, MethodInfo actionInfo)
    {
        RouteMethod = routeMethod;
        RoutePath = routePath;
        RequestHandler = handler;
        ActionInfo = actionInfo;
    }

    public ResourceResponse Execute(ResourceRequest request)
    {
        return RequestHandler?.Invoke(request);
    }
}
