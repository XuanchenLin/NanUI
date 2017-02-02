using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using NetDimension.NanUI;

namespace NanUI.Demo.VueDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HtmlUILauncher.EnableFlashSupport = true;

            if (HtmlUILauncher.InitializeChromium((args =>
            {
                args.Settings.LogSeverity = Chromium.CfxLogSeverity.Default;
                args.Settings.BrowserSubprocessPath = "NanUI.BrowserSubprocess.exe";
            }), 
            
            (args) =>
            {
                // 禁用代理服务器
                args.CommandLine.AppendArgument("no-proxy-server");
            }))
            {
                //初始化成功，加载程序集内嵌的资源到运行时中
                HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly(), "embedded", null);

                //启动主窗体
                Application.Run(new Form1());
            }
        }
    }
}
