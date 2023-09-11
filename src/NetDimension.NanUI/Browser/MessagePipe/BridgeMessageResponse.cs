namespace NetDimension.NanUI.Browser.MessagePipe;

public class BridgeMessageResponse
{
    public bool IsSuccess { get; set; } = true;
    public string Result { get; set; }
    public string Data { get; set; }
    public BridgeMessageResponse(bool isSuccess, string exception)
    {
        IsSuccess = isSuccess;
        Result = exception;
    }

    public BridgeMessageResponse()
    {
        IsSuccess = true;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    internal static BridgeMessageResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<BridgeMessageResponse>(json);
    }
}
