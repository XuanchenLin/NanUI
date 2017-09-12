# Welcome to NanUI

[NanUI](http://netdimension.github.io/NanUI/) is a library based on ChromiumFX that can let your Winform application use HTML5/CSS3 as user interface. You can use orginal Winform borders or full view no border form that use all html/css to design the interface.

NanUI is MIT licensed, so you can use it in both business and free/open source application. For more details, see the [LICENSE](https://github.com/NetDimension/NanUI/blob/master/LICENSE) file.

![NanUI](http://images2015.cnblogs.com/blog/352785/201605/352785-20160518180435701-1461536015.png)

## What's new in version 0.6
- Rewritted codes of no border interface logic, new version is faster than old versions.
- NanUI now supports Hi-DPI in Windows 8 and later.
- Combined HtmlUIForm and HtmlContentForm to one Formium which support these two styles.
- Install Nuget Package of NanUI will add CEF and ChromiumFX dependencies to your application automatically.

## Releases
Stable NanUI binaries are released on NuGet. Use following Nuget command to install latest version of NanUI to your Winfrom application. It will install CEF and CFX dependencies too and the dependencies will automatic copy to the **bin** folder.

**Nuget Package Manager**
```
PM> Install-Package NetDimension.NanUI
```

**Download Manually**
- [NetDimension.NanUI](https://www.nuget.org/packages/NetDimension.NanUI/) - NanUI main library
- [NetDimension.NanUI.Cef2987](https://www.nuget.org/packages/NetDimension.NanUI.Cef2987/) - Dependencies of NanUI (Include CEF3.2987.1601.0 and ChromiumFX3.2987.1601 binaries)

**百度网盘**
- 百度网盘下载：[3.2987.1601.0](http://pan.baidu.com/s/1o7ZRsBC)



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
			var result = Bootstrap.Load(PlatformArch.Auto, System.IO.Path.Combine(Application.StartupPath, "fx"));
			
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

![Screen Shot](http://www.ohtrip.cn/media/beg_with_border.png)

Or you can donate me by **Paypal**.

[![DONATE](http://www.ohtrip.cn/media/PayPal-donate-button.png)](https://www.paypal.me/mrjson)

