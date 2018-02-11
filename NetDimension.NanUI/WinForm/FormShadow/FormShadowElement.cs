using NetDimension.Windows.Imports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NetDimension.WinForm.FormShadow
{
	//你不需要知道这里面发生了什么。
	//YOU DO NOT NEED HAVE TO KNOW WHAT IS HAPPEND HERE.
	public class LockBitmap
	{
		Bitmap source = null;
		IntPtr Iptr = IntPtr.Zero;
		BitmapData bitmapData = null;

		public byte[] Pixels { get; set; }
		public int Depth { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		public LockBitmap(Bitmap source)
		{
			this.source = source;
		}

		/// <summary>
		/// Lock bitmap data
		/// </summary>
		public void LockBits()
		{
			try
			{
				// Get width and height of bitmap
				Width = source.Width;
				Height = source.Height;

				// get total locked pixels count
				int PixelCount = Width * Height;

				// Create rectangle to lock
				Rectangle rect = new Rectangle(0, 0, Width, Height);

				// get source bitmap pixel format size
				Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

				// Check if bpp (Bits Per Pixel) is 8, 24, or 32
				if (Depth != 8 && Depth != 24 && Depth != 32)
				{
					throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
				}

				// Lock bitmap and return bitmap data
				bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite,
											 source.PixelFormat);

				// create byte array to copy pixel values
				int step = Depth / 8;
				Pixels = new byte[PixelCount * step];
				Iptr = bitmapData.Scan0;

				// Copy data from pointer to array
				Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Unlock bitmap data
		/// </summary>
		public void UnlockBits()
		{
			try
			{
				// Copy data from byte array to pointer
				Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

				// Unlock bitmap data
				source.UnlockBits(bitmapData);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Get the color of the specified pixel
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public Color GetPixel(int x, int y)
		{
			Color clr = Color.Empty;

			// Get color components count
			int cCount = Depth / 8;

			// Get start index of the specified pixel
			int i = ((y * Width) + x) * cCount;

			if (i > Pixels.Length - cCount)
				throw new IndexOutOfRangeException();

			if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
			{
				byte b = Pixels[i];
				byte g = Pixels[i + 1];
				byte r = Pixels[i + 2];
				byte a = Pixels[i + 3]; // a
				clr = Color.FromArgb(a, r, g, b);
			}
			if (Depth == 24) // For 24 bpp get Red, Green and Blue
			{
				byte b = Pixels[i];
				byte g = Pixels[i + 1];
				byte r = Pixels[i + 2];
				clr = Color.FromArgb(r, g, b);
			}
			if (Depth == 8)
			// For 8 bpp get color value (Red, Green and Blue values are the same)
			{
				byte c = Pixels[i];
				clr = Color.FromArgb(c, c, c);
			}
			return clr;
		}

		/// <summary>
		/// Set the color of the specified pixel
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="color"></param>
		public void SetPixel(int x, int y, Color color)
		{
			// Get color components count
			int cCount = Depth / 8;

			// Get start index of the specified pixel
			int i = ((y * Width) + x) * cCount;

			if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
			{
				Pixels[i] = color.B;
				Pixels[i + 1] = color.G;
				Pixels[i + 2] = color.R;
				Pixels[i + 3] = color.A;
			}
			if (Depth == 24) // For 24 bpp set Red, Green and Blue
			{
				Pixels[i] = color.B;
				Pixels[i + 1] = color.G;
				Pixels[i + 2] = color.R;
			}
			if (Depth == 8)
			// For 8 bpp set color value (Red, Green and Blue values are the same)
			{
				Pixels[i] = color.B;
			}
		}
	}


	internal class FormShadowElement : IDisposable
	{


		private GCHandle gcHandle;


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

		private const int Size = 20;
		private readonly FormShadowDockPositon _side;
		private const SetWindowPosFlags NoSizeNoMove = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE;

		private bool _parentWindowIsFocused;

		//private Color _activeColor = Color.FromArgb(255, 255, 0, 0);
		//private Color _inactiveColor = Color.FromArgb(128, 0, 255, 0);

		private BLENDFUNCTION _blend;
		private POINT _ptZero = new POINT(0, 0);
		private readonly Color _transparent = Color.FromArgb(0);

		private readonly IntPtr _noTopMost = new IntPtr(-2);
		private readonly IntPtr _yesTopMost = new IntPtr(-1);

		#endregion

		#region constuctor

		//Bitmap[] cachedImages;

		protected IntPtr Region { get; set; } = IntPtr.Zero;


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



			//cachedImages = new Bitmap[3];

			//switch (side)
			//{
			//	case FormShadowDockPositon.Left:
			//		cachedImages[0] = NetDimension.NanUI.Properties.Resources.PopupFormShadowFrameLeft;
			//		break;
			//	case FormShadowDockPositon.Top:
			//		cachedImages[0] = NetDimension.NanUI.Properties.Resources.PopupFormShadowFrameTop;
			//		break;
			//	case FormShadowDockPositon.Right:
			//		cachedImages[0] = NetDimension.NanUI.Properties.Resources.PopupFormShadowFrameRight;
			//		break;
			//	case FormShadowDockPositon.Bottom:
			//		cachedImages[0] = NetDimension.NanUI.Properties.Resources.PopupFormShadowFrameBottom;
			//		break;
			//}

			//InitializeBitmapCache();
			CreateWindow($"{CONSTS.CLASS_NAME}_{side}_{parent}");
		}

		//private void InitializeBitmapCache()
		//{
		//	var rawImage = cachedImages[0];
		//	var activeImageCore = cachedImages[1] = (Bitmap)rawImage.Clone();
		//	var inactiveImageCore = cachedImages[2] = (Bitmap)rawImage.Clone();
		//	BlendBitmapWithColor(activeImageCore, ActiveColor);
		//	BlendBitmapWithColor(inactiveImageCore, InactiveColor, 0.6f);
		//}

		//private void BlendBitmapWithColor(Bitmap source, Color color, float alphaDepth = 1f)
		//{
		//	var rect = new Rectangle(0, 0, source.Width, source.Height);
		//	if (alphaDepth > 1) alphaDepth = 1;

		//	var bmp = new LockBitmap(source);
		//	bmp.LockBits();

		//	for (var y = rect.Top; y < rect.Bottom; y++)
		//	{
		//		for (var x = rect.Left; x < rect.Right; x++)
		//		{
		//			var targetColor = bmp.GetPixel(x, y);

		//			var alpha = Convert.ToByte(targetColor.A * alphaDepth);

		//			var r = color.R;
		//			var g = color.G;
		//			var b = color.B;

		//			bmp.SetPixel(x, y, Color.FromArgb(alpha, r, g, b));
		//		}
		//	}

		//	bmp.UnlockBits();


		//}

		internal void SetOwner(IntPtr owner)
		{
			User32.SetWindowLong(_handle, GetWindowLongFlags.GWL_HWNDPARENT, owner);
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
					top = pos.y;
					break;
				case FormShadowDockPositon.Right:
					left = pos.x + pos.cx;
					top = pos.y;
					break;
			}

			UpdateZOrder(left, top, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOACTIVATE);
		}

		internal void UpdateZOrder(int left, int top, SetWindowPosFlags flags)
		{
			User32.SetWindowPos(_handle, !IsTopMost ? _noTopMost : _yesTopMost, left, top, 0, Size, flags);

			User32.SetWindowPos(_handle, _parentHandle, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);

		}

		internal void UpdateZOrder()
		{
			User32.SetWindowPos(_handle, !IsTopMost ? _noTopMost : _yesTopMost, 0, 0, 0, Size, NoSizeNoMove | SetWindowPosFlags.SWP_NOACTIVATE);
			User32.SetWindowPos(_handle, _parentHandle, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
		}



		public void UpdateShadow()
		{
			Render();
		}


		internal IntPtr Handle
		{
			get { return _handle; }
		}

		internal bool ParentWindowIsFocused
		{
			set
			{
				var needRefresh = false;
				if (_parentWindowIsFocused != value)
				{
					needRefresh = true;
				}
				_parentWindowIsFocused = value;

				if (needRefresh)
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
			if (Region != IntPtr.Zero)
			{
				Gdi32.SetWindowRgn(Handle, IntPtr.Zero, false);
				Gdi32.DeleteObject(Region);
			}
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

			gcHandle = GCHandle.Alloc(_wndProcDelegate);

			WNDCLASS windClass = new WNDCLASS
			{
				lpszClassName = className,
				lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate)
			};

			ushort classAtom = User32.RegisterClassW(ref windClass);

			int lastError = Marshal.GetLastWin32Error();

			if (classAtom == 0 && lastError != ERROR_CLASS_ALREADY_EXISTS)
			{
				throw new Exception("Could not register window class");
			}

			const UInt32 extendedStyle = (UInt32)(
				WindowExStyles.WS_EX_LEFT |
				WindowExStyles.WS_EX_LTRREADING |
				WindowExStyles.WS_EX_RIGHTSCROLLBAR |
				WindowExStyles.WS_EX_TOOLWINDOW);

			const UInt32 style = (UInt32)(
				WindowStyles.WS_CLIPSIBLINGS |
				WindowStyles.WS_CLIPCHILDREN |
				WindowStyles.WS_POPUP);

			var owner = User32.GetWindow(_parentHandle, 4);

			// Create window
			_handle = User32.CreateWindowExW(
				extendedStyle,
				className,
				className,
				style,
				0,
				0,
				0,
				0,
				IntPtr.Zero,
				IntPtr.Zero,
				IntPtr.Zero,
				IntPtr.Zero
			);

			if (_handle == IntPtr.Zero)
			{
				return;
			}

			uint styles = User32.GetWindowLong(_handle, GetWindowLongFlags.GWL_EXSTYLE);
			styles = styles | (int)WindowExStyles.WS_EX_LAYERED | (int)WindowExStyles.WS_EX_NOACTIVATE | (int)WindowExStyles.WS_EX_TRANSPARENT;
			User32.SetWindowLong(_handle, GetWindowLongFlags.GWL_EXSTYLE, styles);
		}

		private IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
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

			RECT windowRect = new RECT();
			User32.GetWindowRect(_parentHandle, ref windowRect);
			Bitmap cachedBmp = _parentWindowIsFocused ? _decorator.ActiveBitmapTemplate : _decorator.InactiveBitmapTemplate;

			lock (cachedBmp)
			{
				using (var g = Graphics.FromImage(bmp))
				{
					switch (_side)
					{
						case FormShadowDockPositon.Left:
							{
								var srcNearCornerRect = new Rectangle(0, 20, 20, 40);
								var srcFarCornerRect = new Rectangle(0, 130, 20, 40);
								var srcRect = new Rectangle(0, 60, 20, 20);

								var destNearCornerRect = new Rectangle(0, 0, 20, 40);
								var destFarCornerRect = new Rectangle(0, height - 40, 20, 40);
								var destRect = new Rectangle(0, 40, 20, height - 40 * 2);

								g.SetClip(destNearCornerRect);
								g.DrawImage(cachedBmp, destNearCornerRect, srcNearCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.SetClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destFarCornerRect, srcFarCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.ExcludeClip(destNearCornerRect);
								g.ExcludeClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destRect, srcRect, GraphicsUnit.Pixel);
								g.ResetClip();

							}
							break;
						case FormShadowDockPositon.Right:
							{
								var srcNearCornerRect = new Rectangle(cachedBmp.Width - 20, 20, 20, 40);
								var srcFarCornerRect = new Rectangle(cachedBmp.Width - 20, 130, 20, 40);
								var srcRect = new Rectangle(cachedBmp.Width - 20, 60, 20, 20);

								var destNearCornerRect = new Rectangle(width - 20, 0, 20, 40);
								var destFarCornerRect = new Rectangle(width - 20, height - 40, 20, 40);
								var destRect = new Rectangle(width - 20, 40, 20, height - 40 * 2);

								g.SetClip(destNearCornerRect);
								g.DrawImage(cachedBmp, destNearCornerRect, srcNearCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.SetClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destFarCornerRect, srcFarCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.ExcludeClip(destNearCornerRect);
								g.ExcludeClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destRect, srcRect, GraphicsUnit.Pixel);
								g.ResetClip();


							}
							break;

						case FormShadowDockPositon.Top:
							{
								var srcNearCornerRect = new Rectangle(0, 0, 40, 20);
								var srcFarCornerRect = new Rectangle(200, 0, 40, 20);
								var srcRect = new Rectangle(40, 0, 160, 20);

								var destNearCornerRect = new Rectangle(0, 0, 40, 20);
								var destFarCornerRect = new Rectangle(width - 40, 0, 40, 20);
								var destRect = new Rectangle(40, 0, width - 40 * 2, 20);

								g.SetClip(destNearCornerRect);
								g.DrawImage(cachedBmp, destNearCornerRect, srcNearCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.SetClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destFarCornerRect, srcFarCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.ExcludeClip(destNearCornerRect);
								g.ExcludeClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destRect, srcRect, GraphicsUnit.Pixel);
								g.ResetClip();
							}
							break;
						case FormShadowDockPositon.Bottom:
							{
								var srcNearCornerRect = new Rectangle(0, cachedBmp.Height - 20, 40, 20);
								var srcFarCornerRect = new Rectangle(200, cachedBmp.Height - 20, 40, 20);
								var srcRect = new Rectangle(40, cachedBmp.Height - 20, 160, 20);

								var destNearCornerRect = new Rectangle(0, height - 20, 40, 20);
								var destFarCornerRect = new Rectangle(width - 40, height - 20, 40, 20);
								var destRect = new Rectangle(40, height - 20, width - 40 * 2, 20);

								g.SetClip(destNearCornerRect);
								g.DrawImage(cachedBmp, destNearCornerRect, srcNearCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.SetClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destFarCornerRect, srcFarCornerRect, GraphicsUnit.Pixel);
								g.ResetClip();

								g.ExcludeClip(destNearCornerRect);
								g.ExcludeClip(destFarCornerRect);
								g.DrawImage(cachedBmp, destRect, srcRect, GraphicsUnit.Pixel);
								g.ResetClip();




							}
							break;
					}
				}

			}


			return bmp;
		}

		private void Render()
		{

			ExcludeRegion();
			DrawToLayeredWindow();
			



		}

		private void DrawToLayeredWindow()
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
			//ExcludeRegion();
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
		}


		private void ExcludeRegion()
		{
			if (!ShouldExlcudeRegion) return;
			IntPtr hRegion = IntPtr.Zero;
			try
			{
				hRegion = GetRegion();
				if (hRegion != IntPtr.Zero)
				{
					Gdi32.SetWindowRgn(Handle, hRegion, false);
				}
				if (Region != IntPtr.Zero)
					Gdi32.DeleteObject(Region);
				Region = hRegion;
			}
			finally
			{
				if (hRegion != IntPtr.Zero) Gdi32.DeleteObject(hRegion);
			}
		}

		private IntPtr GetRegion()
		{
			IntPtr hShadowReg = IntPtr.Zero;
			IntPtr hOwnerReg = IntPtr.Zero;
			IntPtr hRegion = IntPtr.Zero;
			try
			{
				var rect = new RECT();
				User32.GetWindowRect(_handle, ref rect);


				hShadowReg = Gdi32.CreateRectRgn(0, 0, rect.Width, rect.Height);
				hOwnerReg = Gdi32.CreateRectRgn(GetRegionRect());
				hRegion = CombineRgn(hShadowReg, hOwnerReg, 4);
			}
			finally
			{
				if (hShadowReg != IntPtr.Zero)
					Gdi32.DeleteObject(hShadowReg);
				if (hOwnerReg != IntPtr.Zero)
					Gdi32.DeleteObject(hOwnerReg);
			}
			return hRegion;
		}

		private bool ShouldExlcudeRegion
		{
			get
			{
				var rect = new RECT();
				User32.GetWindowRect(_handle, ref rect);
				return rect.Width != 0 && rect.Height != 0;
			}
		}

		protected Rectangle GetRegionRect()
		{
			var rect = new RECT();
			User32.GetWindowRect(_handle, ref rect);

			int offset = 20;
			int width = rect.Width;
			int height = rect.Height;
			return new Rectangle(offset, offset, width, height);


		}

		protected IntPtr CombineRgn(IntPtr hrgnSrc1, IntPtr hrgnSrc2, int fnCombineMode)
		{
			IntPtr hRegion = Gdi32.CreateRectRgn(Rectangle.Empty);
			Gdi32.CombineRgn(hRegion, hrgnSrc1, hrgnSrc2, fnCombineMode);
			return hRegion;
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
