# 文件资源处理器

文件资源处理器（FileResourceHandler）用于直接加载指定文件夹中的各种资源文件。通常情况下，界面资源通过(内嵌资源处理器)[assembly-resource-handler.md]打包到您应用程序的程序集内，但对于需要随时访问的临时性的数据，例如图片（零散）、视频（大体积）、音频等多媒体素材、文件等，建议您放置到特定目录，并通过使用文件资源处理器加载它们。

有关于资源处理器的运作原理，请参考[《实现您自己的资源处理器》](custom-resource-handler.md)。如果需要了解更详细的实现细节，请参考[此文档](https://bitbucket.org/chromiumembedded/cef/wiki/GeneralUsage#markdown-header-scheme-handler)。

本章节涉及的内容

- [安装](#安装)
- [注册资源访问入口](#注册资源访问入口)
- [使用资源](#使用资源)
- [技巧](#技巧)

## 安装

在安装文件资源处理器前，请确保您的项目已正确的安装并引用了 NanUI 的基础库以及运行时依赖项。同样推荐使用 NuGet 包管理器来安装内嵌资源处理的 NuGet 包，在包管理器中输入下面的命令来安装：

```
PM> Install NetDimension.NanUI.FileResourceHandler
```

## 注册资源访问入口

规划好您的文件资源，并放置到特定的文件夹后，您还需要为这个文件夹注册一个可以访问的入口。在 NanUI 初始化时，使用文件资源处理器的扩展方法`UseFileResource`来注册这个存放本地资源文件的文件夹。

```C#
Bootstrap
    .Initialize()
    // ...
    .UseFileResource(ResourceHandlerScheme.Http, "files.app.local", System.IO.Path.Combine(Application.StartupPath, "files"))
    // ...
    .Run(() => // ...);
```

UseFileResource 方法具有 3 个参数：

- `scheme` - type: _ResourceHandlerScheme [`Http`|`Https`]_
- `domain` - type: _string_
- `basePath` - type: _string_

**scheme**

此参数指定了访问资源所需要的 Http Scheme，目前仅提供 Http 和 Https 两种枚举可供选择。

**domain**

此参数指定了一个虚假域名作为访问资源的地址。如代码示例所示，域名`files.app.local`是一个不存在的假域名[^1]。指定该域名后，您就可以在 NanUI 的前端环境中使用该域名来加载指定文件夹中的资源。

需要注意的是，如果您指定了一个能够正常访问的万维网域名，您在当前**应用程序作用域内**，将不能再访问到该域名指向的万维网服务器上的真实内容。简单来说，如果您指定的域名是`www.google.com`，那么在当前应用程序范围内，所有指向`www.google.com`的链接都将映射到您指定的文件夹中的资源文件上，如果该链接请求的资源名称在您指定的文件夹中不存在，那么将返回 404 错误。

**bathPath**

如上述示例所示，build 文件夹存放于您项目的根目录。在不指定**basePath**参数的情况下，如果您想反问 build 文件夹里的 index.html 文件，你需要通过`http://www.app.local/build/index.html`才能正确的定位到程序集里的 index.html 文件。所以，将此参数指定为“build”之后，您就可以 z 直接使用`http://www.app.local/index.html`访问到程序集里的 index.html 文件了。

## 使用资源

至此，您可以在 NanUI 的 Web 环境中尝试使用任何您熟悉的方式，通过指定的协议和域名访问到您指定的文件夹中的文件资源了。

## 技巧

- 您可以直接使用文件资源处理器设置的的 Url 地址（例如示例中的：`http://files.app.local/index.html`）作为 NanUI 浏览器承载窗口 Formium 的启动 Url，在应用程序启动时直接呈现资源内容。
- 对于如何选择资源文件夹的存放路径，如果您的资源文件是动态生成的，并且需要执行 IO 写入操作的，那么建议您将文件夹放置到`NanUI.ApplicationDataDirectory`默认的路径中，因为该目录是具备可写权限的；如果您的资源（例如上面说的固定图片，视频等）并不需要修改和写入，那么可以如上述示例中一样放置到应用程序目录中，因为根据 Windows 7 以及之后的版本，应用程序安装到`Program Files`目录后，默认账户是不具备对该文件夹的写入权限的，用户需要以管理员权限运行应用程序才能修改和写入`Program Files`目录，体验不佳。

[^1]: FileResourceHandler 已默认允许了所有的跨域请求，所以您不仅能从本地访问到文件夹中的内容，也可以从 Internet 的网站上访问这些资源。
