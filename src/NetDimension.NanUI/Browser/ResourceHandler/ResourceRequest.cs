using System.Collections.Specialized;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.ResourceHandler;

public enum Method
{
    /// <summary>
    /// The none.
    /// </summary>
    None,

    /// <summary>
    /// The get.
    /// </summary>
    GET,

    /// <summary>
    /// The post.
    /// </summary>
    POST,

    /// <summary>
    /// The put.
    /// </summary>
    PUT,

    /// <summary>
    /// The delete.
    /// </summary>
    DELETE,

    /// <summary>
    /// The head.
    /// </summary>
    HEAD,

    /// <summary>
    /// The options.
    /// </summary>
    OPTIONS,

    /// <summary>
    /// The patch.
    /// </summary>
    PATCH,

    /// <summary>
    /// The merge.
    /// </summary>
    MERGE
}

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

    public NameValueCollection Headers { get; }

    public string[] UploadFiles { get; }

    public byte[] RawData { get; }

    private const string CONTENT_TYPE_FORM_URL_ENCODED = "application/x-www-form-urlencoded";
    private const string CONTENT_TYPE_APPLICATION_JSON = "application/json";
    private readonly string _method;

    public CefRequest RawRequest { get; }


    public NameValueCollection QueryString { get; } = null;
    public NameValueCollection FormData { get; } = null;
    public string JsonData { get; } = null;

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


    public T DeserializeObjectFromJson<T>()
    {
        if (IsJson)
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

    public Method Method
    {
        get
        {
            if (Enum.TryParse(_method, out Method value))
            {
                return value;
            }

            return Method.None;
        }
    }

    public string ContentType => Headers?.Get("Content-Type");

    internal ResourceRequest(Uri uri, string method, NameValueCollection headers, byte[] postData, string[] uploadFiles, CefRequest cefRequest)
    {
        Uri = uri;
        _method = method;
        Headers = headers;
        RawData = postData;
        UploadFiles = uploadFiles;
        RawRequest = cefRequest;
        QueryString = ResourceRequest.ProcessQueryString(uri.Query);

        if (ContentType != null && ContentType.Contains(CONTENT_TYPE_FORM_URL_ENCODED) && RawData != null)
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



    private NameValueCollection ProcessFormData(byte[] rawData)
    {

        var query = ContentEncoding.GetString(rawData);

        var retval = new NameValueCollection();


        query = query.Trim('?');

        foreach (var pair in query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var keyvalue = pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (keyvalue.Length == 2)
            {
                retval.Add(keyvalue[0], Uri.UnescapeDataString(keyvalue[1]));
            }
            else if (keyvalue.Length == 1)
            {
                retval.Add(keyvalue[0], null);
            }
        }

        return retval;


    }

    private static NameValueCollection ProcessQueryString(string query)
    {
        var retval = new NameValueCollection();

        query = query.Trim('?');
        foreach (var pair in query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var keyvalue = pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (keyvalue.Length == 2)
            {
                retval.Add(keyvalue[0], Uri.UnescapeDataString(keyvalue[1]));
            }
            else if (keyvalue.Length == 1)
            {
                retval.Add(keyvalue[0], null);
            }
        }

        return retval;
    }

}
