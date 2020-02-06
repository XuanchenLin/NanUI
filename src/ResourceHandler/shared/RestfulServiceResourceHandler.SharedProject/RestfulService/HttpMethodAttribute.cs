using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.RestfulService
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpMethodAttribute : Attribute
    {

        public RouteHttpMethodAttribute(Method method = Method.None, string path=null)
        {
            Method = method;
            Path = path;
            
        }

        public string Path { get; set; }
        public Method Method { get; }

    }


    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpGetAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpGetAttribute(string path = null) :base(Method.GET, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpPostAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpPostAttribute(string path = null) : base(Method.POST, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpPutAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpPutAttribute(string path = null) : base(Method.PUT, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpDeleteAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpDeleteAttribute(string path = null) : base(Method.DELETE, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpHeadAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpHeadAttribute(string path = null) : base(Method.HEAD, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpOptionAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpOptionAttribute(string path = null) : base(Method.OPTIONS, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpPatchAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpPatchAttribute(string path = null) : base(Method.PATCH, path)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RouteHttpMergeAttribute : RouteHttpMethodAttribute
    {

        public RouteHttpMergeAttribute(string path = null) : base(Method.MERGE, path)
        {

        }
    }


}
