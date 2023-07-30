using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class JavaScriptRenderSideFunction : JavaScriptValue, IDisposable
{

    public static JavaScriptRenderSideFunction Create(CefV8Context v8Context, CefV8Value func)
    {
        return new JavaScriptRenderSideFunction(v8Context, func);
    }

    internal JavaScriptRenderSideFunction(CefV8Context v8Context, CefV8Value func)
        : base(JavaScriptValueType.Function)
    {
        V8Context = v8Context;
        FunctionDelegate = func;
    }

    internal CefV8Context V8Context { get; }
    internal CefV8Value FunctionDelegate { get; }

    internal override JSValueDefinition ToDefinition()
    {
        var def = new JSValueDefinition();

        def.ValueType = ValueType;

        def.Uuid = Uuid;

        def.Name = Name;

        def.ValueDefinition = new JSFunctionDefinition
        {
            IsAsyncFunction = false,
            Side = CefProcessType.Renderer
        };

        return def;
    }

    public void Dispose()
    {
        FunctionDelegate?.Dispose();
    }
}
