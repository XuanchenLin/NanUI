// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using Chromium.Remote;
using Chromium.Remote.Event;

namespace Chromium.WebBrowser {
	internal class RenderProcess {

		internal static int RenderProcessMain() {
			try {
				var rp = new RenderProcess();
				BrowserCore.RaiseRemoteProcessCreated(rp.processHandler);
				return rp.RemoteMain();
			} catch(CfxRemotingException) {
				return -1;
			}
		}

		private readonly CfrApp app;
		private readonly RenderProcessHandler processHandler;

		private List<WeakReference> browserReferences = new List<WeakReference>();

		internal int RemoteProcessId { get; private set; }

		private RenderProcess() {
			RemoteProcessId = CfxRemoteCallContext.CurrentContext.ProcessId;
			app = new CfrApp();
			processHandler = new RenderProcessHandler(this);
			app.GetRenderProcessHandler += (s, e) => e.SetReturnValue(processHandler);
		}

		internal void AddBrowserReference(BrowserCore browser) {
			for(int i = 0; i < browserReferences.Count; ++i) {
				if(browserReferences[i].Target == null) {
					browserReferences[i] = new WeakReference(browser);
					return;
				}
			}
			browserReferences.Add(new WeakReference(browser));
		}

		private int RemoteMain() {
			try {
				var retval = CfrRuntime.ExecuteProcess(app);
				return retval;
			} finally {
				foreach(var br in browserReferences) {
					var b = (BrowserCore)br.Target;
					b?.RemoteProcessExited(this);
				}
			}
		}

	}
}
