
using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RoutePutAttribute
    : RouteMethodAttribute
{
    public RoutePutAttribute(string routePath = null)
: base(Method.PUT, routePath)
    {

    }
}
