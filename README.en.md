# NanUI

![GitHub](https://img.shields.io/github/license/NetDimension/NanUI)
![Nuget](https://img.shields.io/nuget/dt/NetDimension.NanUI?label=NuGet)
![Nuget](https://img.shields.io/nuget/v/NetDimension.NanUI)
![CI](![CI](https://github.com/xuanchenlin/nanui/actions/workflows/main.yml/badge.svg))

[中文](README.md) | English

**Repos**

https://github.com/NetDimension/NanUI/

https://gitee.com/dotNetChina/NanUI/

---

## What's NanUI

NanUI is an open source .NET/.NET Core component for Windows Form Applications. It's suitable for .NET/.NET Core developers who wants to use front-end technologies suc as HTMM5/CSS3/JavaScript to design the user interface of Windows Form Applications.

NanUI is based on Chromium Embedded Framework (CEF), so users can use various front-end technologies such as HTML5/CSS3/JavaScript and popular front-end frameworks such as React/Vue/Angular/Blazor to design and develop the user interface of .NET desktop applications.

And NanUI's JavaScript Bridge can facilitate communication and data exchange between the browser and .NET enviroment.

Using NanUI will bring unlimited possibilities for your WinForms application development work!

![Formium Client](docs/images/formium-client-preview-zhCN.png)


**If you like NanUI project, please light up a star⭐ for this project!**

Please consider rewarding the project author or sponsoring the project so that the NanUI project can be developed and iterated continuously. Thank you for your support and attention!

### Current Version:

- **Chromium** `90.6.7.4430`
- **NanUI** `0.9.90`

### Requirements

- Windows 7 x86/x64 SP1 or newer systems

### Frameworks

- .NET Framework 4.6.2/4.7/4.7.1/4.7.2/4.8
- .NET Core 3.1
- .NET 5.0/6.0

### New features in version 0.9.90

- Rewrite the bottom layer of the Borderless style form, use SkiaSharp to draw form elements
- Removed the 0.8 version of Acrylic style, this style is very buggy in some Win10 versions and Windows 11
- Integrate the three commonly used resource controllers EmbeddedFile/LocalFile/DataService into NetDimension.NanUI, and there is no need to install the dependencies of these three resource controllers separately.
- Rewrite the entire JavaScript communication system, simplify the communication method, and increase the operating efficiency
- Asynchronous JavaScript binding is upgraded to the native Promise method. By generating awaitable objects in the new Promise(result) of JS, it is convenient to use the new keywords async/await in ES6

## Getting Started

If you want to learn more about NanUI or want to use NanUI for development work as soon as possible, please visit "[Welcome to NanUI](docs/README.en.md)" for help, or you can download sample codes to learn how NanUI to work.

### Documentation

- [Documentation](docs/documentation.md)

### Example

A comprehensive demonstration project, FormiumClient, is included in the project source code. Through the source code of this project, you can quickly learn the relevant knowledge of NanUI and master how to use HTML/CSS/JavaScript to create your Windows applications.

- [formium-client-frontend][FormiumClientFrontends](src/Demo/FormiumClientFrontends/)

   The front-end code of the sample project is written in ReactJS.

   - [formium-client-ui](src/Demo/FormiumClientFrontends/formium-client-ui) - 示例程序的界面UI
  - [startup-ui](src/Demo/FormiumClientFrontends/startup-ui) - 启动窗口的界面UI
  - [window-styles-ui](src/Demo/FormiumClientFrontends/window-styles-ui) - 窗体样式示例中的各类型窗体的界面UI

  If you want to learn more about the front-end project, you need to have basic React and Webpack skills; if you only care about the implementation of the communication between JavaScript and NanUI, you only need to view [formium-client-ui\src\FormiumBridge.js](formium -client-ui\src\FormiumBridge.js) file.

- [FormiumClient](src/Demos/FormiumClient/)

   The sample project shows you the form types of NanUI, the use of resource controllers to load resources, and the way to communicate with JavaScript using NanUI.

### Other examples

You can also download the source code of other NanUI sample programs from the following repos.

- [NanUI Examples@GitHub](https://github.com/XuanchenLin/NanUI-0.9-Examples)
- [NanUI Examples@Gitee](https://gitee.com/linxuanchen/NanUI-0.9-Examples)

### Case show

Here are some examples of open source projects developed by using NanUI.

- to be continued...

---

## Copyrights

The NanUI project is based on the `MIT` license. The copyright of this project is jointly owned by the project sponsor and developer Lin Xuanchen and all NanUI code contributors.

According to the MIT agreement, you need to retain NanUI's copyright information in your derivative projects: `Powered by NanUI`.

For the specific content of the MIT agreement, please refer to this agreement [License] (docs/zh-CN/License.md). In addition, the NanUI project is based on many open source projects. For related projects, please refer to [Third Party Agreement] (docs/zh-CN/Dependences.md).

In addition, the NanUI project has joined the [dotNET China](https://gitee.com/dotnetchina) organization.

![dotnetchina](https://gitee.com/dotnetchina/home/raw/master/assets/dotnetchina-raw.png)

---

## Reward and sponsorship

NanUI is an open source project based on the MIT license, and it is completely free. Nevertheless, without proper financial support, project maintenance and development of new features cannot be sustained. So if you like this project and approve of my work, you can pay for a cup of coffee for me in the following ways, or you or your company can become a long-term project sponsor to help NanUI become better.

Use WeChat or Alipay App to scan the QR code below to make a financial donation.

![DONATE](docs/images/qrcode.png)

Overseas users, please connect to the PayPal platform to make donations by clicking the icon below

[![DONATE](docs/images/paypal.png)](https://www.paypal.me/mrjson)

Thanks.