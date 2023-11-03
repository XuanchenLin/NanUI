// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;

public class ContentResult : ResourceResult
{
    private const string CONTENT_TYPE_TEXT = "text/plain";

    public ContentResult(string? text = null, Encoding? encoding = null)
    {
        Content = text;
        Encoding = encoding;
    }

    public string? Content { get; set; }
    public string? ContentType { get; set; } = CONTENT_TYPE_TEXT;
    public int? StatusCode { get; set; }
    public Encoding? Encoding { get; set; }

    public override void ExecuteResult(DataResourceContext context)
    {
        context.Response.ContentType = ContentType ?? CONTENT_TYPE_TEXT;
        context.Response.HttpStatus = StatusCode ?? StatusCodes.Status200OK;

        var bytes = Encoding.UTF8.GetBytes(Content ?? string.Empty);

        context.Response.Content(bytes, context.Response.ContentType);
    }

}


