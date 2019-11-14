# Welcome to NanUI

[中文说明](https://github.com/NetDimension/NanUI/wiki/%E4%B8%AD%E6%96%87%E8%AF%B4%E6%98%8E)

[NanUI](http://netdimension.github.io/NanUI/) is a library based on ChromiumFX that can let your Winform application use HTML5/CSS3 as user interface. You can use orginal Winform borders or full view no border form that use all html/css to design the interface.

NanUI is MIT licensed, so you can use it in both business and free/open source application. For more details, see the [LICENSE](https://github.com/NetDimension/NanUI/blob/master/LICENSE) file.

![NanUI](http://img.blog.csdn.net/20171226150643379)


## What's new in version 0.6

- Rewritted codes of no border interface logic, new version is faster than old versions.
- NanUI now supports Hi-DPI in Windows 8 and later.
- Combined HtmlUIForm and HtmlContentForm to one Formium which support these two styles.
- Install Nuget Package of NanUI will add CEF and ChromiumFX dependencies to your application automatically.

## Build NetDimension.NanUI.dll

You should use the complier which supports C# 7.0 syntax. Visual Studio 2017 is recommended.

## Releases
Stable NanUI binaries are released on NuGet. Use following Nuget command to install latest version of NanUI to your Winfrom application. It will install CEF and CFX dependencies too and the dependencies will automatic copy to the **bin** folder.

**NOTE:** NanUI requires .Net Framework 4.0 as minimal support.

**Nuget Package Manager**
```
PM> Install-Package NetDimension.NanUI
```

**Release of NetDimension.NanUI.XP**

Another version of NanUI that supports **Windows XP** is now can be downloaded on Nuget by using following command:
```
PM> Install-Package NetDimension.NanUI.XP
```

**Support for High Dpi Monitors**
You should add and modify Application Manifest File to enable this feature:

1. Set DpiAware Attribute to true to enable high dpi support.
```
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
    </windowsSettings>
</application>
```

2. If you are running in Windows 8.1, set DpiAwareness Attribute to PerMonitor to enable per monitor diffirent dpi in mulit monitors.
```
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
        <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitor</dpiAwareness>
    </windowsSettings>
</application>
```

3. If you are running in Windows 10 create update (or later), set DpiAwareness Attribute to PerMonitorV2 to enable per monitor diffirent dpi in mulit monitors with advanced features.
```
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
        <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
    </windowsSettings>
</application>
```





**Download Manually**
- [NetDimension.NanUI](https://www.nuget.org/packages/NetDimension.NanUI/) - NanUI main library
- [NetDimension.NanUI.Cef3239](https://www.nuget.org/packages/NetDimension.NanUI.Cef3239/) - Dependencies of NanUI (Include CEF3.3239.1723 and ChromiumFX3.3239.1723 binaries)

## Changes

Latest change at 2019/11/15, see [here](https://github.com/NetDimension/NanUI/blob/master/changes.txt) to check the details.


## Basic Usage

**Initialize Runtime in Main**
```C#
namespace TestApplication
{
    using NetDimension.NanUI;
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initalize: set CEF paths
            //If you use default structure of the FX folder, you should provide paths of fx folder, resources folder and locales folder.

            var result = Bootstrap.Load();
            
            if (result)
            {
                // Load embedded html/css resources in assembly.
                Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly());

                Application.Run(new Form1());

                Application.Exit();
            }

        }
    }
}

```


**Using native Winform border style**
```C#
namespace TestApplication
{
    public partial class Form1 : WinFormium

    {

        public Form1()
            //Load embedded resource index.html and not set form to no border style by the second parameter.
            : base("http://res.app.local/index.html")
        {
            InitializeComponent();
        }
    }
}
```

**Using no border style**
```C#
namespace TestApplication
{
    public partial class Form1 : Formium

    {

        public Form1()
            //Load embedded resource index.html and set form to no border style by igrone the second parameter or set it to true.
            : base("http://res.app.local/index.html")
        {
            InitializeComponent();
        }
    }
}
```

## Documentation

[WiKi](https://github.com/NetDimension/NanUI/wiki)


## Donate

If you like my work, please buy me a cup of coffee to encourage me continue with this library. 

In China you can donate me by scaning the QR code below in **Alipay** or **WeChat** app.

![Screen Shot](http://ohtrip.cn/media/beg_with_border.png)

Or you can donate me by **Paypal**.

[![DONATE](http://ohtrip.cn/media/PayPal-donate-button.png)](https://www.paypal.me/mrjson)

