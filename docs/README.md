# 欢迎使用 NanUI

中文 | [English](README.en-US.md)

[返回首页](../README.md)

---

## 文档和示例

### 文档

帮助文档将帮助您轻松快速的开始使用 NanUI 进行开发。

- [NanUI 文档](documentation.md)

此外您还可以在下述平台找到更多关于 NanUI 的话题、文档和视频。

- [[知乎专栏] NanUI 技术内幕](https://zhuanlan.zhihu.com/nanui)
- [[B 站] 码农 JSON 的 NanUI 入门教程频道](https://space.bilibili.com/396855974/channel/detail?cid=113298)
- [[西瓜视频] NanUI 入门教程频](https://www.ixigua.com/6804465191196033540?id=6798031330459255303)

目前 NanUI 文档正在逐步完善，如果您愿意帮助翻译不同语言的文档，请与我取得联系或者直接提交其他语言文档的 Pull Request 即可，感激不敬！

### 示例

![示例](images/preview-animation.png)

最新版本的 NanUI 支持多种窗体类型，上面动图中的示例包括了常用的 `系统原生窗口样式`、`无边框窗口样式`、`Win10 亚克力特效窗口样式`以及`异形窗口样式`几种窗口类型。

您可以获取 NanUI 源码后详细了解每种窗口实现方式，以上示例代码均已包含！

您还可以从下述仓库下载 NanUI 的其他示例程序源代码。

- [NanUI 示例仓库@GitHub](https://github.com/XuanchenLin/NanUI-0.9-Examples)
- [NanUI 示例仓库@Gitee](https://gitee.com/linxuanchen/NanUI-0.9-Examples)

---

## 快速开始使用 NanUI

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
