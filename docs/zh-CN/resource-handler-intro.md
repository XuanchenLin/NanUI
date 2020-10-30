# 资源处理器

[[返回目录](README.md)]

- [资源处理器](#资源处理器)
  - [创建资源处理器](#创建资源处理器)
  - [使用资源处理器](#使用资源处理器)
  - [ResourceRequest 和 ResourceResponse](#resourcerequest-和-resourceresponse)
    - [ResourceRequest 对象](#resourcerequest-对象)
    - [ResourceResponse 对象](#resourceresponse-对象)
  - [延伸](#延伸)

NanUI 将 Chromium Embedded 框架中的`CefResourceHandler`进行了封装和简化，您无需再自行实现`CefResourceHandler`的流处理以及`CefSchemeHandlerFactory`接口繁琐的注册流程。NanUI 将 CEF 原本注册资源的整套流程封装成两个抽象类`ResourceSchemeConfiguration`和`ResourceHandlerBase`。

- **ResourceSchemeConfiguration**

  资源方案配置器，用于保存资源配置以及注册对应的资源处理器。

- **ResourceHandlerBase**

  资源处理器基类，用于处理请求数据并返回相应资源。

用一个非常简单的例子来演示资源控制器的用法，这个例子的作用是不论请求任何 URL 都返回当前请求的 URL 地址。

## 创建资源处理器

**UrlEchoSchemeConfiguration**

`UrlEchoSchemeConfiguration`用来注册资源处理器，并将其绑定到`scehcme:domainName`这个域名上。这样，前端如果对此地址发出请求，就可以将前端请求正确的路由到`UrlEchoResourceHandler`处理。

```C#
using Xilium.CefGlue;
using NetDimension.NanUI.ResourceHandler;


public class UrlEchoSchemeConfiguration : ResourceSchemeConfiguration
{
    public UrlEchoSchemeConfiguration(string scheme, string domainName)
        : base(scheme, domainName)
    {

    }

    protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
    {
        return new UrlEchoResourceHandler(this);
    }
}
```

**UrlEchoResourceHandler**

`UrlEchoResourceHandler`用来处理请求。`GetResourceResponse`抽象方法的参数`request`包含了前端发送的请求。该请求中包括了`HttpReqeust`应有的数据，例如 Http 请求头`Headers`集合，查询字符串`QueryString`，请求方法`HttpMethod`等。如果请求使用了 POST/PUT/PATCH 方法的话，还能通过`RawData`或`JsonData`取到相应的请求数据。

```C#
using NetDimension.NanUI.ResourceHandler;

public class UrlEchoResourceHandler : ResourceHandlerBase
{
    public UrlEchoSchemeConfiguration Configuration { get; }

    public UrlEchoResourceHandler(UrlEchoSchemeConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override ResourceResponse GetResourceResponse(ResourceRequest request)
    {
        var url = request.RequestUrl;

        var response = new ResourceResponse(request)
        {
            MimeType = "text/plain",
            HttpStatus = System.Net.HttpStatusCode.OK
        };

        response.TextContent(url);

        return response;

    }
}
```

## 使用资源处理器

**注册资源处理器方案**

自定义处理器之后需要在 WinFormium 启动处理方法中的`应用程序配置代理`方法内对其进行注册。

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseCustomResourceHandler(() => new UrlEchoSchemeConfiguration("http","echo.app.local"));
  // ...
})
.Build()
.Run();
```

**测试资源处理器**

创建一个测试用的 Formium 窗体，将其`StartUrl`属性设置为`http://echo.app.local`的任意地址，启动此应用，那么在该窗体中将打印`StartUrl`中传递的页面地址。例如：当 StartUrl = "http://echo.app.local/hello/nanaui" 时，窗体页面将显示`http://echo.app.local/hello/nanaui`字符串。

## ResourceRequest 和 ResourceResponse

`ResourceRequest`对象包括了请求的相关数据而`ResourceResponse`包括了返回给前端的相应数据。类似 Asp.Net 中的`HttpRequest`和`HttpResponse`。如果您了解 Web 后端开发对此并不陌生，因此此处不再赘述，开发时根据这两个类的提示按实际需要进行开发即可。

### ResourceRequest 对象

_属性_

**Uri Uri { get; }**

发送请求的 Uri 地址信息。

**string RequestUrl { get; }**

发送请求的 Url 地址，不包含查询字符串部分。

**NameValueCollection Headers { get; }**

Http 请求的 Headers 信息。

**string[] UploadFiles { get; }**

如果前端提交了上传文件的请求，这个属性将包含上传文件的真实物理路径集合。可以通过真实的物理路径访问文件并进行操作（例如批量上传，使用 .NET 实现 FTP 上传等）。

**byte[] RawData { get; }**

获取前端提交请求的原始数据。

**CefRequest RawRequest { get; }**

获取当前请求的`CefRequest`对象。

**NameValueCollection QueryString { get; }**

获取当前请求的查询字符串。

**NameValueCollection FormData { get; }**

获取当前请求的`FormData`数据。

**JsonValue JsonData { get; }**

获取当前请求的`JSON`数据。

**bool IsJson { get; }**

判断当前请求的数据是否为 JSON 格式。

**Encoding ContentEncoding { get; }**

获取当前请求的字符集编码。

**string StringContent { get; }**

获取当前请求的字符型数据。

**Method Method { get; }**

获取当前请求的方法。

**string ContentType { get; }**

获取当前请求的 ContentType。

_方法_

**T DeserializeObjectFromJson<T>();**

反序列化当前 JSON 数据到类型 T。

### ResourceResponse 对象

_属性_

**string RelativePath { get; }**

根据当前 ResourceRequest 获取相对路径。

**string FileName { get; }**

根据当前 ResourceRequest 获取请求的文件名。

**string FileExtension { get; }**

根据当前 ResourceRequest 获取请求的文件扩展名。

**Stream ContentStream { get; set; }**

设置或获取返回给前端响应的数据流对象。

**HttpStatusCode HttpStatus { get; set; }**

设置或获取返回给前端响应的 HttpStatus 结果。

**long Length { get; }**

获取当前数据流对象的长度。

**string MimeType { get; set; }**

设置或获取返回给前端响应的 MimeType。

**bool HasFileName { get; }**

根据当前 ResourceRequest 判断当前请求的 Url 是否具备文件名。

**NameValueCollection Headers { get; }**

获取返回给前端响应的 Http 头信息合集。

_方法_

**void Content(byte[] buff, string contentType = null)**

设置`buff:byte[]`到返回给前端响应的数据流对象里；并设置`contentType`，该参数为空时使用默认的 MimeType。

## 延伸

理解了资源处理器的运作方式，您可以根据项目的实际需要自行开发符合需求的资源控制器。NanUI 项目中内置了`程序集资源处理器`，`本地文件资源处理器`，`ZIP压缩包资源处理器`和`数据服务资源处理器`几种处理器，他们都是基于`ResourceSchemeConfiguration`和`ResourceHandlerBase`进行开发的。如果有兴趣，您可以通过阅读这几个资源处理器的源码来详细了解 NanUI 资源处理器的运作原理和实现方式。

对于如何使用这几种资源处理器，后面的章节将分项介绍。

- [嵌入程序集中的资源](resource-handler-embedded.md)
- [本地文件资源](resource-handler-local-file.md)
- [ZIP 文件资源](resource-handler-zip-package.md)
- [使用数据服务资源](resource-handler-data-services.md)
