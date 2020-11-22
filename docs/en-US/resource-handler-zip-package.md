# Compressed Package Resource Processor

[[Home](README.md)]

The compressed package resource processor (ZippedResource) is used to load various resource files compressed with ZIP in the assembly or in the physical path. If the front-end resource folder structure is complicated and it is difficult to set the compilation method one by one to use the assembly resource processor, the compressed package resource processor is the best choice.

You can use any compression and packaging tool to compress resources into Zip files, and NanUI can load it easily.

## Installation

Before installing the compressed package resource processor, please ensure that the project has been correctly installed and referenced the NanUI basic library and runtime dependencies. It is recommended to use the NuGet package manager to install the NuGet package of the assembly resource processor.

```
PM> Install NetDimension.NanUI.ZippedResource
```

## Use resource processor

**Registration plan**

The assembly resource processor needs to be registered in the WinFormium startup processing method. Use the `UseEmbeddedFileResource`method in the`application configuration agent` method to register the assembly resource handler scheme.

**Use Zip file in local directory**

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseZippedResource("http", "archive.app.local", @"D:\files\package.zip");
  // ...
})
.Build()
.Run();

```

or

**Use the Zip file in the assembly resource**

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseZippedResource("http", "archive.app.local",()=>new MemoryStream(Properties.Resources.ZippedFile));
  // ...
})
.Build()
.Run();
```

There are two ways to use Zip compressed files, the first is to directly access the Zip files in the physical path; the other is to package the Zip files as resources into the project, and obtain the `byte[]` of the compressed package through resources Array, and then provide it as a memory stream to the resource processor.

## Use resources

Create a Formium form for testing, use any method (Url jump, AJAX asynchronous access, etc.) in the Web environment to access the file resources in the compressed package through the specified protocol and domain name.

It should be noted that the correct relative path needs to be specified in the Url. For example, to access `http://archive.app.local/music/are_u_ok.mp3`, the corresponding file path in the Zip file should be `music\are_u_ok.mp3`.
