namespace NetDimension.NanUI.JavaScript.JavaScriptEvaluation;

class JavaScriptEvaluationResultMessage
{
    public int TaskId { get; set; }
    public bool Success { get; set; }
    public string Data { get; set; }
    public string Message { get; set; }
    public JavaScriptException Exception { get; set; }
}
