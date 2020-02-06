using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumFocusHandler : CfxFocusHandler
    {
        private BrowserCore browser;

        public ChromiumFocusHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
