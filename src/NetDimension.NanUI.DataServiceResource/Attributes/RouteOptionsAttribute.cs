using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RouteOptionsAttribute
        : RouteMethodAttribute
    {
        public RouteOptionsAttribute(string routePath = null)
    : base(Method.OPTIONS, routePath)
        {

        }
    }
}
