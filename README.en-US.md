# NanUI

[[中文](./README.md)] | [English]



## Introduction

![screenshot](./screenshot.png)


### NanUI Project

**NanUI** is an open source .NET project for .NET / .NET Core developers who want to use front-end technologies such as HTML5 / CSS3 to build user interfaces for Windows Form applications. It's based on [ChromiumFX](https://bitbucket.org/chromiumfx/chromiumfx) project that is a .NET bindings for the Chromium Embedded Framework.

### Formium Engine

**Formium** is the core of the NanUI project. It is focused on using the web front-end technologies such as HTML5 / CSS3 / Javascript to build the user interface of desktop applications. It will bring unlimited possibilities to software interface design work.

With Formium Engine, you can easily use any front-end techonology you are familiar with to build user interface of applications. It is strongly recommended that you use the Single Page Applicaiton (SPA) to make the user interface, because this can give users a better operation experience. The mainstream Javascript frameworks, Angular, React, Vue are all wise choices that can be used to build SPA apps. For more information and examples about how to build apps with Formium, please see [Formium-Demos](https://github.com/NetDimension/Formium-Demos).

**If you like NanUI project, please give it a star!**

## What's new

The latest changes at 2020/1/15, please see [CHANGES](./src/changelog.md) to check more details.


## Documentation

The Documentations will help you to start with Formium quickly. Contact me if you are willing to help translate the documentation. 

[Documentation](https://docs.formium.net)


## Install

The stable release of NanUI project uploads to NuGet. Using the commad below in NuGet Package Manager to install latest version of Formium Engine to your project. The dependencies associated with it will be automatically installed into your project too.

**For .NET Framework 4.0+ / .NET Core 3.1**

Microsft .NET Framework 4.0 is the minimal version support to NetDimension.NanUI.dll.

```
PM> Install-Package NetDimension.NanUI
```

**IMPORTANT!** Unlike previous version of NanUI, this new version will no longer provide support for Window XP.



## Basic Usage

Initialize the Runtime.

```C#
using NetDimension.NanUI;
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

using NetDimension.NanUI;

class MainWindow : Formium
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

  protected override void OnWindowReady(IWebBrowserHandler browserClient)
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

## Donate
NanUI is an MIT licensed open source project and completely free to use. However, the amount of effort needed to maintain and develop new features for the project is not sustainable without proper financial backing.

If you like this project and be sure of my work, you can buy me a cup of coffee, or you can become a backer or sponsor for helping the project better.

[![DONATE](docs/images/paypal.png)](https://www.paypal.me/mrjson)







