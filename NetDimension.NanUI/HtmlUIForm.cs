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
	using Resource;
	using System.Drawing;
	using System.Threading.Tasks;
	public class HtmlUIForm : Form, IChromiumWebBrowser
	{
		private const int BORDER_WIDTH = 6;

		NonclientNativeWindow nativeForm;
		private Padding? fullClientModePadding = null;

		private readonly int BORDER_X;
		private readonly int BORDER_Y;
		private readonly Padding maxPadding;

		private Size? windowOriginalSize = null;

		private readonly bool IsWindowsXP, ForceNonclientMode;

		private bool dwmMarginHandled;

		private bool isFormResizing = false;


		private NativeMethods.MARGINS dwmMargins;

		/// <summary>
		/// NanUI窗口状态变化时，发送JS事件通知网页端
		/// </summary>
		private const string JS_WINDOW_STATE_CHANGED = "(function(){{var event = new CustomEvent('windowstatechanged',{{'detail':{{ state: {0}, width:{1}, height:{2}}}}}); window.dispatchEvent(event);}})();";

		private PictureBox splashPicture;
		private BrowserWidgetMessageInterceptor messageInterceptor;
		private ChromiumBrowser browser;
		protected IntPtr FormHandle { get; private set; }
		protected IntPtr BrowserHandle { get; private set; }

		private Region draggableRegion = null;

		private bool isSplashShown = true;
		private bool isFirstTimeSplashShown = true;

		private string initialUrl;


		protected ResizeDirection ResizeDirection
		{
			get;
			set;
		} = ResizeDirection.None;

		protected int ResizeDirectionState
		{
			get;
			set;
		} = 0;

		protected readonly bool IsDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
		/// <summary>
		/// 设置或获取NanUI在Nonclient模式下是否显示投影
		/// </summary>
		[Category("NanUI")]
		public bool NonclientModeDropShadow
		{
			get; set;
		} = true;

		/// <summary>
		/// 设置或获取NanUI是否为无边窗口
		/// </summary>
		[Category("NanUI")]
		public bool Borderless
		{
			get; set;
		} = true;
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
			get;
			set;
		} = true;

		/// <summary>
		/// 设置或获取NanUI窗口边框线条粗细
		/// </summary>
		[Category("NanUI")]
		public int BorderSize
		{
			get; set;
		} = 1;



		/// <summary>
		/// 设置或获取NanUI窗口边框颜色
		/// </summary>
		[Category("NanUI")]
		public Color BorderColor
		{
			get;
			set;
		} = Color.DarkGray;
		private bool IsNonclientMode
		{
			get
			{
				return IsWindowsXP || ForceNonclientMode;
			}
		}



		public HtmlUIForm() : this(null)
		{

		}

		public HtmlUIForm(string initialUrl, bool forceNonclientMode = false)
		{
			this.initialUrl = initialUrl;
			IsWindowsXP = Environment.OSVersion.Version.Major < 6;
			ForceNonclientMode = forceNonclientMode;
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

				BORDER_X = NativeMethods.GetSystemMetrics(NativeMethods.SystemMetric.SM_CXSIZEFRAME) - BorderSize;
				BORDER_Y = NativeMethods.GetSystemMetrics(NativeMethods.SystemMetric.SM_CYSIZEFRAME) - BorderSize;

				maxPadding = new Padding(BORDER_X, BORDER_Y, BORDER_X, BORDER_Y);

				this.Controls.Add(splashPicture);
				splashPicture.BringToFront();

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
			if (message.Msg == NativeMethods.WindowsMessage.WM_MOUSEACTIVATE)
			{
				var topLevelWindowHandle = message.WParam;
				NativeMethods.PostMessage(topLevelWindowHandle, NativeMethods.WindowsMessage.WM_NCLBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
			}

			if (message.Msg == NativeMethods.WindowsMessage.WM_LBUTTONDOWN)
			{

				var x = NativeMethods.LoWord(message.LParam.ToInt32());
				var y = NativeMethods.HiWord(message.LParam.ToInt32());

				var dragable = (draggableRegion != null && draggableRegion.IsVisible(new Point(x, y)));

				var dir = GetDirection(x, y);

				if (dir != NativeMethods.HitTest.HTCLIENT && Borderless)
				{
					NativeMethods.PostMessage(FormHandle, NativeMethods.DefMessages.WM_CEF_RESIZE_CLIENT, (IntPtr)dir, message.LParam);
					return true;
				}
				else if (dragable)
				{
					NativeMethods.PostMessage(FormHandle, NativeMethods.DefMessages.WM_CEF_DRAG_APP, message.WParam, message.LParam);
					return true;
				}


			}

			if (message.Msg == NativeMethods.WindowsMessage.WM_LBUTTONDBLCLK && Resizable)
			{
				var x = NativeMethods.LoWord(message.LParam.ToInt32());
				var y = NativeMethods.HiWord(message.LParam.ToInt32());

				var dragable = (draggableRegion != null && draggableRegion.IsVisible(new Point(x, y)));

				if (dragable)
				{
					NativeMethods.PostMessage(FormHandle, NativeMethods.DefMessages.WM_CEF_TITLEBAR_LBUTTONDBCLICK, message.WParam, message.LParam);

					return true;
				}

			}

			if (message.Msg == NativeMethods.WindowsMessage.WM_MOUSEMOVE)
			{
				var x = NativeMethods.LoWord(message.LParam.ToInt32());
				var y = NativeMethods.HiWord(message.LParam.ToInt32());

				if (Resizable && Borderless)
				{
					var dir = GetDirection(x, y);

					if (dir != NativeMethods.HitTest.HTCLIENT)
					{
						NativeMethods.PostMessage(FormHandle, NativeMethods.DefMessages.WM_CEF_EDGE_MOVE, (IntPtr)dir, message.LParam);

						return true;
					}
				}

				NativeMethods.SendMessage(FormHandle, NativeMethods.WindowsMessage.WM_MOUSEMOVE, message.WParam, message.LParam);

			}


			return false;

		}

		protected virtual int GetDirection(int x, int y)
		{
			var dir = NativeMethods.HitTest.HTCLIENT;

			if (WindowState == FormWindowState.Normal)
			{
				if (x < BORDER_WIDTH & y < BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTTOPLEFT;

				}
				else if (x < BORDER_WIDTH & y > this.Height - BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTBOTTOMLEFT;

				}
				else if (x > this.Width - BORDER_WIDTH & y > this.Height - BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTBOTTOMRIGHT;

				}
				else if (x > this.Width - BORDER_WIDTH & y < BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTTOPRIGHT;

				}
				else if (x < BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTLEFT;

				}
				else if (x > this.Width - BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTRIGHT;

				}
				else if (y < BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTTOP;

				}
				else if (y > this.Height - BORDER_WIDTH)
				{
					dir = NativeMethods.HitTest.HTBOTTOM;

				}

			}


			return dir;
		}
		protected virtual void SetResizeMethod(int direction)
		{
			if (WindowState == FormWindowState.Normal)
			{
				switch (direction)
				{
					case NativeMethods.HitTest.HTLEFT:
						ResizeDirection = ResizeDirection.Left;
						this.Cursor = Cursors.SizeWE;
						break;
					case NativeMethods.HitTest.HTRIGHT:
						ResizeDirection = ResizeDirection.Right;
						this.Cursor = Cursors.SizeWE;
						break;
					case NativeMethods.HitTest.HTTOP:
						ResizeDirection = ResizeDirection.Top;
						this.Cursor = Cursors.SizeNS;
						break;
					case NativeMethods.HitTest.HTBOTTOM:
						ResizeDirection = ResizeDirection.Bottom;
						this.Cursor = Cursors.SizeNS;
						break;
					case NativeMethods.HitTest.HTBOTTOMLEFT:
						ResizeDirection = ResizeDirection.BottomLeft;
						this.Cursor = Cursors.SizeNESW;
						break;
					case NativeMethods.HitTest.HTTOPRIGHT:
						ResizeDirection = ResizeDirection.TopRight;
						this.Cursor = Cursors.SizeNESW;
						break;
					case NativeMethods.HitTest.HTBOTTOMRIGHT:
						ResizeDirection = ResizeDirection.BottomRight;
						this.Cursor = Cursors.SizeNWSE;
						break;
					case NativeMethods.HitTest.HTTOPLEFT:
						ResizeDirection = ResizeDirection.TopLeft;
						this.Cursor = Cursors.SizeNWSE;
						break;
					default:
						ResizeDirection = ResizeDirection.None;
						//this.Cursor = Cursors.Default;
						break;
				}

			}
			else
			{
				ResizeDirection = ResizeDirection.None;
				this.Cursor = Cursors.Default;

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

		protected override void OnLoad(EventArgs e)
		{
			if (!IsDesignMode && Borderless)
			{
				if (IsNonclientMode)
				{
					NativeMethods.DisableProcessWindowsGhosting();
					NativeMethods.SetWindowTheme(Handle, string.Empty, string.Empty);
					nativeForm = new NonclientNativeWindow(this);
				}
				else
				{
					IntPtr dwAttr = new IntPtr(1);
					NativeMethods.DwmSetWindowAttribute(Handle, 2, dwAttr, 4);

					Padding = new Padding(Padding.Left + BorderSize, Padding.Top + BorderSize, Padding.Right + BorderSize, Padding.Bottom + BorderSize);
				}

			}
			base.OnLoad(e);
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{

			if (windowOriginalSize.HasValue && !IsDesignMode)
			{
				base.SetBoundsCore(x, y, windowOriginalSize.Value.Width, windowOriginalSize.Value.Height, specified);
			}
			else
			{
				base.SetBoundsCore(x, y, width, height, specified);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (Resizable && ResizeDirection != ResizeDirection.None)
			{
				NativeMethods.SendMessage(Handle, NativeMethods.WindowsMessage.WM_NCLBUTTONDOWN, (IntPtr)ResizeDirectionState, (IntPtr)0);
			}
		}
		protected override void OnClosed(EventArgs e)
		{
			messageInterceptor?.ReleaseHandle();
			messageInterceptor?.DestroyHandle();
			messageInterceptor = null;


			base.OnClosed(e);

			nativeForm?.ReleaseHandle();
			nativeForm?.DestroyHandle();


		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{

			if (!IsDesignMode && Borderless)
			{
				if (IsNonclientMode)
				{
					using (var brush = new SolidBrush(BackColor))
					{
						e.Graphics.FillRectangle(brush, e.ClipRectangle);
					}
				}
				else
				{
					using (var brush = new SolidBrush(BackColor))
					{

						var rect = new Rectangle(BorderSize, BorderSize, ClientRectangle.Width - BorderSize * 2, ClientRectangle.Height - BorderSize * 2);
						e.Graphics.FillRectangle(brush, rect);

						using (var pen = new Pen(BorderColor, BorderSize))
						{
							e.Graphics.DrawLine(pen, 0, 0, 0, Height);
							e.Graphics.DrawLine(pen, 0, 0, Width, 0);
							e.Graphics.DrawLine(pen, Width - BorderSize, 0, Width - BorderSize, Height);
							e.Graphics.DrawLine(pen, 0, Height - BorderSize, Width, Height - BorderSize);
						}

						e.Graphics.FillRectangle(brush, rect);
					}
				}

			}
			else
			{
				base.OnPaintBackground(e);
			}
		}


		protected override void WndProc(ref Message m)
		{
			if (!IsDesignMode)
			{

				switch (m.Msg)
				{
					case NativeMethods.WindowsMessage.WM_SHOWWINDOW:
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
					case NativeMethods.WindowsMessage.WM_NCHITTEST:
						{
							if (m.Result == NativeMethods.FALSE && Resizable && Borderless)
							{
								Point p = PointToClient(new Point(NativeMethods.LoWord(m.LParam.ToInt32()), NativeMethods.HiWord(m.LParam.ToInt32())));
								var hit = GetDirection(p.X, p.Y);

								SetResizeMethod(hit);

								m.Result = (IntPtr)hit;
							}
							else
							{
								base.WndProc(ref m);
							}
						}
						break;
					case NativeMethods.WindowsMessage.WM_SIZE:
						{
							if (Borderless)
							{
								var msg = m.WParam.ToInt32();

								if (msg == 0 && fullClientModePadding.HasValue)
								{
									Padding = fullClientModePadding.Value;
									fullClientModePadding = null;
								}
								else if (msg == 2)
								{

									if (fullClientModePadding == null)
									{
										fullClientModePadding = Padding;
									}

									Padding = maxPadding;

								}
							}


							if (browser != null && browser.IsHandleCreated)
							{
								var x = NativeMethods.LoWord(m.LParam.ToInt32());
								var y = NativeMethods.HiWord(m.LParam.ToInt32());

								var js = string.Format(JS_WINDOW_STATE_CHANGED, m.WParam, x, y);
								browser.ExecuteJavascript(js);
							}

							base.WndProc(ref m);

						}

						break;
					case NativeMethods.WindowsMessage.WM_SYSCOMMAND:
						{
							if (Borderless)
							{
								var msg = m.WParam.ToInt32();

								if (msg == NativeMethods.SysCommand.SC_MINIMIZE || msg == NativeMethods.SysCommand.SC_MAXIMIZE)
								{
									if (WindowState != FormWindowState.Minimized && WindowState != FormWindowState.Maximized)
									{
										windowOriginalSize = ClientSize;
									}
								}
							}


							base.WndProc(ref m);

						}
						break;

					default:
						{
							if (Borderless)
							{
								if (IsNonclientMode)
								{
									NonclientModeWndProc(ref m);
								}
								else
								{
									DwmModeWndProc(ref m);
								}
							}
							else
							{
								base.WndProc(ref m);
							}


						}
						break;
				}

			}
			else
			{
				base.WndProc(ref m);
			}



		}

		private void DwmModeWndProc(ref Message m)
		{
			IntPtr result = IntPtr.Zero;

			var dwmHandled = NativeMethods.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, ref result);

			if (dwmHandled == 1)
			{
				m.Result = result;
				return;
			}

			switch (m.Msg)
			{
				case NativeMethods.WindowsMessage.WM_ACTIVATE:
					NativeMethods.DwmExtendFrameIntoClientArea(Handle, ref dwmMargins);
					break;
				case NativeMethods.WindowsMessage.WM_NCCALCSIZE:
					{
						if (m.WParam == NativeMethods.TRUE)
						{
							var nccsp = (NativeMethods.NCCALCSIZE_PARAMS)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));

							if (!dwmMarginHandled)
							{

								dwmMargins.cyTopHeight = BorderSize;
								dwmMargins.cxLeftWidth = BorderSize;
								dwmMargins.cyBottomHeight = BorderSize;
								dwmMargins.cxRightWidth = BorderSize;
								dwmMarginHandled = true;
							}

							Marshal.StructureToPtr(nccsp, m.LParam, false);

							m.Result = IntPtr.Zero;

						}
						else
						{
							base.WndProc(ref m);
						}
					}
					break;
				default:
					base.WndProc(ref m);
					break;
			}


		}


		private void NonclientModeWndProc(ref Message m)
		{
			switch (m.Msg)
			{
				default:
					base.WndProc(ref m);
					break;
			}
		}

		protected override void DefWndProc(ref Message m)
		{
			if (m.Msg == NativeMethods.DefMessages.WM_CEF_TITLEBAR_LBUTTONDBCLICK)
			{
				NativeMethods.ReleaseCapture();

				if (WindowState == FormWindowState.Maximized)
				{
					NativeMethods.SendMessage(FormHandle, NativeMethods.WindowsMessage.WM_SYSCOMMAND, (IntPtr)NativeMethods.SysCommand.SC_RESTORE, IntPtr.Zero);
				}
				else
				{
					NativeMethods.SendMessage(FormHandle, NativeMethods.WindowsMessage.WM_SYSCOMMAND, (IntPtr)NativeMethods.SysCommand.SC_MAXIMIZE, IntPtr.Zero);
				}


			}

			if (m.Msg == NativeMethods.DefMessages.WM_CEF_DRAG_APP && !(FormBorderStyle == FormBorderStyle.None && WindowState == FormWindowState.Maximized))
			{
				NativeMethods.ReleaseCapture();
				NativeMethods.SendMessage(Handle, NativeMethods.WindowsMessage.WM_NCLBUTTONDOWN, (IntPtr)NativeMethods.HitTest.HTCAPTION, (IntPtr)0);
			}
			if (m.Msg == NativeMethods.DefMessages.WM_CEF_RESIZE_CLIENT && Resizable && WindowState == FormWindowState.Normal)
			{
				NativeMethods.ReleaseCapture();
				isFormResizing = true;

				SetResizeMethod(m.WParam.ToInt32());


				NativeMethods.SendMessage(Handle, NativeMethods.WindowsMessage.WM_NCLBUTTONDOWN, m.WParam, (IntPtr)0);

				isFormResizing = false;
			}

			if (m.Msg == NativeMethods.DefMessages.WM_CEF_EDGE_MOVE && Resizable && WindowState == FormWindowState.Normal && !isFormResizing)
			{
				SetResizeMethod(m.WParam.ToInt32());
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




		#endregion

	}
}
