using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using NetDimension.NanUI.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.ZippedResource
{
    internal class SchemeConfiguration : ResourceSchemeConfiguration
    {
        public Func<string, string> OnFallback { get; }


        public SchemeConfiguration(string scheme, string domainName, string zipFilePath, Func<string, string> onFallback = null)
    : this(scheme, domainName, () => new FileStream(zipFilePath, FileMode.Open, FileAccess.Read, FileShare.Read), onFallback)
        {

        }

        public SchemeConfiguration(string scheme, string domainName, Func<Stream> getZipFileStream, Func<string, string> onFallback = null)
: base(scheme, domainName)
        {

            var zipFileStream = getZipFileStream.Invoke();
            using (var stream = new MemoryStream())
            {
                zipFileStream.CopyTo(stream);

                zipFileStream.Dispose();

                ZipFileBuffer = stream.ToArray();
            }

            OnFallback = onFallback;

        }

        public byte[] ZipFileBuffer { get; }



        protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) => new ResourceHandler(this);

    }

    public static class ExtensionRegister
    {
        public static ApplicationConfigurationBuilder UseZippedResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, string zipFilePath, Func<string, string> onFallback = null)
        {
            @this.UseCustomResourceHandler(() => new SchemeConfiguration(scheme, domainName, zipFilePath, onFallback));

            return @this;
        }

        public static ApplicationConfigurationBuilder UseZippedResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, Func<Stream> zipFileStream, Func<string, string> onFallback = null)
        {
            @this.UseCustomResourceHandler(() => new SchemeConfiguration(scheme, domainName, zipFileStream, onFallback));

            return @this;
        }
    }

}
