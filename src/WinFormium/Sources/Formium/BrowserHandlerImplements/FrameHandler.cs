// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class FrameHandler : IFrameHandler
{
    void IFrameHandler.OnFrameAttached(CefBrowser browser, CefFrame frame, bool reattached)
    {
        OnFrameAttached(browser, frame, reattached);
    }

    void IFrameHandler.OnFrameCreated(CefBrowser browser, CefFrame frame)
    {
        OnFrameCreated(browser, frame);
    }

    void IFrameHandler.OnFrameDetached(CefBrowser browser, CefFrame frame)
    {
        OnFrameDetached(browser, frame);
    }

    void IFrameHandler.OnMainFrameChanged(CefBrowser browser, CefFrame? oldFrame, CefFrame? newFrame)
    {
        OnMainFrameChanged(browser, oldFrame, newFrame);
    }

    protected virtual void OnFrameAttached(CefBrowser browser, CefFrame frame, bool reattached)
    {
    }

    protected virtual void OnFrameCreated(CefBrowser browser, CefFrame frame)
    {
    }

    protected virtual void OnFrameDetached(CefBrowser browser, CefFrame frame)
    {
    }

    protected virtual void OnMainFrameChanged(CefBrowser browser, CefFrame? oldFrame, CefFrame? newFrame)
    {
    }
}


