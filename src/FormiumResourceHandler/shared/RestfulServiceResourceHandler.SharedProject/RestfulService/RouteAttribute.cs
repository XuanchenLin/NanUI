using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.Formium.RestfulService
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class RouteAttribute : Attribute
    {
        public RouteAttribute(string path)
        {
            Path = path;
        }
        public string Path { get; set; }
    }
}
