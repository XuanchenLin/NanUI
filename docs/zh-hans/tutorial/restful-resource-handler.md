# REST 资源处理器

REST 资源处理器（RestfulServiceResourceHandler）是 NanUI 0.7 版本新加入的资源处理器，使用 REST 资源处理器您可以使用类似 ASP.Net WebAPI 那样为 Web 环境提供数据。在没有这种资源处理器之前，原来版本的 NanUI 为 Web 环境提供数据的主要手段是直接向 Javascript 环境中注入.NET 生成的数据，普遍有两种做法：一种方法是将.NET 对象序列化成 JSON 字符串提交到 JS 环境，这种方法有很大的概率造成内存溢出导致客户端崩溃；另一种方法是将.NET 对象转译成 Chromium 的 CefV8Value 对象，这种方法虽然稳定，但是对于需要处理大量数据的情况下编写 Chromium 的异步操作非常复杂，等待时间过长还有可能造成 Javascript Context 丢失，从而使得回调函数永不触发。

REST 资源处理器的出现就是为了解决向客户端提供大量数据的难题。使用 REST 资源处理器将自动反射程序集中的数据服务控制器（ServiceControll)并根据数据服务控制器的路由特性（RouteAttribute）自动生成路由表。在 Web 环境中，您可以使用任意 AJAX 技术来获取数据，甚至您还可以通过 POST 请求提供有限类型[^1]的参数（可以是 FormValue，也可以是 JSON 数据）。

下面，将详细为您介绍 REST 资源处理器的具体使用细节。

本章节涉及的内容

