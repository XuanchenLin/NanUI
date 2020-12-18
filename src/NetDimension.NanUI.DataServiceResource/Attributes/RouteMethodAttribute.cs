using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.DataServiceResource
{

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteMethodAttribute : Attribute
    {

        public RouteMethodAttribute(Method method, string routePath = null)
        {
            RouteMethod = method;
            RoutePath = routePath;
        }
        public Method RouteMethod { get; set; }
        public string RoutePath { get; set; }
    }
}
