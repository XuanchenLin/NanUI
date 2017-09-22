using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromium
{
	public partial class CfxWindowInfo
	{

		/// <summary>
		/// Create the browser as a disabled child window.
		/// </summary>
		public void SetAsDisabledChild(IntPtr parentWindow)
		{
			if (CfxApi.PlatformOS == CfxPlatformOS.Windows)
				Style = WindowStyle.WS_CHILD | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_TABSTOP | WindowStyle.WS_DISABLED;
			ParentWindow = parentWindow;
			X = CfxApi.CW_USEDEFAULT;
			Y = CfxApi.CW_USEDEFAULT;
			Width = CfxApi.CW_USEDEFAULT;
			Height = CfxApi.CW_USEDEFAULT;
		}
	}
}
