using Vanara.PInvoke;

using static NetDimension.NanUI.HostWindow.BorderlessWindow;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.DwmApi;
using System.Collections.Specialized;

namespace NetDimension.NanUI.HostWindow;



partial class _FackUnusedClass
{

}

internal class LayeredWindow : Form
{
    internal protected HWND hWnd { get; private set; }

    const int WS_EX_LAYERED = 0x00080000;


    private int _deviceDpi;
    internal protected new AutoScaleMode AutoScaleMode => AutoScaleMode.None;
    protected float ScaleFactor { get; private set; } = 1.0f;

    protected virtual Padding FormBorders => new Padding(0);

    public event EventHandler<WindowDpiChangedEventArgs> SystemDpiChanged;


    public LayeredWindow()
    {
        base.AutoScaleMode = AutoScaleMode.None;

        Text = "NanUI Host Window";

        Padding = Padding.Empty;

        BackColor = Color.White;

        FormBorderStyle = FormBorderStyle.FixedSingle;


        InitializeReflectedFields();

    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams createParams = base.CreateParams;
            createParams.ExStyle |= WS_EX_LAYERED;
            return createParams;
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        hWnd = new HWND(Handle);

        UxTheme.SetWindowTheme(hWnd, string.Empty, string.Empty);
        DisableProcessWindowsGhosting();

        SetWindowPos(Handle, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_FRAMECHANGED);

        DpiHelper.InitializeDpiHelper();
        _deviceDpi = DpiHelper.DeviceDpi;


        ScaleFactor = DpiHelper.GetScaleFactorForWindow(Handle);

        if (DpiHelper.IsScalingRequirementMet && ScaleFactor != 1.0f)
        {
            Scale(new SizeF(ScaleFactor, ScaleFactor));
        }

        SetWindowCenter();
    }

    internal Rectangle RealFormRectangle
    {
        get
        {
            GetWindowRect(hWnd, out var windowRect);

            return new Rectangle(0, 0, windowRect.Width, windowRect.Height);
        }
    }

