using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.ResourceHandler
{
    public sealed class ResourceResponse : IDisposable
    {
        public string RelativePath => $"{_resourceRequest?.Uri?.LocalPath ?? string.Empty}".Trim('/');
        public string FileName => Path.GetFileName(RelativePath);
        public string FileExtension => Path.GetExtension(FileName).TrimStart('.');
        public Stream ContentStream { get; set; }
        public System.Net.HttpStatusCode HttpStatus { get; set; } = System.Net.HttpStatusCode.OK;
        public long Length => ContentStream?.Length ?? 0;
        public string MimeType { get; set; } = "text/plain";

        public bool HasFileName => !string.IsNullOrEmpty(FileName);

        public NameValueCollection Headers { get; } = new NameValueCollection();

        private readonly ResourceRequest _resourceRequest;

        public ResourceResponse()
        {
            
        }

        public ResourceResponse(ResourceRequest request)
        {
            _resourceRequest = request;

            MimeType = CefRuntime.GetMimeType(FileExtension);
        }

        public void Content(byte[] buff, string contentType = null)
        {
            if(!string.IsNullOrEmpty(contentType))
            {
                MimeType = contentType;
            }
            
            Headers.Set("Content-Type", MimeType);

            if (ContentStream != null)
            {
                ContentStream.Dispose();
                ContentStream = null;
            }

            ContentStream = new MemoryStream(buff);

            HttpStatus = System.Net.HttpStatusCode.OK;
        }

        public void Dispose()
        {
            if (ContentStream != null)
            {
                ContentStream.Close();
                ContentStream.Dispose();
                ContentStream = null;
            }
            GC.SuppressFinalize(this);
        }

    }
}
