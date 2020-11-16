using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.EmbeddedFileResource
{
    internal sealed class ResourceHandler : ResourceHandlerBase
    {
        protected override bool DisableCORS => true;

        public ResourceHandler(SchemeConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SchemeConfiguration Configuration { get; }


        // https://stackoverflow.com/questions/5769705/retrieving-embedded-resources-with-special-characters


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

            var filePath = response.RelativePath;



            if (!string.IsNullOrEmpty(Configuration.RootPath))
            {
                filePath = $"{Configuration.RootPath.Trim('/', '\\')}/{filePath}".Trim('/');
            }

            var endTrimIndex = filePath.LastIndexOf('/');


            if (endTrimIndex > -1)
            {
                var path = filePath.Substring(0, endTrimIndex);
                path = path.Replace("-", "_");
                path = path.Replace("/", ".");
                if(Regex.IsMatch(path, "\\.(\\d+)"))
                {
                    path = Regex.Replace(path, "\\.(\\d+)", "._$1");
                }

                filePath = $"{path}{filePath.Substring(endTrimIndex)}";
            }



            var resourceName = $"{mainAssembly.GetName().Name}.{filePath.Replace('/', '.')}";


            Assembly satelliteAssembly = null;

            try
            {
                var fileInfo = new FileInfo(new Uri(mainAssembly.EscapedCodeBase).LocalPath);

                var satelliteFilePath = Path.Combine(fileInfo.DirectoryName, $"{Thread.CurrentThread.CurrentCulture}", $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}.resources.dll");

                if (File.Exists(satelliteFilePath))
                {
                    satelliteAssembly = mainAssembly.GetSatelliteAssembly(Thread.CurrentThread.CurrentCulture);
                }

            }
            catch
            {

            }




            var embeddedResources = mainAssembly.GetManifestResourceNames().Select(x => new { Target = mainAssembly, Name = x, IsSatellite = false });

            if (satelliteAssembly != null)
            {

                string ProcessCultureName(string filename) => $"{Path.GetFileNameWithoutExtension(Path.GetFileName(filename))}.{Thread.CurrentThread.CurrentCulture.Name}{Path.GetExtension(filename)}";

                embeddedResources = embeddedResources.Union(satelliteAssembly.GetManifestResourceNames().Select(x => new { Target = satelliteAssembly, Name = ProcessCultureName(x), IsSatellite = true }));
            }


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


            if (resource != null)
            {
                var manifestResourceName = resourceName;

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
}
