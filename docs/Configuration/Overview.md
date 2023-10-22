# Configure WinFormium Applications

## Overview

WinFormium uses the static method `CreateBuilder` of the `WinFormiumApp` class to create the application builder `AppBuilder`. In the builder you can set CEF's environment parameters, the application's run mode, the application's user data folder, the application's resource folder, etc.

`AppBuilder` provides a series of methods for configuring WinFormium applications. After you configure these parameters, use the `Build` method to create a WinFormium application instance and use the `Run` method to start the application.

```csharp
var app = WinFormiumApp.CreateBuilder()
     // Configure the application here
     // ...
     .Build()
     .Run();
```

Please refer to this section to learn how to configure a WinFormium application.

## Use startup configuration

Use the `UseWinFormiumApp<T>()` generic method of the WinFormium application constructor `AppBuilder` to pass in the startup configuration class. For more information, please refer to ["Startup Configuration"](./Startup Configuration.md).

## Enable built-in browser

When using a WinFormium app, when a user clicks a link in the app, the WinFormium app automatically opens the system default browser to open the link. If you wish to use WinFormium's built-in browser window to open links, you can enable the built-in browser using the `AppBuilder.UseBuiltInBrowser()` method.

```csharp
var app = WinFormiumApp.CreateBuilder()
     .UseBuiltInBrowser()
     //...
     ;
```

## Configure culture of the application

WinFormium applications use the current system's language and culture by default, and you can configure the application's language and culture using the `AppBuilder.UseCulture()` method. The `UserCulture` method accepts a `string` type parameter, which is a language and culture identifier, for example `zh-CN` means Chinese Simplified, `en-US` means English United States.

```csharp
var app = WinFormiumApp.CreateBuilder()
     .UseCulture("en-US")
     //...
     ;
```

## Singleton mode

Use the `AppBuilder.UseSingleInstance()` method to configure the application to run in singleton mode. If the application is already running, you can choose to activate the already running application. The `UseSingleInstance` method accepts an `Aciton<OnApplicationInstanceRunningHanlder>` parameter. `OnApplicationInstanceRunningHanlder` contains the following parameters and methods:

- int ProcessId { get; }
  The process ID of the application that is already running.
- IntPtr MainWindowHandle { get; }
  The main form handle of the already running application.
- Process RunningProcess { get; }
  The process object of an already running application.
- void ActiveRunningInstance()
  Activate an already running application.

```csharp
var app = WinFormiumApp.CreateBuilder()
     .UseSingleApplicationInstanceMode(handler =>
     {
         var retval = MessageBox.Show($"There is already an instance running: {handler.ProcessId}.\r\nDo you want to open its main form?", "Singleton mode is enabled", MessageBoxButtons.YesNo, MessageBoxIcon. Warning);
         if (retval == DialogResult.Yes)
         {
             handler.ActiveRunningInstance();
         }
     })
     //...
     ;
```

## Configure services

Use the `AppBuilder.UseServices()` method to configure the application's services, which accepts an `Action<IServiceCollection>` parameter, which contains a parameter of type `IServiceCollection` where you can register your service. Using `AppBuilder` the service will be registered in each process of the application.

If the service needs to run in the main process, the service should be registered in the `WinFormiumMain` method of `WinFormiumStartup`. For more information about `WinFormiumStartup`, please refer to ["Startup Configuration"](./Startup.md).

## Enable development tools menu

Using DevTools debugging tools is very useful when designing WinFormium applications. You can open DevTools debugging tools in `Formium` using the `OpenDevTools` method. If you wish to enable the DevTools menu in your application, you can enable the DevTools menu using the `AppBuilder.UseDevToolsMenu()` method, which allows you to right-click anywhere to launch DevTools in the context menu.

```csharp
var app = WinFormiumApp.CreateBuilder()
     .UseDevToolsMenu()
     //...
     ;
```

## Clear browser cache

In the CEF interface, there is no method to clear the browser cache. Although WinFormium provides the `AppBuilder.ClearCache()` method to clear the browser cache, this is a very violent way to clear the cache. This method will delete the `Cache` folder in the CEF user data folder. Doing so The consequence is that all caches in your application will be cleared, including cookies, browser history, etc., so you cannot specify a certain type of cache to be deleted.

Also, when CEF loads, it locks the user data folder so you cannot delete files in the user data folder, so you must clear the cache before CEF loads.

```csharp
var app = WinFormiumApp.CreateBuilder()
     .ClearCache()
     //...
     ;
```

## See also

- [Documentation](../Home.md)
- [Startup Configuration](./Startup.md)
- [Setup CEF](./Setup-CEF.md)
- [The Subprocess](./Subprocess.md)
