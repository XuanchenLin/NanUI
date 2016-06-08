// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using Chromium;
using Chromium.Event;
using Chromium.Remote;
using System;

namespace NetDimension.NanUI.ChromiumCore.Event
{

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
