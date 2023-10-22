# Use application manifest file

## Overview

In traditional WinForm application development, you don't need to care too much about the application manifest file, because these files are not necessary for traditional WinForm applications. But in a WinFormium application, a lot of functionality is tied to the application manifest file, so you need to know how to use the application manifest file.

## Create a manifest file for the application

Right-click Add on your WinFormium application project file, select "Application Manifest File" in "Add", "New Item" and click "Add" to add an application manifest file to the current project.

You can configure the following capabilities for your current app in the application manifest file:

**Set Windows User Account Control Level**

Some applications require an elevated user level to run properly. In this case, you can set the Windows User Account Control level in the application manifest file. For example: reading and writing the registry, reading and writing system files, etc.

Configuration information of each level has been added for you by default in the manifest file. You can select the appropriate level according to your needs.

```xml
<trustInfo xmlns="urn:schemas-microsoft-com:asm.v2">
     <security>
         <requestedPrivileges xmlns="urn:schemas-microsoft-com:asm.v3">
             <!-- UAC manifest options
                   If you want to change the Windows User Account Control level, use
                   Replace the requestedExecutionLevel node with one of the following nodes.

             <requestedExecutionLevel level="asInvoker" uiAccess="false" />
             <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
             <requestedExecutionLevel level="highestAvailable" uiAccess="false" />

                 Specifying the requestedExecutionLevel element disables file and registry virtualization.
                 If your application requires this virtualization for backward compatibility, remove this
                 element.
             -->
             <requestedExecutionLevel level="asInvoker" uiAccess="false" />
         </requestedPrivileges>
     </security>
</trustInfo>
```

If you need to know more about Windows User Account Control levels, please refer to [Windows User Account Control](https://docs.microsoft.com/zh-cn/windows/win32/secauthz/user-account-control).

**Set application DPI awareness**

In Windows 10 and later versions of the Windows operating system, you can set DPI awareness for your application so that the application displays properly on monitors with high DPI scaling. The .NET Core framework already provides you with these features. You do not need to configure the application manifest file for these versions of the framework. However, in applications based on the .NET Framework, you still need to add the following configuration to the application manifest file:

```xml
<application xmlns="urn:schemas-microsoft-com:asm.v3">
     <windowsSettings>
         <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
         <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
     </windowsSettings>
</application>
```

If you need to know more about DPI awareness, please refer to [DPI awareness](https://docs.microsoft.com/zh-cn/windows/win32/hidpi/dpi-awareness).

**Enable theming of Windows common controls and dialog boxes**

In the CEF runtime, you can use Windows common controls and dialog boxes, but the themes of these controls and dialog boxes are not enabled by default. You can add the following configuration in the application manifest file to enable the themes of these controls and dialog boxes. :

```xml
<dependency>
     <dependentAssembly>
         <assemblyIdentity
             type="win32"
             name="Microsoft.Windows.Common-Controls"
             version="6.0.0.0"
             processorArchitecture="*"
             publicKeyToken="6595b64144ccf1df"
             language="*"
     />
     </dependentAssembly>
</dependency>
```

The most intuitive performance after enabling the above configuration is that if this configuration is not enabled, the elements with the `title` attribute in the web page will not be displayed normally, but after enabling it, they can be displayed normally.

## Hint

If your application uses the main process and the browser sub-process to run independently, then you need to add the above configuration to the application manifest files of both the main process and the browser sub-process. And the configuration content needs to be consistent.

## See also

- [Overview](Overview.md)
- [Startup Configuration](./Startup.md)
- [The Subprocess](./Subprocess.md)
