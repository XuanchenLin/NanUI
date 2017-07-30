# NanUI
### 前言
NanUI是一个基于ChromiumFX开源项目的.Net Winform界面库，ChromiumFX是Chromium Embedded Framework的.Net实现。众所周知，Chromium Embedded Framework (CEF)是由 Marshall Greenblatt 在2008年创办的开源项目，致力于基于Google Chromium项目开发一个Web控件。可以将Chrome浏览器的功能（页面渲染，JS 执行）嵌入到其他应用程序的框架。CEF 作为嵌入式浏览器框架最适合的应用场景应该是Html页面渲染，所以很多程序都基于CEF来为应用程序提供 HTML 页面渲染的功能，如有道笔记，微信Windows客户端，网易云音乐，Evernote，GitHub Window Client，Q+，Adobe Brackets 等。

在此之前CEF应用大多使用C++来进行开发，对于.Net项目和.Net程序原来说只能是望梅止渴。基于ChromiumFX项目的诞生，.Net项目终于能够与CEF来一次亲密接触，但ChromiumFX项目主要注重于浏览器核心的实现，对Winform界面开发并无太大作用。在此背景下，NanUI孕育而生。

NanUI打破了传统的Winform界面设计方式，通过NanUI你能够使用Html5、CSS3和javascript来构建你的Winform界面。如果你熟悉诸如bootstrap、jQuery、WinJS等各类CSS或JS库的话，你能够根据喜好或客户要求设计出各种漂亮的Winform界面。所以，使用NanUI，你的Winform软件界面将有无限可能。

