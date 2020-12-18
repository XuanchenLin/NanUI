using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.DataServiceResource
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DataRouteAttribute : Attribute
    {
        public DataRouteAttribute(string routePath = null)
        {
            RoutePath = routePath;
        }

        public string RoutePath { get; }
    }
}
