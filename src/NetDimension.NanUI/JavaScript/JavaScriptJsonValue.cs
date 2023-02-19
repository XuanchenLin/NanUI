
namespace NetDimension.NanUI.JavaScript;

using System.Text.Json;

public static class JavaScriptJsonValueExtension
{
    public static JavaScriptJsonValue ToJsonVaue(this JavaScriptValue jsValue)
    {
        if (jsValue != null && jsValue.IsJSON && jsValue is JavaScriptJsonValue)
        {

            return (JavaScriptJsonValue)jsValue;

        }
        else if (jsValue != null && jsValue.IsString)
        {
            var j = jsValue.GetString();
            try
            {
                //var x = JToken.Parse(j);
                return new JavaScriptJsonValue(j);
            }
            catch
            {
                throw new InvalidOperationException($"This is not a {nameof(JavaScriptJsonValue)}.");
            }
        }
        else
        {
            throw new InvalidOperationException($"This is not a {nameof(JavaScriptJsonValue)}.");

        }
    }
}

public sealed class JavaScriptJsonValue : JavaScriptValue
{
    public JavaScriptJsonValue(string source)
: base(source, JavaScriptValueType.JSON)
    {
    }
    public JavaScriptJsonValue(object source)
: base(JsonSerializer.Serialize(source), JavaScriptValueType.JSON)
    {
    }

    public T ConvertToObject<T>()
    {
        return JsonSerializer.Deserialize<T>((string)RawValue);
    }
}
