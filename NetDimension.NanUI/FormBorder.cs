using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI
{


	internal class FormBorder : Form
	{

		internal static class Win32
		{
			public enum Bool
			{
				False = 0,
				True
			};
			public const int WS_EX_LAYERED = 0x80000;
			public const int WS_EX_TRANSPARENT = 0x20;
			public const int WS_EX_NOACTIVATE = 0x08000000;


			public const Int32 ULW_COLORKEY = 0x00000001;
			public const Int32 ULW_ALPHA = 0x00000002;
			public const Int32 ULW_OPAQUE = 0x00000004;

			public const byte AC_SRC_OVER = 0x00;
			public const byte AC_SRC_ALPHA = 0x01;

			[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
			public static extern IntPtr CreateRoundRectRgn
				(
				int nLeftRect, // x-coordinate of upper-left corner
				int nTopRect, // y-coordinate of upper-left corner
				int nRightRect, // x-coordinate of lower-right corner
				int nBottomRect, // y-coordinate of lower-right corner
				int nWidthEllipse, // height of ellipse
				int nHeightEllipse // width of ellipse
				);

			[DllImport("user32.dll", SetLastError = true)]
			public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

			/// <summary>
			///     Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified
			///     offset into the extra window memory.
			/// </summary>
			/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs..</param>
			/// <param name="nIndex">
			///     The zero-based offset to the value to be set. Valid values are in the range zero through the
			///     number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the
			///     following values: GWL_EXSTYLE, GWL_HINSTANCE, GWL_ID, GWL_STYLE, GWL_USERDATA, GWL_WNDPROC
			/// </param>
			/// <param name="dwNewLong">The replacement value.</param>
			/// <returns>
			///     If the function succeeds, the return value is the previous value of the specified 32-bit integer.
			///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
			/// </returns>
			[DllImport("user32.dll")]
			public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


			[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize,
				IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

			[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern IntPtr GetDC(IntPtr hWnd);

			[DllImport("user32.dll", ExactSpelling = true)]
			public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

			[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

			[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern Bool DeleteDC(IntPtr hdc);

			[DllImport("gdi32.dll", ExactSpelling = true)]
			public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

			[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
			public static extern Bool DeleteObject(IntPtr hObject);

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			private struct ARGB
			{
				public readonly byte Blue;
				public readonly byte Green;
				public readonly byte Red;
				public readonly byte Alpha;
			}


			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct BLENDFUNCTION
			{
				public byte BlendOp;
				public byte BlendFlags;
				public byte SourceConstantAlpha;
				public byte AlphaFormat;
			}

			[StructLayout(LayoutKind.Sequential)]
			public struct Point
			{
				public Int32 x;
				public Int32 y;

				public Point(Int32 x, Int32 y)
				{
					this.x = x;
					this.y = y;
				}
			}


			[StructLayout(LayoutKind.Sequential)]
			public struct Size
			{
				public Int32 cx;
				public Int32 cy;

				public Size(Int32 cx, Int32 cy)
				{
					this.cx = cx;
					this.cy = cy;
				}
			}
		}



		const int OffsetX = 10;
		const int OffsetY = 10;


		int watchWidth = 0, watchHeight = 0;

		Mutex mutex;
		bool locked;

		private Queue<Guid> frameSequence = new Queue<Guid>();
		Dictionary<Guid, Bitmap> Animations = new Dictionary<Guid, Bitmap>();

		private bool closeFlag = false;

		private Bitmap _shadowBitmap;

		private Bitmap ShadowBitmap
		{
			get { return _shadowBitmap; }
			set
			{

				if (_shadowBitmap != null)
				{
					mutex.WaitOne();
					_shadowBitmap.Dispose();
					_shadowBitmap = null;
					mutex.ReleaseMutex();
					GC.Collect();
				}

				_shadowBitmap = value;
				SetBitmap(_shadowBitmap);
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= Win32.WS_EX_LAYERED | Win32.WS_EX_NOACTIVATE | Win32.WS_EX_TRANSPARENT; // This form has to have the WS_EX_LAYERED extended style
				return cp;
			}
		}



		public FormBorder(Form f)
		{
			Owner = f;

			ShowInTaskbar = false;

			FormBorderStyle = FormBorderStyle.None;

			mutex = new Mutex(false, string.Format("Splash{0}", Process.GetCurrentProcess().Id), out locked);

			Owner.LocationChanged += UpdateLocation;
			Owner.FormClosing += (sender, eventArgs) =>
			{
				if (!eventArgs.Cancel)
				{

					closeFlag = true;

					mutex.Close();
					mutex.Dispose();
				}
			};
			Owner.VisibleChanged += (sender, eventArgs) =>
			{
				if (Owner != null)
					Visible = Owner.Visible;
			};

			Owner.Activated += (sender, args) => Owner.BringToFront();



		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			Task.Factory.StartNew(() =>
			{
				while (!closeFlag)
				{
					if (frameSequence.Count > 0)
					{
						mutex.WaitOne();
						var gid = frameSequence.Peek();
						mutex.ReleaseMutex();

						if (Animations.ContainsKey(gid) && Animations[gid] != null)
						{

							if (!IsDisposed)
							{
								frameSequence.Dequeue();

								var shadow = Animations[gid].Clone() as Bitmap;

								this.UpdateUI(() =>
								{

									ShadowBitmap = shadow;
								});


							}

							Animations[gid].Dispose();
							mutex.WaitOne();
							Animations.Remove(gid);
							mutex.ReleaseMutex();

						}
					}
					else
					{
						Thread.Sleep(100);
					}


				}
			});
		}
		private void UpdateLocation(object sender = null, EventArgs e = null)
		{
			Point pos = Owner.Location;

			pos.Offset(-OffsetX, -OffsetX);
			Location = pos;


		}



		public void RefreshShadow(int width, int height)
		{

			if (watchHeight == height && watchWidth == width)
			{
				return;
			}
			else
			{
				watchWidth = width;
				watchHeight = height;
			}

			UpdateLocation();

			Task.Factory.StartNew(() =>
			{

				int ow = width;
				int oh = height;

				int w = ow + 20;
				int h = oh + 20;

				var guid = Guid.NewGuid();

				mutex.WaitOne();
				frameSequence.Enqueue(guid);
				Animations.Add(guid, null);
				mutex.ReleaseMutex();

				var bitmap = new Bitmap(w, h);

				using (var g = Graphics.FromImage(bitmap))
				{
					var rectTop = new Rectangle(0, 0, w, 10);
					var rectBottom = new Rectangle(0, oh + 10, w, 10);
					var rectLeft = new Rectangle(0, 0, 10, h);
					var rectRight = new Rectangle(ow + 10, 0, 10, h);

					var rectTopLeft = new Rectangle(0, 0, 20, 20);
					var rectTopRight = new Rectangle(w - 20, 0, 20, 20);
					var rectBottmLeft = new Rectangle(0, h - 20, 20, 20);
					var rectBottomRight = new Rectangle(w - 20, h - 20, 20, 20);

					//g.FillRectangle(Brushes.White, new Rectangle(10, 10, width, height));

					g.ExcludeClip(rectTopLeft);
					g.ExcludeClip(rectTopRight);
					g.ExcludeClip(rectBottmLeft);
					g.ExcludeClip(rectBottomRight);

					g.DrawImage(Properties.Resources.Top, rectTop);
					g.DrawImage(Properties.Resources.Right, rectRight);
					g.DrawImage(Properties.Resources.Bottom, rectBottom);
					g.DrawImage(Properties.Resources.Left, rectLeft);


					g.ResetClip();

					g.DrawImage(Properties.Resources.TopLeft, rectTopLeft);
					g.DrawImage(Properties.Resources.TopRight, rectTopRight);
					g.DrawImage(Properties.Resources.BottomLeft, rectBottmLeft);
					g.DrawImage(Properties.Resources.BottomRight, rectBottomRight);

					mutex.WaitOne();
					Animations[guid] = bitmap;
					mutex.ReleaseMutex();
				}


			});



		}

		public void SetBitmap(Bitmap bitmap, byte opacity = 255)
		{
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
				throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

			// The ideia of this is very simple,
			// 1. Create a compatible DC with screen;
			// 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
			// 3. Call the UpdateLayeredWindow.

			IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
			IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
			IntPtr hBitmap = IntPtr.Zero;
			IntPtr oldBitmap = IntPtr.Zero;

			try
			{
				hBitmap = bitmap.GetHbitmap(Color.FromArgb(0)); // grab a GDI handle from this GDI+ bitmap
				oldBitmap = Win32.SelectObject(memDc, hBitmap);

				var size = new Win32.Size(bitmap.Width, bitmap.Height);
				var pointSource = new Win32.Point(0, 0);
				var topPos = new Win32.Point(Left, Top);
				var blend = new Win32.BLENDFUNCTION();
				blend.BlendOp = Win32.AC_SRC_OVER;
				blend.BlendFlags = 0;
				blend.SourceConstantAlpha = opacity;
				blend.AlphaFormat = Win32.AC_SRC_ALPHA;

				Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend,
					Win32.ULW_ALPHA);
			}
			finally
			{
				Win32.ReleaseDC(IntPtr.Zero, screenDc);
				if (hBitmap != IntPtr.Zero)
				{
					Win32.SelectObject(memDc, oldBitmap);
					//Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
					Win32.DeleteObject(hBitmap);
				}
				Win32.DeleteDC(memDc);
			}
		}

	}
}
