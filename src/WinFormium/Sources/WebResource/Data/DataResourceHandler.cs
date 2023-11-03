// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
internal class DataResourceHandler : ResourceHandler
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefRequest Request { get; }
    public DataResourceOptions Options { get; }

    protected override bool EnableCORSPolicy => true;

    public DataResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request, DataResourceOptions options)
    {
        Browser = browser;
        Frame = frame;
        Request = request;
        Options = options;
    }

    protected override ResourceResponse GetResourceResponse(ResourceRequest request)
    {
        var response = new ResourceResponse();

        var provider = DataResourceProvider.GetProvider(Options);

        if (provider == null || string.IsNullOrEmpty(request.Uri.Host))
        {
            response.HttpStatus = StatusCodes.Status404NotFound;
            return response;
        }

        var relativePath = request.Uri.LocalPath?.Trim('/').ToLower();

        if ((request.Method == ResourceRequestMethod.OPTIONS || request.Method == ResourceRequestMethod.HEAD) && provider.Routes.SingleOrDefault(x => x.Path.Contains(relativePath)) != null)
        {
            response.HttpStatus = StatusCodes.Status200OK;
            return response;
        }

        var route = provider.Routes.SingleOrDefault(x => x.Path.Contains(relativePath) && (x.Method == request.Method || x.Method == ResourceRequestMethod.All));

        if (route == null)
        {
            response.HttpStatus = StatusCodes.Status404NotFound;
            return response;
        }


        try
        {
            var context = new DataResourceContext
            {
                Request = request,
                Response = response,
                Route = route
            };

            var retval = route.Execute(context);

            if(retval == null)
            {
                response.HttpStatus = StatusCodes.Status500InternalServerError;
                return response;
            }
            else if (retval is IResourceResult resourceResult)
            {
                resourceResult.ExecuteResult(context);
            }
            else if(retval is Task<IResourceResult> resourceResultAsync)
            {
                resourceResultAsync.GetAwaiter().GetResult().ExecuteResult(context);
            }

        }
        catch (Exception ex)
        {
            response.HttpStatus = StatusCodes.Status500InternalServerError;
            response.TextContent(ex.ToString());
        }


        return response;
    }
}
