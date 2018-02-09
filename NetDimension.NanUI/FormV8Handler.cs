using Chromium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public sealed class FormV8Handler: CfrV8Handler
	{
		private readonly Form HostForm;
		public FormV8Handler(Form hostForm) {
			HostForm = hostForm;

			Execute += FormV8Handler_Execute;
		}

		private void FormV8Handler_Execute(object sender, Chromium.Remote.Event.CfrV8HandlerExecuteEventArgs e)
		{
			switch (e.Name)
			{
				case "Minimize":
					{
						HostForm.RequireUIThread(() =>
						{
							if (HostForm.WindowState == FormWindowState.Minimized)
							{
								HostForm.WindowState = FormWindowState.Normal;
							}
							else
							{
								HostForm.WindowState = FormWindowState.Minimized;
							}
						});
						
					}
					break;
				case "Maximize":
					{
						HostForm.RequireUIThread(() =>
						{
							if (HostForm.WindowState == FormWindowState.Maximized)
							{
								HostForm.WindowState = FormWindowState.Normal;
							}
							else
							{
								HostForm.WindowState = FormWindowState.Maximized;
							}
						});

					}
					break;
				case "Restore":
					{
						HostForm.RequireUIThread(() =>
						{
							HostForm.WindowState = FormWindowState.Normal;
						});

					}
					break;
				case "Close":
					{
						if(HostForm!=null && !HostForm.IsDisposed)
						{
							HostForm.RequireUIThread(() =>
							{
								HostForm.Close();
							});
						}
					}
					break;
				case "GetWinActivated":
					{
						if (HostForm != null && !HostForm.IsDisposed)
						{
							e.SetReturnValue(CfrV8Value.CreateBool(Form.ActiveForm == HostForm));
							
						}
					}
					break;
				case "GetWinState":
					{
						if (HostForm != null && !HostForm.IsDisposed)
						{
							var obj = CfrV8Value.CreateObject(new CfrV8Accessor());
							var stateString = "normal";
							var currentState = 0;

							if(HostForm.WindowState == FormWindowState.Maximized)
							{
								currentState = 2;
								stateString = "maximized";
							}
							else if(HostForm.WindowState == FormWindowState.Minimized)
							{
								currentState = 1;
								stateString = "minimized";
							}

							obj.SetValue("state", CfrV8Value.CreateInt(currentState), Chromium.CfxV8PropertyAttribute.ReadOnly | Chromium.CfxV8PropertyAttribute.DontDelete);
							obj.SetValue("stateName", CfrV8Value.CreateString(stateString), Chromium.CfxV8PropertyAttribute.ReadOnly | Chromium.CfxV8PropertyAttribute.DontDelete);
							obj.SetValue("width", CfrV8Value.CreateInt(HostForm.ClientSize.Width), Chromium.CfxV8PropertyAttribute.ReadOnly | Chromium.CfxV8PropertyAttribute.DontDelete);
							obj.SetValue("height", CfrV8Value.CreateInt(HostForm.ClientSize.Height), Chromium.CfxV8PropertyAttribute.ReadOnly | Chromium.CfxV8PropertyAttribute.DontDelete);

							e.SetReturnValue(obj);
						}
					}
					break;
			}
		}
	}
}
