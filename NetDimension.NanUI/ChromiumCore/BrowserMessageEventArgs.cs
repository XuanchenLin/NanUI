using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chromium.WebBrowser
{
	public class BrowserMessageEventArgs : EventArgs
	{
		public bool Handled { get; set; }
		public Message BrowserMessage { get; set; }

		public BrowserMessageEventArgs(ref Message message) {
			BrowserMessage = message;
		}
	}
}
