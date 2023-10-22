# Proxy Resources[^1]

[^1]: Agent mapped resource handler is only supported in WinFormium Business Edition.

## Overview

Proxy mapped resources mean that when a resource is requested, the proxy mapped resource handler will forward the request to the specified URL, and then return the response result to the client. Using proxy mapping resources can solve problems such as cross-domain access and API interface mapping.

## Register proxy resource handler

You can use `AppBuilder` to register the proxy mapping resource handler during the WinFormium application creation phase, or you can use `ConfigureServices` of the `WinFormiumStartup` class to configure services to register the proxy mapping resource handler during the WinFormium application configuration phase.

**AppBuilder**

```csharp
class Program
{
     [STAThread]
     static void Main(){
         var builder = WinFormiumApp.CreateBuilder();

         var app = builder
         //...
         .UseProxyResource("https", "www.google.com", "https://www.bing.com")
         .build();

         app.Run();

     }
}
```

Use the extension method `UseProxyResource` of `AppBuilder` to register the proxy mapping resource handler. This method accepts three parameters. The first parameter is the URL protocol of the proxy mapping resource handler. The second parameter is the URL protocol of the proxy mapping resource handler. Url, the third parameter is the target Url of the proxy resource handler.

**WinFormiumStartup**

```csharp
class MyApp : WinFormiumStartup
{
     //...

     public override void ConfigureServices(IServiceCollection services)
     {
         //...
         services.AddProxyResource("https", "www.google.com", "https://www.bing.com");
         //...
     }

}
```

Use the extension method `AddProxyResource` of `WinFormiumStartup` to register the proxy mapping resource handler. This method accepts three parameters. The first parameter is the Url protocol of the proxy mapping resource handler, and the second parameter is the proxy mapping resource handler. Url, the third parameter is the target Url of the proxy resource handler.

## Use proxy resource

In the example in the previous section, we registered a proxy mapping resource handler whose URL address is `https://www.google.com` and its target URL address is `https://www .bing.com`, then when we access `https://www.google.com` in the WinFormium application, the proxy mapping resource handler will forward the request to `https://www.bing.com`, and then Return the response result to the client.

The proxy resource handler, like other resource handlers, is only valid in the current WinFormium process. You cannot access the proxy resource handler outside the current WinFormium process. That is to say, the agent mapping configuration registered in the WinFormium application does not Will affect other applications.

## See also

- [Overview](./overview.md)
- [Embedded File Resource](./Embedded-Resources.md)
- [Local File Resources](./File-Resources.md)
- [Data Resources](./Data-Resources.md)
