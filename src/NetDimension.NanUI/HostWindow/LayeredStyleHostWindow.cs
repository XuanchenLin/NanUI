 using Xilium.CefGlue;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

internal class LayeredStyleHostWindow : BorderlessWindow, IFormiumHostWindow
{
    const int WS_EX_LAYERED = 0x00080000;
    private ImeHandler imeHandler;

    public WindowMessageDelegate OnWindowsMessage { get; set; }

    public WindowMessageDelegate OnDefWindowsMessage { get; set; }

    public Formium Formium { get; }

    private CefBrowserHost BrowserHost => Formium?.Browser?.GetHost();

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams createParams = base.CreateParams;
            createParams.ExStyle |= WS_EX_LAYERED;
            return createParams;
        }
    }
    public LayeredStyleHostWindow(Formium formium)
    {
        Formium = formium;

        imeHandler = new ImeHandler(formium);
    }


    protected override bool CanEnableIme => true;


    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        imeHandler.EnableIME();

        SystemDpiChanged += SystemDpiChangedHandler;
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
                    imeHandler.OnIMESetContext(msg, m.WParam, m.LParam);
                }
                return;
            case WindowMessage.WM_IME_STARTCOMPOSITION:
                {
                    imeHandler.OnImeStartComposition();
                }
                return;
            case WindowMessage.WM_IME_COMPOSITION:
                {
                    imeHandler.OnImeComposition(msg, m.WParam, m.LParam);
                }
                return;
            case WindowMessage.WM_IME_ENDCOMPOSITION:
                {
                    imeHandler.OnImeCancelCompositionEvent();
                }
                break;

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

    protected override void OnKeyDown(KeyEventArgs e)
    {

        e.Handled = true;

        //base.OnKeyDown(e);


        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.KeyDown,
            WindowsKeyCode = (int)e.KeyCode,
            Modifiers = GetKeyboardModifiers(e.Modifiers),
        });




    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        e.Handled = true;


        //base.OnKeyUp(e);


        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.KeyUp,
            WindowsKeyCode = (int)e.KeyCode,
            Modifiers = GetKeyboardModifiers(e.Modifiers)
        });


    }



    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        //base.OnKeyPress(e);


        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.Char,
            WindowsKeyCode = e.KeyChar,
            Character = e.KeyChar,
            UnmodifiedCharacter = e.KeyChar,
        });

    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        var pt = e.Location;

        GetPointInCurrentView(ref pt);

        BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), false);
    }

    internal void ChangeCompositionRange(CefRange selectedRange, CefRectangle[] characterBounds)
    {
        if (imeHandler == null) return;

        imeHandler.ChangeCompositionRange(selectedRange, new List<CefRectangle>(characterBounds));
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
            BrowserHost?.SendFocusEvent(true);
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
            BrowserHost?.SendFocusEvent(true);
        }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        BrowserHost?.WasResized();
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        var pt = PointToClient(e.Location);

        GetPointInCurrentView(ref pt);

        BrowserHost?.SendMouseWheelEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), 0, e.Delta);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        BrowserHost?.SendFocusEvent(false);
    }

    protected override void OnGotFocus(EventArgs e)
    {
        BrowserHost?.SendFocusEvent(true);
    }


    #endregion
}
