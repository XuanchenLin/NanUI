# Local File Resources

## Overview

Local file resources refer to file resources in the local file system. You can specify a folder in the local file system for a local file resource handler and then use the controller in your app to access files in that folder.

## Register local file resource handler

You can use `AppBuilder` to register the local file resource handler during the WinFormium application creation phase, or you can use `ConfigureServices` of the `WinFormiumStartup` class to configure services to register the local file resource handler during the WinFormium application configuration phase.

### Registration example

**AppBuilder**

```csharp
class Program
{
     [STAThread]
     static void Main(){
         var builder = WinFormiumApp.CreateBuilder();

         var app = builder
         //...
         .UseLocalFileResource(new LocalFileResourceOptions
         {
             Scheme = "http",
             DomainName = "files.app.local",
             PhysicalFilePath = Path.Combine(AppContext.BaseDirectory, "wwwroot")
         })
         .build();

         app.Run();

     }
}
```

Use the extension method `UseLocalFileResource` of `AppBuilder` to register a local file resource handler. This method accepts a parameter of type `LocalFileResourceOptions`. You can use this parameter to specify the URL address of the local file resource handler and the folder where the resource is located. Path etc.

**WinFormiumStartup**

```csharp
class MyApp : WinFormiumStartup
{
     //...

     public override void ConfigureServices(IServiceCollection services)
     {
         //...
         services.AddLocalFileResource(new LocalFileResourceOptions
         {
             Scheme = "http",
             DomainName = "files.app.local",
             PhysicalFilePath = Path.Combine(AppContext.BaseDirectory, "wwwroot")
         });
         //...
     }

}
```

Use the extension method `AddLocalFileResource` of `WinFormiumStartup` to register a local file resource handler. This method accepts a parameter of type `LocalFileResourceOptions`. You can use this parameter to specify the URL address of the local file resource handler and the folder where the resource is located. Path etc.

### LocalFileResourceOptions

Parameters of type `LocalFileResourceOptions` are used to specify the URL address of the local file resource handler, the folder path where the resource is located, etc. It contains the following properties:

| Property name    | Type   | Description                                                                                    |
| ---------------- | ------ | ---------------------------------------------------------------------------------------------- |
| Scheme           | string | Url protocol name of the embedded file resource handler, such as `http`, `https`, `file`, etc. |
| DomainName       | string | Url domain name of the embedded file resource handler, for example `embedded.app.local`.       |
| PhysicalFilePath | string | The absolute path to the folder where the resource is located.                                 |

## Use local file resources

In the example in the previous section, we registered a local file resource handler (in two different ways). The URL address of this resource handler is `http://files.app.local`, and its resource file source to the local `wwwroot` folder, then you can use `http://files.app.local` in the WinFormium application to access the resources in the specified folder.

## See also

- [Overview](./overview.md)
- [Embedded File Resources](./Embedded-Resources.md)
- [Data Resources](./Data-Resources.md)
- [Proxy Resources](./Proxy-Resources.md)
