# NanUI
### 前言
NanUI是一个基于ChromiumFX开源项目的.Net Winform界面库，ChromiumFX是Chromium Embedded Framework的.Net实现。众所周知，Chromium Embedded Framework (CEF)是由 Marshall Greenblatt 在2008年创办的开源项目，致力于基于Google Chromium项目开发一个Web控件。可以将Chrome浏览器的功能（页面渲染，JS 执行）嵌入到其他应用程序的框架。CEF 作为嵌入式浏览器框架最适合的应用场景应该是Html页面渲染，所以很多程序都基于CEF来为应用程序提供 HTML 页面渲染的功能，如有道笔记，微信Windows客户端，网易云音乐，Evernote，GitHub Window Client，Q+，Adobe Brackets 等。

在此之前CEF应用大多使用C++来进行开发，对于.Net项目和.Net程序原来说只能是望梅止渴。基于ChromiumFX项目的诞生，.Net项目终于能够与CEF来一次请密接触，但ChromiumFX项目主要注重于浏览器核心的实现，对Winform界面开发并无太大作用。在此背景下，NanUI孕育而生。

NanUI打破了传统的Winform界面设计方式，通过NanUI你能够使用Html5、CSS3和javascript来构建你的Winform界面。如果你熟悉诸如bootstrap、jQuery、WinJS等各类CSS或JS库的话，你能够根据喜好或客户要求设计出各种漂亮的Winform界面。所以，使用NanUI，你的Winform软件界面将有无限可能。

![NanUI](http://images2015.cnblogs.com/blog/352785/201605/352785-20160518180435701-1461536015.png)

### 愿景
NanUI在发布第一个预览版的时候是支持将CEF的各种支持文件放置在程序集目录下面的，但是经过很长时间的思考，在新版本的NanUI中剔除了对此项功能的支持。CEF运行支持文件都需要被放置到“%APPDATA%\Net Dimension Studio\NanUI”下面。

为何我要这样做？因为我希望NanUI能够坚强的发展，有朝一日很多.Net程序都是用NanUI来开发界面，那么这个时候NanUI的CEF运行支持文件就如同.Net Framework一样与系统同在。没有人会在意几十上百兆的.Net Framework，因为它与系统同在，所有的.Net程序都调用它，它是共享的，没有人愿意自己发布的软件随时带着.Net Framework走。

所以，我希望NanUI CEF Runtime有那么一天能够被很多.Net程序共享使用。


### 赞助作者
如果你喜欢NanUI项目，你可以参与到NanUI的开发中来，当然你也可以更直接了当的支持我的工作，使用支付宝或微信扫描下面二维码请我喝一杯热腾腾的咖啡。

![支付宝](http://images2015.cnblogs.com/blog/352785/201606/352785-20160608004055668-1675779685.png)

支付宝扫上面二维码打赏作者杯咖啡

![微信支付](http://images2015.cnblogs.com/blog/352785/201606/352785-20160612234514761-199610391.jpg)

微信扫一扫上面二维码打赏作者杯咖啡


QQ群：
241088256

### 版本状态
NanUI版本
> 0.3.2 alpha预览

支持的操作系统
> Windows XP及已上版本

最小支持 .NET 版本
> .NET Framework 4.0 Client Profile

当前CEF版本
> CEF 3.2623.1401 Chromium 49.0.2623.10

### 如何使用
**引用NanUI库**

NanUI使用非常简单。在项目中只需引用“NetDimension.NanUI.dll”一个库即可。如果本机没有检测到CEF运行库，NanUI会提供下载地址或者自动下载相应的支持文件。

**初始化CEF环境**

在Main函数中
```C#
static class Program
{
  /// <summary>
  /// 应用程序的主入口点。
  /// </summary>
  [STAThread]
  static void Main()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    HtmlUILauncher.EnableFlashSupport = true;	//开启Flash支持

    if (HtmlUILauncher.InitializeChromium())	//初始化CEF环境
    {
      //启动主窗体
      Application.Run(new MainFrame());
    }
  }
}
```

**加载Html**

初始化完成后在窗口中继承HtmlUIForm类，并传入网页地址就完成了页面的加载。除了使用本地资源和远程网址，NanUI还提供了对嵌入式资源的支持，具体请参看Wiki中的相关示例。
```C#
public class MainFrame : HtmlUIForm
{
	public MainFrame()
		: base("<页面地址>")
	{
		InitializeComponent();
		//... 各种初始化代码
	}
}

```

只需如上简单的三步，就完成了对NanUI的加载。其他界面设计的工作就交给美工吧！

代码示例中，将详细展示NanUI的使用方法。当然你也可以通过WIKI来了解更多信息。

### 演示项目
**CodeEditor**

NanUI.Demo.CodeEditor
NanUI.Demo.CodeEditor.Resources

该项目使用强大的JS项目CodeMirror，配合Bootstrap库进行界面布局，实现了一个简单的代码编辑器功能。

**Welcome**

NanUI.Demo.Welcome

该项目使用jQuery及Bootstrap构建界面，主要演示了NanUI对HTML5、CSS3、Flash、WebGL等技术的支持程度。

### CEF运行库下载
| 说明           | 大小  | 说明  | 下载                                                           |
| -------------- |------:|:-----:|:-------------------------------------------------------------:|
| 完整安装包      | 73.0M | 推荐  | [下载](http://www.bolepa.com/NanUI/NanUIPackages/all.exe)             |
| 资源文件        | 3.53M | 必要  | [下载](http://www.bolepa.com/NanUI/NanUIPackages/resources.exe)       |
| 32位CEF运行库   | 24.4M |      | [下载](http://www.bolepa.com/NanUI/NanUIPackages/x86/cef_x86.exe.exe)  |
| 32位Flash支持库 | 7.46M |      | [下载](http://www.bolepa.com/NanUI/NanUIPackages/x86/flash_x86.exe)    |
| 64位CEF运行库   | 29.2M |      | [下载](http://www.bolepa.com/NanUI/NanUIPackages/x64/cef_x64.exe.exe)  |
| 64位Flash支持库 | 10.2M |      | [下载](http://www.bolepa.com/NanUI/NanUIPackages/x64/flash_x64.exe)    |

### 参考
暂无，等我慢慢写。要想写得快，记得打赏我几杯咖啡：）