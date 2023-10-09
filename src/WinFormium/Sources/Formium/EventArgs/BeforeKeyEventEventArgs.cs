// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium;

public class BeforeKeyEventEventArgs : EventArgs
{

    public BeforeKeyEventEventArgs(CefBrowser browser, CefKeyEvent keyEvent)
    {
        Browser = browser;
        KeyEvent = keyEvent;
    }

    public bool IsKeyboardShortcut { get; set; }
    public bool Handled { get; set; }
    public CefBrowser Browser { get; }
    public CefKeyEvent KeyEvent { get; }
}
