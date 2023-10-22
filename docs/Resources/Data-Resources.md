# Data Resources[^1]

[^1]: Data resource handler only supports WinFormium Business Edition.

## Overview

Data resources are resources whose goal is to provide data. For example, you can use commands and tools such as `fetch` or `axios` on the front end to make requests to the data resource processor to obtain back-end data. WinFormium's data resource handler is a request interceptor that simulates the HTTP protocol. It can intercept HTTP requests initiated by the front end, forward the request to the back-end data resource processor, and then call the registered data service and perform the action in the data service. method and returns data.

It is mentioned here that the data resource handler is a request interceptor that simulates the HTTP protocol, so the data resource handler is not a real HTTP server. It only simulates the action of the request interceptor of the HTTP protocol, so that the front end can use the HTTP protocol. to access the data resource handler, so you cannot access the interface provided by the data service outside the current WinFormium process.

## Register data resource handler

You can use `AppBuilder` to register the data resource handler during the WinFormium application creation phase, or you can use `ConfigureServices` of the `WinFormiumStartup` class to configure services to register the data resource handler during the WinFormium application configuration phase.

### Registration example

**AppBuilder**

```csharp
class Program
{
     [STAThread]
     static void Main(){
         var builder = WinFormiumApp.CreateBuilder();

         var app = builder
         //...
         .UseDataResource("http","api.app.local", provider => {
             provider.ImportFromCurrentAssembly(); //Import data services from the current assembly
         })
         .build();

         app.Run();

     }
}
```

Use the extension method `UseDataResource` of `AppBuilder` to register the data resource handler. The first parameter of the method is the Url protocol of the data resource handler. The second parameter is the Url of the data resource handler. The third parameter is a `Action<DataResourceProvider>` type delegate, you can configure the action of the data resource handler in this delegate. `DataResourceProvider` will be introduced in detail in the following summary.

**WinFormiumStartup**

```csharp
class MyApp : WinFormiumStartup
{
     //...

     public override void ConfigureServices(IServiceCollection services)
     {
         //...
         services.AddDataResource("http","api.app.local", provider => {
             provider.ImportFromCurrentAssembly(); //Import data services from the current assembly
         });
         //...
     }

}
```

### DataResourceProvider

`DataResourceProvider` is the configuration class of the data resource handler. You can configure the action of the data resource handler in `DataResourceProvider`. It provides the following methods:

| Method                                    | Description                                                                                                                      |
| ----------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| ImportFromAssemblies(string[] files)      | Import data services from the specified assembly file. `files` is the absolute path to the assembly containing the data service. |
| ImportFromAssembly(Assembly assembly)     | Import data services from the specified assembly. `assembly` is the assembly that contains the data service.                     |
| ImportFromCurrentAssembly()               | Imports data services from the current assembly.                                                                                 |
| ImportFromDirectory(string directoryName) | Import data services from the specified folder. `directoryName` is the absolute path to the folder containing the data service.  |
| ImportFromFile(string fileName)           | Import data service from the specified file. `fileName` is the absolute path to the file containing the data service.            |

## Data Service

Data service is a class inherited from `DataResourceService`. You can define some action methods in the data service. Then when the data resource handler is initialized, an instance of the data service will be generated based on the configuration of the data service and action methods. The front end initiates When making an HTTP request, the data resource handler will call the action method of the data service based on the requested Url and return the data.

### Create Data Service

In the following code example, we define a data service `EchoService`, which inherits from `DataResourceService`. When special declaration is required, the data service must end with `Service`, such as `EchoService`, otherwise the data resource handler cannot recognize the class as a data service.

```csharp
using WinFormium.WebResource;

[RoutePath("/Echo/")]
public class TestService : DataResourceService
{
     ILogger<TestService> _logger;

     public TestService(ILogger<TestService> logger)
     {
         _logger = logger;
     }
     // ...
}
```

`RoutePathAttribute` is the routing configuration of the data service. If you do not configure a route for the data service, the data resource handler will use the class name of the data service as the route. For example, the route of `TestService` is `/Test/`. In the above example code, we configured the route `/Echo/` for the data service, then the data resource handler will use `/Echo/` as the route for the data service.

In addition, the data service supports dependency injection. You can inject the services you need in the constructor of the data service. For example, in the above code, we inject a service of type `ILogger<TestService>`, so that we can The `ILogger<TestService>` service is used in the data service. Services need to be registered in the `ConfigureServices` method of `WinFormiumStartup`.

### Create action

Let's continue to improve the above data service example and define a action method `Hello` in the data service, which returns a string `Hello World!`.

```csharp
using WinFormium.WebResource;

[RoutePath("/Echo/")]
public class TestService : DataResourceService
{
     [HttpGetMethod("Hi")]
     public IResourceResult Hello()
     {
         return Text("Hello World!");
     }
}
```

The action method of the data service needs to return data of type `IResourceResult`. That is to say, only the method with the return value of `IResourceResult` will be recognized as the action method of the data service. As with data services, you can also specify routes for actions individually. For example, in the above code, we specify the route `Hi` for the data service action `Hello`, then the data resource handler will use `/Echo/Hi` as the route for the data service action.

