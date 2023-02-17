using NetDimension.NanUI;

namespace FormiumClient;

public static class Program
{
    public static void Main()
    {

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#if NETCOREAPP3_1_OR_GREATER
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif

        // *************** DO NOT WRITE ANY CODES HERE ***************

        // Warning: Do not write business-related code before or after CreateRuntimeBuilder. Writing business logic here due to the multi-process architecture of CEF will cause your business logic to be executed multiple times.
        // 警告: 请勿在 CreateRuntimeBuilder 之前或之后编写业务相关的代码，由于 CEF 的多进程架构在此处编写业务逻辑将导致您的业务逻辑被多次执行。

        WinFormium.CreateRuntimeBuilder(buildChromiumEnvironment: env =>
        {
            env.CustomCefCommandLineArguments(args =>
            {
                // Configure CEF command line switches arugments here.
                // 在此配置 CEF 的命令行指令和参数

                args.AppendSwitch("ignore-certificate-errors");
                args.AppendSwitch("disable-web-security");
                args.AppendSwitch("enable-media-stream");
                args.AppendSwitch("enable-print-preview");
                args.AppendSwitch("enable-gpu");


                args.AppendSwitch("autoplay-policy", "no-user-gesture-required");

                //args.AppendSwitch("unsafely-treat-insecure-origin-as-secure", "http://resources.app.local");


            });

            env.CustomCefSettings(settings =>
            {
                // Configure default Cef settings here.
                // 在此配置 CEF 默认设置

            });

            env.CustomDefaultBrowserSettings(cefSettings =>
            {
                // Configure default browser settings here.
                // 在此配置浏览器默认设置
            });


            // Enable NanUI Subprocess Demo
            // 启用 NanUI 的子进程示例，使用子进程模式将 CEF 的进程独立到另外的 EXE 文件中，避免在主进程中的各种逻辑意外的多次执行。
            env.UseExternalSubprocess(sb =>
            {
                sb.UseCustomSubprocessPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FormiumClientSubprocess.exe"));
            });


        }, buildApplicationConfiguration: app =>
        {
            app.UseEmbeddedFileResource("http", "resources.app.local", "EmbeddedFiles", url =>
            {
                if (url.StartsWith("http://resources.app.local/window-styles"))
                {
                    return "window-styles/index.html";
                }
                return null;
            });

            // Register LocalFileResource handler which can handle the file resources in local folder.
            // 使用 LocalFileResource 注册本地文件资源，并将本地文件夹内的文件及目录结构映射到 http://static.app.local 域名下。
            app.UseLocalFileResource("http", "static.app.local", System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));

            // Register DataServiceResource handler which can process http request and return data to response. It will find all DataServices in current assembly automatically or you can indicate where to find the DataServices by using the third parameter.
            // 注册数据资源控制器，它能处理前端的http请求并返回相应结果。DataServiceResource会自动扫描并注册程序集内的数据服务，您也可以手动指定数据服务所在的位置。
            app.UseDataServiceResource("http", "api.app.local");

            // Enable single instance mode
            // 启用单例
            //app.UseSingleInstance((processId) => {
            //    // processId - 为已在运行中的进程实例ID
            //    // processId - The Id of the running instance
            //});

#if DEBUG
            // Specify whether to enable debugging mode.
            // 指定是否开启调试模式。
            app.UseDebuggingMode();
#endif

            app.RegisterJavaScriptWindowBinding(() => new DemoWindowBinding());


            // Open the main form and start the message loop.
            // 打开主窗体并开始消息循环。
            app.UseMainWindow(context =>
            {
                var startupWin = new StartupWindow();
                if (startupWin.ShowDialog() == DialogResult.OK)
                {
                    return new MainWindow();
                }

                return null;
            });

            //app.UseMainWindow(_ => new MainWindow());

        })
        .Build()
        .Run();

        // Warning: Do not write business-related code before or after CreateRuntimeBuilder. Writing business logic here due to the multi-process architecture of CEF will cause your business logic to be executed multiple times.
        // 警告: 请勿在 CreateRuntimeBuilder 之前或之后编写业务相关的代码，由于 CEF 的多进程架构在此处编写业务逻辑将导致您的业务逻辑被多次执行。

        // *************** DO NOT WRITE ANY CODES HERE ***************
    }
}
