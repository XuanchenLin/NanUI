// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
internal class EmbeddedFileResourceHandler : ResourceHandler
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefRequest Request { get; }
    public EmbeddedFileResourceOptions Options { get; }
    public Assembly ResourceAssembly => Options.ResourceAssembly;

    public string DefaultNamespace => Options.DefaultNamespace ?? ResourceAssembly.EntryPoint?.DeclaringType?.Namespace ?? ResourceAssembly.GetName().Name!;

    protected override bool EnableCORSPolicy => true;

    public EmbeddedFileResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request, EmbeddedFileResourceOptions options)
    {
        Browser = browser;
        Frame = frame;
        Request = request;
        Options = options;
    }

    private string GetResourceName(string relativePath, string? rootPath)
    {
        var filePath = relativePath;
        if (!string.IsNullOrEmpty(rootPath))
        {
            filePath = $"{rootPath?.Trim('/', '\\')}/{filePath.Trim('/', '\\')}";
        }

        filePath = filePath.Replace('\\', '/');

        var endTrimIndex = filePath.LastIndexOf('/');


        if (endTrimIndex > -1)
        {
            // https://stackoverflow.com/questions/5769705/retrieving-embedded-resources-with-special-characters

            var path = filePath.Substring(0, endTrimIndex);
            path = path.Replace("/", ".");
            if (Regex.IsMatch(path, "\\.(\\d+)"))
            {
                path = Regex.Replace(path, "\\.(\\d+)", "._$1");
            }

            const string replacePartterns = "`~!@$%^&(),-=";

            foreach (var parttern in replacePartterns)
            {
                path = path.Replace(parttern, '_');
            }


            filePath = $"{path}{filePath.Substring(endTrimIndex)}".Trim('/');
        }

        var resourceName = $"{DefaultNamespace}.{filePath.Replace('/', '.')}";

        return resourceName;
    }




    protected override ResourceResponse GetResourceResponse(ResourceRequest request)
    {
        var requestUrl = request.RequestUrl;

        var mainAssembly = ResourceAssembly;

        var response = new ResourceResponse();

        if (request.Method != ResourceRequestMethod.GET)
        {
            response.HttpStatus = StatusCodes.Status404NotFound;

            return response;
        }

        var resourceName = GetResourceName(request.RelativePath, Options.EmbeddedResourceDirectoryName);

        Assembly? satelliteAssembly = null;

        try
        {
            var fileInfo = new FileInfo(new Uri(mainAssembly.Location).LocalPath);

            var satelliteFilePath = Path.Combine(fileInfo.DirectoryName ?? string.Empty, $"{Thread.CurrentThread.CurrentCulture}", $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}.resources.dll");

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

        var namespaces = mainAssembly.DefinedTypes.Select(x => x.Namespace).Distinct().ToArray();


        string ChangeResourceName(string rawName)
        {
            var targetName = namespaces.Where(x => x != null && !string.IsNullOrEmpty(x) && rawName.StartsWith(x!)).OrderByDescending(x=>x!.Length).FirstOrDefault();

            if(targetName == null)
            {
                targetName = DefaultNamespace;
            }

            return $"{DefaultNamespace}{rawName.Substring($"{targetName}".Length)}";
        }

        embeddedResources = embeddedResources.Select(x =>
        new
        {
            x.Target,
            //Name = $"{DefaultNamespace}{x.Name.Substring($"{DefaultNamespace}".Length)}",
            Name= ChangeResourceName(x.Name),
            x.ResourceName,
            x.IsSatellite
        });


        var resource = embeddedResources.SingleOrDefault(x => x.Name.Equals(resourceName, StringComparison.CurrentCultureIgnoreCase));


        if (resource == null && !request.HasFileName)
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

        if (resource == null && Options.OnFallback != null)
        {
            var fallbackFile = Options.OnFallback.Invoke(requestUrl);

            resourceName = GetResourceName(fallbackFile, Options.EmbeddedResourceDirectoryName);

            resource = embeddedResources.SingleOrDefault(x => x.Name.Equals(resourceName, StringComparison.CurrentCultureIgnoreCase));
        }

        //System.Diagnostics.Debug.WriteLine($"Resource: {resourceName}");
        //var names = embeddedResources.Select(x => x.Name).ToArray();

        //System.Diagnostics.Debug.WriteLine($"Resources: {string.Join("\r\n", names)}");

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

                response.ContentBody = contenStream;
                response.ContentType = CefRuntime.GetMimeType(Path.GetExtension(resourceName).Trim('.')) ?? "text/plain";
                return response;
            }
        }

        response.HttpStatus = StatusCodes.Status404NotFound;

        return response;
    }
}
