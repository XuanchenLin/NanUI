using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class JavaScriptRenderSidePromiseContext
{
    public JavaScriptRenderSidePromiseContext(Guid uuid, CefV8Context context, CefV8Value promiseData  /*CefV8Value resovle, CefV8Value reject*/)
    {
        Uuid = uuid;
        V8Context = context;
        PromiseData = promiseData;
        //Resovle = resovle;
        //Reject = reject;
    }

    public Guid Uuid { get; }
    public CefV8Context V8Context { get; }
    public CefV8Value PromiseData { get; }
    public CefV8Value Resolve => PromiseData?.GetValue("resolve");
    public CefV8Value Reject => PromiseData?.GetValue("reject");
}
