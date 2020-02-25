# 自定义资源处理器

到目前为止，您对随NanUI项目一起公布的三个资源处理器`AssemblyResourceHandler`，`FileResourceHandler`，`RestfulServiceResourceHandler`应该已经有所了解。在NanUI 0.7版中优化了资源处理器的实现方式，它允许您根据具体的需求、通过简单的代码来构建您自己的资源处理器。您可以通过查看NanUI源码中有关这三个资源处理器的逻辑来学习如何为您自己的资源提供自定义资源处理器。

构建您自己的资源处理器方法很简单，在下文中将做一些初步的讲解。

本章节涉及的内容

- [资源处理器组件](#资源处理器组件)
- [示例](#示例)

## 资源处理器组件

- `CustomResource 类` 创建资源处理器的工厂类。您必须通过继承`CustomResource`类来构建您的资源处理器工厂，并通过重载`GetResourceHandler`方法来返回您的资源处理器。
- `ResourceHandlerBase 类` 资源处理器基类。您自定义的资源处理器需要继承`ResourceHandlerBase`，并通过重载`GetResponse`方法来返回`FormiumResponse`类型。`GetResponse`方法的参数`request`中包含了由Web端传回的请求内容（例如：Headers，Method，PostBody等），您可以通过解析请求内容来返回对应的`FormiumResponse`，`FormiumResponse`里的各项数据处理完成后会发送回Web端。

## 示例
下面的示例将引导您创建一个自定义的资源处理器，实现不论收到任何请求都返回当前系统时间的功能。

### 创建自定义资源处理器工厂
MyCustomResourceFactory.cs

```C#
class MyCustomResourceFactory : CustomResource
{
    public MyCustomResourceFactory(ResourceHandlerScheme scheme, string domain)
        : base(scheme, domain)
    {
        
    }

    protected override ResourceHandlerBase GetResourceHandler(string schemeName, CfxBrowser browser, CfxFrame frame, CfxRequest request) 
        => new MyResourceHandler();
}
```

### 实现自定义资源处理器

MyCustomResourceHandler.cs

```C#
class MyCustomResourceHandler : ResourceHandlerBase
{
    protected override FormiumResponse GetResponse(FormiumRequest request)
    {
        // 这里我们不轮任何请求，都返回当前的系统时间
        // 您可以根据实际项目中的需求来处理请求内容，返回对应的资源。
        var response = new FormiumResponse()
        {
            ContentStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(DateTime.Now.ToString())),
            MimeType = "text/plain",
            
        };
    }
}
```

### 注册器

MyResourceHandlerRegister.cs

注册器不是必须的，您可以通过`Bootstrap`类的`RegisterCustomResourceHandler`方法来手动注册您的资源处理器工厂。但为了方便开发与维护，建议您使用类似NanUI内置的三种资源处理器的注册方法，为`NanUI`类添加注册自定义资源处理器的扩展方法。

建议您使用约定的命名方式：`Use<你的资源处理器名称>ResourceHandler`，以此来统一自定义资源处理器注册的扩展方法名。

```C#
public static class ResourceHandlerRegister
{
    public static Bootstrap UseClockResourceHandler(
        this Bootstrap _, 
        ResourceHandlerScheme scheme, 
        string domain 
        //, 如果您的资源处理器有其他参数，参数表因添加在末尾处)
    {
        Bootstrap.RegisterCustomResourceHandler(() => new MyCustomResourceFactory(scheme, domain));
        return _;
    }
}
```

### 注册资源访问入口

```C#
Bootstrap
    .Initialize()
    // ...
    .UseClockResourceHandler(ResourceHandlerScheme.Http, "now.app.local")
    // ...
    .Run(() => // ...);

```

完成资源访问入库的注册后，在您的Web环境中使用任意方式访问到`http://now.app.local/`的任何路径时，都会接收到当前系统的时间。您也可以将这个地址作为浏览器承载窗口的`StartupUrl`属性值来看一看呈现的效果。