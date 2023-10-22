# Startup Configuration

## Overview

Use the `UseWinFormiumApp<T>()` generic method of the WinFormium application constructor `AppBuilder` to pass in the startup configuration class. The startup configuration class must inherit from the `WinFormiumStartup` abstract class, which is mainly used to configure the initialization information of the WinFormium application. .

The `WinFormiumStartup` abstract class contains a series of abstract methods and virtual methods. You can implement or override these methods in subclasses to configure the initialization information of the WinFormium application.

## Configure the main form of the application

Use the `UseMainWindow` method to configure the application's main form. This method accepts a `MainWindowOptions` parameter, which contains a series of configuration options where you can configure the application's main form.

**UseMainFormium**

The `MainWindowOptions.UseMainFormium` method accepts a generic parameter, which must be inherited from the `Formium` class, which is used to configure the form's style and home page address. This method using generic parameters supports dependency injection, and you can inject the services you need in the constructor.

```csharp
protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
{
     return opts.UseMainFormium<MyFormiumWin>();
}
```

At the same time, `MainWindowOptions.UseMainFormium` also provides an overloaded method that accepts a `Formium` parameter, and you can directly use an instance of a `Formium` derived class.

```csharp
protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
{
     return opts.UseMainFormium(new MyFormiumWin());
}
```

**UseMainForm**

If your application requires a `Form` as the main form of the application, WinFormium allows you to use a normal Form as the main form.

The `UseMainForm` method receives a generic parameter, which is inherited from the `Form` class. This method using generic parameters supports dependency injection, and you can inject the services you need in the constructor.

```csharp
protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
{
     return opts.UseMainForm<MyForm>();
}
```

At the same time, `MainWindowOptions.UseMainForm` also provides an overloaded method that accepts a `Form` parameter, and you can directly use an instance of a `Form` derived class.

```csharp
protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
{
     return opts.UseMainForm(new MyForm());
}
```

You need to return the return value of the framework method provided by the `MainWindowOptions` parameter in the `UseMainWindow` method. This return value is a proxy of type `MainWindowCreationAction`, which contains the related logic of form creation.

## Configure the main process of the application

Configure the main process of the application using the `WinFormiumMain` method, which accepts a `string[]` parameter, which contains the command line parameters passed in when the application starts.

The function of this method is to replace the `Main` method in the WinForm default template. In [Overview](Overview.md), the theoretical knowledge of CEF multi-process architecture is briefly introduced. In CEF's multi-process architecture, the main process and rendering The processes are separated, and some code in the main process should not run in the rendering process, so you should execute the code in the main process in the `WinFormiumMain` method.

Because the entry method `Main` is also called when the child process is started, if some code of the main process is placed in the `Main` method according to previous understanding, then the child process will also run these codes. For example, you initialize the Quartz.net component in the `Main` method of the WinFormium application to perform some scheduled tasks, but the `Main` method will also be executed when the child process starts, so the Quartz.net component will be in the child process. execution, this will cause the child process to also execute these scheduled tasks, which is obviously incorrect.

Therefore, it is strongly recommended to execute the code in the original `Main` method in the `WinFormiumMain` method, which can prevent the child process from running some incorrect initialization code.

```csharp
protected override void WinFormiumMain(string[] args)
{
     // The code in the Main function should go here, this function only runs in the main process.
     // This prevents the child process from running some incorrect initialization code.
     ApplicationConfiguration.Initialize();
}
```

## Configure Chromium Embedded Framework

Use the `ConfigurationChromiumEmbedded` method to configure Chromium Embedded Framework, which accepts a `ChromiumEnvironmentBuiler` parameter, which contains a series of configuration options where you can configure the CEF running environment or parameters.

**ConfigureCommandLineArguments**

