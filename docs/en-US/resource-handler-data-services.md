# Data Resource Processor

[[Home](README.md)]

- [Data Resource Processor](#data-resource-processor)
  - [Installation](#installation)
  - [DataServiceProvider Data Service Adapter](#dataserviceprovider-data-service-adapter)
  - [DataService Data Service](#dataservice-data-service)
  - [Use resource processor](#use-resource-processor)
    - [Register the data service in the current assembly](#register-the-data-service-in-the-current-assembly)
    - [Manually register data service](#manually-register-data-service)

The data resource processor (DataServiceResource) is used to provide background data to the front-end environment. If you have been in contact with Asp.Net Mvc controller before, then NanUI's data resource processor provides a similar development experience.

In projects of the same type as NanUI, the way to provide data to the front-end is generally to register a data-providing function in the JavaScript environment. The front-end code obtains data from the background by calling this function. There are usually two ways to transfer data:

1. Serialize the .NET object into a JSON string and submit it to the JavaScript environment.
2. Translate the .NET object into Chromium's CefValue and then pass the data through the inter-process communication model inside CEF.

In the first method, if the generated JSON string is very long when the amount of data is large, there is a high chance of causing a memory overflow and causing the client to crash; the second method is stable, but the code is cumbersome to write: Messages are passed back and forth between the Browser process`and the`Renderer process`, and the data needs to be converted between CefValue and CefV8value. It is inevitable that various strange bugs will be generated and it is very difficult to debug.

In summary, the emergence of data resource processors solves the problem of wanting the client to provide data. The data resource processor can automatically reflect the derived class of the data service controller `DataService` in the current assembly (or other specified assembly), and can automatically generate a routing table according to the routing characteristic `RouteAttribute` or the name of the controller. In the front-end environment, any data request technology (Fetch, XHR, etc.) can be used to obtain data, and data can also be submitted to the back-end data service controller (GET, POST, PUT, etc.).

## Installation

Before installing the program data resource processor, please ensure that the project has been correctly installed and referenced the NanUI base library and runtime dependencies. It is recommended to use the NuGet package manager to install the NuGet package of the assembly resource processor.

```
PM> Install NetDimension.NanUI.DataServiceResource
```

## DataServiceProvider Data Service Adapter

Each registered http protocol and domain name corresponds to a data service adapter. A data service adapter contains multiple data services, and each data service includes multiple data processing programs.

**Static method**

_DataServiceProvider_ **DataServiceProvider.GetDataServiceProvider(string domainName)**

Obtain the corresponding `DataServiceProvider` instance according to the specified `domainName`.

_bool_ **RemoveDataServiceProvider(string domainName)**

Remove the corresponding `DataServiceProvider` instance according to the specified `domainName`. Return true if successful, otherwise false.

**Instance Method**

**ImportDataServiceAssembly(string fileName)**

Import and register the data service from the assembly file located in `fileName`.

**ImportDataServiceAssembly(Assembly assembly)**

Import and register data service from assembly `assembly`.

**ImportDataServiceAssemblies(string[] files)**

Import and register data services from the file list `files[]`.

**ImportDataServiceAssemblies(string directoryName)**

Import all assemblies from the specified folder `directoryName`, load these files and import and register the data service.

**AddDataSevice(DataService service)**

Directly add the instance `serivce` of `DataService` to the current data service adapter.

Use the static method of `DataServiceProvider` to get or remove the registered data service adapter at runtime, and use the instance of the data service adapter `DataServiceProvider` to dynamically add data services. Using the above method flexibly, the data service `DataService` can be registered in the data service adapter `DataServiceProvider`.

## DataService Data Service

The data service `DataService` is an important component of the data resource processor. It is mainly responsible for providing routing data and obtaining front-end request information according to the routing information. If you have development experience using ASP.Net Mvc, then it is not difficult to understand the working principle of the data service `DataService`.

With the following example, you can get a rough idea of ​​how data services work.

**HelloService**

This example will return the string `Hello NanUI!` whose ContentType is `text/plain` when the front end requests `http://api.app.local/hello/hi`.

```C#
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.ResourceHandler;

// All: /Hello/Hi
public class HelloService: DataService
{
    public ResourceResponse Hi(ResourceRequest request)
    {
        return Text("Hello NanUI!");
    }
}
```

In particular, it should be pointed out that the derived class of data service `DataService` agrees that the class name must also end with `Service`, such as `HelloService` in the example.

Without specifying routing characteristics, the data service adapter generates a route based on the name of the data service. For example, the above example will automatically generate the route `Hello/Hi`.

In addition, if the data processing program does not specify the Http method, any submitted request will hit the route regardless of the HttpMethod method.

**PassportService**

This example simulates a user login request. The front end submits the login information through the POST method, and uses the JSON deserialization method `DeserializeObjectFromJson` of the `ResourceRequest` object to deserialize the submitted data to the `UserInfo` type, and then simulates a delay of 2000 After milliseconds, the result of successful login is returned.

```C#
using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.ResourceHandler;

[DataRoute("/account")]
public class PassportService: DataService
{
  // User login model
  public class UserInfo
  {
    public string Passport {get; set;}
    public string Password {get; set;}
  }

  // Get the current timestamp
  private string GetTimeStamp()
  {
    TimeSpan ts = DateTime.Now-new DateTime(1970, 1, 1, 0, 0, 0, 0);
    return Convert.ToInt64(ts.TotalSeconds).ToString();
  }

  [RoutePost("user/login")]
  public ResourceResponse Login(ResourceRequest request)
  {
    // Deserialize JSON data
    var result = request.DeserializeObjectFromJson<UserInfo>();

    // Simulate delayed operation
    Task.Delay(2000).GetAwaiter().GetResult();

    // return login success
    return Json(new {success = true, timestamp = GetTimeStamp(), result });
  }
}
```

The `PassportService` in the example specifies the `DataRoute` property, and the data handler `Login` method also specifies the `RoutePost` property and specifies the routing address data. If the routing characteristics are ignored. The route of the data service and data processing program should be `passport/login`. By adding the routing feature, the route of this method becomes `account/user/login`.

At the same time, because the data processing program `Login` specifies the `RoutePost` feature, it means that this method only accepts POST requests, and other requests will be ignored. You can superimpose multiple characteristics to specify multiple Http methods. For example, you can specify the `RouteGet` and `RoutePost` characteristics at the same time, and specify different routing addresses for the two characteristics.

```C#
[RoutePost("user/login")]
[RouteGet("user/logout")]
public ResourceResponse Test(ResourceRequest reqeust)
{
  //...
  return ...
}
```

## Use resource processor

The assembly resource processor needs to be registered in the WinFormium startup processing method. Use the `UseEmbeddedFileResource`method in the`application configuration agent` method to register the assembly resource handler scheme.

### Register the data service in the current assembly

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseDataServiceResource("http", "api.app.local");
  // ...
})
.Build()
.Run();
```

When the third proxy parameter is omitted, NanUI will look for data services in the current assembly and automatically register the data services found.

### Manually register data service

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

The proxy parameter `provider` of the third parameter is an instance of the type `DataServiceProvider`. `DataServiceProvider` provides a static method to obtain the corresponding `DataServiceProvider` instance according to the registered `domainName` parameter, and can dynamically add or remove data services at runtime.
