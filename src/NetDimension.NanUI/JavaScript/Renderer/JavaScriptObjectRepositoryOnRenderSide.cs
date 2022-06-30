using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal static class JavaScriptObjectRepositoryOnRenderSide
{
    public static List<JavaScriptRenderSideFunction> StoredFunctions { get; } = new List<JavaScriptRenderSideFunction>();

    public static List<JavaScriptRenderSidePromiseContext> StoredPromises { get; } = new List<JavaScriptRenderSidePromiseContext>();

    public static void ReleaseStoreByContext(CefV8Context context)
    {
        var storedFunctions = StoredFunctions.Where(x => x.V8Context.IsSame(context)).ToArray();

        for (var i = 0; i < storedFunctions.Length; i++)
        {
            var func = storedFunctions[i];
            func?.FunctionDelegate?.Dispose();
            StoredFunctions.Remove(func);
        }


        var storedPromises = StoredPromises.Where(x => x.V8Context.IsSame(context)).ToArray();

        for (var i = 0; i < storedPromises.Length; i++)
        {
            var func = storedPromises[i];
            //func?.Resolve?.Dispose();
            //func?.Reject?.Dispose();
            func?.PromiseData?.Dispose();
            StoredPromises.Remove(func);
        }
    }
}
