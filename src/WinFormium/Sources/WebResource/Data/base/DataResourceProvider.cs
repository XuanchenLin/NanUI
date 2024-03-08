// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public sealed class DataResourceProvider
{
    static Dictionary<string, DataResourceProvider> RegisteredProviders { get; } = new();

    private readonly List<DataResourceRoute> _routes = new();

    internal IEnumerable<DataResourceRoute> Routes => _routes;

    internal DataResourceOptions Options { get; }

    private DataResourceProvider(DataResourceOptions options)
    {
        Options = options;
    }

    internal static DataResourceProvider Create(DataResourceOptions options)
    {
        var domainName = GetUrlFromOptions(options);

        if (string.IsNullOrEmpty(domainName))
        {
            throw new ArgumentNullException(nameof(domainName), $"Argument must not be null.");
        }

        if (RegisteredProviders.ContainsKey(domainName))
        {
            throw new ArgumentException($"Domain name '{domainName}' is already registered.");
        }

        var provider = new DataResourceProvider(options);

        RegisteredProviders[domainName] = provider;

        return provider;
    }

    private static string GetUrlFromOptions(DataResourceOptions options)
    {
        return $"{options.Scheme}://{options.DomainName}".ToLower();
    }

    internal static DataResourceProvider? GetProvider(DataResourceOptions options)
    {
        var domainName = GetUrlFromOptions(options);

        if (!RegisteredProviders.ContainsKey(domainName)) return null;

        return RegisteredProviders[domainName];
    }

    public JsonSerializerOptions? DefaultJsonSerializerOptions { get; set; }

    internal static void RemoveProvider(DataResourceOptions options)
    {
        var domainName = GetUrlFromOptions(options);


        if (!RegisteredProviders.ContainsKey(domainName)) return;

        RegisteredProviders.Remove(domainName);
    }

    public void ImportFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            var assembly = Assembly.LoadFrom(fileName);
            ImportFromAssembly(assembly);
        }
    }

    public void ImportFromCurrentAssembly()
    {
        var assembly = Assembly.GetEntryAssembly();

        if(assembly == null) throw new InvalidOperationException("Entry assembly is null.");

        ImportFromAssembly(assembly);
    }

    public void ImportFromAssembly(Assembly assembly)
    {
        if (assembly == null)
        {
            throw new ArgumentNullException($"{nameof(assembly)}");
        }

        var services = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(DataResourceService)));

        foreach (var service in services)
        {
            ImportDataResourceService(service);
        }
    }

    public void ImportFromAssemblies(string[] files)
    {
        foreach (var fileName in files)
        {
            ImportFromFile(fileName);
        }
    }

    public void ImportFromDirectory(string directoryName)
    {
        if (Directory.Exists(directoryName))
        {
            foreach (var fileName in Directory.EnumerateFiles(directoryName, "*.dll"))
            {
                ImportFromFile(fileName);
            }
        }
    }

    private void ImportDataResourceService(Type type)
    {
        if (!type.IsSubclassOf(typeof(DataResourceService)))
        {
            throw new ArgumentNullException(nameof(type), $"Argument must not be null.");
        }

        const string SERVICE_SUFFIX = "Service";

        var basePaths = new List<string>();

        var serviceName = type.Name;


        if (type.Name.EndsWith(SERVICE_SUFFIX))
        {

            serviceName = serviceName.Substring(0, serviceName.LastIndexOf(SERVICE_SUFFIX));
        }

        var routePathAttributes = type.GetCustomAttributes(typeof(RoutePathAttribute), false) as RoutePathAttribute[];

        if (routePathAttributes != null && routePathAttributes.Length > 0)
        {
            foreach (var routePathAttr in routePathAttributes)
            {
                serviceName = routePathAttr.Path.Replace(@"\", @"/"); ;
                serviceName = serviceName.Trim('/');

                basePaths.Add(serviceName);
            }
        }
        else
        {
            basePaths.Add(serviceName);
        }

        basePaths = basePaths.Distinct().ToList();


        var serviceActions = type.GetMethods().Where(x => x.ReturnType.IsAssignableFrom(typeof(IResourceResult)) || x.ReturnType.IsAssignableFrom(typeof(Task<IResourceResult>)));


        foreach (var serviceAction in serviceActions)
        {
            var noActionAttributes = serviceAction.GetCustomAttributes(typeof(NoActionAttribute), true) as NoActionAttribute[];

            if (noActionAttributes != null && noActionAttributes.Length > 0) continue;

            var actionHttpMethodAttributes = serviceAction.GetCustomAttributes(typeof(HttpMethodAttribute), true) as HttpMethodAttribute[];

            if (actionHttpMethodAttributes != null)
            {
                foreach (var httpMethodAttr in actionHttpMethodAttributes)
                {
                    var path = string.Empty;
                    var method = ResourceRequestMethod.All;

                    if (httpMethodAttr == null)
                    {
                        path = serviceAction.Name;
                    }
                    else
                    {
                        method = httpMethodAttr.Method;

                        if (string.IsNullOrEmpty(httpMethodAttr.Path))
                        {
                            path = serviceAction.Name;
                        }
                        else
                        {
                            path = httpMethodAttr.Path!.Replace(@"\", @"/");
                            path = path.TrimEnd('/');
                        }
                    }

                    var paths = new List<string>();

                    if (path.StartsWith("/"))
                    {
                        paths.Add(path);
                    }
                    else
                    {
                        foreach (var basePath in basePaths)
                        {
                            paths.Add($"{basePath}/{path}");
                        }
                    }

                    paths = paths.Select(x => x.ToLower()).Distinct().ToList();

                    var route = new DataResourceRoute(method, paths.ToArray(), serviceAction, DefaultJsonSerializerOptions);

                    _routes.Add(route);
                }
            }
            else
            {
                var path = serviceAction.Name;

                var paths = new List<string>();


                foreach (var basePath in basePaths)
                {
                    paths.Add($"{basePath}/{path}");
                }

                paths = paths.Select(x => x.ToLower()).Distinct().ToList();

                var route = new DataResourceRoute(ResourceRequestMethod.All, paths.ToArray(), serviceAction, DefaultJsonSerializerOptions);

                _routes.Add(route);
            }
        }

    }






}
