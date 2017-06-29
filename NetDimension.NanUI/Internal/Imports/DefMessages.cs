using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Internal.Imports
{
	public enum DefMessages
	{
		WM_CEF_DRAG_APP = WindowsMessages.WM_USER + 1000,
		WM_CEF_RESIZE_CLIENT = WindowsMessages.WM_USER + 1001,
		WM_CEF_EDGE_MOVE = WindowsMessages.WM_USER + 1002,
		WM_CEF_TITLEBAR_LBUTTONDBCLICK = WindowsMessages.WM_USER + 1003,
		WM_CEF_INVALIDATE_WINDOW = WindowsMessages.WM_USER + 1004
	}
}
