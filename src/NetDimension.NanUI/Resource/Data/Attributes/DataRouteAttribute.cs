
namespace NetDimension.NanUI.Resource.Data;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class DataRouteAttribute : Attribute
{
    public DataRouteAttribute(string routePath = null)
    {
        RoutePath = routePath;
    }

    public string RoutePath { get; }
}
