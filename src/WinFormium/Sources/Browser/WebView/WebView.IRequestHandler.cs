// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal partial class WebView : IRequestHandler
{
    bool IRequestHandler.GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        return WebViewHost.RequestHandler?.GetAuthCredentials(browser, originUrl, isProxy, host, port, realm, scheme, callback) ?? false;
    }

    CefResourceRequestHandler? IRequestHandler.GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
    {
        return WebViewHost.RequestHandler?.GetResourceRequestHandler(browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
    }

    bool IRequestHandler.OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        var retval = WebViewHost.RequestHandler?.OnBeforeBrowse(browser, frame, request, userGesture, isRedirect) ?? false;

        MessageBridge?.OnBeforeBrowse(browser, frame, request, userGesture, isRedirect);

        return retval;
    }

    bool IRequestHandler.OnCertificateError(CefBrowser browser, CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefCallback callback)
    {
        return WebViewHost.RequestHandler?.OnCertificateError(browser, certError, requestUrl, sslInfo, callback) ?? false;
    }

    void IRequestHandler.OnDocumentAvailableInMainFrame(CefBrowser browser)
    {
        WebViewHost.RequestHandler?.OnDocumentAvailableInMainFrame(browser);

        ColorModeChange();
    }

    bool IRequestHandler.OnOpenUrlFromTab(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        return WebViewHost.RequestHandler?.OnOpenUrlFromTab(browser, frame, targetUrl, targetDisposition, userGesture) ?? false;
    }

    void IRequestHandler.OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
    {
        MessageBridge?.OnRenderProcessTerminated(browser);

        WebViewHost.RequestHandler?.OnRenderProcessTerminated(browser, status);
    }

    void IRequestHandler.OnRenderViewReady(CefBrowser browser)
    {
        WebViewHost.RequestHandler?.OnRenderViewReady(browser);
    }

    bool IRequestHandler.OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host, int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
    {
        return WebViewHost.RequestHandler?.OnSelectClientCertificate(browser, isProxy, host, port, certificates, callback) ?? false;
    }
}
