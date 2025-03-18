// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Net.Http.Headers;

namespace NetDimension.NanUI.WebResource;
internal class ProxyResourceHandler : ResourceHandler
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefRequest Request { get; }
    public string Proxy { get; }

    HttpClient httpClient = new HttpClient(new HttpClientHandler { UseCookies = true });


    protected override bool EnableCORSPolicy { get; }


    public ProxyResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request, string proxy, bool enableCorsPolicy = true)
    {
        Browser = browser;
        Frame = frame;
        Request = request;
        Proxy = proxy;

        EnableCORSPolicy = enableCorsPolicy;
    }



    protected override ResourceResponse GetResourceResponse(ResourceRequest request)
    {
        httpClient.BaseAddress = new Uri(Proxy);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var message = new HttpRequestMessage(new HttpMethod(Request.Method), new Uri(Request.Url).PathAndQuery);

        if (request.Headers != null)
        {
            for (var i = 0; i < request.Headers.Count; i++)
            {
                var headerKey = request.Headers.GetKey(i);
                var headerValue = request.Headers.Get(i);

                if(headerKey !=null && !message.Headers.TryAddWithoutValidation(headerKey, headerValue))
                {
                }
            }
        }

        var result = httpClient.SendAsync(message).GetAwaiter().GetResult()!;

        var response = new ResourceResponse()
        {
            ContentType = result.Content.Headers.ContentType?.MediaType,
            HttpStatus = (int)result.StatusCode,
        };

        foreach(var header in result.Headers.ToList())
        {
            foreach (var v in header.Value)
            {
                response.Headers.Add(header.Key, v);
            }
        }

        response.ContentBody = result.Content.ReadAsStreamAsync().GetAwaiter().GetResult();

        

        return response;
    }
}
