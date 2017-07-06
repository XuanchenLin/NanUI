using NetDimension.NanUI.Internal;
using NetDimension.NanUI.Internal.Imports;
using System;
using System.Windows.Forms;

namespace NetDimension.NanUI.ChromiumCore
{
	internal class JsHostWindowObject : JSObject
	{

		public const string JS_WINDOW_STATE_CHANGED = "(function(){{var event = new CustomEvent('windowstatechanged',{{'detail':{{ state: {0}, width:{1}, height:{2}}}}}); window.dispatchEvent(event);}})();";

		private Form parentForm;
		private IntPtr handle;

		internal JsHostWindowObject(Form parent)
		{
			parentForm = parent;
			handle = parent.Handle;

			var winObj = AddObject("hostWindow");

			winObj.AddFunction("close").Execute += (sender, e) => parentForm.UpdateUI(() => parentForm.Close());
			winObj.AddFunction("minimize").Execute += (sender, e) => parent.UpdateUI(() =>
			{
				parentForm.UpdateUI(() =>
				{
					if (parentForm.WindowState == FormWindowState.Minimized)
					{
						User32.SendMessage(handle, (uint)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_RESTORE, IntPtr.Zero);
					}
					else
					{
						User32.SendMessage(handle, (int)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_MINIMIZE, IntPtr.Zero);
					}
				});
			});
			winObj.AddFunction("maximize").Execute += (sender, e) => parent.UpdateUI(() =>
			{
				parentForm.UpdateUI(() =>
				{
					if (parentForm.WindowState == FormWindowState.Maximized)
					{
						User32.SendMessage(handle, (int)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_RESTORE, IntPtr.Zero);
					}
					else
					{
						User32.SendMessage(handle, (int)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_MAXIMIZE, IntPtr.Zero);
					}
				});
			});

			winObj.AddFunction("restore").Execute += (sender, e) => parent.UpdateUI(() =>
			{
				if (parentForm.WindowState == FormWindowState.Maximized || parentForm.WindowState == FormWindowState.Minimized) {
					User32.SendMessage(handle, (int)WindowsMessages.WM_SYSCOMMAND, (IntPtr)SystemCommandFlags.SC_RESTORE, IntPtr.Zero);
				}
			});
		}

	}
}
