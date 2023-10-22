// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Collections.Specialized;
using System.ComponentModel;

using static Vanara.PInvoke.User32;


namespace WinFormium.Forms;
[StructLayout(LayoutKind.Sequential)]
internal struct NCCALCSIZE_PARAMS
{
    public RECT rgrc0, rgrc1, rgrc2;
    public WINDOWPOS lppos;
}
partial class _FackUnusedClass
{

}

public abstract class FramelessWindowBase : StandardWindowBase
{

    bool _showBorder = false;

    Color ChangeColor(Color color, float correctionFactor)
    {
        float red = (float)color.R;
        float green = (float)color.G;
        float blue = (float)color.B;

        if (correctionFactor < 0)
        {
            correctionFactor = 1 + correctionFactor;
            red *= correctionFactor;
            green *= correctionFactor;
            blue *= correctionFactor;
        }
        else
        {
            red = (255 - red) * correctionFactor + red;
            green = (255 - green) * correctionFactor + green;
            blue = (255 - blue) * correctionFactor + blue;
        }

        if (red < 0) red = 0;

        if (red > 255) red = 255;

        if (green < 0) green = 0;

        if (green > 255) green = 255;

        if (blue < 0) blue = 0;

        if (blue > 255) blue = 255;

        return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
    }

    internal protected Color BorderColor { get; set; } = Color.FromArgb(0xB2, 0xB2, blue: 0xB2);

    private Color? _inactiveBorderColor = null;

    internal protected Color InactiveBorderColor
    {
        get => _inactiveBorderColor ?? ChangeColor(BorderColor,-0.1f);
        set
        {
            if (value != _inactiveBorderColor && value.A > 0)
            {
                _inactiveBorderColor = value;

                if (_inactiveBorderColor == TRANSPARENT_COLOR)
                {
                    _inactiveBorderColor = null;
                }
            }
        }
    }


    private readonly IntPtr TRUE = new IntPtr(1);
    private readonly IntPtr FALSE = new IntPtr(0);

    protected abstract bool EnableHitTest { get; }

    internal protected bool ShowBorder
    {
        get => _showBorder;
        set
        {
            if (value != _showBorder)
            {

                _showBorder = value;

                if (!_showBorder)
                {
                    TransparencyKey = NO_BORDER_COLOR;
                }
            }

        }
    }

    internal protected FramelessWindowType RenderType { get; }

