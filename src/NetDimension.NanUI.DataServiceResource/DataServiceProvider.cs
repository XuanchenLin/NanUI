using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text;
using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.DataServiceResource
{
    public sealed class DataServiceProvider
    {
        const string SERVICE_SUFFIX = "Service";

        internal SchemeConfiguration Configuration { get; }

        readonly List<RouteConfiguration> _routes = new List<RouteConfiguration>();

        internal IEnumerable<RouteConfiguration> Routes => _routes;

        private DataServiceProvider(SchemeConfiguration configuration)
        {
            Configuration = configuration;
        }


        internal static DataServiceProvider Create(SchemeConfiguration schemeConfiguration)
        {
            var domainName = $"{schemeConfiguration.DomainName}".ToLower();

            if (string.IsNullOrEmpty(domainName))
            {
                throw new ArgumentNullException($"DomainName in {nameof(SchemeConfiguration)} must not be null.");
            }

            if (WinFormium.Runtime.Container.IsRegistered<DataServiceProvider>(domainName))
            {
                throw new ArgumentException($"Provider with same domain name \"{domainName}\" has already existed.");
            }


            var provider = new DataServiceProvider(schemeConfiguration);

            WinFormium.Runtime.Container.RegisterInstance(provider, domainName);

            return provider;
        }

        public static DataServiceProvider GetDataServiceProvider(string domainName)
        {
            domainName = $"{domainName}".ToLower();

            if (string.IsNullOrEmpty(domainName))
            {
                throw new ArgumentNullException($"DomainName in {nameof(SchemeConfiguration)} must not be null.");
            }

            if (!WinFormium.Runtime.Container.IsRegistered<DataServiceProvider>(domainName))
            {
                return null;
            }

            return WinFormium.Runtime.Container.GetInstance<DataServiceProvider>(domainName);
        }

        public static bool RemoveDataServiceProvider(string domainName)
        {
            domainName = $"{domainName}".ToLower();

            if (string.IsNullOrEmpty(domainName))
            {
                throw new ArgumentNullException($"DomainName in {nameof(SchemeConfiguration)} must not be null.");
            }

            if (!WinFormium.Runtime.Container.IsRegistered<DataServiceProvider>(domainName))
            {
                return false;
            }

            WinFormium.Runtime.Container.UnregisterHandler<DataServiceProvider>(domainName);

            return true;


        }

        public void ImportDataServiceAssembly(string fileName)
        {
            if (File.Exists(fileName))
            {
                var assembly = Assembly.LoadFrom(fileName);
                ImportDataServiceAssembly(assembly);
            }

        }

        public void ImportDataServiceAssembly(Assembly assembly)
        {
            if(assembly == null)
            {
                throw new ArgumentNullException($"{nameof(assembly)}");
            }

            var services = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(DataService)));

            foreach (var service in services)
            {
                ImportDataService(service);
            }
        }

        public void ImportDataServiceAssemblies(string[] files)
        {
            foreach (var fileName in files)
            {
                ImportDataServiceAssembly(fileName);
            }
        }

        public void ImportDataServiceAssemblies(string directoryName)
        {
            if (Directory.Exists(directoryName))
            {
                foreach (var fileName in Directory.EnumerateFiles(directoryName, "*.dll"))
                {
                    ImportDataServiceAssembly(fileName);
                }
            }
        }

        public void AddDataSevice(DataService service)
        {
            if(service == null)
            {
                throw new ArgumentNullException($"{nameof(service)}");
            }

            ImportDataService(service);
        }

        private void ImportDataService(Type type)
        {

            if (!type.IsSubclassOf(typeof(DataService)))
            {
                throw new TypeLoadException();
            }

            var instance = (DataService)Activator.CreateInstance(type);


            ImportDataService(instance);
        }

        private void ImportDataService<T>(T instance) where T : DataService
        {
            

            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            var type = instance.GetType();

            if (type.Name.EndsWith(SERVICE_SUFFIX))
            {
                var basePaths = new List<string>();

                var serviceName = type.Name.Substring(0, type.Name.LastIndexOf(SERVICE_SUFFIX));

                var dataRouteAttributes = type.GetCustomAttributes(typeof(DataRouteAttribute), false);

                if (dataRouteAttributes != null && dataRouteAttributes.Length > 0)
                {
                    foreach (DataRouteAttribute dataRouteAttr in dataRouteAttributes)
                    {
                        serviceName = dataRouteAttr.RoutePath.Replace(@"\", @"/"); ;
                        serviceName = serviceName.Trim('/');

                        basePaths.Add(serviceName);
                    }
                }
                else
                {
                    basePaths.Add(serviceName);
                }

                basePaths = basePaths.Distinct().ToList();


                var actions = type.GetMethods().Where(x => x.ReturnType.IsAssignableFrom(typeof(ResourceResponse)));


                foreach (var actionInfo in actions)
                {
                    var actionParams = actionInfo.GetParameters().Select(x => Expression.Parameter(x.ParameterType, x.Name)).ToArray();
                    var caller = Expression.Call(Expression.Constant(instance), actionInfo, actionParams);
                    var actionDelegate = Expression.Lambda(caller, actionParams).Compile() as Func<ResourceRequest, ResourceResponse>;

                    if (actionDelegate == null)
                    {
                        continue;
                    }
                    

                    var routeMethodAttributes = actionInfo.GetCustomAttributes(typeof(RouteMethodAttribute), true);

                    if(routeMethodAttributes!=null && routeMethodAttributes.Length > 0)
                    {
                        foreach (RouteMethodAttribute routeMehtodAttr in routeMethodAttributes)
                        {
                            var path = string.Empty;
                            var method = Method.None;

                            if (routeMehtodAttr != null)
                            {
                                method = routeMehtodAttr.RouteMethod;

                                if (string.IsNullOrEmpty(routeMehtodAttr.RoutePath))
                                {
                                    path = actionInfo.Name;
                                }
                                else
                                {
                                    path = routeMehtodAttr.RoutePath.Replace(@"\", @"/");
                                    path = path.TrimEnd('/');
                                }
                            }
                            else
                            {
                                path = actionInfo.Name;
                            }


                            if (path.StartsWith("~") || path.StartsWith("/"))
                            {
                                path = path.Length > 1 ? path.Substring(1) : string.Empty;
                                path = path.Trim('/');
                            }

                            foreach (var basePath in basePaths)
                            {

                                CreateRouteConfiguration(path, basePath, method, actionDelegate);


                            }
                        }
                    }
                    else
                    {
                        var path = actionInfo.Name;

                        foreach (var basePath in basePaths)
                        {
                            CreateRouteConfiguration(path, basePath, Method.None, actionDelegate);
                        }
                    }


                }

            }
        }

        private void CreateRouteConfiguration(string path, string basePath, Method method, Func<ResourceRequest, ResourceResponse> actionDelegate)
        {
            var routePath = $"{basePath}/{path}".Trim('/').ToLower();

            if(_routes.Any(x=>x.RoutePath == routePath &&  x.RouteMethod == method))
            {
                return;
            }

            _routes.Add(new RouteConfiguration(method, routePath, actionDelegate));
        }


    }
}
