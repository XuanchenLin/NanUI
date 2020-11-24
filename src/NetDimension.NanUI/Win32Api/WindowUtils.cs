using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class WindowUtils
{

    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        // ...
        WCA_ACCENT_POLICY = 19
        // ...
    }

    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

    public static void EnableAcrylic(IWin32Window window/*, Color blurColor*/)
    {
        if (window is null)
            throw new ArgumentNullException(nameof(window));

        if(Environment.OSVersion.Version <= new Version(6,1) || !ApiHelper.IsApiAvailable("user32.dll", "SetWindowCompositionAttribute"))
        {
            return;
        }

        var accent = new AccentPolicy();
        accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

        var accentStructSize = Marshal.SizeOf(accent);

        var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        Marshal.StructureToPtr(accent, accentPtr, false);

        var data = new WindowCompositionAttributeData();
        data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
        data.SizeOfData = accentStructSize;
        data.Data = accentPtr;

        SetWindowCompositionAttribute(window.Handle, ref data);

        Marshal.FreeHGlobal(accentPtr);

        //var accentPolicy = new AccentPolicy
        //{
        //    AccentState = ACCENT.ENABLE_BLURBEHIND,
        //    GradientColor = 0, //ToAbgr(blurColor),
        //    //AccentFlags = (uint)AccentFlags.DrawAllBorders
        //};

        //var accentStructSize = Marshal.SizeOf(accentPolicy);
        //var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        //Marshal.StructureToPtr(accentPolicy, accentPtr, false);

        //unsafe
        //{
        //    SetWindowCompositionAttribute(
        //        window.Handle,
        //        new WindowCompositionAttributeData
        //        {
        //            Attribute = WCA.ACCENT_POLICY,
        //            Data = &accentPolicy,
        //            DataLength = Marshal.SizeOf<AccentPolicy>()
        //        });
        //}
    }

    //private static uint ToAbgr(Color color)
    //{
    //    return ((uint)color.A << 24)
    //        | ((uint)color.B << 16)
    //        | ((uint)color.G << 8)
    //        | color.R;
    //}



    //// Discovered via:
    //// https://withinrafael.com/2015/07/08/adding-the-aero-glass-blur-to-your-windows-10-apps/
    //// https://github.com/riverar/sample-win32-acrylicblur/blob/917adc277c7258307799327d12262ebd47fd0308/MainWindow.xaml.cs

    //[DllImport("user32.dll")]
    //private static extern int SetWindowCompositionAttribute(IntPtr hwnd, in WindowCompositionAttributeData data);

    //[Flags]
    //enum AccentFlags
    //{
    //    DrawLeftBorder = 0x20,
    //    DrawTopBorder = 0x40,
    //    DrawRightBorder = 0x80,
    //    DrawBottomBorder = 0x100,
    //    DrawAllBorders = (DrawLeftBorder | DrawTopBorder | DrawRightBorder | DrawBottomBorder)
    //}

    //private unsafe struct WindowCompositionAttributeData
    //{
    //    public WCA Attribute;
    //    public void* Data;
    //    public int DataLength;
    //}

    //private enum WCA
    //{
    //    ACCENT_POLICY = 19
    //}

    //private enum ACCENT
    //{
    //    DISABLED = 0,
    //    ENABLE_GRADIENT = 1,
    //    ENABLE_TRANSPARENTGRADIENT = 2,
    //    ENABLE_BLURBEHIND = 3,
    //    ENABLE_ACRYLICBLURBEHIND = 4,
    //    INVALID_STATE = 5
    //}

    //private struct AccentPolicy
    //{
    //    public ACCENT AccentState;
    //    public uint AccentFlags;
    //    public uint GradientColor;
    //    public uint AnimationId;
    //}
}
