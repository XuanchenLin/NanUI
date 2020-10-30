# NanUI

[中文](README.md) | English

---

## About

### What's this

NanUI is an open source .NET/.NET Core component for Windows Form Applications. It's suitable for .NET/.NET Core developers who wants to use front-end technologies suc as HTMM5/CSS3/JavaScript to design the user interface of Windows Form Applications.

WinFormium, the rendering engine of NanUI is based on Chromium Embedded Framework, so you can use various front-end technologies (HTML5/CSS3/JavaScript) and frameworks (React/Vue/Angular/Blazor) to design and develop user interface of .NET desktop applications.

And WinFormium's JavaScript Bridge can easily and concisely relize the communication and data exchanges between the browser and .NET enviroment.

Using NanUI will bring you unlimited possibilities for designing and developmenting the UI of traditional WinForm applications!

**If you like NanUI project, please light up a star⭐ for this project!**

Please consider rewarding the project author or sponsoring the project so that the NanUI project can be developed and iterated continuously. Thank you for your support and attention!

### Homepage

https://github.com/NetDimension/NanUI/

https://gitee.com/linxuanchen/NanUI/

### Requirements

- Windows 7 x86/x64 SP1 and newer
- .NET Framework 4.6.2 and above / .NET Core 3.1

### License

NanUI is LGPL-3.0 licensed. **The copyright of NanUI project is owned by the project's founder and developer Xuanchen Lin**.

Follow the LGPL-3.0:

1. You can reference NanUI's binary library in any commercial software without paying any copyright-related fees;
2. If your project uses and modifies the source code of NanUI, then your project also needs to use the LGPL agreement to open source, and keep the copyright information of NanUI in your derivative project: `Powered by NanUI`.
3. If you need to use source code of NanUI in a non-open source application, in order to protect your legal rights, please consider purchasing a commercial license from the project author.

For more details of LGPL-3.0 [please see](en-US/Licence.md). The NanUI project is based on many open source projects, for dependency licenses [please see](en-US/Dependences.md)。

---

## How to use

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

### Documentation

The development documentation will help you quickly and easily start to develop with NanUI.

- [NanUI Documentation](README.md)

The NanUI document is currently being gradually improved. If you are willing to help translate documents to different languages, please contact me or directly submit a Pull Request for the documents in other languages. Thank you!

## Reward and Sponsorship

The NanUI project is an open source project based on the LGPL-3.0 agreement and it is completely free. Without proper financial support, project maintenance and the development of new features cannot be sustained. So if you like this project and approve of my work, you buy me a cup of coffee, or you can become a long-term project sponsor to help NanUI better.

Use WeChat or Alipay to scan the QR code below to make a donation.

![DONATE](images/qrcode.png)

If you are not in China, please click the icon below to jump to the PayPal to make a donation.

[![DONATE](images/paypal.png)](https://www.paypal.me/mrjson)
