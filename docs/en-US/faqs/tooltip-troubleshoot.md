# Tooltips in the page are not displayed

[[Home](../README.md)]

If you encounter this problem, add the application manifest file app.manifest to the project and uncomment the content shown below.

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
