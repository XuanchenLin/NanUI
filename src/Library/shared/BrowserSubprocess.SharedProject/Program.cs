using ColoredConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Formium.BrowserSubprocess
{
    using static NetDimension.NanUI.Bootstrap;

    static class Program
    {

        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetConsoleWindow();

        //[DllImport("user32.dll")]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //const int SW_HIDE = 0;
        //const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            //var handle = GetConsoleWindow();

            var libCefPathArg = args?.FirstOrDefault(x => x.StartsWith("--libcef-dir-path"));

            if (libCefPathArg != null)
            {
                var path = libCefPathArg.Split('=');

                if (path.Length == 2)
                {
                    Chromium.CfxRuntime.LibCefDirPath = path[1];
                }

            }
            else
            {
                Chromium.CfxRuntime.LibCefDirPath = LibCefDirPath;

            }

            if (libCefPathArg == null)
            {
                Announce();
                Log("This is a subprocess of ".Gray(), " NanUI ".White().OnDarkRed(), ". It can not be executed without main process.".Gray());
                return;
            }

#if NETCOREAPP
            //Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif


            try
            {
                //ShowWindow(handle, SW_HIDE);

                var retval = ExecuteProcess();
                Environment.Exit(retval);
            }
            catch
            {
                Environment.Exit(-2);
            }



        }
    }
}
