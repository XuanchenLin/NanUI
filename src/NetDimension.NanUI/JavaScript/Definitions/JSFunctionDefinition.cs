namespace NetDimension.NanUI.JavaScript;

internal class JSFunctionDefinition
{
    public bool IsAsyncFunction { get; set; }
    public CefProcessType Side { get; set; }

    public static JSFunctionDefinition FromJson(string json)
    {
        return JsonSerializer.Deserialize<JSFunctionDefinition>(json);
    }
}
