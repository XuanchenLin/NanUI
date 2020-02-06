using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser.Handlers
{
    using Chromium;

    public class ChromiumDownloadHandler : CfxDownloadHandler
    {
        private BrowserCore browser;

        public ChromiumDownloadHandler(BrowserCore browser)
        {
            this.browser = browser;
        }
    }
}
