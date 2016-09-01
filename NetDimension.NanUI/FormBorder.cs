using NetDimension.NanUI.Internal;
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
				cp.ExStyle |= NativeMethods.WS_EX_LAYERED | NativeMethods.WS_EX_NOACTIVATE | NativeMethods.WS_EX_TRANSPARENT; // This form has to have the WS_EX_LAYERED extended style
				return cp;
			}
		}



		public FormBorder(Form f)
		{
			Owner = f;

			ShowInTaskbar = false;

			FormBorderStyle = FormBorderStyle.None;

			mutex = new Mutex(false, string.Format("NanUIFormBorder{0}", Process.GetCurrentProcess().Id), out locked);

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
					var rectTop = new Rectangle(20, 0, w, 10);
					var rectBottom = new Rectangle(20, oh + 10, w, 10);
					var rectLeft = new Rectangle(0, 20, 10, h);
					var rectRight = new Rectangle(ow + 10, 20, 10, h);

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

			IntPtr screenDc = NativeMethods.GetDC(IntPtr.Zero);
			IntPtr memDc = NativeMethods.CreateCompatibleDC(screenDc);
			IntPtr hBitmap = IntPtr.Zero;
			IntPtr oldBitmap = IntPtr.Zero;

			try
			{
				hBitmap = bitmap.GetHbitmap(Color.FromArgb(0)); // grab a GDI handle from this GDI+ bitmap
				oldBitmap = NativeMethods.SelectObject(memDc, hBitmap);

				var size = new NativeMethods.Size(bitmap.Width, bitmap.Height);
				var pointSource = new NativeMethods.Point(0, 0);
				var topPos = new NativeMethods.Point(Left, Top);
				var blend = new NativeMethods.BLENDFUNCTION();
				blend.BlendOp = NativeMethods.AC_SRC_OVER;
				blend.BlendFlags = 0;
				blend.SourceConstantAlpha = opacity;
				blend.AlphaFormat = NativeMethods.AC_SRC_ALPHA;

				NativeMethods.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend,
					NativeMethods.ULW_ALPHA);
			}
			finally
			{
				NativeMethods.ReleaseDC(IntPtr.Zero, screenDc);
				if (hBitmap != IntPtr.Zero)
				{
					NativeMethods.SelectObject(memDc, oldBitmap);
					//Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
					NativeMethods.DeleteObject(hBitmap);
				}
				NativeMethods.DeleteDC(memDc);
			}
		}

	}
}
