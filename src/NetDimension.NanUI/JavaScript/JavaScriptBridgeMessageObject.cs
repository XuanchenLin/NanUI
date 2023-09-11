namespace NetDimension.NanUI.JavaScript;

internal class JavaScriptBridgeMessageObject
{
    public int TaskId { get; set; }
    public Guid FuncId { get; set; }
    public long FrameId { get; set; }
    public bool Success { get; set; }
    public string Data { get; set; }
    public string ExceptionText { get; set; }
}
