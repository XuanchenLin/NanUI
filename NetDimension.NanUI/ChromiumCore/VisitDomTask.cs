using Chromium.Remote;
using System;
using System.Windows.Forms;

namespace NetDimension.NanUI.ChromiumCore
{
	public class VisitDomTask : CfrTask
	{

		IChromiumWebBrowser wb;
		Action<CfrDomDocument, CfrBrowser> callback;
		CfrDomVisitor visitor;

		internal VisitDomTask(IChromiumWebBrowser wb, Action<CfrDomDocument, CfrBrowser> callback)
		{
			this.wb = wb;
			this.callback = callback;
			this.Execute += Task_Execute;
			visitor = new CfrDomVisitor();
			visitor.Visit += (s, e) => {
				if (wb.RemoteCallbacksWillInvoke)
					wb.RenderThreadInvoke((MethodInvoker)(() => { callback(e.Document, wb.RemoteBrowser); }));
				else
					callback(e.Document, wb.RemoteBrowser);
			};
		}

		void Task_Execute(object sender, CfrEventArgs e)
		{
			wb.RemoteBrowser.MainFrame.VisitDom(visitor);
		}
	}

}
