// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using static Vanara.PInvoke.User32;

namespace WinFormium.Forms;
public class WindowDpiAdapter : NativeWindow
{
    Form _targetForm;
    public WindowDpiAdapter(Form form)
    {
        _targetForm = form;


        _targetForm.HandleCreated += (_, _) =>
        {
            AssignHandle(form.Handle);

            SystemDpiManager.InitializeDpiManager();
            _deviceDpi = SystemDpiManager.DeviceDpi;


            ScaleFactor = SystemDpiManager.GetScaleFactorForWindow(Handle);

            if (SystemDpiManager.IsScalingRequirementMet && ScaleFactor != 1.0f)
            {
                form.Scale(new SizeF(ScaleFactor, ScaleFactor));
            }


        };


        _targetForm.HandleDestroyed += (_, _) => ReleaseHandle();
    }


    protected override void WndProc(ref Message m)
    {
        if (m.Msg == (int)WindowMessage.WM_DPICHANGED)
        {
            if (WmDpiChanged(ref m))
            {
                return;
            }
        }



        base.WndProc(ref m);
    }

    private int _deviceDpi;


    internal protected float ScaleFactor { get; private set; } = 1.0f;

    internal protected int CurrentDpi => SystemDpiManager.IsPerMonitorV2Awareness ? _deviceDpi : SystemDpiManager.DeviceDpi;



    internal bool IsBoundsChangingLocked { get; private set; } = false;

    public event EventHandler<WindowDpiChangedEventArgs>? WindowDpiChanged;


    protected void CheckResetDPIAutoScale(bool force = false)
    {
        if (force)
        {
            var fi = typeof(ContainerControl).GetField("currentAutoScaleDimensions", BindingFlags.NonPublic | BindingFlags.Instance);
            var dpi = _targetForm.IsHandleCreated ? SystemDpiManager.GetDpiForWindow(Handle) : 96;
            if (fi != null)
                fi.SetValue(this, new SizeF(dpi, dpi));
        }
    }

    bool _isPerformDpiChanged = false;

    private bool WmDpiChanged(ref Message m)
    {
        if (_isPerformDpiChanged) return false;

        _isPerformDpiChanged = true;

        var oldDeviceDpi = _deviceDpi;
        var newDeviceDpi = Macros.SignedHIWORD(m.WParam);
        var suggestedRect = Marshal.PtrToStructure<RECT>(m.LParam);

        

        if (m.HWnd == (nint)0) return false;

        var hWnd = m.HWnd;

        ScaleFactor = SystemDpiManager.GetScaleFactorForWindow(hWnd);



        _deviceDpi = newDeviceDpi;

        var maxSizeState = _targetForm.MaximumSize;
        var minSizeState = _targetForm.MinimumSize;
        _targetForm.MinimumSize = Size.Empty;
        _targetForm.MaximumSize = Size.Empty;

        var scaleFactor = (float)newDeviceDpi / oldDeviceDpi;

        GetWindowRect(hWnd, out var lpCurrentRect);

//#if NET8_0_OR_GREATER

//        if (scaleFactor != 1.0f && lpCurrentRect == suggestedRect)
//        {
//            suggestedRect.Size = new Size((int)(suggestedRect.Width * scaleFactor), (int)(suggestedRect.Height * scaleFactor));
//        }

//        System.Diagnostics.Debug.WriteLine($"{scaleFactor} {lpCurrentRect.Location} {lpCurrentRect.Size} -> {suggestedRect.Location} {suggestedRect.Size}");

//#endif



        SetWindowPos(hWnd, HWND.NULL, suggestedRect.left, suggestedRect.top, suggestedRect.Width, suggestedRect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);



        _targetForm.MinimumSize = SystemDpiManager.CalcScaledSize(minSizeState, new SizeF(scaleFactor, scaleFactor));
        _targetForm.MaximumSize = SystemDpiManager.CalcScaledSize(maxSizeState, new SizeF(scaleFactor, scaleFactor));


        IsBoundsChangingLocked = true;

        _targetForm.PerformLayout();
        _targetForm.Update();

        IsBoundsChangingLocked = false;

        WindowDpiChanged?.Invoke(this, new WindowDpiChangedEventArgs(oldDeviceDpi, newDeviceDpi));

        _isPerformDpiChanged = false;
        return true;
    }




}
