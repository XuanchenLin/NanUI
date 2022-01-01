
# 源码编译

## 使用默认设置编译

因为 NanUI 支持从 .NET Framework 4.6.2 到最新的 .NET 6.0 框架，并且源代码中使用了 C# 10.0 的新语法，所以如需要编译 NanUI 源码需要使用 __Visual Studio 2022 或更高版本__，并确保安装了相对应的 .NET Framework/.NET 开发框架版本：

- .NET Framework 4.6.2/4.7/4.7.1/4.7.2/4.8 SDK
- .NET Core 3.1 SDK
- .NET 5.0 SDK
- .NET 6.0 SDK

## 按需编译

如果您只希望编译针对特定框架的 NanUI，请手动修改 NanUI 项目文件（NetDimension.NanUI.csproj）中的 `TargetFrameworks` 属性值，默认情况下该设置包含了上述章节中提到的版本。

```xml
<TargetFrameworks>
  net6.0-windows;net5.0-windows;netcoreapp3.1;net48;net472;net471;net47;net462;
</TargetFrameworks>
```

例如，您只想针对 .NET Framework 4.8 和 .NET 6.0 框架编译 NanUI，那么只需保留设置中的 `net48;net6.0-windows;` 设置即可。

```xml
<TargetFrameworks>
  net6.0-windows;net48;
</TargetFrameworks>
```

请根据您的开发环境调整 `TargetFrameworks` 属性值，__如果您的开发环境中没有安装对应的框架 SDK 那么将无法顺利编译__。
