// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class BeforeDownloadEventArgs : EventArgs
{
    public BeforeDownloadEventArgs(CefBrowser browser, CefDownloadItem item, string suggestedName, CefBeforeDownloadCallback callback)
    {
        Browser = browser;
        Item = item;
        SuggestedName = suggestedName;
        Callback = callback;
    }

    public CefBrowser Browser { get; }
    public CefDownloadItem Item { get; }
    public string SuggestedName { get; }
    public CefBeforeDownloadCallback Callback { get; }
}
