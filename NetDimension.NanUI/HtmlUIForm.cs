using NetDimension.NanUI.ChromiumCore;
using NetDimension.NanUI.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	using Chromium;
	using Chromium.Event;
	using Chromium.Remote;
	using Chromium.Remote.Event;
	using NetDimension.NanUI.Internal.Imports;
	using Resource;
	using System.Diagnostics;
	using System.Drawing;
	using System.Threading.Tasks;
	public class HtmlUIForm : BorderlessForm, IChromiumWebBrowser
	{


		private bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode || Process.GetCurrentProcess().ProcessName == "devenv";


		private bool isFormResizing = false;



		private PictureBox splashPicture;
		private BrowserWidgetMessageInterceptor messageInterceptor;
		private ChromiumBrowser browser;
		protected IntPtr FormHandle { get; private set; }
		protected IntPtr BrowserHandle { get; private set; }

		private Region draggableRegion = null;

		private bool isSplashShown = true;
		private bool isFirstTimeSplashShown = true;
		private bool isResizable = true;
		private bool isEnableDropShadow = true;

		float scaleFactor = 1.0f;

		private string initialUrl;
		private int CornerAreaSize
		{
			get
			{
				return (int)Math.Round((BorderSize < 3 ? 3 : BorderSize) / scaleFactor);
			}
		}


		/// <summary>
		/// 设置或获取NanUI在Nonclient模式下是否显示投影
		/// </summary>
		[Category("NanUI")]
		public bool EnableDropShadow
		{
			get
			{
				return isEnableDropShadow;
			}
			set
			{
				isEnableDropShadow = value;
				if (!IsDesignMode)
				{
					FormShadowDecorator.Enable(value);
				}
			}
		}


		/// <summary>
		/// 设置或获取NanUI窗口加载等待画面使用的图片
		/// </summary>
		[Category("NanUI")]
		public Image SplashImage
		{
			get
			{
				return splashPicture.BackgroundImage;
			}
			set
			{
				splashPicture.BackgroundImage = value;
			}
		}
		/// <summary>
		/// 设置或获取NanUI窗口加载等待画面图片布局方式
		/// </summary>
		[Category("NanUI")]
		public ImageLayout SplashImageLayout
		{
			get
			{
				return splashPicture.BackgroundImageLayout;
			}
			set
			{
				splashPicture.BackgroundImageLayout = value;
			}
		}


		/// <summary>
		/// 设置或获取NanUI窗口加载等待画面背景颜色
		/// </summary>
		[Category("NanUI")]
		public Color SplashBackColor
		{
			get
			{
				return splashPicture.BackColor;
			}
			set
			{
				splashPicture.BackColor = value;
			}
		}

		public override Color BackColor
		{
			get;
			set;
		} = Color.White;


		/// <summary>
		/// 设置或获取NanUI窗口是否可以拖动大小
		/// </summary>
		[Category("NanUI")]
		public bool Resizable
		{
			get
			{
				return isResizable;
			}
			set
			{
				isResizable = value;
				//if (!IsDesignMode)
				//{
				//	FormShadowDecorator.EnableResize(value);
				//}
			}
		}

		int borderSize = 1;
		/// <summary>
		/// 设置或获取NanUI窗口边框线条粗细
		/// </summary>
		[Category("NanUI")]
		public int BorderSize
		{
			get
			{
				return borderSize;
			}
			set
			{
				borderSize = value;
				if (!IsDesignMode)
				{
					FormNonclientAreaDecorator.BorderSize = borderSize;
				}
			}
		}


		Color borderColor = Color.Gray;

		/// <summary>
		/// 设置或获取NanUI窗口边框颜色
		/// </summary>
		[Category("NanUI")]
		public Color BorderColor
		{
			get
			{
				return borderColor;
			}
			set
			{
				borderColor = value;
				if (!IsDesignMode)
				{
					FormNonclientAreaDecorator.BorderColor = borderColor;
				}

			}
		}




		public HtmlUIForm() : this(null)
		{

		}

		public HtmlUIForm(string initialUrl)
		{
			this.initialUrl = initialUrl;



			splashPicture = new PictureBox()
			{
				Dock = DockStyle.Fill,
				BackColor = Color.Transparent
			};


			if (!IsDesignMode)
			{
				SetStyle(ControlStyles.ResizeRedraw, true);
				SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);

				DoubleBuffered = true;

				UpdateStyles();


				FormNonclientAreaDecorator.BorderSize = borderSize;
				FormNonclientAreaDecorator.BorderColor = borderColor;

				

				scaleFactor = 1.0f / User32.GetOriginalDeviceScaleFactor(FormHandle);
				//FormShadowDecorator.EnableResize(isResizable);

				this.Controls.Add(splashPicture);
				splashPicture.BringToFront();

				//FormShadowDecorator.Enable(false);

				InitializeChromium(initialUrl);
			}



		}
		protected void InitializeChromium(string initialUrl)
		{
			if (string.IsNullOrEmpty(initialUrl))
			{
				this.browser = new ChromiumBrowser();
			}
			else
			{
				this.browser = new ChromiumBrowser(initialUrl);
			}
			this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browser.RemoteCallbackInvokeMode = JSInvokeMode.Inherit;
			this.Controls.Add(this.browser);

			BrowserHandle = browser.Handle;


			browser.BrowserCreated += (sender, args) =>
			{
				AttachInterceptorToChromiumBrowser();
			};


			LifeSpanHandler.OnBeforePopup += (sender, args) =>
			{

			};

			KeyboardHandler.OnPreKeyEvent += (sender, args) =>
			{
				if (args.Event.IsSystemKey)
					args.SetReturnValue(true);
			};



			DragHandler.OnDraggableRegionsChanged += (sender, args) =>
			{
				var regions = args.Regions;



				if (regions.Length > 0)
				{
					foreach (var region in regions)
					{
						var rect = new Rectangle(region.Bounds.X, region.Bounds.Y, region.Bounds.Width, region.Bounds.Height);


						if (draggableRegion == null)
						{
							draggableRegion = new Region(rect);
						}
						else
						{
							if (region.Draggable)
							{
								draggableRegion.Union(rect);
							}
							else
							{
								draggableRegion.Exclude(rect);
							}
						}
					}
				}

			};

			DragHandler.OnDragEnter += (s, e) =>
			{

				// 禁止往窗口上拖东西
				e.SetReturnValue(true);
			};

			LoadHandler.OnLoadEnd += (sender, args) =>
			{
				HideInitialSplash();
			};

			LoadHandler.OnLoadError += (sender, args) =>
			{
				HideInitialSplash();
			};


			GlobalObject.Add("NanUI", new JsHostWindowObject(this));


		}

		#region Private
		private void AttachInterceptorToChromiumBrowser()
		{
			Task.Factory.StartNew(() =>
			{
				try
				{
					while (true)
					{
						IntPtr chromeWidgetHostHandle = IntPtr.Zero;
						if (BrowserWidgetHandleFinder.TryFindHandle(BrowserHandle, out chromeWidgetHostHandle))
						{
							messageInterceptor = new BrowserWidgetMessageInterceptor(browser, chromeWidgetHostHandle, OnWebBroswerMessage);
							break;
						}
						else
						{
							System.Threading.Thread.Sleep(100);
						}
					}
				}
				catch
				{

				}
			});
		}
		private void HideInitialSplash()
		{
			if (isFirstTimeSplashShown && isSplashShown)
			{

				HideSplash();

				isFirstTimeSplashShown = false;
				isSplashShown = false;
			}
		}
		#endregion

		#region Protected
		protected virtual bool OnWebBroswerMessage(Message message)
		{

			if (message.Msg == (int)WindowsMessages.WM_MOUSEACTIVATE)
			{
				var topLevelWindowHandle = message.WParam;
				User32.PostMessage(topLevelWindowHandle, (int)WindowsMessages.WM_SETFOCUS, IntPtr.Zero, IntPtr.Zero);
				User32.PostMessage(topLevelWindowHandle, (int)WindowsMessages.WM_NCLBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
			}


			if (message.Msg == (int)WindowsMessages.WM_LBUTTONDOWN)
			{

				var x = (int)User32.LoWord(message.LParam);
				var y = (int)User32.HiWord(message.LParam);

				var sx = (int)((int)User32.LoWord(message.LParam) * scaleFactor);
				var sy = (int)((int)User32.HiWord(message.LParam) * scaleFactor);

				var ax = x;
				var ay = y;

				if (scaleFactor != 1.0f)
				{
					ax = sx;
					ay = sy;
				}


				var dragable = (draggableRegion != null && draggableRegion.IsVisible(new Point(sx, sy)));

				var dir = GetSizeMode(new POINT(x, y));

				if (dir != HitTest.HTCLIENT/* && BorderSize == 0*/)
				{
					User32.PostMessage(FormHandle, (uint)DefMessages.WM_CEF_RESIZE_CLIENT, (IntPtr)dir, message.LParam);
					return true;
				}
				else if (dragable)
				{
					User32.PostMessage(FormHandle, (uint)DefMessages.WM_CEF_DRAG_APP, message.WParam, message.LParam);
					return true;
				}


			}

			if (message.Msg == (int)WindowsMessages.WM_LBUTTONDBLCLK && Resizable)
			{
				var x = (int)User32.LoWord(message.LParam);
				var y = (int)User32.HiWord(message.LParam);

				var sx = (int)((int)User32.LoWord(message.LParam) * scaleFactor);
				var sy = (int)((int)User32.HiWord(message.LParam) * scaleFactor);

				var ax = x;
				var ay = y;

				if (scaleFactor != 1.0f)
				{
					ax = sx;
					ay = sy;
				}


				var dragable = (draggableRegion != null && draggableRegion.IsVisible(new Point(sx, sy)));

				if (dragable)
				{
					User32.PostMessage(FormHandle, (uint)DefMessages.WM_CEF_TITLEBAR_LBUTTONDBCLICK, message.WParam, message.LParam);

					return true;
				}

			}

			if (message.Msg == (int)WindowsMessages.WM_MOUSEMOVE/* &&  BorderSize == 0*/)
			{

				var x = (int)User32.LoWord(message.LParam);
				var y = (int)User32.HiWord(message.LParam);

				var sx = (int)((int)User32.LoWord(message.LParam) * scaleFactor);
				var sy = (int)((int)User32.HiWord(message.LParam) * scaleFactor);

				var ax = x;
				var ay = y;

				if (scaleFactor != 1.0f)
				{
					ax = sx;
					ay = sy;
				}


				var dragable = (draggableRegion != null && draggableRegion.IsVisible(new Point(sx, sy)));

				//Debug.WriteLine($"x:{x}\ty:{y}\t|\tax:{ax}\tay:{ay}");


				if (Resizable)
				{
					var dir = GetSizeMode(new POINT(x, y));


					if (dir != HitTest.HTCLIENT)
					{
						User32.PostMessage(FormHandle, (uint)DefMessages.WM_CEF_EDGE_MOVE, (IntPtr)dir, message.LParam);
						return true;
					}

				}

				//User32.SendMessage(FormHandle, (uint)WindowsMessages.WM_MOUSEMOVE, message.WParam, message.LParam);

			}


			return false;

		}

		private HitTest GetSizeMode(POINT point)
		{
			HitTest mode = HitTest.HTCLIENT;

			int x = point.x, y = point.y;

			if (WindowState == FormWindowState.Normal)
			{
				if (x < CornerAreaSize & y < CornerAreaSize)
				{
					mode = HitTest.HTTOPLEFT;
				}
				else if (x < CornerAreaSize & y + CornerAreaSize > this.Height - CornerAreaSize)
				{
					mode = HitTest.HTBOTTOMLEFT;

				}
				else if (x + CornerAreaSize > this.Width - CornerAreaSize & y + CornerAreaSize > this.Height - CornerAreaSize)
				{
					mode = HitTest.HTBOTTOMRIGHT;

				}
				else if (x + CornerAreaSize > this.Width - CornerAreaSize & y < CornerAreaSize)
				{
					mode = HitTest.HTTOPRIGHT;

				}
				else if (x < CornerAreaSize)
				{
					mode = HitTest.HTLEFT;

				}
				else if (x + CornerAreaSize > this.Width - CornerAreaSize)
				{
					mode = HitTest.HTRIGHT;

				}
				else if (y < CornerAreaSize)
				{
					mode = HitTest.HTTOP;

				}
				else if (y + CornerAreaSize > this.Height - CornerAreaSize)
				{
					mode = HitTest.HTBOTTOM;

				}

			}


			return mode;
		}

		private void SetCursor(HitTest mode)
		{


			IntPtr handle = IntPtr.Zero;

			switch (mode)
			{
				case HitTest.HTTOP:
				case HitTest.HTBOTTOM:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENS);
					break;
				case HitTest.HTLEFT:
				case HitTest.HTRIGHT:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZEWE);
					break;
				case HitTest.HTTOPLEFT:
				case HitTest.HTBOTTOMRIGHT:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENWSE);
					break;
				case HitTest.HTTOPRIGHT:
				case HitTest.HTBOTTOMLEFT:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENESW);
					break;
			}

			if (handle != IntPtr.Zero)
			{
				User32.SetCursor(handle);
			}
		}
		public virtual void ShowDevTools()
		{
			CfxWindowInfo windowInfo = new CfxWindowInfo();

			windowInfo.Style = WindowStyle.WS_OVERLAPPEDWINDOW | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_VISIBLE & ~WindowStyle.WS_CAPTION;
			windowInfo.ParentWindow = IntPtr.Zero;
			windowInfo.WindowName = "Dev Tools";
			windowInfo.X = 200;
			windowInfo.Y = 200;
			windowInfo.Width = 720;
			windowInfo.Height = 480;

			browser.BrowserHost.ShowDevTools(windowInfo, new CfxClient(), new CfxBrowserSettings(), null);
		}

		#endregion

		#region Public
		public void ShowAboutNanUI()
		{

			this.UpdateUI(() =>
			{
				var about = new AboutForm();

				about.ShowDialog(this);
			});


		}
		public virtual void HideSplash()
		{
			this.UpdateUI(() =>
			{
				splashPicture.Hide();
				splashPicture.SendToBack();
			});
		}
		#endregion

		#region Override
		protected override void OnHandleCreated(EventArgs e)
		{
			FormHandle = this.Handle;
			base.OnHandleCreated(e);
		}

		//protected override void OnMouseDown(MouseEventArgs e)
		//{
		//	base.OnMouseDown(e);

		//	if (Resizable && ResizeDirection != HitTest.HTNOWHERE)
		//	{
		//		User32.SendMessage(Handle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)ResizeDirection, (IntPtr)0);
		//		User32.InvalidateWindow(Handle);
		//	}
		//}
		protected override void OnClosed(EventArgs e)
		{
			messageInterceptor?.ReleaseHandle();
			messageInterceptor?.DestroyHandle();
			messageInterceptor = null;


			browser.Dispose();

			base.OnClosed(e);
		}



		protected override void WndProc(ref Message m)
		{
			if (!IsDesignMode)
			{

				switch (m.Msg)
				{
					case (int)WindowsMessages.WM_SHOWWINDOW:
						{


							if (StartPosition == FormStartPosition.CenterParent && Owner != null)
							{
								Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
								Owner.Location.Y + Owner.Height / 2 - Height / 2);


							}
							else if (StartPosition == FormStartPosition.CenterScreen || (StartPosition == FormStartPosition.CenterParent && Owner == null))
							{
								var currentScreen = Screen.FromHandle(this.Handle);
								Location = new Point(currentScreen.WorkingArea.Left + (currentScreen.WorkingArea.Width / 2 - this.Width / 2), currentScreen.WorkingArea.Top + (currentScreen.WorkingArea.Height / 2 - this.Height / 2));

							}

							Activate();
							BringToFront();

							base.WndProc(ref m);
						}
						break;
					case (int)WindowsMessages.WM_MOVE:
						{

							browser?.BrowserHost?.NotifyScreenInfoChanged();


							base.WndProc(ref m);
						}
						break;
					case (int)WindowsMessages.WM_SIZE:
						{
							var x = (int)User32.LoWord(m.LParam);
							var y = (int)User32.HiWord(m.LParam);
							if (browser != null && browser.IsHandleCreated)
							{
								var js = string.Format(JsHostWindowObject.JS_WINDOW_STATE_CHANGED, m.WParam, x, y);
								browser.ExecuteJavascript(js);

							}
								
						}
						break;
					default:
						{
							base.WndProc(ref m);
						}
						break;
				}

			}
			else
			{
				base.WndProc(ref m);
			}



		}


		protected override void DefWndProc(ref Message m)
		{
			if (m.Msg == (int)DefMessages.WM_CEF_TITLEBAR_LBUTTONDBCLICK)
			{
				User32.ReleaseCapture();

				if (WindowState == FormWindowState.Maximized)
				{
					User32.SendMessage(FormHandle, (uint)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_RESTORE, IntPtr.Zero);
				}
				else
				{
					User32.SendMessage(FormHandle, (uint)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_MAXIMIZE, IntPtr.Zero);
				}


			}

			if (m.Msg == (int)DefMessages.WM_CEF_DRAG_APP && !(FormBorderStyle == FormBorderStyle.None && WindowState == FormWindowState.Maximized))
			{
				User32.ReleaseCapture();
				User32.SendMessage(Handle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)HitTest.HTCAPTION, (IntPtr)0);
			}
			if (m.Msg == (int)DefMessages.WM_CEF_RESIZE_CLIENT && Resizable && WindowState == FormWindowState.Normal)
			{
				User32.ReleaseCapture();
				isFormResizing = true;


				User32.SendMessage(Handle, (int)WindowsMessages.WM_NCLBUTTONDOWN, m.WParam, (IntPtr)0);

				isFormResizing = false;
			}

			if (m.Msg == (int)DefMessages.WM_CEF_EDGE_MOVE && Resizable && WindowState == FormWindowState.Normal)
			{
				SetCursor((HitTest)m.WParam.ToInt32());
			}


			base.DefWndProc(ref m);
		}
		#endregion

		#region IChromiumBrowser
		[Browsable(false)]
		public bool RemoteCallbacksWillInvoke
		{
			get
			{
				return ((IChromiumWebBrowser)browser).RemoteCallbacksWillInvoke;
			}
		}
		[Browsable(false)]
		public CfrBrowser RemoteBrowser
		{
			get
			{
				return ((IChromiumWebBrowser)browser).RemoteBrowser;
			}
		}
		[Browsable(false)]
		public RenderProcess RemoteProcess
		{
			get
			{
				return ((IChromiumWebBrowser)browser).RemoteProcess;
			}
		}
		[Browsable(false)]
		public Dictionary<string, WebResource> WebResources
		{
			get
			{
				return ((IChromiumWebBrowser)browser).WebResources;
			}
		}
		[Browsable(false)]
		public Dictionary<string, JSObject> FrameGlobalObjects
		{
			get
			{
				return ((IChromiumWebBrowser)browser).FrameGlobalObjects;
			}
		}
		[Browsable(false)]
		public JSObject GlobalObject
		{
			get
			{
				return ((IChromiumWebBrowser)browser).GlobalObject;
			}
		}
		[Browsable(false)]
		public CfxContextMenuHandler ContextMenuHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).ContextMenuHandler;
			}
		}
		[Browsable(false)]
		public CfxLifeSpanHandler LifeSpanHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).LifeSpanHandler;
			}
		}
		[Browsable(false)]
		public CfxLoadHandler LoadHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).LoadHandler;
			}
		}
		[Browsable(false)]
		public CfxRequestHandler RequestHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).RequestHandler;
			}
		}
		[Browsable(false)]
		public CfxDisplayHandler DisplayHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).DisplayHandler;
			}
		}
		[Browsable(false)]
		public CfxDownloadHandler DownloadHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).DownloadHandler;
			}
		}
		[Browsable(false)]
		public CfxDragHandler DragHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).DragHandler;
			}
		}
		[Browsable(false)]
		public CfxDialogHandler DialogHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).DialogHandler;
			}
		}
		[Browsable(false)]
		public CfxFindHandler FindHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).FindHandler;
			}
		}
		[Browsable(false)]
		public CfxFocusHandler FocusHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).FocusHandler;
			}
		}
		[Browsable(false)]
		public CfxGeolocationHandler GeolocationHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).GeolocationHandler;
			}
		}
		[Browsable(false)]
		public CfxJsDialogHandler JsDialogHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).JsDialogHandler;
			}
		}
		[Browsable(false)]
		public CfxKeyboardHandler KeyboardHandler
		{
			get
			{
				return ((IChromiumWebBrowser)browser).KeyboardHandler;
			}
		}
		[Browsable(false)]
		public Uri Url
		{
			get
			{
				return ((IChromiumWebBrowser)browser).Url;
			}
		}
		[Browsable(false)]
		public bool IsLoading
		{
			get
			{
				return ((IChromiumWebBrowser)browser).IsLoading;
			}
		}
		[Browsable(false)]
		public bool CanGoBack
		{
			get
			{
				return ((IChromiumWebBrowser)browser).CanGoBack;
			}
		}
		[Browsable(false)]
		public bool CanGoForward
		{
			get
			{
				return ((IChromiumWebBrowser)browser).CanGoForward;
			}
		}

		public object RenderThreadInvoke(Delegate method, params object[] args)
		{
			return ((IChromiumWebBrowser)browser).RenderThreadInvoke(method, args);
		}

		public void RenderThreadInvoke(MethodInvoker method)
		{
			((IChromiumWebBrowser)browser).RenderThreadInvoke(method);
		}

		public void CreateBrowser(CfxRequestContext requestContext)
		{
			((IChromiumWebBrowser)browser).CreateBrowser(requestContext);
		}

		public void SetRemoteBrowser(CfrBrowser remoteBrowser, RenderProcess remoteProcess)
		{
			((IChromiumWebBrowser)browser).SetRemoteBrowser(remoteBrowser, remoteProcess);
		}

		public void GoBack()
		{
			((IChromiumWebBrowser)browser).GoBack();
		}

		public void GoForward()
		{
			((IChromiumWebBrowser)browser).GoForward();
		}

		public void LoadUrl(string url)
		{
			((IChromiumWebBrowser)browser).LoadUrl(url);
		}

		public void LoadString(string stringVal, string url)
		{
			((IChromiumWebBrowser)browser).LoadString(stringVal, url);
		}

		public void LoadString(string stringVal)
		{
			((IChromiumWebBrowser)browser).LoadString(stringVal);
		}

		public int Find(string searchText, bool forward, bool matchCase)
		{
			return ((IChromiumWebBrowser)browser).Find(searchText, forward, matchCase);
		}

		public void RaiseOnV8ContextCreated(CfrOnContextCreatedEventArgs e)
		{
			((IChromiumWebBrowser)browser).RaiseOnV8ContextCreated(e);
		}

		public bool ExecuteJavascript(string code)
		{
			return ((IChromiumWebBrowser)browser).ExecuteJavascript(code);
		}


		public bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback)
		{
			return EvaluateJavascript(code, JSInvokeMode.Inherit, callback);
		}


		public bool EvaluateJavascript(string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback)
		{

			return ((IChromiumWebBrowser)browser).EvaluateJavascript(code, invokeMode, callback);
		}

		public void SetWebResource(string url, WebResource resource)
		{
			((IChromiumWebBrowser)browser).SetWebResource(url, resource);
		}

		public void RemoveWebResource(string url)
		{
			((IChromiumWebBrowser)browser).RemoveWebResource(url);
		}

		public void OnBrowserCreated(CfxOnAfterCreatedEventArgs e)
		{
			((IChromiumWebBrowser)browser).OnBrowserCreated(e);
		}

		public void RemoteProcessExited(RenderProcess process)
		{
			((IChromiumWebBrowser)browser).RemoteProcessExited(process);
		}




		#endregion

	}
}
