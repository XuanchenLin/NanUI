using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public sealed class RouteMergeAttribute
    : RouteMethodAttribute
{
    public RouteMergeAttribute(string routePath = null)
: base(Method.MERGE, routePath)
    {

    }
}
