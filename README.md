# Welcome to NanUI

[中文说明](https://github.com/NetDimension/NanUI/wiki/%E4%B8%AD%E6%96%87%E8%AF%B4%E6%98%8E)

[NanUI](http://netdimension.github.io/NanUI/) is a library based on ChromiumFX that can let your Winform application use HTML5/CSS3 as user interface. You can use orginal Winform borders or full view no border form that use all html/css to design the interface.

NanUI is MIT licensed, so you can use it in both business and free/open source application. For more details, see the [LICENSE](https://github.com/NetDimension/NanUI/blob/master/LICENSE) file.

![NanUI](http://images2015.cnblogs.com/blog/352785/201605/352785-20160518180435701-1461536015.png)


## What's new in version 0.6

- Rewritted codes of no border interface logic, new version is faster than old versions.
- NanUI now supports Hi-DPI in Windows 8 and later.
- Combined HtmlUIForm and HtmlContentForm to one Formium which support these two styles.
- Install Nuget Package of NanUI will add CEF and ChromiumFX dependencies to your application automatically.

## Changes
**2017/9/25**
- Fixed: if your project didn't has satellite resources, the program will crash by a dll file not found exception.
- Fixed: if your html contains select element which is opened and dropdown is shown, moving or resizing the window will cause the dropdown at wrong place.

**2017/9/22**
- Add NetDimension.NanUI.XP project, it can use on Windows XP and it is based on CEF3.2526.1373.
- The sources of NanUI 0.6 is open source now.
- Fixed an issue that if you add embedded globalization files like xxx.zh-cn.js or xxx.en-us.css to your project, the complier will auto generate satellite files in output fold and NanUI did not loads these files correctly.

**2017/9/10**
- update to version 0.6

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



**Download Manually**
- [NetDimension.NanUI](https://www.nuget.org/packages/NetDimension.NanUI/) - NanUI main library
- [NetDimension.NanUI.Cef2987](https://www.nuget.org/packages/NetDimension.NanUI.Cef2987/) - Dependencies of NanUI (Include CEF3.2987.1601.0 and ChromiumFX3.2987.1601 binaries)




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

			var result = Bootstrap.Load(PlatformArch.Auto, System.IO.Path.Combine(Application.StartupPath, "fx"), System.IO.Path.Combine(Application.StartupPath, "fx\\Resources"), System.IO.Path.Combine(Application.StartupPath, "fx\\Resources\\locales"));
			
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
	public partial class Form1 : Formium

	{

		public Form1()
			//Load embedded resource index.html and not set form to no border style by the second parameter.
			: base("http://res.app.local/index.html", false)
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

I have no time for writting documents for the present, documents will come late.


## Donate

If you like my work, please buy me a cup of coffee to encourage me continue with this library. 

In China you can donate me by scaning the QR code below in **Alipay** or **WeChat** app.

![Screen Shot](http://ohtrip.cn/media/beg_with_border.png)

Or you can donate me by **Paypal**.

[![DONATE](http://ohtrip.cn/media/PayPal-donate-button.png)](https://www.paypal.me/mrjson)

