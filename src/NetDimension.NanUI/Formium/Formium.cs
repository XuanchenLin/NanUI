using NetDimension.NanUI.Browser;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.Logging;
using Vanara.PInvoke;
using Xilium.CefGlue;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI;

public delegate bool WindowMessageDelegate(ref Message message);


public abstract partial class Formium
{
    /// <summary>
    /// Gets the handle of host window.
    /// </summary>
    internal protected IntPtr HostWindowHandle { get; private set; }

    /// <summary>
    /// Gets the handle of browser window.
    /// </summary>
    internal protected IntPtr BrowserWindowHandle { get; private set; }

    internal FormiumWebView WebView { get; private set; }

    /// <summary>
    /// Gets the WebView is ready to use.
    /// </summary>
    protected bool IsWebViewReady => WebView?.IsReady ?? false;

    /// <summary>
    /// Gets the default logger.
    /// </summary>
    protected ILogger Logger => WinFormium.GetLogger();

    /// <summary>
    /// Sets the startup url.
    /// </summary>
    public abstract string StartUrl { get; }

    /// <summary>
    /// Gets or sets the system menu will show when right clicking in dragable regions.
    /// </summary>
    public bool AllowSystemMenu { get; set; } = true;


    public Formium()
    {
        InitializeFormium();
    }


    private void InitializeFormium()
    {
        CreateHostWindow();
    }

    internal WindowStyleBase _currentHostWindowStyle { get; private set; }

    /// <summary>
    /// Gets the extended style configurator of the specified Host Window Type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    protected T UseExtendedStyles<T>() where T : WindowStyleBase
    {
        switch (WindowType)
        {
            case HostWindowType.System:
                if (_currentHostWindowStyle is not SystemWindowStyle)
                    throw new InvalidOperationException($"The type should of`{nameof(SystemWindowStyle)}` when WindowType is {WindowType}.");
                break;
            case HostWindowType.SystemBorderless:
                if (_currentHostWindowStyle is not SystemBorderlessWindowStyle)
                    throw new InvalidOperationException($"The type should of`{nameof(SystemBorderlessWindowStyle)}` when WindowType is {WindowType}.");
                break;
            case HostWindowType.Borderless:
                if (_currentHostWindowStyle is not BorderlessWindowStyle)
                    throw new InvalidOperationException($"The type should of`{nameof(BorderlessWindowStyle)}` when WindowType is {WindowType}.");
                break;
            case HostWindowType.Kiosk:
                if (_currentHostWindowStyle is not KioskWindowStyle)
                    throw new InvalidOperationException($"The type should of`{nameof(KioskWindowStyle)}` when WindowType is {WindowType}.");
                break;
            case HostWindowType.Layered:
                if (_currentHostWindowStyle is not LayeredWindowStyle)
                    throw new InvalidOperationException($"The type should of`{nameof(LayeredWindowStyle)}` when WindowType is {WindowType}.");
                break;
        }

        return (T)_currentHostWindowStyle;
    }



    /// <summary>
    /// Setup the default browser settings.
    /// </summary>
    /// <param name="defaultBrowserSettings"></param>
    /// <returns></returns>
    protected virtual CefBrowserSettings OnCreateBrowserSettings()
    {
        return WinFormium.DefaultBrowserSettings;
    }

    /// <summary>
    /// If the browser context is ready to use.
    /// </summary>
    protected abstract void OnReady();

    internal void OnWindowAndBrowserReady()
    {
        OnReady();
        //Ready?.Invoke(this, new EventArgs());
    }

    private void ShowSystemMenu(ref Point pt)
    {
        var hMenu = GetSystemMenu(HostWindowHandle, false);
        var hCmd = TrackPopupMenuEx(hMenu, TrackPopupMenuFlags.TPM_RETURNCMD | TrackPopupMenuFlags.TPM_TOPALIGN | TrackPopupMenuFlags.TPM_LEFTALIGN, pt.X, pt.Y, HostWindowHandle);

        PostMessage(HostWindowHandle, (uint)WindowMessage.WM_SYSCOMMAND, (IntPtr)hCmd, IntPtr.Zero);
    }

    private void SetCursor(HitTestValues mode)
    {
        SafeHCURSOR handle = null;

        switch (mode)
        {
            case HitTestValues.HTTOP:
            case HitTestValues.HTBOTTOM:
                handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32645));
                break;
            case HitTestValues.HTLEFT:
            case HitTestValues.HTRIGHT:
                handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32644));
                break;
            case HitTestValues.HTTOPLEFT:
            case HitTestValues.HTBOTTOMRIGHT:
                handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32642));

                break;
            case HitTestValues.HTTOPRIGHT:
            case HitTestValues.HTBOTTOMLEFT:
                handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32643));
                break;
        }


        if (handle != null)
        {
            var oldCursor = User32.SetCursor(handle);

            oldCursor.Close();
        }
    }
}
