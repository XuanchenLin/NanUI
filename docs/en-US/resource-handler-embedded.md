# Assembly Resource Processor

[[Home](README.md)]

The assembly resource processor (EmbeddedFileResource) is used to load various resource files that are packaged into the assembly as `embedded resources`. This is the most common way of resource packaging in NanUI applications.

## Installation

Before installing the assembly resource processor, please ensure that the project has been correctly installed and referenced the NanUI base library and runtime dependencies. It is recommended to use the NuGet package manager to install the NuGet package of the assembly resource processor.

```
PM> Install NetDimension.NanUI.AssemblyResourceHandler
```

## Organize resources

Usually you need to package the front-end page to reduce the file size and exclude unnecessary files (such as `SourceMap` files). Copy the organized resource files to the current NanUI project. You can create folders in the project root directory as needed to facilitate resource concentration.

After the copy is complete, select these resource files in the `Solution Explorer`, and find the column of `Generate Operation` in the `Properties Window`, and select the operation as `Embedded Resources`.

![Set Build Action](../images/set-resource-build-action.png)

The example above uses the resources packaged by WebPack, in which only the required files need to be selected, and unnecessary files do not need to be set as `embedded resources`.

Follow the above operations, when your project is successfully compiled, the selected resources will be automatically packaged into your assembly.

## Use resource processor

**Registration plan**

The assembly resource processor needs to be registered in the WinFormium startup processing method. Use the `UseEmbeddedFileResource` method in the `application configuration agent` method to register the assembly resource handler scheme.

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseEmbeddedFileResource("http", "assembly.app.local", "wwwroot");
  // ...
})
.Build()
.Run();
```

To use the `UseEmbeddedFileResource` method to register a resource processor solution, you need to specify the following parameters:

- **scheme** `string`

  This parameter specifies the protocol that needs to be used to access the resource. Generally, it is set to the commonly used `http` protocol.

- **domainName** `string`

  The domainName parameter needs to specify a fake domain name as the address for resource access. It should be noted that the domain name registered here is not accessible from outside, and the domain name is only available within the scope of the current NanUI application, which is different from the real web service. As shown in the code example, the domain name `assembly.app.local` is a non-existent fake domain name. After the domain name is specified, the domain name can be used to load resources in the NanUI front-end environment.

  It should be noted that if you specify a web domain name that can be accessed normally, you will no longer be able to access the real content on the web server pointed to by the domain name within the current **application scope**. Simply put, if the domain name you specify is `www.google.com`, then within the scope of the current application, all links to `www.google.com` will be mapped to your current resource processor, if The resource requested by the link does not exist in your assembly, then a 404 error will be returned.

- _(Optional)_ **resourceAssembly** `Assembly`

  This parameter is the assembly in which you package the resource. As shown in the code, if this parameter is omitted, resources will be loaded from the current entry assembly. You can package the resource files separately into a `class library` type project, and then load an instance of such library assembly at startup and pass it as a parameter, then you can achieve the goal of separating resources from the main program and reduce the main program volume.

- _(Optional)_ **resourceFileRootPath** `string`

  This parameter specifies the root directory for resource file access. For example, your resources are stored in the `project directory\wwwroot` file. If you do not specify this parameter, you need to explicitly specify the `wwwroot` folder in the Url when you access the resources. Take the above code as an example, if you want to access the `project directory\wwwroot\index.html` file in the front-end environment, then the Url needs to be written as `http://assembly.app.local/wwwroot/index.html`. After the root directory `wwwroot` is specified in this parameter, there is no need to explicitly specify the `wwwroot` path in the URL, just use `http://assembly.app.local/index.html`.

The `UseEmbeddedFileResource` method provides a variety of overloaded methods to facilitate different scenarios. In general, after understanding the above parameters, you can flexibly use these overloading methods to reduce the amount of code.

## Use resources

Create a Formium form for testing, and use any method (Url jump, AJAX asynchronous access, etc.) in the Web environment to access various resource files in the assembly through the specified protocol and domain name.

As the address specified in the above example, use `http://assembly.app.local/index.html` as the inspiration URL of the Formium form, and the files in the assembly will be automatically loaded after the project is started.
