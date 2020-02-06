## Build NanUI

You should use a complier which supports C# 7.0 syntax to build the source code of NanUI.  Visual Studio 2019 (version 16.4 or above) is recommanded.

NanUI will run on .NET 4.0 Client Profile as minimum .NET Framework version requirement, but you still need VS2019 to build the source code as well.

## NuGet

Stable NanUI Library is published on NuGet. Use the following command in package manager to install latest version of NanUI. Package manager will copy cef and cfx dependencies automaticly to your application's bin folder. 

```
PM> Install-Package NetDimension.NanUI
```

## HighDPI Support

If you want to enable high DPI support, you should add configuration below to the application manifest file.

```
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
    </windowsSettings>
</application>
```

If you are running on Windows 8.1, set DpiAwareness Attribute to PerMonitor to enable per monitor diffirent DPI in mulit monitors.
```
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        ...
        <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitor</dpiAwareness>
    </windowsSettings>
</application>
```

If you are running on Windows 10 create update (or later), set DpiAwareness Attribute to PerMonitorV2 to enable per monitor diffirent DPI in mulit monitors with advanced features.
```
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
        <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
    </windowsSettings>
</application>
```

If your applicaiton runs on .NET 4.6 or above, you can use the system DPI setting to resize components of controls by opting in with an entry in the application configuration file (app.config) for your app. The feature is used to auto scale the standard windows form.
```
<configuration>
    ...
    <System.Windows.Forms.ApplicationConfigurationSection>
        <add key="DpiAwareness" value="PerMonitorV2"/>
        <add key="EnableWindowsFormsHighDpiAutoResizing" value="true"/>
    </System.Windows.Forms.ApplicationConfigurationSection>
</configuration>
```


## References
* Chromium Embedded Framework - https://bitbucket.org/chromiumembedded/cef
* ChromiumFX - https://bitbucket.org/chromiumfx/chromiumfx/src/default/
* ColoredConsole - https://github.com/colored-console/colored-console
* WinForm-ModernUI - https://github.com/NetDimension/WinForm-ModernUI