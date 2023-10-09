// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium;

public class FaviconUrlChangeEventArgs : EventArgs
{
    public FaviconUrlChangeEventArgs(CefBrowser browser, string[] urls)
    {
        Browser = browser;
        Urls = urls;
    }

    public CefBrowser Browser { get; }
    public string[] Urls { get; }
}
