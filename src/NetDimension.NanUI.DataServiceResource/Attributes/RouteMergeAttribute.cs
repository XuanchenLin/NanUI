using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RouteMergeAttribute
        : RouteMethodAttribute
    {
        public RouteMergeAttribute(string routePath = null)
    : base(Method.MERGE, routePath)
        {

        }
    }
}
