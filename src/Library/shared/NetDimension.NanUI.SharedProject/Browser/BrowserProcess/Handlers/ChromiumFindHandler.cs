using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumFindHandler : CfxFindHandler
    {
        private BrowserCore browser;

        public ChromiumFindHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
