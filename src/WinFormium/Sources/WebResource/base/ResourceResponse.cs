// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Collections.Specialized;

namespace WinFormium.WebResource;
public sealed class ResourceResponse : IDisposable
{
    public Stream? ContentBody { get; set; }
    public int HttpStatus { get; set; } = StatusCodes.Status200OK;
    public long Length => ContentBody?.Length ?? 0;
    public string? ContentType { get; set; } = "text/plain";
    public NameValueCollection Headers { get; } = new NameValueCollection();



    public ResourceResponse(byte[]? buff =null, string? contentType = null)
    {
        if (!string.IsNullOrEmpty(contentType))
        {
            ContentType = contentType;
        }

        //Headers.Set("Content-Type", ContentType);

        if (buff != null)
        {
            ContentBody = new MemoryStream(buff);
        }

        HttpStatus = StatusCodes.Status200OK;
    }

    public void Dispose()
    {
        ContentBody?.Close();
        ContentBody?.Dispose();
        ContentBody = null;

        GC.SuppressFinalize(this);
    }

    internal void Content(byte[] buff, string? contentType = null)
    {
        if (!string.IsNullOrEmpty(contentType))
        {
            ContentType = contentType;
        }

        Headers.Set("Content-Type", ContentType);

        if (ContentBody != null)
        {
            ContentBody.Dispose();
            ContentBody = null;
        }

        ContentBody = new MemoryStream(buff);

        HttpStatus = StatusCodes.Status200OK;
    }

    internal void JsonContent(object data, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data, jsonSerializerOptions));

        Content(bytes, "application/json");
    }


    internal void JsonContent<T>(T data, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data, jsonSerializerOptions));


        Content(bytes, "application/json");
    }


    internal void TextContent(string text)
    {
        TextContent( text, Encoding.UTF8);
    }


    internal void TextContent(string text, Encoding encoding)
    {
        Content( text, "text/plain", encoding);
    }


    internal void Content(string content)
    {
        Content(Encoding.UTF8.GetBytes(content), "text/plain");
    }

    internal void Content(string content, string contentType)
    {
        Content(Encoding.UTF8.GetBytes(content), contentType);
    }

    internal void Content(string content, string contentType, Encoding encoding)
    {
        Content(encoding.GetBytes(content), contentType);
    }


}