When using any CEF-based framework, configuring CEF's command line parameters is essential. In WinFormium, you can configure CEF's command line arguments using the `Aciton<ConfigureCommandLineArguments>` method.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.ConfigureCommandLineArguments(cmdLine =>
     {
         cmdLine.AppendArgument("disable-web-security");
         cmdLine.AppendSwitch("no-proxy-server");
     });
}
```

For more information about CEF command line parameters, see [Chromium Command Line Parameter List](https://peter.sh/experiments/chromium-command-line-switches/). It should be noted that some of the command line parameters listed in this document are not applicable to CEF, so you need to refer to the CEF documentation to understand the command line parameters supported by CEF.

**ConfigureDefaultSettings**

Use the `ConfigureDefaultSettings` method to configure the default settings of CEF. This method accepts an `Action<CefSettings>` parameter, which contains a series of configuration options. You can configure the default settings of CEF here.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.ConfigureDefaultSettings(settings =>
     {
         settings.WindowlessRenderingEnabled = true;
     });
}
```

**ConfigureDefaultBrowserSettings**

Use the `ConfigureDefaultBrowserSettings` method to configure CEF's default browser settings. This method accepts an `Action<CefBrowserSettings>` parameter, which contains a series of configuration options. You can configure CEF's default browser settings here.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.ConfigureDefaultBrowserSettings(settings =>
     {
         settings.BackgroundColor = new CefColor(0, 0, 0, 0);
     });
}
```

**ConfigureSubprocess**

Use the `ConfigureSubprocess` method to configure the CEF subprocess. This method accepts an `Action<SubprocessOptions>` parameter, which contains a series of configuration options. You can configure the CEF subprocess here.

In the multi-process architecture of CEF, the main process and the rendering process are separated. By default, CEF starts multiple current executable files as child processes. When introducing the CEF multi-process architecture in [Overview](Overview.md) as mentioned before, if the main application executable file is large and has a lot of logic, the loading time will be very long, and starting the executable file multiple times as a child process will also occupy too much memory. In this case, you can Use a separate executable file as its child process to speed up application startup time and reduce memory usage.

```csharp
protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
{
     cef.ConfigureSubprocess(sub =>
     {
         //Specify the file path of Subprocess
         sub.SubprocessFilePath = "WinFormiumSubProcess.exe";
     });
}
```

The `WinFormiumSubProcess.exe` mentioned in the above code example is a sub-process executable file created separately to separate the main process and the rendering process. You can find it in ["The Subprocess"](./Subprocess.md) Learn how to create a standalone subprocess executable.

**other**

The `ChromiumEnvironmentBuiler` parameter also provides many other methods for configuring the CEF running environment or parameters. You can refer to the following documents to learn more:

- [Setup CEF](Setup-CEF.md)

## Configure application services

Use the `ConfigureServices` method to configure the application's services, which accepts an `IServiceCollection` parameter, which contains a series of configuration options where you can configure the application's services.

Please note that the services registered in the `ConfigureServices` method in `WinFormiumStartup` can only be used in the main process. If you need to use the service in all processes, please register the service in the `UseServices` method in `AppBuilder`. However, please note that services registered in different processes are independent of each other, so services registered by child processes cannot be called in the main process, although the names and types of these services are the same.

```csharp
protected override void ConfigureServices(IServiceCollection services)
{
     //Register embedded resources
     services.AddEmbeddedFileResource(new EmbeddedFileResourceOptions
     {
         Scheme = "http",
         DomainName = "embedded.app.local",
         ResourceAssembly = typeof(Program).Assembly,
         EmbeddedResourceDirectoryName = "wwwroot",
     });

     //Register local resources
     services.AddLocalFileResource(new LocalFileResourceOptions
     {
         Scheme = "http",
         DomainName = "files.app.local",
         PhysicalFilePath = Path.Combine(AppContext.BaseDirectory, "wwwroot"),
     });

     //Register JavaScript Window Binding Object
     services.AddWindowBindingObject<TestWindowBindingObject>();
}
```

## See also

- [Overview](Overview.md)
- [Setup CEF](Setup-CEF.md)
