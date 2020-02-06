using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumDialogHandler : CfxDialogHandler
    {
        private BrowserCore browser;

        public ChromiumDialogHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
