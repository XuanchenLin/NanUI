# 编译 WinFormium 框架

## 概述

WinFormium 框架使用了最新的 SDK 样式的项目结构，因此您应该使用 Visual Studio 2022 来打开 WinFormium 框架的解决方案文件 `WinFormium.sln`。框架的源代码位于 `src` 文件夹内，您可以在这里找到所有源代码。

## 准备编译

WinFormium 项目默认支持的目标框架为：

- .NET Framework 4.6.2
- .NET Framework 4.7 / 4.7.1 / 4.7.2
- .NET Framework 4.8 / 4.8.1
- .NET 6.0 / 7.0

因此您需要安装对应的 .NET Framework SDK 和 .NET SDK，否则将导致编译失败。当然，您也可修改项目文件来更改目标框架，删除不需要的目标框架。

## 编译

在准备好 Visual Studio 2022 以及对应的 .NET Framework SDK 和 .NET SDK 之后，您可以打开 `WinFormium.sln` 解决方案文件并编译 WinFormium 框架，不出意外的话，您将会得到一个成功的编译结果。

## 另请参阅

- [入门](./概述.md)