    private void SetWindowCenter()
    {
        if (FormBorderStyle == FormBorderStyle.None)
            return;

        if (StartPosition == FormStartPosition.CenterParent && Owner != null)
        {
            Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
            Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
        else if (StartPosition == FormStartPosition.CenterScreen || (StartPosition == FormStartPosition.CenterParent && Owner == null))
        {
            var currentScreen = Screen.FromPoint(MousePosition);

            //var initScreen = Screen.FromHandle(Handle);

            var w = RealFormRectangle.Width;
            var h = RealFormRectangle.Height;

            var screenLeft = 0;
            var screenTop = 0;

            if (DpiHelper.IsPerMonitorV2Awareness)
            {
                var screenDpi = DpiHelper.GetScreenDpiFromPoint(MousePosition);

                var screenScaleFactor = (screenDpi / 96f) / ScaleFactor;

                var bounds = GetScaledBounds(RealFormRectangle, new SizeF(screenScaleFactor, screenScaleFactor), BoundsSpecified.Size);

                w = bounds.Width;
                h = bounds.Height;
            }

            screenLeft += currentScreen.WorkingArea.Left;
            screenTop += currentScreen.WorkingArea.Top;


            SetWindowPos(Handle, IntPtr.Zero, screenLeft + (currentScreen.WorkingArea.Width - w) / 2, screenTop + (currentScreen.WorkingArea.Height - h) / 2, RealFormRectangle.Width, RealFormRectangle.Height, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
        }

    }

    protected override void WndProc(ref Message m)
    {
        switch ((WindowMessage)m.Msg)
        {
            case WindowMessage.WM_NCCALCSIZE:
                {
                    if (!WmNCCalcSize(ref m))
                    {
                        base.WndProc(ref m);
                    }
                }
                break;
            case WindowMessage.WM_ACTIVATE:
                {
                    base.WndProc(ref m);
                    DwmExtendFrameIntoClientArea(hWnd, new MARGINS(0));

                }
                break;
            case WindowMessage.WM_DPICHANGED:
                {
                    WmDpiChanged(ref m);
                    break;
                }
            case WindowMessage.WM_SYSCOMMAND:
                {
                    WmSystemCommand(ref m);

                    break;
                }
            case WindowMessage.WM_SHOWWINDOW:
                {

                    if (m.WParam != IntPtr.Zero)
                    {
                        SetForegroundWindow(m.HWnd);
                        SetFocus(m.HWnd);


                    }

                    base.WndProc(ref m);


                }
                break;
            default:
                {
                    base.WndProc(ref m);
                    break;
                }
        }
    }

    private bool WmNCCalcSize(ref Message m)
    {
        if (m.WParam == TRUE)
        {
            var nccsp = Marshal.PtrToStructure<NCCALCSIZE_PARAMS>(m.LParam);
            var ncBorders = GetNonClientAeraBorders();

            if (WindowState != FormWindowState.Maximized && WindowState != FormWindowState.Minimized)
            {

                return true;
            }
            else if (WindowState == FormWindowState.Maximized)
            {


                nccsp.rgrc0.top -= ncBorders.Top;
                nccsp.rgrc0.top += ncBorders.Bottom;

                Marshal.StructureToPtr(nccsp, m.LParam, true);
                m.Result = MESSAGE_PROCESS;
            }
        }

        return false;
    }

    private void WmSystemCommand(ref Message m)
    {
        var state = (SysCommand)m.WParam;

        if (state == SysCommand.SC_CLOSE)
        {
            var pi = typeof(Form).GetProperty("CloseReason", BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.NonPublic);

            pi.SetValue(this, CloseReason.UserClosing, null);
        }

        if (state != SysCommand.SC_KEYMENU)
        {
            DefWndProc(ref m);
        }
    }
    private void AdjustWindowRectInternal(ref RECT rect, WindowStyles style, WindowStylesEx exStyle)
    {
        if (DpiHelper.IsPerMonitorV2Awareness)
        {
            AdjustWindowRectExForDpi(ref rect, style, false, exStyle, (uint)DpiHelper.GetDpiForWindow(hWnd));
        }
        else
        {
            AdjustWindowRectEx(ref rect, style, false, exStyle);
        }
    }

    internal Padding GetNonClientAeraBorders()
    {
        var rect = RECT.Empty;

        var screenRect = ClientRectangle;

        screenRect.Offset(-Bounds.Left, -Bounds.Top);

        rect.top = screenRect.Top;
        rect.left = screenRect.Left;
        rect.bottom = screenRect.Bottom;
        rect.right = screenRect.Right;

        AdjustWindowRectInternal(ref rect, (WindowStyles)CreateParams.Style, (WindowStylesEx)CreateParams.ExStyle);

        return new Padding
        {
            Top = screenRect.Top - rect.top,
            Left = screenRect.Left - rect.left,
            Bottom = rect.bottom - screenRect.Bottom,
            Right = rect.right - screenRect.Right
        };
    }

    private void WmDpiChanged(ref Message m)
    {
        var oldDeviceDpi = _deviceDpi;
        var newDeviceDpi = Macros.SignedHIWORD(m.WParam);
        var suggestedRect = Marshal.PtrToStructure<RECT>(m.LParam);

        ScaleFactor = DpiHelper.GetScaleFactorForWindow(hWnd);

        _deviceDpi = newDeviceDpi;

        var maxSizeState = MaximumSize;
        var minSizeState = MinimumSize;
        MinimumSize = Size.Empty;
        MaximumSize = Size.Empty;

        SetWindowPos(hWnd, HWND.NULL, suggestedRect.left, suggestedRect.top, suggestedRect.Width, suggestedRect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);


        var scaleFactor = (float)newDeviceDpi / oldDeviceDpi;

        MinimumSize = DpiHelper.CalcScaledSize(minSizeState, new SizeF(scaleFactor, scaleFactor));
        MaximumSize = DpiHelper.CalcScaledSize(maxSizeState, new SizeF(scaleFactor, scaleFactor));

        SystemDpiChanged?.Invoke(this, new WindowDpiChangedEventArgs(oldDeviceDpi, newDeviceDpi));
    }





    #region WinForm Crack

    protected override void OnSizeChanged(EventArgs e)
    {
        PatchClientSize();

        base.OnSizeChanged(e);
    }
    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {


        if (_shouldPerformMaximiazedState && WindowState != FormWindowState.Minimized)
        {
            if (y != Top)
                y = Top;

            if (x != Left)
                x = Left;

            _shouldPerformMaximiazedState = false;
        }

        var size = PatchWindowSizeInRestoreWindowBoundsIfNecessary(width, height);

        base.SetBoundsCore(x, y, size.Width, size.Height, specified);


    }
    public HitTestValues HitTest(Point point)
    {
        var htSize = Convert.ToInt32(Math.Ceiling(4 * 1.0));
        GetWindowRect(Handle, out var lpRect);

        var rect = new Rectangle(Point.Empty, lpRect.Size);

        var hitTestValue = HitTestValues.HTCLIENT;
        var x = point.X;
        var y = point.Y;

        if (x < rect.Left + htSize * 2 && y < rect.Top + htSize * 2)
        {
            hitTestValue = HitTestValues.HTTOPLEFT;
        }
        else if (x >= rect.Left + htSize * 2 && x <= rect.Right - htSize * 2 && y <= rect.Top + htSize)
        {
            hitTestValue = HitTestValues.HTTOP;
        }
        else if (x > rect.Right - htSize * 2 && y <= rect.Top + htSize * 2)
        {
            hitTestValue = HitTestValues.HTTOPRIGHT;
        }
        else if (x <= rect.Left + htSize && y >= rect.Top + htSize * 2 && y <= rect.Bottom - htSize * 2)
        {
            hitTestValue = HitTestValues.HTLEFT;
        }
        else if (x >= rect.Right - htSize && y >= rect.Top * 2 + htSize && y <= rect.Bottom - htSize * 2)
        {
            hitTestValue = HitTestValues.HTRIGHT;
        }
        else if (x <= rect.Left + htSize * 2 && y >= rect.Bottom - htSize * 2)
        {
            hitTestValue = HitTestValues.HTBOTTOMLEFT;
        }
        else if (x > rect.Left + htSize * 2 && x < rect.Right - htSize * 2 && y >= rect.Bottom - htSize)
        {
            hitTestValue = HitTestValues.HTBOTTOM;
        }
        else if (x >= rect.Right - htSize * 2 && y >= rect.Bottom - htSize * 2)
        {
            hitTestValue = HitTestValues.HTBOTTOMRIGHT;
        }

        return hitTestValue;
    }

    private Size PatchWindowSizeInRestoreWindowBoundsIfNecessary(int width, int height)
    {
        if (WindowState == FormWindowState.Normal)
        {
            try
            {
                var restoredWindowBoundsSpecified = typeof(Form).GetField("restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance);
                var restoredSpecified = (BoundsSpecified)restoredWindowBoundsSpecified.GetValue(this);

                if ((restoredSpecified & BoundsSpecified.Size) != BoundsSpecified.None)
                {
                    var formStateExWindowBoundsFieldInfo = typeof(Form).GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static);
                    var formStateExFieldInfo = typeof(Form).GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_formStateEx", BindingFlags.NonPublic | BindingFlags.Instance);
                    var restoredBoundsFieldInfo = typeof(Form).GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (formStateExWindowBoundsFieldInfo != null && formStateExFieldInfo != null && restoredBoundsFieldInfo != null)
                    {
                        var restoredWindowBounds = (Rectangle)restoredBoundsFieldInfo.GetValue(this);
                        var section = (BitVector32.Section)formStateExWindowBoundsFieldInfo.GetValue(this);
                        var vector = (BitVector32)formStateExFieldInfo.GetValue(this);
                        if (vector[section] == 1)
                        {
                            width = restoredWindowBounds.Width + FormBorders.Horizontal;
                            height = restoredWindowBounds.Height + FormBorders.Vertical;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        return new Size(width, height);
    }

    private Size ClientSizeFromSize(Size size)
    {
        if (size.IsEmpty)
        {
            return Size.Empty;
        }

        var sz = SizeFromClientSize(Size.Empty);

        var res = new Size(size.Width - sz.Width, size.Height - sz.Height);

        if (WindowState != FormWindowState.Maximized)
            return res;

        var ncBorders = GetNonClientAeraBorders();

        return new Size(res.Width - ncBorders.Horizontal + sz.Width, res.Height - ncBorders.Bottom * 2 + sz.Height);
    }

    protected override Size SizeFromClientSize(Size clientSize)
    {

        clientSize.Width += FormBorders.Horizontal;
        clientSize.Height += FormBorders.Vertical;

        return clientSize;
    }

    private bool _shouldPerformMaximiazedState = false;
    private void PatchClientSize()
    {
        if (FormBorderStyle != FormBorderStyle.None)
        {
            var size = ClientSizeFromSize(Size);
            _clientWidthField!.SetValue(this, size.Width);
            _clientHeightField!.SetValue(this, size.Height);
        }
    }

    private FieldInfo? _clientWidthField;
    private FieldInfo? _clientHeightField;

    private void InitializeReflectedFields()
    {
        _clientWidthField = typeof(Control).GetField("_clientWidth", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
        _clientHeightField = typeof(Control).GetField("_clientHeight", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);
    }
    private void AdjustWindowRect(ref RECT rect, WindowStyles style, WindowStylesEx exStyle)
    {
        AdjustWindowRectEx(ref rect, style, false, exStyle);
    }


    private void SetResizeCursor(HitTestValues mode)
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
    }
    #endregion

}
