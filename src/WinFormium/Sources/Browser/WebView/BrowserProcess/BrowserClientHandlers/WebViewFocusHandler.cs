// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewFocusHandler : CefFocusHandler
{
    public IFocusHandler Handler { get; }

    public WebViewFocusHandler(IFocusHandler handler)
    {
        Handler = handler;
    }

    protected override void OnGotFocus(CefBrowser browser)
    {
        Handler.OnGotFocus(browser);
    }

    protected override bool OnSetFocus(CefBrowser browser, CefFocusSource source)
    {
        return Handler.OnSetFocus(browser, source);
    }

    protected override void OnTakeFocus(CefBrowser browser, bool next)
    {
        Handler.OnTakeFocus(browser, next);
    }
}