- [安装](#安装)
- [注册资源访问入口](#注册资源访问入口)
- [ServiceProvider 类](#serviceprovider-类)
- [数据控制器](#数据控制器)
- [使用数据资源](#使用数据资源)
- [帮助开发和完善 REST 资源处理器](#帮助开发和完善-rest-资源处理器)

## 安装

在安装 REST 资源处理器前，请确保您的项目已正确的安装并引用了 NanUI 的基础库以及运行时依赖项。同样推荐使用 NuGet 包管理器来安装内嵌资源处理的 NuGet 包，在包管理器中输入下面的命令来安装：

```
PM> Install NetDimension.NanUI.RestfulResourceHandler
```

## 注册资源访问入口

与其他两种资源处理器相同，您也需要为 REST 资源处理器注册访问入口。在 NanUI 初始化时，使用 REST 资源处理器的扩展方法`UseFileResource`来注册这个存放本地资源文件的文件夹。

```C#
Bootstrap
    .Initialize()
    // ...
    .UseRestfulService(ResourceHandlerScheme.Http, "data.app.local", (provider) => {

    })
    // ...
    .Run(() => // ...);

```

UseRestfulService 方法具有 3 个参数：

- `scheme` - type: _ResourceHandlerScheme [`Http`|`Https`]_
- `domain` - type: _string_
- `provide` - type: _Action&lt;RestfulServiceProvider&gt;(optional)_

**scheme**

此参数指定了访问资源所需要的 Http Scheme，目前仅提供 Http 和 Https 两种枚举可供选择。

**domain**

此参数指定了一个虚假域名作为访问资源的地址。如代码示例所示，域名`data.app.local`是一个不存在的假域名[^2]。指定该域名后，您就可以在 NanUI 的前端环境中使用该域名来调用数据服务适配器里的 restful 数据资源。

**provide（可选参数）**

此参数为可选参数。

如果您需要在 NanUI 启动前就为您的应用注册数据服务控制器，那么通过这个代理的类型为数据服务适配器`RestfulServiceProvider`的参数`provider`来提前注册您的数据服务控制器。

当您不指定它时，NanUI 在不注册任何数据服务控制器，但 NanUI 会为您创建与您注册的 REST 资源处理器`domain`相同的数据服务适配器`RestfulServiceProvider`，您可以稍后通过`RestfulServiceProvider`类的静态方法`GetServiceProvider(string domainName)`来获取数据服务适配器的实例，然后再通过该实例提供的注册数据服务控制器的接口来选择注册的方式。

## ServiceProvider 类

### 静态方法

- `GetServiceProvider(string domainName)` 获取域名为`domainName`的数据服务适配器。

### 实例方法

- `RegisterServiceController(ServiceController controller)` 注册单个数据服务控制器。参数`controller`可以指定任何`ServiceController`的衍生类。
- `ImportServiceAssembly(Assembly assembly)` 注册程序集内的数据服务控制器。通过参数`assembly`来指定程序集。指定后，程序会自动扫面程序集内的`ServiceController`衍生类，然后将数据服务的接口注册到路由表中。
- `ImportServiceAssembly(string fileName)` 扫描文件名为`fileName`的库文件，并扫描该文件里所有程序集里的`ServiceController`衍生类，然后将数据服务的接口注册到路由表中。
- `ImportServiceAssemblies(string directoryName)` 扫描文件夹`directoryName`内的所有库文件，并扫描这些文件内所有程序集里的`ServiceController`衍生类，然后将数据服务的接口注册到路由表中。
- `ImportServiceAssemblies(string[] fileNames)` 扫描参数`fileNames`列表里指定的文件，并扫描这些文件内所有程序集里的`ServiceController`衍生类，然后将数据服务的接口注册到路由表中。

### 示例

注册当前运行的程序集里的数据控制器。

```C#
Bootstrap
    .Initialize()
    // ...
    .UseRestfulService(ResourceHandlerScheme.Http, "data.app.local", (provider) => {
        provider.ImportServiceAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    })
    // ...
    .Run(() => // ...);
```

## 数据控制器

数据控制器`ServiceController`是 REST 资源处理器的核心组件。使用数据控制器，您能使用 ASP.Net WebAPI 相似的体验来编码。

通过下面的示例，您就能大致了解数据服务控制器的工作方式。

```C#
[Route("/api/test")]
class TestController : ServiceController
{
    // route path: /api/test/hello
    [RouteHttpGet("hello")]
    FormiumResponse HelloNanUI(FormiumRequest request)
    {
        // reqeust 提供以下参数：

        // request.Body - byte[] | 当前请求的数据流
        // request.ContentType - string | 请求类型
        // request.Files - string[] | 如果POST过来的数据流中有上传的文件，那么您并不能从Body获取到数据流，只能通过本参数获得本地文件的路径
        // request.Headers - RequestHeader(string[]) | 请求头
        // request.Method - HttpMethod | 请求发送的方法
        // request.QueryString - QueryString(string[]) | 查询字符串
        // request.RequestUrl - string | 发送请求的Url地址
        // request.Uri - Uri | 发送请求的Uri


        // 这是响应Http请求的标准做法：

        //var response = new FormiumResponse();
        //response.MimeType = "text/plain";
        //response.Status = 200;
        //response.ContentStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("Hello NanUI"));
        //return response;

        // 但是数据控制器内部提供了快捷方法：

        // return Content("OK", "text/plain", Encoding.UTF8);

        // 这衍生自Content方法，通过Json.net来序列化对象：

        return Json(new
        {
            text = "Hello NanUI!"
        });
    }


}
```

您可以增加多个数据服务控制器，而且它们可以使用不同的路由地址。您还可以把不同功能的数据服务控制器分散到不同的项目中，而且还能注册到不同的域名下。

## 使用数据资源

在您正确注册了数据控制器之后，您就能在 NanUI 的 Web 环境中调用他们了。以上面的例子为例，您可以使用任何方式提交和获取数据。

```JS
fetch("http://data.app.local/api/test/hello").then(({data})=>{
    console.log(data);
    // console: { text: "Hello NanUI" }
});
```

另外再次强调一下，所有的资源控制器，默认情况已**允许**了所有的跨域请求。

## 帮助开发和完善 REST 资源处理器

REST 资源处理器需要您的帮助！

由于 NanUI 作者的时间精力有限，需要维护和完善 NanUI 主程序的开发。目前 REST 资源处理器已完成了原型开发，基本的功能均已实现，但它任然需要进一步的完善（例如，在 FormiumRequest 扩展诸如`FormValueCollection`之类的的存在）。因此，如果在您有空余时间，并且熟悉 Asp.Net MVC 实现原理的前提下，NanUI 请求您的帮助。

[^1]: 目前 REST 资源处理器不支持文件上传，当您发起 Multipart/form-data 类型的 POST 请求时，数据服务控制器只能接收上传文件的物理路径，您需要根据物理路径自行处理待上传的文件。
[^2]: RestfulServiceResourceHandler 已默认允许了所有的跨域请求，所以您不仅能从本地访问到文件夹中的内容，也可以从 Internet 的网站上访问这些资源。
