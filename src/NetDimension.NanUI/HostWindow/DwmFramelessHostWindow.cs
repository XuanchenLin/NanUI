
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using Vanara.PInvoke;

using static Vanara.PInvoke.DwmApi;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Gdi32;


namespace NetDimension.NanUI.HostWindow;
internal class DwmFramelessHostWindow : SystemWindow, IFormiumHostWindow
{
    public DwmFramelessHostWindow(Formium formium)
    {
        Formium = formium;

        InitializeReflectedFields();

    }
    public WindowMessageDelegate OnWindowsMessage { get; set; }
    public WindowMessageDelegate OnDefWindowsMessage { get; set; }
    public Formium Formium { get; }


    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        //DwmSetWindowAttribute(hWnd, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, DWMNCRENDERINGPOLICY.DWMNCRP_ENABLED);

        //DwmExtendFrameIntoClientArea(hWnd, new MARGINS(0, this.Width, 0, this.Height));

        //DwmExtendFrameIntoClientArea(hWnd, new MARGINS(1));

        SetWindowPos(hWnd, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_FRAMECHANGED);

    }
    private void AdjustWindowRect(ref RECT rect, WindowStyles style, WindowStylesEx exStyle)
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

        AdjustWindowRect(ref rect, (WindowStyles)CreateParams.Style, (WindowStylesEx)CreateParams.ExStyle);

        return new Padding
        {
            Top = screenRect.Top - rect.top,
            Left = screenRect.Left - rect.left,
            Bottom = rect.bottom - screenRect.Bottom,
            Right = rect.right - screenRect.Right
        };
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == (int)WindowMessage.WM_NCCALCSIZE && m.WParam != IntPtr.Zero)
        {
            if (IsZoomed(hWnd))
            {
                var nccsp = Marshal.PtrToStructure<BorderlessWindow.NCCALCSIZE_PARAMS>(m.LParam);
                var ncBorders = GetNonClientAeraBorders();
                nccsp.rgrc1 = nccsp.rgrc0;
                nccsp.rgrc0.top -= ncBorders.Top;
                nccsp.rgrc0.top += ncBorders.Bottom;
                Marshal.StructureToPtr(nccsp, m.LParam, false);
                m.Result = (IntPtr)0x0400;
                base.WndProc(ref m);
            }
            else
            {
                m.Result = IntPtr.Zero;
            }

            return;
        }

        if (m.Msg == (int)WindowMessage.WM_ACTIVATE)
        {
            //DwmExtendFrameIntoClientArea(hWnd, new MARGINS(0, this.Width, 0, this.Height));
            DwmExtendFrameIntoClientArea(hWnd, new MARGINS(1));
        }

        if (m.Msg == (int)WindowMessage.WM_SIZE)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                _shouldPerformMaximiazedState = true;
            }
        }

        if(m.Msg == (int)WindowMessage.WM_PAINT)
        {

            var hdc = BeginPaint(hWnd, out var ps);

            var brush = CreateSolidBrush(new COLORREF(Color.White));

            FillRect(hdc, ps.rcPaint, brush);

            DeleteObject(brush);

            EndPaint(hWnd, ps);

            m.Result = IntPtr.Zero;

            return;
        }


        var handled = OnWindowsMessage?.Invoke(ref m) ?? false;

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

    public HitTestValues HitTest(Point point)
    {
        var htSize = Convert.ToInt32(Math.Ceiling(4 * ScaleFactor));
        GetWindowRect(hWnd, out var lpRect);

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
                var restoredWindowBoundsSpecified = typeof(Form).GetField("restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance);
                var restoredSpecified = (BoundsSpecified)restoredWindowBoundsSpecified.GetValue(this);

                if ((restoredSpecified & BoundsSpecified.Size) != BoundsSpecified.None)
                {
                    var formStateExWindowBoundsFieldInfo = typeof(Form).GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static);
                    var formStateExFieldInfo = typeof(Form).GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance);
                    var restoredBoundsFieldInfo = typeof(Form).GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (formStateExWindowBoundsFieldInfo != null && formStateExFieldInfo != null && restoredBoundsFieldInfo != null)
                    {
                        var restoredWindowBounds = (Rectangle)restoredBoundsFieldInfo.GetValue(this);
                        var section = (BitVector32.Section)formStateExWindowBoundsFieldInfo.GetValue(this);
                        var vector = (BitVector32)formStateExFieldInfo.GetValue(this);
                        if (vector[section] == 1)
                        {
                            width = restoredWindowBounds.Width;
                            height = restoredWindowBounds.Height;
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

    protected override void OnSizeChanged(EventArgs e)
    {
        PatchClientSize();

        base.OnSizeChanged(e);
    }

    protected override Size SizeFromClientSize(Size clientSize)
    {
        return clientSize;
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

    private bool _shouldPerformMaximiazedState = false;

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

    private void PatchClientSize()
    {
        if (FormBorderStyle != FormBorderStyle.None)
        {
            var size = ClientSizeFromSize(Size);
            _clientWidthField.SetValue(this, size.Width);
            _clientHeightField.SetValue(this, size.Height);
        }
    }

    private FieldInfo _clientWidthField;
    private FieldInfo _clientHeightField;

    private void InitializeReflectedFields()
    {
        _clientWidthField = typeof(Control).GetField("_clientWidth", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
        _clientHeightField = typeof(Control).GetField("_clientHeight", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);
    }
}
