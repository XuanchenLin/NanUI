// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal partial class WebView
{
    private Dictionary<string, string> DelayedInternalScripts { get; } = new Dictionary<string, string>();


    public void InvokeOnActivated()
    {
        var code = $"formium?.hostWindow?.internal?.onWindowActivated();";

        if (!IsBrowserInitialized)
        {
            DelayedInternalScripts[nameof(InvokeOnActivated)]= code;
        }

        Browser?.GetMainFrame()?.ExecuteJavaScript(code, string.Empty, 0);

    }

    public void InvokeOnDeactivate()
    {
        var code = $"formium?.hostWindow?.internal?.onWindowDeactivate();";

        if (!IsBrowserInitialized)
        {
            DelayedInternalScripts[nameof(InvokeOnActivated)] = code;
        }

        Browser?.GetMainFrame()?.ExecuteJavaScript(code, string.Empty, 0);
    }

    public void InvokeOnWindowStateChanged(string state)
    {
        var code = $"formium?.hostWindow?.internal?.onWindowStateChanged(\"{state}\");";

        if (!IsBrowserInitialized)
        {
            DelayedInternalScripts[nameof(InvokeOnWindowStateChanged)] = code;
        }
        else
        {
            Browser?.GetMainFrame()?.ExecuteJavaScript(code, string.Empty, 0);
        }
    }

    public void InvokeOnWindowResized(Rectangle rect)
    {
        var code = $"formium?.hostWindow?.internal?.onWindowResized({rect.Left},{rect.Top},{rect.Width},{rect.Height});";

        if (!IsBrowserInitialized)
        {
            DelayedInternalScripts[nameof(InvokeOnWindowResized)] = code;
        }
        else
        {
            Browser?.GetMainFrame()?.ExecuteJavaScript(code, string.Empty, 0);
        }
    }

    public void InvokeOnWindowMoved(int x,int y)
    {
        var code = $"formium?.hostWindow?.internal?.onWindowMoved({x},{y});";

        if (!IsBrowserInitialized)
        {
            DelayedInternalScripts[nameof(InvokeOnWindowMoved)] = code;
        }
        else
        {
            Browser?.GetMainFrame()?.ExecuteJavaScript(code, string.Empty, 0);
        }
    }

    public void InvokeOnColorSchemeChanged(WebViewColorMode mode)
    {
        var code = $"formium?.hostWindow?.internal?.onColorSchemeChanged(\"{mode}\");";

        if (!IsBrowserInitialized)
        {
            DelayedInternalScripts[nameof(InvokeOnColorSchemeChanged)] = code;
        }
        else
        {
            Browser?.GetMainFrame()?.ExecuteJavaScript(code, string.Empty, 0);
        }
    }
}
