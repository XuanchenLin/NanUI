// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Browser.DevTools;

namespace WinFormium.Browser;
internal partial class WebView : IDisposable
{
    const string DEFAULT_STARTUP_URL = "formium://pages";

    private string _url = DEFAULT_STARTUP_URL;

    private WebViewColorMode _colorMode = WebViewColorMode.Light;

    DevToolsWindow? _devToolsWindow;

    public MessageBridge? MessageBridge { get; private set; }
    public JavaScriptEngineBridge? JavaScriptEngine { get; private set; }
    public JavaScriptObjectMappingBridge? JavaScriptObjectMapping { get; private set; }
    public JavaScriptWindowBindingObjectBridge? JavaScriptWindowBindingObject { get; private set; }

    public ProcessMessageDispatcher MessageDispatcher { get; } = new ProcessMessageDispatcher();




    private void ContextCreated(CefBrowser browser, CefFrame frame)
    {
        WebViewHost.ContextCreated(browser, frame);
    }

    private void ColorModeChange()
    {
        InvokeOnColorSchemeChanged(ColorMode);
    }

    private void LoadUrl(string url)
    {
        url = url.TrimStart();

        TaskAction.Run(() =>
        {
            if (IsBrowserInitialized)
            {
                Browser?.GetMainFrame()?.LoadUrl(url);
            }
            else
            {
                _url = url;
            }
        });

    }

    private void ShowDevToolsCore()
    {
        if (BrowserHost == null) return;

        if (_devToolsWindow == null || _devToolsWindow.IsDisposed)
        {
            _devToolsWindow = new DevToolsWindow(this);
        }

        User32.GetClientRect(_devToolsWindow.Handle, out var rect);

        var windowInfo = CefWindowInfo.Create();

        windowInfo.SetAsChild(_devToolsWindow.Handle, new CefRectangle(0, 0, rect.Width < 800 ? 800 : rect.Width, rect.Height < 600 ? 600 : rect.Height));

        BrowserHost.ShowDevTools(windowInfo, new DevToolsClient(_devToolsWindow), new CefBrowserSettings
        {
        }, new CefPoint(0, 0));

        if (!_devToolsWindow.Visible)
        {
            _devToolsWindow.Show();
        }
    }

    private void HideDevToolsCore()
    {
        if (BrowserHost == null) return;

        BrowserHost.CloseDevTools();
    }

}
