using Chromium;
using ColoredConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    class NanUIApp : CfxApp
    {
        readonly Bootstrap globalConfiguration;
        private readonly BrowserProcessHandler processHandler;

        public NanUIApp(Bootstrap globalConfiguration)
        {
            this.globalConfiguration = globalConfiguration;

            processHandler = new BrowserProcessHandler();

            this.GetBrowserProcessHandler += App_GetBrowserProcessHandler;

            this.OnBeforeCommandLineProcessing += App_OnBeforeCommandLineProcessing;

            this.OnRegisterCustomSchemes += App_OnRegisterCustomSchemes;


        }

        private void App_OnRegisterCustomSchemes(object sender, Chromium.Event.CfxOnRegisterCustomSchemesEventArgs e)
        {
            BrowserCore.RaiseOnRegisterCustomSchemes(e);
        }

        private void App_OnBeforeCommandLineProcessing(object sender, Chromium.Event.CfxOnBeforeCommandLineProcessingEventArgs e)
        {
            var command = e.CommandLine;

            command.AppendSwitchWithValue("default-encoding", "utf-8");
            command.AppendSwitch("allow-file-access-from-files");
            command.AppendSwitch("allow-universal-access-from-files");
            command.AppendSwitch("disable-web-security");
            command.AppendSwitch("ignore-certificate-errors");

            foreach (var action in globalConfiguration.CommandLineBuildActions)
            {
                action?.Invoke(e.ProcessType, command);
            }

            if (Bootstrap.IsDebugModeEnabled)
            {
                Bootstrap.Log("Command Line Arguments ->".Gray());
                Bootstrap.Text(command.CommandLineString);
            }


            

        }

        private void App_GetBrowserProcessHandler(object sender, Chromium.Event.CfxGetBrowserProcessHandlerEventArgs e)
        {
            e.SetReturnValue(processHandler);
        }
    }
}
