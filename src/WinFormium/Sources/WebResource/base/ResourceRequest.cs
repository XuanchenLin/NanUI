// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Collections.Specialized;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace WinFormium.WebResource;

public sealed class ResourceRequest
{
    public Uri Uri { get; }
    public string RequestUrl
    {
        get
        {
            var original = Uri.OriginalString;
            if (original.Contains('?'))
            {
                return original.Substring(0, original.IndexOf("?"));
            }

            return original;
        }
    }

    public NameValueCollection? Headers { get; }

    public string[] UploadFiles { get; }

    public byte[]? RawData { get; }

    private const string CONTENT_TYPE_FORM_URL_ENCODED = "application/x-www-form-urlencoded";
    private const string CONTENT_TYPE_APPLICATION_JSON = "application/json";
    private const string CONTENT_TYPE_MULTIPART_FORM_DATA = "multipart/form-data";
    private readonly string _method;

    public CefRequest RawRequest { get; }
    public string RelativePath => $"{Uri?.LocalPath ?? string.Empty}".TrimStart('/');
    public string FileName => Path.GetFileName(RelativePath);
    public string FileExtension => Path.GetExtension(FileName).TrimStart('.');
    public bool HasFileName => !string.IsNullOrEmpty(FileName);


    public NameValueCollection? QueryString { get; } = null;
    public NameValueCollection? FormData { get; } = null;
    public string? JsonData { get; } = null;

    public bool IsJson
    {
        get
        {
            if (string.IsNullOrEmpty(ContentType))
            {
                return false;
            }

            return ContentType.Contains(CONTENT_TYPE_APPLICATION_JSON);
        }
    }

    public Encoding ContentEncoding
    {
        get
        {
            var encoding = ContentType;

            if (string.IsNullOrEmpty(encoding) || !encoding.Contains("charset="))
            {
                encoding = "utf-8";
            }
            else
            {
                // match "charset=xxx"
                var match = Regex.Match(encoding, @"(?<=charset=)(([^;,\r\n]))*");

                if (match.Success)
                {
                    encoding = match.Value;
                }
            }

            return Encoding.GetEncoding(encoding);
        }
    }

    public string StringContent
    {
        get
        {
            if (RawData == null)
            {
                return string.Empty;
            }

            return ContentEncoding.GetString(RawData);
        }
    }

    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

    };


    public T? DeserializeObjectFromJson<T>()
    {
        if (IsJson && RawData != null)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(RawData), _jsonSerializerOptions);

            }
            catch
            {
                return default;
            }
        }

        return default;
    }

    public ResourceRequestMethod Method
    {
        get
        {
            if (Enum.TryParse(_method, out ResourceRequestMethod value))
            {
                return value;
            }

            return ResourceRequestMethod.All;
        }
    }

    public string ContentType => Headers?.Get("Content-Type") ?? string.Empty;

    internal ResourceRequest(Uri uri, string method, NameValueCollection? headers, byte[] postData, string[] uploadFiles, CefRequest cefRequest)
    {
        Uri = uri;
        _method = method;
        Headers = headers;
        RawData = postData;
        UploadFiles = uploadFiles;
        RawRequest = cefRequest;
        QueryString = ProcessQueryString(uri.Query);

        if (ContentType != null && ContentType.Contains(CONTENT_TYPE_FORM_URL_ENCODED) && RawData != null)
        {
            FormData = ProcessFormUrlEncodedData(RawData);
        }
        else if (ContentType != null && ContentType.Contains(CONTENT_TYPE_MULTIPART_FORM_DATA) && RawData != null)
        {
            FormData = ProcessFormData(RawData);
        }
        else
        {
            FormData = new NameValueCollection();
        }

        if (IsJson && RawData != null)
        {
            try
            {
                JsonData = JsonSerializer.Serialize(Encoding.UTF8.GetString(RawData));
            }
            catch
            {
                JsonData = string.Empty;
            }
        }
    }

    private NameValueCollection ProcessFormData(byte[] bytes)
    {
        var formData = ContentEncoding.GetString(bytes);

        var fields = new NameValueCollection();

        var boundary = GetBoundary(formData);

        formData = formData.Replace($"{boundary}--", null);

        var boundaryParts = formData.Split(new[] { boundary }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in boundaryParts)
        {
            var lines = part.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            string? fieldName = null;
            string? fieldValue = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("Content-Disposition: form-data;"))
                {
                    var dispositionParts = line.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var partInfo in dispositionParts)
                    {
                        if (partInfo.StartsWith("name="))
                        {
                            fieldName = partInfo.Substring(5).Trim('"');
                        }
                    }
                }
                else if (line.StartsWith("Content-Type:"))
                {
                    // Handle file content type if needed
                }
                else
                {
                    fieldValue = line;
                }
            }

            if (!string.IsNullOrEmpty(fieldName))
            {
                fields.Add(fieldName, fieldValue);
            }
        }

        return fields;
    }

    private string GetBoundary(string formData)
    {

        var endIndex = formData.IndexOf("\r\n", StringComparison.OrdinalIgnoreCase);

        return formData[..endIndex];
    }


    private NameValueCollection ProcessFormUrlEncodedData(byte[] rawData)
    {

        var query = ContentEncoding.GetString(rawData);

        var retval = new NameValueCollection();


        query = query.Trim('?');

        foreach (var pair in query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var keyvalue = pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (keyvalue.Length == 2)
            {
                retval.Add(keyvalue[0].ToLower(), Uri.UnescapeDataString(keyvalue[1]));
            }
            else if (keyvalue.Length == 1)
            {
                retval.Add(keyvalue[0].ToLower(), null);
            }
        }

        return retval;


    }

    private NameValueCollection ProcessQueryString(string query)
    {
        var retval = new NameValueCollection();

        query = query.Trim('?');
        foreach (var pair in query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var keyvalue = pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (keyvalue.Length == 2)
            {
                retval.Add(keyvalue[0].ToLower(), Uri.UnescapeDataString(keyvalue[1]));
            }
            else if (keyvalue.Length == 1)
            {
                retval.Add(keyvalue[0].ToLower(), null);
            }
        }

        return retval;
    }

}
