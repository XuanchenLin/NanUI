namespace NetDimension.NanUI.Browser.MessagePipe;

public sealed class MessageRequest
{
    public string Name { get; set; }
    public int BrowserId { get; set; }
    public long FrameId { get; set; }
    public int ContextId { get; set; }
    public string Data { get; set; }
    public MessageRequest(string name, int browserId, long frameId, int contextId)
    {
        Name = name;
        BrowserId = browserId;
        FrameId = frameId;
        ContextId = contextId;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static MessageRequest Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<MessageRequest>(json);
    }
}