    public FramelessWindowBase(FramelessWindowType renderType)
    {
        RenderType = renderType;

        InitializeReflectedFields();

        BackColor = Color.White;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (RenderType != FramelessWindowType.DWM)
        {
            UxTheme.SetWindowTheme(WND, string.Empty, string.Empty);

            if (!ShowBorder)
            {
                TransparencyKey = NO_BORDER_COLOR;
            }
        }

        DisableProcessWindowsGhosting();
    }


    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        if (!e.Cancel)
        {
            NO_BORDER_COLOR = BorderColor;
            TransparencyKey = Color.Empty;
        }
    }

    protected override void WndProc(ref Message m)
    {
        var msg = (WindowMessage)m.Msg;

        //var dwmHandled = DwmDefWindowProc(m.HWnd, (uint)m.Msg, m.WParam, m.LParam, out var plResult);

        switch (msg)
        {
            case WindowMessage.WM_WINDOWPOSCHANGING when RenderType == FramelessWindowType.DWM:
                {
                    var wp = m.LParam.ToStructure<WINDOWPOS>();

                    var flag = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE;

                    if ((wp.flags & flag) != flag)
                    {
                        Invalidate();
                    }
                }
                break;
            case WindowMessage.WM_ACTIVATE when RenderType != FramelessWindowType.DWM:
                {
                    InvalidateNonclient();
                }
                break;
            case WindowMessage.WM_ACTIVATE when RenderType == FramelessWindowType.DWM:
                {
                    DwmExtendFrameIntoClientArea(WND, new MARGINS(0, 0, 1, 0));
                }
                break;
            case WindowMessage.WM_NCCALCSIZE when m.WParam != IntPtr.Zero:
                {
                    if (WmNCCalcSize(ref m)) return;
                }
                break;
            case WindowMessage.WM_NCACTIVATE:
                {
                    if (WmNCActivate(ref m)) return;
                }
                break;
            case WindowMessage.WM_NCPAINT when RenderType != FramelessWindowType.DWM:
                {
                    if (WmNCPaint(ref m)) return;
                }
                break;
            case WindowMessage.WM_NCPAINT when RenderType == FramelessWindowType.DWM:
                {
                    if (WmNCPaintDWM(ref m)) return;
                }
                break;
            case WindowMessage.WM_PAINT when RenderType != FramelessWindowType.DWM:
                {
                    WmPaint(ref m);
                }
                break;
            case WindowMessage.WM_NCHITTEST:
                {
                    m.Result = TRUE;
                }
                return;
            case WindowMessage.WM_SIZE:
                {
                    WmSize(ref m);
                }
                break;
            case WindowMessage.WM_SETCURSOR when EnableHitTest == true:
                {
                    if (WmSetCursorWithHitTestEnabled(ref m)) return;
                }
                break;
                //case WindowMessage.WM_LBUTTONDOWN when EnableHitTest == true:
                //    {
                //        if (WmLButtonDownWithHitTestEnabled(ref m)) return;
                //    }
                //    break;
        }

        if (WmGhostingHandler(ref m)) return;

        //if (dwmHandled)
        //{
        //    m.Result = plResult;

        //    return;
        //};

        base.WndProc(ref m);

    }



    #region WindowMessage Handlers
    private void WmSize(ref Message m)
    {
        const int SIZE_RESTORED = 0;
        const int SIZE_MAXIMIZED = 2;


        if (m.WParam == (nint)SIZE_MAXIMIZED)
        {
            _shouldPerformMaximiazedState = true;
        }

        if (m.WParam == (nint)SIZE_RESTORED)
        {
            InvalidateNonclient();
            Invalidate();

            if (!IsZoomed(m.HWnd))
            {
                Region?.Dispose();
                Region = null;
            }
        }

    }


    private bool WmNCCalcSize(ref Message m)
    {

        if (FormBorderStyle == FormBorderStyle.None) return false;

        var nccsp = Marshal.PtrToStructure<NCCALCSIZE_PARAMS>(m.LParam);
        var borders = GetNonClientMetrics();

        if (IsZoomed(WND))
        {
            nccsp.rgrc0.top -= borders.Top;
            nccsp.rgrc0.top += borders.Bottom;

            Marshal.StructureToPtr(nccsp, m.LParam, false);
        }
        else
        {
            if (RenderType == FramelessWindowType.DWM)
            {
                m.Result = TRUE;
                return true;
            }

            nccsp.rgrc0.top -= borders.Top;
            nccsp.rgrc0.bottom += borders.Bottom;
            nccsp.rgrc0.left -= borders.Left;
            nccsp.rgrc0.right += borders.Right;

            nccsp.rgrc0.top += NonclientFrameSize.Top;
            nccsp.rgrc0.bottom -= NonclientFrameSize.Bottom;
            nccsp.rgrc0.left += NonclientFrameSize.Left;
            nccsp.rgrc0.right -= NonclientFrameSize.Right;

            //if (RenderType == FramelessWindowType.DWM)
            //{
            //    //nccsp.rgrc0.top -= NonclientFrameSize.Top;
            //    //nccsp.rgrc0.bottom += NonclientFrameSize.Bottom;
            //    //nccsp.rgrc0.left -= NonclientFrameSize.Left;
            //    //nccsp.rgrc0.right += NonclientFrameSize.Right;
            //}
            //else
            //{

            //}

            //if (ShowBorder)
            //{
            //    nccsp.rgrc0.top += NonclientFrameSize.Top;
            //    nccsp.rgrc0.bottom -= NonclientFrameSize.Bottom;
            //    nccsp.rgrc0.left += NonclientFrameSize.Left;
            //    nccsp.rgrc0.right -= NonclientFrameSize.Right;
            //}
            //else
            //{
            //    nccsp.rgrc0.top += NonclientFrameSize.Top;
            //    nccsp.rgrc0.bottom -= NonclientFrameSize.Bottom;
            //    nccsp.rgrc0.left += NonclientFrameSize.Left;
            //    nccsp.rgrc0.right -= NonclientFrameSize.Right;
            //}


            Marshal.StructureToPtr(nccsp, m.LParam, false);
        }

        m.Result = new IntPtr(0x0400);

        return false;
    }


    private bool WmLButtonDownWithHitTestEnabled(ref Message m)
    {
        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));
        var mode = HitTest(point);

        ClientToScreen(WND, ref point);

        if (mode != HitTestValues.HTCLIENT && WindowState == FormWindowState.Normal)
        {
            ReleaseCapture();

            SendMessage(WND, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)mode, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));
            SendMessage(WND, (uint)WindowMessage.WM_LBUTTONUP);
            return true;
        }
        else if (WindowState != FormWindowState.Minimized)
        {
            ReleaseCapture();

            SendMessage(WND, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)HitTestValues.HTCAPTION, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));
            SendMessage(WND, (uint)WindowMessage.WM_LBUTTONUP);

            return true;
        }

        return false;
    }

    private bool WmSetCursorWithHitTestEnabled(ref Message m)
    {
        var pos = GetMessagePos();
        var point = new POINT(Macros.LOWORD(pos), Macros.HIWORD(pos));
        ScreenToClient(WND, ref point);

        var mode = HitTest(point);

        if (mode == HitTestValues.HTNOWHERE)
        {
            return false;
        }

        if (mode != HitTestValues.HTCLIENT && WindowState == FormWindowState.Normal)
        {
            SetWindowCursor(mode);

            m.Result = TRUE;

            return true;
        }

        return false;
    }



    protected override void OnWindowStateChanged(WindowChangeState state)
    {
        switch (state)
        {
            case WindowChangeState.Restore:
                Invalidate();
                InvalidateNonclient();
                break;
            case WindowChangeState.Maximize:
                Invalidate();
                InvalidateNonclient();
                break;
            case WindowChangeState.Minimize:
                break;
            default:
                break;
        }

        base.OnWindowStateChanged(state);
    }





    private void WmPaint(ref Message m)
    {

        if (Bounds.X == -32000 && Bounds.Y == -32000)
        {
            return;
        }


        if (IsZoomed(m.HWnd))
        {

            var screen = Screen.FromHandle(Handle);

            var bounds = FormBorderStyle == FormBorderStyle.None ? screen.Bounds : screen.WorkingArea;

            var regionBounds = new Rectangle(bounds.X - Bounds.X, bounds.Y - Bounds.Y, Bounds.Width - (Bounds.Width - bounds.Width), Bounds.Height - (Bounds.Height - bounds.Height));

            Region?.Dispose();
            Region = null;

            if (FormBorderStyle != FormBorderStyle.None)
            {
                Region = new Region(regionBounds);
            }
            else
            {

            }


        }
        else
        {
            Region?.Dispose();
            Region = null;
        }

    }


    private bool WmNCPaintDWM(ref Message m)
    {
        return false;
    }

    private bool WmNCPaint(ref Message m)
    {
        if (m.HWnd == IntPtr.Zero)
        {
            return false;
        };

        if (IsWindowTransparent) return true;

        //return false;
        GetWindowRect(m.HWnd, out var bounds);

        if (bounds.Width <= 0 || bounds.Height <= 0)
        {
            return false;
        }

        var dcxFlags = DCX.DCX_WINDOW | DCX.DCX_CACHE | DCX.DCX_CLIPSIBLINGS | DCX.DCX_VALIDATE;

        var hRegion = IntPtr.Zero;

        if (m.WParam != TRUE)
        {
            dcxFlags |= DCX.DCX_INTERSECTRGN;
            hRegion = m.WParam;
        }

        var dc = GetDCEx(WND, hRegion, dcxFlags);

        try
        {

            if (dc != IntPtr.Zero)
            {

                GetClientRect(m.HWnd, out var clientRect);

                OffsetRect(ref clientRect, NonclientFrameSize.Left, NonclientFrameSize.Top);

                OffsetRect(ref bounds, -bounds.left, -bounds.top);

                if (IsZoomed(m.HWnd))
                {
                    ExcludeClipRect(dc, bounds.left, bounds.top, bounds.right, bounds.bottom);
                }
                else
                {
                    ExcludeClipRect(dc, clientRect.left, clientRect.top, clientRect.right, clientRect.bottom);
                }

                var borderColor = IsWindowActivated ?
                    BorderColor :
                    InactiveBorderColor;

                using var brush = ShowBorder ? CreateSolidBrush(new COLORREF(borderColor)) : CreateSolidBrush(new COLORREF(NO_BORDER_COLOR));

                FillRect(dc, bounds, brush);
                DeleteObject(brush);
                brush.Close();

                SelectClipRgn(dc, HRGN.NULL);

                //System.Diagnostics.Debug.WriteLine("Draw Nonclient");
            }
        }
        finally
        {
            ReleaseDC(m.HWnd, dc);
        }

        m.Result = TRUE;// IntPtr.Zero;

        return true;

    }

    private bool WmNCActivate(ref Message m)
    {
        if (m.HWnd == IntPtr.Zero) return false;

        IsWindowActivated = m.WParam != IntPtr.Zero;

        if (IsIconic(m.HWnd)) return false;

        m.Result = DefWindowProc(m.HWnd, (uint)m.Msg, m.WParam, new IntPtr(-1));


        if (RenderType != FramelessWindowType.DWM)
        {
            if (m.WParam == IntPtr.Zero)
            {
                m.Result = TRUE;
                InvalidateNonclient();
                Invalidate();
            }

            return true;
        }

        return true;
    }

    private readonly WindowMessage[] NC_MESSAGES = new[]
    {
        WindowMessage.WM_NCMOUSEMOVE,
        WindowMessage.WM_NCMOUSELEAVE,
        WindowMessage.WM_NCLBUTTONDOWN,
        WindowMessage.WM_NCRBUTTONDOWN,
        WindowMessage.WM_NCLBUTTONDBLCLK,
        WindowMessage.WM_NCRBUTTONDBLCLK,
    };

    private readonly int[] GHOSTING_MESSAGES = new[]
    {
        0x00AE,
        0x00AF,
        0xC1BC
    };


    private bool WmGhostingHandler(ref Message m)
    {
        if (GHOSTING_MESSAGES.Contains(m.Msg))
        {
            m.Result = FALSE;
            InvalidateNonclient();
        }

        if (NC_MESSAGES.Contains((WindowMessage)m.Msg))
        {
            if (m.HWnd == IntPtr.Zero) return false;
            InvalidateNonclient();
            Invalidate();
        }

        return false;
    }
    #endregion


    #region WinForm Frameless Crack

    private FieldInfo? _clientWidthField;
    private FieldInfo? _clientHeightField;

    private FieldInfo? _formStateSetClientSizeField;
    private FieldInfo? _formStateField;


    protected virtual Padding NonclientFrameSize => new Padding(1);

    protected Padding GetNonClientMetrics()
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


    private void InitializeReflectedFields()
    {
        _clientWidthField = typeof(Control).GetField("_clientWidth", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
        _clientHeightField = typeof(Control).GetField("_clientHeight", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);

        _formStateSetClientSizeField = typeof(Form).GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static);
        _formStateField = typeof(Form).GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_formState", BindingFlags.NonPublic | BindingFlags.Instance);

    }

    protected override void OnSizeChanged(EventArgs e)
    {
        PatchClientSize();

        base.OnSizeChanged(e);
    }

    protected override void SetClientSizeCore(int x, int y)
    {
        if (_clientWidthField != null && _clientHeightField != null && _formStateField != null && _formStateSetClientSizeField != null)
        {

            _clientWidthField.SetValue(this, x);
            _clientHeightField.SetValue(this, y);

            var section = (BitVector32.Section)_formStateSetClientSizeField!.GetValue(this)!;

            var vector = (BitVector32)_formStateField!.GetValue(this)!;

            vector[section] = 1;

            _formStateField.SetValue(this, vector);

            OnClientSizeChanged(EventArgs.Empty);

            vector[section] = 0;

            _formStateField.SetValue(this, vector);

            Size = SizeFromClientSize(new Size(x, y));

        }
        else
        {
            base.SetClientSizeCore(x, y);
        }
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {

        if (WindowDpiAdapter?.IsBoundsChangingLocked ?? false)
        {
            return;
        }

        if (_shouldPerformMaximiazedState && WindowState != FormWindowState.Minimized)
        {
            if (y != Top)
                y = Top;

            if (x != Left)
                x = Left;

            _shouldPerformMaximiazedState = false;

        }

        var size = PatchWindowSizeInRestoreWindowBoundsIfNecessary(width, height);

        //System.Diagnostics.Debug.WriteLine($"SetBoundsCore: w×h -> {width}×{height}");

        //System.Diagnostics.Debug.WriteLine($"SetBoundsCore: size -> {size.Width}×{size.Height}");

        base.SetBoundsCore(x, y, size.Width, size.Height, specified);


    }

    internal protected override HitTestValues HitTest(Point point)
    {
        var htSize = Convert.ToInt32(Math.Ceiling(4 * WindowDpiAdapter.ScaleFactor));
        GetWindowRect(WND, out var lpRect);



        var rect = new Rectangle(Point.Empty, lpRect.Size);

        var hitTestValue = HitTestValues.HTNOWHERE;

        if (rect.Contains(point))
        {
            hitTestValue = HitTestValues.HTCLIENT;

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
        }

        return hitTestValue;
    }





    protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
    {
        var rect = base.GetScaledBounds(bounds, factor, specified);

        //var sz = SizeFromClientSize(Size.Empty);

        //System.Diagnostics.Debug.WriteLine($"GetScaledBounds: rect[before] -> {rect}");

        //System.Diagnostics.Debug.WriteLine($"GetScaledBounds: bounds -> {bounds}");

        if (!GetStyle(ControlStyles.FixedWidth) && (specified & BoundsSpecified.Width) != BoundsSpecified.None)
        {
            var clientWidth = bounds.Width;// - sz.Width;
            rect.Width = (int)Math.Round((double)(clientWidth * factor.Width));// + sz.Width;
        }

        if (!GetStyle(ControlStyles.FixedHeight) && (specified & BoundsSpecified.Height) != BoundsSpecified.None)
        {
            var clientHeight = bounds.Height;// - sz.Height;
            rect.Height = (int)Math.Round((double)(clientHeight * factor.Height));// + sz.Height;
        }

        //System.Diagnostics.Debug.WriteLine($"GetScaledBounds: rect[after] -> {rect}");

        return rect;
    }

    protected override Size SizeFromClientSize(Size clientSize)
    {
        if (RenderType != FramelessWindowType.DWM)
        {
            clientSize.Width += NonclientFrameSize.Horizontal;
            clientSize.Height += NonclientFrameSize.Vertical;
        }

        return clientSize;
    }


    private Size ClientSizeFromSize(Size size)
    {
        if (size.IsEmpty)
        {
            return Size.Empty;
        }

        var borders = GetNonClientMetrics();

        var sz = SizeFromClientSize(Size.Empty);

        var res = Size.Empty;

        switch (RenderType)
        {
            case FramelessWindowType.DWM:
                res = new Size(size.Width - borders.Horizontal, size.Height);
                break;
            case FramelessWindowType.GDI:
                res = new Size(size.Width - sz.Width, size.Height - sz.Height);
                break;
        }

        if (WindowState != FormWindowState.Maximized)
            return res;

        return RenderType != FramelessWindowType.DWM ?
            new Size(res.Width - borders.Horizontal + sz.Width, res.Height - borders.Bottom * 2 + sz.Height) :
            new Size(res.Width - borders.Horizontal, res.Height - borders.Bottom * 2);
    }


    private bool _shouldPerformMaximiazedState = false;

    private void PatchClientSize()
    {
        if (FormBorderStyle != FormBorderStyle.None)
        {
            //System.Diagnostics.Debug.WriteLine($"[PatchClientSize] Size -> {Size.Width}x{Size.Height}");
            var size = ClientSizeFromSize(Size);
            //System.Diagnostics.Debug.WriteLine($"[PatchClientSize] Client -> {size.Width}x{size.Height}");

            if (RenderType != FramelessWindowType.DWM)
            {
                _clientWidthField!.SetValue(this, size.Width);
                _clientHeightField!.SetValue(this, size.Height);
            }

        }
    }

    private void AdjustWindowRect(ref RECT rect, WindowStyles style, WindowStylesEx exStyle)
    {
        if (SystemDpiManager.IsPerMonitorV2Awareness)
        {
            AdjustWindowRectExForDpi(ref rect, style, false, exStyle, (uint)SystemDpiManager.GetDpiForWindow(WND));
        }
        else
        {
            AdjustWindowRectEx(ref rect, style, false, exStyle);
        }

    }

    private Size PatchWindowSizeInRestoreWindowBoundsIfNecessary(int width, int height)
    {
        if (WindowState == FormWindowState.Normal)
        {
            var restoredWindowBoundsSpecified = typeof(Form).GetField("restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance);
            var restoredSpecified = (BoundsSpecified)restoredWindowBoundsSpecified!.GetValue(this)!;

            if ((restoredSpecified & BoundsSpecified.Size) != BoundsSpecified.None)
            {
                var formStateExWindowBoundsFieldInfo = typeof(Form).GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static);
                var formStateExFieldInfo = typeof(Form).GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_formStateEx", BindingFlags.NonPublic | BindingFlags.Instance);
                var restoredBoundsFieldInfo = typeof(Form).GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);

                if (formStateExWindowBoundsFieldInfo != null && formStateExFieldInfo != null && restoredBoundsFieldInfo != null)
                {
                    var restoredWindowBounds = (Rectangle)restoredBoundsFieldInfo.GetValue(this)!;
                    var section = (BitVector32.Section)formStateExWindowBoundsFieldInfo.GetValue(this)!;
                    var vector = (BitVector32)formStateExFieldInfo.GetValue(this)!;
                    if (vector[section] == 1)
                    {
                        if (RenderType != FramelessWindowType.DWM)
                        {
                            width = restoredWindowBounds.Width + NonclientFrameSize.Horizontal;
                            height = restoredWindowBounds.Height + NonclientFrameSize.Vertical;
                        }
                        else
                        {
                            //var borders = GetNonClientMetrics();

                            width = restoredWindowBounds.Width;// + borders.Horizontal;
                            height = restoredWindowBounds.Height;

                        }

                    }
                }
            }
        }

        return new Size(width, height);
    }

    #endregion


}
