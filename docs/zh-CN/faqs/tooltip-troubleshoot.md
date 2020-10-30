# 页面中的工具提示（Tooltips）不显示

[[返回目录](../README.md)]

如果遇到此问题，在项目中添加应用程序清单文件 app.manifest，并取消下面所示内容的注释即可。

```xml
<!-- Enable themes for Windows common controls and dialogs (Windows XP and later) -->

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
