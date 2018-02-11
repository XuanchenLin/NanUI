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

## Changes
**2018/2/12**
-新功能：Formium里添加了新的窗体阴影效果，现在可以通过窗体属性ShadowEffect选择传统的GlowShadow和DropShadow(新)两种样式。DropShadow样式效果和Win7的投影效果类似。

**2018/2/11**
- BUG FIX: 修复了一个当拥有并打开了子窗体的主窗体获取焦点时其本身将覆盖子窗体的阴影窗口的问题。
- NEW VERSION: 0.7版的NanUI已在开发中，新版除了继续调整窗口问题外，还将引入新的阴影绘制逻辑，另外类型注册也是新版本的重点内容。

**2018/2/10**
- BUG FIX: 修复了子窗体最小化后主窗体不响应鼠标事件的问题。
- IMPROVE: 优化了窗口逻辑。
- NEW FEATURE: 增加了注册本地文件夹内资源的ResourceHandler，现在可以通过使用Bootstrap的RegisterFolderResources方法来注册一整个文件夹中的资源文件到指定的域名，也就是说除了内嵌资源外，又提供了一种访问磁盘文件的途径。

**2018/1/25**
- BUG FIX: When FormBorderStyle = None, the Form border will show incorrect

**2018/1/23**
- BUG FIX: ShowInTaskBar=True, NanUI will crash.

**2018/1/16**
- BUG FIX: ShowInTaskBar=True, ModernUI Shadows will show on incorrect position.
- BUG: ShowInTaskBar=True, NanUI will crash. Please wait for this issue solved.

**2018/1/10**
- BUG FIX: NanUI.XP run at 32bit mode will crash sometimes.

**2017/12/21**
- New feature: added a new WebBrowser control to NanUI. You can now drag the WebBrowserControl to your form.

**2017/12/11**
- BUG FIX: n-ui-command html attribute doesn't fire and cause a javasscript error.
- Update new nuget packages.

**2017/11/24**
- BUG FIX: n-ui-command html attribute will not fire if html source dosen't contain script tags. 
- Update new dependencies of NetDimension.NanUI. I made a mistake, the old one did not contain 32bit dependencies. So please reinstall the new one.

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

