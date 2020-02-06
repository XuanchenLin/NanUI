using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    using Chromium;

    class BrowserProcessHandler : CfxBrowserProcessHandler
    {
        internal BrowserProcessHandler()
        {
            this.OnBeforeChildProcessLaunch += BrowserProcessHandler_OnBeforeChildProcessLaunch;

        }

        private void BrowserProcessHandler_OnBeforeChildProcessLaunch(object sender, Chromium.Event.CfxOnBeforeChildProcessLaunchEventArgs e)
        {
            e.CommandLine.AppendSwitchWithValue("--host-process-id", System.Diagnostics.Process.GetCurrentProcess().Id.ToString());
            e.CommandLine.AppendSwitchWithValue("--libcef-dir-path", Bootstrap.LibCefDirPath);
        }
    }
}
