# 配置开发环境

[[返回目录](README.md)]

- [配置开发环境](#配置开发环境)
  - [开发环境要求](#开发环境要求)
  - [相关依赖](#相关依赖)
  - [编译 NanUI 源码或是用二进制包](#编译-nanui-源码或是用二进制包)

## 开发环境要求

在开发前，请确保您的开发环境满足以下条件：

- Visual Studio 2012 或更新版本，此处强烈推荐使用 Visual Studio 2019/2022 来进行开发，避免出现各种尴尬的问题。

  - 如需编译 NanUI 项目源码，则必须使用 Visual Studio 2022，并且确保已安装所有 NanUI 支持的 .NET Framework / .NET SDK 软件开发包，具体可参考[源码编译说明](../../src/NetDimension.NanUI/)。

- Windows 7 SP1 或更高版本。
- .NET Framework 4.6.2 或更高版本。
- .NET Core 3.1 或 .NET 5.0/6.0。

## 相关依赖

NanUI 项目基于 CefGlue 进行二次封装和开发，而 CefGlue 是一个 CEF 的 .NET 实现。 因此 NanUI 项目的运行依赖于 CEF 的相关文件。

当前版本的 NanUI 基于 CEF 90.6.7 版本，您可以选择手动下载对应版本的 CEF 文件， 或者使用`NuGet包管理器`来安装自动安装这些依赖。在稍后的一段时间里，还将推出 NanUI SDK 工具包，也将内置这些依赖文件。

请注意，特定版本的 NanUI 使用特定版本的 CEF 运行时文件，您不应该也不能使用其他版本的 CEF 文件。如果 CEF 文件版本与当前 NanUI 版本无法对应，那么您的应用程序将无法正常运行。实际情况下，NanUI 版本号的第三位即对应了所使用 CEF 的版本。例如 `NanUI 0.9.90.xx` 代表了此版本需要使用 `90.x.x` 版本的CEF运行文件。

**手动下载或编译 CEF 依赖项**

您可以从 [http://opensource.spotify.com/cefbuilds/index.html](http://opensource.spotify.com/cefbuilds/index.html) 网站搜索并下载已经编译好的 CEF 二进制文件（需要对应 NanUI 版本）。

如果您有丰富的 CEF 开发编译经验，您也可以根据 CEF 官方指引（[Branches and Building](https://bitbucket.org/chromiumembedded/cef/wiki/BranchesAndBuilding)）自己编译 CEF 框架。自行编译 CEF 框架能够使您更清楚的理解 CEF 的运行机制，还能为 CEF 框架定制更多功能。

**使用 NuGet 包管理器安装依赖项**

```
PM> Install-Package NetDimension.NanUI.Runtime -Version 90.6.7
```

使用 NuGet 包管理器安装 NanUI 依赖后，包管理器将根据您项目的架构信息（anycpu/x86/x64）自动生成 CEF 依赖的目录和文件结构，您无需关注目录结构信息，所以这也是最快速最简便的方法。

**附：CEF 依赖项文件夹结构**

- AnyCPU - 自动适用于 32 位和 64 位 Windows 系统

```
<应用程序目录>
    │  <您的应用程序.exe>
    └─fx
        ├─Resources
        │  │  cef.pak
        │  │  cef_100_percent.pak
        │  │  cef_200_percent.pak
        │  │  cef_extensions.pak
        │  │  devtools_resources.pak
        │  │
        │  └─locales
        │          <locales pak files...>
        │
        ├─x64
        │      chrome_elf.dll
        │      d3dcompiler_47.dll
        │      icudtl.dat
        │      libcef.dll
        │      libEGL.dll
        │      libGLESv2.dll
        │      natives_blob.bin
        │      snapshot_blob.bin
        │      v8_context_snapshot.bin
        │
        └─x86
                chrome_elf.dll
                d3dcompiler_47.dll
                icudtl.dat
                libcef.dll
                libEGL.dll
                libGLESv2.dll
                natives_blob.bin
                snapshot_blob.bin
                v8_context_snapshot.bin
```

- x86 - 用于 32/64 位 Windows 系统的 32 位应用程序

```
<应用程序目录>
    │  <您的应用程序.exe>
    │  cef.pak
    │  cef_100_percent.pak
    │  cef_200_percent.pak
    │  cef_extensions.pak
    │  chrome_elf.dll
    │  d3dcompiler_47.dll
    │  devtools_resources.pak
    │  icudtl.dat
    │  libcef.dll
    │  libEGL.dll
    │  libGLESv2.dll
    │  natives_blob.bin
    │  snapshot_blob.bin
    │  v8_context_snapshot.bin
    │
    └─locales
            <locales pak files...>

```

- x64 - 只用于 64 位 Windows 系统的 64位应用程序

```
<应用程序目录>
    │  <您的应用程序.exe>
    │  cef.pak
    │  cef_100_percent.pak
    │  cef_200_percent.pak
    │  cef_extensions.pak
    │  chrome_elf.dll
    │  d3dcompiler_47.dll
    │  devtools_resources.pak
    │  icudtl.dat
    │  libcef.dll
    │  libEGL.dll
    │  libGLESv2.dll
    │  natives_blob.bin
    │  snapshot_blob.bin
    │  v8_context_snapshot.bin
    │
    └─locales
            <locales pak files...>
```

**NanUI 依赖项公共文件夹**

除了将 CEF 的相关文件放置到应用程序更目录外，您还可以选择将这些文件放到一个公共的位置从而避免开发多个 NanUI 应用程序时，每个应用程序都需要部署依赖项的问题。

```
%ProgramData%\Net Dimension Studio\NanUI\[CEF_VERSION]\
```

依赖项公共文件夹应具备以下架构：

```
<%ProgramData%>
    └─Net Dimension Studio
        └─NanUI
            └─[CEF_VERSION]
                ├─Resources
                │  │  cef.pak
                │  │  cef_100_percent.pak
                │  │  cef_200_percent.pak
                │  │  cef_extensions.pak
                │  │  devtools_resources.pak
                │  │
                │  └─locales
                │          <locales pak files...>
                │
                ├─x64
                │      chrome_elf.dll
                │      d3dcompiler_47.dll
                │      icudtl.dat
                │      libcef.dll
                │      libEGL.dll
                │      libGLESv2.dll
                │      natives_blob.bin
                │      snapshot_blob.bin
                │      v8_context_snapshot.bin
                │
                └─x86
                        chrome_elf.dll
                        d3dcompiler_47.dll
                        icudtl.dat
                        libcef.dll
                        libEGL.dll
                        libGLESv2.dll
                        natives_blob.bin
                        snapshot_blob.bin
                        v8_context_snapshot.bin
```

此版本的 NanUI 在环境初始化时会优先检测公共位置（通常这个位置应该是：`C:\ProgramData\Net Dimension Studio\NanUI\90.6.7\`）是否存在 CEF 相关依赖文件，如果不存在才会检测应用程序根目录。

## 编译 NanUI 源码或是用二进制包

您可以从 [GitHub](https://github.com/NetDimension/NanUI/) 或 [Gitee](https://gitee.com/linxuanchen/NanUI) 获取 NanUI 项目的全部源代码，并使用 VS2022 编译。

或者通过`NuGet 包管理器`安装 NanUI 二进制包。

```
PM> Install-Package NetDimension.NanUI
```

**NanUI 相关二进制包**

| 项目名称                                   | 框架                | 说明                                                                                |
| :----------------------------------------- | :------------------ | :---------------------------------------------------------------------------------- |
| NetDimension.NanUI                         | net462+ / netcore31+  | 您需要引用此库来构建 NanUI 应用程序，这是 NanUI 的核心库。                          |
| NetDimension.NanUI.Runtime                 | net462+ / netcore31+ | NanUI 的依赖项，包括了 CEF 框架二进制文件和 CFX 二进制文件。                        |


**\*net462+** : .NET Framework 4.6.2 或更高版本

**\*netcore31+**: .NET Core 3.1/.NET 5.0/.NET 6.0
