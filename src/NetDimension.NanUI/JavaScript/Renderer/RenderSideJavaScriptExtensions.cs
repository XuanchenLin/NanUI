using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;
internal static class RenderSideJavaScriptExtensions
{
    const string CREATE_PROMISE_FUNCTION_NAME = "__createFormiumPromiseFunction__";
    const string TARGET_OBJECT_NAME = "Formium";

    public static CefV8Value CreateJavaScriptPromiseContext(this CefV8Context context,Guid uuid)
    {
        var global = context.GetGlobal();

        var formium = global.GetValue(TARGET_OBJECT_NAME);

        var promiseCreateFunc = formium.GetValue(CREATE_PROMISE_FUNCTION_NAME);

        

        var promiseData = promiseCreateFunc.ExecuteFunctionWithContext(context, null, new CefV8Value[] { });

        var retval = promiseData?.GetValue("promise");

        if (retval != null)
        {
            var promiseFunction = new JavaScriptRenderSidePromiseContext(uuid, context, promiseData);

            JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Add(promiseFunction);

        }

        return retval;

    }
}
