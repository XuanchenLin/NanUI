# NanUI
## Introduction
### About NanUI

**NanUI** is an open source .NET project for .NET / .NET Core developers who want to use front-end technologies such as HTML5 / CSS3 to build user interfaces for Windows Form applications.

### Formium Engine

**Formium** is the core of the NanUI project. The Formium Engine can be used to build Windows Form applications in a .NET / .NET Core environment. It's based on [ChromiumFX](https://bitbucket.org/chromiumfx/chromiumfx) project that is a .NET bindings for the Chromium Embedded Framework. NanUI is focused on using the web front-end technologies such as HTML5 / CSS3 / Javascript to build the user interface of desktop applications. It will bring unlimited possibilities to software interface design work.

With Formium, you can easily use any front-end techonology you are familiar with to build user interface of applications. It is strongly recommended that you use the Single Page Applicaiton (SPA) to make the user interface, because this can give users a better operation experience. The mainstream Javascript frameworks, Angular, React, Vue are all wise choices that can be used to build SPA apps. For more information and examples about how to build apps with Formium, please see [Formium-Demos](https://github.com/NetDimension/Formium-Demos).

**If you like NanUI project, please give it a star!**

## What's new

The latest changes at 2020/1/15, please see [changelog](changelog.md) to check more details.

## Build

You need to use Visual Studio 2019 with the .NET Framework SDKs (4.0 and above) and .NET Core 3.1 SDK installed to  compile the source code of the NanUI project successfully. If you don't need to compile the source code of NanUI, just use the binary library files directly, then the version of Visual Studio will not be limited. More information about how to build the project, please see [here](src/README.md).

## Release

The stable release of NanUI project uploads to NuGet. Using the commad below in NuGet Package Manager to install latest version of Formium Engine to your project. The dependencies associated with it will be automatically installed into your project too.

**NOTE:** Microsft .NET Framework 4.0 is the minimal version support to NetDimension.Formium.dll

```
PM> Install-Package NetDimension.Formium
```

**ATTENTION!** Unlike previous version of NanUI, this new Formium Engine will no longer provide support for Window XP systems.

## Documentation

The [Documentations](documents/en-US/README.md) will help you to start with Formium quickly. Contact me if you are willing to help translate the documentations. 

- [English](documents/en-US/README.md)

- [中文文档](documents/zh-CN/README.md)

## Basic Usage

Initialize the Runtime.

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

Using a browser host window.
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

For more info see - [Getting Started]()

## Demos
[Formium Demos](https://github.com/NetDimension/Formium-Demos)

## Donate
NanUI is an MIT licensed open source project and completely free to use. However, the amount of effort needed to maintain and develop new features for the project is not sustainable without proper financial backing.

If you like this project and be sure of my work, you can buy me a cup of coffee, or you can become a backer or sponsor for helping the project better.

[![DONATE](documents/images/paypal.png)](https://www.paypal.me/mrjson)







