using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chromium;

namespace NetDimension.NanUI.HostObjects
{
	[JSObject(JSName = "NanUI")]
	public sealed class NanUIHostObject
	{
		private Control hostControl;
		private NanUIVersionHostObject versionObject = new NanUIVersionHostObject();

		internal Form TopForm
		{
			get => hostControl is Form ? (Form)hostControl : (Form)hostControl.TopLevelControl;
		}




		[JSProperty(JSName = "version")]
		public NanUIVersionHostObject Version => versionObject;

		private HostWindow hostWindow;

		[JSProperty(JSName = "hostWindow")]
		public HostWindow HostWindow => hostWindow;

		internal NanUIHostObject(Control hostControl)
		{
			this.hostControl = hostControl;

			hostWindow = new HostWindow(TopForm);
		}

	}

	public sealed class NanUIVersionHostObject
	{
		public string NanUI => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		public string CEF => $"{CfxRuntime.GetCefVersion()} (chromium {CfxRuntime.GetChromeVersion()})";
	}


	public sealed class HostWindow
	{
		Form hostForm;
		public HostWindow(Form topForm)
		{
			hostForm = topForm;
		}

		[JSProperty(JSName = "currentState")]
		public int CurrentWindowState { get; internal set; } = 0;

		[JSFunction(JSName = "minimize")]
		public void ToggleMinimize()
		{

			hostForm.RequireUIThread(() =>
			{
				if (hostForm.WindowState == FormWindowState.Minimized)
				{
					hostForm.WindowState = FormWindowState.Normal;
				}
				else
				{
					hostForm.WindowState = FormWindowState.Minimized;
				}

			});


		}

		[JSFunction(JSName = "maximize")]
		public void ToggleMaximize()
		{
			hostForm.RequireUIThread(() =>
			{

				if (hostForm.WindowState == FormWindowState.Maximized)
				{
					hostForm.WindowState = FormWindowState.Normal;
				}
				else
				{
					hostForm.WindowState = FormWindowState.Maximized;
				}
			});

		}

		[JSFunction(JSName = "restore")]
		public void RestoreNormal()
		{
			hostForm.RequireUIThread(() =>
			{
				hostForm.WindowState = FormWindowState.Normal;

			});

		}

		[JSFunction(JSName = "close")]
		public void Close()
		{
			if (!hostForm.IsDisposed)
			{
				hostForm.RequireUIThread(() =>
				{
					hostForm.Close();

				});
			}
		}


	}
}
