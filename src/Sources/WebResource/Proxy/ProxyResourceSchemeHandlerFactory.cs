// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;
internal class ProxyResourceSchemeHandlerFactory : ResourceSchemeHandlerFactory
{
    public string Proxy { get; }

    public ProxyResourceSchemeHandlerFactory(string scheme, string domainName, string proxy)
        : base(scheme, domainName)
    {
        Proxy = proxy;
    }


    protected override CefResourceHandler? GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
    {
        return new ProxyResourceHandler(browser, frame, request, Proxy);
    }
}


