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
using Chromium.Remote;
using Chromium.Remote.Event;

namespace NetDimension.NanUI.ChromiumCore
{
	internal class RenderProcessHandler : CfrRenderProcessHandler
	{

		private readonly RenderProcess remoteProcess;

		internal RenderProcessHandler(RenderProcess remoteProcess)
		{
			this.remoteProcess = remoteProcess;

			this.OnContextCreated += RenderProcessHandler_OnContextCreated;
			this.OnBrowserCreated += RenderProcessHandler_OnBrowserCreated;
			this.OnWebKitInitialized += RenderProcessHandler_OnWebKitInitialized;
		}

		private void RenderProcessHandler_OnWebKitInitialized(object sender, CfrEventArgs e)
		{
			//var result = CfrRuntime.RegisterExtension("NanUI/extensions", Properties.Resources.ExtensionScripts, null);
		}

		void RenderProcessHandler_OnUncaughtException(object sender, CfrOnUncaughtExceptionEventArgs e)
		{
			var wb = HtmlUILauncher.GetBrowser(e.Browser.Identifier);
			if (wb != null)
			{

			}
		}

		void RenderProcessHandler_OnBrowserCreated(object sender, CfrOnBrowserCreatedEventArgs e)
		{
			var id = e.Browser.Identifier;
			var wb = HtmlUILauncher.GetBrowser(id);
			if (wb != null)
			{

				var rp = wb.RemoteProcess;
				if (rp != null && rp != this.remoteProcess)
				{
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

		void RenderProcessHandler_OnContextCreated(object sender, CfrOnContextCreatedEventArgs e)
		{
			var wb = HtmlUILauncher.GetBrowser(e.Browser.Identifier);
			if (wb != null)
			{
				if (e.Frame.IsMain)
				{
					SetProperties(e.Context, wb.GlobalObject);
					e.Frame.ExecuteJavaScript(Properties.Resources.InitialScripts, e.Frame.Url, 0);
				}
				else
				{
					JSObject obj;
					if (wb.FrameGlobalObjects.TryGetValue(e.Frame.Name, out obj))
					{
						SetProperties(e.Context, obj);
					}
				}

				wb.RaiseOnV8ContextCreated(e);
			}
		}

		private void SetProperties(CfrV8Context context, JSObject obj)
		{
			foreach (var p in obj)
			{
				var v8Value = p.Value.GetV8Value(context);
				context.Global.SetValue(p.Key, v8Value, CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);
			}
		}
	}
}
