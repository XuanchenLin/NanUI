namespace NetDimension.NanUI.Browser.MessagePipe;

public sealed class BridgeMessageRequest
{
    public string Name { get; set; }
    public int BrowserId { get; set; }
    public long FrameId { get; set; }
    public int ContextId { get; set; }
    public string Data { get; set; }
    public BridgeMessageRequest(string name, int browserId, long frameId, int contextId)
    {
        Name = name;
        BrowserId = browserId;
        FrameId = frameId;
        ContextId = contextId;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static BridgeMessageRequest Deserialize(string json)
    {
        return JsonSerializer.Deserialize<BridgeMessageRequest>(json);
    }
}
