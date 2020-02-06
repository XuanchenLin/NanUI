using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;
    using System.Windows.Forms;

    public class ChromiumLifeSpanHandler : CfxLifeSpanHandler
    {
        private BrowserCore browser;

        public ChromiumLifeSpanHandler(BrowserCore browser)
        {
            this.browser = browser;
            this.OnAfterCreated += ChromiumLifeSpanHandler_OnAfterCreated;
            this.OnBeforeClose += ChromiumLifeSpanHandler_OnBeforeClose;
            this.OnBeforePopup += ChromiumLifeSpanHandler_OnBeforePopup;
            //this.DoClose += ChromiumLifeSpanHandler_DoClose;
        }

        //private void ChromiumLifeSpanHandler_DoClose(object sender, Chromium.Event.CfxDoCloseEventArgs e)
        //{
            
        //}

        private void ChromiumLifeSpanHandler_OnBeforePopup(object sender, Chromium.Event.CfxOnBeforePopupEventArgs e)
        {

        }

        private void ChromiumLifeSpanHandler_OnBeforeClose(object sender, Chromium.Event.CfxOnBeforeCloseEventArgs e)
        {
            
            var id = e.Browser.Identifier;
            BrowserCore.RemoveBrowserCore(id);
        }

        private void ChromiumLifeSpanHandler_OnAfterCreated(object sender, Chromium.Event.CfxOnAfterCreatedEventArgs e)
        {
            browser.OnBrowserCreated(e.Browser);
        }


    }
}
