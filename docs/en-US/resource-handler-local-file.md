# File Resource Processor

[[Home](README.md)]

The file resource processor (LocalFileResource) is used to load various resource files in the `specified physical folder`.

It is generally not recommended to pack too large files into the assembly, so if the resource file is relatively large (such as video, audio, etc.) or the resource file requires dynamic operations (such as a large number of downloaded pictures, dynamically generated documents, etc.), then Using the `file resource processor` would be a good choice.

## Installation

Before installing the file resource processor, please ensure that the project has been correctly installed and referenced the NanUI base library and runtime dependencies. It is recommended to use the NuGet package manager to install the NuGet package of the assembly resource processor.

```
PM> Install NetDimension.NanUI.LocalFileResource
```

## Use resource processor

**Registration plan**

The assembly resource processor needs to be registered in the WinFormium startup processing method. Use the `UseEmbeddedFileResource`method in the`application configuration agent` method to register the assembly resource handler scheme.

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseLocalFileResource("http", "static.app.local", @"D:\wwwroot");
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

- **localFileResourceDirectory** `string`

This parameter specifies the folder where the resource file is located. When a resource request is generated, the resource processor will find the file requested in the Url from the specified folder and return it to the requester.

## Use resources

Create a Formium form for testing, use any method (Url jump, AJAX asynchronous access, etc.) in the Web environment to access the resource files in the specified physical folder through the specified protocol and domain name.

The file resource processor has allowed all cross-domain requests by default, so you can not only access the contents of the folder locally, but also access these resources from the Internet page loaded by the Formium form (security issues need to be considered).
