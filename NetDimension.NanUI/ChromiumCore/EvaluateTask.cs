using Chromium.Remote;
using System;
using System.Collections.Generic;

namespace NetDimension.NanUI.ChromiumCore
{
	class EvaluateTask : CfrTask
	{

		// quick fix: cache evaluation tasks so the GC won't
		// collect them before CEF performs the callback (fixes issue #64)
		// TODO: This involves hashing and locking. Is there a faster way to do this?
		private static HashSet<EvaluateTask> tasks = new HashSet<EvaluateTask>();

		IChromiumWebBrowser wb;
		string code;
		JSInvokeMode invokeMode;
		Action<CfrV8Value, CfrV8Exception> callback;

		internal EvaluateTask(IChromiumWebBrowser wb, string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback)
		{
			this.wb = wb;
			this.code = code;
			this.invokeMode = invokeMode;
			this.callback = callback;
			lock (tasks) tasks.Add(this);
			Execute += (s, e) => {
				if (invokeMode == JSInvokeMode.Invoke || (invokeMode == JSInvokeMode.Inherit && wb.RemoteCallbacksWillInvoke))
					wb.RenderThreadInvoke(() => Task_Execute(e));
				else
					Task_Execute(e);
				lock (tasks) tasks.Remove(this);
			};
		}

		void Task_Execute(CfrEventArgs e)
		{
			CfrV8Value retval;
			CfrV8Exception ex;
			bool result = false;
			try
			{
				var context = wb.RemoteBrowser.MainFrame.V8Context;
				result = context.Eval(code, out retval, out ex);
			}
			catch
			{
				callback(null, null);
				return;
			}
			if (result)
			{
				callback(retval, null);
			}
			else
			{
				callback(null, ex);
			}
		}
	}

}
