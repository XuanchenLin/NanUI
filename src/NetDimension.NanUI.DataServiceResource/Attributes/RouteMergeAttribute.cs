using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RouteMergeAttribute
        : RouteMethodAttribute
    {
        public RouteMergeAttribute(string routePath)
    : base(Method.MERGE, routePath)
        {

        }
    }
}
