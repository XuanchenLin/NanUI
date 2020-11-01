using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



internal static class DpiHelper
{
    // https://github.com/dotnet/winforms/blob/740fca0f854eac26a7cbd63b72b04f5bc962cb18/src/System.Windows.Forms/src/misc/DpiHelper.cs
    // https://github.com/dotnet/winforms/blob/740fca0f854eac26a7cbd63b72b04f5bc962cb18/src/Common/src/ApiHelper.cs

    public const float LOGICAL_DPI = 96.0f;

    /// <summary>
    /// The primary screen's (device) current DPI
    /// </summary>
    private static float deviceDpi = LOGICAL_DPI;

    private static float logicalToDeviceUnitsScalingFactor = 0.0f;

    private static bool isInitialized;
    private static bool isInitializeDpiHelper;
    private static bool doesNeedQueryForPerMonitorV2Awareness;
    private readonly static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

    private static bool isScalingRequirementMet = false;

    private static void Initialize()
    {
        if (isInitialized)
        {
            return;
        }

        var handle = NullHandleRef.Handle;

        var hDC = User32.GetDC(handle);

        if (hDC != IntPtr.Zero)
        {
            deviceDpi = Gdi32.GetDeviceCaps(new HandleRef(null, hDC).Handle, DeviceCap.LOGPIXELSX);

            User32.ReleaseDC(handle, new HandleRef(null, hDC).Handle);
        }
        isInitialized = true;

    }

    /// <summary>
    /// Transforms a horizontal or vertical integer coordinate from logical to device units
    /// by scaling it up  for current DPI and rounding to nearest integer value
    /// </summary>
    /// <param name="value">value in logical units</param>
    /// <param name="devicePixels">value in logical units</param>
    /// <returns>value in device units</returns>
    public static int LogicalToDeviceUnits(int value, int devicePixels = 0)
    {
        if (devicePixels == 0)
        {
            return (int)Math.Round(LogicalToDeviceUnitsScalingFactor * (double)value);
        }
        double scalingFactor = devicePixels / LOGICAL_DPI;
        return (int)Math.Round(scalingFactor * (double)value);
    }

    public static bool IsScalingRequired
    {
        get
        {
            Initialize();
            return deviceDpi != LOGICAL_DPI;
        }
    }

    internal static bool IsScalingRequirementMet
    {
        get
        {
            InitializeDpiHelper();
            return isScalingRequirementMet;
        }
    }

    private static double LogicalToDeviceUnitsScalingFactor
    {
        get
        {
            if (logicalToDeviceUnitsScalingFactor == 0.0)
            {
                Initialize();
                logicalToDeviceUnitsScalingFactor = deviceDpi / LOGICAL_DPI;
            }
            return logicalToDeviceUnitsScalingFactor;
        }
    }

    internal static int DeviceDpi
    {
        get
        {
            Initialize();
            return (int)deviceDpi;
        }
    }

    internal static void InitializeDpiHelper()
    {
        if (isInitializeDpiHelper)
        {
            return;
        }

        // initialize shared fields
        Initialize();

        // We are in Windows 10/1603 or greater when this API is present.
        if (ApiHelper.IsApiAvailable("Shcore.dll", nameof(Shcore.GetProcessDpiAwareness)))
        {

            // We are on Windows 10/1603 or greater all right, but we could still be DpiUnaware or SystemAware, so let's find that out...
            PROCESS_DPI_AWARENESS processDpiAwareness;
            var currentProcessId = Kernel32.GetCurrentProcessId();

            IntPtr hProcess = Kernel32.OpenProcess(Kernel32.PROCESS_QUERY_INFORMATION, false, currentProcessId);

            var result = Shcore.GetProcessDpiAwareness(hProcess, out processDpiAwareness);

            // Only if we're not, it makes sense to query for PerMonitorV2 awareness from now on, if needed.
            if (!(processDpiAwareness == PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE ||
                  processDpiAwareness == PROCESS_DPI_AWARENESS.PROCESS_SYSTEM_DPI_AWARE))
            {
                doesNeedQueryForPerMonitorV2Awareness = true;
            }
        }

        if (IsScalingRequired || doesNeedQueryForPerMonitorV2Awareness)
        {
            isScalingRequirementMet = true;
        }

        isInitializeDpiHelper = true;
    }


    internal static bool IsPerMonitorV2Awareness
    {
        get
        {
            InitializeDpiHelper();
            if (doesNeedQueryForPerMonitorV2Awareness)
            {
                // We can't cache this value because different top level windows can 
                // have different DPI awareness context for mixed mode applications.
                DpiAwarenessContext? dpiAwareness = DpiMethods.TryGetThreadDpiAwarenessContext();
                return DpiMethods.TryFindDpiAwarenessContextsEqual(dpiAwareness, DpiAwarenessContext.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            }
            else
            {
                return false;
            }
        }
    }

    internal static int GetDpiForCurrentWindow(IntPtr handle)
    {

        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = User32.MonitorFromWindow(handle, User32.MONITOR_DEFAULTTONEAREST);

            Shcore.GetDpiForMonitor(hMonitor, DpiType.Effective, out var dpiX, out var dpiY);

            return (int)dpiX;
        }

        return DeviceDpi;
    }

