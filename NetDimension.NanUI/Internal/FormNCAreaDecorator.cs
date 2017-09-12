using NetDimension.NanUI.Internal.Imports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI.Internal
{

	public class FormNCAreaDecorator : NativeWindow, IDisposable
	{
		private IntPtr parentWindowHWnd;
		private Form parentWindow;

		internal static readonly IntPtr TRUE = new IntPtr(1);
		internal static readonly IntPtr FALSE = new IntPtr(0);

		internal static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);
		internal static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);

		static readonly IntPtr WVR_VALIDRECTS = new IntPtr(0x400);
		private static int ncFrameHeight = 8;
		private static int ncFrameWidth = 8;
		private static int ncCaptionHeight = SystemInformation.CaptionHeight + ncFrameHeight;

		private bool isFrameSizeStored = false;



		private bool isEnabled;
		private Color borderColor = Color.Gray;

		private int borderSize = 1;

		private bool isMaximized = false;
		private bool isMinimized = false;


		/// <summary>
		/// 设置或获取主窗体边框颜色颜色。
		/// </summary>

		public Color BorderColor
		{
			get
			{
				return borderColor;
			}

			set
			{
				borderColor = value;

				User32.SendFrameChanged(parentWindowHWnd);
			}
		}

		public int BorderSize
		{
			get
			{
				return borderSize;
			}
			set
			{
				borderSize = value;

				User32.SendFrameChanged(parentWindowHWnd);
			}
		}

		private void ForceRender()
		{
			User32.InvalidateWindow(parentWindowHWnd);
		}

		public bool IsEnabled
		{
			get { return isEnabled; }
		}
		public FormNCAreaDecorator(Form window, bool enable = true)
		{
			parentWindow = window;
			parentWindowHWnd = window.Handle;


			AssignHandle(parentWindowHWnd);

			User32.InvalidateWindow(parentWindowHWnd);
			RecalculateSize();
			User32.InvalidateWindow(parentWindowHWnd);

			isEnabled = enable;
		}

		private void RecalculateSize()
		{
			User32.SetWindowPos(parentWindowHWnd, IntPtr.Zero,
				0, 0, 0, 0,
				SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
		}

		Rectangle regionRect = Rectangle.Empty;
		protected Rectangle FormBounds
		{
			get
			{
				if (Handle == IntPtr.Zero) return new Rectangle(0, 0, parentWindow.Bounds.Width, parentWindow.Bounds.Height);
				var r = new RECT();
				User32.GetWindowRect(Handle, ref r);
				return new Rectangle(r.left, r.top, (int)r.Width, (int)r.Height);
			}
		}

		void SetRegion(Region region, Rectangle rect)
		{
			if (this.regionRect == rect)
			{
				if (region != null)
					region.Dispose();
				return;
			}
			if (parentWindow.Region != null)
			{
				parentWindow.Region.Dispose();
			}
			parentWindow.Region = region;
			if (object.Equals(region, parentWindow.Region))
				this.regionRect = rect;
		}

		protected virtual Region GetDefaultFormRegion(ref Rectangle rect)
		{
			rect = Rectangle.Empty;
			return null;
		}


		protected override void WndProc(ref Message m)
		{
			if (!isEnabled || IsDisposed)
			{
				base.WndProc(ref m);
				return;
			}

			var msg = m.Msg;

			switch (msg)
			{
				//case (int)WindowsMessages.WM_GETMINMAXINFO:
				//	var info = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));

				//	var wa = Screen.FromHandle(parentWindowHWnd).WorkingArea;

				//	info.ptMaxPosition.x = 0;
				//	info.ptMaxPosition.y = 0;

				//	info.ptMaxSize.x = wa.Width;
				//	info.ptMaxSize.y = wa.Height;

				//	Marshal.StructureToPtr(info, m.LParam, true);


				//	base.WndProc(ref m);

				//	break;
				case (int)WindowsMessages.WM_NCACTIVATE:
					if (m.WParam == Win32DataUtils.FALSE)
					{
						m.Result = MESSAGE_HANDLED;
					}
					User32.InvalidateWindow(parentWindowHWnd);
					break;
				case (int)WindowsMessages.WM_ACTIVATEAPP:
				case (int)WindowsMessages.WM_MOVE:
					base.WndProc(ref m);

					User32.InvalidateWindow(parentWindowHWnd);

					break;
				case (int)WindowsMessages.WM_SIZE:

					var width = User32.LoWord(m.LParam);
					var height = User32.HiWord(m.LParam);

					if (m.WParam == (IntPtr)WindowSizeMessageFlags.SIZE_RESTORED && isMaximized)
					{
						isMaximized = false;
						isMinimized = false;
						//fix: In Win7 or higher, drag a window maximized will casue ncpaint error, so force window to calculate size of the nonclient area.
						//fix: 在Win7系统下面如果窗体最大化，拖动窗体会造成非客户区绘制错误，因为没有触发WM_NCCALCSIZE，所以强制触发这个消息来使非客户去重新计算大小。
						User32.SendFrameChanged(parentWindowHWnd);
					}

					if (m.WParam == (IntPtr)WindowSizeMessageFlags.SIZE_MAXIMIZED)
					{
						isMaximized = true;
						isMinimized = false;

						User32.SendFrameChanged(parentWindowHWnd);
					}


					if (isMaximized)
					{
						Screen screen = Screen.FromHandle(Handle);
						if (screen == null) return;
						Rectangle bounds = parentWindow.FormBorderStyle == FormBorderStyle.None ? screen.Bounds : screen.WorkingArea;
						Rectangle formBounds = FormBounds;
						if (formBounds.X == -10000 || formBounds.Y == -10000)
							return;
						Rectangle r = new Rectangle(bounds.X - formBounds.X, bounds.Y - formBounds.Y, formBounds.Width - (formBounds.Width - bounds.Width), formBounds.Height - (formBounds.Height - bounds.Height));

						SetRegion(new Region(r), r);
					}
					else if (isMinimized)
					{
						SetRegion(null, Rectangle.Empty);
						return;
					}
					else
					{
						Rectangle rect = new Rectangle();
						Region region = GetDefaultFormRegion(ref rect);
						SetRegion(region, rect);
					}
					//User32.InvalidateWindow(parentWindowHWnd);


					base.WndProc(ref m);

					break;
				case (int)WindowsMessages.WM_NCLBUTTONDOWN:
					if (m.WParam == (IntPtr)2 && isMaximized)
					{
						User32.SendFrameChanged(parentWindowHWnd);
					}

					base.WndProc(ref m);
					break;
				case (int)WindowsMessages.WM_SYSCOMMAND:

					if (m.WParam == (IntPtr)SystemCommandFlags.SC_MAXIMIZE)
					{

						isMaximized = true;
						isMinimized = false;
					}
					else if (m.WParam == (IntPtr)SystemCommandFlags.SC_MINIMIZE)
					{
						isMinimized = true;
					}
					else if (m.WParam == (IntPtr)SystemCommandFlags.SC_RESTORE)
					{

						if (isMinimized)
						{
							isMinimized = false;
						}
						else
						{
							isMaximized = false;

						}
					}


					base.WndProc(ref m);

					break;
				case (int)WindowsMessages.WM_NCCALCSIZE:
					if (m.WParam != FALSE)
					{
						NCCALCSIZE_PARAMS ncsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

						WINDOWPOS pos = (WINDOWPOS)Marshal.PtrToStructure(ncsize.lppos, typeof(WINDOWPOS));
						if (!isFrameSizeStored)
						{
							isFrameSizeStored = true;
							ncCaptionHeight = ncsize.rectClientBeforeMove.top - ncsize.rectProposed.top; ;

							ncFrameWidth = ncsize.rectClientBeforeMove.left - ncsize.rectProposed.left;

							ncFrameHeight = ncsize.rectBeforeMove.bottom - ncsize.rectClientBeforeMove.bottom;
						}


						RECT rc = ncsize.rectProposed;

						ncsize.rectProposed = CalculateFrameSize(rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);

						//ncsize.rectBeforeMove = ncsize.rectProposed;


						Marshal.StructureToPtr(ncsize, m.LParam, false);
						m.Result = WVR_VALIDRECTS;

						User32.InvalidateWindow(parentWindowHWnd);

					}
					else
					{
						RECT rc = (RECT)m.GetLParam(typeof(RECT));
						rc = CalculateFrameSize(rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
						Marshal.StructureToPtr(rc, m.LParam, true);
						m.Result = MESSAGE_PROCESS;

					}



					base.WndProc(ref m);
					break;

				case (int)WindowsMessages.WM_NCPAINT:
					if (User32.IsWindowVisible(parentWindowHWnd))
					{
						m.Result = MESSAGE_HANDLED;
						DrawNCArea(m.WParam);
					}
					break;
				case (int)WindowsMessages.WM_NCUAHDRAWCAPTION:
				case (int)WindowsMessages.WM_NCUAHDRAWFRAME:
					User32.InvalidateWindow(parentWindowHWnd);
					break;

				default:
					base.WndProc(ref m);
					break;
			}

		}



		private RECT CalculateFrameSize(int x, int y, int cx, int cy)
		{
			RECT windowRect = new RECT(x, y, cx, cy);

			//// subtract original frame size
			windowRect.top -= SystemInformation.CaptionHeight;




			// reset client area

			if (!isMaximized)
			{
				// 特么最大化的时候窗体边框被吃了3个像素，看得老子好纠结。
				windowRect.top -= ncFrameHeight;
				windowRect.bottom += ncFrameHeight;

				windowRect.left -= ncFrameWidth;
				windowRect.right += ncFrameWidth;

				windowRect.left += borderSize;
				windowRect.right -= borderSize;

				windowRect.top += borderSize;
				windowRect.bottom -= borderSize;
			}



			return windowRect;
		}



		private int Win_Height, Win_Width = 0;

		private void DrawNCArea(IntPtr hRgn)
		{
			Region clipRegion = null;
			if (hRgn != TRUE)
				clipRegion = Region.FromHrgn(hRgn);

			RECT windowRect = new RECT();

			RECT clientRect = new RECT();


			User32.GetWindowRect(parentWindowHWnd, ref windowRect);
			User32.OffsetRect(ref windowRect, -windowRect.left, -windowRect.top);

			var height = windowRect.bottom;
			var width = windowRect.right;

			if(Win_Height== height && Win_Width == width)
			{
				return;
			}

			Win_Height = height;
			Win_Width = width;



			User32.GetClientRect(parentWindowHWnd, ref clientRect);
			User32.OffsetRect(ref clientRect, -clientRect.left, -clientRect.top);

			User32.OffsetRect(ref clientRect, borderSize, borderSize);


			IntPtr hDC = User32.GetWindowDC(parentWindowHWnd);



			COLORREF color = new COLORREF(borderColor);



			try
			{
				
				IntPtr hBrush = Gdi32.CreateSolidBrush(color.ColorDWORD);
				Gdi32.ExcludeClipRect(hDC, clientRect.left, clientRect.top, clientRect.right, clientRect.bottom);

				User32.FillRect(hDC, ref windowRect, hBrush);

				//var topRect = new RECT(0, 0, (int)windowRect.Width, borderSize);
				//var bottomRect = new RECT(0, (int)windowRect.Height - borderSize, (int)windowRect.Width, borderSize);
				//var leftRect = new RECT(0, borderSize, borderSize, (int)windowRect.Height - borderSize * 2);
				//var rightRect = new RECT((int)windowRect.Width - borderSize, borderSize, borderSize, (int)windowRect.Height - borderSize * 2);

				//User32.FillRect(hDC, ref topRect, hBrush);
				//User32.FillRect(hDC, ref bottomRect, hBrush);
				//User32.FillRect(hDC, ref leftRect, hBrush);
				//User32.FillRect(hDC, ref rightRect, hBrush);

				Gdi32.DeleteObject(hBrush);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				User32.ReleaseDC(parentWindowHWnd, hDC);
			}




		}

		#region Dispose

		private bool isDisposed;

		/// <summary>
		/// IsDisposed status
		/// </summary>
		public bool IsDisposed
		{
			get { return isDisposed; }
		}

		/// <summary>
		/// Standard Dispose
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose
		/// </summary>
		/// <param name="disposing">True if disposing, false otherwise</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
					// release unmanaged resources
				}

				isDisposed = true;


				this.ReleaseHandle();

				parentWindow = null;
			}
		}

		#endregion

	}
}
