using System.Diagnostics;

using Xilium.CefGlue;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

internal class LayeredStyleHostWindow : LayeredWindow, IFormiumHostWindow
{


    private ImeHandler imeHandler;


    public WindowMessageDelegate OnWindowsMessage { get; set; }

    public WindowMessageDelegate OnDefWindowsMessage { get; set; }

    public Formium Formium { get; }

    private CefBrowserHost BrowserHost => Formium?.Browser?.GetHost();


    public LayeredStyleHostWindow(Formium formium)
    {
        Formium = formium;

        imeHandler = new ImeHandler(Formium);


        //Formium.ContextCreated += ContextCreated;

        formium.LoadStart += Formium_LoadStart;
    }

    private void Formium_LoadStart(object sender, Browser.LoadStartEventArgs e)
    {
        imeHandler.OnImeCancelComposition();

        var host = e.Frame.Browser.GetHost();


        host.ImeSetComposition(string.Empty, 0, new CefCompositionUnderline(), new CefRange(int.MaxValue, int.MaxValue), new CefRange(0, 0));

        host.ImeCommitText(string.Empty, new CefRange(int.MaxValue, int.MaxValue), 0);

        host.ImeFinishComposingText(false);

        SendMessage(Formium.HostWindowHandle, WindowMessage.WM_IME_KEYDOWN, 0);
    }

    private void Formium_BeforeBrowse(object sender, Browser.BeforeBrowseEventArgs e)
    {

    }

    private void ContextCreated(object sender, ContextCreatedEventArgs e)
    {

        imeHandler.OnImeCancelComposition();

        var host = e.Frame.Browser.GetHost();

        host.ImeCommitText(string.Empty, new CefRange(int.MaxValue, int.MaxValue), 0);
        host.ImeSetComposition(string.Empty, 0, new CefCompositionUnderline(), new CefRange(int.MaxValue, int.MaxValue), new CefRange(0, 0));
        host.ImeFinishComposingText(false);
        SendMessage(Formium.HostWindowHandle, WindowMessage.WM_IME_KEYDOWN, 0);
    }

    protected override bool CanEnableIme => true;


    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        SystemDpiChanged += SystemDpiChangedHandler;

        ImeMode = ImeMode.Disable;

