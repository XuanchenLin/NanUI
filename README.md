# NanUI 

[[English](./README.en-US.md)]

**NanUI**是一个开放源代码的.NET项目，它适用于希望使用HTML5 / CSS3等前端技术来构建Windows窗体应用用户界面的.NET / .NET Core开发人员。

**Formium**是NanUI项目的核心，Formium引擎可用于构建.NET / .NET CORE环境下的Windows窗体应用程序，它的底层基于[ChromiumFX](https://bitbucket.org/chromiumfx/chromiumfx)开源项目。Formium专注于使用HTML5/CSS3/Javascript等Web前端技术来构建桌面应用程序的用户界面，他将为软件界面设计工作带来无限可能。

使用Formium引擎，你可以使用任何你所熟悉的前端技术来搭建用户界面。但强烈建议你使用单页应用（SPA）模式来制作界面，因为这可以给用户带来更好的操作体验。主流的Javascript框架，比如Angular, React, Vue都是可以用来构架SPA应用的明智选择。更多的Formium应用程序实例，请移步[Formium-Demos](https://github.com/NetDimension/Formium-Demos)。

如果你喜欢NanUI项目，请为NanUI项目点亮一颗星！

## 如何编译

你需要使用Visual Studio 2019并安装了.NET Framework SDKs和.NET Core 3.1 SDK才能成功编译编译NanUI项目的源码。如果你不需要编译项目源代码，而是直接使用二进制库文件，那么Visual Studio的版本将不会受到限制。如果需要了解更多关于编译项目的信息，请移步到[这里](src/README.md).


## 引用Formium库

稳定版的库文件我会上传到NuGet平台，你可以通过NuGet的包管理器来安装Formium引擎到你的项目中。与之关联的对应版本的CEF和CFX依赖项目也会自动拷贝到项目文件夹中。

**备注：** NetDimension.Formium.dll最小支持到Microsft .NET Framework 4.0版本

```
PM> Install-Package NetDimension.Formium
```

**请注意!** 与之前发布的NanUI库不同， 新的Formium引擎将不再支持Windows XP系统。

## 帮助文档

[帮助文档](documents/zh-CN/README.md)将帮助你轻松快速的开始使用Formium引擎进行开发。如果你愿意帮助翻译不同语言的文档，请与我取得联系，感激不敬。 

- [English](documents/en-US/README.md)

- [中文文档](documents/zh-CN/README.md)

## 创建一个最简单的应用

初始化Formium的启动环境。

```C#
class Program
{
   [STAThread]
   static void Main(string[] args)
   {
      // ...
      Bootstrap
        .Initialize()
        .Run(()=>new MainWindow());
    }
}
```

使用浏览器承载窗口，例子中将使用一个原生样式的窗口来打开微软必应。
```C#

using NetDimension.Formium;

class MainWindow : HostWindow
{
  // Set the startup url of this window
  public override string StartUrl => "https://www.bing.com";

  // Set the style of the host window, here set window to use the native style 
  public override HostWindowType WindowType =>  HostWindowType.Standard;

  // If you need to add a splash screen when the web page is first loaded, return the control instance of the splash screen here
  protected override Control LaunchScreen => null;

  public MainWindow()
  {
      // Set the base title of the window
      Title = "NanUI Application";
  }

  protected override void OnHostWindowReady(IWebBrowserHandler browserClient)
  {
    // Add the processing functions of the CefClient's handlers here, such as DownloadHandler， LifeSpanHandler, DisplayHandler, etc. 

  }

  // Browser's Javascript context initialization is complete
  protected override void OnRegisterGlobalObject(JSObject global)
  {
      // The C# objects can be injected into Javascript Context of this window here

  }

  protected override void OnStandardFormStyle(IStandardHostWindowStyle style)
  {
    // Define the basic style of the standard window here
    style.MinimumSize = new System.Drawing.Size(1024, 640);
    style.Size = new System.Drawing.Size(1280, 720);
    style.Icon = <Icon File>;
  }
}
```

更多信息请移步 - [开始使用]()

## 示例程序
移步[Formium Demos](https://github.com/NetDimension/Formium-Demos)来下载并体验更多Formium示例程序。

## 资助项目
NanUI是一个基于MIT协议的开源项目并且它是完全免费的。尽管如此，如果没有适当的资金支持，项目维护和新功能的开发是无法持续下去的。所以如果你喜欢这个项目并认可我的工作，你可以支付我一杯咖啡的钱请我喝一杯咖啡，或者你也可以成为长期的项目资助人以帮助NanUI变得更好。

使用微信或者支付宝扫描下方二维码来进行资金方面的捐助。

![DONATE](documents/images/qrcode.png)


海外用户请通过点击下方图标连接到PayPal平台进行捐助。

[![DONATE](documents/images/paypal.png)](https://www.paypal.me/mrjson)

**NanUI的发展需要你的支持，谢谢！**