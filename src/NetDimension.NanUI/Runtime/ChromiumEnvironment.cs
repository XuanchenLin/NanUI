using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.Browser;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{
    public class ChromiumEnvironment
    {
        public string LibCefDir { get; internal set; }
        public string LibCefResourceDir { get; internal set; }
        public string LibCefLocaleDir { get; internal set; }
        public string SubprocessPath { get; internal set; }
        public bool ForceHighDpiSupportDisabled { get; internal set; }
        internal Action<CefCommandLine> CommandLineConfigurations { get; set; }
        internal Action<CefSettings> SettingConfigurations { get; set; }
        internal Action<CefBrowserSettings> CefBrowserSettingConfigurations { get; set; }
    }

}
