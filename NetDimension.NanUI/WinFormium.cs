using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	using Chromium;
	using Chromium.Remote;
	using Chromium.WebBrowser;
	using NetDimension.Windows.Imports;
	using NetDimension.WinForm;
	using System.ComponentModel;
	using System.Drawing;

	public class WinFormium : Form, IChromiumClient
	{
		#region ICefClient
		[Browsable(false)]
		public CfxBrowser Browser => Chromium?.Browser;
		[Browsable(false)]
		public CfxBrowserHost BrowserHost => Chromium?.BrowserHost;
		[Browsable(false)]
		public Uri Url => Chromium.Url;
		[Browsable(false)]
		public bool IsLoading => Chromium.IsLoading;
		[Browsable(false)]
		public bool CanGoBack => Chromium.CanGoBack;
		[Browsable(false)]
		public bool CanGoForward => Chromium.CanGoForward;
		[Browsable(false)]
		public JSObject GlobalObject => Chromium.GlobalObject;
		[Browsable(false)]
		public CfxContextMenuHandler ContextMenuHandler => Chromium.ContextMenuHandler;
		[Browsable(false)]
		public CfxLifeSpanHandler LifeSpanHandler => Chromium.LifeSpanHandler;
		[Browsable(false)]
		public CfxLoadHandler LoadHandler => Chromium.LoadHandler;
		[Browsable(false)]
		public CfxRequestHandler RequestHandler => Chromium.RequestHandler;
		[Browsable(false)]
		public CfxDisplayHandler DisplayHandler => Chromium.DisplayHandler;
		[Browsable(false)]
		public CfxDownloadHandler DownloadHandler => Chromium.DownloadHandler;
		[Browsable(false)]
		public CfxDragHandler DragHandler => Chromium.DragHandler;
		[Browsable(false)]
		public CfxDialogHandler DialogHandler => Chromium.DialogHandler;
		[Browsable(false)]
		public CfxFindHandler FindHandler => Chromium.FindHandler;
		[Browsable(false)]
		public CfxFocusHandler FocusHandler => Chromium.FocusHandler;
		[Browsable(false)]
		public CfxGeolocationHandler GeolocationHandler => Chromium.GeolocationHandler;
		[Browsable(false)]
		public CfxJsDialogHandler JsDialogHandler => Chromium.JsDialogHandler;
		[Browsable(false)]
		public CfxKeyboardHandler KeyboardHandler => Chromium.KeyboardHandler;

		public void GoBack() => Chromium.GoBack();
		public void GoForward() => Chromium.GoForward();
		public void LoadUrl(string url) => Chromium.LoadUrl(url);
		public void LoadString(string stringVal, string url) => Chromium.LoadString(stringVal, url);
		public void LoadString(string stringVal) => Chromium.LoadString(stringVal);
		public int Find(string searchText, bool forward, bool matchCase) => Chromium.Find(searchText, forward, matchCase);
		public int Find(string searchText, bool forward) => Chromium.Find(searchText, forward);
		public int Find(string searchText) => Chromium.Find(searchText);
		public bool ExecuteJavascript(string code) => Chromium.ExecuteJavascript(code);
		public bool ExecuteJavascript(string code, string scriptUrl, int startLine) => Chromium.ExecuteJavascript(code, scriptUrl, startLine);
		public bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback) => Chromium.EvaluateJavascript(code, callback);
		public bool EvaluateJavascript(string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback) => Chromium.EvaluateJavascript(code, invokeMode, callback);
		public JSObject GlobalObjectForFrame(string frameName) => Chromium.GlobalObjectForFrame(frameName);
		#endregion

		private static bool? isDesingerProcess = null;
		private SplashPanelImplement splashPanel;
		private WebBrowserFormImplement webBrowserForm;

		protected readonly WebBrowserControl BrowserWrapper;

		protected BrowserCore Chromium => BrowserWrapper?.Chromium;

		protected IntPtr FormHandle { get; private set; }

		protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || IsDesingerProcess;
		protected static bool IsDesingerProcess
		{
			get
			{
				if (isDesingerProcess == null)
				{
					isDesingerProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
				}

				return isDesingerProcess.Value;
			}
		}

		protected IntPtr BrowserHandle
		{
			get
			{
				return Chromium.BrowserHost.WindowHandle;
			}
		}

		#region Splash
		[Category("NanUI")]
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Panel SplashPanel
		{
			get
			{
				return splashPanel.SplashPanel;
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
				return splashPanel.SplashImage;
			}
			set
			{
				splashPanel.SplashImage = value;
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
				return splashPanel.SplashImageLayout;
			}
			set
			{
				splashPanel.SplashImageLayout = value;
			}
		}


		/// <summary>
		/// 设置或获取NanUI窗口加载等待画面背景颜色
		/// </summary>
		[Category("NanUI")]
		public Color SplashPanelColor
		{
			get
			{
				return splashPanel.SplashPanelColor;
			}
			set
			{
				splashPanel.SplashPanelColor = value;
			}
		}

		#endregion

		public WinFormium()
	: this("about:blank")
		{

		}
		public WinFormium(string initialUrl)
		{

			if (!IsDesignMode)
			{
				BrowserWrapper = new WebBrowserControl(initialUrl);
				Controls.Add(BrowserWrapper);
				BrowserWrapper.Dock = DockStyle.Fill;
				BrowserWrapper.SendToBack();

				webBrowserForm = new WebBrowserFormImplement(this, this.Chromium);
			}

			splashPanel = new SplashPanelImplement(this, this.Chromium);

		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{


			base.OnFormClosed(e);


			Chromium.Dispose();

		}

	}
}
