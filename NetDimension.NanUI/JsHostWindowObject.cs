using NetDimension.NanUI.Internal;
using System;
using System.Windows.Forms;

namespace NetDimension.NanUI.ChromiumCore
{
	internal class JsHostWindowObject : JSObject
	{
		private Form parentForm;
		private IntPtr handle;

		internal JsHostWindowObject(Form parent)
		{
			parentForm = parent;
			handle = parent.Handle;

			var winObj = AddObject("hostWindow");

			winObj.AddFunction("close").Execute += (sender, e) => parentForm.UpdateUI(() => parentForm.Close());
			winObj.AddFunction("minimize").Execute += (sender, e) => parent.UpdateUI(() => {
				parentForm.UpdateUI(() =>
				{
					if (parentForm.WindowState == FormWindowState.Minimized)
					{
						NativeMethods.SendMessage(handle, NativeMethods.WindowsMessage.WM_SYSCOMMAND, (IntPtr)NativeMethods.SysCommand.SC_RESTORE, IntPtr.Zero);
					}
					else
					{
						NativeMethods.SendMessage(handle, NativeMethods.WindowsMessage.WM_SYSCOMMAND, (IntPtr)NativeMethods.SysCommand.SC_MINIMIZE, IntPtr.Zero);
					}
				});
			});
			winObj.AddFunction("maximize").Execute += (sender, e) => parent.UpdateUI(() => {
				parentForm.UpdateUI(() =>
				{
					if (parentForm.WindowState == FormWindowState.Maximized)
					{
						NativeMethods.SendMessage(handle, NativeMethods.WindowsMessage.WM_SYSCOMMAND, (IntPtr)NativeMethods.SysCommand.SC_RESTORE, IntPtr.Zero);
					}
					else
					{
						NativeMethods.SendMessage(handle, NativeMethods.WindowsMessage.WM_SYSCOMMAND, (IntPtr)NativeMethods.SysCommand.SC_MAXIMIZE, IntPtr.Zero);
					}
				});
			});
		}

	}
}
