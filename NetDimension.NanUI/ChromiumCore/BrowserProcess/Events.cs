// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using Chromium;
using Chromium.Event;
using Chromium.Remote;

namespace Chromium.WebBrowser.Event {

    public delegate void OnBeforeCommandLineProcessingEventHandler(CfxOnBeforeCommandLineProcessingEventArgs e);
    public delegate void OnRegisterCustomSchemesEventHandler(CfxOnRegisterCustomSchemesEventArgs e);
    public delegate void OnBeforeCfxInitializeEventHandler(OnBeforeCfxInitializeEventArgs e);
    [Obsolete()]
    public delegate void OnRemoteContextCreatedEventHandler(EventArgs e);
    
    public class OnBeforeCfxInitializeEventArgs : EventArgs {
        public CfxSettings Settings { get; private set; }
        public CfxBrowserProcessHandler ProcessHandler { get; private set; }
        internal OnBeforeCfxInitializeEventArgs(CfxSettings settings, CfxBrowserProcessHandler processHandler) {
            Settings = settings;
            ProcessHandler = processHandler;
        }
    }

    public delegate void BrowserCreatedEventHandler(object sender, BrowserCreatedEventArgs e);

    public class BrowserCreatedEventArgs : EventArgs {
        public CfxBrowser Browser { get; private set; }
        internal BrowserCreatedEventArgs(CfxBrowser browser) {
            Browser = browser;
        }
    }

    public delegate void RemoteProcessCreatedEventHandler(RemoteProcessCreatedEventArgs e);

    public class RemoteProcessCreatedEventArgs : EventArgs {
        public CfrRenderProcessHandler RenderProcessHandler { get; private set; }
        internal RemoteProcessCreatedEventArgs(CfrRenderProcessHandler renderProcessHandler) {
            RenderProcessHandler = renderProcessHandler;
        }
    }

    public delegate void RemoteBrowserCreatedEventHandler(object sender, RemoteBrowserCreatedEventArgs e);

    public class RemoteBrowserCreatedEventArgs : EventArgs {
        public CfrBrowser Browser { get; private set; }
        internal RemoteBrowserCreatedEventArgs(CfrBrowser browser) {
            Browser = browser;
        }
    }

}
