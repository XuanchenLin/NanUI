# Resource processor

[[Home](README.md)]

NanUI encapsulates and simplifies the `CefResourceHandler` in the Chromium Embedded framework. You no longer need to implement the stream processing of `CefResourceHandler` and the cumbersome registration process of the `CefSchemeHandlerFactory` interface. NanUI encapsulates the entire process of CEF's original registration of resources into two abstract classes `ResourceSchemeConfiguration` and `ResourceHandlerBase`.

- **ResourceSchemeConfiguration**

  Resource plan configurator, used to save resource configuration and register the corresponding resource processor.

- **ResourceHandlerBase**

  Resource processor base class, used to process request data and return corresponding resources.

A very simple example is used to demonstrate the use of resource controllers. The function of this example is to return the URL address of the current request no matter what URL is requested.

## Create Resource Processor

**UrlEchoSchemeConfiguration**

`UrlEchoSchemeConfiguration` is used to register the resource processor and bind it to the domain name `scehcme:domainName`. In this way, if the front end sends a request to this address, it can correctly route the front end request to the `UrlEchoResourceHandler` for processing.

```C#
using Xilium.CefGlue;
using NetDimension.NanUI.ResourceHandler;


public class UrlEchoSchemeConfiguration: ResourceSchemeConfiguration
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

`UrlEchoResourceHandler` is used to process requests. The parameter `request` of the abstract method of `GetResourceResponse` contains the request sent by the front end. The request includes the necessary data of `HttpReqeust`, such as the collection of Http request headers `Headers`, query string `QueryString`, request method `HttpMethod`, etc. If the request uses the POST/PUT/PATCH method, the corresponding request data can also be obtained through `RawData` or `JsonData`.

```C#
using NetDimension.NanUI.ResourceHandler;

public class UrlEchoResourceHandler: ResourceHandlerBase
{
    public UrlEchoSchemeConfiguration Configuration {get;}

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

## Use resource processor

**Registered Resource Processor Program**

After customizing the processor, you need to register it in the `Application Configuration Agent` method in the WinFormium startup processing method.

```C#
WinFormium.CreateRuntimeBuilder(buildApplicationConfiguration: app => {
  // ...
  app.UseCustomResourceHandler(() => new UrlEchoSchemeConfiguration("http","echo.app.local"));
  // ...
})
.Build()
.Run();
```

**Test Resource Processor**

Create a Formium form for testing, set its `StartUrl` property to any address of `http://echo.app.local`, start the application, then the form passed in `StartUrl` will be printed Page address. For example: when StartUrl = "http://echo.app.local/hello/nanaui", the form page will display the string `http://echo.app.local/hello/nanaui`.

## ResourceRequest and ResourceResponse

The `ResourceRequest` object contains the related data of the request and the `ResourceResponse` contains the corresponding data returned to the front end. Similar to `HttpRequest` and `HttpResponse` in Asp.Net. If you know that Web back-end development is not unfamiliar, so I won't repeat it here. You can develop according to the actual needs according to the prompts of these two types during development.

### ResourceRequest Object

_Attributes_

**Uri Uri {get; }**

Send the requested Uri address information.

**string RequestUrl {get; }**

The URL address for sending the request, excluding the query string part.

**NameValueCollection Headers {get; }**

Headers information of Http request.

**string[] UploadFiles {get; }**

If the front end submits a file upload request, this attribute will contain the real physical path collection of the uploaded file. You can access files and perform operations through real physical paths (such as batch upload, FTP upload using .NET, etc.).

**byte[] RawData {get; }**

Get the original data of the request submitted by the front end.

**CefRequest RawRequest {get; }**

Get the `CefRequest` object of the current request.

**NameValueCollection QueryString {get; }**

Get the query string of the current request.

**NameValueCollection FormData {get; }**

Get the currently requested `FormData` data.

**JsonValue JsonData {get; }**

Get the currently requested `JSON` data.

**bool IsJson {get; }**

Determine whether the currently requested data is in JSON format.

**Encoding ContentEncoding {get; }**

Get the currently requested character set encoding.

**string StringContent {get; }**

Get the currently requested character data.

**Method Method {get; }**

Get the method of the current request.

**string ContentType {get; }**

Get the ContentType of the current request.

_method_

**T DeserializeObjectFromJson<T>();**

Deserialize the current JSON data to type T.

### ResourceResponse Object

_Attributes_

**string RelativePath {get; }**

Get the relative path according to the current ResourceRequest.

**string FileName {get; }**

Obtain the requested file name according to the current ResourceRequest.

**string FileExtension {get; }**

Obtain the requested file extension according to the current ResourceRequest.

**Stream ContentStream {get; set; }**

Set or get the data stream object returned to the front-end response.

**HttpStatusCode HttpStatus {get; set; }**

Set or get the HttpStatus result returned to the front-end response.

**long Length {get; }**

Get the length of the current data stream object.

**string MimeType {get; set; }**

Set or get the MimeType returned to the front-end response.

**bool HasFileName {get; }**

According to the current ResourceRequest, judge whether the currently requested URL has a file name.

**NameValueCollection Headers {get; }**

Get a collection of Http header information returned to the front-end response.

_method_

**void Content(byte[] buff, string contentType = null)**

Set `buff:byte[]` to the data stream object returned to the front-end response; and set `contentType`, use the default MimeType when this parameter is empty.

## Extension

Understand how the resource processor works, you can develop a resource controller that meets your needs according to the actual needs of the project. The NanUI project has built-in `assembly resource processor`, `local file resource processor`, `ZIP compressed package resource processor` and `data service resource processor` several processors, they are all based on `ResourceSchemeConfiguration` and `ResourceHandlerBase` was developed. If you are interested, you can learn more about the operation principle and implementation of NanUI resource processor by reading the source code of these resource processors.

How to use these resource processors will be introduced separately in the following chapters.

- [Resources embedded in assembly](resource-handler-embedded.md)
- [Local File Resource](resource-handler-local-file.md)
- [ZIP file resource](resource-handler-zip-package.md)
- [Use data service resources](resource-handler-data-services.md)
