// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public abstract class DataResourceService
{
    private const string CONTENT_TYPE_TEXT_PLAIN = "text/plain";

    public required DataResourceContext Context { get; set; }

    public ResourceRequest Request => Context.Request;
    public ResourceResponse Response => Context.Response;

    [NoAction]
    protected virtual ContentResult Content(string content, string contentType, Encoding encoding)
    {
        return new ContentResult
        {
            Content = encoding.GetString(encoding.GetBytes(content)),
            ContentType = contentType,
            Encoding = encoding
        };
    }

    [NoAction]
    protected virtual ContentResult Content(string content, string contentType)
    {
        return Content(content, contentType, Encoding.UTF8);
    }

    [NoAction]
    protected virtual ContentResult Text(string text)
    {
        return Content(text, CONTENT_TYPE_TEXT_PLAIN);
    }

    [NoAction]
    protected virtual JsonResult Json(object data, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        return new JsonResult(data, jsonSerializerOptions);
    }

    [NoAction]
    protected virtual JsonResult Json<T>(T data, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        return new JsonResult(data, jsonSerializerOptions);
    }

    [NoAction]
    protected virtual StatusCodeResult StatusCode(System.Net.HttpStatusCode status)
    {
        return StatusCode((int)status);
    }

    [NoAction]
    protected virtual StatusCodeResult StatusCode(int code)
    {
        return new StatusCodeResult(code);
    }

    [NoAction]
    protected BadRequestResult BadRequest()
    {
        return new BadRequestResult();
    }

    [NoAction]
    protected NoContentResult NoContent()
    {
        return new NoContentResult();
    }

    [NoAction]
    protected NotFoundResult NotFound()
    {
        return new NotFoundResult();
    }

    [NoAction]
    protected OkResult Ok()
    {
        return new OkResult();
    }


}
