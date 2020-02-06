using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    using Chromium;
    using NetDimension.NanUI.Browser.Handlers;

    public class BrowserClient : CfxClient
    {
        private BrowserCore browserCore;

        private ChromiumContextMenuHandler contextMenuHandler;
        private ChromiumDialogHandler dialogHandler;
        private ChromiumDisplayHandler displayHandler;
        private ChromiumDownloadHandler downloadHandler;
        private ChromiumDragHandler dragHandler;
        private ChromiumFindHandler findHandler;
        private ChromiumFocusHandler focusHandler;
        private ChromiumJSDialogHandler jsDialogHandler;
        private ChromiumKeyboardHandler keyboardHandler;
        private ChromiumLoadHandler loadHandler;
        private ChromiumRenderHandler renderHandler;
        private ChromiumRequestHandler requestHandler;


        internal BrowserClient(BrowserCore browserCore)
        {
            this.browserCore = browserCore;

            this.LifeSpanHandler = new ChromiumLifeSpanHandler(browserCore);

            this.GetLifeSpanHandler += (_, e) => { e.SetReturnValue(LifeSpanHandler); };
        }

        internal ChromiumLifeSpanHandler LifeSpanHandler { get; }

        internal ChromiumContextMenuHandler ContextMenuHandler
        {
            get
            {
                if (contextMenuHandler == null)
                {
                    contextMenuHandler = new ChromiumContextMenuHandler(browserCore);
                    this.GetContextMenuHandler += (handler, e) => e.SetReturnValue(contextMenuHandler);
                }
                return contextMenuHandler;
            }
        }

        internal ChromiumDialogHandler DialogHandler
        {
            get
            {
                if (dialogHandler == null)
                {
                    dialogHandler = new ChromiumDialogHandler(browserCore);
                    this.GetDialogHandler += (handler, e) => e.SetReturnValue(dialogHandler);
                }
                return dialogHandler;
            }
        }

        internal ChromiumDisplayHandler DisplayHandler
        {
            get
            {
                if (displayHandler == null)
                {
                    displayHandler = new ChromiumDisplayHandler(browserCore);
                    this.GetDisplayHandler += (handler, e) => e.SetReturnValue(displayHandler);
                }
                return displayHandler;
            }
        }

        internal ChromiumDownloadHandler DownloadHandler
        {
            get
            {
                if (downloadHandler == null)
                {
                    downloadHandler = new ChromiumDownloadHandler(browserCore);
                    this.GetDownloadHandler += (handler, e) => e.SetReturnValue(downloadHandler);
                }
                return downloadHandler;
            }
        }
        internal ChromiumDragHandler DragHandler
        {
            get
            {
                if (dragHandler == null)
                {
                    dragHandler = new ChromiumDragHandler(browserCore);
                    this.GetDragHandler += (handler, e) => e.SetReturnValue(dragHandler);
                }
                return dragHandler;
            }
        }

        internal ChromiumFindHandler FindHandler
        {
            get
            {
                if (findHandler == null)
                {
                    findHandler = new ChromiumFindHandler(browserCore);
                    this.GetFindHandler += (handler, e) => e.SetReturnValue(findHandler);
                }
                return findHandler;
            }
        }

        internal ChromiumFocusHandler FocusHandler
        {
            get
            {
                if (focusHandler == null)
                {
                    focusHandler = new ChromiumFocusHandler(browserCore);
                    this.GetFocusHandler += (handler, e) => e.SetReturnValue(focusHandler);
                }
                return focusHandler;
            }
        }

        internal ChromiumJSDialogHandler JsDialogHandler
        {
            get
            {
                if (jsDialogHandler == null)
                {
                    jsDialogHandler = new ChromiumJSDialogHandler(browserCore);
                    this.GetJsDialogHandler += (handler, e) => e.SetReturnValue(jsDialogHandler);
                }
                return jsDialogHandler;
            }
        }

        internal ChromiumKeyboardHandler KeyboardHandler
        {
            get
            {
                if (keyboardHandler == null)
                {
                    keyboardHandler = new ChromiumKeyboardHandler(browserCore);
                    this.GetKeyboardHandler += (handler, e) => e.SetReturnValue(keyboardHandler);
                }
                return keyboardHandler;
            }
        }

        internal ChromiumLoadHandler LoadHandler
        {
            get
            {
                if (loadHandler == null)
                {
                    loadHandler = new ChromiumLoadHandler(browserCore);
                    this.GetLoadHandler += (handler, e) => e.SetReturnValue(loadHandler);
                }
                return loadHandler;
            }
        }

        internal ChromiumRequestHandler RequestHandler
        {
            get
            {
                if (requestHandler == null)
                {
                    requestHandler = new ChromiumRequestHandler(browserCore);
                    this.GetRequestHandler += (handler, e) => e.SetReturnValue(requestHandler);
                }
                return requestHandler;
            }
        }

        internal ChromiumRenderHandler RenderHandler
        {
            get
            {
                if (renderHandler == null)
                {
                    renderHandler = new ChromiumRenderHandler(browserCore);
                    this.GetRenderHandler += (handler, e) => e.SetReturnValue(renderHandler);
                }
                return renderHandler;
            }
        }
    }
}
