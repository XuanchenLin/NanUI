using System;
using NetDimension.NanUI.Internal.Imports;

namespace NetDimension.NanUI.Internal.Extensions
{
	internal static class HitTestExtension
	{
		public static int ToInt(this HitTest handles)
		{
			switch (handles)
			{
				case HitTest.HTNOWHERE:
				case HitTest.HTCAPTION:
					return 0;
				case HitTest.HTLEFT:
					return (int)ResizeDirection.Left;
				case HitTest.HTRIGHT:
					return (int)ResizeDirection.Right;
				case HitTest.HTTOP:
					return (int)ResizeDirection.Top;
				case HitTest.HTTOPLEFT:
					return (int)ResizeDirection.TopLeft;
				case HitTest.HTTOPRIGHT:
					return (int)ResizeDirection.TopRight;
				case HitTest.HTBOTTOM:
					return (int)ResizeDirection.Bottom;
				case HitTest.HTBOTTOMLEFT:
					return (int)ResizeDirection.BottomLeft;
				case HitTest.HTBOTTOMRIGHT:
					return (int)ResizeDirection.BottomRight;
				default:
					return 0;
			}
		}
	}

}
