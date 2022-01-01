using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

partial class _FackUnusedClass
{

}

internal partial class SystemWindow : Form
{
    internal protected HWND hWnd { get; private set; }

    private int _deviceDpi;
    internal protected new AutoScaleMode AutoScaleMode => AutoScaleMode.None;
    protected float ScaleFactor { get; private set; } = 1.0f;

    public SystemWindow()
    {

        base.AutoScaleMode = AutoScaleMode.None;

        Text = "NanUI Host Window";

        Padding = Padding.Empty;

        BackColor = Color.White;
    }

    protected override CreateParams CreateParams
    {
        get
        {
            var createParams = base.CreateParams;


            return createParams;
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        hWnd = new HWND(Handle);

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
            default:
                {
                    base.WndProc(ref m);
                    break;
                }
        }
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
    }
}
