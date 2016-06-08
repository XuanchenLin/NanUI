using System;
using System.Runtime.InteropServices;

namespace NetDimension.NanUI.Internal
{
	internal static partial class NativeMethods
	{

		internal static readonly IntPtr TRUE = new IntPtr(1);
		internal static readonly IntPtr FALSE = new IntPtr(0);

		internal static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);
		internal static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);

		[StructLayout(LayoutKind.Explicit)]
		internal struct RECT
		{
			// Fields
			[FieldOffset(12)]
			internal int Bottom;
			[FieldOffset(0)]
			internal int Left;
			[FieldOffset(8)]
			internal int Right;
			[FieldOffset(4)]

			internal int Top;
			// Methods
			internal RECT(System.Drawing.Rectangle rect)
			{
				this.Left = rect.Left;
				this.Top = rect.Top;
				this.Right = rect.Right;
				this.Bottom = rect.Bottom;
			}

			internal RECT(int left, int top, int right, int bottom)
			{
				this.Left = left;
				this.Top = top;
				this.Right = right;
				this.Bottom = bottom;
			}

			internal void Set()
			{
				this.Left = InlineAssignHelper(ref this.Top, InlineAssignHelper(ref this.Right, InlineAssignHelper(ref this.Bottom, 0)));
			}

			internal void Set(System.Drawing.Rectangle rect)
			{
				this.Left = rect.Left;
				this.Top = rect.Top;
				this.Right = rect.Right;
				this.Bottom = rect.Bottom;
			}

			internal void Set(int left, int top, int right, int bottom)
			{
				this.Left = left;
				this.Top = top;
				this.Right = right;
				this.Bottom = bottom;
			}

			internal System.Drawing.Rectangle ToRectangle()
			{
				return new System.Drawing.Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
			}

			// Properties
			internal int Height
			{
				get { return (this.Bottom - this.Top); }
			}

			internal System.Drawing.Size Size
			{
				get { return new System.Drawing.Size(this.Width, this.Height); }
			}

			internal int Width
			{
				get { return (this.Right - this.Left); }
			}
			private static T InlineAssignHelper<T>(ref T target, T value)
			{
				target = value;
				return value;
			}
		}
		[StructLayout(LayoutKind.Sequential)]
		internal struct NCCALCSIZE_PARAMS
		{
			public RECT rect0;
			public RECT rect1;
			public RECT rect2;
			// Can't use an array here so simulate one
			public IntPtr lppos;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPOS
		{
			public IntPtr hwnd;
			public IntPtr hwndInsertAfter;
			public int x;
			public int y;
			public int cx;
			public int cy;
			public uint flags;
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32")]
		internal static extern void DisableProcessWindowsGhosting();


		[DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
		internal static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);
		[DllImport("gdi32.dll")]
		internal static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect,
			int nBottomRect);
		[DllImport("user32.dll")]
		internal static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32")]
		internal static extern bool ReleaseCapture();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll ")]
		internal static extern IntPtr GetWindowDC(IntPtr hwnd);
		[DllImport("User32.dll ")]
		internal static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("gdi32.dll")]
		internal extern static int ExcludeClipRect(IntPtr hdc, int x1, int y1, int x2, int y2);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

		internal static int MAKEPARAM(int l, int h)
		{
			return ((l & 0xffff) | (h << 0x10));
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

		[DllImport("user32.dll")]
		internal extern static int OffsetRect(ref RECT lpRect, int x, int y);


		[DllImport("user32.dll")]
		internal static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);


		internal static IntPtr MAKEPARAM(IntPtr l, IntPtr h)
		{
			return (IntPtr)((l.ToInt32() & 0xffff) | (h.ToInt32() << 0x10));
		}

		internal static int LoWord(int dwValue)
		{
			return dwValue & 0xffff;
		}


		internal static int HiWord(int dwValue)
		{
			return (dwValue >> 16) & 0xffff;
		}

		internal static int LoWord(IntPtr dwValue)
		{
			return (int)dwValue & 0xffff;
		}




		internal static int HiWord(IntPtr dwValue)
		{
			return ((int)dwValue >> 16) & 0xffff;
		}

		internal struct FDWFlags
		{
			internal const int DCX_CACHE = 0x2;
			internal const int DCX_CLIPCHILDREN = 0x8;
			internal const int DCX_CLIPSIBLINGS = 0x10;
			internal const int DCX_EXCLUDERGN = 0x40;
			internal const int DCX_EXCLUDEUPDATE = 0x100;
			internal const int DCX_INTERSECTRGN = 0x80;
			internal const int DCX_INTERSECTUPDATE = 0x200;
			internal const int DCX_LOCKWINDOWUPDATE = 0x400;
			internal const int DCX_NORECOMPUTE = 0x100000;
			internal const int DCX_NORESETATTRS = 0x4;
			internal const int DCX_PARENTCLIP = 0x20;
			internal const int DCX_VALIDATE = 0x200000;
			internal const int DCX_WINDOW = 0x1;
		}

		internal struct DefMessages
		{
			internal const int WM_CEF_DRAG_APP = WindowsMessage.WM_USER + 1000;
			internal const int WM_CEF_RESIZE_CLIENT = WindowsMessage.WM_USER + 1001;
			internal const int WM_CEF_EDGE_MOVE = WindowsMessage.WM_USER + 1002;
			internal const int WM_CEF_TITLEBAR_LBUTTONDBCLICK = WindowsMessage.WM_USER + 1003;
			internal const int WM_CEF_INVALIDATE_WINDOW = WindowsMessage.WM_USER + 1004;
		}

		internal struct RedrawWindowFlags
		{
			internal const int RDW_INVALIDATE = 0x0001;
			internal const int RDW_INTERNALPAINT = 0x0002;
			internal const int RDW_ERASE = 0x0004;
			internal const int RDW_VALIDATE = 0x0008;
			internal const int RDW_NOINTERNALPAINT = 0x0010;
			internal const int RDW_NOERASE = 0x0020;
			internal const int RDW_NOCHILDREN = 0x0040;
			internal const int RDW_ALLCHILDREN = 0x0080;
			internal const int RDW_UPDATENOW = 0x0100;
			internal const int RDW_ERASENOW = 0x0200;
			internal const int RDW_FRAME = 0x0400;
			internal const int RDW_NOFRAME = 0x0800;

		}


		internal struct SetWindowPosFlags
		{
			internal const int SWP_NOSIZE = 0x0001;
			internal const int SWP_NOMOVE = 0x0002;
			internal const int SWP_NOZORDER = 0x0004;
			internal const int SWP_NOREDRAW = 0x0008;
			internal const int SWP_NOACTIVATE = 0x0010;
			internal const int SWP_FRAMECHANGED = 0x0020;
			internal const int SWP_SHOWWINDOW = 0x0040;
			internal const int SWP_HIDEWINDOW = 0x0080;
			internal const int SWP_NOCOPYBITS = 0x0100;
			internal const int SWP_NOOWNERZORDER = 0x0200;
			internal const int SWP_NOSENDCHANGING = 0x0400;
		}





		internal struct WindowStyle
		{
			/// <summary>The window has a thin-line border.</summary>
			internal const int WS_BORDER = 0x800000;

			/// <summary>The window has a title bar (includes the internal const int WS_BORDER style).</summary>
			internal const int WS_CAPTION = 0xc00000;

			/// <summary>The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the internal const int WS_POPUP style.</summary>
			internal const int WS_CHILD = 0x40000000;

			/// <summary>Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.</summary>
			internal const int WS_CLIPCHILDREN = 0x2000000;

			/// <summary>
			/// Clips child windows relative to each other; that is; when a particular child window receives a WM_PAINT message; the internal const int WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated.
			/// If internal const int WS_CLIPSIBLINGS is not specified and child windows overlap; it is possible; when drawing within the client area of a child window; to draw within the client area of a neighboring child window.
			/// </summary>
			internal const int WS_CLIPSIBLINGS = 0x4000000;

			/// <summary>The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created; use the EnableWindow function.</summary>
			internal const int WS_DISABLED = 0x8000000;

			/// <summary>The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.</summary>
			internal const int WS_DLGFRAME = 0x400000;

			/// <summary>
			/// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it; up to the next control with the internal const int WS_GROUP style.
			/// The first control in each group usually has the internal const int WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
			/// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created; use the SetWindowLong function.
			/// </summary>
			internal const int WS_GROUP = 0x20000;

			/// <summary>The window has a horizontal scroll bar.</summary>
			internal const int WS_HSCROLL = 0x100000;

			/// <summary>The window is initially maximized.</summary>
			internal const int WS_MAXIMIZE = 0x1000000;

			/// <summary>The window has a maximize button. Cannot be combined with the internal const int WS_EX_CONTEXTHELP style. The internal const int WS_SYSMENU style must also be specified.</summary>
			internal const int WS_MAXIMIZEBOX = 0x10000;

			/// <summary>The window is initially minimized.</summary>
			internal const int WS_MINIMIZE = 0x20000000;

			/// <summary>The window has a minimize button. Cannot be combined with the internal const int WS_EX_CONTEXTHELP style. The internal const int WS_SYSMENU style must also be specified.</summary>
			internal const int WS_MINIMIZEBOX = 0x20000;

			/// <summary>The window is an overlapped window. An overlapped window has a title bar and a border.</summary>
			internal const int WS_OVERLAPPED = 0x0;

			/// <summary>The window is an overlapped window.</summary>
			internal const int WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

			/// <summary>The window is a pop-up window. This style cannot be used with the internal const int WS_CHILD style.</summary>
			internal const int WS_POPUP = unchecked((int)0x80000000);

			//// <summary>The window is a pop-up window. The internal const int WS_CAPTION and internal const int WS_POPUPWINDOW styles must be combined to make the window menu visible.</summary>
			//internal const int WS_POPUPWINDOW = internal const int WS_POPUP | internal const int WS_BORDER | internal const int WS_SYSMENU;

			/// <summary>The window has a sizing border.</summary>
			internal const int WS_SIZEFRAME = 0x40000;

			/// <summary>The window has a window menu on its title bar. The internal const int WS_CAPTION style must also be specified.</summary>
			internal const int WS_SYSMENU = 0x80000;

			/// <summary>
			/// The window is a control that can receive the keyboard focus when the user presses the TAB key.
			/// Pressing the TAB key changes the keyboard focus to the next control with the internal const int WS_TABSTOP style.  
			/// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created; use the SetWindowLong function.
			/// For user-created windows and modeless dialogs to work with tab stops; alter the message loop to call the IsDialogMessage function.
			/// </summary>
			internal const int WS_TABSTOP = 0x10000;

			/// <summary>The window is initially visible. This style can be turned on and off by using the ShowWindow or SetWindowPos function.</summary>
			internal const int WS_VISIBLE = 0x10000000;

			/// <summary>The window has a vertical scroll bar.</summary>
			internal const int WS_VSCROLL = 0x200000;
		}


		internal struct HitTest
		{
			internal const int HTNOWHERE = 0;
			internal const int HTCLIENT = 1;
			internal const int HTCAPTION = 2;
			internal const int HTGROWBOX = 4;
			internal const int HTSIZE = HTGROWBOX;
			internal const int HTMINBUTTON = 8;
			internal const int HTMAXBUTTON = 9;
			internal const int HTLEFT = 10;
			internal const int HTRIGHT = 11;
			internal const int HTTOP = 12;
			internal const int HTTOPLEFT = 13;
			internal const int HTTOPRIGHT = 14;
			internal const int HTBOTTOM = 15;
			internal const int HTBOTTOMLEFT = 16;
			internal const int HTBOTTOMRIGHT = 17;
			internal const int HTREDUCE = HTMINBUTTON;
			internal const int HTZOOM = HTMAXBUTTON;
			internal const int HTSIZEFIRST = HTLEFT;
			internal const int HTSIZELAST = HTBOTTOMRIGHT;
		}

		internal struct SysCommand
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

		[DllImport("user32.dll")]
		internal static extern int GetSystemMetrics(SystemMetric smIndex);

		/// <summary>
		/// Flags used with the Windows API (User32.dll):GetSystemMetrics(SystemMetric smIndex)
		///   
		/// This Enum and declaration signature was written by Gabriel T. Sharp
		/// ai_productions@verizon.net or osirisgothra@hotmail.com
		/// Obtained on pinvoke.net, please contribute your code to support the wiki!
		/// </summary>
		internal enum SystemMetric : int
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



		internal struct WindowsMessage
		{
			internal const int WM_ACTIVATE = 0x0006;


			internal const int WM_ACTIVATEAPP = 0x001C;


			internal const int WM_AFXFIRST = 0x0360;


			internal const int WM_AFXLAST = 0x037F;


			internal const int WM_APP = 0x8000;


			internal const int WM_ASKCBFORMATNAME = 0x030C;


			internal const int WM_CANCELJOURNAL = 0x004B;


			internal const int WM_CANCELMODE = 0x001F;


			internal const int WM_CAPTURECHANGED = 0x0215;


			internal const int WM_CHANGECBCHAIN = 0x030D;


			internal const int WM_CHANGEUISTATE = 0x0127;


			internal const int WM_CHAR = 0x0102;


			internal const int WM_CHARTOITEM = 0x002F;


			internal const int WM_CHILDACTIVATE = 0x0022;


			internal const int WM_CLEAR = 0x0303;


			internal const int WM_CLOSE = 0x0010;


			internal const int WM_COMMAND = 0x0111;


			internal const int WM_COMPACTING = 0x0041;


			internal const int WM_COMPAREITEM = 0x0039;


			internal const int WM_CONTEXTMENU = 0x007B;


			internal const int WM_COPY = 0x0301;


			internal const int WM_COPYDATA = 0x004A;


			internal const int WM_CREATE = 0x0001;


			internal const int WM_CTLCOLORBTN = 0x0135;


			internal const int WM_CTLCOLORDLG = 0x0136;


			internal const int WM_CTLCOLOREDIT = 0x0133;


			internal const int WM_CTLCOLORLISTBOX = 0x0134;


			internal const int WM_CTLCOLORMSGBOX = 0x0132;


			internal const int WM_CTLCOLORSCROLLBAR = 0x0137;


			internal const int WM_CTLCOLORSTATIC = 0x0138;


			internal const int WM_CUT = 0x0300;


			internal const int WM_DEADCHAR = 0x0103;


			internal const int WM_DELETEITEM = 0x002D;


			internal const int WM_DESTROY = 0x0002;


			internal const int WM_DESTROYCLIPBOARD = 0x0307;


			internal const int WM_DEVICECHANGE = 0x0219;


			internal const int WM_DEVMODECHANGE = 0x001B;


			internal const int WM_DISPLAYCHANGE = 0x007E;


			internal const int WM_DRAWCLIPBOARD = 0x0308;


			internal const int WM_DRAWITEM = 0x002B;


			internal const int WM_DROPFILES = 0x0233;


			internal const int WM_ENABLE = 0x000A;


			internal const int WM_ENDSESSION = 0x0016;


			internal const int WM_ENTERIDLE = 0x0121;


			internal const int WM_ENTERMENULOOP = 0x0211;


			internal const int WM_ENTERSIZEMOVE = 0x0231;


			internal const int WM_ERASEBKGND = 0x0014;


			internal const int WM_EXITMENULOOP = 0x0212;


			internal const int WM_EXITSIZEMOVE = 0x0232;


			internal const int WM_FONTCHANGE = 0x001D;


			internal const int WM_GETDLGCODE = 0x0087;


			internal const int WM_GETFONT = 0x0031;


			internal const int WM_GETHOTKEY = 0x0033;


			internal const int WM_GETICON = 0x007F;


			internal const int WM_GETMINMAXINFO = 0x0024;


			internal const int WM_GETOBJECT = 0x003D;


			internal const int WM_GETTEXT = 0x000D;


			internal const int WM_GETTEXTLENGTH = 0x000E;


			internal const int WM_HANDHELDFIRST = 0x0358;


			internal const int WM_HANDHELDLAST = 0x035F;


			internal const int WM_HELP = 0x0053;


			internal const int WM_HOTKEY = 0x0312;


			internal const int WM_HSCROLL = 0x0114;


			internal const int WM_HSCROLLCLIPBOARD = 0x030E;


			internal const int WM_ICONERASEBKGND = 0x0027;


			internal const int WM_IME_CHAR = 0x0286;


			internal const int WM_IME_COMPOSITION = 0x010F;


			internal const int WM_IME_COMPOSITIONFULL = 0x0284;


			internal const int WM_IME_CONTROL = 0x0283;


			internal const int WM_IME_ENDCOMPOSITION = 0x010E;


			internal const int WM_IME_KEYDOWN = 0x0290;


			internal const int WM_IME_KEYLAST = 0x010F;


			internal const int WM_IME_KEYUP = 0x0291;


			internal const int WM_IME_NOTIFY = 0x0282;


			internal const int WM_IME_REQUEST = 0x0288;


			internal const int WM_IME_SELECT = 0x0285;


			internal const int WM_IME_SETCONTEXT = 0x0281;


			internal const int WM_IME_STARTCOMPOSITION = 0x010D;


			internal const int WM_INITDIALOG = 0x0110;


			internal const int WM_INITMENU = 0x0116;


			internal const int WM_INITMENUPOPUP = 0x0117;


			internal const int WM_INPUTLANGCHANGE = 0x0051;


			internal const int WM_INPUTLANGCHANGEREQUEST = 0x0050;


			internal const int WM_KEYDOWN = 0x0100;


			internal const int WM_KEYFIRST = 0x0100;


			internal const int WM_KEYLAST = 0x0108;


			internal const int WM_KEYUP = 0x0101;


			internal const int WM_KILLFOCUS = 0x0008;


			internal const int WM_LBUTTONDBLCLK = 0x0203;


			internal const int WM_LBUTTONDOWN = 0x0201;


			internal const int WM_LBUTTONUP = 0x0202;


			internal const int WM_MBUTTONDBLCLK = 0x0209;


			internal const int WM_MBUTTONDOWN = 0x0207;


			internal const int WM_MBUTTONUP = 0x0208;


			internal const int WM_MDIACTIVATE = 0x0222;


			internal const int WM_MDICASCADE = 0x0227;


			internal const int WM_MDICREATE = 0x0220;


			internal const int WM_MDIDESTROY = 0x0221;


			internal const int WM_MDIGETACTIVE = 0x0229;


			internal const int WM_MDIICONARRANGE = 0x0228;


			internal const int WM_MDIMAXIMIZE = 0x0225;


			internal const int WM_MDINEXT = 0x0224;


			internal const int WM_MDIREFRESHMENU = 0x0234;


			internal const int WM_MDIRESTORE = 0x0223;


			internal const int WM_MDISETMENU = 0x0230;


			internal const int WM_MDITILE = 0x0226;


			internal const int WM_MEASUREITEM = 0x002C;


			internal const int WM_MENUCHAR = 0x0120;


			internal const int WM_MENUCOMMAND = 0x0126;


			internal const int WM_MENUDRAG = 0x0123;


			internal const int WM_MENUGETOBJECT = 0x0124;


			internal const int WM_MENURBUTTONUP = 0x0122;


			internal const int WM_MENUSELECT = 0x011F;


			internal const int WM_MOUSEACTIVATE = 0x0021;


			internal const int WM_MOUSEFIRST = 0x0200;


			internal const int WM_MOUSEHOVER = 0x02A1;


			internal const int WM_MOUSELAST = 0x020D;


			internal const int WM_MOUSELEAVE = 0x02A3;


			internal const int WM_MOUSEMOVE = 0x0200;


			internal const int WM_MOUSEWHEEL = 0x020A;


			internal const int WM_MOUSEHWHEEL = 0x020E;


			internal const int WM_MOVE = 0x0003;


			internal const int WM_MOVING = 0x0216;


			internal const int WM_NCACTIVATE = 0x0086;


			internal const int WM_NCCALCSIZE = 0x0083;


			internal const int WM_NCCREATE = 0x0081;


			internal const int WM_NCDESTROY = 0x0082;


			internal const int WM_NCHITTEST = 0x0084;


			internal const int WM_NCLBUTTONDBLCLK = 0x00A3;


			internal const int WM_NCLBUTTONDOWN = 0x00A1;


			internal const int WM_NCLBUTTONUP = 0x00A2;


			internal const int WM_NCMBUTTONDBLCLK = 0x00A9;


			internal const int WM_NCMBUTTONDOWN = 0x00A7;


			internal const int WM_NCMBUTTONUP = 0x00A8;


			internal const int WM_NCMOUSEHOVER = 0x02A0;


			internal const int WM_NCMOUSELEAVE = 0x02A2;


			internal const int WM_NCMOUSEMOVE = 0x00A0;


			internal const int WM_NCPAINT = 0x0085;


			internal const int WM_NCRBUTTONDBLCLK = 0x00A6;


			internal const int WM_NCRBUTTONDOWN = 0x00A4;


			internal const int WM_NCRBUTTONUP = 0x00A5;


			internal const int WM_NCXBUTTONDBLCLK = 0x00AD;


			internal const int WM_NCXBUTTONDOWN = 0x00AB;


			internal const int WM_NCXBUTTONUP = 0x00AC;


			internal const int WM_NCUAHDRAWCAPTION = 0x00AE;


			internal const int WM_NCUAHDRAWFRAME = 0x00AF;


			internal const int WM_NEXTDLGCTL = 0x0028;


			internal const int WM_NEXTMENU = 0x0213;


			internal const int WM_NOTIFY = 0x004E;


			internal const int WM_NOTIFYFORMAT = 0x0055;


			internal const int WM_NULL = 0x0000;


			internal const int WM_PAINT = 0x000F;


			internal const int WM_PAINTCLIPBOARD = 0x0309;


			internal const int WM_PAINTICON = 0x0026;


			internal const int WM_PALETTECHANGED = 0x0311;


			internal const int WM_PALETTEISCHANGING = 0x0310;


			internal const int WM_PARENTNOTIFY = 0x0210;


			internal const int WM_PASTE = 0x0302;


			internal const int WM_PENWINFIRST = 0x0380;


			internal const int WM_PENWINLAST = 0x038F;


			internal const int WM_POWER = 0x0048;


			internal const int WM_POWERBROADCAST = 0x0218;


			internal const int WM_PRINT = 0x0317;


			internal const int WM_PRINTCLIENT = 0x0318;


			internal const int WM_QUERYDRAGICON = 0x0037;


			internal const int WM_QUERYENDSESSION = 0x0011;


			internal const int WM_QUERYNEWPALETTE = 0x030F;


			internal const int WM_QUERYOPEN = 0x0013;


			internal const int WM_QUEUESYNC = 0x0023;


			internal const int WM_QUIT = 0x0012;


			internal const int WM_RBUTTONDBLCLK = 0x0206;


			internal const int WM_RBUTTONDOWN = 0x0204;


			internal const int WM_RBUTTONUP = 0x0205;


			internal const int WM_RENDERALLFORMATS = 0x0306;


			internal const int WM_RENDERFORMAT = 0x0305;


			internal const int WM_SETCURSOR = 0x0020;


			internal const int WM_SETFOCUS = 0x0007;


			internal const int WM_SETFONT = 0x0030;


			internal const int WM_SETHOTKEY = 0x0032;


			internal const int WM_SETICON = 0x0080;


			internal const int WM_SETREDRAW = 0x000B;


			internal const int WM_SETTEXT = 0x000C;


			internal const int WM_SETTINGCHANGE = 0x001A;


			internal const int WM_SHOWWINDOW = 0x0018;


			internal const int WM_SIZE = 0x0005;


			internal const int WM_SIZECLIPBOARD = 0x030B;


			internal const int WM_SIZING = 0x0214;


			internal const int WM_SPOOLERSTATUS = 0x002A;


			internal const int WM_STYLECHANGED = 0x007D;


			internal const int WM_STYLECHANGING = 0x007C;


			internal const int WM_SYNCPAINT = 0x0088;


			internal const int WM_SYSCHAR = 0x0106;


			internal const int WM_SYSCOLORCHANGE = 0x0015;


			internal const int WM_SYSCOMMAND = 0x0112;


			internal const int WM_SYSDEADCHAR = 0x0107;


			internal const int WM_SYSKEYDOWN = 0x0104;


			internal const int WM_SYSKEYUP = 0x0105;


			internal const int WM_TCARD = 0x0052;


			internal const int WM_TIMECHANGE = 0x001E;


			internal const int WM_TIMER = 0x0113;


			internal const int WM_UNDO = 0x0304;


			internal const int WM_UNINITMENUPOPUP = 0x0125;


			internal const int WM_USER = 0x0400;


			internal const int WM_USERCHANGED = 0x0054;


			internal const int WM_VKEYTOITEM = 0x002E;


			internal const int WM_VSCROLL = 0x0115;


			internal const int WM_VSCROLLCLIPBOARD = 0x030A;


			internal const int WM_WINDOWPOSCHANGED = 0x0047;


			internal const int WM_WINDOWPOSCHANGING = 0x0046;


			internal const int WM_WININICHANGE = 0x001A;


			internal const int WM_XBUTTONDBLCLK = 0x020D;


			internal const int WM_XBUTTONDOWN = 0x020B;


			internal const int WM_XBUTTONUP = 0x020C;

		}


		// dwm

		// Fields
		internal const int DWM_BB_BLURREGION = 2;
		internal const int DWM_BB_ENABLE = 1;
		internal const int DWM_BB_TRANSITIONONMAXIMIZED = 4;
		internal const string DWM_COMPOSED_EVENT_BASE_NAME = "DwmComposedEvent_";
		internal const string DWM_COMPOSED_EVENT_NAME_FORMAT = "%s%d";
		internal const int DWM_COMPOSED_EVENT_NAME_MAX_LENGTH = 0x40;
		internal const int DWM_FRAME_DURATION_DEFAULT = -1;
		internal const int DWM_TNP_OPACITY = 4;
		internal const int DWM_TNP_RECTDESTINATION = 1;
		internal const int DWM_TNP_RECTSOURCE = 2;
		internal const int DWM_TNP_SOURCECLIENTAREAONLY = 0x10;
		internal const int DWM_TNP_VISIBLE = 8;
		internal static readonly bool DwmApiAvailable = (Environment.OSVersion.Version.Major >= 6);

		internal const int WM_DWMCOMPOSITIONCHANGED = 0x31e;
		// Methods
		[DllImport("dwmapi.dll")]
		internal static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref IntPtr result);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmEnableComposition(int fEnable);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmEnableMMCSS(int fEnableMMCSS);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmGetColorizationColor(ref int pcrColorization, ref int pfOpaqueBlend);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO pTimingInfo);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmIsCompositionEnabled(ref int pfEnabled);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, int cRefreshes, int fRelative);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref System.Drawing.Size pSize);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, ref System.Drawing.Size pMinimizedSize, ref IntPtr phThumbnailId);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetDxFrameDuration(IntPtr hwnd, int cRefreshes);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetPresentParameters(IntPtr hwnd, ref DWM_PRESENT_PARAMETERS pPresentParams);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);
		[DllImport("dwmapi.dll")]
		internal static extern int DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref DWM_THUMBNAIL_PROPERTIES ptnProperties);

		// Nested Types
		[StructLayout(LayoutKind.Sequential)]
		internal struct DWM_BLURBEHIND
		{
			internal int dwFlags;
			internal int fEnable;
			internal IntPtr hRgnBlur;
			internal int fTransitionOnMaximized;
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct DWM_PRESENT_PARAMETERS
		{
			internal int cbSize;
			internal int fQueue;
			internal long cRefreshStart;
			internal int cBuffer;
			internal int fUseSourceRate;
			internal UNSIGNED_RATIO rateSource;
			internal int cRefreshesPerFrame;
			internal DWM_SOURCE_FRAME_SAMPLING eSampling;
		}

		internal enum DWM_SOURCE_FRAME_SAMPLING
		{
			DWM_SOURCE_FRAME_SAMPLING_POINT,
			DWM_SOURCE_FRAME_SAMPLING_COVERAGE,
			DWM_SOURCE_FRAME_SAMPLING_LAST
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct DWM_THUMBNAIL_PROPERTIES
		{
			internal int dwFlags;
			internal RECT rcDestination;
			internal RECT rcSource;
			internal byte opacity;
			internal int fVisible;
			internal int fSourceClientAreaOnly;
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct DWM_TIMING_INFO
		{
			internal int cbSize;
			internal UNSIGNED_RATIO rateRefresh;
			internal UNSIGNED_RATIO rateCompose;
			internal long qpcVBlank;
			internal long cRefresh;
			internal long qpcCompose;
			internal long cFrame;
			internal long cRefreshFrame;
			internal long cRefreshConfirmed;
			internal int cFlipsOutstanding;
			internal long cFrameCurrent;
			internal long cFramesAvailable;
			internal long cFrameCleared;
			internal long cFramesReceived;
			internal long cFramesDisplayed;
			internal long cFramesDropped;
			internal long cFramesMissed;
		}

		internal enum DWMNCRENDERINGPOLICY
		{
			DWMNCRP_USEWINDOWSTYLE,
			DWMNCRP_DISABLED,
			DWMNCRP_ENABLED
		}

		internal enum DWMWINDOWATTRIBUTE
		{
			DWMWA_ALLOW_NCPAINT = 4,
			DWMWA_CAPTION_BUTTON_BOUNDS = 5,
			DWMWA_FLIP3D_POLICY = 8,
			DWMWA_FORCE_ICONIC_REPRESENTATION = 7,
			DWMWA_LAST = 9,
			DWMWA_NCRENDERING_ENABLED = 1,
			DWMWA_NCRENDERING_POLICY = 2,
			DWMWA_NONCLIENT_RTL_LAYOUT = 6,
			DWMWA_TRANSITIONS_FORCEDISABLED = 3
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct UNSIGNED_RATIO
		{
			internal int uiNumerator;
			internal int uiDenominator;
		}



		[StructLayout(LayoutKind.Sequential)]
		internal struct MARGINS
		{
			internal int cxLeftWidth;
			internal int cxRightWidth;
			internal int cyTopHeight;
			internal int cyBottomHeight;
			internal MARGINS(int Left, int Right, int Top, int Bottom)
			{
				this.cxLeftWidth = Left;
				this.cxRightWidth = Right;
				this.cyTopHeight = Top;
				this.cyBottomHeight = Bottom;
			}
		}


		/// <summary>
		/// Do Not Draw The Caption (Text)
		/// </summary>
		internal static uint WTNCA_NODRAWCAPTION = 0x1;
		/// <summary>
		/// Do Not Draw the Icon
		/// </summary>
		internal static uint WTNCA_NODRAWICON = 0x2;
		/// <summary>
		/// Do Not Show the System Menu
		/// </summary>
		internal static uint WTNCA_NOSYSMENU = 0x4;
		/// <summary>
		/// Do Not Mirror the Question mark Symbol
		/// </summary>

		internal static uint WTNCA_NOMIRRORHELP = 0x8;
		/// <summary>
		/// The Options of What Attributes to Add/Remove
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct WTA_OPTIONS
		{
			internal uint Flags;
			internal uint Mask;
		}

		/// <summary>
		/// What Type of Attributes? (Only One is Currently Defined)
		/// </summary>
		internal enum WindowThemeAttributeType
		{
			WTA_NONCLIENT = 1
		}

		/// <summary>
		/// Set The Window's Theme Attributes
		/// </summary>
		/// <param name="hWnd">The Handle to the Window</param>
		/// <param name="wtype">What Type of Attributes</param>
		/// <param name="attributes">The Attributes to Add/Remove</param>
		/// <param name="size">The Size of the Attributes Struct</param>
		/// <returns>If The Call Was Successful or Not</returns>
		[DllImport("UxTheme.dll")]
		internal static extern int SetWindowThemeAttribute(IntPtr hWnd, WindowThemeAttributeType wtype, ref WTA_OPTIONS attributes, uint size);



	}
}
