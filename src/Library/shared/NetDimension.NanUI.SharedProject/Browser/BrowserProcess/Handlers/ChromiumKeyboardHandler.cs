using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumKeyboardHandler : CfxKeyboardHandler
    {
        private BrowserCore browser;

        public ChromiumKeyboardHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