![NanUI](http://images2015.cnblogs.com/blog/352785/201605/352785-20160518180435701-1461536015.png)

### NUGET
NanUI现已加入NuGet豪华套餐：

`Install-Package NetDimension.NanUI`

### 赞助作者
如果你喜欢NanUI项目，你可以参与到NanUI的开发中来，当然你也可以更直接了当的支持我的工作，使用支付宝或微信扫描下面二维码请我喝一杯热腾腾的咖啡。

![Screen Shot](http://www.ohtrip.cn/media/beg_with_border.png)

### 加入讨论

__QQ群__：
241088256

__我的QQ__：
19843266

__博客园：__ [http://www.cnblogs.com/linxuanchen/](http://www.cnblogs.com/linxuanchen/)

### CEF运行支持文件

由于从0.4.4开始，NanUI不再提供自动下载CEF运行支持文件的功能，所以您需要手动添加CEF运行支持文件。

**NanUI 0.5.x CEF支持文件下载**

百度网盘：<http://pan.baidu.com/s/1o7ZRsBC>

**NanUI 0.4.x CEF支持文件下载**

百度网盘：<http://pan.baidu.com/s/1mi4xChE>

使用时，将fx文件夹解压到与 _<AppName.exe>_ 同级的文件夹中，并根据项目的平台适当的删减 _x86_ 或者 _x64_ 文件夹。



### 更新日志
> 0.5.1 (2017-7-30)

- 修复了主窗口还没加载出来，但影子窗口却先加载出来的问题。现在影子会随着主窗体的出现才出现，不会再在桌面上显示一个300*300的镂空影子窗口。
- 修改了IsDesignMode的逻辑，之前使用`Process.GetCurrentProcess().ProcessName == "devenv"`语句来判断窗口是否处于设计模式，但是`Process.GetCurrentProcess()`在系统进程很多的情况下调用非常卡顿，这直接导致了进程多的时候阻塞了WndProc的效率，具体表现就是系统进程越多，拖动窗口的时候就越卡顿。
- **0.6版本正在酝酿和开发中，API将完全改变，可能不会向下兼容，提前告知。**

> 0.5.1 (2017-7-6)

- 新增了不使用全屏窗口的新类型HtmlContentForm。继承这个类型的窗口NanUI将不再重绘窗口样式，使用系统标准的窗口样式。
- 修正了最大化最小化关闭按钮点击不相应的问题。
- 修正了窗体最大化最小化和恢复时不触发windowstatechange的js事件的问题。

> **0.5.0 发布了！**

- 现在CEF及ChromiumFX内核升级到了**CEF 3.2987.1601 (Chrome 57.0.2987.133)**，部分API结构改变，需要调整原有系统的代码。
- **重要：** 此版本不支持WindowsXP。

> 0.4.4

- 重写了无边框窗口和窗体阴影的逻辑，剔除了使用DWM来实现满屏窗口的逻辑。现在整个界面都采用重绘NonclientArea的方式来实现。那也就是说，Win7系统环境下偶尔有出现界面绘制出错的情况将不会发生。
- __删除了CEF框架自动下载和安装的功能__，现在需要自行下载CEF运行文件。您需要将对应的x86/x64文件夹以及Resources文件夹放置于与项目exe文件同级的fx文件夹内。
- 根据之前群友提供的方案，现在默认的嵌入式资源文件默认的Scheme不再采用 __embbed__，而默认采用 __http__。
- 修正了文件加载时，如果内嵌资源在文件夹里，且该文件夹名称含有“-”而不能正确加载的问题。
- 修改和删除了部分API，但是主要的API没有修改，因此升级0.4.4后之前的项目需要做小幅度的更改。
- 移除了离屏渲染相关的API和例子，效率实在太差，并没有实际意义。
- 移除了MarkDown编辑器的例子，因此MarkDown编辑器例子和CodeEditor例子略显重复。
- __重要：__ 0.4.4将是支持__CEF3.2526.5__的最后一个版本，下个版本将直接步进到 __CEF.3071.2__ 与ChromiumFX实现同步。那也意味着，此版本NanUI将是__最后一个支持Windows XP的版本__。0.4.4将作为单独分支持续修正BUG。

> 0.4.3

- 解决了最大化出现白色边的问题。
- 解决了Win7下面不开启DWM错误的渲染了系统主题边框的问题（感谢 Mr.铲屎 提供帮助）。

**注意：**请使用了0.4.2版本的朋友及时更新0.4.3版本

> 0.4.2

- 添加了离屏渲染的支持，并添加了一个离屏渲染+LayeredForm的小火箭渲染例子。

- 增加了本地资源的支持，现在可以通过 local:///C:/xxx/a.jpg这种方式来调用本地目录里的文件了。使用local:///x.jpg则调用当前目录下文件，这里稍作修改了下，和原本的file:///这种scheme的方式不同。

- 部分使用第三方theme.dll的Win7和XP系统在NonclientMode模式下面会突发边框和标题栏重绘时不正确的绘制了系统原生皮肤的图像，这个问题还在找解决办法，请有条件的朋友协助处理此BUG

> 版本0.4.1

**0.4.1更新后无法下载CEF库的问题紧急修复了，这是我没有仔细核对版本号造成的问题，现在已修正。请下载了0.4.1 release的朋友重新下载Release**

 - 新增了NonclientMode下窗口投影的开关NonclientModeDropShadow，现在在无边框模式下面窗口有阴影了（WinXP暂时没测试）。
 - 应大家的要求，从这个版本开始支持本地打包CEF运行框架了。将[all.exe](http://www.ohtrip.cn/NanUI/NanUIPackages/3.2526.1373/all.exe)自解压包中的问价解压到软件目录的fx文件夹，就可以达到CEF随软件分发的目的。


> 版本0.4

- 现在CEF运行库安装路径从%AppData%下转到了%ProgramData%目录下，有群友报告此问题，在多用户环境中若使用%AppData%作为CEF共享目录，如果切换用户后会导致NanUI重新下载CEF运行库。

- 重新优化了CEF运行库自动下载的逻辑，现在CEF运行库带有版本号了，因此采用不同CEF版本的NanUI软件理论上不会因为版本不同造成无法启动的问题。

- 现在CEF运行库的版本从3.2623.1401.gb90a3be（Chromium 49）降回到3.2526.1373.gb660893（Chromium 47），因为CEF 3.2623.1401在使用EvalJavascript方法时有概率无法接收到回调参数。

- 现版本把内部脚本移到了Resources\InitalScripts.js中，不再作为const string，方便修改。

- 另外，各位要求的原生窗口回来了。通过修改窗口的Borderless属性来控制是否开启原生窗口。默认情况Borderless属性为True，若要使用原生窗口请设置为False


### 版本状态
NanUI版本
> 0.5.0 alpha预览

支持的操作系统
> Windows XP及已上版本

最小支持 .NET 版本
> .NET Framework 4.0 Client Profile

当前CEF版本
> CEF 3.2987.1601.gf035232 Chrome 57.0.2987.133

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

**注意**

如果加载窗口后一片空白，请按照下述方法解决：

项目属性->调试->取消勾选“启用 Visual Studio 承载进程”

另外，请勾选“启用本机代码调试”选项来解决中文输入法状态启动调试时软件崩溃的问题。

### 演示项目

**MarkdownDotNet**

NanUI.Demo.MarkdownDotNet

一个功能简单的Markdown编辑器，主要展示NonclientMode。

**CodeEditor**

NanUI.Demo.CodeEditor
NanUI.Demo.CodeEditor.Resources

该项目使用强大的JS项目CodeMirror，配合Bootstrap库进行界面布局，实现了一个简单的代码编辑器功能。

**Welcome**

NanUI.Demo.Welcome

该项目使用jQuery及Bootstrap构建界面，主要演示了NanUI对HTML5、CSS3、Flash、WebGL等技术的支持程度。

### 参考
暂无，等我慢慢写。要想写得快，记得打赏我几杯咖啡：）
