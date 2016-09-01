using Chromium;
using NetDimension.NanUI.Internal;
using NetDimension.NanUI.Resource;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public class HtmlWidgetForm : Form
	{
		internal CfxBrowser browser;

		private CfxClient client;
		private CfxLifeSpanHandler lifeSpanHandler;
		private CfxLoadHandler loadHandler;
		private CfxRenderHandler renderHandler;


		private Mutex mutex;
		private bool locked;

		private Queue<Guid> frameSequence = new Queue<Guid>();
		private Dictionary<Guid, Bitmap> Animations = new Dictionary<Guid, Bitmap>();
		internal readonly Dictionary<string, WebResource> webResources = new Dictionary<string, WebResource>();
		public Dictionary<string, WebResource> WebResources
		{
			get
			{
				return webResources;
			}
		}

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

		private void SetBitmap(Bitmap bitmap, byte opacity = 255)
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


		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= NativeMethods.WS_EX_LAYERED; /*| NativeMethods.WS_EX_NOACTIVATE | NativeMethods.WS_EX_TRANSPARENT; // This form has to have the WS_EX_LAYERED extended style*/
				return cp;
			}
		}

		public void SetWebResource(string url, WebResource resource)
		{
			webResources[url] = resource;
		}

		/// <summary>
		/// Remove a resource previously set for the specified URL.
		/// </summary>
		/// <param name="url"></param>
		public void RemoveWebResource(string url)
		{
			webResources.Remove(url);
		}



		public HtmlWidgetForm(string initialUrl)
		{
			FormBorderStyle = FormBorderStyle.None;

			mutex = new Mutex(false, string.Format("NanUIWidget{0}", Process.GetCurrentProcess().Id), out locked);


			lifeSpanHandler = new CfxLifeSpanHandler();
			lifeSpanHandler.OnAfterCreated += lifeSpanHandler_OnAfterCreated;

			renderHandler = new CfxRenderHandler();

			renderHandler.GetRootScreenRect += renderHandler_GetRootScreenRect;
			renderHandler.GetScreenInfo += renderHandler_GetScreenInfo;
			renderHandler.GetScreenPoint += renderHandler_GetScreenPoint;
			renderHandler.GetViewRect += renderHandler_GetViewRect;
			renderHandler.OnCursorChange += renderHandler_OnCursorChange;
			renderHandler.OnPaint += renderHandler_OnPaint;

			//renderHandler.OnPopupShow += renderHandler_OnPopupShow;
			//renderHandler.OnPopupSize += renderHandler_OnPopupSize;
			//renderHandler.OnScrollOffsetChanged += renderHandler_OnScrollOffsetChanged;
			//renderHandler.StartDragging += renderHandler_StartDragging;
			//renderHandler.UpdateDragCursor += renderHandler_UpdateDragCursor;

			loadHandler = new CfxLoadHandler();

			loadHandler.OnLoadError += loadHandler_OnLoadError;

			client = new CfxClient();
			client.GetLifeSpanHandler += (sender, e) => e.SetReturnValue(lifeSpanHandler);
			client.GetRenderHandler += (sender, e) => e.SetReturnValue(renderHandler);
			client.GetLoadHandler += (sender, e) => e.SetReturnValue(loadHandler);

			var settings = new CfxBrowserSettings();

			var windowInfo = new CfxWindowInfo();
			windowInfo.SetAsWindowless(false);
			windowInfo.TransparentPaintingEnabled = true;

			CreateHandle();

			CfxBrowserHost.CreateBrowser(windowInfo, client, initialUrl, settings, null);
		}

		void loadHandler_OnLoadError(object sender, Chromium.Event.CfxOnLoadErrorEventArgs e)
		{
			if (e.ErrorCode == CfxErrorCode.Aborted)
			{
				// this seems to happen when calling LoadUrl and the browser is not yet ready
				var url = e.FailedUrl;
				var frame = e.Frame;
				System.Threading.ThreadPool.QueueUserWorkItem((state) =>
				{
					System.Threading.Thread.Sleep(200);
					frame.LoadUrl(url);
				});
			}
		}

		void renderHandler_UpdateDragCursor(object sender, Chromium.Event.CfxUpdateDragCursorEventArgs e)
		{
			throw new NotImplementedException();
		}

		void renderHandler_StartDragging(object sender, Chromium.Event.CfxStartDraggingEventArgs e)
		{
			throw new NotImplementedException();
		}

		void renderHandler_OnScrollOffsetChanged(object sender, Chromium.Event.CfxOnScrollOffsetChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		void renderHandler_OnPopupSize(object sender, Chromium.Event.CfxOnPopupSizeEventArgs e)
		{
			throw new NotImplementedException();
		}

		void renderHandler_OnPopupShow(object sender, Chromium.Event.CfxOnPopupShowEventArgs e)
		{
			throw new NotImplementedException();
		}

		void renderHandler_OnPaint(object sender, Chromium.Event.CfxOnPaintEventArgs e)
		{
			Console.WriteLine($"[{DateTime.Now}] PAINT_CALLED");

			//lock (pbLock)
			//{
			//	if (pixelBuffer == null || pixelBuffer.Width < e.Width || pixelBuffer.Height < e.Height)
			//	{
			//		pixelBuffer = new Bitmap(e.Width, e.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			//	}
			//	using (var bm = new Bitmap(e.Width, e.Height, e.Width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, e.Buffer))
			//	{
			//		using (var g = Graphics.FromImage(pixelBuffer))
			//		{
			//			g.DrawImageUnscaled(bm, 0, 0);
			//		}
			//	}
			//}
			//foreach (var r in e.DirtyRects)
			//{
			//	Invalidate(new Rectangle(r.X, r.Y, r.Width, r.Height));
			//}
			var w = e.Width;
			var h = e.Height;

			var guid = Guid.NewGuid();

			mutex.WaitOne();
			frameSequence.Enqueue(guid);
			Animations.Add(guid, null);
			mutex.ReleaseMutex();

			var bitmap = new Bitmap(w, h);

			using (var bm = new Bitmap(w, h, w * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, e.Buffer))
			{
				using (var g = Graphics.FromImage(bitmap))
				{
					g.DrawImageUnscaled(bm, 0, 0);
					mutex.WaitOne();
					Animations[guid] = bitmap;
					mutex.ReleaseMutex();
				}
			}
		}

		void renderHandler_OnCursorChange(object sender, Chromium.Event.CfxOnCursorChangeEventArgs e)
		{
			switch (e.Type)
			{
				case CfxCursorType.Hand:
					Cursor = Cursors.Hand;
					break;
				default:
					Cursor = Cursors.Default;
					break;
			}
		}

		void renderHandler_GetViewRect(object sender, Chromium.Event.CfxGetViewRectEventArgs e)
		{

			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() => renderHandler_GetViewRect(sender, e)));
				return;
			}

			if (!IsDisposed)
			{
				var origin = PointToScreen(new Point(0, 0));
				e.Rect.X = origin.X;
				e.Rect.Y = origin.Y;
				e.Rect.Width = Width;
				e.Rect.Height = Height;
				e.SetReturnValue(true);
			}
		}

		void renderHandler_GetScreenPoint(object sender, Chromium.Event.CfxGetScreenPointEventArgs e)
		{

			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() => renderHandler_GetScreenPoint(sender, e)));
				return;
			}

			if (!IsDisposed)
			{
				var origin = PointToScreen(new Point(e.ViewX, e.ViewY));
				e.ScreenX = origin.X;
				e.ScreenY = origin.Y;
				e.SetReturnValue(true);
			}
		}

		void renderHandler_GetScreenInfo(object sender, Chromium.Event.CfxGetScreenInfoEventArgs e)
		{
		}

		void renderHandler_GetRootScreenRect(object sender, Chromium.Event.CfxGetRootScreenRectEventArgs e)
		{
		}


		void lifeSpanHandler_OnAfterCreated(object sender, Chromium.Event.CfxOnAfterCreatedEventArgs e)
		{
			browser = e.Browser;
			//browser.MainFrame.LoadUrl("http://www.baidu.com/");
			if (Focused)
			{
				browser.Host.SendFocusEvent(true);
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			if (browser != null)
			{
				browser.Host.SendFocusEvent(true);
			}
		}

		// control overrides

		protected override void OnResize(EventArgs e)
		{
			if (browser != null)
			{
				browser.Host.WasResized();
			}
		}

		//protected override void OnPaintBackground(PaintEventArgs pevent)
		//{
		//	// do nothing
		//}

		//protected override void OnPaint(PaintEventArgs e)
		//{
		//	//lock (pbLock)
		//	//{
		//	//	if (pixelBuffer != null)
		//	//		e.Graphics.DrawImage(pixelBuffer, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
		//	//}
		//}

		// mouse events
		// this is not complete

		private readonly CfxMouseEvent mouseEventProxy = new CfxMouseEvent();

		private void SetMouseEvent(MouseEventArgs e)
		{
			mouseEventProxy.X = e.X;
			mouseEventProxy.Y = e.Y;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (browser != null)
			{
				SetMouseEvent(e);
				browser.Host.SendMouseMoveEvent(mouseEventProxy, false);
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (browser != null)
			{
				browser.Host.SendMouseMoveEvent(mouseEventProxy, true);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (browser != null)
			{
				SetMouseEvent(e);
				CfxMouseButtonType t;
				switch (e.Button)
				{
					case System.Windows.Forms.MouseButtons.Right:
						t = CfxMouseButtonType.Left;
						break;
					case System.Windows.Forms.MouseButtons.Middle:
						t = CfxMouseButtonType.Middle;
						break;
					default:
						t = CfxMouseButtonType.Left;
						break;
				}
				browser.Host.SendFocusEvent(true);
				browser.Host.SendMouseClickEvent(mouseEventProxy, t, false, e.Clicks);
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (browser != null)
			{
				SetMouseEvent(e);
				CfxMouseButtonType t;
				switch (e.Button)
				{
					case System.Windows.Forms.MouseButtons.Right:
						t = CfxMouseButtonType.Left;
						break;
					case System.Windows.Forms.MouseButtons.Middle:
						t = CfxMouseButtonType.Middle;
						break;
					default:
						t = CfxMouseButtonType.Left;
						break;
				}
				browser.Host.SendMouseClickEvent(mouseEventProxy, t, true, e.Clicks);
			}
		}

		// key events
		// this is not complete

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			var k = new CfxKeyEvent();
			k.WindowsKeyCode = e.KeyChar;
			k.Type = CfxKeyEventType.Char;
			browser.Host.SendKeyEvent(k);
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

	}
}
