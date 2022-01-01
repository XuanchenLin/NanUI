using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;


public sealed class JavaScriptAsyncFunction : JavaScriptValue
{

    internal static HashSet<JavaScriptAsyncFunction> Bag { get; } = new HashSet<JavaScriptAsyncFunction>();


    internal Action<JavaScriptArray, JavaScriptFunctionPromise> FunctionDelegate { get; }

    internal JavaScriptAsyncFunction(CefFrame frame, Action<JavaScriptArray, JavaScriptFunctionPromise> action)
        : base(JavaScriptValueType.Function)
    {
        Frame = frame;
        FunctionDelegate = action;
        Bag.Add(this);
    }

    public JavaScriptAsyncFunction(Action<JavaScriptArray, JavaScriptFunctionPromise> action)
: base(JavaScriptValueType.Function)
    {
        FunctionDelegate = action;

        Bag.Add(this);
    }

    internal override JSValueDefinition ToDefinition()
    {
        var def = new JSValueDefinition();

        def.ValueType = ValueType;

        def.Uuid = Uuid;

        def.Name = Name;

        def.ValueDefinition = new JSFunctionDefinition
        {
            IsAsyncFunction = true,
            Side = CefProcessType.Browser
        };

        return def;
    }

    internal static void ReleaseFunctions(CefFrame frame)
    {
        if (frame == null) return;

        Bag.RemoveWhere(x => x.Frame == null || x.Frame.Identifier == frame.Identifier && !x.IsFreeze);
    }

    internal static void ReleaseFunctions()
    {
        Bag.Clear();
    }
}
