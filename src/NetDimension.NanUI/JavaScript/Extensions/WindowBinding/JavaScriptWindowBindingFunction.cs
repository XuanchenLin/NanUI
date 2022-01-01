namespace NetDimension.NanUI.JavaScript.WindowBinding;

enum JavaScriptWindowBindingFunctionType
{
    SyncFunctionOnBrowserSide,
    SyncFunctionOnRenderSide,
    AsyncFucntionOnBrowserSide,
    AsyncFunctionOnRenderSide
}

class JavaScriptWindowBindingFunction
{
    public Guid Uuid { get; } = Guid.NewGuid();

    public JavaScriptWindowBindingFunctionType FunctionType { get; }

    public string FunctionName { get; }

    public Func<Formium, JavaScriptArray, JavaScriptValue> BrowserSideSyncFuncion { get; }
    public Action<Formium, JavaScriptArray, JavaScriptFunctionPromise> BrowserSideAsyncFunction { get; }
    public Func<JavaScriptArray, JavaScriptValue> RenderSideSyncFunction { get; }
    public Action<JavaScriptArray, JavaScriptFunctionPromise> RenderSideAsyncFunction { get; }


    public JavaScriptWindowBindingFunction(string functionName, Func<Formium, JavaScriptArray, JavaScriptValue> function)
    {
        FunctionName = functionName;
        FunctionType = JavaScriptWindowBindingFunctionType.SyncFunctionOnBrowserSide;
        BrowserSideSyncFuncion = function;
    }

    public JavaScriptWindowBindingFunction(string functionName, Action<Formium, JavaScriptArray, JavaScriptFunctionPromise> function)
    {
        FunctionName = functionName;
        FunctionType = JavaScriptWindowBindingFunctionType.AsyncFucntionOnBrowserSide;
        BrowserSideAsyncFunction = function;
    }

    public JavaScriptWindowBindingFunction(string functionName, Func<JavaScriptArray, JavaScriptValue> function)
    {
        FunctionName = functionName;
        FunctionType = JavaScriptWindowBindingFunctionType.SyncFunctionOnRenderSide;
        RenderSideSyncFunction = function;
    }

    public JavaScriptWindowBindingFunction(string functionName, Action<JavaScriptArray, JavaScriptFunctionPromise> function)
    {
        FunctionName = functionName;
        FunctionType = JavaScriptWindowBindingFunctionType.AsyncFunctionOnRenderSide;
        RenderSideAsyncFunction = function;
    }

}
