# Overview

Welcome to the WinFormium interface framework. WinFormium is a UI framework for desktop client applications based on WinForm and Chromium embedded frameworks. It can help you quickly develop a powerful desktop client application with a modern user interface.

## Introduction

WinFormium uses the Chromium browser framework to render the user interface, so you can use front-end technologies such as HTML5, CSS3, and JavaScript to develop rich user interfaces, while retaining the ability to write powerful back-end business logic in the C# language.

You can develop WinFormium applications based on the traditional .NET Framework [^1] or the new generation .NET Core [^2].

[^1]: .NET Framework 4.6.2 and above
[^2]: .NET Core 6.0 and above

This document will help you quickly get started with the WinFormium framework and understand the basic concepts and usage of the WinFormium framework. In principle, unless otherwise specified, the sample code in this document is developed based on .NET 6.0, and the development environment is the Visual Studio 2022 version. . For developers of the .NET Framework version, you can refer to the sample code in this document or search the engine for more information.

To learn how to create a WinFormium application, see [Create an Application](./Create-Application.md).

## The Multi-Process Architecture of CEF

WinFormium is extended based on CEF's .NET implementation CefGlue project, and therefore also follows CEF's multi-process architecture model.

The main process that handles window creation, UI, and network access is called the "browser" process (also called the main process). This is usually the same process as the main application, and most of the application logic will run in the browser process.

Page rendering and JavaScript execution occur in separate "render" processes. Some application logic, such as JavaScript binding and DOM access, runs in the rendering process. The default process model will spawn a new render process for each unique origin (scheme + domain, i.e. URL). Other processes will be spawned as needed, such as GPU processes that handle accelerated compositing.

By default, the main application's executable will be executed multiple times as one of the above kinds of processes. If the main application executable file is large and has a lot of logic, the loading time will be very long, and starting the executable file multiple times as a child process will also occupy too much memory. In this case, a separate executable file can be used. Execute the file as its child process to speed up application startup time and reduce memory usage. For more information, see the [Using Subprocesses](../Configuration/Using-Subprocesses.md) section.

IPC is used to communicate between independent processes spawned by CEF. Application logic implemented in the browser and rendering processes can communicate by sending asynchronous messages back and forth. JavaScriptIntegration in the rendering process can call asynchronous APIs located in the browser process. WinFormium has encapsulated the process of inter-process communication. In principle, you should not handle the process of inter-process communication manually. If you need to communicate between the browser process and the rendering process, please search for relevant information about CEF inter-process communication.

## CEF Version

WinFormium has CEF core built-in, so the CEF version associated with it is fixed. If you use Nuget to install the WinFormium package, users cannot choose the CEF version independently. If you need to use a specific version of CEF, you can manually replace the CefGlue-related files in the WinFormium project source code and compile the WinFormium framework.

## The Community and Commercial Editions

Since the continuous development of the project requires a lot of time and effort, I had to launch the WinFormium commercial version. The fees for the commercial version are used for the continuous development and maintenance of the project. But don’t worry, there are very few differences in functionality between the commercial version and the community version. While retaining the basic functions of NanUI, the commercial version provides more functions and better support.

For community edition, please install the `NetDimension.NanUI` and `NetDimension.NanUI.Runtime` packages from NuGet.org.

For the commercial version, you can also install the `WinFormium` and `NetDimension.NanUI.Runtime` packages from NuGet.org, but you need to add the commercial version authorization file to the project. WinFormium also provides a separate commercial version SDK installation package, which contains additional deployment tools, a CEF runtime package `WinFormium.Runtime` package that supports H264 encoding, and the source code of the commercial version of WinFormium.

If you need to use the WinFormium commercial version, please contact me to obtain the commercial version authorization and SDK installation package.

## Version of Documentation

Since WinFormium's predecessor, NanUI, has always been in a testing state, each release version will have major API adjustments, so the documentation for each version will have major differences. If you are using an earlier version, you need to match the framework version and the documentation version yourself to avoid API mismatches.

For example, if you are using version 0.9.xxx of the NetDimension.NanUI package, then you need to check the documentation for version 0.9.xxx.

You are currently viewing the latest version of the document, corresponding to NetDimension.NanUI version 1.0.xxx (community version) and WinFormium version 1.0.xxx (commercial version).

## See also

- [Documentation](../Home.md)
- [Create an Application](./Create-Application.md)
- [Configuration](../Configuration/Overview.md)
- [Forms](../Forms/Overview.md)
- [Resources](../Resources/Overview.md)
- [JavaScript](../JavaScript/Overview.md)
