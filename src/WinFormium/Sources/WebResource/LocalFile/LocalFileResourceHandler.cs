// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
internal class LocalFileResourceHandler : ResourceHandler
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefRequest Request { get; }

    public LocalFileResourceOptions Options { get; }

    protected override bool EnableCORSPolicy => true;

    public LocalFileResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request, LocalFileResourceOptions options)
    {
        Browser = browser;
        Frame = frame;
        Request = request;
        Options = options;
    }

    protected override ResourceResponse GetResourceResponse(ResourceRequest request)
    {
        var requestUrl = request.RequestUrl;

        var response = new ResourceResponse();

        if (request.Method != ResourceRequestMethod.GET)
        {
            response.HttpStatus = StatusCodes.Status404NotFound;

            return response;
        }

        var filePath = request.RelativePath;

        var physicalFilePath = Path.Combine(Options.PhysicalFilePath, filePath);

        if (!request.HasFileName)
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

        if (!File.Exists(physicalFilePath) && Options.OnFallback != null)
        {
            var fallbackFile = Options.OnFallback.Invoke(requestUrl);

            physicalFilePath = Path.GetFullPath(Path.Combine(Options.PhysicalFilePath, fallbackFile));
        }

        if (File.Exists(physicalFilePath))
        {
            response.ContentBody = File.Open(physicalFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); //File.OpenRead(physicalFilePath);
            response.ContentType = CefRuntime.GetMimeType(Path.GetExtension(physicalFilePath).Trim('.')) ?? "text/plain";
        }
        else
        {
            response.HttpStatus = StatusCodes.Status404NotFound;
        }

        return response;
    }
}
