// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public abstract class ResourceHandler
    : CefResourceHandler
{
    private const string ACCESS_CONTROL_ALLOW_HEADERS = "Access-Control-Allow-Headers";
    private const string ACCESS_CONTROL_ALLOW_METHODS = "Access-Control-Allow-Methods";

    private const string ACCESS_CONTROL_ALLOW_ORIGIN = "Access-Control-Allow-Origin";

    private const string ACCESS_CONTROL_MAX_AGE = "Access-Control-Max-Age";
    private const string X_FRAME_OPTIONS = "X-Frame-Options";
    private const string X_POWERED_BY = "X-Powered-By";

    protected virtual bool EnableCORSPolicy
    {
        get
        {
            return false;
        }
    }

    private GCHandle _gcHandle;
    private int _readStreamOffset;
    private int? _buffStartPostition = null;
    private int? _buffEndPostition = null;
    private bool _isPartContent = false;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    private ResourceResponse? _resourceResponse;

    abstract protected ResourceResponse GetResourceResponse(ResourceRequest request);

    protected ResourceSchemeHandlerOptions SchemeOptions { get; }

    protected static string GetMimeType(string fileName)
    {
        var ext = Path.GetExtension(fileName)?.Trim('.') ?? string.Empty;

        if (string.IsNullOrEmpty(ext))
        {
            return "application/octet-stream";
        }

        return CefRuntime.GetMimeType(ext);
    }

    public ResourceHandler()
    {
        var options = new ResourceSchemeHandlerOptions();

        SchemeOptions = options;

        _gcHandle = GCHandle.Alloc(this);


    }

    protected override bool Skip(long bytesToSkip, out long bytesSkipped, CefResourceSkipCallback callback)
    {
        bytesSkipped = bytesToSkip;
        return true;
    }

    protected override void GetResponseHeaders(CefResponse response, out long responseLength, out string redirectUrl)
    {
        var statusCode = _resourceResponse?.HttpStatus ?? StatusCodes.Status400BadRequest;

        if (_resourceResponse != null)
        {
            response.SetHeaderMap(_resourceResponse.Headers);
        }


        response.Status = (int)statusCode;

        redirectUrl = string.Empty;

        if (statusCode == StatusCodes.Status200OK && _resourceResponse != null)
        {

            responseLength = _resourceResponse.Length;

            response.MimeType = _resourceResponse.ContentType ?? string.Empty;



            if (_isPartContent)
            {
                response.SetHeaderByName("Accept-Ranges", "bytes", true);

                var startPos = 0;
                var endPos = _resourceResponse.Length - 1;

                if (_buffStartPostition.HasValue && _buffEndPostition.HasValue)
                {
                    startPos = _buffStartPostition.Value;
                    endPos = _buffStartPostition.Value;
                }
                else if (!_buffEndPostition.HasValue && _buffStartPostition.HasValue)
                {
                    startPos = _buffStartPostition.Value;
                }

                response.SetHeaderByName("Content-Range", $"bytes {startPos}-{endPos}/{_resourceResponse.Length}", true);
                response.SetHeaderByName("Content-Length", $"{endPos - startPos + 1}", true);


                response.Status = 206;
            }


            response.SetHeaderByName("Content-Type", response.MimeType, true);

            response.SetHeaderByName(X_POWERED_BY, $"WinFormium/{Assembly.GetExecutingAssembly().GetName().Version}", true);
        }
        else
        {
            responseLength = 0;
        }
    }

    protected override bool Open(CefRequest request, out bool handleRequest, CefCallback callback)
    {
        var uri = new Uri(request.Url);
        var headers = request.GetHeaderMap();


        if (!string.IsNullOrEmpty(headers.Get("range")))
        {
            var rangeString = headers?.Get("range") ?? string.Empty;
            var group = System.Text.RegularExpressions.Regex.Match(rangeString, @"(?<start>\d+)-(?<end>\d*)")?.Groups;
            if (group != null)
            {
                if (!string.IsNullOrEmpty(group["start"].Value) && int.TryParse(group["start"].Value, out var startPos))
                {
                    _buffStartPostition = startPos;
                }

                if (!string.IsNullOrEmpty(group["end"].Value) && int.TryParse(group["end"].Value, out var endPos))
                {
                    _buffEndPostition = endPos;
                }
            }
            _isPartContent = true;
        }

        _readStreamOffset = 0;

        if (_buffStartPostition.HasValue)
        {
            _readStreamOffset = _buffStartPostition.Value;
        }


        var postData = new List<byte>();
        var uploadFiles = new List<string>();

        if (request.PostData != null)
        {
            var items = request.PostData.GetElements();

            if (items != null && items.Length > 0)
            {
                foreach (var item in items)
                {

                    var buffer = item.GetBytes();

                    //var size = (int)item.BytesCount;

                    switch (item.ElementType)
                    {
                        case CefPostDataElementType.Bytes:
                            postData.AddRange(buffer);
                            break;
                        case CefPostDataElementType.File:
                            uploadFiles.Add(item.GetFile());
                            break;
                    }

                }
            }
        }

        var method = request.Method;

        var resourceRequest = new ResourceRequest(uri, method, headers, postData.ToArray(), uploadFiles.ToArray(), request);

        handleRequest = false;

        Task.Run(() =>
        {
            try
            {
                _resourceResponse = GetResourceResponse(resourceRequest);

                if (EnableCORSPolicy)
                {
                    _resourceResponse.Headers.Set(ACCESS_CONTROL_ALLOW_HEADERS, "*");
                    _resourceResponse.Headers.Set(ACCESS_CONTROL_ALLOW_METHODS, "*");
                    _resourceResponse.Headers.Set(X_FRAME_OPTIONS, "ALLOWALL");

                    _resourceResponse.Headers.Set(ACCESS_CONTROL_MAX_AGE, "3600");

                    if (!string.IsNullOrEmpty(request.GetHeaderByName("origin")))
                    {
                        _resourceResponse.Headers.Set(ACCESS_CONTROL_ALLOW_ORIGIN, request.GetHeaderByName("origin"));

                    }
                    else
                    {
                        _resourceResponse.Headers.Set(ACCESS_CONTROL_ALLOW_ORIGIN, "*");

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Instance.Log.LogError(ex);

                callback.Cancel();
            }

        }, _cancellationTokenSource.Token).ContinueWith(t => callback.Continue());

        return true;

    }

    protected override void Cancel()
    {
        _cancellationTokenSource.Cancel();
    }





    protected override bool Read(IntPtr dataOut, int bytesToRead, out int bytesRead, CefResourceReadCallback callback)
    {
        if (_resourceResponse?.ContentBody == null)
        {
            bytesRead = 0;
            return false;
        }

        var total = _resourceResponse.Length;

        var bytesToCopy = (int)(total - _readStreamOffset);

        if (total == 0 || bytesToCopy <= 0)
        {
            bytesRead = 0;
            return false;
        }

        bytesToCopy = Math.Min(bytesToCopy, bytesToRead);

        var buff = new byte[bytesToCopy];

        _resourceResponse.ContentBody.Position = _readStreamOffset;
        _resourceResponse.ContentBody.Read(buff, 0, bytesToCopy);

        Marshal.Copy(buff, 0, dataOut, bytesToCopy);

        _readStreamOffset += bytesToCopy;

        bytesRead = bytesToCopy;

        if (_readStreamOffset == _resourceResponse.Length)
        {
            _resourceResponse.Dispose();
            _gcHandle.Free();
        }

        return true;

    }


}
