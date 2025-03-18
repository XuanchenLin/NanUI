// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class DownloadUpdatedEventArgs : EventArgs
{

    public DownloadUpdatedEventArgs(CefBrowser browser, CefDownloadItem item, CefDownloadItemCallback callback)
    {
        Browser = browser;
        Item = item;
        Callback = callback;
    }

    public CefBrowser Browser { get; }
    public CefDownloadItem Item { get; }
    public CefDownloadItemCallback Callback { get; }
}
