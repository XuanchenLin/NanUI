// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.




using Chromium;

namespace NetDimension.NanUI.ChromiumCore
{
	internal class BrowserClient : CfxClient  {

        internal IChromiumWebBrowser browser;

        internal LifeSpanHandler lifeSpanHandler;
		internal RequestHandler requestHandler;
        
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
		private CfxRenderHandler renderHandler;


        internal BrowserClient(IChromiumWebBrowser browser) {
            this.browser = browser;
            this.lifeSpanHandler = new LifeSpanHandler(this);
            this.requestHandler = new RequestHandler(this);


            this.GetLifeSpanHandler += (s, e) => e.SetReturnValue(lifeSpanHandler);
            this.GetRequestHandler += (s, e) => e.SetReturnValue(requestHandler);
			

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

		internal CfxRenderHandler RenderHandler
		{
			get
			{
				if (renderHandler == null)
				{
					renderHandler = new CfxRenderHandler();
					this.GetRenderHandler += (s, e) => e.SetReturnValue(renderHandler);
				}
				return renderHandler;
			}
		}

		//internal CfxRenderProcessHandler RenderProcessHandler
		//{
		//	get
		//	{
		//		if (renderProcessHandler == null)
		//		{
		//			renderProcessHandler = new CfxRenderProcessHandler();
		//			this.GetRenderProcessHandler += (s, e) => e.SetReturnValue(renderProcessHandler);
		//		}
		//		return renderProcessHandler;
		//	}
		//}
	}
}
