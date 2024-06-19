// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using static Vanara.PInvoke.SHCore;
using static Vanara.PInvoke.User32;

namespace WinFormium.Forms;
internal static class SystemDpiManager
{
    public const float LOGICAL_DPI = 96.0f;
    private static float deviceDpi = LOGICAL_DPI;
    private static float logicalToDeviceUnitsScalingFactor = 0.0f;
    private static bool isInitialized;
    private static bool isDpiManagerInitialized;
    private static bool doesNeedQueryForPerMonitorV2Awareness;
    private static bool isScalingRequirementMet = false;

    public static double LogicalToDeviceUnitsScalingFactor
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

    public static bool IsPerMonitorV2Awareness
    {
        get
        {
            InitializeDpiManager();
            if (doesNeedQueryForPerMonitorV2Awareness)
            {
                var dpiAwareness = DpiMethods.TryGetThreadDpiAwarenessContext();
                var DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new DPI_AWARENESS_CONTEXT((nint)(-4));
                return DpiMethods.TryFindDpiAwarenessContextsEqual(dpiAwareness, DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            }
            else
            {
                return false;
            }
        }
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
            InitializeDpiManager();
            return isScalingRequirementMet;
        }
    }

    private static void Initialize()
    {
        if (isInitialized)
        {
            return;
        }

        var hDC = GetDC(HWND.NULL);

        if (hDC != (nint)0)
        {
            deviceDpi = GetDeviceCaps(hDC, DeviceCap.LOGPIXELSX);

            ReleaseDC(HWND.NULL, hDC);
        }

        isInitialized = true;

    }

    public static int LogicalToDeviceUnits(int value, int devicePixels = 0)
    {
        if (devicePixels == 0)
        {
            return (int)Math.Round(LogicalToDeviceUnitsScalingFactor * value);
        }
        double scalingFactor = devicePixels / LOGICAL_DPI;
        return (int)Math.Round(scalingFactor * value);
    }

    public static int DeviceDpi
    {
        get
        {
            Initialize();
            return (int)deviceDpi;
        }
    }

    public static void InitializeDpiManager()
    {
        if (isDpiManagerInitialized)
        {
            return;
        }

        Initialize();

        // We are in Windows 10/1603 or greater when this API is present.
        if (Win32APIAvailableHelper.IsAvailable("Shcore.dll", nameof(GetProcessDpiAwareness)))
        {

            // We are on Windows 10/1603 or greater all right, but we could still be DpiUnaware or SystemAware, so let's find that out...
            PROCESS_DPI_AWARENESS processDpiAwareness;
            var currentProcessId = Kernel32.GetCurrentProcessId();

            var PROCESS_QUERY_INFORMATION = new ACCESS_MASK(0x0400);

            var hProcess = Kernel32.OpenProcess(PROCESS_QUERY_INFORMATION, false, currentProcessId);

            var result = GetProcessDpiAwareness(hProcess, out processDpiAwareness);

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

        isDpiManagerInitialized = true;
    }

    //[DllImport("Shcore.dll", ExactSpelling = true)]
    //[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.GetDpiForMonitor")]
    //private static extern HRESULT GetDpiForMonitor([In] HMONITOR hmonitor, [In] MONITOR_DPI_TYPE dpiType, [Out] out uint dpiX, [Out] out uint dpiY);

    public static int GetDpiForWindow(HWND handle)
    {


        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = MonitorFromWindow(handle, MonitorFlags.MONITOR_DEFAULTTONEAREST);

            GetDpiForMonitor(hMonitor, MONITOR_DPI_TYPE.MDT_DEFAULT, out var dpiX, out var dpiY);

            return (int)dpiY;
        }

        return DeviceDpi;
    }

    public static float GetScaleFactorForWindow(HWND handle)
    {
        var dpi = GetDpiForWindow(handle);

        return dpi / LOGICAL_DPI;
    }

    public static int GetScreenDpiFromPoint(Point point)
    {
        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = MonitorFromPoint(point, MonitorFlags.MONITOR_DEFAULTTONEAREST);

            GetDpiForMonitor(hMonitor, MONITOR_DPI_TYPE.MDT_EFFECTIVE_DPI, out var dpiX, out _);

            return (int)dpiX;

        }

