using Chromium;
using NetDimension.NanUI.Browser;
using NetDimension.NanUI.Browser.Handlers;
using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.Window
{
    [ToolboxItem(false)]
    public class HostBrowserControl : Control, IWebBrowserHandler
    {
        public BrowserCore WebBrowserCore { get; private set; }
        protected Formium BrowserHostWindow { get; private set; }

        #region IWebBrowserHandler

        public ChromiumContextMenuHandler ContextMenuHandler => WebBrowserCore?.Client?.ContextMenuHandler;

        public ChromiumDialogHandler DialogHandler => WebBrowserCore?.Client?.DialogHandler;

        public ChromiumDisplayHandler DisplayHandler => WebBrowserCore?.Client?.DisplayHandler;

        public ChromiumDownloadHandler DownloadHandler => WebBrowserCore?.Client?.DownloadHandler;

        public ChromiumDragHandler DragHandler => WebBrowserCore?.Client?.DragHandler;

        public ChromiumFindHandler FindHandler => WebBrowserCore?.Client?.FindHandler;

        public ChromiumFocusHandler FocusHandler => WebBrowserCore?.Client?.FocusHandler;

        public ChromiumJSDialogHandler JSDialogHandler => WebBrowserCore?.Client?.JsDialogHandler;

        public ChromiumKeyboardHandler KeyboardHandler => WebBrowserCore?.Client?.KeyboardHandler;

        public ChromiumLifeSpanHandler LifeSpanHandler => WebBrowserCore?.Client?.LifeSpanHandler;

        public ChromiumLoadHandler LoadHandler => WebBrowserCore?.Client?.LoadHandler;

        public ChromiumRenderHandler RenderHandler => WebBrowserCore?.Client?.RenderHandler;

        public ChromiumRequestHandler RequestHandler => WebBrowserCore?.Client?.RequestHandler;
        #endregion

        private HostBrowserControl() { }
        internal HostBrowserControl(Formium hostWindow)
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

            BrowserHostWindow = hostWindow;


        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            WebBrowserCore = new BrowserCore(this, BrowserHostWindow.StartUrl);
            WebBrowserCore.BrowserCreated += BrowserCreated;
            var windowInfo = new CfxWindowInfo();
            windowInfo.SetAsChild(Handle, 0, 0, Width, Height);
            WebBrowserCore.Create(windowInfo);
        }
        
        private void BrowserCreated(object sender, BrowserCreatedEventArgs e)
        {
            this.TopLevelControl.Move += TopLevelControl_Move;
            WebBrowserCore.ResizeBrowserWindow();
            BrowserHostWindow.RaiseWebBrowserControlCreated();
        }




        private void TopLevelControl_Move(object sender, EventArgs e)
        {
            if (WebBrowserCore != null)
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
    }
}
