// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class LoadHandler : ILoadHandler
{
    void ILoadHandler.OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
        OnLoadEnd(browser, frame, httpStatusCode);
    }

    void ILoadHandler.OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
    {
        OnLoadError(browser, frame, errorCode, errorText, failedUrl);
    }

    void ILoadHandler.OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
    {
        OnLoadingStateChange(browser, isLoading, canGoBack, canGoForward);
    }

    void ILoadHandler.OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
    {
        OnLoadStart(browser, frame, transitionType);
    }

    internal protected virtual void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
    }

    internal protected virtual void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
    {
    }

    internal protected virtual void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
    {
    }

    internal protected virtual void OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
    {
    }
}