        return DeviceDpi;
    }

    public static int GetScreenDpi(Screen currentScreen)
    {
        if (IsPerMonitorV2Awareness)
        {
            var hMonitor = MonitorFromPoint(new Point(currentScreen.Bounds.X + currentScreen.Bounds.Width / 2, currentScreen.Bounds.Y + currentScreen.Bounds.Height / 2), MonitorFlags.MONITOR_DEFAULTTONEAREST);

            GetDpiForMonitor(hMonitor, MONITOR_DPI_TYPE.MDT_EFFECTIVE_DPI, out var dpiX, out _);
            return (int)dpiX;

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
            return Win32APIAvailableHelper.IsAvailable("User32.dll", nameof(GetThreadDpiAwarenessContext));
        }

        public static bool SetThreadDpiAwarenessContextIsAvailable()
        {
            return Win32APIAvailableHelper.IsAvailable("User32.dll", nameof(SetThreadDpiAwarenessContext));
        }

        public static bool AreDpiAwarenessContextsEqualIsAvailable()
        {
            return Win32APIAvailableHelper.IsAvailable("User32.dll", nameof(AreDpiAwarenessContextsEqual));
        }

        public static bool GetWindowDpiAwarenessContextIsAvailable()
        {
            return Win32APIAvailableHelper.IsAvailable("User32.dll", nameof(GetWindowDpiAwarenessContext));
        }

        /// <summary>
        /// Tries to compare two DPIawareness context values. Return true if they were equal.
        /// Return false when they are not equal or underlying OS does not support this API.
        /// </summary>
        /// <returns>true/false</returns>
        public static bool TryFindDpiAwarenessContextsEqual(DPI_AWARENESS_CONTEXT? dpiContextA, DPI_AWARENESS_CONTEXT? dpiContextB)
        {
            if (dpiContextA == null)
            {
                return dpiContextB == null; // true if both null but not either
            }
            else if (dpiContextB == null)
            {
                return false; // because we know A is not null
            }

            if (AreDpiAwarenessContextsEqualIsAvailable())
            {
                return AreDpiAwarenessContextsEqual((DPI_AWARENESS_CONTEXT)dpiContextA, (DPI_AWARENESS_CONTEXT)dpiContextB);
            }

            // legacy OS that does not have this API available.
            return false;
        }

        /// <summary>
        /// Tries to get thread dpi awareness context
        /// </summary>
        /// <returns> returns thread dpi awareness context if API is available in this version of OS. otherwise, return IntPtr.Zero.</returns>
        public static DPI_AWARENESS_CONTEXT? TryGetThreadDpiAwarenessContext()
        {
            if (GetThreadDpiAwarenessContextIsAvailable())
            {
                return GetThreadDpiAwarenessContext();
            }
            // legacy OS that does not have this API available.
            return null;
        }

        /// <summary>
        /// Tries to set thread dpi awareness context
        /// </summary>
        /// <returns> returns old thread dpi awareness context if API is available in this version of OS. otherwise, return IntPtr.Zero.</returns>
        public static DPI_AWARENESS_CONTEXT? TrySetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT? dpiContext)
        {
            if (SetThreadDpiAwarenessContextIsAvailable())
            {
                if (dpiContext == null)
                {
                    throw new ArgumentNullException();
                }
                return SetThreadDpiAwarenessContext((DPI_AWARENESS_CONTEXT)dpiContext);
            }
            // legacy OS that does not have this API available.
            return null;
        }

        /// <summary>
        /// Tries to get window dpi awareness context
        /// </summary>
        /// <returns> returns window dpi awareness context if API is available in this version of OS. otherwise, return DpiAwarenessContext.DPI_AWARENESS_CONTEXT_UNSPECIFIED.</returns>
        public static DPI_AWARENESS_CONTEXT? TryGetWindowDpiAwarenessContext(HWND hWnd)
        {
            if (GetWindowDpiAwarenessContextIsAvailable())
            {
                return GetWindowDpiAwarenessContext(hWnd);
            }
            // legacy OS that does not have this API available.
            return null;
        }
    }
}
