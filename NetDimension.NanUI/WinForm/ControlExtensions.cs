using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public static class ControlExtensions
	{
		public static void RequireUIThread(this Control control, Delegate action, params object[] args)
		{
			if (control.InvokeRequired)
			{
				control.BeginInvoke(action, args);
			}
			else
			{
				action.DynamicInvoke(args);
			}
		}

		public static void RequireUIThread(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.BeginInvoke(action);
			}
			else
			{
				action?.Invoke();
			}
		}
	}
}
