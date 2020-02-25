# NanUI 启动器 Bootstrap 的设置

Bootstrap 类是初始化 NanUI 以及 Chromium Embedded 框架运行环境的主要入口。

通常将 Bootstrap 放置到应用程序的入口函数 `Main()` 中，该类必须先通过 `Initialize()` 方法来告知 NanUI 进入初始化流程，并且实例化 Bootstrap。Initialize()方法返回 Bootstrap 实例。此处约定，所有 Bootstrap 实例的内置方法以及可能出现的其他扩展方法（例如 AssemblyResourceHandler 的初始化方法）都必须返回该 Bootstrap 实例，以此来构建 FluentAPI 样式的编写风格。

Bootstrap 实例以 `Run()` 方法结束，并需要提供 `Func<Formium|Form|ApplicationContext>` 泛型作为其唯一参数，作用是为应用程序指定启动应用程序的主窗体，由它来代替 `Application.Run()` 方法。因此，您在 Main()方法中无需再次执行 Application.Run(_mainform_)方法。

本章节涉及的内容

- [Bootstrap 类](#bootstrap-类)
- [示例](#示例)
- [可能遇到的问题](#可能遇到的问题)

## Bootstrap 类

命名空间： NetDimension.NanUI

程序集： NetDimension.NanUI.dll

### 静态成员

- `CEF_VERSION` type:_const string_ | 指示当前框架的 Cef 版本
- `CommandLineArgs` type：_string[]_ | 当前进程的命令行参数

### 静态属性

- `ApplicationDataDirectory { get; }` type:_string_ | 获取应用程序的数据目录，应用数据目录用于存放 NanUI 相关的数据。通常该目录位于%appdata%\Net Dimension Studio\\<ProductName>中。
- `CacheDirectory { get; }` type:_string_ | 获取应用程序 Chromium 的缓存目录，缓存目录用于存放 Chromium 的零时数据，包含了浏览记录、Cookies 数据、LocalStorage 数据等。通常该目录位于应用程序数据目录中。
- `CurrentContext { get; }` type:_Bootstrap 实例_ | 获取当前 Bootstrap 的单例实例。应用程序初始化开始后才具备返回值；否则，返回 null。
- `DefaultBrowserSetting { get; }` type:_CfxBrowserSettings_ | Chromium 浏览器的默认设置，关于浏览器设置 CefBrowserSettings 的相关设置信息以及功能，请参考[此文档](<https://magpcss.org/ceforum/apidocs/projects/(default)/_cef_browser_settings_t.html>)。
- `LibCefDirPath { get; }` type:_string_ | 获取 libcef.dll 的路径。当 NanUI 自动搜索到 Cef 以及 ChromiumFX 的二进制依赖项时，此属性才具有返回值；否则返回 null，也代表 NanUI 没能找到正确的依赖项路径，启动应用程序后将抛出异常。
- `PlatformArchitecture { get; }` type:_enum[x86|x64]_ | 获取当前应用程序运行的系统架构
- `ResourceDirPath { get; }` type:_string_ | 获取 Cef 的 Resources 目录。Resources 目录包含了 Chromium 运行的必要文件，这些文件不可缺少。NanUI 会根据 LibCefDirPath 的值自动查找该目录并且验证目录文件，验证通过后此属性才具有返回值；否则返回 null，同样的启动应用程序后将抛出异常。
- `SubprocessPath { get; }` type:_string_ | 返回 NanUI 子进程可执行文件的路径。如果在 Bootstrap 初始化时指定了 `UseDefaultBrowserSubpress()` 特性，那么 NanUI 会自动搜索到 NanUI 子进程可执行文件时，此属性才具有返回值；否则返回 null，启动应用程序后将抛出异常。

### 静态方法

- `void Announce()` 在控制台中打印 NanUI 的相关信息。这些信息在 NanUI 主进程启动时已自动打印。
- `int ExecuteProcess()` 执行应用程序子进程。如果单独没有指定子进程或者没有指定`UseDefaultBrowserSubpress()` 特性，那么应用程序执行自己作为 Chromium 的子进程，否则将使用 Subprocess.exe 作为子进程。
- `Bootstrap Initialize()` 通知 NanUI 开始初始化运行时环境，并返回 Bootstrap 类的实例。
- `void Log(params ColorToken[] tokens);` 在控制台中打印日志，NanUI 的控制台打印模块使用了[ColoredConsole](https://github.com/colored-console/colored-console)库来实现控制台内容着色，有关信息请参考 ColoredConsole 项目。
- `void RegisterCustomResourceHandler(Func<CustomResource> resourceHandler);` 注册自定义资源处理器。使用该方法可以注册任何 `CustomResource` 的派生类。资源处理器主要原理是通过拦截 Http 请求，当 Url 命中资源处理器中预设的 Url 时，返回指定的文件或信息。关于如何自定义资源处理器，请参考文档[《实现您自己的资源控制器》](custom-resource-handler.md)。
- `void Text(string text)` 在控制台中打印非重要信息。通常这些信息以黑底白字呈现。

### 实例方法

- `BeforeApplicaitonRun(Func<Bootstrap, bool> beforeRun);` 设置一个在主窗体加载前的处理程序，参数传入当前 Bootstrap 实例，返回一个 Boolean 类型指示是否继续执行 Run()方法。
- `DisableHighDpiSupported()` 禁用 Chromium 的 HighDPI 支持。默认情况下，NanUI 启用了 Chromium 的 HighDPI 支持，如果您的应用程序不是为新版 Windows 系统（例如 Windows 7）开发的，那么您需要显式地指定这一特性来避免 Chromium 跟随系统 DPI 缩放。
- `RegisterChromiumExtension(string name, Func<ChromiumExtensionBase> register)` 为 Chromium 的 Javascript 环境注册扩展内容。参数*name*为该扩展的唯一名称，参数*register*是指定了返回值为*ChromiumExtensionBase*类型的代理，*ChromiumExtensionBase*是任何自定义扩展的基类。关于如何自定义 Chromium 的 Javascript 扩展，请参考文档[《注册 Javascript 扩展程序》](js-extension.md)。
- `UseDefaultBrowserSubpress()` 指定使用 NanUI 默认的子进程应用程序。要使用此特性，您需要提前为您的应用程序安装 NanUI 子进程应用程序。具体信息请参考文档[《Subprocess 子进程应用》](subprocess.md)。
- `WhenLibCefNotFound(Action<LibCefNotFoundArgs> action)` 设置 NanUI 没能自动找到 libcef.dll 依赖是的处理程序。参数*LibCefNotFoundArgs*包含了几个只读属性：Architecture - 只是当前应用运行的系统架构；ApplicationStartupPath - 应用程序的启动路径；DataPath - 应用程序的数据路径。在此代理中，您可以实现自己的路径查找逻辑，或者实现 Cef 依赖项目的远程下载等操作，最后，把您自定义的 Cef 依赖项存放地址反写到 LibCefDir 属性中，系统将再次检测您指定的路径，如果符合 NanUI 的运行要求，那么应用程序继续初始化工作；否则，将抛出异常。
- `WithApplicationDataDirectroty(string dataDir)` 设置自定义的应用程序数据目录路径。
- `WithCustomLibCefDirPath(string libCefDirPath)` 设置自定义的 Cef 依赖项存放目录路径。
- `WithDebugModeEnabled()` 开启调试模式。默认情况下 NanUI 的调试模式是关闭的，非调试模式下 NanUI 禁用了某些非必要日志的输出，处了编辑菜单项外，移除了 Chromium 的其他上下文菜单。
- `WithChromiumCommandLineArguments(Action<string, CfxCommandLine> buildAction);` 自定义 Chromium 的命令行参数，代理方法的第一个参数是 processType，第二个参数是命令行参数的快捷设置器。有关于 Chromium 的命令行参数，请参考[此文档](https://peter.sh/experiments/chromium-command-line-switches/)。
- `WithChromiumSettings(Action<CfxSettings> buildAction)` 自定义 Chromium 的各项参数。代理方法的第一个参数为 Chromium 设置的快捷设置器。有关于 Chromium 设置的相关参数，请参考[此文档](<https://magpcss.org/ceforum/apidocs3/projects/(default)/_cef_settings_t.html>)。
- `void Run(Func<Formium|Form|ApplicationContext> runAction)` 初始化 NanUI 并运行应用程序主窗体。执行本方法意味着 NanUI 运行环境初始化完成。您只能执行本方法一次，多次执行本方法将抛出异常。

## 示例

```C#
static void Main()
{


    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    // 在此处执行IO操作或者单例检测操作，有可能导致应用程序执行异常。

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
```

## 可能遇到的问题

`特别提示：` 不建议您在 Main 方法中执行其他操作，鉴于 Chromium 的多进程模型，Bootstrap 类初始化代码之前的其他代码将被执行多次。

例如您执行了下面的代码，那么将会出现至少 3 个以上的窗体。

```C#
var form = new Form();

Bootstrap.Initialize().Run(()=> ...);
```

又比如您如果添加了应用程序单例检测代码禁止了多个进程启动，那么将造成应用程序无法启动渲染进程从而导致窗体无内容显示。

如果您一定要实现应用程序的单例执行，请确保使用 UseDefaultBrowserSubpress 特性，并且将单例检测的逻辑放到 Run()方法的的代理中执行。
