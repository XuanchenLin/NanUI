using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace NetDimension.NanUI.HostWindow;

using System.Collections.Specialized;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

partial class _FackUnusedClass
{

}


internal partial class BorderlessWindow : Form
{
    Size? _minimumSize = null;

    internal static readonly IntPtr TRUE = new IntPtr(1);
    internal static readonly IntPtr FALSE = new IntPtr(0);

    internal static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);
    internal static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);

    internal protected bool IsWindowFocused
    {
        get;
        internal set;
    }


    private Color _shadowColor = ColorTranslator.FromHtml("#CC000000");

    private Color? _inactiveShadowColor = null;

    private ShadowEffect _windowShadowStyle = ShadowEffect.Normal;

    private CornerStyle _windowCornerStyle = CornerStyle.Normal;

    #region Window Sizing
    private bool _shouldPerformMaximiazedState = false;

    private bool _isLoaded = false;

    private FieldInfo _clientWidthField;
    private FieldInfo _clientHeightField;
    private FieldInfo _formStateSetClientSizeField;
    private FieldInfo _formStateField;

    internal Rectangle RealFormRectangle
    {
        get
        {
            GetWindowRect(hWnd, out var windowRect);

            return new Rectangle(0, 0, windowRect.Width, windowRect.Height);
        }
    }

    internal int CornerSize => (int)CornerStyle;

    internal FormWindowState MinMaxState
    {
        get
        {
            var retval = (WindowStyles)GetWindowLong(hWnd, WindowLongFlags.GWL_STYLE);

            var max = (retval & WindowStyles.WS_MAXIMIZE) > 0;
            if (max)
                return FormWindowState.Maximized;
            var min = (retval & WindowStyles.WS_MINIMIZE) > 0;
            if (min)
                return FormWindowState.Minimized;

            return FormWindowState.Normal;
        }
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
                    var restoredBoundsFieldInfo = typeof(Form).GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance) ;

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


    private void InitializeReflectedFields()
    {
        _clientWidthField = typeof(Control).GetField("_clientWidth", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
        _clientHeightField = typeof(Control).GetField("_clientHeight", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Control).GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);

        _formStateSetClientSizeField = typeof(Form).GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static);
        _formStateField = typeof(Form).GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance) ?? typeof(Form).GetField("_formState", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    internal void SendFrameChangedMessage()
    {
        SetWindowPos(hWnd, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOCOPYBITS | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOREPOSITION | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
    }


    internal void InvalidateNonClientArea()
    {
        InvalidateNonClientArea(Rectangle.Empty);
    }

    private void InvalidateNonClientArea(Rectangle invalidRect)
    {
        if (!IsHandleCreated || IsDisposed)
            return;

        try
        {
            RedrawWindow(hWnd, null, HRGN.NULL, RedrawWindowFlags.RDW_FRAME | RedrawWindowFlags.RDW_UPDATENOW | RedrawWindowFlags.RDW_VALIDATE);

            UpdateWindow(hWnd);
        }
        catch { }
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

    internal GraphicsPath GetWindowBorderPath()
    {
        var rect = RealFormRectangle;

        return GetRoundedRectanglePath(rect, CornerSize);
    }

    private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
    {
        var roundedRect = new GraphicsPath();

        roundedRect.StartFigure();

        if (radius == 0)
        {
            roundedRect.AddRectangle(rect);
        }
        else
        {
            roundedRect.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            roundedRect.AddLine(rect.X + radius, rect.Y, rect.Right - radius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + radius * 2, rect.Right, rect.Y + rect.Height - radius * 2);
            roundedRect.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - radius * 2, rect.Bottom, rect.X + radius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - radius * 2, rect.X, rect.Y + radius * 2);
        }

        roundedRect.CloseFigure();

        return roundedRect;
    }


    internal void RemoveWindowRegion()
    {
        Region?.Dispose();

        Region = null;
    }

    internal void SetWindowRegion(GraphicsPath pathRegion)
    {
        Region oldRegion = null;

        if (Region != null)
        {
            oldRegion = Region;
        }

        Region = new Region(pathRegion);

        oldRegion?.Dispose();


    }

    internal void SetWindowRegion(Rectangle rectangleRegion)
    {
        Region oldRegion = null;

        if (Region != null)
        {
            oldRegion = Region;
        }

        Region = new Region(rectangleRegion);

        oldRegion?.Dispose();
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

    #endregion

    #region Dpi Features
    private bool _isBoundsChangingLocked = false;
    private int _deviceDpi;

    internal protected float ScaleFactor { get; private set; } = 1.0f;

    protected void CheckResetDPIAutoScale(bool force = false)
    {
        if (force)
        {
            var fi = typeof(ContainerControl).GetField("currentAutoScaleDimensions", BindingFlags.NonPublic | BindingFlags.Instance);
            var dpi = IsHandleCreated ? DpiHelper.GetDpiForWindow(hWnd) : 96;
            if (fi != null)
                fi.SetValue(this, new SizeF(dpi, dpi));
        }
    }


    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected int CurrentDpi => DpiHelper.IsPerMonitorV2Awareness ? _deviceDpi : DpiHelper.DeviceDpi;

    private bool WmDpiChanged(ref Message m)
    {
        var oldDeviceDpi = _deviceDpi;
        var newDeviceDpi = Macros.SignedHIWORD(m.WParam);
        var suggestedRect = Marshal.PtrToStructure<RECT>(m.LParam);

        if (hWnd.IsNull) return false;

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


        _isBoundsChangingLocked = true;

        PerformLayout();
        Update();

        _isBoundsChangingLocked = false;

        DrawShadowBitmap();

        SystemDpiChanged?.Invoke(this, new WindowDpiChangedEventArgs(oldDeviceDpi, newDeviceDpi));

        return true;
    }
    #endregion

    #region Hit Test

    public HitTestValues HitTest(int x, int y)
    {
        return HitTest(new Point(x, y));
    }

    public HitTestValues HitTest(Point pt)
    {
        var htSize = Convert.ToInt32(Math.Ceiling(4 * ScaleFactor));


        var rect = new Rectangle(Point.Empty, RealFormRectangle.Size);


        var corner = CornerSize;


        var x = pt.X;
        var y = pt.Y;

        HitTestValues htValue = HitTestValues.HTCLIENT;


        if (corner == 0)
        {

            if (x < rect.Left + htSize * 2 && y < rect.Top + htSize * 2)
            {
                htValue = HitTestValues.HTTOPLEFT;
            }
            else if (x >= rect.Left + htSize * 2 && x <= rect.Right - htSize * 2 && y <= rect.Top + htSize)
            {
                htValue = HitTestValues.HTTOP;
            }
            else if (x > rect.Right - htSize * 2 && y <= rect.Top + htSize * 2)
            {
                htValue = HitTestValues.HTTOPRIGHT;
            }
            else if (x <= rect.Left + htSize && y >= rect.Top + htSize * 2 && y <= rect.Bottom - htSize * 2)
            {
                htValue = HitTestValues.HTLEFT;
            }
            else if (x >= rect.Right - htSize && y >= rect.Top * 2 + htSize && y <= rect.Bottom - htSize * 2)
            {
                htValue = HitTestValues.HTRIGHT;
            }
            else if (x <= rect.Left + htSize * 2 && y >= rect.Bottom - htSize * 2)
            {
                htValue = HitTestValues.HTBOTTOMLEFT;
            }
            else if (x > rect.Left + htSize * 2 && x < rect.Right - htSize * 2 && y >= rect.Bottom - htSize)
            {
                htValue = HitTestValues.HTBOTTOM;
            }
            else if (x >= rect.Right - htSize * 2 && y >= rect.Bottom - htSize * 2)
            {
                htValue = HitTestValues.HTBOTTOMRIGHT;
            }
        }
        else
        {

            if (x < rect.Left + htSize * 2 && y < rect.Top + htSize * 2)
            {
                htValue = HitTestValues.HTTOPLEFT;
            }
            else if (x < rect.Left + corner && y < rect.Top + corner && Math.Sqrt(Math.Pow(x - (rect.Left + corner), 2) + Math.Pow(y - (rect.Top + corner), 2)) > corner / 2)
            {
                htValue = HitTestValues.HTTOPLEFT;
            }
            else if (x > rect.Right - htSize * 2 && y <= rect.Top + htSize * 2)
            {
                htValue = HitTestValues.HTTOPRIGHT;
            }
            else if ((x > rect.Right - corner && y <= rect.Top + corner) && Math.Sqrt(Math.Pow(x - (rect.Right - corner), 2) + Math.Pow(y - (rect.Top + corner), 2)) > corner / 2)
            {
                htValue = HitTestValues.HTTOPRIGHT;

            }
            else if (x <= rect.Left + htSize * 2 && y >= rect.Bottom - htSize * 2)
            {
                htValue = HitTestValues.HTBOTTOMLEFT;
            }
            else if (x <= rect.Left + corner && y >= rect.Bottom - corner && Math.Sqrt(Math.Pow(x - (rect.Left + corner), 2) + Math.Pow(y - (rect.Bottom - corner), 2)) > corner / 2)
            {
                htValue = HitTestValues.HTBOTTOMLEFT;
            }
            else if (x >= rect.Right - htSize * 2 && y >= rect.Bottom - htSize * 2)
            {
                htValue = HitTestValues.HTBOTTOMRIGHT;
            }
            else if (x >= rect.Right - corner && y >= rect.Bottom - corner && Math.Sqrt(Math.Pow(x - (rect.Right - corner), 2) + Math.Pow(y - (rect.Bottom - corner), 2)) > corner / 2)
            {
                htValue = HitTestValues.HTBOTTOMRIGHT;
            }
            else if (x >= rect.Left + corner && x <= rect.Right - corner && y <= rect.Top + htSize)
            {
                htValue = HitTestValues.HTTOP;
            }

            else if (x > rect.Left + corner && x < rect.Right - corner && y >= rect.Bottom - htSize)
            {
                htValue = HitTestValues.HTBOTTOM;
            }
            else if (x <= rect.Left + htSize && y >= rect.Top + corner && y <= rect.Bottom - corner)
            {
                htValue = HitTestValues.HTLEFT;
            }
            else if (x >= rect.Right - htSize && y >= rect.Top + corner && y <= rect.Bottom - corner)
            {
                htValue = HitTestValues.HTRIGHT;
            }
        }

        return htValue;
    }

    #endregion

}