        //


    }

    private void SystemDpiChangedHandler(object sender, WindowDpiChangedEventArgs e)
    {
        BrowserHost?.NotifyScreenInfoChanged();
    }

    protected override void WndProc(ref Message m)
    {
        var handled = OnWindowsMessage?.Invoke(ref m) ?? false;

        var msg = (WindowMessage)m.Msg;

        switch (msg)
        {
            case WindowMessage.WM_LBUTTONDOWN:
                handled = Formium?.BrowserWmLButtonDown(ref m) ?? false;
                break;
            case WindowMessage.WM_RBUTTONDOWN:
                handled = Formium?.BrowserWmRButtonDown(ref m) ?? false;
                break;
            case WindowMessage.WM_RBUTTONUP:
                handled = Formium?.BrowserWmRButtonUp(ref m) ?? false;
                break;
            case WindowMessage.WM_LBUTTONDBLCLK:
                handled = Formium?.BrowserWmLButtonDbClick(ref m) ?? false;
                break;
            case WindowMessage.WM_MOUSEMOVE:
                if (Formium != null && Formium.Sizable)
                {
                    handled = Formium.BrowserWmMouseMove(ref m);
                }
                break;
            case WindowMessage.WM_SETCURSOR:
                handled = Formium?.BrowserWmSetCursor(ref m) ?? false;
                break;
            case WindowMessage.WM_IME_SETCONTEXT:
                {
                    imeHandler?.OnIMESetContext(ref m);

                }
                return;
            case WindowMessage.WM_IME_STARTCOMPOSITION:
                {
                    imeHandler?.OnImeStartComposition();
                }
                return;
            case WindowMessage.WM_IME_COMPOSITION:
                {
                    imeHandler?.OnImeComposition(msg, m.WParam, m.LParam);
                }
                return;
            case WindowMessage.WM_IME_ENDCOMPOSITION:
                {
                    imeHandler?.OnImeCancelComposition();
                    base.WndProc(ref m);

                }
                return;

        }





        if (!handled)
        {
            base.WndProc(ref m);
        }
    }


    protected override void DefWndProc(ref Message m)
    {
        var handled = OnDefWindowsMessage?.Invoke(ref m) ?? false;

        if (!handled)
        {
            base.DefWndProc(ref m);
        }
    }

    #region OSR Event handlers
    private void GetPointInCurrentView(ref Point point)
    {
        point.X = (int)(point.X / ScaleFactor);
        point.Y = (int)(point.Y / ScaleFactor);
    }

    private static CefEventFlags GetMouseModifiers(MouseButtons mouseButtons)
    {
        var modifiers = new CefEventFlags();

        if (mouseButtons == MouseButtons.Left)
            modifiers |= CefEventFlags.LeftMouseButton;

        if (mouseButtons == MouseButtons.Middle)
            modifiers |= CefEventFlags.MiddleMouseButton;

        if (mouseButtons == MouseButtons.Right)
            modifiers |= CefEventFlags.RightMouseButton;

        return modifiers;
    }

    private static CefEventFlags GetKeyboardModifiers(Keys modifiers)
    {
        var result = new CefEventFlags();

        if (modifiers == Keys.Alt)
            result |= CefEventFlags.AltDown;

        if (modifiers == Keys.Control)
            result |= CefEventFlags.ControlDown;

        if (modifiers == Keys.Shift)
            result |= CefEventFlags.ShiftDown;

        return result;
    }

    bool _isOnEditableField = false;
    internal void OnEditableField(bool v)
    {
        _isOnEditableField = v;

        if (v == true)
        {
            ImeMode = ImeMode.OnHalf;
        }
        else
        {
            ImeMode = ImeMode.Disable;
        }
    }


    protected override void OnKeyDown(KeyEventArgs e)
    {
        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.RawKeyDown,
            WindowsKeyCode = (int)e.KeyCode,
            NativeKeyCode = (int)e.KeyValue,
            Modifiers = GetKeyboardModifiers(e.Modifiers),
            FocusOnEditableField = _isOnEditableField,
        });
        base.OnKeyDown(e);

    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.KeyUp,
            WindowsKeyCode = (int)e.KeyCode,
            NativeKeyCode = (int)e.KeyValue,
            Modifiers = GetKeyboardModifiers(e.Modifiers),
            FocusOnEditableField = !_isOnEditableField,
        });

        base.OnKeyUp(e);
    }



    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        e.Handled = true;

        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.Char,
            WindowsKeyCode = e.KeyChar,
            Character = e.KeyChar,
            UnmodifiedCharacter = e.KeyChar,
            FocusOnEditableField = _isOnEditableField,
        });

        base.OnKeyPress(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        var pt = e.Location;

        GetPointInCurrentView(ref pt);

        BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), false);

    }

    internal void ChangeCompositionRange(CefRange selectedRange, CefRectangle[] characterBounds)
    {
        imeHandler?.ChangeCompositionRange(selectedRange, new List<CefRectangle>(characterBounds));
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(0, 0, CefEventFlags.None), true);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        var pt = e.Location;


        GetPointInCurrentView(ref pt);

        CefMouseButtonType? buttonType = null;

        switch (e.Button)
        {
            case MouseButtons.Right:
                buttonType = CefMouseButtonType.Right;
                break;
            case MouseButtons.Middle:
                buttonType = CefMouseButtonType.Middle;
                break;
            case MouseButtons.Left:
                buttonType = CefMouseButtonType.Left;
                break;
        }

        if (buttonType.HasValue)
        {
            BrowserHost?.SendMouseClickEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), buttonType.Value, false, e.Clicks);
            BrowserHost?.SetFocus(true);
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        var pt = e.Location;


        GetPointInCurrentView(ref pt);

        CefMouseButtonType? buttonType = null;

        switch (e.Button)
        {
            case MouseButtons.Right:
                buttonType = CefMouseButtonType.Right;
                break;
            case MouseButtons.Middle:
                buttonType = CefMouseButtonType.Middle;
                break;
            case MouseButtons.Left:
                buttonType = CefMouseButtonType.Left;
                break;
        }

        if (buttonType.HasValue)
        {
            BrowserHost?.SendMouseClickEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), buttonType.Value, true, e.Clicks);
            BrowserHost?.SetFocus(true);
        }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        BrowserHost?.NotifyMoveOrResizeStarted();

        base.OnSizeChanged(e);
        BrowserHost?.WasResized();

    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        var pt = e.Location;

        GetPointInCurrentView(ref pt);

        BrowserHost?.SendMouseWheelEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), 0, e.Delta);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        BrowserHost?.SetFocus(false);
    }

    protected override void OnGotFocus(EventArgs e)
    {
        BrowserHost?.SetFocus(true);
    }



    #endregion
}
