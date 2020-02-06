using Chromium;
using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace NetDimension.NanUI
{
    internal class FileResourceHandler : ResourceHandlerBase
    {

        private string wwwroot = null;
        private string physicalPath = null;

        public FileResourceHandler(string wwwroot)
        {
            this.wwwroot = wwwroot;
        }

        protected override FormiumResponse GetResponse(FormiumRequest request)
        {
            var response = new FileStreamResponse(request, true);

            if (request.Method != Method.GET)
            {
                response.Status = (int)System.Net.HttpStatusCode.NotFound;
                return response;
            }
            var filePath = response.RelativePath;
            physicalPath = System.IO.Path.Combine(wwwroot, filePath);
            var fileInfo = new System.IO.FileInfo(physicalPath);

            if (fileInfo.Exists)
            {
                response.ContentStream = File.OpenRead(fileInfo.FullName);
            }
            else
            {
                response.Status = (int)System.Net.HttpStatusCode.NotFound;
            }

            return response;

        }
    }
}
