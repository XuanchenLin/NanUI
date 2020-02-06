using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.ResourceHandler
{
    public class FormiumResponse : IDisposable
    {
        public Stream ContentStream { get; set; }
        public int Status { get; set; } = (int)System.Net.HttpStatusCode.OK;
        public long Length { get => ContentStream?.Length??0 ; }
        public string MimeType { get; set; } = "text/html";
        public bool ShouldCached { get; set; } = false;

        public Dictionary<string, string[]> Headers { get; } = new Dictionary<string, string[]>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {

            }

            if (ContentStream != null)
            {
                ContentStream.Dispose();
            }
        }
    }
}
