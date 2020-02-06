using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NetDimension.WinForm
{
	//你不需要知道这里面发生了什么。
	//YOU DO NOT NEED HAVE TO KNOW WHAT IS HAPPEND HERE.
	internal delegate IntPtr WndProcHandler(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	internal struct Win32
	{
		internal static readonly IntPtr TRUE = new IntPtr(1);
		internal static readonly IntPtr FALSE = new IntPtr(0);

		internal static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);
		internal static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);
		internal static int CornerAreaSize = SystemInformation.FrameBorderSize.Width / 2;

		internal static IntPtr MakeParam(IntPtr l, IntPtr h)
		{
			return (IntPtr)((l.ToInt32() & 0xffff) | (h.ToInt32() << 0x10));
		}

		internal static int Loword(int dwValue)
		{
			return dwValue & 0xffff;
		}


		internal static int Hiword(int dwValue)
		{
			return (dwValue >> 16) & 0xffff;
		}

		internal static POINT GetPostionFromPtr(IntPtr lparam)
		{
			var scaledX = (int)User32.LoWord(lparam);
			var scaledY = (int)User32.HiWord(lparam);

			var x = scaledX;
			var y = scaledY;

			return new POINT(x, y);
		}

		internal static HitTest GetSizeMode(POINT point, int width, int height)
		{
			HitTest mode = HitTest.HTCLIENT;

			int x = point.x, y = point.y;

			if (x < CornerAreaSize & y < CornerAreaSize)
			{
				mode = HitTest.HTTOPLEFT;
			}
			else if (x < CornerAreaSize & y + CornerAreaSize > height - CornerAreaSize)
			{
				mode = HitTest.HTBOTTOMLEFT;

			}
			else if (x + CornerAreaSize > width - CornerAreaSize & y + CornerAreaSize > height - CornerAreaSize)
			{
				mode = HitTest.HTBOTTOMRIGHT;

			}
			else if (x + CornerAreaSize > width - CornerAreaSize & y < CornerAreaSize)
			{
				mode = HitTest.HTTOPRIGHT;

			}
			else if (x < CornerAreaSize)
			{
				mode = HitTest.HTLEFT;

			}
			else if (x + CornerAreaSize > width - CornerAreaSize)
			{
				mode = HitTest.HTRIGHT;

			}
			else if (y < CornerAreaSize)
			{
				mode = HitTest.HTTOP;

			}
			else if (y + CornerAreaSize > height - CornerAreaSize)
			{
				mode = HitTest.HTBOTTOM;
			}

			return mode;
		}

	}

    public enum IDC_STANDARD_CURSORS
    {
        IDC_ARROW = 32512,
        IDC_IBEAM = 32513,
        IDC_WAIT = 32514,
        IDC_CROSS = 32515,
        IDC_UPARROW = 32516,
        IDC_SIZE = 32640,
        IDC_ICON = 32641,
        IDC_SIZENWSE = 32642,
        IDC_SIZENESW = 32643,
        IDC_SIZEWE = 32644,
        IDC_SIZENS = 32645,
        IDC_SIZEALL = 32646,
        IDC_NO = 32648,
        IDC_HAND = 32649,
        IDC_APPSTARTING = 32650,
        IDC_HELP = 32651
    }

    /// <summary>
    /// The services requested. This member can be a combination of the following values.
    /// </summary>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ms645604%28v=vs.85%29.aspx"/>
    [Flags]
    public enum TMEFlags : uint
    {
        /// <summary>
        /// The caller wants to cancel a prior tracking request. The caller should also specify the type of tracking that it wants to cancel. For example, to cancel hover tracking, the caller must pass the TME_CANCEL and TME_HOVER flags.
        /// </summary>
        TME_CANCEL = 0x80000000,
        /// <summary>
        /// The caller wants hover notification. Notification is delivered as a WM_MOUSEHOVER message.
        /// If the caller requests hover tracking while hover tracking is already active, the hover timer will be reset.
        /// This flag is ignored if the mouse pointer is not over the specified window or area.
        /// </summary>
        TME_HOVER = 0x00000001,
        /// <summary>
        /// The caller wants leave notification. Notification is delivered as a WM_MOUSELEAVE message. If the mouse is not over the specified window or area, a leave notification is generated immediately and no further tracking is performed.
        /// </summary>
        TME_LEAVE = 0x00000002,
        /// <summary>
        /// The caller wants hover and leave notification for the nonclient areas. Notification is delivered as WM_NCMOUSEHOVER and WM_NCMOUSELEAVE messages.
        /// </summary>
        TME_NONCLIENT = 0x00000010,
        /// <summary>
        /// The function fills in the structure instead of treating it as a tracking request. The structure is filled such that had that structure been passed to TrackMouseEvent, it would generate the current tracking. The only anomaly is that the hover time-out returned is always the actual time-out and not HOVER_DEFAULT, if HOVER_DEFAULT was specified during the original TrackMouseEvent request.
        /// </summary>
        TME_QUERY = 0x40000000,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TRACKMOUSEEVENTS
    {
        public uint cbSize;
        public uint dwFlags;
        public IntPtr hWnd;
        public uint dwHoverTime;
    }

    public struct MARGINS                           // struct for box shadow
	{
		public int leftWidth;
		public int rightWidth;
		public int topHeight;
		public int bottomHeight;
	}
	internal enum ABMsg : int
	{
		ABM_NEW = 0,
		ABM_REMOVE,
		ABM_QUERYPOS,
		ABM_SETPOS,
		ABM_GETSTATE,
		ABM_GETTASKBARPOS,
		ABM_ACTIVATE,
		ABM_GETAUTOHIDEBAR,
		ABM_SETAUTOHIDEBAR,
		ABM_WINDOWPOSCHANGED,
		ABM_SETSTATE
	}

	public enum WindowActiveFlags:uint {
		WA_INACTIVE = 0,
		WA_ACTIVE = 1,
		WA_CLICKACTIVE = 2
	}

	public enum ABEdge : int
	{
		ABE_LEFT = 0,
		ABE_TOP,
		ABE_RIGHT,
		ABE_BOTTOM
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct APPBARDATA
	{
		public int cbSize;
		public IntPtr hWnd;
		public uint uCallbackMessage;
		public uint uEdge;
		public RECT rc;
		public IntPtr lParam;
	}

	public enum PenStyle : int
	{
		PS_SOLID = 0, //The pen is solid.
		PS_DASH = 1, //The pen is dashed.
		PS_DOT = 2, //The pen is dotted.
		PS_DASHDOT = 3, //The pen has alternating dashes and dots.
		PS_DASHDOTDOT = 4, //The pen has alternating dashes and double dots.
		PS_NULL = 5, //The pen is invisible.
		PS_INSIDEFRAME = 6,// Normally when the edge is drawn, it’s centred on the outer edge meaning that half the width of the pen is drawn
						   // outside the shape’s edge, half is inside the shape’s edge. When PS_INSIDEFRAME is specified the edge is drawn 
						   //completely inside the outer edge of the shape.
		PS_USERSTYLE = 7,
		PS_ALTERNATE = 8,
		PS_STYLE_MASK = 0x0000000F,

		PS_ENDCAP_ROUND = 0x00000000,
		PS_ENDCAP_SQUARE = 0x00000100,
		PS_ENDCAP_FLAT = 0x00000200,
		PS_ENDCAP_MASK = 0x00000F00,

		PS_JOIN_ROUND = 0x00000000,
		PS_JOIN_BEVEL = 0x00001000,
		PS_JOIN_MITER = 0x00002000,
		PS_JOIN_MASK = 0x0000F000,

		PS_COSMETIC = 0x00000000,
		PS_GEOMETRIC = 0x00010000,
		PS_TYPE_MASK = 0x000F0000
	};

	public enum MonitorFromWindowFlags : uint
	{
		MONITOR_DEFAULTTONULL = 0x0,
		MONITORINFOF_PRIMARY = 0x1,
		MONITOR_DEFAULTTONEAREST = 0x2,
		MONITOR_DEFAULTTOPRIMARY = 0x1
	}


	internal struct SystemCommandFlags
	{
		internal const int SC_SIZE = 0xF000;
		internal const int SC_MOVE = 0xF010;
		internal const int SC_MINIMIZE = 0xF020;
		internal const int SC_MAXIMIZE = 0xF030;
		internal const int SC_NEXTWINDOW = 0xF040;
		internal const int SC_PREVWINDOW = 0xF050;
		internal const int SC_CLOSE = 0xF060;
		internal const int SC_VSCROLL = 0xF070;
		internal const int SC_HSCROLL = 0xF080;
		internal const int SC_MOUSEMENU = 0xF090;
		internal const int SC_KEYMENU = 0xF100;
		internal const int SC_ARRANGE = 0xF110;
		internal const int SC_RESTORE = 0xF120;
		internal const int SC_TASKLIST = 0xF130;
		internal const int SC_SCREENSAVE = 0xF140;
		internal const int SC_HOTKEY = 0xF150;
		internal const int SC_DEFAULT = 0xF160;
		internal const int SC_MONITORPOWER = 0xF170;
		internal const int SC_CONTEXTHELP = 0xF180;
		internal const int SC_SEPARATOR = 0xF00F;
		internal const int SCF_ISSECURE = 0x00000001;
	}

	public enum MonitorDpiType : int
	{
		MDT_EFFECTIVE_DPI = 0,
		MDT_ANGULAR_DPI = 1,
		MDT_RAW_DPI = 2,
		MDT_DEFAULT = MDT_EFFECTIVE_DPI
	}

	public enum DeviceScaleFactor
	{
		SCALE_100_PERCENT = 100,
		SCALE_120_PERCENT = 120,
		SCALE_140_PERCENT = 140,
		SCALE_150_PERCENT = 150,
		SCALE_160_PERCENT = 160,
		SCALE_180_PERCENT = 180,
		SCALE_225_PERCENT = 225
	}

	public enum SystemMetricFlags : int
	{
		/// <summary>
		/// The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.
		/// </summary>
		SM_ARRANGE = 56,

		/// <summary>
		/// The value that specifies how the system is started: 
		/// 0 Normal boot
		/// 1 Fail-safe boot
		/// 2 Fail-safe with network boot
		/// A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses the user startup files.
		/// </summary>
		SM_CLEANBOOT = 67,

		/// <summary>
		/// The number of display monitors on a desktop. For more information, see the Remarks section in this topic.
		/// </summary>
		SM_CMONITORS = 80,

		/// <summary>
		/// The number of buttons on a mouse, or zero if no mouse is installed.
		/// </summary>
		SM_CMOUSEBUTTONS = 43,

		/// <summary>
		/// The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
		/// </summary>
		SM_CXBORDER = 5,

		/// <summary>
		/// The width of a cursor, in pixels. The system cannot create cursors of other sizes.
		/// </summary>
		SM_CXCURSOR = 13,

		/// <summary>
		/// This value is the same as SM_CXFIXEDFRAME.
		/// </summary>
		SM_CXDLGFRAME = 7,

		/// <summary>
		/// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. ,
		/// The second click must occur within the rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system
		/// to consider the two clicks a double-click. The two clicks must also occur within a specified time.
		/// To set the width of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.
		/// </summary>
		SM_CXDOUBLECLK = 36,

		/// <summary>
		/// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. 
		/// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. 
		/// If this value is negative, it is subtracted from the left of the mouse-down point and added to the right of it.
		/// </summary>
		SM_CXDRAG = 68,

		/// <summary>
		/// The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.
		/// </summary>
		SM_CXEDGE = 45,

		/// <summary>
		/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels.
		/// SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
		/// This value is the same as SM_CXDLGFRAME.
		/// </summary>
		SM_CXFIXEDFRAME = 7,

		/// <summary>
		/// The width of the left and right edges of the focus rectangle that the DrawFocusRectdraws. 
		/// This value is in pixels. 
		/// Windows 2000:  This value is not supported.
		/// </summary>
		SM_CXFOCUSBORDER = 83,

		/// <summary>
		/// This value is the same as SM_CXSIZEFRAME.
		/// </summary>
		SM_CXFRAME = 32,

		/// <summary>
		/// The width of the client area for a full-screen window on the primary display monitor, in pixels. 
		/// To get the coordinates of the portion of the screen that is not obscured by the system taskbar or by application desktop toolbars, 
		/// call the SystemParametersInfofunction with the SPI_GETWORKAREA value.
		/// </summary>
		SM_CXFULLSCREEN = 16,

		/// <summary>
		/// The width of the arrow bitmap on a horizontal scroll bar, in pixels.
		/// </summary>
		SM_CXHSCROLL = 21,

		/// <summary>
		/// The width of the thumb box in a horizontal scroll bar, in pixels.
		/// </summary>
		SM_CXHTHUMB = 10,

		/// <summary>
		/// The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions 
		/// that SM_CXICON and SM_CYICON specifies.
		/// </summary>
		SM_CXICON = 11,

		/// <summary>
		/// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size 
		/// SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON.
		/// </summary>
		SM_CXICONSPACING = 38,

		/// <summary>
		/// The default width, in pixels, of a maximized top-level window on the primary display monitor.
		/// </summary>
		SM_CXMAXIMIZED = 61,

		/// <summary>
		/// The default maximum width of a window that has a caption and sizing borders, in pixels. 
		/// This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. 
		/// A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </summary>
		SM_CXMAXTRACK = 59,

		/// <summary>
		/// The width of the default menu check-mark bitmap, in pixels.
		/// </summary>
		SM_CXMENUCHECK = 71,

		/// <summary>
		/// The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
		/// </summary>
		SM_CXMENUSIZE = 54,

		/// <summary>
		/// The minimum width of a window, in pixels.
		/// </summary>
		SM_CXMIN = 28,

		/// <summary>
		/// The width of a minimized window, in pixels.
		/// </summary>
		SM_CXMINIMIZED = 57,

		/// <summary>
		/// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. 
		/// This value is always greater than or equal to SM_CXMINIMIZED.
		/// </summary>
		SM_CXMINSPACING = 47,

		/// <summary>
		/// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. 
		/// A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </summary>
		SM_CXMINTRACK = 34,

		/// <summary>
		/// The amount of border padding for captioned windows, in pixels. Windows XP/2000:  This value is not supported.
		/// </summary>
		SM_CXPADDEDBORDER = 92,

		/// <summary>
		/// The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling 
		/// GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
		/// </summary>
		SM_CXSCREEN = 0,

		/// <summary>
		/// The width of a button in a window caption or title bar, in pixels.
		/// </summary>
		SM_CXSIZE = 30,

		/// <summary>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
		/// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
		/// This value is the same as SM_CXFRAME.
		/// </summary>
		SM_CXSIZEFRAME = 32,

		/// <summary>
		/// The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
		/// </summary>
		SM_CXSMICON = 49,

		/// <summary>
		/// The width of small caption buttons, in pixels.
		/// </summary>
		SM_CXSMSIZE = 52,

		/// <summary>
		/// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. 
		/// The SM_XVIRTUALSCREEN metric is the coordinates for the left side of the virtual screen.
		/// </summary>
		SM_CXVIRTUALSCREEN = 78,

		/// <summary>
		/// The width of a vertical scroll bar, in pixels.
		/// </summary>
		SM_CXVSCROLL = 2,

		/// <summary>
		/// The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.
		/// </summary>
		SM_CYBORDER = 6,

		/// <summary>
		/// The height of a caption area, in pixels.
		/// </summary>
		SM_CYCAPTION = 4,

		/// <summary>
		/// The height of a cursor, in pixels. The system cannot create cursors of other sizes.
		/// </summary>
		SM_CYCURSOR = 14,

		/// <summary>
		/// This value is the same as SM_CYFIXEDFRAME.
		/// </summary>
		SM_CYDLGFRAME = 8,

		/// <summary>
		/// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. 
		/// The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider 
		/// the two clicks a double-click. The two clicks must also occur within a specified time. To set the height of the double-click 
		/// rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.
		/// </summary>
		SM_CYDOUBLECLK = 37,

		/// <summary>
		/// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. 
		/// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. 
		/// If this value is negative, it is subtracted from above the mouse-down point and added below it.
		/// </summary>
		SM_CYDRAG = 69,

		/// <summary>
		/// The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.
		/// </summary>
		SM_CYEDGE = 46,

		/// <summary>
		/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. 
		/// SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border. 
		/// This value is the same as SM_CYDLGFRAME.
		/// </summary>
		SM_CYFIXEDFRAME = 8,

		/// <summary>
		/// The height of the top and bottom edges of the focus rectangle drawn byDrawFocusRect. 
		/// This value is in pixels. 
		/// Windows 2000:  This value is not supported.
		/// </summary>
		SM_CYFOCUSBORDER = 84,

		/// <summary>
		/// This value is the same as SM_CYSIZEFRAME.
		/// </summary>
		SM_CYFRAME = 33,

		/// <summary>
		/// The height of the client area for a full-screen window on the primary display monitor, in pixels. 
		/// To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars,
		/// call the SystemParametersInfo function with the SPI_GETWORKAREA value.
		/// </summary>
		SM_CYFULLSCREEN = 17,

		/// <summary>
		/// The height of a horizontal scroll bar, in pixels.
		/// </summary>
		SM_CYHSCROLL = 3,

		/// <summary>
		/// The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
		/// </summary>
		SM_CYICON = 12,

		/// <summary>
		/// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size 
		/// SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
		/// </summary>
		SM_CYICONSPACING = 39,

		/// <summary>
		/// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.
		/// </summary>
		SM_CYKANJIWINDOW = 18,

		/// <summary>
		/// The default height, in pixels, of a maximized top-level window on the primary display monitor.
		/// </summary>
		SM_CYMAXIMIZED = 62,

		/// <summary>
		/// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. 
		/// The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing 
		/// the WM_GETMINMAXINFO message.
		/// </summary>
		SM_CYMAXTRACK = 60,

		/// <summary>
		/// The height of a single-line menu bar, in pixels.
		/// </summary>
		SM_CYMENU = 15,

		/// <summary>
		/// The height of the default menu check-mark bitmap, in pixels.
		/// </summary>
		SM_CYMENUCHECK = 72,

		/// <summary>
		/// The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
		/// </summary>
		SM_CYMENUSIZE = 55,

		/// <summary>
		/// The minimum height of a window, in pixels.
		/// </summary>
		SM_CYMIN = 29,

		/// <summary>
		/// The height of a minimized window, in pixels.
		/// </summary>
		SM_CYMINIMIZED = 58,

		/// <summary>
		/// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. 
		/// This value is always greater than or equal to SM_CYMINIMIZED.
		/// </summary>
		SM_CYMINSPACING = 48,

		/// <summary>
		/// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. 
		/// A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </summary>
		SM_CYMINTRACK = 35,

		/// <summary>
		/// The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling 
		/// GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
		/// </summary>
		SM_CYSCREEN = 1,

		/// <summary>
		/// The height of a button in a window caption or title bar, in pixels.
		/// </summary>
		SM_CYSIZE = 31,

		/// <summary>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
		/// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
		/// This value is the same as SM_CYFRAME.
		/// </summary>
		SM_CYSIZEFRAME = 33,

		/// <summary>
		/// The height of a small caption, in pixels.
		/// </summary>
		SM_CYSMCAPTION = 51,

		/// <summary>
		/// The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
		/// </summary>
		SM_CYSMICON = 50,

		/// <summary>
		/// The height of small caption buttons, in pixels.
		/// </summary>
		SM_CYSMSIZE = 53,

		/// <summary>
		/// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. 
		/// The SM_YVIRTUALSCREEN metric is the coordinates for the top of the virtual screen.
		/// </summary>
		SM_CYVIRTUALSCREEN = 79,

		/// <summary>
		/// The height of the arrow bitmap on a vertical scroll bar, in pixels.
		/// </summary>
		SM_CYVSCROLL = 20,

		/// <summary>
		/// The height of the thumb box in a vertical scroll bar, in pixels.
		/// </summary>
		SM_CYVTHUMB = 9,

		/// <summary>
		/// Nonzero if User32.dll supports DBCS; otherwise, 0.
		/// </summary>
		SM_DBCSENABLED = 42,

		/// <summary>
		/// Nonzero if the debug version of User.exe is installed; otherwise, 0.
		/// </summary>
		SM_DEBUG = 22,

		/// <summary>
		/// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input 
		/// service is started; otherwise, 0. The return value is a bitmask that specifies the type of digitizer input supported by the device. 
		/// For more information, see Remarks. 
		/// Windows Server 2008, Windows Vista, and Windows XP/2000:  This value is not supported.
		/// </summary>
		SM_DIGITIZER = 94,

		/// <summary>
		/// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0. 
		/// SM_IMMENABLED indicates whether the system is ready to use a Unicode-based IME on a Unicode application. 
		/// To ensure that a language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page.
		/// Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or some components like fonts
		/// or registry settings may not be present.
		/// </summary>
		SM_IMMENABLED = 82,

		/// <summary>
		/// Nonzero if there are digitizers in the system; otherwise, 0. SM_MAXIMUMTOUCHES returns the aggregate maximum of the 
		/// maximum number of contacts supported by every digitizer in the system. If the system has only single-touch digitizers, 
		/// the return value is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts 
		/// the hardware can provide. Windows Server 2008, Windows Vista, and Windows XP/2000:  This value is not supported.
		/// </summary>
		SM_MAXIMUMTOUCHES = 95,

		/// <summary>
		/// Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.
		/// </summary>
		SM_MEDIACENTER = 87,

		/// <summary>
		/// Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.
		/// </summary>
		SM_MENUDROPALIGNMENT = 40,

		/// <summary>
		/// Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.
		/// </summary>
		SM_MIDEASTENABLED = 74,

		/// <summary>
		/// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because 
		/// some systems detect the presence of the port instead of the presence of a mouse.
		/// </summary>
		SM_MOUSEPRESENT = 19,

		/// <summary>
		/// Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.
		/// </summary>
		SM_MOUSEHORIZONTALWHEELPRESENT = 91,

		/// <summary>
		/// Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.
		/// </summary>
		SM_MOUSEWHEELPRESENT = 75,

		/// <summary>
		/// The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.
		/// </summary>
		SM_NETWORK = 63,

		/// <summary>
		/// Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.
		/// </summary>
		SM_PENWINDOWS = 41,

		/// <summary>
		/// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is 
		/// being remotely controlled. Its value is nonzero if the current session is remotely controlled; otherwise, 0. 
		/// You can use terminal services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to 
		/// control a remote session. When a session is being remotely controlled, another user can view the contents of that session 
		/// and potentially interact with it.
		/// </summary>
		SM_REMOTECONTROL = 0x2001,

		/// <summary>
		/// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services 
		/// client session, the return value is nonzero. If the calling process is associated with the Terminal Services console session, 
		/// the return value is 0. 
		/// Windows Server 2003 and Windows XP:  The console session is not necessarily the physical console. 
		/// For more information, seeWTSGetActiveConsoleSessionId.
		/// </summary>
		SM_REMOTESESSION = 0x1000,

		/// <summary>
		/// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, 
		/// but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, 
		/// or those bits can be located in different places in a pixel color value.
		/// </summary>
		SM_SAMEDISPLAYFORMAT = 81,

		/// <summary>
		/// This system metric should be ignored; it always returns 0.
		/// </summary>
		SM_SECURE = 44,

		/// <summary>
		/// The build number if the system is Windows Server 2003 R2; otherwise, 0.
		/// </summary>
		SM_SERVERR2 = 89,

		/// <summary>
		/// Nonzero if the user requires an application to present information visually in situations where it would otherwise present 
		/// the information only in audible form; otherwise, 0.
		/// </summary>
		SM_SHOWSOUNDS = 70,

		/// <summary>
		/// Nonzero if the current session is shutting down; otherwise, 0. Windows 2000:  This value is not supported.
		/// </summary>
		SM_SHUTTINGDOWN = 0x2000,

		/// <summary>
		/// Nonzero if the computer has a low-end (slow) processor; otherwise, 0.
		/// </summary>
		SM_SLOWMACHINE = 73,

		/// <summary>
		/// Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; otherwise, 0.
		/// </summary>
		SM_STARTER = 88,

		/// <summary>
		/// Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
		/// </summary>
		SM_SWAPBUTTON = 23,

		/// <summary>
		/// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista
		/// or Windows 7 and the Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer 
		/// input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
		/// </summary>
		SM_TABLETPC = 86,

		/// <summary>
		/// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. 
		/// The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.
		/// </summary>
		SM_XVIRTUALSCREEN = 76,

		/// <summary>
		/// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. 
		/// The SM_CYVIRTUALSCREEN metric is the height of the virtual screen.
		/// </summary>
		SM_YVIRTUALSCREEN = 77,
	}


	[StructLayout(LayoutKind.Sequential)]
	public struct COLORREF
	{
		public uint ColorDWORD;

		public COLORREF(System.Drawing.Color color)
		{
			ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
		}

		public System.Drawing.Color GetColor()
		{
			return System.Drawing.Color.FromArgb((int)(0x000000FFU & ColorDWORD),
		   (int)(0x0000FF00U & ColorDWORD) >> 8, (int)(0x00FF0000U & ColorDWORD) >> 16);
		}

		public void SetColor(System.Drawing.Color color)
		{
			ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
		}
	}
	[Flags()]
	internal enum DCX
	{
		CACHE = 0x2,
		CLIPCHILDREN = 0x8,
        CLIPSIBLINGS = 0x10,
		EXCLUDERGN = 0x40,
		EXCLUDEUPDATE = 0x100,
		INTERSECTRGN = 0x80,
		INTERSECTUPDATE = 0x200,
		LOCKWINDOWUPDATE = 0x400,
        NORECOMPUTE = 0x100000,
		NORESETATTRS = 0x4,
		PARENTCLIP = 0x20,
		VALIDATE = 0x200000,
		WINDOW = 0x1,
	}

	[Flags]
	public enum RedrawWindowFlags
	{
		RDW_INVALIDATE = 0x0001,
		RDW_INTERNALPAINT = 0x0002,
		RDW_ERASE = 0x0004,
		RDW_VALIDATE = 0x0008,
		RDW_NOINTERNALPAINT = 0x0010,
		RDW_NOERASE = 0x0020,
		RDW_NOCHILDREN = 0x0040,
		RDW_ALLCHILDREN = 0x0080,
		RDW_UPDATENOW = 0x0100,
		RDW_ERASENOW = 0x0200,
		RDW_FRAME = 0x0400,
		RDW_NOFRAME = 0x0800,

	}
	public enum SetWindowPosFlags
	{
		SWP_NOSIZE = 0x0001,
		SWP_NOMOVE = 0x0002,
		SWP_NOZORDER = 0x0004,
		SWP_NOREDRAW = 0x0008,
		SWP_NOACTIVATE = 0x0010,
		SWP_FRAMECHANGED = 0x0020,
		SWP_SHOWWINDOW = 0x0040,
		SWP_HIDEWINDOW = 0x0080,
		SWP_NOCOPYBITS = 0x0100,
		SWP_NOOWNERZORDER = 0x0200,
		SWP_NOSENDCHANGING = 0x0400,
		SWP_DRAWFRAME = 0x0020,
		SWP_NOREPOSITION = 0x0200,
		SWP_DEFERERASE = 0x2000,
		SWP_ASYNCWINDOWPOS = 0x4000
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BLENDFUNCTION
	{
		/// <summary>
		/// BlendOp field of structure
		/// </summary>
		public byte BlendOp;

		/// <summary>
		/// BlendFlags field of structure
		/// </summary>
		public byte BlendFlags;

		/// <summary>
		/// SourceConstantAlpha field of structure
		/// </summary>
		public byte SourceConstantAlpha;

		/// <summary>
		/// AlphaFormat field of structure
		/// </summary>
		public byte AlphaFormat;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		/// <summary>
		/// x field of structure
		/// </summary>
		public int x;

		/// <summary>
		/// y field of structure
		/// </summary>
		public int y;

		#region Constructors
		public POINT(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public POINT(Point point)
		{
			x = point.X;
			y = point.Y;
		}

		public override string ToString()
		{
			return $"x:{x} y:{y}";
		}
		#endregion
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWPOS
	{
		public IntPtr hwnd;
		public IntPtr hwndAfter;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public uint flags;

		#region Overrides
		public override string ToString()
		{
			return x + ":" + y + ":" + cx + ":" + cy + ":" + ((SetWindowPosFlags)flags);
		}
		#endregion
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WNDCLASS
	{
		public uint style;
		public IntPtr lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszMenuName;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszClassName;
	}

	[Flags]
	public enum WindowExStyles
	{
		/// <summary>
		/// Specified WS_EX_DLGMODALFRAME enumeration value.
		/// </summary>
		WS_EX_DLGMODALFRAME = 0x00000001,

		/// <summary>
		/// Specified WS_EX_NOPARENTNOTIFY enumeration value.
		/// </summary>
		WS_EX_NOPARENTNOTIFY = 0x00000004,
		/// <summary>
		/// Specified WS_EX_NOACTIVATE enumeration value.
		/// </summary>
		WS_EX_NOACTIVATE = 0x08000000,
		/// <summary>
		/// Specified WS_EX_TOPMOST enumeration value.
		/// </summary>
		WS_EX_TOPMOST = 0x00000008,

		/// <summary>
		/// Specified WS_EX_ACCEPTFILES enumeration value.
		/// </summary>
		WS_EX_ACCEPTFILES = 0x00000010,

		/// <summary>
		/// Specified WS_EX_TRANSPARENT enumeration value.
		/// </summary>
		WS_EX_TRANSPARENT = 0x00000020,

		/// <summary>
		/// Specified WS_EX_MDICHILD enumeration value.
		/// </summary>
		WS_EX_MDICHILD = 0x00000040,

		/// <summary>
		/// Specified WS_EX_TOOLWINDOW enumeration value.
		/// </summary>
		WS_EX_TOOLWINDOW = 0x00000080,

		/// <summary>
		/// Specified WS_EX_WINDOWEDGE enumeration value.
		/// </summary>
		WS_EX_WINDOWEDGE = 0x00000100,

		/// <summary>
		/// Specified WS_EX_CLIENTEDGE enumeration value.
		/// </summary>
		WS_EX_CLIENTEDGE = 0x00000200,

		/// <summary>
		/// Specified WS_EX_CONTEXTHELP enumeration value.
		/// </summary>
		WS_EX_CONTEXTHELP = 0x00000400,

		/// <summary>
		/// Specified WS_EX_RIGHT enumeration value.
		/// </summary>
		WS_EX_RIGHT = 0x00001000,

		/// <summary>
		/// Specified WS_EX_LEFT enumeration value.
		/// </summary>
		WS_EX_LEFT = 0x00000000,

		/// <summary>
		/// Specified WS_EX_RTLREADING enumeration value.
		/// </summary>
		WS_EX_RTLREADING = 0x00002000,

		/// <summary>
		/// Specified WS_EX_LTRREADING enumeration value.
		/// </summary>
		WS_EX_LTRREADING = 0x00000000,

		/// <summary>
		/// Specified WS_EX_LEFTSCROLLBAR enumeration value.
		/// </summary>
		WS_EX_LEFTSCROLLBAR = 0x00004000,

		/// <summary>
		/// Specified WS_EX_RIGHTSCROLLBAR enumeration value.
		/// </summary>
		WS_EX_RIGHTSCROLLBAR = 0x00000000,

		/// <summary>
		/// Specified WS_EX_CONTROLPARENT enumeration value.
		/// </summary>
		WS_EX_CONTROLPARENT = 0x00010000,

		/// <summary>
		/// Specified WS_EX_STATICEDGE enumeration value.
		/// </summary>
		WS_EX_STATICEDGE = 0x00020000,

		/// <summary>
		/// Specified WS_EX_APPWINDOW enumeration value.
		/// </summary>
		WS_EX_APPWINDOW = 0x00040000,

		/// <summary>
		/// Specified WS_EX_OVERLAPPEDWINDOW enumeration value.
		/// </summary>
		WS_EX_OVERLAPPEDWINDOW = 0x00000300,

		/// <summary>
		/// Specified WS_EX_PALETTEWINDOW enumeration value.
		/// </summary>
		WS_EX_PALETTEWINDOW = 0x00000188,

		/// <summary>
		/// Specified WS_EX_LAYERED enumeration value.
		/// </summary>
		WS_EX_LAYERED = 0x00080000
	}

	[Flags]
	public enum WindowStyles : long
	{
		WS_OVERLAPPED = 0x00000000,
		WS_POPUP = 0x80000000,
		WS_CHILD = 0x40000000,
		WS_MINIMIZE = 0x20000000,
		WS_VISIBLE = 0x10000000,
		WS_DISABLED = 0x08000000,
		WS_CLIPSIBLINGS = 0x04000000,
		WS_CLIPCHILDREN = 0x02000000,
		WS_MAXIMIZE = 0x01000000,
		WS_CAPTION = 0x00C00000,
		WS_BORDER = 0x00800000,
		WS_DLGFRAME = 0x00400000,
		WS_VSCROLL = 0x00200000,
		WS_HSCROLL = 0x00100000,
		WS_SYSMENU = 0x00080000,
		WS_THICKFRAME = 0x00040000,
		WS_GROUP = 0x00020000,
		WS_TABSTOP = 0x00010000,
		WS_MINIMIZEBOX = 0x00020000,
		WS_MAXIMIZEBOX = 0x00010000,
		WS_TILED = 0x00000000,
		WS_ICONIC = 0x20000000,
		WS_SIZEBOX = 0x00040000,
		WS_POPUPWINDOW = 0x80880000,
		WS_OVERLAPPEDWINDOW = 0x00CF0000,
		WS_TILEDWINDOW = 0x00CF0000,
		WS_CHILDWINDOW = 0x40000000
	}

	public enum GetWindowLongFlags
	{
		/// <summary>
		/// Specified GWL_WNDPROC enumeration value.
		/// </summary>
		GWL_WNDPROC = -4,

		/// <summary>
		/// Specified GWL_HINSTANCE enumeration value.
		/// </summary>
		GWL_HINSTANCE = -6,

		/// <summary>
		/// Specified GWL_HWNDPARENT enumeration value.
		/// </summary>
		GWL_HWNDPARENT = -8,

		/// <summary>
		/// Specified GWL_STYLE enumeration value.
		/// </summary>
		GWL_STYLE = -16,

		/// <summary>
		/// Specified GWL_EXSTYLE enumeration value.
		/// </summary>
		GWL_EXSTYLE = -20,

		/// <summary>
		/// Specified GWL_USERDATA enumeration value.
		/// </summary>
		GWL_USERDATA = -21,

		/// <summary>
		/// Specified GWL_ID enumeration value.
		/// </summary>
		GWL_ID = -12
	}


	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		/// <summary>
		/// left field of structure
		/// </summary>
		public int left;

		/// <summary>
		/// top field of structure
		/// </summary>
		public int top;

		/// <summary>
		/// right field of structure
		/// </summary>
		public int right;

		/// <summary>
		/// bottom field of structure
		/// </summary>
		public int bottom;

		public int Left
		{
			get => left;
			set => left = value;
		}

		public int Right
		{
			get => right;
			set => right = value;
		}
		public int Top
		{
			get => top;
			set => top = value;
		}
		public int Bottom
		{
			get => bottom;
			set => bottom = value;
		}
		public RECT(int left, int top, int width, int height)
		{
			this.left = left;
			this.top = top;
			right = this.left + width;
			bottom = this.top + height;
		}

		public RECT(Rectangle r)
		{
			left = r.Left; top = r.Top; right = r.Right; bottom = r.Bottom;
		}

		public Rectangle ToRectangle()
		{
			return Rectangle.FromLTRB(Left, Top, Right, Bottom);
		}
		public void Inflate(int width, int height)
		{
			Left -= width;
			Top -= height;
			Right += width;
			Bottom += height;
		}

		#region Properties

		public POINT Location
		{
			get
			{
				return new POINT(left, top);
			}
			set
			{
				right -= (left - value.x);
				bottom -= (bottom - value.y);
				left = value.x;
				top = value.y;
			}
		}

		public int Width
		{
			get { return Math.Abs(right - left); }
			set { right = left + (int)value; }
		}

		public int Height
		{
			get { return Math.Abs(bottom - top); }
			set { bottom = top + (int)value; }
		}
		#endregion

		#region Overrides

		public override string ToString()
		{
			return string.Format("x:{0},y:{1},width:{2},height:{3}", Left, Top, Right - Left, Bottom - Top);
		}

		#endregion

		public static explicit operator Rectangle(RECT rect)
		{
			return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SIZE
	{
		/// <summary>
		/// cx field of structure
		/// </summary>
		public int cx;

		/// <summary>
		/// cy field of structure
		/// </summary>
		public int cy;

		public SIZE(Int32 cx, Int32 cy)
		{
			this.cx = cx;
			this.cy = cy;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MINMAXINFO
	{
		public POINT ptReserved;
		public POINT ptMaxSize;
		public POINT ptMaxPosition;
		public POINT ptMinTrackSize;
		public POINT ptMaxTrackSize;
	}

	public enum HitTest : int
	{
		HTERROR = (-2),
		HTTRANSPARENT = (-1),
		HTNOWHERE = 0,
		HTCLIENT = 1,
		HTCAPTION = 2,
		HTSYSMENU = 3,
		HTGROWBOX = 4,
		HTSIZE = HTGROWBOX,
		HTMENU = 5,
		HTHSCROLL = 6,
		HTVSCROLL = 7,
		HTMINBUTTON = 8,
		HTMAXBUTTON = 9,
		HTLEFT = 10,
		HTRIGHT = 11,
		HTTOP = 12,
		HTTOPLEFT = 13,
		HTTOPRIGHT = 14,
		HTBOTTOM = 15,
		HTBOTTOMLEFT = 16,
		HTBOTTOMRIGHT = 17,
		HTBORDER = 18,
		HTREDUCE = HTMINBUTTON,
		HTZOOM = HTMAXBUTTON,
		HTSIZEFIRST = HTLEFT,
		HTSIZELAST = HTBOTTOMRIGHT,
		HTOBJECT = 19,
		HTCLOSE = 20,
		HTHELP = 21
	}

	public enum IdcStandardCursors
	{
		IDC_ARROW = 32512,
		IDC_IBEAM = 32513,
		IDC_WAIT = 32514,
		IDC_CROSS = 32515,
		IDC_UPARROW = 32516,
		IDC_SIZE = 32640,
		IDC_ICON = 32641,
		IDC_SIZENWSE = 32642,
		IDC_SIZENESW = 32643,
		IDC_SIZEWE = 32644,
		IDC_SIZENS = 32645,
		IDC_SIZEALL = 32646,
		IDC_NO = 32648,
		IDC_HAND = 32649,
		IDC_APPSTARTING = 32650,
		IDC_HELP = 32651
	}

	public enum ShowWindowStyles : short
	{
		/// <summary>
		/// Specified SW_HIDE enumeration value.
		/// </summary>
		SW_HIDE = 0,

		/// <summary>
		/// Specified SW_SHOWNORMAL enumeration value.
		/// </summary>
		SW_SHOWNORMAL = 1,

		/// <summary>
		/// Specified SW_NORMAL enumeration value.
		/// </summary>
		SW_NORMAL = 1,

		/// <summary>
		/// Specified SW_SHOWMINIMIZED enumeration value.
		/// </summary>
		SW_SHOWMINIMIZED = 2,

		/// <summary>
		/// Specified SW_SHOWMAXIMIZED enumeration value.
		/// </summary>
		SW_SHOWMAXIMIZED = 3,

		/// <summary>
		/// Specified SW_MAXIMIZE enumeration value.
		/// </summary>
		SW_MAXIMIZE = 3,

		/// <summary>
		/// Specified SW_SHOWNOACTIVATE enumeration value.
		/// </summary>
		SW_SHOWNOACTIVATE = 4,

		/// <summary>
		/// Specified SW_SHOW enumeration value.
		/// </summary>
		SW_SHOW = 5,

		/// <summary>
		/// Specified SW_MINIMIZE enumeration value.
		/// </summary>
		SW_MINIMIZE = 6,

		/// <summary>
		/// Specified SW_SHOWMINNOACTIVE enumeration value.
		/// </summary>
		SW_SHOWMINNOACTIVE = 7,

		/// <summary>
		/// Specified SW_SHOWNA enumeration value.
		/// </summary>
		SW_SHOWNA = 8,

		/// <summary>
		/// Specified SW_RESTORE enumeration value.
		/// </summary>
		SW_RESTORE = 9,

		/// <summary>
		/// Specified SW_SHOWDEFAULT enumeration value.
		/// </summary>
		SW_SHOWDEFAULT = 10,

		/// <summary>
		/// Specified SW_FORCEMINIMIZE enumeration value.
		/// </summary>
		SW_FORCEMINIMIZE = 11,

		/// <summary>
		/// Specified SW_MAX enumeration value.
		/// </summary>
		SW_MAX = 11
	}

	public enum ResizeDirection
	{
		Left = 61441,
		Right = 61442,
		Top = 61443,
		TopLeft = 61444,
		TopRight = 61445,
		Bottom = 61446,
		BottomLeft = 61447,
		BottomRight = 61448,
	}

	[Flags]
	public enum WindowSizeEdges : uint
	{
		WMSZ_LEFT = 1,
		WMSZ_RIGHT = 2,
		WMSZ_TOP = 3,
		WMSZ_TOPLEFT = 4,
		WMSZ_TOPRIGHT = 5,
		WMSZ_BOTTOM = 6,
		WMSZ_BOTTOMLEFT = 7,
		WMSZ_BOTTOMRIGHT = 8
	}

	//[StructLayout(LayoutKind.Sequential)]
	//public struct NCCALCSIZE_PARAMS
	//{
	//	public RECT rect0;
	//	public RECT rect1;
	//	public RECT rect2;
	//	// Can't use an array here so simulate one
	//	public IntPtr lppos;
	//}

	[StructLayout(LayoutKind.Sequential)]
	public struct NCCALCSIZE_PARAMS
	{
		/// <summary>
		/// Contains the new coordinates of a window that has been moved or resized, that is, it is the proposed new window coordinates.
		/// </summary>
		public RECT rectProposed;
		/// <summary>
		/// Contains the coordinates of the window before it was moved or resized.
		/// </summary>
		public RECT rectBeforeMove;
		/// <summary>
		/// Contains the coordinates of the window's client area before the window was moved or resized.
		/// </summary>
		public RECT rectClientBeforeMove;
		/// <summary>
		/// Pointer to a WINDOWPOS structure that contains the size and position values specified in the operation that moved or resized the window.
		/// </summary>
		public IntPtr lppos;
	}

	public enum WindowSizeMessageFlags : int
	{
		SIZE_RESTORED = 0,
		SIZE_MINIMIZED = 1,
		SIZE_MAXIMIZED = 2,
		SIZE_MAXSHOW = 3,
		SIZE_MAXHIDE = 4
	}

}
