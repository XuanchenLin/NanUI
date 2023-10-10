// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewRequestHandler : CefRequestHandler
{
    public IRequestHandler Handler { get; }

    public WebViewRequestHandler(IRequestHandler handler)
    {
        Handler = handler;
    }

    protected override bool GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        return Handler.GetAuthCredentials(browser, originUrl, isProxy, host, port, realm, scheme, callback);
    }

    protected override CefResourceRequestHandler GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
    {
        return Handler.GetResourceRequestHandler(browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
    }

    protected override bool OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        return Handler.OnBeforeBrowse(browser, frame, request, userGesture, isRedirect);
    }

    protected override bool OnCertificateError(CefBrowser browser, CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefCallback callback)
    {
        return Handler.OnCertificateError(browser, certError, requestUrl, sslInfo, callback);
    }

    protected override void OnDocumentAvailableInMainFrame(CefBrowser browser)
    {
        Handler.OnDocumentAvailableInMainFrame(browser);
    }

    protected override bool OnOpenUrlFromTab(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        return Handler.OnOpenUrlFromTab(browser, frame, targetUrl, targetDisposition, userGesture);
    }

    protected override void OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
    {
        Handler.OnRenderProcessTerminated(browser, status);
    }

    protected override void OnRenderViewReady(CefBrowser browser)
    {
        Handler.OnRenderViewReady(browser);
    }

    protected override bool OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host, int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
    {
        return Handler.OnSelectClientCertificate(browser, isProxy, host, port, certificates, callback);
    }

}
