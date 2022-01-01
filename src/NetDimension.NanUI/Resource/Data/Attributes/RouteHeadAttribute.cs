using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RouteHeadAttribute
    : RouteMethodAttribute
{
    public RouteHeadAttribute(string routePath = null)
: base(Method.HEAD, routePath)
    {

    }
}
