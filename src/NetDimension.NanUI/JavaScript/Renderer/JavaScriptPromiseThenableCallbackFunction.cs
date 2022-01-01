using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class JavaScriptPromiseThenableCallbackFunction : CefV8Handler
{
    public JavaScriptPromiseThenableCallbackFunction(Guid uuid, CefV8Context context)
    {
        Context = context;
        Uuid = uuid;
    }

    public Guid Uuid { get; }
    public CefV8Context Context { get; }

    protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
    {
        if (name != "promise")
        {
            returnValue = null;
            exception = null;
            return false;
        }

        if (arguments.Length == 2 && arguments[0].IsFunction && arguments[1].IsFunction)
        {
            var resovle = arguments[0];
            var reject = arguments[1];
            var promiseFunction = new JavaScriptRenderSidePromiseContext(Uuid, Context, resovle, reject);

            JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Add(promiseFunction);

            exception = null;
            returnValue = CefV8Value.CreateUndefined();
        }
        else
        {
            returnValue = null;
            exception = $"[NanUI] This is not a promise function.";
        }

        return true;
    }
}
