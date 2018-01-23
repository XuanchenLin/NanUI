// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using Chromium;
using Chromium.Event;

namespace Chromium.WebBrowser {
    internal class BrowserClient : CfxClient  {

        internal BrowserCore browser;

		private CfxLifeSpanHandler lifeSpanHandler;
		private CfxRequestHandler requestHandler;
		private CfxContextMenuHandler contextMenuHandler;
        private CfxLoadHandler loadHandler;
        private CfxDisplayHandler displayHandler;
        private CfxDownloadHandler downloadHandler;
        private CfxDragHandler dragHandler;
        private CfxDialogHandler dialogHandler;
        private CfxFindHandler findHandler;
        private CfxFocusHandler focusHandler;
        private CfxGeolocationHandler geolocationHandler;
        private CfxJsDialogHandler jsDialogHandler;
        private CfxKeyboardHandler keyboardHandler;

        internal BrowserClient(BrowserCore browser) {
            this.browser = browser;
			lifeSpanHandler = new CfxLifeSpanHandler();

			lifeSpanHandler.OnAfterCreated += (handler, e) => this.browser.OnBrowserCreated(e);
			lifeSpanHandler.OnBeforePopup += (handler, e) =>
			{
				var windowinfo = e.WindowInfo;
				//fix: the popup window show on incorrect position
			};
			this.GetLifeSpanHandler += (handler, e) => e.SetReturnValue(lifeSpanHandler);
		}
		internal CfxLifeSpanHandler LifeSpanHandler
		{
			get
			{
				return lifeSpanHandler;
			}
		}

		internal CfxRequestHandler RequestHandler
		{
			get
			{
				if (requestHandler == null)
				{
					requestHandler = new CfxRequestHandler();
					this.GetRequestHandler += (handler, e) => e.SetReturnValue(requestHandler);
				}
				return requestHandler;
			}
		}

        internal CfxContextMenuHandler ContextMenuHandler {
            get {
                if(contextMenuHandler == null) {
                    contextMenuHandler = new CfxContextMenuHandler();
                    this.GetContextMenuHandler += (s, e) => e.SetReturnValue(contextMenuHandler);
                }
                return contextMenuHandler;
            }
        }

        internal CfxLoadHandler LoadHandler {
            get {
                if(loadHandler == null) {
                    loadHandler = new CfxLoadHandler();
                    this.GetLoadHandler += (s, e) => e.SetReturnValue(loadHandler);
                }
                return loadHandler;
            }
        }

        internal CfxDisplayHandler DisplayHandler {
            get {
                if(displayHandler == null) {
                    displayHandler = new CfxDisplayHandler();
                    this.GetDisplayHandler += (s, e) => e.SetReturnValue(displayHandler);
                }
                return displayHandler;
            }
        }

        internal CfxDownloadHandler DownloadHandler {
            get {
                if(downloadHandler == null) {
                    downloadHandler = new CfxDownloadHandler();
                    this.GetDownloadHandler += (s, e) => e.SetReturnValue(downloadHandler);
                }
                return downloadHandler;
            }
        }

        internal CfxDragHandler DragHandler {
            get {
                if(dragHandler == null) {
                    dragHandler = new CfxDragHandler();
                    this.GetDragHandler += (s, e) => e.SetReturnValue(dragHandler);
                }
                return dragHandler;
            }
        }

        internal CfxDialogHandler DialogHandler {
            get {
                if(dialogHandler == null) {
                    dialogHandler = new CfxDialogHandler();
                    this.GetDialogHandler += (s, e) => e.SetReturnValue(dialogHandler);
                }
                return dialogHandler;
            }
        }

        internal CfxFindHandler FindHandler {
            get {
                if(findHandler == null) {
                    findHandler = new CfxFindHandler();
                    this.GetFindHandler += (s, e) => e.SetReturnValue(findHandler);
                }
                return findHandler;
            }
        }

        internal CfxFocusHandler FocusHandler {
            get {
                if(focusHandler == null) {
                    focusHandler = new CfxFocusHandler();
                    this.GetFocusHandler += (s, e) => e.SetReturnValue(focusHandler);
                }
                return focusHandler;
            }
        }

        internal CfxGeolocationHandler GeolocationHandler {
            get {
                if(geolocationHandler == null) {
                    geolocationHandler = new CfxGeolocationHandler();
                    this.GetGeolocationHandler += (s, e) => e.SetReturnValue(geolocationHandler);
                }
                return geolocationHandler;
            }
        }

        internal CfxJsDialogHandler JsDialogHandler {
            get {
                if(jsDialogHandler == null) {
                    jsDialogHandler = new CfxJsDialogHandler();
                    this.GetJsDialogHandler += (s, e) => e.SetReturnValue(jsDialogHandler);
                }
                return jsDialogHandler;
            }
        }

        internal CfxKeyboardHandler KeyboardHandler {
            get {
                if(keyboardHandler == null) {
                    keyboardHandler = new CfxKeyboardHandler();
                    this.GetKeyboardHandler += (s, e) => e.SetReturnValue(keyboardHandler);
                }
                return keyboardHandler;
            }
        }
    }
}
