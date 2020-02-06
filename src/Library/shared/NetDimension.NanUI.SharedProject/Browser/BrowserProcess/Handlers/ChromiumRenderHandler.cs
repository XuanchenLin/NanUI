using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumRenderHandler : CfxRenderHandler
    {
        private BrowserCore browser;

        public ChromiumRenderHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
