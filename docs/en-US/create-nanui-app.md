# Create NanUI Application

[[Home](README.md)]

NanUI is based on the core of the Chromium browser, so you can use any front-end technology you are familiar with to create your desktop applications. You can also inject .NET objects or methods into the Javascript environment; in addition, by using the resource processor, you can also easily provide files, multimedia, and data to the Web environment.

You can think of NanUI as a simplified Chromium browser embedded in WinForm. This browser replaces the canvas of the traditional WinForm interface, so you can use your imagination and use any Web front-end technology to design your form interface .

Not only that, you can retain all the features of the .NET framework, be able to use EntityFramework, be able to use multithreading, and even interact with your hardware devices in any way and feed relevant information back to the Web environment. It not only satisfies the requirement of designing beautiful user interface, but also can give play to the powerful functions of .NET.

Read the following steps to create your first NanUI application.

- [Create NanUI Application](#create-nanui-application)
  - [Choose .NET Framework](#choose-net-framework)
  - [Installation](#installation)
  - [Create a simple form](#create-a-simple-form)
    - [Step 1: Create the main form](#step-1-create-the-main-form)
    - [Step 2: Initialization](#step-2-initialization)
    - [Step 3: Run](#step-3-run)

## Choose .NET Framework

You can choose to use Windows Forms (WinForm) applications for .NET Framework or .NET Core based on actual project requirements. For both types of form applications, all API interfaces are the same, and you can easily migrate from one framework to another.

![创建Windows Forms应用程序](../images/create_new_project.png)

## Installation

Now, you need to install NanUI and NanUI's dependencies. It is recommended that you use NuGet package management to install them. Run the following command in the package manager to install:

**Install NanUI**

```
PM> Install-Package NetDimension.NanUI
```

**Install NanUI Dependencies**

```
PM> Install-Package NetDimension.NanUI.Runtime
```

Or you can follow the method described in the previous chapter to manually lay out the dependency file structure.

## Create a simple form

### Step 1: Create the main form

NanUI uses the abstract class `Formium` to create browser-hosted windows, so we don't need to design forms and controls through the form designer as usual. Therefore, we can directly delete the Form1.cs form automatically created for us in the project template.

Create a new MainWindow.cs file, and inherit the Formium abstract class, and implement all abstract interfaces of this class:

```C#
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

class MainWindow : Formium
{
  // Set the form style type
  public override HostWindowType WindowType => HostWindowType.System;
  // 指定启动 Url
  public override string StartUrl => "https://www.formium.net";

  public MainWindow()
  {
    // Specify startup URL
    Size = new System.Drawing.Size(1024, 768);
  }

  protected override void OnReady()
  {
    // Perform browser-related operations here

    //ShowDevTools();
    //ExecuteJavaScript("alert('Hello NanUI')");
  }
}
```

Modify the StartUrl property to specify the URL address to be accessed at startup.

```C#
public override string StartUrl => "https://www.formium.net";
```

Specify the WindowType property and select the presentation style of the form. Currently NanUI provides a variety of window styles to choose from, which will be described in detail in the following chapters.

The native style of Windows Forms will be used in the following code.

```C#
public override HostWindowType WindowType => HostWindowType.System;
```

Use the OnReady overload method to set browser-related actuals, execute initialization JavaScript code, etc. here. In this way, the various behaviors of the browser are processed, such as: choosing which method to handle the newly opened window, how to handle the download request, how to notify the application of the change of the web page title, and so on.

This method is usually executed after the Chromium browser core is initialized.

If you don’t need to deal with specific browser behavior, leave it blank. NanUI has handled most of the browser behavior for you.

Through the above simple coding, you have completed the setup of your first NanUI window, which will use the content of https://www.formium.net as the interface of your form.

So far, the application has not been able to run normally, because we still need to initialize the NanUI and CEF environment.

### Step 2: Initialization

To initialize the operation of NanUI and CEF, we need to put it in the Main method of the application.

```C#
using NetDimension.NanUI;

class Program
{
  static void Main()
  {
    // ...
    WinFormium.CreateRuntimeBuilder(env => {

      env.CustomCefSettings(settings =>
      {
        // Set the relevant parameters of CEF here
      });

      env.CustomCefCommandLineArguments(commandLine =>
      {
        // Specify CEF command line parameters here
      });

    }, app =>
    {
      // Specify the startup form
      app.UseMainWindow(context => new MainWindow());
    })
    .Build()
    .Run();
  }
}
```

The `WinFormium` class is the initial launcher of NanUI. Use the `CreateRuntime` method to start the runtime initialization process. The first delegate parameter can set the settings related to the CEF environment and the command line parameters when the CEF process starts; the second delegate Parameters are mainly used to set some options related to NanUI, such as resource controller injection, registered JavaScript extensions, etc. which will be used later.

**Customize the Form**

If you want to further customize your form, similar to WinForm development, you can set the window size in the form constructor, specify the location of the window to start, and set icons for the window.

What needs to be pointed out here is that after selecting a different `WindowType`, you can also set specific window style attributes for the currently specified `WindowType`. For example, if you set the `Borderless` style for the form, you can set the style in the constructor Use `BorderlessWindowProperties` to specify more behaviors and styles for the current window. For example, `ShadowEffect` is a unique style property of the `Borderless` style window and is used to set the size of the window projection.

For a detailed introduction on how to customize the Formium form, please refer to the specific content in the [NanUI form](nanui-formium.md) chapter.

### Step 3: Run

So far, your first NanUI application has been able to run normally. Press the F5 key to open a window with a web page as the interface.

If everything is normal, then the running result of your first NanUI application should look like the following figure.

![运行结果](../images/system-style.png)
