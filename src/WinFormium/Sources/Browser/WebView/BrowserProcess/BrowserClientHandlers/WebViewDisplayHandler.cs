// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewDisplayHandler : CefDisplayHandler
{
    public IDisplayHandler Handler { get; }

    public WebViewDisplayHandler(IDisplayHandler handler)
    {
        Handler = handler;
    }

    protected override void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
    {
        Handler.OnAddressChange(browser, frame, url);
    }

    protected override bool OnAutoResize(CefBrowser browser, ref CefSize newSize)
    {
        return Handler.OnAutoResize(browser, ref newSize);
    }

    protected override bool OnConsoleMessage(CefBrowser browser, CefLogSeverity level, string message, string source, int line)
    {
        return Handler.OnConsoleMessage(browser, level, message, source, line);
    }

    protected override bool OnCursorChange(CefBrowser browser, nint cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
    {
        return Handler.OnCursorChange(browser, cursorHandle, type, customCursorInfo);
    }

    protected override void OnFaviconUrlChange(CefBrowser browser, string[] iconUrls)
    {
        Handler.OnFaviconUrlChange(browser, iconUrls);
    }

    protected override void OnFullscreenModeChange(CefBrowser browser, bool fullscreen)
    {
        Handler.OnFullscreenModeChange(browser, fullscreen);
    }

    protected override void OnLoadingProgressChange(CefBrowser browser, double progress)
    {
        Handler.OnLoadingProgressChange(browser, progress);
    }

    protected override void OnMediaAccessChange(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess)
    {
        Handler.OnMediaAccessChange(browser, hasVideoAccess, hasAudioAccess);
    }

    protected override void OnStatusMessage(CefBrowser browser, string value)
    {
        Handler.OnStatusMessage(browser, value);
    }

    protected override void OnTitleChange(CefBrowser browser, string title)
    {
        Handler.OnTitleChange(browser, title);
    }

    protected override bool OnTooltip(CefBrowser browser, string text)
    {
        return Handler.OnTooltip(browser, text);
    }
}
