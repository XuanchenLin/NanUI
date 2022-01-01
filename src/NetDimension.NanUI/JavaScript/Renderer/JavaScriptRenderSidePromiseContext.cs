using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class JavaScriptRenderSidePromiseContext
{
    public JavaScriptRenderSidePromiseContext(Guid uuid, CefV8Context context, CefV8Value resovle, CefV8Value reject)
    {
        Uuid = uuid;
        V8Context = context;
        Resovle = resovle;
        Reject = reject;
    }

    public Guid Uuid { get; }
    public CefV8Context V8Context { get; }
    public CefV8Value Resovle { get; }
    public CefV8Value Reject { get; }
}
