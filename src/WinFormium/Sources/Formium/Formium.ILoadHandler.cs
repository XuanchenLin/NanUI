// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : ILoadHandler
{
    #region interface
    void ILoadHandler.OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
        if (LoadHandler != null)
        {
            LoadHandler.OnLoadEnd(browser, frame, httpStatusCode);
        }

        OnPageLoadEndCore(browser, frame, httpStatusCode);
    }

    void ILoadHandler.OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
    {
        if (LoadHandler != null)
        {
            LoadHandler.OnLoadError(browser, frame, errorCode, errorText, failedUrl);

        }
        OnPageLoadErrorCore(browser, frame, errorCode, errorText, failedUrl);
    }

    void ILoadHandler.OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
    {
        if (LoadHandler != null)
        {
            LoadHandler.OnLoadingStateChange(browser, isLoading, canGoBack, canGoForward);
        }

        OnPageLoadingStateChangeCore(browser, canGoForward, canGoForward, canGoForward);
    }

    void ILoadHandler.OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
    {
        if (LoadHandler != null)
        {
            LoadHandler.OnLoadStart(browser, frame, transitionType);
        }

        OnPageLoadStartCore(browser, frame, transitionType);
    }
    #endregion

    #region implements
    private void OnPageLoadStartCore(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
    {
        if (frame.IsMain)
        {
            var args1 = new PageLoadStartEventArgs(browser, frame, transitionType);

            InvokeOnUIThread(OnPageLoadStart, args1);
        }

        var args2 = new FramePageLoadStartEventArgs(browser, frame, transitionType);



        InvokeOnUIThread(OnFramePageLoadStart, args2);
    }

    (CefErrorCode, string)? _lastPageLoadError;
    int _pageLoadErrorRetryCount = 0;

    private void OnPageLoadErrorCore(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
    {
        if (frame.IsMain && errorCode == CefErrorCode.Aborted) return;

        if (frame.IsMain)
        {
            var args1 = new PageLoadErrorEventArgs(browser, frame, errorCode, errorText, failedUrl);
            InvokeOnUIThread(OnPageLoadError, args1);

            frame.LoadUrl($"formium://pages/error/{errorCode}?text={errorText}&url={failedUrl}");


            if(_lastPageLoadError == (errorCode, failedUrl))
            {
                _pageLoadErrorRetryCount++;
            }

            if (_pageLoadErrorRetryCount > 20)
            {
                _pageLoadErrorRetryCount = 0;
                _lastPageLoadError = null;

                throw new Exception($"Page load error: {errorCode} {errorText} {failedUrl}");

            }

            _lastPageLoadError = (errorCode, failedUrl);

            HideSplash();

        }

        var args2 = new FramePageLoadErrorEventArgs(browser, frame, errorCode, errorText, failedUrl);
        InvokeOnUIThread(OnFramePageLoadError, args2);
    }

    private void OnPageLoadEndCore(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
        if (frame.IsMain)
        {
            var args1 = new PageLoadEndEventArgs(browser, frame, httpStatusCode);
            InvokeOnUIThread(OnPageLoadEnd, args1);

            HideSplash();
        }

        var args2 = new FramePageLoadEndEventArgs(browser, frame, httpStatusCode);
        InvokeOnUIThread(OnFramePageLoadEnd, args2);


    }

    private void OnPageLoadingStateChangeCore(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
    {
        var args = new PageLoadingStateChangeEventArgs(browser, isLoading, canGoBack, canGoForward);
        InvokeOnUIThread(OnPageLoadingStateChange, args);
    }

    #endregion
}
