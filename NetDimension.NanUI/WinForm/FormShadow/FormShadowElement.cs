using NetDimension.Windows.Imports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NetDimension.WinForm.FormShadow
{
	//你不需要知道这里面发生了什么。
	//YOU DO NOT NEED HAVE TO KNOW WHAT IS HAPPEND HERE.
	internal static class CONSTS
	{
		internal const string CLASS_NAME = "NetDimensionFormShadowWindow";

	}
	internal enum FormShadowDockPositon
	{
		Left = 0,
		Top = 1,
		Right = 2,
		Bottom = 3
	}

	internal delegate void FormShadowResizeEventHandler(object sender, FormShadowResizeArgs args);
	internal class FormShadowResizeArgs : EventArgs
	{
		private readonly FormShadowDockPositon _side;
		private readonly HitTest _mode;

		public FormShadowDockPositon Side
		{
			get { return _side; }
		}

		public HitTest Mode
		{
			get { return _mode; }
		}

		internal FormShadowResizeArgs(FormShadowDockPositon side, HitTest mode)
		{
			_side = side;
			_mode = mode;
		}
	}
	internal class FormShadowElement : IDisposable
	{


		private System.Runtime.InteropServices.GCHandle gcHandle;


		#region private

		private const int CORNER_AREA = 20;


		private const int ERROR_CLASS_ALREADY_EXISTS = 1410;
		private bool _disposed;
		private IntPtr _handle;
		private readonly IntPtr _parentHandle;
		private readonly FormShadowDecorator _decorator;

		private WndProcHandler _wndProcDelegate;

		const int AcSrcOver = 0x00;
		const int AcSrcAlpha = 0x01;

		private const int Size = 10;
		private readonly FormShadowDockPositon _side;
		private const SetWindowPosFlags NoSizeNoMove = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE;

		private bool _parentWindowIsFocused;

		private Color _activeColor = Color.FromArgb(255, 0, 0, 0);
		private Color _inactiveColor = Color.FromArgb(128, 0, 0, 0);

		private readonly List<Color> _activeColors = new List<Color>();
		private readonly List<Color> _inactiveColors = new List<Color>();
		private readonly List<byte> _alphas = new List<byte>();

		private BLENDFUNCTION _blend;
		private POINT _ptZero = new POINT(0, 0);
		private readonly Color _transparent = Color.FromArgb(0);

		private readonly IntPtr _noTopMost = new IntPtr(-2);
		private readonly IntPtr _yesTopMost = new IntPtr(-1);

		#endregion

		#region constuctor

		internal FormShadowElement(FormShadowDockPositon side, IntPtr parent, FormShadowDecorator decorator)
		{
			_side = side;
			_parentHandle = parent;
			_decorator = decorator;

			_blend = new BLENDFUNCTION
			{
				BlendOp = AcSrcOver,
				BlendFlags = 0,
				SourceConstantAlpha = 255,
				AlphaFormat = AcSrcAlpha
			};

			InitializeAlphas();
			InitializeColors();

			CreateWindow($"{CONSTS.CLASS_NAME}_{side}_{parent}");
		}

		#endregion

		#region internal

		//internal bool ExternalResizeEnable { get; set; }

		//internal event FormShadowResizeEventHandler MouseDown;


		internal void SetSize(int width, int height)
		{
			if (_side == FormShadowDockPositon.Top || _side == FormShadowDockPositon.Bottom)
			{
				height = Size;
				width = width + Size * 2;
			}
			else
			{
				width = Size;
				height = height + Size * 2;
			}




			const SetWindowPosFlags flags = (SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);
			User32.SetWindowPos(_handle, new IntPtr(-2), 0, 0, width, height, flags);
			Render();
		}

		internal void SetLocation(WINDOWPOS pos)
		{
			int left = 0;
			int top = 0;
			switch (_side)
			{
				case FormShadowDockPositon.Top:
					left = pos.x - Size;
					top = pos.y - Size;
					break;
				case FormShadowDockPositon.Bottom:
					left = pos.x - Size;
					top = pos.y + pos.cy;
					break;
				case FormShadowDockPositon.Left:
					left = pos.x - Size;
					top = pos.y - Size;
					break;
				case FormShadowDockPositon.Right:
					left = pos.x + pos.cx;
					top = pos.y - Size;
					break;
			}

			UpdateZOrder(left, top, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOACTIVATE);
		}

		internal void UpdateZOrder(int left, int top, SetWindowPosFlags flags)
		{
			User32.SetWindowPos(_handle, !IsTopMost ? _noTopMost : _yesTopMost, left, top, 0, Size, flags);
			//User32.SetWindowPos(_handle, _parentHandle, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);
			//User32.SetWindowPos(_handle, IntPtr.Zero, left, top, 0, Size, flags);

			User32.SetWindowPos(_handle, _parentHandle, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);

		}

		internal void UpdateZOrder()
		{
			//User32.SetWindowPos(_handle, !IsTopMost ? _noTopMost : _yesTopMost, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);
			//User32.SetWindowPos(_handle, _parentHandle, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);
			//User32.SetWindowPos(_handle, IntPtr.Zero, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);

			User32.SetWindowPos(_handle, _parentHandle, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);
		}

		internal Color InactiveColor
		{
			get { return _inactiveColor; }
			set
			{
				_inactiveColor = value;
				InitializeColors();
				Render();
			}
		}

		internal Color ActiveColor
		{
			get
			{
				return _activeColor;
			}
			set
			{
				_activeColor = value;
				InitializeColors();
				Render();
			}
		}


		internal IntPtr Handle
		{
			get { return _handle; }
		}

		internal bool ParentWindowIsFocused
		{
			set
			{
				_parentWindowIsFocused = value;
				Render();
			}
		}

		internal bool IsTopMost { get; set; }

		internal void Show(bool show)
		{
			const int swShowNoActivate = 4;
			User32.ShowWindow(_handle, show ? swShowNoActivate : 0);
		}

		internal void Close()
		{
			User32.CloseWindow(_handle);
			User32.SetParent(_handle, IntPtr.Zero);
			User32.DestroyWindow(_handle);
		}

		#endregion

		#region private

		private void CreateWindow(string className)
		{
			if (className == null) throw new Exception("class_name is null");
			if (className == String.Empty) throw new Exception("class_name is empty");

			_wndProcDelegate = CustomWndProc;

			gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(_wndProcDelegate);

			WNDCLASS windClass = new WNDCLASS
			{
				cbClsExtra = 0,
				cbWndExtra = 0,
				hbrBackground = IntPtr.Zero,
				hCursor = IntPtr.Zero,
				hIcon = IntPtr.Zero,
				lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate),
				lpszClassName = className,
				lpszMenuName = null,
				style = 0
			};

			ushort classAtom = User32.RegisterClassW(ref windClass);

			int lastError = Marshal.GetLastWin32Error();

			if (classAtom == 0 && lastError != ERROR_CLASS_ALREADY_EXISTS)
			{
				throw new Exception("Could not register window class");
			}


			var owner = User32.GetWindow(_parentHandle, GetWindowCommands.GW_OWNER);

			_handle = User32.CreateWindowEx(
					(int)(WindowExStyles.WS_EX_LEFT | WindowExStyles.WS_EX_LTRREADING | WindowExStyles.WS_EX_LAYERED | WindowExStyles.WS_EX_TOOLWINDOW | WindowExStyles.WS_EX_RIGHTSCROLLBAR | WindowExStyles.WS_EX_NOACTIVATE | WindowExStyles.WS_EX_TRANSPARENT),
					new IntPtr(classAtom),
					className,
					//-(WindowStyles.WS_VISIBLE | WindowStyles.WS_MINIMIZE | WindowStyles.WS_CHILDWINDOW | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_DISABLED | WindowStyles.WS_POPUP),
					(WindowStyles.WS_POPUP | WindowStyles.WS_VISIBLE | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_CLIPCHILDREN),
					0, 0, 0, 0, owner, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

			if (_handle == IntPtr.Zero)
			{
				return;
			}

			//const UInt32 extendedStyle = (UInt32)(
			//	WindowExStyles.WS_EX_LEFT |
			//	WindowExStyles.WS_EX_LTRREADING |
			//	WindowExStyles.WS_EX_RIGHTSCROLLBAR |
			//	WindowExStyles.WS_EX_TOOLWINDOW);

			//const UInt32 style = (UInt32)(
			//	WindowStyles.WS_CLIPSIBLINGS |
			//	WindowStyles.WS_CLIPCHILDREN |
			//	WindowStyles.WS_POPUP);

			//// Create window
			//_handle = User32.CreateWindowExW(
			//	extendedStyle,
			//	className,
			//	className,
			//	style,
			//	0,
			//	0,
			//	0,
			//	0,
			//	IntPtr.Zero,
			//	IntPtr.Zero,
			//	IntPtr.Zero,
			//	IntPtr.Zero
			//);

			//if (_handle == IntPtr.Zero)
			//{
			//	return;
			//}

			//uint styles = User32.GetWindowLong(_handle, GetWindowLongFlags.GWL_EXSTYLE);
			//styles = styles | (int)WindowExStyles.WS_EX_LAYERED | (int)WindowExStyles.WS_EX_NOACTIVATE | (int)WindowExStyles.WS_EX_TRANSPARENT;
			//User32.SetWindowLong(_handle, GetWindowLongFlags.GWL_EXSTYLE, styles);
		}

		private IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
		{

			//if (msg.Is(WindowsMessages.WM_LBUTTONDOWN))
			//{
			//	CastMouseDown();
			//}

			//if (msg.Is(WindowsMessages.WM_SETFOCUS))
			//{
			//	User32.PostMessage(_parentHandle, msg, hWnd, IntPtr.Zero);
			//}


			//if (msg.Is(WindowsMessages.WM_SETCURSOR))
			//{
			//	SetCursor();
			//	return new IntPtr(1);
			//}

			return User32.DefWindowProcW(hWnd, msg, wParam, lParam);
		}

		private Bitmap GetBitmap(int width, int height)
		{
			Bitmap bmp;
			switch (_side)
			{
				case FormShadowDockPositon.Top:
				case FormShadowDockPositon.Bottom:
					bmp = new Bitmap(width, Size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					break;
				case FormShadowDockPositon.Left:
				case FormShadowDockPositon.Right:
					bmp = new Bitmap(Size, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			Graphics g = Graphics.FromImage(bmp);
			List<Color> colorMap = _parentWindowIsFocused ? _activeColors : _inactiveColors;

			RECT windowRect = new RECT();
			User32.GetWindowRect(_parentHandle, ref windowRect);





			if (_side == FormShadowDockPositon.Top || _side == FormShadowDockPositon.Bottom)
			{



				for (int i = 0; i < _alphas.Count; i++)
				{
					Color color = Color.FromArgb((int)(_alphas[i] * (colorMap[i].A / 255f)), colorMap[i].R, colorMap[i].G, colorMap[i].B);
					Pen pen = new Pen(color);
					int y = (_side == FormShadowDockPositon.Top) ? Size - 1 - i : i;
					const int xLeft = Size * 2 - 2;
					int xRight = width - Size * 2 + 2;
					g.DrawLine(pen, new Point(xLeft, y), new Point(xRight, y));
					double a = _alphas[i] / (Size + i);

					for (int j = 0; j < Size; j++)
					{
						double al = Math.Max(0, _alphas[i] - a * j);
						color = Color.FromArgb((int)(al * (colorMap[i].A / 255f)), colorMap[i].R, colorMap[i].G, colorMap[i].B);
						System.Drawing.Brush b = new SolidBrush(color);
						g.FillRectangle(b, xLeft - 1 - j, y, 1, 1);
						g.FillRectangle(b, xRight + 1 + j, y, 1, 1);
					}
					for (int j = Size; j < Size + i; j++)
					{
						double al = Math.Max(0, _alphas[i] - a * j) / 2;
						color = Color.FromArgb((int)(al * (colorMap[i].A / 255f)), colorMap[i].R, colorMap[i].G, colorMap[i].B);
						System.Drawing.Brush b = new SolidBrush(color);
						g.FillRectangle(b, xLeft - 1 - j, y, 1, 1);
						g.FillRectangle(b, xRight + 1 + j, y, 1, 1);
					}

				}

			}
			else
			{
				for (int i = 0; i < _alphas.Count; i++)
				{
					Color color = Color.FromArgb((int)(_alphas[i] * (colorMap[i].A / 255f)), colorMap[i].R, colorMap[i].G, colorMap[i].B);
					Pen pen = new Pen(color);
					int x = (_side == FormShadowDockPositon.Right) ? i : Size - i - 1;
					const int yTop = Size * 2 - 1;
					int yBottom = height - Size * 2 + 1;
					g.DrawLine(pen, new Point(x, yTop), new Point(x, yBottom));

					double a = _alphas[i] / (Size + i);
					for (int j = 0; j < Size + 1; j++)
					{
						double al = Math.Max(0, _alphas[i] - a * j);
						color = Color.FromArgb((int)(al * (colorMap[i].A / 255f)), colorMap[i].R, colorMap[i].G, colorMap[i].B);
						System.Drawing.Brush b = new SolidBrush(color);
						g.FillRectangle(b, x, yTop - 1 - j, 1, 1);
						g.FillRectangle(b, x, yBottom + 1 + j, 1, 1);
					}
					for (int j = Size; j < Size + i + 1; j++)
					{
						double al = Math.Max(0, _alphas[i] - a * j) / 2;
						color = Color.FromArgb((int)(al * (colorMap[i].A / 255f)), colorMap[i].R, colorMap[i].G, colorMap[i].B);
						System.Drawing.Brush b = new SolidBrush(color);
						g.FillRectangle(b, x, yTop - 1 - j, 1, 1);
						g.FillRectangle(b, x, yBottom + 1 + j, 1, 1);
					}


				}
			}
			g.Flush();


			return bmp;
		}

		private void Render()
		{

			RECT rect = new RECT();
			User32.GetWindowRect(_handle, ref rect);



			int width = rect.right - rect.left;
			int height = rect.bottom - rect.top;
			if (width == 0 || height == 0) return;

			POINT newLocation = new POINT(rect.left, rect.top);
			SIZE newSize = new SIZE(width, height);
			IntPtr screenDc = User32.GetDC(IntPtr.Zero);
			IntPtr memDc = Gdi32.CreateCompatibleDC(screenDc);

			using (Bitmap bmp = GetBitmap(width, height))
			{
				IntPtr hBitmap = bmp.GetHbitmap(_transparent);
				IntPtr hOldBitmap = Gdi32.SelectObject(memDc, hBitmap);

				User32.UpdateLayeredWindow(_handle, screenDc, ref newLocation, ref newSize, memDc, ref _ptZero, 0, ref _blend, 0x02);

				User32.ReleaseDC(IntPtr.Zero, screenDc);
				if (hBitmap != IntPtr.Zero)
				{
					Gdi32.SelectObject(memDc, hOldBitmap);
					Gdi32.DeleteObject(hBitmap);
				}
			}

			Gdi32.DeleteDC(memDc);

			GC.Collect();

			UpdateZOrder();

		}

		private void InitializeAlphas()
		{
			_alphas.Clear();

			_alphas.Add(120);
			_alphas.Add(66);
			_alphas.Add(46);
			_alphas.Add(25);
			_alphas.Add(19);
			_alphas.Add(10);
			_alphas.Add(07);
			_alphas.Add(02);
			_alphas.Add(01);
			_alphas.Add(00); // transparent
		}

		private void InitializeColors()
		{
			_activeColors.Clear();
			_inactiveColors.Clear();

			for (int i = 0; i < Size; i++)
			{
				_activeColors.Add(_activeColor);
				_inactiveColors.Add(_inactiveColor);
			}
		}

		//private void SetCursor()
		//{
		//	if (!ExternalResizeEnable)
		//	{
		//		return;
		//	}

		//	IntPtr handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_HAND);
		//	HitTest mode = GetResizeMode();
		//	switch (mode)
		//	{
		//		case HitTest.HTTOP:
		//		case HitTest.HTBOTTOM:
		//			handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENS);
		//			break;
		//		case HitTest.HTLEFT:
		//		case HitTest.HTRIGHT:
		//			handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZEWE);
		//			break;
		//		case HitTest.HTTOPLEFT:
		//		case HitTest.HTBOTTOMRIGHT:
		//			handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENWSE);
		//			break;
		//		case HitTest.HTTOPRIGHT:
		//		case HitTest.HTBOTTOMLEFT:
		//			handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENESW);
		//			break;
		//	}

		//	if (handle != IntPtr.Zero)
		//	{
		//		User32.SetCursor(handle);
		//	}
		//}

		//private void CastMouseDown()
		//{

		//	if (!ExternalResizeEnable)
		//	{
		//		return;
		//	}

		//	HitTest mode = GetResizeMode();



		//	if (MouseDown != null)
		//	{
		//		FormShadowResizeArgs args = new FormShadowResizeArgs(_side, mode);
		//		MouseDown(this, args);
		//	}
		//}

		//private POINT GetRelativeMousePosition()
		//{
		//	POINT point = new POINT();
		//	User32.GetCursorPos(ref point);
		//	User32.ScreenToClient(_handle, ref point);
		//	return point;
		//}

		//private HitTest GetResizeMode()
		//{
		//	HitTest mode = HitTest.HTNOWHERE;

		//	RECT rect = new RECT();
		//	POINT point = GetRelativeMousePosition();
		//	User32.GetWindowRect(_handle, ref rect);
		//	switch (_side)
		//	{
		//		case FormShadowDockPositon.Top:
		//			int width = rect.right - rect.left;
		//			if (point.x < CORNER_AREA) mode = HitTest.HTTOPLEFT;
		//			else if (point.x > width - CORNER_AREA) mode = HitTest.HTTOPRIGHT;
		//			else mode = HitTest.HTTOP;
		//			break;
		//		case FormShadowDockPositon.Bottom:
		//			width = rect.right - rect.left;
		//			if (point.x < CORNER_AREA) mode = HitTest.HTBOTTOMLEFT;
		//			else if (point.x > width - CORNER_AREA) mode = HitTest.HTBOTTOMRIGHT;
		//			else mode = HitTest.HTBOTTOM;
		//			break;
		//		case FormShadowDockPositon.Left:
		//			int height = rect.bottom - rect.top;
		//			if (point.y < CORNER_AREA) mode = HitTest.HTTOPLEFT;
		//			else if (point.y > height - CORNER_AREA) mode = HitTest.HTBOTTOMLEFT;
		//			else mode = HitTest.HTLEFT;
		//			break;
		//		case FormShadowDockPositon.Right:
		//			height = rect.bottom - rect.top;
		//			if (point.y < CORNER_AREA) mode = HitTest.HTTOPRIGHT;
		//			else if (point.y > height - CORNER_AREA) mode = HitTest.HTBOTTOMRIGHT;
		//			else mode = HitTest.HTRIGHT;
		//			break;
		//	}

		//	return mode;
		//}

		#endregion

		#region Dispose

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (_disposed) return;
			_disposed = true;
			if (_handle == IntPtr.Zero) return;

			User32.DestroyWindow(_handle);
			_handle = IntPtr.Zero;
			gcHandle.Free();
		}

		#endregion
	}
}
