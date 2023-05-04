# NanUI

![GitHub](https://img.shields.io/github/license/xuanchenlin/NanUI)
![Nuget](https://img.shields.io/nuget/dt/NetDimension.NanUI?label=NuGet)
![Nuget](https://img.shields.io/nuget/v/NetDimension.NanUI)
![CI](https://github.com/xuanchenlin/nanui/actions/workflows/main.yml/badge.svg)

中文 | [English](README.en.md)


**仓库**

https://github.com/NetDimension/NanUI/

https://gitee.com/dotNetChina/NanUI/

---

## 关于 NanUI

NanUI 界面组件是一个开放源代码的 .NET / .NET Core 窗体应用程序（WinForms）界面框架。它适用于希望使用 HTML5/CSS3 等前端技术来构建 Windows 窗体应用程序用户界面的 .NET 开发人员。

NanUI 基于谷歌可嵌入的浏览器框架 Chromium Embedded Framework (CEF)，因此用户可以使用各种前端技术 HTML5/CSS3/JavaScript 和流行前端框架 React/Vue/Angular/Blazor 设计和开发 .NET 桌面应用程序的用户界面。

同时，NanUI 独创的 JavaScript Bridge 可以方便地实现浏览器端与 .NET 之间的通信和数据交换。

使用 NanUI 界面框架将为传统的 WinForm 应用程序的用户界面设计和开发工作带来无限种可能！

![Formium Client](docs/images/formium-client-preview-zhCN.png)

**如果你喜欢 NanUI 项目，请为本项点亮一颗星 ⭐！**

此外也请您考虑打赏项目作者或者为项目提供赞助，以便 NanUI 项目得以长期开发和持续迭代，感谢您的支持和关注！

## 示例体验

您可以在当前页面右侧“发行版”或者“Release”栏位里下载打包好的示例程序进行体验。

请注意，如果您需要在 Windows 7 上体验示例程序，那么请确保它已经升级到了 ServicePack 1 并且安装了 DirectX 11 的支持程序。

### 当前 NanUI 版本：

- **Chromium** `90.6.7.4430`
- **NanUI** `0.9.90` 

### 客户端环境

- Windows 7 x86/x64 SP1 或更新版本的系统

### 支持框架

- .NET Framework 4.6.2/4.7/4.7.1/4.7.2/4.8
- .NET Core 3.1
- .NET 5.0/6.0

### 0.9.90 版新特性

- 重写了 Borderless 样式的窗体底层，使用 SkiaSharp 绘制窗体元素
- 删除了 0.8 版的 Acrylic 样式，这个样式在部分 Win10 版本以及 Windows 11 中表现得非常 Bug
- 整合了常用的三种资源控制器 EmbeddedFile/LocalFile/DataService 到 NetDimension.NanUI 中，不需要再单独安装这三种资源控制器的依赖。
- 重写了整个 JavaScript 通信系统，简化了通信方式，增加了运行效率
- 异步 JavaScript 绑定中升级为原生的 Promise 方式，通过在 JS 的 new Promise(result) 的生成可等待的对象，方便使用 ES6 中的新关键字 async/await

---

## 入门

如果想进一步了解有关 NanUI 的更多信息或者想使用 NanUI 尽快进行开发工作，请访问《[欢迎使用 NanUI](docs/README.md)》来获取帮助，也可以通过下载示例代码来了解 NanUI 运作机制。


### 文档

- [NanUI 使用文档](docs/documentation.md)

### 示例

在项目源代码中包括了一个综合性的展示项目 FormiumClient，您可以通过这个项目的源代码快速学习 NanUI 的相关知识并掌握如何使用 HTML/CSS/JavaScript 来创建您的 Windows 应用程序。

- [FormiumClientFrontends](src/Demo/FormiumClientFrontends/)

  示例项目的前端代码，使用了 ReactJS 编写。
  
  - [formium-client-ui](src/Demo/FormiumClientFrontends/formium-client-ui) - 示例程序的界面UI
  - [startup-ui](src/Demo/FormiumClientFrontends/startup-ui) - 启动窗口的界面UI
  - [window-styles-ui](src/Demo/FormiumClientFrontends/window-styles-ui) - 窗体样式示例中的各类型窗体的界面UI

  如果希望深入了解该前端项目您需要具备基础的 React 和 Webpack 技能；如果您只关心 JavaScript 与 NanUI 之间通信的实现方式，您只需查看[formium-client-ui\src\FormiumBridge.js](formium-client-ui\src\FormiumBridge.js)文件即可。

- [FormiumClient](src/Demo/FormiumClient/)

  示例项目的 .NET 实现，该项目展示了 NanUI 的窗体类型、使用资源控制器加载资源以及使用 NanUI 与 JavaScript 进行通信的方式。

此外，您可以通过百度网盘下载编译好的 NanUI 示例项目进行实际体验。网盘地址：

链接: https://pan.baidu.com/s/11S6iXZBtLv1NdtmzMZyTsQ 
提取码: `v351`

### 其他示例

您还可以从下述仓库下载 NanUI 的其他示例程序源代码。

- [NanUI 示例仓库@GitHub](https://github.com/XuanchenLin/NanUI-0.9-Examples) 
- [NanUI 示例仓库@Gitee](https://gitee.com/linxuanchen/NanUI-0.9-Examples) 

### 案例展示

以下列举了一些使用 NanUI 为基础开发的开源项目案例。

- 待续...

---


## 版权和协议

NanUI 项目基于 `MIT` 开源协议开放项目源代码。本项目版权由项目发起人、开发者林选臣以及全体NanUI代码贡献者共同所有。

依照 MIT 协议规定您需要在您的衍生项目中保留 NanUI 的版权信息：`Powered by NanUI`。

关于 MIT 协议的具体内容请参考此协议[详细副本](docs/zh-CN/License.md)。此外，NanUI 项目基于诸多开源项目进行构建，相关的项目请查阅[第三方协议](docs/zh-CN/Dependences.md)。

此外，NanUI 项目已加入 [dotNET China](https://gitee.com/dotnetchina)  组织。

![dotnetchina](https://gitee.com/dotnetchina/home/raw/master/assets/dotnetchina-raw.png)

---

## 打赏和赞助

NanUI 是基于 MIT 协议的开源项目，它是完全免费的。尽管如此，如果没有适当的资金支持，项目维护和新功能的开发是无法持续下去的。所以如果您喜欢这个项目，并认可我的工作，您可以通过下述方式支付一杯咖啡钱请作者喝一杯咖啡，或者您或者您所在的企业也可以成为长期的项目资助人以帮助 NanUI 变得更好。

使用微信或者支付宝扫描下方二维码来进行资金方面的捐助。

![DONATE](docs/images/qrcode.png)

海外用户请通过点击下方图标连接到 PayPal 平台进行捐助

[![DONATE](docs/images/paypal.png)](https://www.paypal.me/mrjson)

### 特别赞助

一次性赞助 NanUI 项目 ￥399.00 元可获取 CEF 商业视频编码（h264/aac）播放定制编译包（含32位/64位）。

下载地址：

链接：https://pan.baidu.com/s/1e09wTZg2iSIKbrResVAlzg 

提取码：`0990`

解压密码：`******`

---

## 鸣谢

特别感谢 [JetBrains](https://www.jetbrains.com/community/opensource/) 为本项目提供免费的全家桶!

<img src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png" alt="JetBrains Logo (Main) logo." width="128">
