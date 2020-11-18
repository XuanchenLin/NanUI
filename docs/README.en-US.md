# Welcome to NanUI

[中文](README.md) | English


[Return to Homepage](../README.en-US.md) 

---


## Getting Start

### Step 1: Reference Necessary Assemblies and Components of NanUI

**NuGet**

1.Install Reference From NuGet

```
PM> Install-Package NetDimension.NanUI
```

Use `NuGet Package Manager` or `Package Manager Console` in Visual Studio to install the NanUI package. According to the type of your project (.NET Framwork or .NET Core), it will install the appropriate assembly to your project automatically.

2.Install NanUI Runtime

```
PM>  Install-Package NetDimension.NanUI.Runtime
```

Just like installing NanUI assembly above, Use `NuGet Package Manager` or `Package Manager Console` in Visual Studio to install the NanUI runtime. This package mainly contains files related to the Embedded Chromium Framework.
According to the architecture of your project (AnyCPU, x86 or x64), this package will copy the runtime files to output directory corresponding to current architecture after project is compiled.

**NanUI SDK**

You can also download and install the NanUI SDK from the offical website of NanUI. The SDK Toolkit contains more tools to simplify the developing and packaging.

### Step 2: Write code

1.Initialize the NanUI runtime environment in Main function.

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
        // Set the relevant parameters of CEF here
      });

      env.CustomCefCommandLineArguments(commandLine =>
      {
        // Specify CEF command line parameters here
      });

    }, builder => app
    {
        // Specify the startup window
        app.UseMainWindow(context => new MainWindow());
    })
    .Build()
    .Run();
  }
}

```

2.Write the code of host window

```C#
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

class MainWindow : Formium
{
  // Specify the form style type
  public override HostWindowType WindowType => HostWindowType.System;
  // Specify the startup URL
  public override string StartUrl => "https://www.formium.net";

  public MainWindow()
  {
    // Sets window styles here
    Size = new System.Drawing.Size(1024, 768);
  }

  protected override void OnReady()
  {
    // Perform operations of browser here

    //ShowDevTools();
    //ExecuteJavaScript("alert('Hello NanUI')");
  }
}

```

No more complicated steps, just writing few code and your project will run smoothly.

---

## Examples and Documentation

### Examples

![Examples](images/preview-animation.png)

The latest version of NanUI supports a variety of window types. The example in the above includes the commonly used `System Native Window Style`, `Borderless Window Style`, `Win10 Acrylic Window Style`, and `Layered Window Style`.

You can get the source code of NanUI and learn more about each window's implementation. The code of samples above are included in the source code!

You can also download other example program source codes of NanUI 0.8 through [NanUI Example Warehouse](https://github.com/XuanchenLin/NanUI-0.8-Examples).

### Documentation

The development documentation will help you quickly and easily start to develop with NanUI.

- [NanUI Documentation](documentation.md)

The NanUI document is currently being gradually improved. If you are willing to help translate documents to different languages, please contact me or directly submit a Pull Request for the documents in other languages. Thank you!

