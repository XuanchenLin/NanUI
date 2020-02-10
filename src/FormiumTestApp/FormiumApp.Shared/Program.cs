using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormiumApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if NETCOREAPP
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Bootstrap
                .Initialize()
                .WithChromiumCommandLineArguments((procesName, cmd)=> { 
                    // 在此处处理CEF的命令行参数
                    // Process the command line arguments here which are used to config the CEF processes。
                })
                .WithChromiumSettings(settings=> {
                    // 在此处处理CEF的设置
                    // Handle CEF settings here
                })
                //.UseDefaultBrowserSubpress()
                .WhenLibCefNotFound(args => {
                    // 如果NanUI启动器没有检测到正确的CEF以及ChromiumFX运行环境，将执行此处理过程。
                    // This process handler will be performed if the NanUI bootstrapper does not detect correct CEF & ChromiumFX runtime enviroment.


                    MessageBox.Show("没有检测到Chromium Embedded运行环境，请确认libcef环境配置正确。", "libcef.dll is not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // 在此过程中，你可以自己实现检测逻辑（当然高端一点的做法，可以在此实现动态下载的功能）。指定返回LibCefDir参数，启动器会再次检测指定的位置是否符合运行条件，如果符合程序将继续执行，否则将抛出异常。
                    // You can implement the detection logic yourself here. Of course, a high-end approach, you can implement a function to download the cef & cfx from your own server and deploy to any place you like. Specify the return parameter LibCefDir, the bootstrapper will check whether the specified location meets the running conditions again, if it matches, the program will continue to execute, otherwise it will throw an exception.

                    //args.LibCefDir = ""

                })
                .Run(() =>
            {
                // 需要返回一个HostWindow的实例作为主要的启动窗口
                // Need to return a instance of HostWindow as the main window of the application.
                return new MainWindow();
            });
        }

        // If you are using .net core 3.1 singlefile to pack your application, you should use the function below to find correct application running path then give it to NanUI.
        //private static string GetBasePath()
        //{
        //    var processModule = System.Diagnostics.Process.GetCurrentProcess().MainModule;
        //    return System.IO.Path.GetDirectoryName(processModule?.FileName);
        //}
    }
}
