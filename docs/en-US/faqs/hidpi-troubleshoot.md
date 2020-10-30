# Troubleshoot on HiDPI

[[Home](../README.md)]

When Windows has enabled custom zoom level (Win10: Settings->System->Display->Zoom and Layout->Change the size of text, applications, etc.) under high-resolution displays (such as 2K, 4K displays), run The NanUI application may see the following screens, with overlapping interfaces of different sizes, sometimes flashing continuously.

**Note**: Due to the addition of specific processing procedures in NanUI version 0.8, this problem no longer occurs. What you may see is that the current image is blurred. To deal with the problem of image blur, the method is the same as the following.

![HiDPI Bug](../../images/high-dpi-bug.png)

Then, you need to manually add the application manifest file app.manifest, and select the manifest file you manually added in the Application tab of the project properties page.

![Add application manifest](../../images/add-app-manifest.png)

![Specified application list](../../images/target-app-manifest.png)

Uncomment the paragraph about HighDPI support in the app.manifest file.

```xml
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
    </windowsSettings>
</application>
```

If you want to enable multi-monitor scaling at different DPI levels (supported by Windows 8.1 or later), you also need to add the following code.

```xml
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        ...
        <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitor</dpiAwareness>
    </windowsSettings>
</application>
```

If you want to enable the drag zoom feature of different DPI levels for multiple monitors (Windows 10 Creators Update or later), then please change the above code to the following parameters.

```xml
<application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
        <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
        <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
    </windowsSettings>
</application>
```

If your application is based on the .NET CORE 3.1 framework, you don't need to use the above steps, just add the following code directly to the Main method.

```C#
static void Main()
{
    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
    // ...
}
```
