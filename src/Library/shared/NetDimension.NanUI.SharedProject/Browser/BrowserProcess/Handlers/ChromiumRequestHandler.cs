using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumRequestHandler : CfxRequestHandler
    {
        private BrowserCore browser;

        public ChromiumRequestHandler(BrowserCore browser)
        {
            this.browser = browser;

            this.OnRenderProcessTerminated += ChromiumRequestHandler_OnRenderProcessTerminated;
        }

        private void ChromiumRequestHandler_OnRenderProcessTerminated(object sender, Chromium.Event.CfxOnRenderProcessTerminatedEventArgs e)
        {
            browser.OnBrowserCrashed(e.Browser, e.Status);
        }
    }
}
