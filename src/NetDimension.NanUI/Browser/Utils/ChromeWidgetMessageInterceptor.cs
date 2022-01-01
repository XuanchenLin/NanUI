using Vanara.PInvoke;

namespace NetDimension.NanUI.Browser;

internal class ChromeWidgetMessageInterceptor : NativeWindow
{
    private readonly Form _hostWindow;
    WindowMessageDelegate _forwardAction;

    public HWND BrowserWindowHandle { get; }

    internal ChromeWidgetMessageInterceptor(Form hostWindow, HWND browserWindowHandle, WindowMessageDelegate forwardAction)
    {
        BrowserWindowHandle = browserWindowHandle;
        AssignHandle(browserWindowHandle.DangerousGetHandle());
        _hostWindow = hostWindow;
        _forwardAction = forwardAction;


        hostWindow.HandleDestroyed += HostWindowHandleDestroyed;
    }

    private void HostWindowHandleDestroyed(object sender, EventArgs e)
    {
        ReleaseBrowserHandle();
        _hostWindow.HandleDestroyed -= HostWindowHandleDestroyed;
        _forwardAction = null;
    }

    internal void ReleaseBrowserHandle()
    {
        if (!BrowserWindowHandle.IsNull)
        {
            ReleaseHandle();
        }
    }

    protected override void WndProc(ref Message m)
    {
        var result = _forwardAction?.Invoke(ref m) ?? false;


        if (!result)
        {
            base.WndProc(ref m);
        }
    }

    internal static Task<ChromeWidgetMessageInterceptor> Setup(ChromeWidgetMessageInterceptor interceptor, Formium formium, WindowMessageDelegate forwardAction)
    {
        return Task.Run(() =>
        {
            try
            {
                var retryCount = 10;

                while (true)
                {
                    if (BrowserWidgetHandleFinder.TryFindHandle(formium.BrowserWindowHandle, out var chromeWidgetHostHandle))
                    {
                        if (interceptor == null || (interceptor != null && interceptor.BrowserWindowHandle != chromeWidgetHostHandle))
                        {
                            interceptor = new ChromeWidgetMessageInterceptor(formium.FormHostWindow, chromeWidgetHostHandle, forwardAction);

                            if (WinFormium.Runtime.IsDebuggingMode)
                            {
                                WinFormium.GetLogger().Debug("BrowserWindow has been attached successfully.");
                            }

                            return interceptor;
                        }

                        return null;
                    }
                    else
                    {
                        Thread.Sleep(200);

                        retryCount--;

                        if (retryCount <= 0)
                        {

                            if (WinFormium.Runtime.IsDebuggingMode)
                            {
                                WinFormium.GetLogger().Debug("BrowserWindow is failed to attach.");
                            }

                            return null;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        });
    }
}
