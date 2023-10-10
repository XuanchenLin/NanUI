// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class PageLoadingStateChangeEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public bool IsLoading { get; }
    public bool CanGoBack { get; }
    public bool CanGoForward { get; }

    public PageLoadingStateChangeEventArgs(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
    {
        Browser = browser;
        IsLoading = isLoading;
        CanGoBack = canGoBack;
        CanGoForward = canGoForward;
    }
}
