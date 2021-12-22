# 创建 NanUI 应用程序

[[返回目录](README.md)]

NanUI 基于 Chromium 浏览器核心，因此您可以使用您所熟悉的任何前端技术来打造您的桌面应用程序。您还可以向 Javascript 环境中注入 .NET 对象或方法来丰富前端的 JavaScript 功能；另外使用资源处理器，您还可以方便地向前端 Web 环境提供文件、多媒体、数据等内容。

您可以把 NanUI 看作一个嵌入到 WinForm 中的、精简化的 Chromium 浏览器，这个浏览器替代了传统 WinForm 界面画布，因此您可以发挥想象力，使用任何 Web 前端技术来设计您的窗体界面。

不仅如此，您还能保留 .NET 框架的所有特性，能够使用 EntityFramework，能够使用多线程、甚至能通过任何方式与您的硬件设备进行交互并把相关的信息反馈给 Web 环境。既满足了设计漂亮用户界面的需求，也能发挥 .NET 强大的功能。

阅读以下步骤，创建您的第一个 NanUI 应用程序。

- [创建 NanUI 应用程序](#创建-nanui-应用程序)
  - [选择 .NET 框架](#选择-net-框架)
  - [安装 NanUI](#安装-nanui)
  - [创建简易的窗体](#创建简易的窗体)
    - [第一步：创建主窗体](#第一步创建主窗体)
    - [第二步：初始化](#第二步初始化)
    - [第三步：运行](#第三步运行)

## 选择 .NET 框架

您可以根据实际项目的需求，选择使用 .NET Framework 或者最新的 .NET Core 框架的 Windows 窗体（WinForm）应用程序。对于两种类型的窗体应用程序来说，所有的 API 接口都是相同的，您可以方便的从一种框架迁移到另外一种。

![创建Windows Forms应用程序](../images/create_new_project.png)

在此，强力建议您放弃过时的 .NET Framework 版本来开发您的应用，而是使用先进的 .NET 5.0/6.0 框架取而代之。

## 安装 NanUI

现在，您需要安装 NanUI 以及 NanUI 的依赖项。推荐您使用 NuGet 包管理器来安装他们，或者也可以在包管理器控制台中运行如下命令来安装：

**安装 NanUI**

```
PM> Install-Package NetDimension.NanUI
```

**安装 NanUI 运行时依赖项**

```
PM> Install-Package NetDimension.NanUI.Runtime
```

当然，您也可以按照上一章节介绍的内容来手动布局依赖项文件结构。

## 创建简易的窗体

### 第一步：创建主窗体

NanUI 使用了基类 `Formium` 来创建浏览器承载窗口，因此我们并不需要像往常一样通过窗体设计器来设计窗体和控件（当然也不可以像通常那样把传统窗体控件拖动到窗体上）。因此我们可以直接删除项目模板中自动创建的 Form1.cs 窗体文件。

新建类 MainWindow.cs，并让他继承 NetDimension.NanUI.Formium 基类，并实现该类的所有抽象接口：

```C#
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

class MainWindow : Formium
{
  // 设置窗体样式类型
  public override HostWindowType WindowType => HostWindowType.System;
  // 指定启动 Url
  public override string StartUrl => "https://www.bing.com";

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

修改 StartUrl 属性，指定启动时访问的 Url 地址。

```C#
public override string StartUrl => "https://www.bing.com";
```

指定 WindowType 属性，选择窗体的呈现样式，目前 NanUI 提供了多种窗口样式可供选择，在后面的章节中将详细介绍。

下面代码中将选用 Windows 窗体的原生样式。

```C#
public override HostWindowType WindowType => HostWindowType.System;
```

使用 OnReady 重载方法设置与浏览器相关的逻辑、执行初始化 JavaScript 代码等。以此来实现对浏览器的各项行为的处理，例如：选择何种方式处理新开窗口、如何处理下载请求、如何通知应用程序网页标题的改变等等行为。

这个方法通常在 Chromium 浏览器核心初始化完成之后执行。

如果不需要处理特定浏览器行为，那么留空即可。 NanUI 已经为您处理了大多数的浏览器行为。

通过以上简单的编码您已经完成了您的第一个 NanUI 窗口的设置，该窗口将使用 https:/www.bing.com 的内容作为您窗体的界面。

但到目前为止，应用程序还不能正常运行，因为我们还需要初始化 NanUI 和 CEF 环境。

### 第二步：初始化

初始化 NanUI 和 CEF 的操作我们需要放到应用程序的 Main 方法中。

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

`WinFormium` 类是 NanUI 的初始化启动器，使用 `CreateRuntimeBuilder` 方法来启动运行时初始化过程，第一个委托参数可以设置与 CEF 环境相关的设置和 CEF 进程启动时的命令行参数；第二个委托参数主要用于设置于 NanUI 相关的一些选项，例如后面会用到的资源控制器注入、注册 JavaScript 扩展等。

**进一步定制窗体**

如果您还想进一步定制您的窗体，和 WinForm 开发类似的，在窗体构造函数中可以设置窗口大小，指定启动是窗口的位置，为窗口设置图标等。

这里需要指出的是，选择不同的`WindowType`后，还可以为当前指定的`WindowType`设置特有的窗体样式属性，例如，如果您为窗体设置了`Borderless`样式，那么可以在构造函数中使用`UseExtendedStyles<BorderlessWindowStyle>()`来为当前窗体指定更多的行为和样式，例如`ShadowEffect`既是`Borderless`样式窗口的特有样式属性，用来设置窗体投影的大小。

```C#
var style = UseExtendedStyles<BorderlessWindowStyle>();
style.ShadowEffect = ShadowEffect.Huge;
style.ShadowColor = ColorTranslator.FromHtml("#963B6F");
```

有关于如何定制 Formium 窗体的详细介绍，请参考《[NanUI 窗体](nanui-formium.md)》章节中的内容。

### 第三步：运行

至此，您的第一个 NanUI 应用程序已经能够正常运行了。按下 F5 键，即可打开以网页为界面的窗口。

如果一切正常，那么您的第一个 NanUI 应用程序的运行结果应该如下图所示。

![运行结果](../images/system-style.png)
