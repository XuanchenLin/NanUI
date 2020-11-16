using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RouteOptionsAttribute
        : RouteMethodAttribute
    {
        public RouteOptionsAttribute(string routePath)
    : base(Method.OPTIONS, routePath)
        {

        }
    }
}
