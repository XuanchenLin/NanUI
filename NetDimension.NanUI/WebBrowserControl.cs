using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	using Chromium;
	using Chromium.Remote;
	using Chromium.WebBrowser;
	using NetDimension.NanUI;

	public partial class WebBrowserControl : Control, IChromiumClient
	{
		private BrowserCore browserCore;
		private static bool? isDesingerProcess = null;
		protected IntPtr FormHandle { get; private set; }

		[Browsable(false)]
		public BrowserCore Chromium => browserCore;

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
		private string _url = "about:blank";

		[Category("NanUI")]
		public string NavigateUrl
		{
			get
			{
				return _url;
			}
			set
			{
				_url = value;
				if(!IsDesignMode)
					this.LoadUrl(_url);
			}
		}

		[Browsable(false)]
		public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }
		[Browsable(false)]
		public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }
		[Browsable(false)]
		public override Image BackgroundImage { get => base.BackgroundImage; set => base.BackgroundImage = value; }
		[Browsable(false)]
		public override ImageLayout BackgroundImageLayout { get => base.BackgroundImageLayout; set => base.BackgroundImageLayout = value; }
		[Browsable(false)]
		public override bool AutoSize { get => base.AutoSize; set => base.AutoSize = value; }
		[Browsable(false)]
		public override ContextMenu ContextMenu { get => base.ContextMenu; set => base.ContextMenu = value; }
		[Browsable(false)]
		public override ContextMenuStrip ContextMenuStrip { get => base.ContextMenuStrip; set => base.ContextMenuStrip = value; }
		[Browsable(false)]
		public override string Text { get => base.Text; set => base.Text = value; }

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

		public WebBrowserControl()
		{
			this.DoubleBuffered = true;
			this.UpdateStyles();
			InitializeComponent();

			InitializeBrowserCore(NavigateUrl);
		}

		protected virtual void InitializeBrowserCore(string initialUrl)
		{
			if (IsDesignMode) return;

			browserCore = new BrowserCore(this, initialUrl);
			browserCore.RemoteCallbackInvokeMode = JSInvokeMode.Inherit;

			FormHandle = Handle;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			if (IsDesignMode)
			{
				var format = new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				};
				pe.Graphics.DrawString("NanUI WebBrowser Control", this.Font, SystemBrushes.ControlText, this.ClientRectangle, format);
			}
			
			
			base.OnPaint(pe);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			pevent.Graphics.FillRectangle(SystemBrushes.Window, pevent.ClipRectangle);

		}
	}
}
