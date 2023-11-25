// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI



using static Vanara.PInvoke.User32;

namespace WinFormium.Forms;
partial class _FackUnusedClass
{

}


public abstract class StandardWindowBase : Form
{
    internal protected HWND WND { get; protected set; }
    internal protected WindowDpiAdapter WindowDpiAdapter { get; }

    protected Color NO_BORDER_COLOR { get; set; } =  Color.FromArgb(0xFF, 0x01, 0x01, 0x01);

    protected readonly Color TRANSPARENT_COLOR = Color.Empty;// Color.FromArgb(0x00, 0x00, 0x00, 0x01);

    protected virtual bool IsWindowTransparent => false;

    internal protected Rectangle WindowRectangle
    {
        get
        {
            GetWindowRect(WND, out var windowRect);
            return System.Drawing.Rectangle.FromLTRB(windowRect.left, windowRect.top, windowRect.right, windowRect.bottom);
        }
    }

    internal protected virtual HitTestValues HitTest(Point pos)
    {
        return HitTestValues.HTNOWHERE;
    }


    public StandardWindowBase()
    {
        WindowDpiAdapter = new WindowDpiAdapter(this);

        BackColor = Color.White;
    }

    public float WindowScaleFactor => SystemDpiManager.GetScaleFactorForWindow(WND);

    protected override void OnLoad(EventArgs e)
    {

        base.OnLoad(e);


        CenterWindow();

    }

    public void ShowInvisible()
    {
        if (!IsHandleCreated)
        {
            CreateHandle();
        }
    }

    //protected override void SetVisibleCore(bool value)
    //{
    //    if (!IsHandleCreated)
    //    {
    //        value = false;
    //        CreateHandle();
    //    }


    //    base.SetVisibleCore(value);
    //}


    protected override void OnHandleCreated(EventArgs e)
    {
        //const int GCL_HBRBACKGROUND = -10;

        WND = new HWND(Handle);

        //SetClassLong(WND, GCL_HBRBACKGROUND, HBRUSH.NULL.DangerousGetHandle());

        if(FormBorderStyle!= FormBorderStyle.None)
        {
            SetWindowPos(WND, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_FRAMECHANGED);
        }



        base.OnHandleCreated(e);
    }



    protected void InvalidateNonclient()
    {
        if (Handle == IntPtr.Zero) return;

        if (IsWindowTransparent) return;

        InvalidateNonclient(WND);
    }

    protected void CenterWindow()
    {

        if (StartPosition == FormStartPosition.CenterParent && Owner != null)
        {
            Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
            Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
        else if (StartPosition == FormStartPosition.CenterScreen || (StartPosition == FormStartPosition.CenterParent && Owner == null))
        {
            var currentScreen = Screen.FromPoint(MousePosition);

            var w = WindowRectangle.Width;
            var h = WindowRectangle.Height;

            var screenLeft = 0;
            var screenTop = 0;

            if (SystemDpiManager.IsPerMonitorV2Awareness)
            {
                var screenDpi = SystemDpiManager.GetScreenDpiFromPoint(MousePosition);

                var screenScaleFactor = screenDpi / 96f / WindowDpiAdapter.ScaleFactor;

                var bounds = GetScaledBounds(WindowRectangle, new SizeF(screenScaleFactor, screenScaleFactor), BoundsSpecified.Size);

                w = bounds.Width;
                h = bounds.Height;
            }

            screenLeft += currentScreen.WorkingArea.X;
            screenTop += currentScreen.WorkingArea.Y;

            var location = default(Point);

            location.X = screenLeft + (currentScreen.WorkingArea.Width - w) / 2;
            location.Y = screenTop + (currentScreen.WorkingArea.Height - h) / 2;

            Location = location;
        }
    }

    internal SafeHCURSOR? SetWindowCursor(HitTestValues mode)
    {
        SafeHCURSOR? handle = null;

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
            var oldCursor = SetCursor(handle);

            oldCursor.Close();
        }

        return handle;
    }

    protected override void WndProc(ref Message m)
    {
        var msg = (WindowMessage)m.Msg;
        switch (msg)
        {
            case WindowMessage.WM_SIZE:
                {
                    WmSize(ref m);
                }
                break;
        }

        base.WndProc(ref m);
    }

    private WindowChangeState _lastWinState = WindowChangeState.Restore;

    private void WmSize(ref Message m)
    {
        const int SIZE_RESTORED = 0;
        const int SIZE_MINIMIZED = 1;
        const int SIZE_MAXIMIZED = 2;

        if (m.WParam == (nint)SIZE_MINIMIZED)
        {
            if (_lastWinState != WindowChangeState.Minimize)
            {
                var state = _lastWinState = WindowChangeState.Minimize;

                OnWindowStateChangedInternal(state);
            }
        }

        if (m.WParam == (nint)SIZE_MAXIMIZED)
        {
            if (_lastWinState != WindowChangeState.Maximize)
            {
                var state = _lastWinState = WindowChangeState.Maximize;

                OnWindowStateChangedInternal(state);

            }
        }

        if (m.WParam == (nint)SIZE_RESTORED)
        {
            if (_lastWinState != WindowChangeState.Restore)
            {
                var state = _lastWinState = WindowChangeState.Restore;

                OnWindowStateChangedInternal(state);
            }
        }


    }

    #region Event for Window activation state changed


    private bool _isWindowActivated = false;

    internal protected bool IsWindowActivated
    {
        get => _isWindowActivated;
        internal set
        {
            if (_isWindowActivated != value)
            {
                _isWindowActivated = value;

                OnWindowActivatedInternal();
            }
        }
    }

    internal protected FormWindowState MinMaxState
    {
        get
        {
            var retval = (WindowStyles)GetWindowLong(WND, WindowLongFlags.GWL_STYLE);

            var max = (retval & WindowStyles.WS_MAXIMIZE) > 0;
            if (max)
                return FormWindowState.Maximized;
            var min = (retval & WindowStyles.WS_MINIMIZE) > 0;
            if (min)
                return FormWindowState.Minimized;

            return FormWindowState.Normal;
        }
    }

    public event EventHandler<WindowActivatedEventArgs>? WindowActivated;

    private void OnWindowActivatedInternal()
    {
        OnWindowActivated(_isWindowActivated);
    }

    protected virtual void OnWindowActivated(bool isActivated)
    {
        WindowActivated?.Invoke(this, new WindowActivatedEventArgs(_isWindowActivated));

    }
    #endregion

    #region Event for Window state changed

    public event EventHandler<WindowStateChangedEventArgs>? WindowStateChanged;

    private void OnWindowStateChangedInternal(WindowChangeState state)
    {
        OnWindowStateChanged(state);

    }


    protected virtual void OnWindowStateChanged(WindowChangeState state)
    {
        WindowStateChanged?.Invoke(this, new WindowStateChangedEventArgs(state));
    }

    #endregion

    #region Private methods


    private void InvalidateNonclient(HWND hWnd)
    {
        if (!IsHandleCreated || IsDisposed)
            return;

        RedrawWindow(hWnd, null, HRGN.NULL, RedrawWindowFlags.RDW_FRAME | RedrawWindowFlags.RDW_UPDATENOW | RedrawWindowFlags.RDW_VALIDATE);

        UpdateWindow(hWnd);

        SetWindowPos(hWnd, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOCOPYBITS | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOREPOSITION | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
    }
    #endregion


}
