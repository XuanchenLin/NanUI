using Chromium;
using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    class DevToolBrowserClient : CfxClient
    {
        private readonly CfxLifeSpanHandler LifeSpanHandler;

        public DevToolBrowserClient()
        {
            LifeSpanHandler = new CfxLifeSpanHandler();

            this.GetLifeSpanHandler += (_, e) => { e.SetReturnValue(LifeSpanHandler); };



            LifeSpanHandler.OnAfterCreated += LifeSpanHandler_OnAfterCreated;

            LifeSpanHandler.OnBeforePopup += LifeSpanHandler_OnBeforePopup;
        }

        private void LifeSpanHandler_OnBeforePopup(object sender, Chromium.Event.CfxOnBeforePopupEventArgs e)
        {
            
        }

        private void LifeSpanHandler_OnAfterCreated(object sender, Chromium.Event.CfxOnAfterCreatedEventArgs e)
        {
            var windowHandle = e.Browser.Host.WindowHandle;
            User32.SendMessage(windowHandle, (uint)WindowsMessages.WM_SETICON, (IntPtr)1, Properties.Resources.DevToolsIcon.Handle);
        }
    }
}
