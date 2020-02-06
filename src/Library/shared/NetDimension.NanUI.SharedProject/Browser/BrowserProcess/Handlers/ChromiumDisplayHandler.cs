using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumDisplayHandler : CfxDisplayHandler
    {
        private BrowserCore browser;

        public ChromiumDisplayHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
