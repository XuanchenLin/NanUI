namespace NetDimension.NanUI.Browser.MessagePipe;

public class BridgeMessage
{
    public string Name { get; internal set; }
    public string Data { get; set; }

    public BridgeMessage(string name, string data = null)
    {
        Name = name;
        Data = data;
    }
}
