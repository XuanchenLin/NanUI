// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : IDisplayHandler
{
    #region interface
    void IDisplayHandler.OnAddressChange(CefBrowser browser, CefFrame frame, string url)
    {
        DisplayHandler?.OnAddressChange(browser, frame, url);

        OnPageAddressChangeCore(browser, frame, url);
    }

    bool IDisplayHandler.OnAutoResize(CefBrowser browser, ref CefSize newSize)
    {
        return DisplayHandler?.OnAutoResize(browser, ref newSize) ?? false;
    }

    bool IDisplayHandler.OnConsoleMessage(CefBrowser browser, CefLogSeverity level, string message, string source, int line)
    {
        var retval = DisplayHandler?.OnConsoleMessage(browser, level, message, source, line) ?? false;

        return retval ? retval : OnConsoleMessageCore(browser, level, message, source, line);
    }

    bool IDisplayHandler.OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
    {
        var retval = DisplayHandler?.OnCursorChange(browser, cursorHandle, type, customCursorInfo) ?? false;

        return retval ? retval : OnCursorChangeCore(browser, cursorHandle, type, customCursorInfo);
    }

    void IDisplayHandler.OnFaviconUrlChange(CefBrowser browser, string[] iconUrls)
    {
        DisplayHandler?.OnFaviconUrlChange(browser, iconUrls);

        OnFaviconUrlChangeCore(browser, iconUrls);
    }

    void IDisplayHandler.OnFullscreenModeChange(CefBrowser browser, bool fullscreen)
    {
        DisplayHandler?.OnFullscreenModeChange(browser, fullscreen);

        OnFullscreenModeChangeCore(browser, fullscreen);
    }

    void IDisplayHandler.OnLoadingProgressChange(CefBrowser browser, double progress)
    {
        DisplayHandler?.OnLoadingProgressChange(browser, progress);

        OnPageLoadingProgressChangeCore(browser, progress);
    }

    void IDisplayHandler.OnMediaAccessChange(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess)
    {
        DisplayHandler?.OnMediaAccessChange(browser, hasVideoAccess, hasAudioAccess);

        OnMediaAccessChangeCore(browser, hasVideoAccess, hasAudioAccess);
    }

    void IDisplayHandler.OnStatusMessage(CefBrowser browser, string value)
    {
        DisplayHandler?.OnStatusMessage(browser, value);

        OnStatusMessageCore(browser, value);
    }

    void IDisplayHandler.OnTitleChange(CefBrowser browser, string title)
    {
        DisplayHandler?.OnTitleChange(browser, title);

        OnPageTitleChangeCore(browser, title);
    }

    bool IDisplayHandler.OnTooltip(CefBrowser browser, string text)
    {
        var retval = DisplayHandler?.OnTooltip(browser, text) ?? false;

        return retval ? retval : OnTooltipShowCore(browser, text);
    }
    #endregion

    #region implements
    private bool OnTooltipShowCore(CefBrowser browser, string text)
    {
        var args = new TooltipEventArgs(browser, text);

        InvokeOnUIThread(OnToolTip, args);

        return args.Handled;
    }

    private void OnMediaAccessChangeCore(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess)
    {
        var args = new MediaAccessChangeEventArgs(browser, hasVideoAccess, hasAudioAccess);

        InvokeOnUIThread(OnMediaAccessChange, args);
    }

    private void OnPageLoadingProgressChangeCore(CefBrowser browser, double progress)
    {
        var args = new PageLoadingProgressChangeEventArgs(browser, (decimal)(progress * 100));

        InvokeOnUIThread(OnPageLoadingProgressChange, args);
    }

    private void OnFullscreenModeChangeCore(CefBrowser browser, bool fullscreen)
    {
        var args = new FullscreenModeChangeEventArgs(browser, fullscreen);

        InvokeOnUIThread(OnFullscreenModeChange, args);
    }

    private void OnFaviconUrlChangeCore(CefBrowser browser, string[] iconUrls)
    {
        var args = new FaviconUrlChangeEventArgs(browser, iconUrls);

        InvokeOnUIThread(OnFaviconUrlChange, args);
    }

    private bool OnConsoleMessageCore(CefBrowser browser, CefLogSeverity level, string message, string source, int line)
    {
        var args = new ConsoleMessageEventArgs(browser, level, message, source, line);

        InvokeOnUIThread(OnConsoleMessage, args);

        return args.Handled;
    }

    private void OnStatusMessageCore(CefBrowser browser, string value)
    {
        var args = new StatusMessageChangeEventArgs(browser, value);

        InvokeOnUIThread(OnStatusMessageChange, args);
    }

    private void OnPageTitleChangeCore(CefBrowser browser, string title)
    {
        var args = new PageTitleChangeEventArgs(browser, title);

        InvokeOnUIThread(OnPageTitleChange, args);
    }

    private bool OnCursorChangeCore(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
    {
        if (CurrentFormStyle.OffScreenRenderEnabled && HostWindow!=null)
        {
            InvokeOnUIThread(() =>
            {
                HostWindow.Cursor = new Cursor(cursorHandle);
            });
        }

        var args = new CursorChangeEventArgs(browser, cursorHandle, type, customCursorInfo);
        OnCursorChange(args);
        return args.Handled;
    }

    private void OnPageAddressChangeCore(CefBrowser browser, CefFrame frame, string url)
    {
        if (frame.IsMain)
        {
            var args1 = new PageAddressChangeEventArgs(browser, frame, url);

            InvokeOnUIThread(OnPageAddressChange, args1);
        }

        var args2 = new FramePageAddressChangeEventArgs(browser, frame, url);
        InvokeOnUIThread(OnFramePageAddressChange, args2);
    }
    #endregion
}
