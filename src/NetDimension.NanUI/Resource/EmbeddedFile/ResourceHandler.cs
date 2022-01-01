using NetDimension.NanUI.Browser.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Resource.EmbeddedFile;

internal class ResourceHandler : ResourceHandlerBase
{
    protected override bool DisableCORS => true;

    public ResourceHandler(SchemeConfiguration configuration)
    {
        Configuration = configuration;
    }

    public SchemeConfiguration Configuration { get; }


    private string GetResourceName(string relativePath, string rootPath)
    {
        var filePath = relativePath;
        if (!string.IsNullOrEmpty(rootPath))
        {
            filePath = $"{rootPath.Trim('/', '\\')}/{filePath}";
        }

        var endTrimIndex = filePath.LastIndexOf('/');


        if (endTrimIndex > -1)
        {

            // https://stackoverflow.com/questions/5769705/retrieving-embedded-resources-with-special-characters

            var path = filePath.Substring(0, endTrimIndex);
            path = path.Replace("-", "_");
            path = path.Replace("/", ".");
            if (Regex.IsMatch(path, "\\.(\\d+)"))
            {
                path = Regex.Replace(path, "\\.(\\d+)", "._$1");
            }

            filePath = $"{path}{filePath.Substring(endTrimIndex)}".Trim('/');
        }

        var resourceName = $"{Configuration.DefaultNameSpace}.{filePath.Replace('/', '.')}";

        return resourceName;

    }



    protected override ResourceResponse GetResourceResponse(ResourceRequest request)
    {
        var requestUrl = request.RequestUrl;

        var mainAssembly = Configuration.ResourceAssebmly;

        var response = new ResourceResponse(request);

        if (request.Method != Method.GET)
        {
            response.HttpStatus = System.Net.HttpStatusCode.NotFound;

            return response;
        }

        var resourceName = GetResourceName(response.RelativePath, Configuration.RootPath);

        Assembly satelliteAssembly = null;

        try
        {
            var fileInfo = new FileInfo(new Uri(mainAssembly.Location).LocalPath);

            var satelliteFilePath = Path.Combine(fileInfo.DirectoryName, $"{Thread.CurrentThread.CurrentCulture}", $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}.resources.dll");

            if (File.Exists(satelliteFilePath))
            {
                satelliteAssembly = mainAssembly.GetSatelliteAssembly(Thread.CurrentThread.CurrentCulture);
            }
        }
        catch
        {

        }

        var embeddedResources = mainAssembly.GetManifestResourceNames().Select(x => new { Target = mainAssembly, Name = x, ResourceName = x, IsSatellite = false });

        if (satelliteAssembly != null)
        {
            static string ProcessCultureName(string filename) => $"{Path.GetFileNameWithoutExtension(Path.GetFileName(filename))}.{Thread.CurrentThread.CurrentCulture.Name}{Path.GetExtension(filename)}";

            embeddedResources = embeddedResources.Union(satelliteAssembly.GetManifestResourceNames().Select(x => new { Target = satelliteAssembly, Name = ProcessCultureName(x), ResourceName = ProcessCultureName(x), IsSatellite = true }));
        }

        embeddedResources = embeddedResources.Select(x => new { x.Target, Name = $"{Configuration.DefaultNameSpace}{x.Name.Substring($"{Configuration.DefaultNameSpace}".Length)}", x.ResourceName, x.IsSatellite, });


        var resource = embeddedResources.SingleOrDefault(x => x.Name.Equals(resourceName, StringComparison.CurrentCultureIgnoreCase));

        if (resource == null && !response.HasFileName)
        {
            foreach (var defaultFileName in SchemeOptions.DefaultFileName)
            {

                resourceName = string.Join(".", resourceName, defaultFileName);

                resource = embeddedResources.SingleOrDefault(x => x.Name.Equals(resourceName, StringComparison.CurrentCultureIgnoreCase));

                if (resource != null)
                {
                    break;
                }
            }
        }

        if (resource == null && Configuration.OnFallback != null)
        {
            var fallbackFile = Configuration.OnFallback.Invoke(requestUrl);

            //var test = Path.GetFullPath(fallbackFile);

            resourceName = GetResourceName(fallbackFile, Configuration.RootPath);

            resource = embeddedResources.SingleOrDefault(x => x.Name.Equals(resourceName, StringComparison.CurrentCultureIgnoreCase));

        }


        if (resource != null)
        {
            var manifestResourceName = resource.ResourceName;

            if (resource.IsSatellite)
            {
                manifestResourceName = $"{Path.GetFileNameWithoutExtension(Path.GetFileName(manifestResourceName))}{Path.GetExtension(manifestResourceName)}";
            }


            var contenStream = resource?.Target?.GetManifestResourceStream(manifestResourceName);

            if (contenStream != null)
            {

                response.ContentStream = contenStream;
                response.MimeType = CefRuntime.GetMimeType(Path.GetExtension(resourceName).Trim('.')) ?? "text/plain";
                return response;
            }
        }


        response.HttpStatus = System.Net.HttpStatusCode.NotFound;


        return response;
    }

}
