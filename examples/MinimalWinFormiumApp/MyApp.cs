using Microsoft.Extensions.DependencyInjection;

using WinFormium;
using WinFormium.WebResource;
using WinFormium.JavaScript;


namespace MinimalWinFormiumApp;
internal class MyApp : WinFormiumStartup
{
    protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
    {

        return opts.UseMainFormium<MyWindow>();

        // 可以指定 Formium 为主窗体，也可以使用原生的 WinForm 窗体。
        // You can specify Formium as the main form, or you can use the native WinForm form.
        //return opts.UseMainForm<Form1>();
    }

    protected override void WinFormiumMain(string[] args)
    {
        // 现在把 Main 函数搬到这里来。避免用户搞不清主进程和渲染进程的区别，在 Program.cs 里面写太多代码导致子进程内部出现问题。
        // Now move the Main function here. To avoid users not knowing the difference between the main process and the rendering process, write too much code in Program.cs, which causes problems in the sub-process.

#if NETCOREAPP3_1_OR_GREATER
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
#else
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#endif
    }


    // CEF 的配置可以在Program.cs里面写，也可以在这里写，在这里写更集中，更简洁。
    // CEF configuration can be written in Program.cs or here, which is more centralized and concise here.
    protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
    {
        //cef.UseInMemoryUserData();

        cef.ConfigureCommandLineArguments(cl =>
        {
            //cl.AppendArgument("disable-web-security");
            //cl.AppendSwitch("no-proxy-server");
            cl.AppendSwitch("enable-gpu");
            //cl.AppendSwitch("disable-gpu");
        });

        cef.ConfigureDefaultSettings(settings =>
        {
            settings.WindowlessRenderingEnabled = true;
        });

        cef.ConfigureDefaultBrowserSettings(settings =>
        {

        });

        // 启用子进程的示例。
        // Example of enabling sub-process.
        //cef.ConfigureSubprocess(sub =>
        //{
        //    sub.SubprocessFilePath = "WinFormiumSubProcess.exe";
        //});

    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        // 注册嵌入资源
        // Register embedded resources to specific domain.
        services.AddEmbeddedFileResource(new EmbeddedFileResourceOptions
        {
            Scheme = "http",
            DomainName = "embedded.app.local",
            ResourceAssembly = typeof(Program).Assembly,
            EmbeddedResourceDirectoryName = "wwwroot",
        });

        // 注册本地资源
        // Register local resources to specific domain.
        services.AddLocalFileResource(new LocalFileResourceOptions
        {
            Scheme = "http",
            DomainName = "files.app.local",
            PhysicalFilePath = Path.Combine(AppContext.BaseDirectory, "wwwroot"),
        });

        services.AddDataResource("http", "data.app.local", provider => {
            provider.ImportFromCurrentAssembly();
        });


        // 注册 JavaScript Window Binding Object
        // Register JavaScript Window Binding Object
        services.AddWindowBindingObject<TestWindowBindingObject>();

    }

}
