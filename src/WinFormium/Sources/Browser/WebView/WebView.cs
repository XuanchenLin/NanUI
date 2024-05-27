// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Security.Policy;

using static Vanara.PInvoke.User32;

namespace WinFormium.Browser;

internal partial class WebView
{
    public WebViewClient BrowserClient { get; private set; }
    public CefWindowInfo BrowserWindowInfo { get; private set; }
    public IntPtr BrowserHandle { get; private set; }
    public IntPtr WindowHandle { get => WebViewHost.WindowHandle; }
    public IWebViewHost WebViewHost { get; }
    public WinFormiumApp App => WebViewHost.ApplicationContext;
    public bool CanClose { get; private set; } = false;
    public bool IsBrowserInitialized { get; private set; } = false;
    public CefBrowser? Browser { get; private set; }
    public CefBrowserHost? BrowserHost => Browser?.GetHost();

    public WebViewColorMode ColorMode
    {
        get => _colorMode;
        set
        {
            if (value != _colorMode)
            {
                _colorMode = value;

                ColorModeChange();
            }
        }
    }

    public string Url
    {
        get => Browser?.GetMainFrame()?.Url ?? _url;
        set {
            _url = $"{value}".Trim();

            TaskAction.Run(() =>
            {
                if (IsBrowserInitialized)
                {
                    Browser?.GetMainFrame()?.LoadUrl(_url);
                }
            });
        }
    }

    public WebView(IWebViewHost host)
    {
        WebViewHost = host;

        BrowserWindowInfo = CefWindowInfo.Create();

        BrowserClient = new WebViewClient(this);

    }

    public void Create(CefBrowserSettings settings, WebViewHostMode renderMode = WebViewHostMode.HwndChild)
    {
        switch (renderMode)
        {
            case WebViewHostMode.HwndChild:

                BrowserWindowInfo.StyleEx |= CefGlue.Platform.Windows.WindowStyleEx.WS_EX_NOACTIVATE;

                GetClientRect(WindowHandle, out var rect);

                BrowserWindowInfo.SetAsChild(WindowHandle!, new CefRectangle(0, 0, rect.Width, rect.Height));

                break;
            case WebViewHostMode.Windowless:

                BrowserWindowInfo.SetAsWindowless(IntPtr.Zero, true);

                BrowserWindowInfo.WindowlessRenderingEnabled = true;

                break;
        }

        CefBrowserHost.CreateBrowser(BrowserWindowInfo, BrowserClient, settings, Url);
    }

    public void NotifyMoveOrResizeStarted()
    {
        BrowserHost?.NotifyMoveOrResizeStarted();
    }

    public void WasResized()
    {
        BrowserHost?.WasResized();
    }

    public void NotifyScreenInfoChanged()
    {
        BrowserHost?.NotifyScreenInfoChanged();
    }

    public void WasHidden(bool hidden)
    {
        BrowserHost?.WasHidden(hidden);
    }

    public void ResizeWebView(int width, int height)
    {
        WebViewHost.InvokeOnUIThread(() => {
            ResizeWebViewCore(width, height);
        });
    }

    public void ResizeWebViewCore(int width, int height)
    {
        if (Browser != null && BrowserHandle == IntPtr.Zero)
        {
            WasResized();

            return;
        }

        if (Browser == null || BrowserHandle == IntPtr.Zero /*|| !IsBrowserInitialized*/) return;

        if (IsIconic(WindowHandle))
        {
            SetWindowPos(BrowserHandle, HWND.NULL, 0, 0, width, height, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOACTIVATE);
        }
        else
        {
            if (WebViewHost.Formium.Visible)
            {
                SetWindowPos(BrowserHandle, HWND.NULL, 0, 0, width, height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_SHOWWINDOW);

                SetWindowLong(BrowserHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_VISIBLE));
            }
            else
            {
                SetWindowPos(BrowserHandle, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_HIDEWINDOW);

                SetWindowLong(BrowserHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_DISABLED));
            }
        }

        WasResized();

    }

    public void Dispose()
    {
        Browser?.Dispose();
    }

    public void ShowDevTools()
    {
        WebViewHost.InvokeOnUIThread(ShowDevToolsCore);
    }
    public void HideDevTools()
    {
        WebViewHost.InvokeOnUIThread(HideDevToolsCore);
    }


    public void ExecuteJavaScript(string code, string url = "", int line = 0)
    {
        var frame = Browser?.GetMainFrame();

        if (frame == null) return;

        ExecuteJavaScript(frame, code, url, line);
    }

    public void ExecuteJavaScript(CefFrame frame, string code, string url = "", int line = 0)
    {
        frame.ExecuteJavaScript(code, url, line);
    }

    public Task<JavaScriptResult> EvaluateJavaScriptAsync(string code, string url = "about:blank", int line = 0)
    {
        if (Browser == null) throw new NullReferenceException("Browser is null.");

        return EvaluateJavaScriptAsync(Browser.GetMainFrame(), code, url, line);
    }

    public Task<JavaScriptResult> EvaluateJavaScriptAsync(CefFrame frame, string code, string url = "about:blank", int line = 0)
    {
        if (JavaScriptEngine == null) throw new Exception($"{nameof(JavaScriptEngine)} is not ready at this moment.");

        return JavaScriptEngine.EvaluateJavaScriptAsync(frame, code, url, line);
    }

    public JavaScriptObjectRegisterHandle BeginRegisterJavaScriptObject(CefFrame frame)
    {
        if (JavaScriptObjectMapping == null) throw new Exception($"{nameof(JavaScriptObjectMapping)} is not ready at this moment.");

        return JavaScriptObjectMapping.BeginRegisterJavaScriptObject(frame);
    }

    public void EndRegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle)
    {
        if (JavaScriptObjectMapping == null) throw new Exception($"{nameof(JavaScriptObjectMapping)} is not ready at this moment.");

        JavaScriptObjectMapping.EndRegisterJavaScriptObject(handle);
    }

    public bool RegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle, string name, JavaScriptObject jsObject)
    {
        if (JavaScriptObjectMapping == null) throw new Exception($"{nameof(JavaScriptObjectMapping)} is not ready at this moment.");

        return JavaScriptObjectMapping.RegisterJavaScriptObject(handle, name, jsObject);
    }


    public bool RegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle, string name, JavaScriptObjectWrapper jsHostObject)
    {
        if (JavaScriptObjectMapping == null) throw new Exception($"{nameof(JavaScriptObjectMapping)} is not ready at this moment.");

        return RegisterJavaScriptObject(handle, name, jsHostObject.HostObject);
    }

    public void ShowAboutDialog()
    {
        WebViewHost.InvokeOnUIThread(() =>
        {
            var about = new AboutForm();

            about.ShowDialog(WebViewHost.Formium);
        });
    }

}
