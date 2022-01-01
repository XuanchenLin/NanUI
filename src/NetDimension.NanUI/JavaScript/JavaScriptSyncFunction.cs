using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public sealed class JavaScriptSyncFunction : JavaScriptValue
{

    internal static HashSet<JavaScriptSyncFunction> Bag { get; } = new HashSet<JavaScriptSyncFunction>();


    internal Func<JavaScriptArray, JavaScriptValue> FunctionDelegate { get; }

    //public static JavaScriptFunction Create(Func<JavaScriptArray, JavaScriptValue> func)
    //{
    //    return new JavaScriptFunction(func);
    //}

    internal JavaScriptSyncFunction(CefFrame frame, Func<JavaScriptArray, JavaScriptValue> func)
        : base(JavaScriptValueType.Function)
    {
        Frame = frame;
        FunctionDelegate = func;

        Bag.Add(this);
    }

    public JavaScriptSyncFunction(Func<JavaScriptArray, JavaScriptValue> func)
: base(JavaScriptValueType.Function)
    {
        FunctionDelegate = func;

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
            IsAsyncFunction = false,
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