The routing attributes of data service actions are inherited from `HttpMethodAttribute`. Depending on the actual situation, you can use `HttpGetMethodAttribute`, `HttpPostMethodAttribute`, `HttpPutMethodAttribute`, `HttpDeleteMethodAttribute`, `HttpPatchMethodAttribute`, `HttpHeadMethodAttribute`, `HttpOptionsMethodAttribute` to specify routing and Http methods of action. The action only responds to requests for the specified Http method. If you do not specify an Http method, the action will respond to requests for all Http methods.

### Return value of action method

In the above code, the `Text` method is used to return string content. You can also use the `Json` method to return Json data.

The `DataResourceService` class provides the following methods and properties:

**Attributes**

| Property name | Type             | Description                                 |
| ------------- | ---------------- | ------------------------------------------- |
| Request       | ResourceRequest  | Get information about the current request.  |
| Response      | ResourceResponse | Get information about the current response. |

**Methods**

| Method name                        | Description                                                                                                                                                                                                                     |
| ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| BadReqeust()                       | Returns an error result with status code 400.                                                                                                                                                                                   |
| Content(string,string)             | Returns a result with status code 200. The result content is the content of the `content` parameter, and the `contentType` parameter is the content type of the result.                                                         |
| Content(string,string,Encoding)    | Returns a result with status code 200. The result content is the content of the `content` parameter, the `contentType` parameter is the content type of the result, and the `encoding` parameter is the encoding of the result. |
| Json(object,JsonSerializerOptions) | Returns a result with status code 200. The result content is the content of the `object` parameter. This parameter will be serialized into a Json string. The `options` parameter is the serialization option of the result.    |
| Json<T>(T,JsonSerializerOptions)   | Returns a result with status code 200. The result content is the content of the `T` parameter. This parameter will be serialized into a Json string. The `options` parameter is the serialization of the result. options.       |
| NoContent()                        | Returns a result with status code 204.                                                                                                                                                                                          |
| NotFound()                         | Returns an error result with status code 404.                                                                                                                                                                                   |
| Ok()                               | Returns a result with status code 200.                                                                                                                                                                                          |
| StatusCode(int)                    | Returns a result whose status code is the `statusCode` parameter.                                                                                                                                                               |
| StatusCode(HttpStatusCode)         | Returns a result whose status code is the `HttpStatusCode` parameter.                                                                                                                                                           |
| Text(string)                       | Returns a result with status code 200, and the result content is the content of the `text` parameter.                                                                                                                           |

### Parameters of action methods

You can define parameters in the action method of the data service. The data resource handler will call the action method of the data service and automatically assign values to the parameters based on the parameters requested by the front end.

```csharp
using WinFormium.WebResource;

[RoutePath("/Echo/")]
public class TestService : DataResourceService
{
     // ...

     [HttpGetMethod]
     public IResourceResult Test(int id, string[] message)
     {
         return Json(new { id = id, text = string.Join(",", message) });
     }

}
```

The above code defines a `Test` action, which has two parameters `id` and `message`. `id` is a parameter of type `int` and `message` is a parameter of type `string[]`. When the front end initiates a request for `http://api.app.local/Echo/Test?id=1&message=hello&message=world`, the data resource handler will automatically assign the value of `1` to the `id` parameter and `message` The parameter assignment is `["hello","world"]`.

Let’s look at the following code:

```csharp
using WinFormium.WebResource;

[RoutePath("/Echo/")]
public class TestService : DataResourceService
{
     //Hi...

     //Test...

     [HttpPostMethod]
     public async Task<IResourceResult> TestAsync([JsonBody] Model m)
     {
         var request = Request;

         await Task.Delay(5000);

         return Json(m);
     }
}
```

The above code defines a `TestAsync` action, which has a parameter `m`, which is a parameter of type `Model`. When the front end initiates a request to `http://api.app.local/Echo/TestAsync`, the data resource handler will automatically assign the value of the `m` parameter to the requested Json data. It should be noted that the `m` parameter must be modified with the `[JsonBody]` attribute, otherwise the data resource handler cannot recognize the parameter as Json data.

Also you should note that this method is asynchronous and yes, you can use asynchronous methods in action methods of data services. In the above example, `await Task.Delay(5000);` is used to simulate a time-consuming operation. What you also need to know is that the data service will not block the main process regardless of the asynchronous or synchronous method.

### Test data service

You can use the following front-end code to test the action method `/Echo/Hi` of the data service:

```javascript
fetch("http://api.app.local/Echo/Hi")
  .then((res) => res.text())
  .then(console.log); //console: Hello World!
```

You can use the following front-end code to test the data service's actional method `/Echo/Test`:

```javascript
fetch("http://api.app.local/Echo/Test?id=1&message=hello&message=world")
  .then((res) => res.json())
  .then(console.log); //console: {id: 1, text: "hello,world"}
```

You can use the following front-end code to test the data service's actional method `/Echo/TestAsync`:

```javascript
fetch("http://api.app.local/Echo/TestAsync", {
  method: "POST",
  headers: {
    "Content-Type": "application/json",
  },
  body: JSON.stringify({ id: 1, text: "Hello WinFormium !!" }),
})
  .then((res) => res.json())
  .then(console.log); //console: {id: 1, text: "Hello WinFormium !!"}
```

## See also

- [Overview](./Overview.md)
- [Embedded File Resource](./Embedded-Resources.md)
- [Local File Resources](./File-Resources.md)
- [Proxy Resources](./Proxy-Resources.md)
