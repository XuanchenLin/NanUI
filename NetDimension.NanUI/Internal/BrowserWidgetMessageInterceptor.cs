using System;
using System.Windows.Forms;

namespace NetDimension.NanUI.Internal
{
	internal class BrowserWidgetMessageInterceptor : NativeWindow
	{
		private Func<Message, bool> forwardAction;

		internal BrowserWidgetMessageInterceptor(Control browser, IntPtr chromeHostHandle, Func<Message, bool> forwardAction)
		{
			AssignHandle(chromeHostHandle);
			browser.HandleDestroyed += BrowserHandleDestroyed;
			this.forwardAction = forwardAction;
		}

		private void BrowserHandleDestroyed(object sender, EventArgs e)
		{
			ReleaseHandle();
			var browser = (Control)sender;
			browser.HandleDestroyed -= BrowserHandleDestroyed;
			forwardAction = null;
		}

		protected override void WndProc(ref Message m)
		{
			var result = forwardAction(m);

			if (!result)
			{
				base.WndProc(ref m);
			}
			

		}
	}
}
