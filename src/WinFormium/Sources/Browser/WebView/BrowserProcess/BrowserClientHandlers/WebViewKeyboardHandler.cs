// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewKeyboardHandler : CefKeyboardHandler
{
    public IKeyboardHandler Handler { get; }

    public WebViewKeyboardHandler(IKeyboardHandler handler)
    {
        Handler = handler;
    }

    protected override bool OnKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, nint osEvent)
    {
        return Handler.OnKeyEvent(browser, keyEvent, osEvent);
    }

    protected override bool OnPreKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, nint os_event, out bool isKeyboardShortcut)
    {
        return Handler.OnPreKeyEvent(browser, keyEvent, os_event, out isKeyboardShortcut);
    }
}
