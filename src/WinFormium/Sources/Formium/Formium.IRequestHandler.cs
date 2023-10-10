// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : IRequestHandler
{
    #region interface

    bool IRequestHandler.GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        var retval = RequestHandler?.GetAuthCredentials(browser, originUrl, isProxy, host, port, realm, scheme, callback) ?? false;

        return retval ? retval : GetAuthCredentialsCore(browser, originUrl, isProxy, host, port, realm, scheme, callback);


    }



    CefResourceRequestHandler? IRequestHandler.GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
    {
        return RequestHandler?.GetResourceRequestHandler(browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
    }

    bool IRequestHandler.OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        var retval = RequestHandler?.OnBeforeBrowse(browser, frame, request, userGesture, isRedirect) ?? false;

        return retval ? retval : OnBeforeBrowseCore(browser, frame, request, userGesture, isRedirect);
    }

    bool IRequestHandler.OnCertificateError(CefBrowser browser, CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefCallback callback)
    {
        return RequestHandler?.OnCertificateError(browser, certError, requestUrl, sslInfo, callback) ?? false;
    }

    void IRequestHandler.OnDocumentAvailableInMainFrame(CefBrowser browser)
    {
        RequestHandler?.OnDocumentAvailableInMainFrame(browser);

        OnDocumentAvailableInMainFrameCore(browser);
    }

    bool IRequestHandler.OnOpenUrlFromTab(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        if (RequestHandler != null)
        {
            return RequestHandler?.OnOpenUrlFromTab(browser, frame, targetUrl, targetDisposition, userGesture) ?? false;
        }

        var retval = OnOpenUrlFromTabCore(browser, frame, targetUrl, targetDisposition, userGesture);

        if (!retval)
        {
            Browser?.GetMainFrame().LoadUrl(targetUrl);
        }

        return retval;
    }

    void IRequestHandler.OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
    {
        RequestHandler?.OnRenderProcessTerminated(browser, status);

        OnRenderProcessTerminatedCore(browser, status);
    }

    void IRequestHandler.OnRenderViewReady(CefBrowser browser)
    {
        RequestHandler?.OnRenderViewReady(browser);

        OnRenderViewReadyCore(browser);
    }

    bool IRequestHandler.OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host, int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
    {
        return RequestHandler?.OnSelectClientCertificate(browser, isProxy, host, port, certificates, callback) ?? false;
    }
    #endregion

    #region implement
    private bool GetAuthCredentialsCore(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        var args = new GetAuthCredentialsEventArgs(browser, originUrl, isProxy, host, port, realm, scheme, callback);

        InvokeOnUIThread(OnGetAuthCredentials, args);


        return args.Handled;
    }


    private bool OnOpenUrlFromTabCore(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        var args = new OpenUrlFromTabEventArgs(browser, frame, targetUrl, targetDisposition, userGesture);

        InvokeOnUIThread(OnOpenUrlFromTab, args);

        return args.Cancel;
    }


    private void OnRenderProcessTerminatedCore(CefBrowser browser, CefTerminationStatus status)
    {
        if (status == CefTerminationStatus.Termination) return;

        var args = new RenderProcessCrashedEventArgs(browser, status);

        InvokeOnUIThread(() => OnRenderProcessCrashed(args));

        if (args.RestartProcess)
        {
            browser.Reload();
        }
    }

    private void OnDocumentAvailableInMainFrameCore(CefBrowser browser)
    {
        var args = new BrowserEventArgs(browser);

        InvokeOnUIThread(OnDocumentAvailable, args);
    }

    private void OnRenderViewReadyCore(CefBrowser browser)
    {
        if (!CurrentFormStyle.OffScreenRenderEnabled)
        {
            CreateBrowserMessageInterceptor();
        }

        var args = new BrowserEventArgs(browser);

        InvokeOnUIThread(OnLoaded, args);
    }

    private bool OnBeforeBrowseCore(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        var args = new BeforeBrowseEventArgs(browser, frame, request, userGesture, isRedirect);

        InvokeOnUIThread(OnBeforeBrowse, args);

        return args.Handled;
    }

    #endregion
}
