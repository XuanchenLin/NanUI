# 设置 CEF 运行时

在[《启动配置》](./启动配置.md)中简单介绍了如何使用 `AppBuilder` 类的 `UseChromiumEmbeddedFramework` 方法来配置 CEF，本章节将介绍在该文档中未涉及的配置。

## 禁用 CEF 的 Hidpi 缩放

在 CEF 中，当您的应用程序运行在高 DPI 缩放比例的显示器上时，CEF 会自动缩放页面内容以适应高 DPI 缩放比例，这样做的目的是为了让页面内容在高 DPI 缩放比例的显示器上显示的更清晰。但是在某些情况下，您可能不希望 CEF 自动缩放页面内容，那么您可以使用 `DisableHidpiSupport` 方法来禁用 CEF 的 Hidpi 缩放。

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
    cef.DisableHiDpiSupport();
}
```

## 使用自定义 CEF 运行时路径

通常情况下您不需要手动设置 CEF 的运行时路径，因为 WinFormium 会自动从 NuGet 包中加载 CEF 运行时，但是在某些情况下您可能需要手动设置 CEF 的运行时路径，例如在您的项目中有多个 WinFormium 应用程序时，没有必要每一个 WinFormium 应用程序中包含一个 CEF 运行时，这样会导致您的应用程序体积过大，这时您可以将 CEF 运行时放在一个公共的位置，然后在每一个 WinFormium 应用程序中设置 CEF 的运行时路径。

使用 `UseCustomDistributionDirectory` 方法可以设置 CEF 的运行时路径，该方法接受一个 `Action<CustomDistributionDirectoryOptions>` 参数，该参数包含了一系列的配置选项，您可以在这里配置 CEF 的运行时路径。

- public PlatformArchitecture Architecture { get; }
  CEF 运行时的架构，可以是 x86 或 x64。
- public string LibCefPath { get; set; }
  CEF 运行时的 libcef.dll 文件路径。
- public string ResourceFilePath { get; set; }
  CEF 运行时的资源文件夹路径。

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
    cef.UseCustomDistributionDirectory(options => {
        if(options.Architecture == PlatformArchitecture.x86)
        {
            options.LibCefPath = Path.Combine("<path to 32bit libcef.dll>");
        }
        else
        {
            options.LibCefPath = Path.Combine("<path to 64bit libcef.dll>");
        }
        options.ResourceFilePath = Path.Combine("<path to resources of cef>");
    });
}
```

## 设置用户数据文件夹

在 CEF 中，用户数据文件夹用于存储用户的配置文件、缓存文件、Cookie 等数据，您可以使用 `UseCustomUserDataDirectory` 方法设置用户数据文件夹，该方法接受一个 `string` 类型的参数，该参数为用户数据文件夹的路径。

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
    cef.UseCustomUserDataDirectory("<path to user data>");
}
```

不同的应用程序实例无法共享同一个用户数据文件夹。

如果您的应用程序不想将用户数据存于本地，您可以使用 `UseInMemoryUserData` 方法将用户数据文件夹设置到内存中，当应用程序退出时，用户数据将会立即从内存中被清除。

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
    cef.UseInMemoryUserData();
}
```

## 设置自定义协议方案

在《使用资源》章节的[《概述》](./使用资源/概述.md)中将介绍 WinFormium 的各种自定义资源处理器，资源处理器注册接口允许您指定协议方案，在 CEF 中默认了一系列的协议方案，例如 `http`、`https`、`file`、`ftp` 等，如果您指定的协议方案不在默认方案范围内，例如 `app`、`myapp` 等，那么您需要在 CEF 中注册这些自定义的协议方案，否则 CEF 将无法识别这些自定义的协议方案。

您可以使用 `ConfigureCustomSchemes` 方法设置自定义的协议方案，该方法接受一个 `Action<CefSchemeRegistrar>` 参数，该参数包含了一系列的配置选项，您可以在这里配置自定义的协议方案。

- public bool AddCustomScheme(string schemeName, CefSchemeOptions options);
  添加自定义协议方案。

`AddCustomScheme` 方法的第一个参数为自定义协议方案的名称，第二个参数 `CefSchemeOptions` 为自定义协议方案的配置选项。使用 `CefSchemeOptions` 的枚举值来配置自定义协议方案的性质。

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
    cef.ConfigureCustomSchemes(register => {
        register.AddCustomScheme("app", CefSchemeOptions.Standard);
    });
}
```

## 另请参阅

- [概述](概述.md)
- [启动配置](./启动配置.md)
- [使用资源](./使用资源/概述.md)
