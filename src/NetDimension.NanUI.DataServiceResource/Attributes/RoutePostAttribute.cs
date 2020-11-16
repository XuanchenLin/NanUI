using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RoutePostAttribute
        : RouteMethodAttribute
    {
        public RoutePostAttribute(string routePath)
    : base(Method.POST, routePath)
        {

        }
    }
}
