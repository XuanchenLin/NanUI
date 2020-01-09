using NetDimension.Formium.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace NetDimension.Formium
{
    internal class AssembledResourceHandler : ResourceHandlerBase
    {
        static readonly Dictionary<string, FileStreamResponse> WebResources = new Dictionary<string, FileStreamResponse>();

        private Assembly resourceAssembly;

        private string wwwroot = null;
        public AssembledResourceHandler(Assembly resourceAssembly, string wwwroot=null)
        {
            this.resourceAssembly = resourceAssembly;
            this.wwwroot = wwwroot;
        }

        protected override FormiumResponse GetResponse(FormiumRequest request)
        {
            var requestUrl = request.RequestUrl;

            if (WebResources.ContainsKey(requestUrl))
            {
                return WebResources[requestUrl];
            }

            var mainAssembly = resourceAssembly;

            var response = WebResources[requestUrl] = new FileStreamResponse(request, true);
            
            if (request.Method != Method.GET)
            {
                response.Status = (int)System.Net.HttpStatusCode.NotFound;
                return response;
            }

            var filePath = response.RelativePath;

            if (!string.IsNullOrEmpty(wwwroot))
            {
                filePath = $"{wwwroot}/{filePath}";
            }

            var endTrimIndex = filePath.LastIndexOf('/');

            if (endTrimIndex > -1)
            {
                var tmp = filePath.Substring(0, endTrimIndex);
                tmp = tmp.Replace("-", "_");

                filePath = string.Format("{0}{1}", tmp, filePath.Substring(endTrimIndex));
            }

            var resourcePath = string.Format("{0}.{1}", mainAssembly.GetName().Name, filePath.Replace('/', '.'));

            Assembly satelliteAssembly = null;

            try
            {
                satelliteAssembly = mainAssembly.GetSatelliteAssembly(System.Threading.Thread.CurrentThread.CurrentCulture);
            }
            catch
            {

            }

            var resourceNames = mainAssembly.GetManifestResourceNames().Select(x => new { TargetAssembly = mainAssembly, Name = x, IsSatellite = false });

            if (satelliteAssembly != null)
            {
                string HandleCultureName(string name)
                {
                    var cultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                    var fileInfo = new System.IO.FileInfo(name);

                    return $"{System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name)}.{cultureName}{fileInfo.Extension}";
                }

                resourceNames = resourceNames.Union(satelliteAssembly.GetManifestResourceNames().Select(x => new { TargetAssembly = satelliteAssembly, Name = HandleCultureName(x), IsSatellite = true }));
            }

            var resource = resourceNames.SingleOrDefault(p => p.Name.Equals(resourcePath, StringComparison.CurrentCultureIgnoreCase));

            var manifestResourceName = resourcePath;
            if (resource != null && resource.IsSatellite)
            {
                var fileInfo = new System.IO.FileInfo(manifestResourceName);
                manifestResourceName = $"{System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name))}{fileInfo.Extension}";
            }

            if (resource != null && resource.TargetAssembly.GetManifestResourceStream(manifestResourceName) != null)
            {

                response.ContentStream = resource.TargetAssembly.GetManifestResourceStream(manifestResourceName);

                WebResources[requestUrl] = response;

                return response;
            }

            response.Status = (int)System.Net.HttpStatusCode.BadRequest;


            return response;


        }

        
    }
}
