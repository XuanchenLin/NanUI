using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
    using Chromium;
    using Chromium.Remote;
    using NetDimension.NanUI.Browser;
    using NetDimension.NanUI.Browser.Handlers;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class WebBrowserControl : Control, IWebBrowser, IWebBrowserHandler
    {
        private const string ABOUT_BLANK = "about:blank";
        const string CONTROL_NAME = "WebBrowserControl Powered By NanUI";
        private string startUrl = ABOUT_BLANK;

        [Browsable(false)]
        public BrowserCore WebBrowserCore { get; private set; }

        [Browsable(true)]
        [Category("WebBrowser")]
        public string StartUrl
        {
            get => startUrl;
            set
            {
                if (string.IsNullOrEmpty(startUrl))
                {
                    startUrl = ABOUT_BLANK;
                }
                else
                {
                    startUrl = value;
                }

                LoadUrl(startUrl);

                if (DesignMode)
                {
                    Refresh();
                }
            }
        }

        #region IWebBrowserHandler
        [Browsable(false)]
        public ChromiumContextMenuHandler ContextMenuHandler => WebBrowserCore?.Client?.ContextMenuHandler;
        [Browsable(false)]
        public ChromiumDialogHandler DialogHandler => WebBrowserCore?.Client?.DialogHandler;
        [Browsable(false)]
        public ChromiumDisplayHandler DisplayHandler => WebBrowserCore?.Client?.DisplayHandler;
        [Browsable(false)]
        public ChromiumDownloadHandler DownloadHandler => WebBrowserCore?.Client?.DownloadHandler;
        [Browsable(false)]
        public ChromiumDragHandler DragHandler => WebBrowserCore?.Client?.DragHandler;
        [Browsable(false)]
        public ChromiumFindHandler FindHandler => WebBrowserCore?.Client?.FindHandler;
        [Browsable(false)]
        public ChromiumFocusHandler FocusHandler => WebBrowserCore?.Client?.FocusHandler;
        [Browsable(false)]
        public ChromiumJSDialogHandler JSDialogHandler => WebBrowserCore?.Client?.JsDialogHandler;
        [Browsable(false)]
        public ChromiumKeyboardHandler KeyboardHandler => WebBrowserCore?.Client?.KeyboardHandler;
        [Browsable(false)]
        public ChromiumLifeSpanHandler LifeSpanHandler => WebBrowserCore?.Client?.LifeSpanHandler;
        [Browsable(false)]
        public ChromiumLoadHandler LoadHandler => WebBrowserCore?.Client?.LoadHandler;
        [Browsable(false)]
        public ChromiumRenderHandler RenderHandler => WebBrowserCore?.Client?.RenderHandler;
        [Browsable(false)]
        public ChromiumRequestHandler RequestHandler => WebBrowserCore?.Client?.RequestHandler;
        #endregion

        #region IWebBrowser
        [Browsable(false)]
        public bool IsLoading => WebBrowserCore?.Browser == null ? false : WebBrowserCore.Browser.IsLoading;
        [Browsable(false)]
        public bool CanGoBack => WebBrowserCore?.Browser == null ? false : WebBrowserCore.Browser.CanGoBack;
        [Browsable(false)]
        public bool CanGoForward => WebBrowserCore?.Browser == null ? false : WebBrowserCore.Browser.CanGoForward;

        public void GoBack()
        {
            WebBrowserCore?.Browser?.GoBack();
        }

        public void GoForward()
        {
            WebBrowserCore?.Browser?.GoForward();
        }

        public void LoadUrl(string url)
        {
            WebBrowserCore?.NavigateToUrl(url);
        }

        public void LoadString(string stringVal, string url)
        {
            WebBrowserCore?.LoadString(stringVal, url);
        }

        public void LoadString(string stringVal)
        {
            WebBrowserCore?.LoadString(stringVal, ABOUT_BLANK);
        }

        //public bool ExecuteJavascript(string code)
        //{
        //    return webBrowser == null ? false : webBrowser.ExecuteJavascript(code);
        //}

        //public bool ExecuteJavascript(string code, string scriptUrl, int startLine)
        //{
        //    return webBrowser == null ? false : webBrowser.ExecuteJavascript(code, scriptUrl, startLine);
        //}

        //public bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback)
        //{
        //    return webBrowser == null ? false : webBrowser.EvaluateJavascript(code, callback);
        //}
        #endregion

        public WebBrowserControl()
        {
            SetStyle(
                ControlStyles.ContainerControl
                | ControlStyles.ResizeRedraw
                | ControlStyles.FixedWidth
                | ControlStyles.FixedHeight
                | ControlStyles.StandardClick
                | ControlStyles.UserMouse
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.StandardDoubleClick
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.CacheText
                | ControlStyles.EnableNotifyMessage
                | ControlStyles.DoubleBuffer
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UseTextForAccessibility
                | ControlStyles.Opaque,
                false);
            SetStyle(
                ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.Selectable,
                true);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode)
            {
                Paint += PaintInDesignMode;
            }
            else
            {
                InitializeBrowser();
            }
        }



        private void InitializeBrowser()
        {
            WebBrowserCore = new BrowserCore(this, startUrl);
            WebBrowserCore.BrowserCreated += BrowserCreated;
            var windowInfo = new CfxWindowInfo();
            windowInfo.SetAsChild(Handle, 0, 0, Width, Height);
            WebBrowserCore.Create(windowInfo);
        }

        private void BrowserCreated(object sender, BrowserCreatedEventArgs e)
        {
            this.TopLevelControl.Move += TopLevelControl_Move;
            WebBrowserCore.ResizeBrowserWindow();
        }

        private void TopLevelControl_Move(object sender, EventArgs e)
        {
            if (WebBrowserCore != null && !DesignMode)
            {
                WebBrowserCore.ResizeBrowserWindow();
                WebBrowserCore?.BrowserHost?.NotifyMoveOrResizeStarted();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (WebBrowserCore != null && !DesignMode)
            {
                WebBrowserCore?.ResizeBrowserWindow();
                WebBrowserCore?.BrowserHost?.NotifyMoveOrResizeStarted();
            }
        }

        private void PaintInDesignMode(object sender, PaintEventArgs e)
        {
            var width = this.Width;
            var height = this.Height;
            if (width > 1 && height > 1)
            {
                var foregroundBrush = new SolidBrush(this.ForeColor);
                var backgroundBrush = new SolidBrush(Color.White);


                e.Graphics.FillRectangle(backgroundBrush, 0, 0, width - 1, height - 1);

                var fontHeight = (int)(this.Font.GetHeight(e.Graphics) * 1.25);



                var sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                var measure = e.Graphics.MeasureString(CONTROL_NAME, Font);
                //var x = this.Width / 2 - measure.Width / 2;
                var y = this.Height / 2 - measure.Height / 2;

                e.Graphics.DrawString(CONTROL_NAME, Font, foregroundBrush, new RectangleF(0, y, width, fontHeight), sf);
                e.Graphics.DrawString($"StartUrl: {StartUrl}, it will be navigated to this url on runtime.", Font, foregroundBrush, new RectangleF(0, y + fontHeight, width, fontHeight), sf);

                foregroundBrush.Dispose();
                backgroundBrush.Dispose();
            }

        }






    }


}
