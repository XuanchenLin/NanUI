// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium;

public class PageLoadEndEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public int HttpStatusCode { get; }

    public PageLoadEndEventArgs(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
        Browser = browser;
        Frame = frame;
        HttpStatusCode = httpStatusCode;
    }
}
