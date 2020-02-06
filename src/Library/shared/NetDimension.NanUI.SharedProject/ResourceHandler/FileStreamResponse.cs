using Chromium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.ResourceHandler
{
    public class FileStreamResponse : FormiumResponse
    {
        public string RelativePath { get; }
        public string FileName { get => Path.GetFileName(RelativePath); }
        public string FileExtension { get => Path.GetExtension(FileName).TrimStart('.'); }
        protected FormiumRequest Request { get; }
        public FileStreamResponse(FormiumRequest request) : this(request, false)
        {
            Request = request;
        }

        public FileStreamResponse(FormiumRequest request, bool shouldCached = false)
        {
            this.RelativePath = request.Uri.LocalPath;
            RelativePath = RelativePath.Trim('/');
            ShouldCached = shouldCached;
            this.MimeType = CfxRuntime.GetMimeType(FileExtension);
        }
    }
}
