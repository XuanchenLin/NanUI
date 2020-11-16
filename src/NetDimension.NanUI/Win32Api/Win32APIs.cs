using System;
using System.Drawing;
using System.Runtime.InteropServices;


//你不需要知道这里面发生了什么。
//YOU DO NOT NEED HAVE TO KNOW WHAT IS HAPPEND HERE.




public class UxTheme
{
    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    internal static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);
}

public class Shell32
{
    public const int ABS_AUTOHIDE = 1;


    [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
    internal static extern int SHAppBarMessage(int dwMessage, ref APPBARDATA pData);
}

public class Dwm
{
    [DllImport("dwmapi.dll")]
    internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmIsCompositionEnabled(ref int pfEnabled);
}

public class User32
{
    private const string USER32 = "user32.dll";

    [DllImport(USER32)]
    internal static extern IntPtr BeginDeferWindowPos(int nNumWindows);

    [DllImport(USER32)]

    internal static extern bool DeferWindowPos(

        IntPtr hWinPosInfo,
        IntPtr hWnd,           // window handle
        IntPtr hWndInsertAfter,    // placement-order handle
        int X,             // horizontal position
        int Y,             // vertical position
        int cx,            // width
        int cy,            // height
        uint uFlags);          // window positioning flags

    [DllImport(USER32)]
    internal static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

    [DllImport(USER32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

    [DllImport(USER32, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

    [DllImport(USER32)]
    internal static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

    [DllImport(USER32)]
    internal static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport(USER32)]
    internal static extern IntPtr GetTopWindow(IntPtr hWnd);
    [DllImport(USER32)]
    internal static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);
    [DllImport(USER32)]
    internal static extern IntPtr TrackPopupMenu(IntPtr menuHandle, int uFlags, int x, int y, int nReserved, IntPtr hwnd, IntPtr par);


    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern void AdjustWindowRectEx(ref RECT rect, int dwStyle, bool hasMenu, int dwExSytle);


    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool AdjustWindowRectExForDpi(ref RECT rect, int dwStyle, bool hasMenu, int dwExSytle, int dpi);



    [DllImport(USER32)]
    internal static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

    [DllImport(USER32)]
    internal static extern IntPtr DefWindowProc(IntPtr hWnd, WindowsMessages uMsg, IntPtr wParam, IntPtr lParam);

    [DllImport(USER32)]
    internal static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

    [DllImport(USER32)]
    internal static extern bool IsZoomed(IntPtr hwnd);

    [DllImport(USER32)]
    internal static extern bool IsIconic(IntPtr hwnd);

    [DllImport(USER32)]
    internal static extern int GetDpiForWindow(IntPtr hWnd);

    [DllImport(USER32)]
    internal static extern IntPtr MonitorFromWindow(IntPtr hWnd, uint dwFlags);



    [DllImport("Shcore.dll")]
    internal static extern int GetScaleFactorForMonitor(IntPtr hMonitor, ref int pScale);

    [DllImport(USER32)]
    internal static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);


    [DllImport(USER32)]
    internal static extern bool InflateRect(ref RECT lprc, int dx, int dy);
    [DllImport(USER32)]
    internal static extern int GetSystemMetrics(SystemMetricFlags smIndex);

    [DllImport(USER32)]
    internal static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);
    [DllImport(USER32)]
    internal static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, int fdwOptions);

