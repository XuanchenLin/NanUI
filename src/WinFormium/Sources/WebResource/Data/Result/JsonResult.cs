// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public class JsonResult : ResourceResult
{
    private const string CONTENT_TYPE_JSON = "application/json";

    public JsonResult(object? data, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        Data = data;
        JsonSerializerOptions = jsonSerializerOptions;
    }

    public object? Data { get; }

    public string? ContentType { get; set; } = CONTENT_TYPE_JSON;

    public int? StatusCode { get; set; }

    public JsonSerializerOptions? JsonSerializerOptions { get; }

    public override void ExecuteResult(DataResourceContext context)
    {
        context.Response.ContentType = ContentType ?? CONTENT_TYPE_JSON;
        context.Response.HttpStatus = StatusCode ?? StatusCodes.Status200OK;

        if (Data != null)
        {
            var json = JsonSerializer.Serialize(Data, JsonSerializerOptions ?? context.Route.DefaultJsonSerializerOptions);
            var bytes = Encoding.UTF8.GetBytes(json);

            context.Response.Content(bytes, context.Response.ContentType);
        }
    }

}
