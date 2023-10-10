// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;

public delegate bool WindowMessageDelegate(ref Message message);

internal class BrowserRenderWidgetHostMessageInterceptor : NativeWindow
{
    private readonly Form _hostWindow;
    WindowMessageDelegate? _forwardAction;

    public HWND BrowserWindowHandle { get; }

    internal BrowserRenderWidgetHostMessageInterceptor(Form hostWindow, HWND browserWindowHandle, WindowMessageDelegate forwardAction)
    {
        BrowserWindowHandle = browserWindowHandle;
        AssignHandle(browserWindowHandle.DangerousGetHandle());
        _hostWindow = hostWindow;
        _forwardAction = forwardAction;


        hostWindow.HandleDestroyed += HostWindowHandleDestroyed;
    }

    private void HostWindowHandleDestroyed(object? sender, EventArgs e)
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

    internal static Task<BrowserRenderWidgetHostMessageInterceptor?> Setup(BrowserRenderWidgetHostMessageInterceptor? interceptor, Formium formium, WindowMessageDelegate forwardAction)
    {
        return Task.Run(() =>
        {
            try
            {
                var retryCount = 10;

                var handle = formium.BrowserHandle;

                if(handle == IntPtr.Zero)
                {
                    handle = formium.WindowHandle;
                }

                while (true)
                {
                    if (BrowserRenderWidgetHostFinder.TryFindHandle(handle, out var chromeWidgetHostHandle))
                    {
                        if (interceptor == null || (interceptor != null && interceptor.BrowserWindowHandle != chromeWidgetHostHandle))
                        {
                            interceptor = new BrowserRenderWidgetHostMessageInterceptor(formium.HostWindow!, chromeWidgetHostHandle, forwardAction);

                            System.Diagnostics.Debug.WriteLine("The browser message listener has been attached successfully.");

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
                            throw new Exception("Browser message listener attach failed.");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Instance.Log.LogError(ex);

                return null;
            }
        });
    }

}
