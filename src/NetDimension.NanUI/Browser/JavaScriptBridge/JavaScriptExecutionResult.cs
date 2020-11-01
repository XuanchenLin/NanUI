namespace NetDimension.NanUI.JavaScript
{
    public sealed class JavaScriptExecutionResult
    {
        public bool Success { get; }
        public string ExceptionMessage { get; }
        public JavaScriptValue ResultValue { get; }

        internal JavaScriptExecutionResult(bool isSuccess, string definition, string exception)
        {
            Success = isSuccess;
            if (Success)
            {
                ResultValue = JavaScriptValue.FromJson(definition);
            }
            else
            {
                ExceptionMessage = exception;
            }
        }
    }

}
