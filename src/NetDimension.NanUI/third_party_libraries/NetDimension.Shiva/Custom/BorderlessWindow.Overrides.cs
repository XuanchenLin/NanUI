using System.Collections.Specialized;

namespace NetDimension.NanUI.HostWindow;

using Vanara.PInvoke;
using static Vanara.PInvoke.DwmApi;
using static Vanara.PInvoke.User32;

partial class _FackUnusedClass
{

}


internal partial class BorderlessWindow
{

    protected HWND hWnd { get; private set; }

    public BorderlessWindow()
    {
        AutoScaleMode = AutoScaleMode.None;


        //SetStyle(
        //     ControlStyles.AllPaintingInWmPaint |
        //     ControlStyles.UserPaint |
        //     ControlStyles.OptimizedDoubleBuffer
        //, true);

        SetStyle(ControlStyles.ResizeRedraw, true);

        Padding = Padding.Empty;

        Text = "NanUI Host Window";

        InitializeReflectedFields();



    }



    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);



        hWnd = new HWND(Handle);

        //DwmSetWindowAttribute(hWnd, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, DWMNCRENDERINGPOLICY.DWMNCRP_ENABLED);


        DpiHelper.InitializeDpiHelper();

        _deviceDpi = DpiHelper.DeviceDpi;

        UxTheme.SetWindowTheme(hWnd, string.Empty, string.Empty);
        DisableProcessWindowsGhosting();

        ScaleFactor = DpiHelper.GetScaleFactorForWindow(Handle);

        if (DpiHelper.IsScalingRequirementMet && ScaleFactor != 1.0f)
        {
            Scale(new SizeF(ScaleFactor, ScaleFactor));
        }


        SetWindowPos(hWnd, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_FRAMECHANGED);

        var currentScreenScaleFactor = DpiHelper.GetDpiForWindow(Handle);

        var primaryScreenScaleFactor = DpiHelper.GetScreenDpi(Screen.PrimaryScreen) / 96f;

        if (primaryScreenScaleFactor != 1.0f)
        {
            Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size / primaryScreenScaleFactor), Font.Style);
        }

        Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size * currentScreenScaleFactor), Font.Style);

        SetWindowCenter();

        _isLoaded = true;


    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
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

    protected override void OnLoad(EventArgs e)
    {
        InitializeDropShadows();


        base.OnLoad(e);



        if (MinMaxState == FormWindowState.Normal)
        {
            EnableShadow(true);
        }
        else
        {
            EnableShadow(false);
        }
    }




    protected override void OnSizeChanged(EventArgs e)
    {
        PatchClientSize();

        base.OnSizeChanged(e);
    }

    

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        DestroyShadows();

        base.OnFormClosed(e);
    }

    protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
    {

        var rect = base.GetScaledBounds(bounds, factor, specified);

        var sz = SizeFromClientSize(Size.Empty);

        if (!GetStyle(ControlStyles.FixedWidth) && ((specified & BoundsSpecified.Width) != BoundsSpecified.None))
        {
            var clientWidth = bounds.Width - sz.Width;
            rect.Width = ((int)Math.Round((double)(clientWidth * factor.Width))) + sz.Width;
        }
        if (!GetStyle(ControlStyles.FixedHeight) && ((specified & BoundsSpecified.Height) != BoundsSpecified.None))
        {
            var clientHeight = bounds.Height - sz.Height;
            rect.Height = ((int)Math.Round((double)(clientHeight * factor.Height))) + sz.Height;
        }

        return rect;
    }


    protected Size ClientSizeFromSize(Size size)
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




    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {

        if (_isBoundsChangingLocked)
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

        base.SetBoundsCore(x, y, size.Width, size.Height, specified);


    }

    protected override void SetClientSizeCore(int x, int y)
    {
        if (_clientWidthField != null && _clientHeightField != null && _formStateField != null && _formStateSetClientSizeField != null)
        {

            _clientWidthField.SetValue(this, x);
            _clientHeightField.SetValue(this, y);

            var section = (BitVector32.Section)_formStateSetClientSizeField.GetValue(this);

            var vector = (BitVector32)_formStateField.GetValue(this);

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
}
