using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RouteGetAttribute
    : RouteMethodAttribute
{
    public RouteGetAttribute(string routePath = null)
        : base(Method.GET, routePath)
    {

    }
}
