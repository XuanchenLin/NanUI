using WinFormium;
using WinFormium.JavaScript;
using WinFormium.WebResource;

namespace MinimalWinFormiumApp;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {

        var builder = WinFormiumApp.CreateBuilder();

        var app = builder
            // 使用WinFormiumStartup的子类来启动应用程序，这个子类必须继承自WinFormiumStartup类，这个类提供了一些方法来配置应用程序。
            // Use a subclass of WinFormiumStartup to start the application. This subclass must inherit from the WinFormiumStartup class, which provides some methods to configure the application.
            .UseWinFormiumApp<MyApp>()
            // 启用内部浏览器，这个版本默认外部Url打开方式是调用系统默认浏览器，需要手动开启内部浏览器后才能使用内部浏览器打开外部Url。
            // Enable the internal browser. In this version, the default external URL opening method is to call the system default browser. You need to manually enable the internal browser before you can use the internal browser to open the external URL.
            .UseEmbeddedBrowser()
            // 演示单例模式，如果你的应用需要单例模式，那么可以使用这个方法来启用单例模式。新版本可以使用ActiveRunningInstance方法来激活已经运行实例的主窗体。
            // Demonstrate singleton mode. If your application requires singleton mode, you can use this method to enable singleton mode. The new version can use the ActiveRunningInstance method to activate the main form of the running instance.
            .UseSingleApplicationInstanceMode(handler =>
            {
                var retval = MessageBox.Show($"已经有一个实例在运行了:{handler.ProcessId}。\r\n是否打开其主窗体？", "单例模式已启用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (retval == DialogResult.Yes)
                {
                    handler.ActiveRunningInstance();
                }
            })
            // 在这里指定culture字符传来模拟多语言环境，这个版本的多语言环境还不完善，只提供zh-CN和en-US两种语言环境。欢迎提交PR来增加更多语言环境。
            // Specify the culture string here to simulate the multilingual environment. The multilingual environment of this version is not perfect, and only provides two language environments: zh-CN and en-US. Welcome to submit PR to add more language environments.
            //.UseCulture("en-US")
            // 是否启用开发者工具菜单，这个菜单可以在主窗体的右键菜单中找到。
            // Whether to enable the developer tool menu, this menu can be found in the right-click menu of the main form.
            .UseDevToolsMenu()
            .Build();

        app.Run();

    }
}
