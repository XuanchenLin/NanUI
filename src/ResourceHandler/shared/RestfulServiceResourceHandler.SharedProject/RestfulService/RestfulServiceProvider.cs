using NetDimension.NanUI.ResourceHandler;
using ColoredConsole;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI.RestfulService
{
    public class RestfulServiceProvider
    {

        static Dictionary<string, RestfulServiceProvider> Providers { get; } = new Dictionary<string, RestfulServiceProvider>();


        internal static RestfulServiceProvider Create(RestfulServiceResource resource)
        {
            var key = resource.DomainName.ToLower();

            if (Providers.ContainsKey(key))
            {
                throw new ArgumentOutOfRangeException();
            }
            var provider = Providers[key] = new RestfulServiceProvider();
            return provider;
        }

        public static RestfulServiceProvider GetServiceProvider(string domainName)
        {
            var key = domainName.ToLower();

            if (Providers.ContainsKey(key))
            {
                return Providers[key];
            }

            return null;
            //throw new ArgumentOutOfRangeException();
        }

        internal RouteCollection Routes { get; }


        private RestfulServiceProvider()
        {
            Routes = new RouteCollection();
        }

        public void ImportServiceAssembly(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(fileName);
                    ImportServiceAssembly(assembly);
                }
                catch (Exception ex)
                {
                    Bootstrap.Log("[ResourceHandler:".Green(), $"{this.GetType().Name}".Cyan(), "]".Green(), " ", "[LOAD FAILED]:".Red(), $"{Path.GetFileName(fileName)}".Gray());
                    Bootstrap.Text($"{ex}");
                }
            }
            else
            {
                Bootstrap.Log("[ResourceHandler:".Green(), $"{this.GetType().Name}".Cyan(), "]".Green(), " ", "[NOT FOUND]:".Red(), $"{Path.GetFileName(fileName)}".Gray());
            }


        }

        public void ImportServiceAssemblies(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                ImportServiceAssembly(fileName);
            }
        }

        public void ImportServiceAssemblies(string directoryName)
        {
            if (Directory.Exists(directoryName))
            {
                foreach (var fileName in Directory.EnumerateFiles(directoryName, "*.dll"))
                {
                    ImportServiceAssembly(fileName);
                }
            }
        }




        public void RegisterServiceController(ServiceController controller)
        {
            if (controller == null)
            {
                throw new NullReferenceException();
            }

            PrepareServiceController(controller.GetType(), controller);

        }


        public void ImportServiceAssembly(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException();
            }

            var loadable = from x in assembly.GetTypes() where /*Attribute.IsDefined(x, typeof(RouteAttribute)) &&*/ x.IsSubclassOf(typeof(ServiceController)) select x;

            foreach (var type in loadable)
            {
                PrepareServiceController(type);
            }
        }
        private void PrepareServiceController(Type type, object instance = null)
        {
            if (instance == null)
            {
                instance = Activator.CreateInstance(type);
            }

            var classRouteAttr = type.GetCustomAttributes(typeof(RouteAttribute), false).SingleOrDefault() as RouteAttribute;
            var basePath = string.Empty;

            if (classRouteAttr != null)
            {
                basePath = classRouteAttr.Path;
                basePath = basePath.Trim('/');
            }
            else
            {
                basePath = type.Name;

                if (basePath.EndsWith("Service", StringComparison.CurrentCultureIgnoreCase))
                {
                    basePath = basePath.Substring(0, basePath.LastIndexOf("Service", StringComparison.CurrentCultureIgnoreCase));
                }
            }

            var methodInfos = type.GetMethods().Where(m => m.ReturnType.IsAssignableFrom(typeof(FormiumResponse)) && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(FormiumRequest)));

            foreach (var methodInfo in methodInfos)
            {
                var httpMethodAttr = methodInfo.GetCustomAttributes(typeof(RouteHttpMethodAttribute), false).SingleOrDefault() as RouteHttpMethodAttribute;

                var path = string.Empty;
                var httpMethod = Method.None;

                if (httpMethodAttr != null)
                {
                    httpMethod = httpMethodAttr.Method;


                    if (string.IsNullOrEmpty(httpMethodAttr.Path))
                    {
                        path = methodInfo.Name;

                    }
                    else
                    {
                        path = httpMethodAttr.Path;
                        path = path.Trim('/');
                    }


                }
                else
                {
                    path = methodInfo.Name;
                }

                var routePath = $"{basePath}/{path}";

                if (path.StartsWith("~"))
                {
                    routePath = path.Length > 1 ? path.Substring(1) : string.Empty;

                    routePath = routePath.Trim('/');
                }
                var methodParams = methodInfo.GetParameters().Select(x => Expression.Parameter(x.ParameterType, x.Name)).ToArray();
                var call = Expression.Call(Expression.Constant(instance), methodInfo, methodParams);
                var actionDelegate = Expression.Lambda(call, methodParams).Compile() as Func<FormiumRequest, FormiumResponse>;
                if (actionDelegate != null)
                {
                    var route = new Route(httpMethod, routePath, actionDelegate);
                    Routes.Add(route);
                }
            }

        }

    }
}
