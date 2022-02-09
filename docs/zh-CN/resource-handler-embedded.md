# 程序集资源处理器

[[返回目录](README.md)]

- [程序集资源处理器](#程序集资源处理器)
  - [整理资源](#整理资源)
  - [使用资源处理器](#使用资源处理器)
  - [使用资源](#使用资源)

程序集资源处理器（EmbeddedFileResource）用于加载作为`嵌入的资源`打包到程序集里的各种资源文件。这是 NanUI 应用中最常见的资源打包方式。

## 整理资源

通常情况您需要对前端页面进行打包以减小文件的体积并排除不必要的文件（例如`SourceMap`文件）。拷贝整理过的资源文件到当前 NanUI 项目中。您可以根据需要在项目根目录建立文件夹以方便集中资源。

拷贝完成后在`解决方案资源管理器`中选中这些资源文件，并在`属性窗口`中找到`生成操作`一栏，选择操作为`嵌入的资源`。

![设置生成操作](../images/set-resource-build-action.png)

上图示例使用了 WebPack 打包的资源，其中只需选中需要的文件，没必要的文件无需设置为`嵌入的资源`。

遵循上述操作，当您的项目成功编译后，选中的资源就自动打包到您的程序集中了。

对于 .NET Core 3.1 及以上版本的项目文件，您可以在 Visual Studio 中直接双击打开项目文件修改配置的方法来设置嵌入资源，而且您还可以使用通配符来简化操作。

例如，如果需要把`build`文件夹中的所有文件设置为嵌入资源，那么直接添加以下配置：

```xml
<ItemGroup>
  <None Remove="build\**\*" />
</ItemGroup>

<ItemGroup>
  <EmbeddedResource Include="build\**\*" />
</ItemGroup>
```

## 使用资源处理器

**注册方案**

程序集资源处理器需要在 WinFormium 启动处理方法中进行注册。在`应用程序配置代理`方法中使用`UseEmbeddedFileResource`方法来注册程序集资源处理器方案。

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseEmbeddedFileResource("http", "assembly.app.local", "wwwroot");
  // ...
})
.Build()
.Run();
```

使用`UseEmbeddedFileResource`方法注册资源处理器方案，需要指定以下参数：

- **scheme** `string`

  此参数指定了访问资源所需要使用的协议，一般情况下设置为常用的`http`协议即可。

- **domainName** `string`

  domainName 参数需要指定一个虚假的域名来作为资源访问的地址。需要注意的时，这里注册的域名外部是无法访问的，该域名仅在当前 NanUI 应用程序范围内可用，这里跟真实的 Web 服务是有区别的。如代码示例所示，域名`assembly.app.local`是一个不存在的假域名，指定该域名后就可以在 NanUI 的前端环境中使用该域名来加载资源。

  需要注意的是，如果您指定了一个能够正常访问的万维网域名，您在当前**应用程序作用域内**，将不能再访问到该域名指向的万维网服务器上的真实内容。简单来说，如果您指定的域名是`www.google.com`，那么在当前应用程序范围内，所有指向`www.google.com`的链接都将映射到您的当前资源处理器上，如果该链接请求的资源在您的程序集中不存在，那么将返回 404 错误。

- _(可选)_ **resourceAssembly** `Assembly`

  此参数是您打包资源的程序集。如代码所示，省略该参数的话将从当前入口程序集加载资源。您可以将资源文件单独打包到一个`类库`类型的项目中，然后在启动时加载此类库程序集实例并作为参数传递，那么就可以实现资源和主程序分离的目标，减小主程序体积。

- _(可选)_ **resourceFileRootPath** `string`

  此参数指定了资源文件访问根目录。例如，您的资源存放在`项目目录\wwwroot`文件中，如果不指定此参数，在您访问资源时您需要在 Url 中显式地指定`wwwroot`文件夹。以上面代码为例，如果要在前端环境访问`项目目录\wwwroot\index.html`文件，那么 Url 需要写成 `http://assembly.app.local/wwwroot/index.html`。在此参数中指定了根目录`wwwroot`后就 URL 中就无须显式地指定`wwwroot`路径，使用`http://assembly.app.local/index.html`即可。

`UseEmbeddedFileResource`方法提供了多种重载方法以方便应对不同场景。总体来说，理解上述参数后即可灵活运用这些重载方法来减少代码量。

## 使用资源

创建一个测试用的 Formium 窗体，在 Web 环境中使用任何方式（Url 跳转、AJAX 异步访问等），通过指定的协议和域名就能访问到程序集里的各项资源文件。

如上述示例中指定的地址，把`http://assembly.app.local/index.html`作为 Formium 窗体的起始 Url，项目启动后将自动加载程序集中的文件。
