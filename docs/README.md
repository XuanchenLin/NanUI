# 欢迎使用 NanUI

中文 | [English](README.en-US.md)

---

## 关于 NanUI

### 项目核心

NanUI 界面组件是一个开放源代码的 .NET / .NET Core 窗体应用程序（WinForms）界面组件。她适用于希望使用 HTML5/CSS3 等前端技术来构建 Windows 窗体应用程序用户界面的 .NET/.NET Core 开发人员。

NanUI 的渲染引擎 WinFormium[^1] 基于可嵌入的谷歌浏览器框架（Chromium Embedded Framework），因此用户可以使用各种前端技术（HTML5/CSS3/JavaScript）和框架（React/Vue/Angular/Blazor）设计和开发.NET 桌面应用程序的用户界面。

[^1]：NanUI 项目目前已更新迭代了 8 个测试版本，在功能和 API 语法上趋近稳定，因此很可能在不就的未来即将发布 1.0 正式版，届时将正式启用 `WinFormium` 作为本项目的对外名称，`NanUI` 会作为项目代号进行保留。

同时，WinFormium 特有的 JavaScript Bridge 可以方便简洁地实现浏览器端与 .NET 之间的通信和数据交换。

使用 NanUI 界面框架将为传统的 WinForm 应用程序的用户界面设计和开发工作带来无限种可能！

**如果你喜欢 NanUI 项目，请为本项点亮一颗星 ⭐！**

此外也请您考虑打赏项目作者或者为项目提供赞助，以便 NanUI 项目得以长期开发和持续迭代，感谢您的支持和关注！

### 项目地址

https://github.com/NetDimension/NanUI/

https://gitee.com/linxuanchen/NanUI/

### 运行要求

- Windows 7 x86/x64 SP1 或更新版本的系统
- .NET Framework 4.6.2 及以上版本 / .NET Core 3.1

### 版权和协议

NanUI 项目基于 LGPL-3.0 开源协议开放项目源代码。**本项目版权由项目发起人、开发者林选臣所有**。

依照 LGPL-3.0 协议规定：

1. 您可以在任何商业软件中引用 NanUI 的二进制库而无需支付任何与版权相关的费用;
2. 如果您的项目使用并修改了 NanUI 的源代码，那么您的项目也需要使用 LGPL 协议进行开源，并且在您的衍生项目中保留 NanUI 的版权信息：`Powered by NanUI`。
3. 如果您需要在非开源的应用程序中使用 NanUI 的源代码，为了保障您的合法权益，请考虑向项目作者购买商业授权。

关于 LGPL-3.0 协议的具体内容请参考此协议[详细副本](zh-CN/Licence.md)。此外，NanUI 项目基于诸多开源项目进行构建，相关的项目请查阅[第三方授权协议](zh-CN/Dependences.md)。

---

## 使用 NanUI

### 第一步：引用 NanUI 必要程序集及组件

您可以从两种取到获取到 NanUI 相关的程序集及组件：

**NuGet**

1.从 NuGet 获取并引用 NanUI

```
PM> Install-Package NetDimension.NanUI
```

使用 Visual Studio 的`NuGet包管理器`或者`程序包管理器控制台`来获取 NanUI 的程序集，根据您项目的类型（.NET Framework 或者 .NET Core）将自动为您安装合适的程序集。

2.安装 NanUI 运行环境包

```
PM>  Install-Package NetDimension.NanUI.Runtime
```

和安装 NanUI 程序集一样，使用 Visual Studio 的`NuGet包管理器`或者`程序包管理器控制台`来获取 NanUI 的运行时支持文件，这些文件主要包含了与`CEF`框架有关的文件，根据您项目架构（AnyCPU/x86/x64）的具体情况，此 NuGet 包将在编译时拷贝与架构对应的运行时文件到您项目的输出目录中。

**NanUI SDK 工具包**

除了使用 Visual Studio 的`NuGet包管理器`或者`程序包管理器控制台`来获取 NanUI 相关的程序集，您还可以从 NanUI 项目官网下载和安装 SDK 工具包。SDK 工具包包含了更多的工具来简化操作。

### 第二步：编写代码

1.在主窗体加载前初始化 NanUI 运行环境。

```C#
using NetDimension.NanUI;

class Program
{
  static void Main()
  {
    // ...
    WinFormium.CreateRuntimeBuilder(env => {

      env.CustomCefSettings(settings =>
      {
        // 在此处设置 CEF 的相关参数
      });

      env.CustomCefCommandLineArguments(commandLine =>
      {
        // 在此处指定 CEF 命令行参数
      });

    }, app =>
    {
        // 指定启动窗体
        app.UseMainWindow(context => new MainWindow());
    })
    .Build()
    .Run();
  }
}

```

2.编写窗体代码

```C#
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

class MainWindow : Formium
{
  // 设置窗体样式类型
  public override HostWindowType WindowType => HostWindowType.System;
  // 指定启动 Url
  public override string StartUrl => "https://www.formium.net";

  public MainWindow()
  {
    // 在此处设置窗口样式
    Size = new System.Drawing.Size(1024, 768);
  }

  protected override void OnReady()
  {
    // 在此处进行浏览器相关操作

    //ShowDevTools();
    //ExecuteJavaScript("alert('Hello NanUI')");
  }
}

```

没有复杂的步骤！只需简单操作 NanUI 项目就可以顺利运行。

如果需要了解更多内容，请参考[示例和文档](#示例和文档)章节中的内容。

---

## 示例和文档

### 示例

![示例](images/preview-animation.png)

最新版本的 NanUI 支持多种窗体类型，上面动图中的示例包括了常用的 `系统原生窗口样式`、`无边框窗口样式`、`Win10 亚克力特效窗口样式`以及`异形窗口样式`几种窗口类型。

您可以获取 NanUI 源码后详细了解每种窗口实现方式，以上示例代码均已包含！

### 文档

帮助文档将帮助您轻松快速的开始使用 NanUI 进行开发。

- [NanUI 0.8 文档](documentation.md)

此外您还可以在下述平台找到更多关于 NanUI 的话题、文档和视频。

- [[知乎专栏] NanUI 技术内幕](https://zhuanlan.zhihu.com/nanui)
- [[B 站] 码农 JSON 的 NanUI 入门教程频道](https://space.bilibili.com/396855974/channel/detail?cid=113298)
- [[西瓜视频] NanUI 入门教程频](https://www.ixigua.com/6804465191196033540?id=6798031330459255303)

目前 NanUI 文档正在逐步完善，如果您愿意帮助翻译不同语言的文档，请与我取得联系或者直接提交其他语言文档的 Pull Request 即可，感激不敬！

## 打赏和赞助

NanUI 项目基于 LGPL-3.0 协议的开源项目并且它是完全免费的。尽管如此，如果没有适当的资金支持，项目维护和新功能的开发是无法持续下去的。所以如果你喜欢这个项目并认可我的工作，你可以支付我一杯咖啡的钱请我喝一杯咖啡，或者你也可以成为长期的项目资助人以帮助 NanUI 变得更好。

使用微信或者支付宝扫描下方二维码来进行资金方面的捐助。

![DONATE](images/qrcode.png)

海外用户请通过点击下方图标连接到 PayPal 平台进行捐助

[![DONATE](images/paypal.png)](https://www.paypal.me/mrjson)