    internal static float GetScaleFactorForCurrentWindow(IntPtr handle)
    {
        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = User32.MonitorFromWindow(handle, User32.MONITOR_DEFAULTTONEAREST);

            Shcore.GetDpiForMonitor(hMonitor, DpiType.Effective, out var dpiX, out var dpiY);

            return dpiX / LOGICAL_DPI;
        }

        return DeviceDpi / LOGICAL_DPI;
    }

    internal static int GetScreenDpiFromPoint(Point point)
    {
        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = User32.MonitorFromPoint(new POINT(point), MonitorOptions.MONITOR_DEFAULTTONEAREST);

            Shcore.GetDpiForMonitor(hMonitor, DpiType.Effective, out var dpiX, out var dpiY);
            return (int)dpiY;

        }

        return DeviceDpi;
    }

    internal static int GetScreenDpi(Screen currentScreen)
    {
        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = User32.MonitorFromPoint(new POINT(currentScreen.Bounds.X + currentScreen.Bounds.Width / 2, currentScreen.Bounds.Y + currentScreen.Bounds.Height / 2), MonitorOptions.MONITOR_DEFAULTTONEAREST);

            Shcore.GetDpiForMonitor(hMonitor, DpiType.Effective, out var dpiX, out var dpiY);
            return (int)dpiY;

        }

        return DeviceDpi;
    }

    public static Size CalcScaledSize(Size value, SizeF scaleFactor)
    {
        return new Size(
            (int)Math.Round(value.Width * scaleFactor.Width, MidpointRounding.AwayFromZero),
            (int)Math.Round(value.Height * scaleFactor.Height, MidpointRounding.AwayFromZero));
    }


    static class DpiMethods
    {
        public static bool GetThreadDpiAwarenessContextIsAvailable()
        {
            return ApiHelper.IsApiAvailable("User32.dll", nameof(User32.GetThreadDpiAwarenessContext));
        }

        public static bool SetThreadDpiAwarenessContextIsAvailable()
        {
            return ApiHelper.IsApiAvailable("User32.dll", nameof(User32.SetThreadDpiAwarenessContext));
        }

        public static bool AreDpiAwarenessContextsEqualIsAvailable()
        {
            return ApiHelper.IsApiAvailable("User32.dll", nameof(User32.AreDpiAwarenessContextsEqual));
        }

        public static bool GetWindowDpiAwarenessContextIsAvailable()
        {
            return ApiHelper.IsApiAvailable("User32.dll", nameof(User32.GetWindowDpiAwarenessContext));
        }

        /// <summary>
        /// Tries to compare two DPIawareness context values. Return true if they were equal. 
        /// Return false when they are not equal or underlying OS does not support this API.
        /// </summary>
        /// <returns>true/false</returns>
        public static bool TryFindDpiAwarenessContextsEqual(DpiAwarenessContext? dpiContextA, DpiAwarenessContext? dpiContextB)
        {
            if (dpiContextA == null)
            {
                return (dpiContextB == null); // true if both null but not either
            }
            else if (dpiContextB == null)
            {
                return false; // because we know A is not null
            }

            if (AreDpiAwarenessContextsEqualIsAvailable())
            {
                return User32.AreDpiAwarenessContextsEqual((DpiAwarenessContext)dpiContextA, (DpiAwarenessContext)dpiContextB);
            }

            // legacy OS that does not have this API available.
            return false;
        }

        /// <summary>
        /// Tries to get thread dpi awareness context
        /// </summary>
        /// <returns> returns thread dpi awareness context if API is available in this version of OS. otherwise, return IntPtr.Zero.</returns>
        public static DpiAwarenessContext? TryGetThreadDpiAwarenessContext()
        {
            if (GetThreadDpiAwarenessContextIsAvailable())
            {
                return User32.GetThreadDpiAwarenessContext();
            }
            // legacy OS that does not have this API available.
            return null;
        }

        /// <summary>
        /// Tries to set thread dpi awareness context
        /// </summary>
        /// <returns> returns old thread dpi awareness context if API is available in this version of OS. otherwise, return IntPtr.Zero.</returns>
        public static DpiAwarenessContext? TrySetThreadDpiAwarenessContext(DpiAwarenessContext? dpiContext)
        {
            if (SetThreadDpiAwarenessContextIsAvailable())
            {
                if (dpiContext == null)
                {
                    throw new ArgumentNullException();
                }
                return User32.SetThreadDpiAwarenessContext((DpiAwarenessContext)dpiContext);
            }
            // legacy OS that does not have this API available.
            return null;
        }

        /// <summary>
        /// Tries to get window dpi awareness context
        /// </summary>
        /// <returns> returns window dpi awareness context if API is available in this version of OS. otherwise, return DpiAwarenessContext.DPI_AWARENESS_CONTEXT_UNSPECIFIED.</returns>
        public static DpiAwarenessContext? TryGetWindowDpiAwarenessContext(IntPtr hwnd)
        {
            if (GetWindowDpiAwarenessContextIsAvailable())
            {
                return User32.GetWindowDpiAwarenessContext(hwnd);
            }
            // legacy OS that does not have this API available.
            return null;
        }
    }


}


