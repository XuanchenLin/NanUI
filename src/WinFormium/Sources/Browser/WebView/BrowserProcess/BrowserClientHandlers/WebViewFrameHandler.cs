// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewFrameHandler : CefFrameHandler
{
    public IFrameHandler Handler { get; }

    public WebViewFrameHandler(IFrameHandler handler)
    {
        Handler = handler;
    }

    protected override void OnFrameAttached(CefBrowser browser, CefFrame frame, bool reattached)
    {
        Handler.OnFrameAttached(browser, frame, reattached);
    }

    protected override void OnFrameCreated(CefBrowser browser, CefFrame frame)
    {
        Handler.OnFrameCreated(browser, frame);
    }

    protected override void OnFrameDetached(CefBrowser browser, CefFrame frame)
    {
        Handler.OnFrameDetached(browser, frame);
    }

    protected override void OnMainFrameChanged(CefBrowser browser, CefFrame? oldFrame, CefFrame? newFrame)
    {
        Handler.OnMainFrameChanged(browser, oldFrame, newFrame);
    }
}
