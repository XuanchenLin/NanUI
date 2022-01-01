using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RoutePatchAttribute
    : RouteMethodAttribute
{
    public RoutePatchAttribute(string routePath = null)
: base(Method.PATCH, routePath)
    {

    }
}
