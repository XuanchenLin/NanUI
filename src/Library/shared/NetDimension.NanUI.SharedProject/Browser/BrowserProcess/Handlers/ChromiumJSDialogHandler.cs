using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumJSDialogHandler : CfxJsDialogHandler
    {
        private BrowserCore browser;

        public ChromiumJSDialogHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
