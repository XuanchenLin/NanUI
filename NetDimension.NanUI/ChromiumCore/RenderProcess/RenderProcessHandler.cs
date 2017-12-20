// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using Chromium;
using Chromium.Remote;
using Chromium.Remote.Event;

namespace Chromium.WebBrowser {
	internal class RenderProcessHandler : CfrRenderProcessHandler {

		private readonly RenderProcess remoteProcess;

		internal RenderProcessHandler(RenderProcess remoteProcess) {
			this.remoteProcess = remoteProcess;

			this.OnContextCreated += RenderProcessHandler_OnContextCreated;
			this.OnBrowserCreated += RenderProcessHandler_OnBrowserCreated;
			this.OnWebKitInitialized += RenderProcessHandler_OnWebKitInitialized;
		}

		private void RenderProcessHandler_OnWebKitInitialized(object sender, CfrEventArgs e)
		{
			
		}

		void RenderProcessHandler_OnBrowserCreated(object sender, CfrOnBrowserCreatedEventArgs e) {
			var id = e.Browser.Identifier;
			var wb = BrowserCore.GetBrowser(id);
			if(wb != null) {

				var rp = wb.remoteProcess;
				if(rp != null && rp != this.remoteProcess) {
					// A new process has been created for the browser.
					// The old process is still alive, but probably it gets
					// killed soon after this callback returns.
					// So we suspend all callbacks from the old process.
					// If there are currently executing callbacks, 
					// this call will block until they are finished. 
					// When this call returns, it should be safe to 
					// continue execution and let the old process die.
					CfxRemoteCallbackManager.SuspendCallbacks(rp.RemoteProcessId);
				}

				wb.SetRemoteBrowser(e.Browser, remoteProcess);
			}
		}

		void RenderProcessHandler_OnContextCreated(object sender, CfrOnContextCreatedEventArgs e) {
			var wb = BrowserCore.GetBrowser(e.Browser.Identifier);
			if(wb != null) {
				if(e.Frame.IsMain) {
					SetProperties(e.Context, wb.GlobalObject);
				} else {
					JSObject obj;
					if(wb.frameGlobalObjects.TryGetValue(e.Frame.Name, out obj)) {
						SetProperties(e.Context, obj);
					}
				}
				wb.RaiseOnV8ContextCreated(e);
			}
		}

		private void SetProperties(CfrV8Context context, JSObject obj) {
			foreach(var p in obj) {
				var v8Value = p.Value.GetV8Value(context);
				context.Global.SetValue(p.Key, v8Value, CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);
			}
		}
	}
}
