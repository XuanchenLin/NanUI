<p align="center">
    <img src="./artworks/WinFormiumLogo.png" width="144" />
</p>
<h1 align="center">The NanUI Project</h1>
<p align="center"><strong>Easily build powerful WinForm applications with HTML, CSS and JavaScript.</strong></p>

# NanUI

点击[[此处]](https://gitee.com/dotNetChina/NanUI/)切换到**简体中文**仓库首页。

![GitHub](https://img.shields.io/github/license/XuanchenLin/NanUI)
![Nuget](https://img.shields.io/nuget/v/NetDimension.NanUI)
![Nuget](https://img.shields.io/nuget/dt/NetDimension.NanUI)

## ⭐ About

NanUI is an open source framework on .NET platform for creating user interface for WinForm Applications using HTML5, CSS3, and JavaScript. It is based on the [Xilium.CefGlue](https://bitbucket.org/xilium/xilium.cefglue/wiki/Home) project, which is a .NET wrapper around the [Chromium Embedded Framework](https://bitbucket.org/chromiumembedded/cef).

If you are looking for a framework for creating a WinForm application with a modern user interface, NanUI is a good choice. you can use HTML, CSS, and JavaScript to create a user interface, and use C# to write the business logic of the application.

**Please give NanUI project a star⭐ if you like it.**

If this project helps, please consider funding it.

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://paypal.me/mrjson?country.x=C2&locale.x=zh_XC)

## 🖥️ Requirements

**For Development**

- .NET Framework 4.6.2 or higher / .NET 6.0 or higher
- Visual Studio 2019 or higher (VS2022 is recommended)

**For Deployment**

- Microsoft Windows 7 Service Pack 1 or higher
- .Net Framework 4.6.2 or higher
- .NET 6.0 for Windows 7 and higher.
- .NET 7.0/8.0 for Windows 10 and higher.

This is a **Windows Only** framework, it can not run on Linux or Mac OS.

The minimum supported Windows is Windows 7 Service Pack 1, and some features (such as DirectComposition Offscreen Rendering) are not supported on Windows 7.

## 🧰 Getting Started

Create a simple NanUI Application by following the steps below:

**1. Create a WinForm Application by default template.**

**2. Install NanUI NuGet Package**

Open the NuGet Package Manager to install or use NuGet Package Manager Console, and run the following command to install NanUI nuget package:

```powershell
PM> Install-Package NetDimension.NanUI
```

Install the dependencies of Chromium Embedded Framework that NanUI depends on:

```powershell
PM> Install-Package NetDimension.NanUI.Runtime
```

**3. A basic NanUI application requires the following code:**

Modify the code in the **Program.cs** file as follows:

```csharp
using WinFormium;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var builder = NanUIApp.CreateBuilder();

        builder.UseNanUIApp<MyApp>();

        var app = builder.Build();

        app.Run();
    }
}
```

Create a class implements **NanUIAppStartup** for configuring the application:

```csharp
using NetDimension.NanUI;

class MyAPP : NanUIAppStartup
{
    protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
    {
        // Configure the main window of this application
        return opts.UseMainFormium<MyWindow>();
    }

    protected override void ProgramMain(string[] args)
    {
        // The codes in Main function should be here, this function only runs in Main process. So it can prevent the codes in Main process running in sub-processes.
        ApplicationConfiguration.Initialize();
    }

    protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
    {
        // Configure the Chromium Embedded Framework here
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        // Configure the services of this application here
    }
}
```

Create a class implements **Formium** for configuring the main window of the application:

```csharp
using NetDimension.NanUI;
using NetDimension.NanUI.Forms;

class MyWindow : Formium
{
    public MyWindow()
    {
        Url = "https://www.google.com";
    }

    protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
    {
        // Configure the style of the window here or leave it blank to use the default style

        var style = builder.UseSystemForm();

        style.TitleBar = false;

        style.DefaultAppTitle = "My first WinFomrim app";

        return style;
    }
}
```

**4. Build and run your NanUI application**

## 📖 Documentation

For more info please see - [Documentation](docs/README.md)

## 🤖 Demos

- [Minimal WinFormium App](./examples/MinimalWinFormiumApp) - Introduction to the basic usage of WinFormium.

## 🔗 Third-Party References & Tools

- CEF - [https://bitbucket.org/chromiumembedded/cef](https://bitbucket.org/chromiumembedded/cef)
- Xilium.CefGlue - [https://gitlab.com/xiliumhq/chromiumembedded/cefglue/](https://gitlab.com/xiliumhq/chromiumembedded/cefglue)
- Vanara.Library - [https://github.com/dahall/Vanara](https://github.com/dahall/Vanara)
- Vortice.Windows - [https://github.com/amerkoleci/Vortice.Windows](https://github.com/amerkoleci/Vortice.Windows)
- SkiaSharp - [https://github.com/mono/SkiaSharp](https://github.com/mono/SkiaSharp)
- React - [https://github.com/facebook/react](https://github.com/facebook/react)
- React-Router - [https://github.com/remix-run/react-router](https://github.com/remix-run/react-router)
- Vite - [https://github.com/vitejs/vite](https://github.com/vitejs/vite)

## 🏆 Inspirations

I was inspired by the following songs and albums when creating this version of WinFormium.

- **Strandels** - Chance Of Rain
- **One Direction** - What a Feeling (Made In The A.M.)
- **Thomas Rhett** - VHS (Center Point Road)
- **Sammy Kershaw** - She Don't Know She's Beautiful (Haunted Heart)
- **Chrissy Steele** - Two Bodies (Magnet To Steele)
- **Halestorm** - I Like It Heavy (Into the Wild Life)
- **Joan Jett & The Blackhearts** - I Hate Myself for Loving You (Up Your Alley)
