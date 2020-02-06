using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumLoadHandler : CfxLoadHandler
    {
        private BrowserCore browser;

        public ChromiumLoadHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
