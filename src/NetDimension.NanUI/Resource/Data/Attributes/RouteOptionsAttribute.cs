using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RouteOptionsAttribute
    : RouteMethodAttribute
{
    public RouteOptionsAttribute(string routePath = null)
: base(Method.OPTIONS, routePath)
    {

    }
}
