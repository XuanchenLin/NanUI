// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium;

public class SetFocusEventArgs
{
    public SetFocusEventArgs(CefBrowser browser, CefFocusSource source)
    {
        Browser = browser;
        Source = source;
    }

    public CefBrowser Browser { get; }
    public CefFocusSource Source { get; }
    public bool Handled { get; set; }
}
