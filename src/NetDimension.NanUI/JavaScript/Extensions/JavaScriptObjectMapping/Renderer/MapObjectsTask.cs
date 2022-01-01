using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptObjectMapping;

class MapObjectsTask : CefTask
{
    const string FORMIUM_OBJECT_NAME = "Formium";
    const string EXTERNAL_OBJECT_NAME = "external";
    public JavaScriptObject Objects { get; }
    public CefFrame Frame { get; }
    public MapObjectsTask(CefFrame frame, string args)
    {
        Frame = frame;
        Objects = JavaScriptValue.FromJson(args).ToObject();
    }


    protected override void Execute()
    {
        var context = Frame.V8Context;


        context.Enter();

        try
        {
            var global = context.GetGlobal();

            if (!global.HasValue(FORMIUM_OBJECT_NAME))
            {
                global.SetValue(FORMIUM_OBJECT_NAME, CefV8Value.CreateObject(), CefV8PropertyAttribute.DontDelete);
            }

            var formiumRoot = global.GetValue(FORMIUM_OBJECT_NAME);

            if (formiumRoot.HasValue(EXTERNAL_OBJECT_NAME))
            {
                formiumRoot.DeleteValue(EXTERNAL_OBJECT_NAME);
            }

            var externalObject = CefV8Value.CreateObject();

            formiumRoot.SetValue(EXTERNAL_OBJECT_NAME, externalObject, CefV8PropertyAttribute.DontDelete);

            foreach (var key in Objects.PropertyNames)
            {
                var source = Objects.GetValue(key);
                externalObject.SetValue(key, source.ToCefV8Value());
            }
        }
        finally
        {
            context.Exit();
        }
    }
}
