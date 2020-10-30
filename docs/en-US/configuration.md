# Configuration

[[Home](README.md)]

- [Configuration](#configuration)
  - [Requirements](#requirements)
  - [Dependencies](#dependencies)
  - [Sources and Binaries](#sources-and-binaries)

## Requirements

Before development, please make sure that your development environment meets the following conditions:

- Visual Studio 2012 or later, it is strongly recommended to use Visual Studio 2019 for development here to avoid problems.

  - If you need to compile the source code of the NanUI project, you must use Visual Studio 2019 and make sure that the .NET Core 3.1 SDK package has been installed.
  - If you need to develop desktop applications based on the .NET Core 3.1 framework, currently you can only choose VS2019 as the development environment.

- Windows 7 Service Pack 1 or later.
- .NET Framework 4.6.2 or above.
- .NET Core 3.1 or .NET 5 coming soon.

## Dependencies

The latest version of NanUI project is based on CefGlue for secondary packaging and development, and CefGlue is a .NET implementation of CEF. The NanUI project needs on CEF files to run.

The latest version of NanUI is based on CEF 80.1.15, You can choose to manually download the corresponding version of the CEF file, Or use the `NuGet Package Manager` to install these dependencies automatically. The NanUI SDK toolkit will be launched shortly, and these dependencies will also be built-in.

**Download or compile CEF dependencies manually**

You can search and download the compiled version 80.1.15 CEF binary file from [http://opensource.spotify.com/cefbuilds/index.html](http://opensource.spotify.com/cefbuilds/index.html).

If you have CEF compilation experience, you can also compile the CEF framework yourself according to the official CEF guidelines from [Branches and Building](https://bitbucket.org/chromiumembedded/cef/wiki/BranchesAndBuilding). Compiling the CEF framework by yourself can give you a clearer understanding of the operating mechanism of CEF and can customize more functions for the CEF framework.

**Install dependencies using NuGet package manager**

```
PM> Install-Package NetDimension.NanUI.Runtime
```

The NuGet package manager will automatically generate the directory and file structure of the dependent project based on the architecture information of your project. You don't need to pay attention to the directory structure information. This is the fastest and easiest way.

**CEF dependency folder structure**

- AnyCPU - Automatic recognition of 32-bit and 64-bit Windows systems

```
<AppDir>
    │  <YourApp.exe>
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

- x86 - Only for 32-bit Windows systems

```
<AppDir>
    │  <YourApp.exe>
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

- x64 - Only for 64-bit Windows

```
<AppDir>
    │  <YourApp.exe>
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

**NanUI dependency public folder**

In addition to placing CEF related files in the application directory, you can also choose to place these files in a common location to avoid the problem of deploying dependencies for each application when developing multiple NanUI applications.

```
%ProgramData%\Net Dimension Studio\NanUI\[VERSION]\
```

The dependency public folder should have the following structure:

```
<%ProgramData%>
    └─Net Dimension Studio
        └─NanUI
            └─[VERSION]
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

This version of NanUI will first check the public location (usually this location should be: `C:\ProgramData\Net Dimension Studio\NanUI\80.1.15\`) when the environment is initialized, whether there are CEF related dependencies, if there is no NanUI will search the application root directory for dependencies.

## Sources and Binaries

You can get all the source code of NanUI project from [GitHub](https://github.com/NetDimension/NanUI/) or [Gitee](https://gitee.com/linxuanchen/NanUI) and compile it with VS2019.

Or install NanUI binary package through `NuGet Package Manager`.

```
PM> Install-Package NetDimension.NanUI
```

**NanUI binary packages**

| Name                       | Framework           | Introduction                                                                                        |
| :------------------------- | :------------------ | :-------------------------------------------------------------------------------------------------- |
| NetDimension.NanUI         | net462+ / netcore31 | You need to reference this library to build NanUI applications, which is the core library of NanUI. |
| NetDimension.NanUI.Runtime | net462+ / netcore31 | NanUI's dependencies include CEF framework binary files and CFX binary files.                       |

**\*net462+** : .NET Framework 4.6.2 and above

**\*netcore31**: .NET Core 3.1
