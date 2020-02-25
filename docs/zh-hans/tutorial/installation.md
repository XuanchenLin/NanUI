# 配置NanUI开发环境

- [开发环境要求](#开发环境要求)
- [NanUI依赖项](#nanui依赖项)
- [编译NanUI源码或是用二进制包](#编译nanui源码或是用二进制包)
- [NanUI相关二进制包](#nanui相关二进制包)

## 开发环境要求

构建NanUI应用程序，您的开发环境需要满足以下条件：

- 开发环境首选 Visual Studio 2019
    - 如果您需要编译NanUI项目源码，您必须使用VS2019，因为只有VS2019能够编译.NET CORE 3.1项目源码。
    - 您可以使用旧版本的Visual Studio（例如VS2012）来开发基于.NET Framework的应用程序。
    - 如果您需要开发基于.NET Core 3.1框架的应用程序，目前来说您有且只有VS2019可供选择。

- 客户端运行环境 Windows 7 SP1及更高版本的Windows系统。
    - 从NanUI 0.7版本之后，不再提供对Windows XP系统的任何支持，如需要开发针对Windows XP系统的应用程序，请继续使用0.6.2526版本。
    - NanUI的HighDPI自适应功能的实现需要Windows 10 Createors Update或者更高版本的Windows 10系统。


## NanUI依赖项

### CEF 和 ChromiumFX

NanUI基于ChromiumFX开发，ChromiumFX是.NET的Chromium Embedded框架（CEF）的实现。

NanUI 0.7的运行需要依赖Chromium Embedded Framework (CEF) 77.1.18的二进制文件以及对应版本的ChromiumFX二进制文件。您可以选择手动下载或编译这些二进制文件，或者您也可以直接通过Nuget包管理器来自动安装这些依赖项。

### 手动下载或编译依赖项

#### Chromium Embedded Framework (CEF) 框架

您可以从[http://opensource.spotify.com/cefbuilds/index.html](http://opensource.spotify.com/cefbuilds/index.html)网站下载已经编译好的、对应版本的CEF二进制文件：

  - [CEF 77.1.18+g8e8d602+chromium-77.0.3865.120 / Chromium 77.0.3865.120](http://opensource.spotify.com/cefbuilds/cef_binary_77.1.18%2Bg8e8d602%2Bchromium-77.0.3865.120_windows32_minimal.tar.bz2) - Windows x86
  - [CEF 77.1.14+g4fb61d2+chromium-77.0.3865.120 / Chromium 77.0.3865.120](http://opensource.spotify.com/cefbuilds/cef_binary_77.1.18%2Bg8e8d602%2Bchromium-77.0.3865.120_windows64_minimal.tar.bz2) - Windows x64

如果您有丰富的CEF开发经验，您也可以根据CEF官方的指引[^1]自行编译CEF框架。自行编译CEF框架您可以加入更多的可定制功能[^2]。

#### ChromiumFX

你可以从ChromiumFX项目的托管网站下载[77.1.18.0版本](https://bitbucket.org/chromiumfx/chromiumfx/src/77.1.18.0/)的源码，根据指引编译x86架构和x64架构平台下的二进制文件：
- libcfx.dll - Windows 32位
- libcfx64.dll - Windows 64位

### 使用NuGet包管理器安装依赖项

```
PM> Install-Package NetDimension.NanUI.Runtime
```

NuGet包管理器将根据您项目的架构信息自动生成依赖项目的目录和文件结构，您无需关注目录结构信息，这也是最快速最简便的方法。


### NanUI依赖项文件夹结构

针对您项目的架构，以下文档中列举了正确的NanUI依赖项目录和二进制文件结构。

- AnyCPU - 自动适用于32位和64位Windows系统

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
        │      libcfx64.dll
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
                libcfx.dll
                libEGL.dll
                libGLESv2.dll
                natives_blob.bin
                snapshot_blob.bin
                v8_context_snapshot.bin
```
- x86 - 只用于32位Windows系统

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
    │  libcfx64.dll
    │  libEGL.dll
    │  libGLESv2.dll
    │  natives_blob.bin
    │  snapshot_blob.bin
    │  v8_context_snapshot.bin
    │  
    └─locales
            <locales pak files...>

```
- x64 - 只用于64位Windows系统 

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
    │  libcfx.dll
    │  libEGL.dll
    │  libGLESv2.dll
    │  natives_blob.bin
    │  snapshot_blob.bin
    │  v8_context_snapshot.bin
    │  
    └─locales
            <locales pak files...>
```

## 编译NanUI源码或是用二进制包

您可以从GitHub获取NanUI的全部源码并使用VS2019编译源码，或者通过NuGet安装NanUI二进制包。

- NanUI项目源码 - [https://github.com/NetDimension/NanUI/](https://github.com/NetDimension/NanUI/)
- 使用NuGet包管理器安装NanUI
```
PM> Install-Package NetDimension.NanUI
```

## NanUI相关二进制包

以下表格展示了NanUI项目的各个NuGet包及相关信息。


| 项目名称                                   | 框架                                | 说明                                                                           |
| :----------------------------------------- | :---------------------------------- | :----------------------------------------------------------------------------- |
| NetDimension.NanUI                         | .NET Framework 4.0+ / .NET Core 3.1 | 您需要引用此库来构建NanUI应用程序，这是NanUI的核心库。                         |
| NetDimension.NanUI.Runtime                 | .NET Framework 4.0+ / .NET Core 3.1 | NanUI的依赖项，包括了CEF框架二进制文件和CFX二进制文件。                        |
| NetDimension.NanUI.Subprocess              | .NET Framework 4.0+ / .NET Core 3.1 | NanUI的子进程可执行文件，如果是用NanUI的UseDefaultSubprocess特性需要安装此包。 |
| NetDimension.NanUI.AssemblyResourceHandler | .NET Framework 4.0+ / .NET Core 3.1 | 内嵌资源处理器。                                                               |
| NetDimension.NanUI.FileResourceHandler     | .NET Framework 4.0+ / .NET Core 3.1 | 文件资源处理器。                                                               |
| NetDimension.NanUI.RestfulResourceHandler  | .NET Framework 4.0+ / .NET Core 3.1 | REST数据资源处理器。                                                           |





[^1]: [CEF官方文档](https://github.com/chromiumembedded/cef) - [Branches and Building](https://bitbucket.org/chromiumembedded/cef/wiki/BranchesAndBuilding)
[^2]: Chromium Embedded Framework原生不支持h.264视频播放（该格式为商业格式），因此您需要自行加入与之相关的编译符号并重新编译CEF源码才能实现h.264格式视频的播放。