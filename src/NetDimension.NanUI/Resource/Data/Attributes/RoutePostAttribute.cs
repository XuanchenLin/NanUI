using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RoutePostAttribute
    : RouteMethodAttribute
{
    public RoutePostAttribute(string routePath = null)
: base(Method.POST, routePath)
    {

    }
}
