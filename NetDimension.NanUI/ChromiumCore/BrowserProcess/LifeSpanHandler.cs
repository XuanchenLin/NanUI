// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using Chromium;
using Chromium.Event;

namespace Chromium.WebBrowser {
    internal class LifeSpanHandler : CfxLifeSpanHandler {

        internal BrowserClient client;

        internal LifeSpanHandler(BrowserClient client) {
            this.client = client;

            this.OnAfterCreated += new CfxOnAfterCreatedEventHandler(LifeSpanHandler_OnAfterCreated);
        }

        void LifeSpanHandler_OnAfterCreated(object sender, CfxOnAfterCreatedEventArgs e) {
            client.browser.OnBrowserCreated(e);
        }
        
        
    }
}
