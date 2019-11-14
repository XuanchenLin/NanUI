using Chromium.Remote;
using Chromium.WebBrowser;
using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public class WebBrowserFormImplement
	{
		Form parentForm;
		BrowserCore browserCore;
		private FormV8Handler formV8Handler;
		private Dictionary<string, string> delayedScripts = new Dictionary<string, string>();
		private bool CanResize => parentForm.FormBorderStyle == FormBorderStyle.SizableToolWindow || parentForm.FormBorderStyle == FormBorderStyle.Sizable;

		

		protected IntPtr BrowserHandle
		{
			get
			{
				return browserCore.BrowserHost.WindowHandle;
			}
		}




		public WebBrowserFormImplement(Form form, BrowserCore browser)
		{
			parentForm = form;
			browserCore = browser;


			browser.RemoteBrowserCreated += (_,e)=> {
				formV8Handler = new FormV8Handler(parentForm);
#if XP
				CfrRuntime.RegisterExtension("nanui/form", NetDimension.NanUI.XP.Properties.Resources.nanui_formExtension, formV8Handler);
#else
				CfrRuntime.RegisterExtension("nanui/form", NetDimension.NanUI.Properties.Resources.nanui_formExtension, formV8Handler);
#endif
			};
			browser.LoadHandler.OnLoadEnd += (_, e) => {
				if (e.Frame.IsMain)
				{
					foreach (var script in delayedScripts)
					{
						browserCore.ExecuteJavascript(script.Value);
					}
				}
			};


			form.Move += (_, e) =>
			{
				if(browserCore!=null && browserCore.BrowserHost != null)
				{
					browserCore.BrowserHost.NotifyMoveOrResizeStarted();
				}
			};


			

			RegisterActivatedStateChangedHandler();
			RegisterSizeChangedEventHandler();
		}
		protected void RegisterActivatedStateChangedHandler()
		{
			parentForm.Activated += (s, e) =>
			{
				var js = "raiseCustomEvent('hostactivestate', {state:1, stateName:'activated'})";


				if (browserCore == null || !browserCore.IsMainFrameLoaded || !browserCore.ExecuteJavascript(js))
				{
					delayedScripts["hostactivestate"] = js;
				}

			};

			parentForm.Deactivate += (s, e) =>
			{
				var js = "raiseCustomEvent('hostactivestate', {state:0, stateName:'deactivated'})";
				if (browserCore == null || !browserCore.IsMainFrameLoaded || !browserCore.ExecuteJavascript(js))
				{
					delayedScripts["hostactivestate"] = js;
				}
			};
		}

		protected void RegisterSizeChangedEventHandler()
		{
			parentForm.SizeChanged += (s, e) =>
			{
				var currentState = 0;
				var stateString = "normal";

				if (parentForm.WindowState == FormWindowState.Maximized)
				{
					currentState = 2;
					stateString = "maximized";

				}
				else if (parentForm.WindowState == FormWindowState.Minimized)
				{

					currentState = 1;
					stateString = "minimized";
				}


				var rect = new RECT();
				User32.GetClientRect(parentForm.Handle, ref rect);


				var js = $"raiseCustomEvent('hoststatechange', " +
						$"{{" +
						$"state: {currentState}," +
						$"stateName: \"{stateString}\"," +
						$"width: {rect.Width}," +
						$"height: {rect.Height}" +
						$"}});" +
						$"raiseCustomEvent('hostsizechange', " +
						$"{{" +
						$"width: {rect.Width}," +
						$"height: {rect.Height}" +
						$"}});";


				if (browserCore == null || !browserCore.IsMainFrameLoaded || !browserCore.ExecuteJavascript(js))
				{
					delayedScripts["hoststatechange"] = js;
				}
				else
				{
					browserCore.BrowserHost.NotifyMoveOrResizeStarted();
				}

			};
		}







	}
}
