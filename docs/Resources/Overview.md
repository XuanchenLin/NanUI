# Resources

## Overview

The WinFormium framework provides a series of resource handlers that you can use to manage your resource files to facilitate browser loading. WinFormium's resource handler is implemented based on CEF's `CefSchemeHandlerFactory` and `CefResourceHandler` interfaces and encapsulates them to make them easier to use.

The principle of the resource handler is to map a URL address to a series of resource file sources. This URL address can be the `http://` or `https://` protocol, or it can be any customized protocol. When the browser loads this URL address, the resource handler will load the corresponding resource file based on the file source.

However, it should be noted that the resource handler is essentially implemented by intercepting the browser's request and returning the resource file stream. Therefore, the resources provided by the resource handler can only be used in the current WinFormium application process and cannot be accessed outside the process. Yes, this is essentially different from running a Web Server locally (for example: IIS, Nginx, etc.). For example, if you register an address like `https://my.resource.local`, you can access this address in the current WinFormium application, but it cannot be accessed in other applications, even on the same computer.

Currently the WinFormium framework provides the following resource handlers:

- [Embedded File Resource](./Embedded-Resources.md)

  Using .NET assemblies as the source of resource files, you can embed various HTML, CSS, JavaScript, image and other files into your .NET assembly, and then use the embedded file resource handler to load these files.

- [Local File Resources](./File-Resources.md)

  Using files in a local folder as the source of resource files, you can place various HTML, CSS, JavaScript, images and other files into any folder, and then use the file resource handler to load these files.

- [Data Resources](./Data-Resources.md)

  Use the coding method closest to ASP.Net WebApi to provide data type resources to the front end. You can write data services according to your needs, define behavior methods in the data service, and define routes for the data services or behavior methods, so that the front end can pass Routing to access these data interfaces.

- [Proxy Resources](./Proxy-Resources.md)

  You can use the proxy mapping resource handler to map one Url address to another Url address. You can simply understand it as a URL redirection. In actual development, using proxy mapping resources can solve problems such as cross-domain access and API interfaces. Mapping and other issues.

## Register resource handler

You can use `AppBuilder` to register resource handlers during the WinFormium application creation phase, or you can use `ConfigureServices` of the `WinFormiumStartup` class to configure services to register resource handlers during the WinFormium application configuration phase.

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
             PhysicalFilePath = "<RESOURCE_FILES_DIR>"
         })
         .build();

         app.Run();

     }
}
```

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
             PhysicalFilePath = "<RESOURCE_FILES_DIR>"
         });
         //...
     }

}
```

## Use resources

In the example in the previous section, we registered a local file resource handler (in two different ways). The URL address of this resource handler is `http://files.app.local`, and its resource file source in the local `<RESOURCE_FILES_DIR>` folder.

In a WinFormium form, you can use this URL to access resource files in a specified folder. For example, access: `http://files.app.local/index.html`, the local file resource handler will map the address to the local file `<RESOURCE_FILES_DIR>\index.html`. If there are multiple levels of directories, such as: `http://files.app.local/subdir/index.html`, the local file resource handler will map the address to the local file `<RESOURCE_FILES_DIR>\subdir\index.html `.

```csharp
class MyWindow : Formium
{
     publicMyWindow()
     {
         Url = "http://files.app.local/"; // There is no need to specify index.html here
                                          //because the resource handler will automatically map to index.html.
                                          // This is achieved through the DefaultFileName property of ResourceSchemeHandlerOptions.
     }
}
```

## See also

- [Documentation](../Home.md)
- [Embedded File Resource](./Embedded-Resources.md)
- [Local File Resources](./File-Resources.md)
- [Data Resources](./Data-Resources.md)
- [Proxy Resources](./Proxy-Resources.md)
