// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Browser;
public interface ILoadHandler
{
    void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward);
    void OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType);
    void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode);
    void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl);
}
