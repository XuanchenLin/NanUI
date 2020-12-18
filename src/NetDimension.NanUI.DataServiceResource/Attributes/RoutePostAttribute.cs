using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RoutePostAttribute
        : RouteMethodAttribute
    {
        public RoutePostAttribute(string routePath = null)
    : base(Method.POST, routePath)
        {

        }
    }
}
