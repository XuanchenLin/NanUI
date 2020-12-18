using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RouteHeadAttribute
        : RouteMethodAttribute
    {
        public RouteHeadAttribute(string routePath = null)
    : base(Method.HEAD, routePath)
        {

        }
    }
}
