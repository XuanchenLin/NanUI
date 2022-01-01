using NetDimension.NanUI.Browser.ResourceHandler;

namespace NetDimension.NanUI.Resource.Data;

public abstract class DataService
{
    protected static ResourceResponse Json(object data, Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = null)
    {
        var response = new ResourceResponse();

        response.JsonContent(data, jsonSerializerSettings);

        return response;
    }

    protected static ResourceResponse Text(string text)
    {
        var response = new ResourceResponse();

        response.Content(text);

        return response;
    }

    protected static ResourceResponse Content(string content, string contentType)
    {
        var response = new ResourceResponse();

        response.Content(Encoding.UTF8.GetBytes(content), contentType);

        return response;

    }

    protected static ResourceResponse Content(string content, string contentType, Encoding encoding)
    {
        var response = new ResourceResponse();

        response.Content(encoding.GetBytes(content), contentType);

        return response;

    }

    protected static ResourceResponse Content(byte[] buffer, string contentType = null)
    {
        var response = new ResourceResponse();

        response.Content(buffer, contentType);

        return response;
    }

    protected static ResourceResponse StatusCode(System.Net.HttpStatusCode status)
    {
        var response = new ResourceResponse
        {
            HttpStatus = status
        };
        return response;

    }

    protected static ResourceResponse StatusCode(int code)
    {
        return StatusCode((System.Net.HttpStatusCode)code);
    }
}
