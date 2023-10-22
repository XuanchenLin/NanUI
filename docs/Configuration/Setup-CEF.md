# Set up CEF

[Startup Configuration](./Startup.md) briefly introduces how to use the `UseChromiumEmbeddedFramework` method of the `AppBuilder` class to configure CEF. This chapter will introduce configurations not covered in this document.

## Disable Hidpi scaling for CEF

In CEF, when your application runs on a display with a high DPI scaling ratio, CEF will automatically scale the page content to adapt to the high DPI scaling ratio. The purpose of this is to make the page content appear on the display with a high DPI scaling ratio. The display is clearer. But in some cases, you may not want CEF to automatically scale the page content, then you can use the `DisableHidpiSupport` method to disable CEF's Hidpi scaling.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.DisableHiDpiSupport();
}
```

## Use custom CEF runtime path

Normally you do not need to manually set the CEF runtime path because WinFormium automatically loads the CEF runtime from the NuGet package, but in some cases you may need to manually set the CEF runtime path, such as in your project When there are multiple WinFormium applications, it is not necessary for each WinFormium application to include a CEF runtime. This will cause your application to be too large. In this case, you can put the CEF runtime in a common location, and then Set the CEF runtime path in each WinFormium application.

The runtime path of CEF can be set using the `UseCustomDistributionDirectory` method, which accepts an `Action<CustomDistributionDirectoryOptions>` parameter, which contains a series of configuration options where you can configure the runtime path of CEF.

- public PlatformArchitecture Architecture { get; }
  The architecture of the CEF runtime, which can be x86 or x64.
- public string LibCefPath { get; set; }
  Path to the libcef.dll file of the CEF runtime.
- public string ResourceFilePath { get; set; }
  The path to the resource folder of the CEF runtime.

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

## Set user data folder

In CEF, the user data folder is used to store user configuration files, cache files, cookies and other data. You can use the `UseCustomUserDataDirectory` method to set the user data folder. This method accepts a `string` type parameter, which is The path to the user data folder.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.UseCustomUserDataDirectory("<path to user data>");
}
```

Different application instances cannot share the same user data folder.

If your application does not want to store user data locally, you can use the `UseInMemoryUserData` method to set the user data folder to memory. When the application exits, the user data will be cleared from memory immediately.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.UseInMemoryUserData();
}
```

## Set custom protocol scheme

Various custom resource processors of WinFormium will be introduced in ["Overview"](./Use Resources/Overview.md) of the "Using Resources" chapter. The resource processor registration interface allows you to specify the protocol scheme. By default in CEF A series of protocol schemes, such as `http`, `https`, `file`, `ftp`, etc. If the protocol scheme you specify is not within the default scheme range, such as `app`, `myapp`, etc., then you need Register these custom protocol schemes in CEF, otherwise CEF will not recognize these custom protocol schemes.

You can set custom protocol schemes using the `ConfigureCustomSchemes` method, which accepts an `Action<CefSchemeRegistrar>` parameter, which contains a series of configuration options where you can configure custom protocol schemes.

- public bool AddCustomScheme(string schemeName, CefSchemeOptions options);
  Add custom protocol scheme.

The first parameter of the `AddCustomScheme` method is the name of the custom protocol scheme, and the second parameter `CefSchemeOptions` is the configuration options of the custom protocol scheme. Use the `CefSchemeOptions` enumeration value to configure the properties of a custom protocol scheme.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.ConfigureCustomSchemes(register => {
         register.AddCustomScheme("app", CefSchemeOptions.Standard);
     });
}
```

## See also

- [Overview](Overview.md)
- [Startup Configuration](./Startup.md)
- [Resources](./Resources/Overview.md)
