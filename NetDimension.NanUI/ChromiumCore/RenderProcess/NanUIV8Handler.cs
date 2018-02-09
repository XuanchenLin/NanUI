using Chromium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromium.WebBrowser
{
	internal class NanUIV8Handler : CfrV8Handler
	{
		public NanUIV8Handler()
		{
			Execute += NanUIV8Handler_Execute;
		}

		private void NanUIV8Handler_Execute(object sender, Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			if (e.Name == "GetVersion")
			{
				e.SetReturnValue(CfrV8Value.CreateString(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
			}

		}

	}
}
