# 数据资源处理器

[[返回目录](README.md)]

- [数据资源处理器](#数据资源处理器)
  - [DataServiceProvider 数据服务适配器](#dataserviceprovider-数据服务适配器)
  - [DataService 数据服务](#dataservice-数据服务)
  - [使用资源处理器](#使用资源处理器)
    - [注册当前程序集内的数据服务](#注册当前程序集内的数据服务)
    - [手动注册数据服务](#手动注册数据服务)

数据资源处理器（DataServiceResource）用于向前端环境提供后台数据。如果您之前接触过 Asp.Net Mvc 的控制器，那么 NanUI 的数据资源处理器提供了类似的开发体验。

与 NanUI 同类型的项目中，向前端提供数据的手段一般是通过向 JavaScript 环境中注册数据提供函数，前端代码通过调用该函数从后台获取数据，通常有两种方法传递数据：

1. 将.NET 对象序列化成 JSON 字符串提交到 JavaScript 环境。
2. 将.NET 对象转译成 Chromium 的 CefValue 再通过 CEF 内部的进程间通信模型传递数据。

第一种方法如果数据量很大时，生成的 JSON 字符串非常长，那么就有很大的几率造成内存溢出从而导致客户端崩溃；第二种方法虽然稳定但代码编写起来很繁琐：在`Browser 进程`和`Renderer 进程`之间来回传递消息，而且数据需要在 CefValue 和 CefV8value 之间平凡转换，难免产生各种奇葩的 BUG 还非常难以调试。

综合以上，数据资源处理器的出现解决了想客户端提供数据的难题。数据资源处理器能自动反射当前程序集（或其他指定程序集）内的数据服务控制器`DataService`的派生类，并能根据路由特性`RouteAttribute`或者控制器的名称自动生成路由表。在前端环境中可使用任意数据请求技术（Fetch，XHR，等等）来获取数据，并且还能向后端数据服务控制器提交数据（GET、POST、PUT 等）。

## DataServiceProvider 数据服务适配器

每个注册的 http 协议和域名对应一个数据服务适配器，一个数据服务适配器又包含了多个数据服务，每个数据服务又包括了多个数据处理程序。

**静态方法**

_DataServiceProvider_ **DataServiceProvider.GetDataServiceProvider(string domainName)**

根据指定的`domainName`获取与之对应的`DataServiceProvider`实例。

_bool_ **RemoveDataServiceProvider(string domainName)**

根据指定的`domainName`移除之对应的`DataServiceProvider`实例。成功返回 true，否则返回 false。

**实例方法**

**ImportDataServiceAssembly(string fileName)**

从位于`fileName`的程序集文件中导入并注册数据服务。

**ImportDataServiceAssembly(Assembly assembly)**

从程序集`assembly`中导入并注册数据服务。

**ImportDataServiceAssemblies(string[] files)**

从文件列表`files[]`中导入并注册数据服务。

**ImportDataServiceAssemblies(string directoryName)**

从指定文件夹`directoryName`中导入所有程序集，加载这些文件后导入并注册数据服务。

**AddDataSevice(DataService service)**

直接添加`DataService`的实例`serivce`到当前数据服务适配器中。

使用`DataServiceProvider`的静态方法可以运行时获取或移除已注册的数据服务适配器，使用数据服务适配器`DataServiceProvider`的实例又能动态的添加数据服务。灵活使用上述的方法，可以将数据服务`DataService`注册到数据服务适配器`DataServiceProvider`里。

## DataService 数据服务

数据服务`DataService`是数据资源处理器的重要组成，它主要负责提供路由数据并根据路由信息获取前端的请求信息。如果您有使用 ASP.Net Mvc 的开发经验那么就不难理解数据服务`DataService`的工作原理。

通过下面的示例，您就可以大致了解数据服务的工作方式。

**HelloService**

此示例在前端请求`http://api.app.local/hello/hi`时，将返回 ContentType 为 `text/plain` 的字符串 `Hello NanUI!`。

```C#
using NetDimension.NanUI.Resource.Data;
using NetDimension.NanUI.Browser.ResourceHandler;

// All: /Hello/Hi
public class HelloService : DataService
{
    public ResourceResponse Hi(ResourceRequest request)
    {
        return Text("Hello NanUI!");
    }
}
```

特别需要指出的，数据服务`DataService`的派生类约定类名称也必须以`Service`结尾，例如示例中的`HelloService`。

在不指定路由特性的情况下，数据服务适配器根据数据服务的名称来生成路由。例如上面的示例将自动生成路由`Hello/Hi`。

另外，如果数据处理程序不指定 Http 方法时，任何提交的请求不论 HttpMethod 是什么方法都将命中路由。

**PassportService**

此示例模拟了一个用户登录的请求，前端通过 POST 方法提交登录信息，使用`ResourceRequest`对象的 JSON 反序列化方法`DeserializeObjectFromJson`将提交过来的数据反序列化为`UserInfo`类型，然后模拟延迟 2000 毫秒后返回登录成功的结果。

```C#
using NetDimension.NanUI.Resource.Data;
using NetDimension.NanUI.Browser.ResourceHandler;

[DataRoute("/account")]
public class PassportService : DataService
{
  // 用户登录模型
  public class UserInfo
  {
    public string Passport { get; set; }
    public string Password { get; set; }
  }

  // 获取当前时间戳
  private string GetTimeStamp()
  {
    TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
    return Convert.ToInt64(ts.TotalSeconds).ToString();
  }

  [RoutePost("user/login")]
  public ResourceResponse Login(ResourceRequest request)
  {
    // 反序列化 JSON 数据
    var result = request.DeserializeObjectFromJson<UserInfo>();

    // 模拟延迟操作
    Task.Delay(2000).GetAwaiter().GetResult();

    // 返回登录成功
    return Json(new { success = true, timestamp = GetTimeStamp(), result });
  }
}
```

示例中的`PassportService`指定了`DataRoute`特性，数据处理程序`Login`方法也指定了`RoutePost`特性并指定了路由地址数据。如果忽略路由特性的情况下。该数据服务和数据处理程序的路由应该是`passport/login`，通过添加路由特性，那么该方法的路由就变成`account/user/login`。

同时，由于数据处理程序`Login`指定了`RoutePost`特性，意味着该方法仅接受 POST 请求，其他请求将被忽略。您可以叠加多个特性以此来指定多个 Http 方法。例如，可以同时指定`RouteGet`和`RoutePost`特性，并为两个特性指定不同的路由地址。

```C#
[RoutePost("user/login")]
[RouteGet("user/logout")]
public ResourceResponse Test(ResourceRequest reqeust)
{
  //...
  return ...
}
```

## 使用资源处理器

程序集资源处理器需要在 WinFormium 启动处理方法中进行注册。在`应用程序配置代理`方法中使用`UseEmbeddedFileResource`方法来注册程序集资源处理器方案。

### 注册当前程序集内的数据服务

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseDataServiceResource("http", "api.app.local");
  // ...
})
.Build()
.Run();
```

省略第三个代理参数时，NanUI 将在当前程序集查找数据服务并自动注册找到的数据服务。

### 手动注册数据服务

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseDataServiceResource("http", "api.app.local", provider=>{
    // provider: DataServiceProvider
    DataServiceProvider.ImportDataServiceAssembly("datasource.dll");
  });
  // ...
})
.Build()
.Run();
```

其中第三个参数的代理参数`provider`为类型`DataServiceProvider`的实例。`DataServiceProvider`提供了静态方法可以根据注册的的`domainName`参数获取与之对应的`DataServiceProvider`实例，可以在运行时动态增加或移除数据服务。
