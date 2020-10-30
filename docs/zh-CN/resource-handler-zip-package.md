# 压缩包资源处理器

[[返回目录](README.md)]

压缩包资源处理器（ZippedResource）用于加载程序集内或者物理路径中使用 ZIP 压缩后的各种资源文件。如果在前端资源文件夹结构比较复杂，难以一一设置编译方式使用程序集资源处理器时，压缩包资源处理器是最好的选择。

您可以用任何压缩打包工具把资源压缩成 Zip 文件，NanUI 可以方便的加载它。

## 安装

在安装压缩包资源处理器前，请确保项目已正确安装并引用了 NanUI 基础库以及运行时依赖。推荐使用 NuGet 包管理器来安装程序集资源处理器的 NuGet 包。

```
PM> Install NetDimension.NanUI.ZippedResource
```

## 使用资源处理器

**注册方案**

程序集资源处理器需要在 WinFormium 启动处理方法中进行注册。在`应用程序配置代理`方法中使用`UseEmbeddedFileResource`方法来注册程序集资源处理器方案。

**使用本地目录中的 Zip 文件**

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseZippedResource("http", "archive.app.local", @"D:\files\package.zip");
  // ...
})
.Build()
.Run();

```

或

**使用程序集资源内的 Zip 文件**

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseZippedResource("http", "archive.app.local",()=>new MemoryStream(Properties.Resources.ZippedFile));
  // ...
})
.Build()
.Run();
```

这里有两种方式使用 Zip 压缩文件，第一种是直接访问物理路径中的 Zip 文件；另一种是将 Zip 文件作为资源打包到项目里，通过资源获得到该压缩包的`byte[]`数组，让后将其作为内存流提供给资源处理器使用。

## 使用资源

创建一个测试用的 Formium 窗体，在 Web 环境中使用任何方式（Url 跳转、AJAX 异步访问等），通过指定的协议和域名都访问到压缩包里的文件资源。

需要注意的是，Url 中需要指定正确的相对路径。例如，访问`http://archive.app.local/music/are_u_ok.mp3`对应该文件在 Zip 文件中的路径应为`music\are_u_ok.mp3`。
