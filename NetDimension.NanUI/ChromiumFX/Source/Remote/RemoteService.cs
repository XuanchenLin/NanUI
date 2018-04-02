// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;

namespace Chromium {
    /// <summary>
    /// Delegate for the main callback of the remote render process.
    /// </summary>
    /// <returns></returns>
    public delegate int CfxRenderProcessMainDelegate();
}

namespace Chromium.Remote {

    internal class RemoteService {

        internal static CfxRenderProcessMainDelegate renderProcessMainCallback;
        
        private static CfxApp m_app;
        private static CfxBrowserProcessHandler m_browserProcessHandler;
        private static readonly List<RemoteConnection> connections = new List<RemoteConnection>();

        internal static void Initialize(CfxRenderProcessMainDelegate renderProcessMainCallback, ref CfxApp app) {

            if(app == null) {
                m_app = new CfxApp();
                app = m_app;
            } else {
                m_app = app;
                m_browserProcessHandler = m_app.RetrieveBrowserProcessHandler();
            }

            if(m_browserProcessHandler == null) {
                m_browserProcessHandler = new CfxBrowserProcessHandler();
                m_app.GetBrowserProcessHandler += (sender, e) => e.SetReturnValue(m_browserProcessHandler);
            }

            RemoteService.renderProcessMainCallback = renderProcessMainCallback;
            m_browserProcessHandler.OnBeforeChildProcessLaunch += OnBeforeChildProcessLaunch;
        }

        private static void OnBeforeChildProcessLaunch(object sender, Chromium.Event.CfxOnBeforeChildProcessLaunchEventArgs e) {

            if(e.CommandLine.HasSwitch("type") && e.CommandLine.GetSwitchValue("type") == "renderer") {
                var pipeName = "cfx" + Guid.NewGuid().ToString().Replace("-", string.Empty);
                var connection = new RemoteConnection(pipeName, false);
                lock(connections) {
                    connections.Add(connection);
                }
                e.CommandLine.AppendSwitchWithValue("cfxremote", pipeName);
            }
        }

        internal static void RemoveConnection(RemoteConnection c) {
            // On shutdown, different threads may try to remove the same connection.
            // Need to lock and check if the connection is still in the list
            lock (connections) {
                if(connections.Contains(c))
                    connections.Remove(c);
            }
        }
    }
}
