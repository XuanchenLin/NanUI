// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class DisplayHandler : IDisplayHandler
{
    void IDisplayHandler.OnAddressChange(CefBrowser browser, CefFrame frame, string url)
    {
        OnAddressChange(browser, frame, url);
    }

    bool IDisplayHandler.OnAutoResize(CefBrowser browser, ref CefSize newSize)
    {
        return OnAutoResize(browser, ref newSize);
    }

    bool IDisplayHandler.OnConsoleMessage(CefBrowser browser, CefLogSeverity level, string message, string source, int line)
    {
        return OnConsoleMessage(browser, level, message, source, line);
    }

    bool IDisplayHandler.OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
    {
        return OnCursorChange(browser, cursorHandle, type, customCursorInfo);
    }

    void IDisplayHandler.OnFaviconUrlChange(CefBrowser browser, string[] iconUrls)
    {
        OnFaviconUrlChange(browser, iconUrls);
    }

    void IDisplayHandler.OnFullscreenModeChange(CefBrowser browser, bool fullscreen)
    {
        OnFullscreenModeChange(browser, fullscreen);
    }

    void IDisplayHandler.OnLoadingProgressChange(CefBrowser browser, double progress)
    {
        OnLoadingProgressChange(browser, progress);
    }

    void IDisplayHandler.OnMediaAccessChange(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess)
    {
        OnMediaAccessChange(browser, hasVideoAccess, hasAudioAccess);
    }

    void IDisplayHandler.OnStatusMessage(CefBrowser browser, string value)
    {
        OnStatusMessage(browser, value);
    }

    void IDisplayHandler.OnTitleChange(CefBrowser browser, string title)
    {
        OnTitleChange(browser, title);
    }

    bool IDisplayHandler.OnTooltip(CefBrowser browser, string text)
    {
        return OnTooltip(browser, text);
    }

    internal protected virtual void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
    {
    }

    internal protected virtual bool OnAutoResize(CefBrowser browser, ref CefSize newSize)
    {
        return false;
    }

    internal protected virtual bool OnConsoleMessage(CefBrowser browser, CefLogSeverity level, string message, string source, int line)
    {
        return false;
    }

    internal protected virtual bool OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
    {
        return false;
    }

    internal protected virtual void OnFaviconUrlChange(CefBrowser browser, string[] iconUrls)
    {
    }

    internal protected virtual void OnFullscreenModeChange(CefBrowser browser, bool fullscreen)
    {
    }

    internal protected virtual void OnLoadingProgressChange(CefBrowser browser, double progress)
    {
    }

    internal protected virtual void OnMediaAccessChange(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess)
    {
    }

    internal protected virtual void OnStatusMessage(CefBrowser browser, string value)
    {
    }

    internal protected virtual void OnTitleChange(CefBrowser browser, string title)
    {
    }

    internal protected virtual bool OnTooltip(CefBrowser browser, string text)
    {
        return false;
    }


}
