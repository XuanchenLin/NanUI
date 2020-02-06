using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumContextMenuHandler : CfxContextMenuHandler
    {
        private BrowserCore browser;

        public ChromiumContextMenuHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
