using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI.Logging;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    class BrowserProcessHandler : CefBrowserProcessHandler
    {
        ILogger logger => WinFormium.GetLogger();

        internal BrowserProcessHandler()
        {

        }

        protected override void OnBeforeChildProcessLaunch(CefCommandLine commandLine)
        {


            commandLine.AppendSwitch("default-encoding", "utf-8");
            commandLine.AppendArgument("--allow-file-access-from-files");
            commandLine.AppendArgument("--allow-universal-access-from-files");
            commandLine.AppendArgument("--disable-web-security");
            commandLine.AppendArgument("--ignore-certificate-errors");


            //WinFormium.Runtime.ChromiumEnvironment.CommandLineConfigurations?.Invoke(commandLine);

            commandLine.AppendSwitch("--libcef-dir-path", WinFormium.Runtime.ChromiumEnvironment.LibCefDir);
            commandLine.AppendSwitch("--host-process-id", System.Diagnostics.Process.GetCurrentProcess().Id.ToString());

            if (WinFormium.Runtime.IsDebuggingMode)
            {
                logger.Debug("On CefGlue child process launch arguments:");
                logger.Verbose(commandLine.ToString());
            }


        }

        
    }
}
