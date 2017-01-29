using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetDimension.NanUI;

/**
 * 项目说明:
 * cef3是多进程的架构，默认情况下它会使用当前进程再启动另外2个后台进程(与当前进程一模一样)
 * 如果是将cef3以"动态链接库(DLL)或.net程序集"的方式嵌入其它的UI程序里(比如cad、word等)，那么UI主程序将会被多次启动！！！
 * 当然，google的工程师也考虑到这种情况了，进行如下的修改即可：
 * (1) 在初始化cef的时候，指定CefSettings类的browser_subprocess_path参数，比如:
 *      browser_subprocess_path = "NanUI.BrowserSubprocess.exe"
 * 参考1:CefSettings中的browser_subprocess_path参数说明
 * https://bitbucket.org/chromiumembedded/cef/wiki/GeneralUsage#markdown-header-cefsettings
 * 参考2: NanUI.Demo.Welcome/Program.cs中的修改(第23行)
 *      args.Settings.BrowserSubprocessPath = "NanUI.BrowserSubprocess.exe";
 * 
 * (2) 新建子进程项目(项目类型：Windows应用程序),比如: NanUI.BrowserSubprocess项目(本项目)
 * 参考1: Cef3中子进程(browser_subprocess)的说明和参考代码
 * https://bitbucket.org/chromiumembedded/cef/wiki/GeneralUsage#markdown-header-separate-sub-process-executable
 * 参考2: CefSharp项目的CefSharp.BrowserSubprocess子项目
 * https://github.com/cefsharp/CefSharp
 * 
 * 完成上面的2步操作后，cef3启动的时候，将使用browser_subprocess_path参数指定的exe程序来启动另外2个后台进程!!!
 */
namespace NanUI.BrowserSubprocess
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlUILauncher.InitializeChromium(null, null);
        }
    }
}