    [DllImport(USER32)]
    internal static extern void DisableProcessWindowsGhosting();
    [DllImport(USER32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

    internal static void InvalidateWindow(IntPtr hWnd)
    {
        RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, (int)(RedrawWindowFlags.RDW_FRAME | RedrawWindowFlags.RDW_UPDATENOW | RedrawWindowFlags.RDW_INVALIDATE | RedrawWindowFlags.RDW_ERASE));
    }
    [DllImport(USER32, SetLastError = true)]
    internal static extern IntPtr SetFocus(IntPtr hWnd);


    [DllImport(USER32)]
    internal static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport(USER32)]
    internal static extern int OffsetRect(ref RECT lpRect, int x, int y);
    [DllImport(USER32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool SetWindowPos(int hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int width, int height, SetWindowPosFlags flags);


    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern int MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint = false);

    /// <summary>
    /// ShowWindow function of USER32
    /// </summary>
    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool ShowWindow(int hWnd, int nCmdShow);

    /// <summary>
    /// ShowWindow function of USER32
    /// </summary>
    [DllImport(USER32)]
    internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


    /// <summary>
    /// ShowWindow function of USER32
    /// </summary>
    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern int ShowWindow(IntPtr hWnd, short cmdShow);

    [DllImport(USER32, SetLastError = true)]
    internal static extern int CloseWindow(IntPtr hWnd);

    [DllImport(USER32)]
    internal static extern int SetParent(int hWndChild, int hWndParent);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport(USER32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DestroyWindow(IntPtr hWnd);

    [DllImport(USER32, SetLastError = true)]
    internal static extern UInt16 RegisterClassW([In] ref WNDCLASS lpWndClass);

    [DllImport(USER32, SetLastError = true)]
    internal static extern IntPtr CreateWindowExW(
      UInt32 dwExStyle,
      [MarshalAs(UnmanagedType.LPWStr)] string lpClassName,
      [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName,
      UInt32 dwStyle,
      Int32 x,
      Int32 y,
      Int32 nWidth,
      Int32 nHeight,
      IntPtr hWndParent,
      IntPtr hMenu,
      IntPtr hInstance,
      IntPtr lpParam
      );

    [DllImport(USER32, CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern IntPtr CreateWindowEx(int dwExStyle, IntPtr classAtom, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    [DllImport(USER32, CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern IntPtr CreateWindowEx(long dwExStyle, IntPtr classAtom, string lpWindowName, long dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    //[DllImport(USER32, CharSet = CharSet.Unicode)]
    //internal static extern uint GetWindowLong(IntPtr hWnd, WindowLongFlags nIndex);

    //[DllImport(USER32, CharSet = CharSet.Unicode)]
    //internal static extern int SetWindowLong(IntPtr hWnd, WindowLongFlags nIndex, IntPtr newLong);

    //[DllImport(USER32, CharSet = CharSet.Unicode)]
    //internal static extern int SetWindowLong(IntPtr hWnd, WindowLongFlags nIndex, uint newLong);

    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]

    static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]

    static extern IntPtr GetWindowLong64(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]

    static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]

    static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    internal static IntPtr GetWindowLongPtr(IntPtr hWnd, WindowLongFlags nIndex)

    {

        if (IntPtr.Size == 8)

            return GetWindowLong64(hWnd, (int)nIndex);

        else

            return GetWindowLong32(hWnd, (int)nIndex);

    }

    internal static IntPtr SetWindowLongPtr(IntPtr hWnd, WindowLongFlags nIndex, IntPtr dwNewLong)

    {

        if (IntPtr.Size == 8)

            return SetWindowLong64(hWnd, (int)nIndex, dwNewLong);

        else

            return SetWindowLong32(hWnd, (int)nIndex, dwNewLong);

    }

    [DllImport(USER32, SetLastError = true)]
    internal static extern IntPtr DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern IntPtr SetCursor(IntPtr hCursor);

    [DllImport(USER32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern int GetCursorPos(ref POINT lpPoint);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern int ShowWindow(IntPtr hWnd, ShowWindowStyles cmdShow);
    [DllImport(USER32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);
    [DllImport(USER32)]
    internal static extern IntPtr GetActiveWindow();
    [DllImport(USER32)]
    internal static extern IntPtr GetForegroundWindow();

    [DllImport(USER32, CharSet = CharSet.Unicode)]
    internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport(USER32)]
    internal static extern IntPtr SetCapture(IntPtr hWnd);
    [DllImport(USER32)]
    internal static extern bool ReleaseCapture();
    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport(USER32, SetLastError = true)]
    internal static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport(USER32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern IntPtr GetSystemMenu(IntPtr windowHandle, bool bReset);

    [DllImport(USER32)]
    internal static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);

    [DllImport(USER32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

    [DllImport(USER32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);
    [DllImport(USER32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem,
   uint uEnable);
    internal const int MF_INSERT = 0x00000000;
    internal const int MF_CHANGE = 0x00000080;
    internal const int MF_APPEND = 0x00000100;
    internal const int MF_DELETE = 0x00000200;
    internal const int MF_REMOVE = 0x00001000;

    internal const int MF_BYCOMMAND = 0x00000000;
    internal const int MF_BYPOSITION = 0x00000400;

    internal const int MF_SEPARATOR = 0x00000800;

    internal const int MF_ENABLED = 0x00000000;
    internal const int MF_GRAYED = 0x00000001;
    internal const int MF_DISABLED = 0x00000002;

    internal const int MF_UNCHECKED = 0x00000000;
    internal const int MF_CHECKED = 0x00000008;
    internal const int MF_USECHECKBITMAPS = 0x00000200;

    internal const int MF_STRING = 0x00000000;
    internal const int MF_BITMAP = 0x00000004;
    internal const int MF_OWNERDRAW = 0x00000100;

    internal const int MF_POPUP = 0x00000010;
    internal const int MF_MENUBARBREAK = 0x00000020;
    internal const int MF_MENUBREAK = 0x00000040;

    internal const int MF_UNHILITE = 0x00000000;
    internal const int MF_HILITE = 0x00000080;

    internal const int MF_DEFAULT = 0x00001000;
    internal const int MF_SYSMENU = 0x00002000;
    internal const int MF_HELP = 0x00004000;
    internal const int MF_RIGHTJUSTIFY = 0x00004000;

    internal const int MF_MOUSESELECT = 0x00008000;



    [DllImport(USER32)]
    internal static extern int GetAwarenessFromDpiAwarenessContext(IntPtr dpiContext);

    [DllImport(USER32)]
    internal static extern DpiAwarenessContext GetWindowDpiAwarenessContext(IntPtr hWnd);

    [DllImport(USER32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
    internal static extern DpiAwarenessContext GetThreadDpiAwarenessContext();

    [DllImport(USER32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
    internal static extern DpiAwarenessContext SetThreadDpiAwarenessContext(DpiAwarenessContext dpiContext);

    [DllImport(USER32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
    internal static extern bool AreDpiAwarenessContextsEqual(DpiAwarenessContext dpiContextA, DpiAwarenessContext dpiContextB);


    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    internal static extern bool UpdateLayeredWindowIndirect(IntPtr hwnd,
    ref UPDATELAYEREDWINDOWINFO updateInfo);


    internal const int MONITOR_DEFAULTTONULL = 0;
    internal const int MONITOR_DEFAULTTOPRIMARY = 1;
    internal const int MONITOR_DEFAULTTONEAREST = 2;

    [DllImport(USER32, SetLastError = true)]
    internal static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);
}

public class Gdi32
{

    private const string GDI32 = "gdi32.dll";

    [DllImport(GDI32, EntryPoint = "GdiAlphaBlend")]
    internal static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);


    [DllImport(GDI32)]
    internal static extern int GetRgnBox(IntPtr hrgn, out RECT lprc);

    public const int RGN_AND = 1, RGN_OR = 2, RGN_XOR = 3, RGN_DIFF = 4, RGN_COPY = 5;


    [DllImport(GDI32, EntryPoint = "CreateRoundRectRgn")]
    internal static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


    [DllImport(GDI32, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
    internal static extern int BitBlt(HandleRef hDC, int x, int y, int nWidth, int nHeight, HandleRef hSrcDC, int xSrc, int ySrc, int dwRop);

    [DllImport(GDI32, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
    internal static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, uint dwRop);

    [DllImport(GDI32)]
    internal static extern bool LPtoDP(IntPtr hdc, [In, Out] POINT[] lpPoints, int nCount);
    [DllImport(GDI32, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
    internal static extern bool GetViewportOrgEx(IntPtr hDC, ref POINT point);
    [DllImport(GDI32)]
    internal static extern int ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, int mode);

    [DllImport(GDI32)]
    internal static extern int RestoreDC(IntPtr hdc, int savedDC);
    [DllImport(GDI32)]
    internal static extern int SaveDC(IntPtr hdc);
    [DllImport(GDI32)]
    internal static extern int GetClipRgn(IntPtr hdc, IntPtr hrgn);
    [DllImport(GDI32)]
    internal static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);
    [DllImport(GDI32)]
    internal static extern IntPtr CreatePen(PenStyle fnPenStyle, int nWidth, uint crColor);

    [DllImport(GDI32)]
    internal static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    internal static IntPtr CreateRectRgn(Rectangle rect)
    {
        return CreateRectRgn(rect.Left, rect.Top, rect.Right, rect.Bottom);
    }

    [DllImport(GDI32)]
    internal static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, int fnCombineMode);

    [DllImport(GDI32)]
    internal static extern uint SetBkColor(IntPtr hdc, int crColor);

    [DllImport(GDI32)]
    internal extern static int ExcludeClipRect(IntPtr hdc, int x1, int y1, int x2, int y2);

    [DllImport(GDI32)]
    internal static extern IntPtr CreateSolidBrush([In] uint color);

    [DllImport(GDI32)]
    internal static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport(GDI32, EntryPoint = "SelectObject", SetLastError = true)]
    internal static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

    [DllImport(GDI32)]
    internal static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);

    [DllImport(GDI32, EntryPoint = "DeleteObject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DeleteObject([In] IntPtr hObject);

    [DllImport(GDI32, EntryPoint = "CreateCompatibleDC", SetLastError = true)]
    internal static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

    [DllImport(GDI32, EntryPoint = "DeleteDC")]
    internal static extern bool DeleteDC([In] IntPtr hdc);

    [DllImport(GDI32)]
    internal static extern int GetDeviceCaps(IntPtr hdc, DeviceCap nIndex);


}

public class Kernel32
{
    internal const int PROCESS_QUERY_INFORMATION = 0x0400;
    internal const int PROCESS_VM_READ = 0x0010;
    internal const int LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800;
    private const string KERNEL32 = "Kernel32.dll";

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
    [DllImport(KERNEL32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
    internal static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern IntPtr GetModuleHandle(string modName);

    [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
    internal static extern IntPtr LoadLibraryEx(string lpModuleName, IntPtr hFile, uint dwFlags);

    [DllImport(KERNEL32, CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern IntPtr LoadLibrary(string libname);

    [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool FreeLibrary(IntPtr hModule);

    [DllImport(KERNEL32, SetLastError = true)]
    internal static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

    [DllImport(KERNEL32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CloseHandle(IntPtr handle);

    [DllImport(KERNEL32)]
    internal static extern uint GetCurrentProcessId();

    [DllImport("kernel32.dll")]
    internal static extern uint GetLastError();
}

public class Shcore
{
    [DllImport("Shcore.dll")]
    internal static extern int GetProcessDpiAwareness(IntPtr hprocess, out PROCESS_DPI_AWARENESS value);

    [DllImport("Shcore.dll")]
    internal static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);
    [DllImport("Shcore.dll")]
    internal static extern int GetDpiForMonitor(IntPtr hMonitor, MonitorDpiType dpiType, out int dpiX, out int dpiY);
    [DllImport("Shcore.dll")]
    internal static extern int GetScaleFactorForMonitor(IntPtr hMonitor, ref DeviceScaleFactor pScale);
}

