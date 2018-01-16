using Chromium.WebBrowser;
using NetDimension.Windows.Imports;
using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Chromium;
using System.ComponentModel;
using Chromium.Remote;

namespace NetDimension.NanUI
{
	public class Formium : ModernUIForm, IChromiumClient
	{
		private BrowserCore browserCore;
		private readonly Panel splashPanel;
		private bool isFirstTimeShowSplash;

		protected IntPtr FormHandle { get; private set; }


		protected BrowserCore Chromium => browserCore;

		protected IntPtr BrowserHandle
		{
			get
			{
				return browserCore.BrowserHost.WindowHandle;
			}
		}

		#region ICefClient
		[Browsable(false)]
		public CfxBrowser Browser => browserCore.Browser;
		[Browsable(false)]
		public CfxBrowserHost BrowserHost => browserCore.BrowserHost;
		[Browsable(false)]
		public Uri Url => browserCore.Url;
		[Browsable(false)]
		public bool IsLoading => browserCore.IsLoading;
		[Browsable(false)]
		public bool CanGoBack => browserCore.CanGoBack;
		[Browsable(false)]
		public bool CanGoForward => browserCore.CanGoForward;
		[Browsable(false)]
		public JSObject GlobalObject => browserCore.GlobalObject;
		[Browsable(false)]
		public CfxContextMenuHandler ContextMenuHandler => browserCore.ContextMenuHandler;
		[Browsable(false)]
		public CfxLifeSpanHandler LifeSpanHandler => browserCore.LifeSpanHandler;
		[Browsable(false)]
		public CfxLoadHandler LoadHandler => browserCore.LoadHandler;
		[Browsable(false)]
		public CfxRequestHandler RequestHandler => browserCore.RequestHandler;
		[Browsable(false)]
		public CfxDisplayHandler DisplayHandler => browserCore.DisplayHandler;
		[Browsable(false)]
		public CfxDownloadHandler DownloadHandler => browserCore.DownloadHandler;
		[Browsable(false)]
		public CfxDragHandler DragHandler => browserCore.DragHandler;
		[Browsable(false)]
		public CfxDialogHandler DialogHandler => browserCore.DialogHandler;
		[Browsable(false)]
		public CfxFindHandler FindHandler => browserCore.FindHandler;
		[Browsable(false)]
		public CfxFocusHandler FocusHandler => browserCore.FocusHandler;
		[Browsable(false)]
		public CfxGeolocationHandler GeolocationHandler => browserCore.GeolocationHandler;
		[Browsable(false)]
		public CfxJsDialogHandler JsDialogHandler => browserCore.JsDialogHandler;
		[Browsable(false)]
		public CfxKeyboardHandler KeyboardHandler => browserCore.KeyboardHandler;

		public void GoBack() => browserCore.GoBack();
		public void GoForward() => browserCore.GoForward();
		public void LoadUrl(string url) => browserCore.LoadUrl(url);
		public void LoadString(string stringVal, string url) => browserCore.LoadString(stringVal, url);
		public void LoadString(string stringVal) => browserCore.LoadString(stringVal);
		public int Find(string searchText, bool forward, bool matchCase) => browserCore.Find(searchText, forward, matchCase);
		public int Find(string searchText, bool forward) => browserCore.Find(searchText, forward);
		public int Find(string searchText) => browserCore.Find(searchText);
		public bool ExecuteJavascript(string code) => browserCore.ExecuteJavascript(code);
		public bool ExecuteJavascript(string code, string scriptUrl, int startLine) => browserCore.ExecuteJavascript(code, scriptUrl, startLine);
		public bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback) => browserCore.EvaluateJavascript(code, callback);
		public bool EvaluateJavascript(string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback) => browserCore.EvaluateJavascript(code, invokeMode, callback);
		public JSObject GlobalObjectForFrame(string frameName) => browserCore.GlobalObjectForFrame(frameName);
		#endregion
		[Browsable(false)]
		public Panel SplashPanel
		{
			get
			{
				return splashPanel;
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
				return splashPanel.BackgroundImage;
			}
			set
			{
				splashPanel.BackgroundImage = value;
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
				return splashPanel.BackgroundImageLayout;
			}
			set
			{
				splashPanel.BackgroundImageLayout = value;
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
				return splashPanel.BackColor;
			}
			set
			{
				splashPanel.BackColor = value;
			}
		}



		public Formium()
				: this(null)
		{

		}

		public Formium(string initialUrl)
				: this(initialUrl, true)
		{

		}

