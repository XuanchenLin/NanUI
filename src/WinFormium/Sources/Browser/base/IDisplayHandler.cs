// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IDisplayHandler
{
    void OnAddressChange(CefBrowser browser, CefFrame frame, string url);
    void OnTitleChange(CefBrowser browser, string title);
    void OnFaviconUrlChange(CefBrowser browser, string[] iconUrls);
    void OnFullscreenModeChange(CefBrowser browser, bool fullscreen);
    bool OnTooltip(CefBrowser browser, string text);
    void OnStatusMessage(CefBrowser browser, string value);
    bool OnConsoleMessage(CefBrowser browser, CefLogSeverity level, string message, string source, int line);
    bool OnAutoResize(CefBrowser browser, ref CefSize newSize);
    void OnLoadingProgressChange(CefBrowser browser, double progress);
    bool OnCursorChange(CefBrowser browser, nint cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo);
    void OnMediaAccessChange(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess);
}
