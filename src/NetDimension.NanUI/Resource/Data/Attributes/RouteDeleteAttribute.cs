
using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RouteDeleteAttribute
    : RouteMethodAttribute
{
    public RouteDeleteAttribute(string routePath = null)
: base(Method.DELETE, routePath)
    {

    }
}
