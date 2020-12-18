using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RoutePatchAttribute
        : RouteMethodAttribute
    {
        public RoutePatchAttribute(string routePath = null)
    : base(Method.PATCH, routePath)
        {

        }
    }
}