		public Formium(string initialUrl, bool enableModernForm)
				: base(enableModernForm)
		{

			this.DoubleBuffered = true;

			UpdateStyles();




			splashPanel = new Panel()
			{
				Dock = DockStyle.Fill,
				BackColor = Color.Transparent
			};



			if (!IsDesignMode)
			{
				this.Controls.Add(splashPanel);
				splashPanel.BringToFront();

				isFirstTimeShowSplash = true;

				InitializeBrowserCore(initialUrl);

			}

		}


		protected void HideInitialSplash()
		{
			if (isFirstTimeShowSplash)
			{
				HideSplash();
				isFirstTimeShowSplash = false;
			}
		}

		protected void HideSplash()
		{
			this.RequireUIThread(() =>
			{

				splashPanel.Visible = false;
				splashPanel.SendToBack();
				browserCore.SetToTop();
			});
		}
		
		protected virtual void InitializeBrowserCore(string initialUrl)
		{
			if (IsDesignMode) return;


			browserCore = new BrowserCore(this, initialUrl, true);
			browserCore.RemoteCallbackInvokeMode = JSInvokeMode.Inherit;

			FormHandle = Handle;

			browserCore.OnBrowserMessage += BrowserCore_OnBrowserMessage;

			LoadHandler.OnLoadEnd += (_, args) =>
			{

				if (args.Frame.IsMain)
				{
					HideInitialSplash();
				}
			};

		}
		
		private POINT GetPostionFromPtr(IntPtr lparam)
		{
			var scaledX = (int)User32.LoWord(lparam);
			var scaledY = (int)User32.HiWord(lparam);

			var x = scaledX;
			var y = scaledY;

			return new POINT(x, y);
		}
		private void BrowserCore_OnBrowserMessage(object sender, BrowserMessageEventArgs e)
		{
			if (BrowserHandle == IntPtr.Zero) return;

			var msg = (WindowsMessages)e.BrowserMessage.Msg;

			if (CanResize && msg == WindowsMessages.WM_MOUSEMOVE)
			{
				var pt = GetPostionFromPtr(e.BrowserMessage.LParam);
				var mode = GetSizeMode(pt);

				if (mode != HitTest.HTNOWHERE)
				{

					User32.ClientToScreen(FormHandle, ref pt);

					User32.PostMessage(FormHandle, (uint)WindowsMessages.WM_NCHITTEST, IntPtr.Zero, Win32.MakeParam((IntPtr)pt.x, (IntPtr)pt.y));

					e.Handled = true;
				}
			}


			if (msg == WindowsMessages.WM_LBUTTONDOWN)
			{
				var pt = GetPostionFromPtr(e.BrowserMessage.LParam);
				var dragable = (Chromium.DraggableRegion != null && Chromium.DraggableRegion.IsVisible(new Point(pt.x, pt.y)));

				var mode = GetSizeMode(pt);
				if (CanResize && mode != HitTest.HTNOWHERE)
				{

					User32.ClientToScreen(FormHandle, ref pt);
					User32.PostMessage(FormHandle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)mode, Win32.MakeParam((IntPtr)pt.x, (IntPtr)pt.y));
					e.Handled = true;
				}
				else if (dragable && !(FormBorderStyle == FormBorderStyle.None && WindowState == FormWindowState.Maximized))
				{
					User32.PostMessage(FormHandle, (uint)WindowsMessages.WM_USER + 1000, IntPtr.Zero, IntPtr.Zero);
					e.Handled = true;
				}
			}

			if (CanResize && msg == WindowsMessages.WM_LBUTTONDBLCLK)
			{
				var pt = GetPostionFromPtr(e.BrowserMessage.LParam);
				var dragable = (Chromium.DraggableRegion != null && Chromium.DraggableRegion.IsVisible(new Point(pt.x, pt.y)));
				if (dragable)
				{
					User32.SendMessage(FormHandle, (uint)WindowsMessages.WM_NCLBUTTONDBLCLK, (IntPtr)HitTest.HTCAPTION, Win32.MakeParam((IntPtr)pt.x, (IntPtr)pt.y));
				}
			}
		}
		protected override void DefWndProc(ref Message m)
		{
			var msg = (WindowsMessages)m.Msg;
			if (msg == (WindowsMessages.WM_USER + 1000))
			{
				User32.ReleaseCapture();
				User32.SendMessage(Handle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)HitTest.HTCAPTION, (IntPtr)0);
			}

			base.DefWndProc(ref m);
		}


	}
}
