namespace NetDimension.NanUI.JavaScript
{
    internal class JavaScriptFunctionInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsAsync { get; set; }
        public CefProcessType Side { get; set; }
    }


}
