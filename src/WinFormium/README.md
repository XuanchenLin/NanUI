# WinFormium

Easily buid powerful WinForm applications with HTML, CSS and JavaScript.

![GitHub](https://img.shields.io/github/license/XuanchenLin/NanUI)
![Nuget](https://img.shields.io/nuget/v/NetDimension.NanUI)
![Nuget](https://img.shields.io/nuget/dt/NetDimension.NanUI)

## About

WinFormium is a open source framework on .NET platform for creating user interface of WinForm Applicaitons using HTML5, CSS3, and JavaScript. It is based on the [Xilium.CefGlue](https://bitbucket.org/xilium/xilium.cefglue/wiki/Home) project, which is a .NET wrapper around the [Chromium Embedded Framework](https://bitbucket.org/chromiumembedded/cef).

If you are looking for a framework for creating a WinForm application with a modern user interface, WinFormium is a good choice. you can use HTML, CSS, and JavaScript to create a user interface, and use C# to write the business logic of the application.

## Platform

This is a **Windows Only** framework, it can not run on Linux or Mac OS.

The minimum supported Windows is Windows 7 Service Pack 1, and some features (such as DirectComposition Offscreen Rendering) are not supported on Windows 7.

## Requirements

**For Development**

- .NET Framework 4.6.2 or higher / .NET 5.0 or higher
- Visual Studio 2019 or heigher (VS2022 is recommended)

**For Deployment**

- Microsoft Windows 7 Service Pack 1 or higher
- .Net Framework 4.6.2 or higher
- .NET 5.0/6.0 for Windows 7 and above.
- .NET 7.0/8.0 for Windows 10 and above.

## Getting Started

Create a simple WinFormium application with the following steps:

**1. Create a WinForm Application by default template**

**2. Install WinFormium NuGet Package**

Open the NuGet Package Manager to install or use NuGet Package Manager Console, and run the following command to install WinFormium nuget package:

```powershell
PM> Install-Package NetDimension.NanUI
```

Install the dependencies of Chromium Embedded Framework that WinFormium depends on:

```powershell
PM> Install-Package NetDimension.NanUI.Runtime
```

**3. A basic WinFormium application requires the following code:**

Modify the code in the Program.cs file as follows:

```csharp
using WinFormium;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var builder = WinFormiumApp.CreateBuilder();

        builder.UseWinFormiumApp<MyApp>();

        var app = builder.Build();

        app.Run();
    }
}
```

Create a class implements **WinFormiumStartup** for configuring the application:

```csharp
using WinFormium;

class MyAPP : WinFormiumStartup
{
    protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
    {
        // Configure the main window of this application
        return opts.UseMainFormium<MyWindow>();
    }

    protected override void WinFormiumMain(string[] args)
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
using WinFormium;
using WinFormium.Forms;

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

**4. Build and run your WinFormium application.**
