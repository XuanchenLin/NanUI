using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class RouteDeleteAttribute
        : RouteMethodAttribute
    {
        public RouteDeleteAttribute(string routePath = null)
    : base(Method.DELETE, routePath)
        {

        }
    }
}
