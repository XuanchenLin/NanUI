// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium;

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
