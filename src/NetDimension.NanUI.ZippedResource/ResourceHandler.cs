using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using NetDimension.NanUI.ResourceHandler;

namespace NetDimension.NanUI.ZippedResource
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

            using (var stream = new MemoryStream(Configuration.ZipFileBuffer))
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Read))
            {

                var fileEntry = archive.GetEntry(filePath);

                if(fileEntry == null && !response.HasFileName)
                {
                    foreach (var defaultFileName in SchemeOptions.DefaultFileName)
                    {
                        var searchPath = string.Join("/", filePath.TrimEnd('/'), defaultFileName).TrimStart('/');

                        fileEntry = archive.GetEntry(searchPath);

                        if(fileEntry != null)
                        {
                            response.MimeType = GetMimeType(defaultFileName);
                            break;
                        }
                    }
                }

                if(fileEntry == null && Configuration.OnFallback != null)
                {
                    var fallbackFile = Configuration.OnFallback.Invoke(filePath);
                    
                    fileEntry = archive.GetEntry(fallbackFile);

                    if (fileEntry != null)
                    {
                        response.MimeType = GetMimeType(fallbackFile);
                        
                    }
                }

                if (fileEntry != null)
                {
                    using (var entryStream = fileEntry.Open())
                    {
                        var fileStream = new MemoryStream();
                        entryStream.CopyTo(fileStream);
                        response.ContentStream = fileStream;
                        entryStream.Close();
                    }
                }
                else
                {
                    response.HttpStatus = System.Net.HttpStatusCode.NotFound;
                }

                stream.Close();
            }


            return response;

        }

    }
}
