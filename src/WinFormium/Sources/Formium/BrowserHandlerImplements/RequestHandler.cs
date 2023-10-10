// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class RequestHandler : IRequestHandler
{
    bool IRequestHandler.GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        return GetAuthCredentials(browser, originUrl, isProxy, host, port, realm, scheme, callback);
    }

    CefResourceRequestHandler? IRequestHandler.GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
    {
        return GetResourceRequestHandler(browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
    }

    bool IRequestHandler.OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        return OnBeforeBrowse(browser, frame, request, userGesture, isRedirect);
    }

    bool IRequestHandler.OnCertificateError(CefBrowser browser, CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefCallback callback)
    {
        return OnCertificateError(browser, certError, requestUrl, sslInfo, callback);
    }

    void IRequestHandler.OnDocumentAvailableInMainFrame(CefBrowser browser)
    {
        OnDocumentAvailableInMainFrame(browser);
    }

    bool IRequestHandler.OnOpenUrlFromTab(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        return OnOpenUrlFromTab(browser, frame, targetUrl, targetDisposition, userGesture);
    }

    void IRequestHandler.OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
    {
        OnRenderProcessTerminated(browser, status);
    }

    void IRequestHandler.OnRenderViewReady(CefBrowser browser)
    {
        OnRenderViewReady(browser);
    }

    bool IRequestHandler.OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host, int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
    {
        return OnSelectClientCertificate(browser, isProxy, host, port, certificates, callback);
    }

    internal protected virtual bool GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        return false;
    }

    internal protected virtual CefResourceRequestHandler? GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
    {
        return null;
    }

    internal protected virtual bool OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        return false;
    }

    internal protected virtual bool OnCertificateError(CefBrowser browser, CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefCallback callback)
    {
        return false;
    }

    internal protected virtual void OnDocumentAvailableInMainFrame(CefBrowser browser)
    {
    }

    internal protected virtual bool OnOpenUrlFromTab(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        return false;
    }

    internal protected virtual void OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
    {
    }

    internal protected virtual void OnRenderViewReady(CefBrowser browser)
    {
    }

    internal protected virtual bool OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host, int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
    {
        return false;
    }


}
