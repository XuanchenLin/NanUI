using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.LocalFileResource
{
    internal class ResourceHandler : ResourceHandlerBase
    {
        protected override bool DisableCORS => true;

        public ResourceHandler(SchemeConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SchemeConfiguration Configuration { get; }

        protected override ResourceResponse GetResourceResponse(ResourceRequest request)
        {

            var response = new ResourceResponse(request);

            if (request.Method != Method.GET)
            {
                response.HttpStatus = System.Net.HttpStatusCode.NotFound;

                return response;
            }

            var filePath = response.RelativePath;

            var physicalFilePath = Path.Combine(Configuration.LocalResourceDiretory, filePath);

            if (!response.HasFileName) 
            {
                foreach (var defaultFileName in SchemeOptions.DefaultFileName)
                {
                    physicalFilePath = Path.Combine(physicalFilePath, defaultFileName);

                    if (File.Exists(physicalFilePath))
                    {
                        break;
                    }
                }    
            }

            if (!File.Exists(physicalFilePath) && Configuration.OnFallback != null)
            {
                var fallbackFile = Configuration.OnFallback.Invoke(filePath);

                physicalFilePath = Path.GetFullPath( Path.Combine(Configuration.LocalResourceDiretory, fallbackFile));
            }



            if (File.Exists(physicalFilePath))
            {
                response.ContentStream = File.OpenRead(physicalFilePath);
                response.MimeType = CefRuntime.GetMimeType(Path.GetExtension(physicalFilePath).Trim('.')) ?? "text/plain";
            }
            else
            {
                response.HttpStatus = System.Net.HttpStatusCode.NotFound;
            }

            return response;


        }
    }
}
