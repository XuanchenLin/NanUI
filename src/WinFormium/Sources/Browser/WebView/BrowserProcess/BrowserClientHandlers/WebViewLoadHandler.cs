// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewLoadHandler : CefLoadHandler
{
    public ILoadHandler Handler { get; }

    public WebViewLoadHandler(ILoadHandler handler)
    {
        Handler = handler;
    }

    protected override void OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
    {
        Handler.OnLoadStart(browser, frame, transitionType);
    }

    protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
        if (frame.IsMain)
        {
            frame.ExecuteJavaScript("window.formium && formium?.hostWindow?.internal?.setDocumentReadyState()", string.Empty, 0);
        }
        Handler.OnLoadEnd(browser, frame, httpStatusCode);
    }

    protected override void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
    {
        Handler.OnLoadError(browser, frame, errorCode, errorText, failedUrl);
    }

    protected override void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
    {
        Handler.OnLoadingStateChange(browser, isLoading, canGoBack, canGoForward);
    }

}
