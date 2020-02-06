using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumDragHandler : CfxDragHandler
    {
        private BrowserCore browser;

        public ChromiumDragHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
