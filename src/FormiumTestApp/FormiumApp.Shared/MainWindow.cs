using NetDimension.NanUI;
using NetDimension.NanUI.Browser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FormiumApp
{
    class MainWindow : Formium
    {
        // 设置承载窗口启动时加载的网址
        // Set the startup url of this window
        public override string StartUrl => "https://www.bing.com";

        // 设置承载窗口的样式，此处设置为使用原生样式的窗口
        // Set the style of the host window, here set window to use the native style 
        public override HostWindowType WindowType =>  HostWindowType.Borderless;

        // 如果需要在首次加载网页时添加启动屏幕，在此处返回启动屏幕的控件实例
        // If you need to add a splash screen when the web page is first loaded, return the control instance of the splash screen here
        protected override Control LaunchScreen => null;

        public MainWindow()
        {
            // 设置窗口基础标题
            // Set the base title of the window
            Title = "NanUI Application";
        }

        // 浏览器核心准备就绪
        protected override void OnWindowReady(IWebBrowserHandler browserClient)
        {
            // 在此处添加CEF客户端各项行文的处理子程序，例如：下载（通常使用DownloadHandler处理下载过程）、弹窗（LiftSpanHandler）、信息显示（DisplayHandler）等等
            // Add the processing functions of the CefClient's handlers here, such as DownloadHandler， LifeSpanHandler, DisplayHandler, etc. 


            // 示例： 处理浏览器的弹窗行为。如果不特别指定弹窗行为，CEF将会自行弹出一个无法控制浏览器窗口，你无法为CEF创建的这个窗口指定任何处理子程序。
            // Example: Handle browser's popup behavior. If you don't specify the popup behavior handler, CEF will pop up a window that cannot controlled. You cannot specify any processing functions for this window created by CEF.
            browserClient.LifeSpanHandler.OnBeforePopup += LifeSpanHandler_OnBeforePopup;


            // 示例：处理浏览器的下载行为。如果不指定下载处理过程，那么浏览器将不会处理任何来自网页的下载请求。
            // Example: Handle browser's download behavior. If you don't specify the download behavior handler,  you could not donwload anything from the webpage.
            browserClient.DownloadHandler.OnBeforeDownload += DownloadHandler_OnBeforeDownload;

            // 示例：处理浏览器的加载行为。
            // Example: Handle browser's load behavior.
            browserClient.LoadHandler.OnLoadEnd += LoadHandler_OnLoadEnd;

            browserClient.DisplayHandler.OnTitleChange += DisplayHandler_OnTitleChange;


            // 当主页面加载完成后，打开Chromium的开发者工具。
            // When the main page is loadded, open the developer's tool
            // WebBrowser.ShowDevTools();

        }

        private void DisplayHandler_OnTitleChange(object sender, Chromium.Event.CfxOnTitleChangeEventArgs e)
        {
            this.Subtitle = e.Title;
        }

        // 浏览器Javascript环境初始化完成
        // Browser's Javascript context initialization is complete
        protected override void OnRegisterGlobalObject(JSObject global)
        {
            // 可以在此处将C#对象注入到当前窗口的JS上下文中
            // The C# objects can be injected into Javascript Context of this window here
        }

        protected override void OnStandardFormStyle(IStandardHostWindowStyle style)
        {
            base.OnStandardFormStyle(style);

            // 在此处定义标准窗口的基础样式
            // Define the basic style of the standard window here

            style.MinimumSize = new System.Drawing.Size(1024, 640);
            style.Size = new System.Drawing.Size(1280, 720);
            style.Icon = Properties.Resources.Chromium;
            style.StartPosition = FormStartPosition.CenterScreen;

        }

        protected override void OnBorderlessFormStyle(IBorderlessHostWindowStyle style)
        {
            base.OnBorderlessFormStyle(style);

            // style.MinimumSize = new System.Drawing.Size(1024, 640);
            style.Size = new System.Drawing.Size(1280, 720);
            style.Icon = Properties.Resources.Chromium;
            style.StartPosition = FormStartPosition.CenterScreen;
        }


        private void LoadHandler_OnLoadEnd(object sender, Chromium.Event.CfxOnLoadEndEventArgs e)
        {

            if (e.Frame.IsMain)
            {
                // 来这里干点有趣的事情，让必应网站能够支持我们拖动移动窗口
                // 通过JS注入下面的CSS，修改必应的菜单栏，加上背景虚化部分，并让背景虚化部分支持拖动

                WebBrowser.ExecuteJavascript(@"
var style = document.createElement(""style"");
style.type = ""text/css"";

style.innerHTML=`
.hp_hor_hdr {
    -webkit-app-region: drag;
    background-color:rgba(255,255,255,0.1) !important;
    backdrop-filter:blur(15px);
}
.hp_hor_hdr ul, .hp_hor_hdr #id_h  {
    -webkit-app-region: no-drag;
}
.b_header{
    -webkit-app-region: drag;
}

.b_header > * {
    -webkit-app-region: no-drag;
}
`;

document.getElementsByTagName(""HEAD"").item(0).appendChild(style);
");
            }
        }

        private void DownloadHandler_OnBeforeDownload(object sender, Chromium.Event.CfxOnBeforeDownloadEventArgs e)
        {
            // 弹出默认的另存为窗口来指定下载位置。
            e.Callback.Continue(string.Empty, true);
        }

        private void LifeSpanHandler_OnBeforePopup(object sender, Chromium.Event.CfxOnBeforePopupEventArgs e)
        {
            // 使用系统默认的浏览器打开新窗口
            // Open the new windows with system default browser
            var newUrl = e.TargetUrl;

            var process = new System.Diagnostics.ProcessStartInfo(newUrl)
            {
                UseShellExecute = true,
                Verb = "open"
            };

            System.Diagnostics.Process.Start(process);

            e.SetReturnValue(true);
        }


    }
}
