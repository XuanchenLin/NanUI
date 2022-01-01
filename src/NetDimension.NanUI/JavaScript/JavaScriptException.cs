namespace NetDimension.NanUI.JavaScript;

public class JavaScriptException
{
    public int StartColumn { get; internal set; }
    public int StartPosition { get; internal set; }
    public int EndColumn { get; internal set; }
    public int EndPosition { get; internal set; }
    public int LineNumber { get; internal set; }
    public string ScriptResourceName { get; internal set; }
    public string SourceLine { get; internal set; }

}
