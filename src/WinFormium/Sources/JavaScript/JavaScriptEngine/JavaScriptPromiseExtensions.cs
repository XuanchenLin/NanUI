// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public static class JavaScriptPromiseExtensions
{
    public static CefV8Value CreateJavaScriptPromiseContext(this CefV8Context context, Guid uuid)
    {
        var promiseCreationCode = """"
(()=>{
    const result = {};
    const promise = new Promise((resolve,reject)=>{
        result.resolve = resolve;
        result.reject = reject;
    });
    result.promise = promise;
    return result;
})();
"""";

        if (!context.TryEval(promiseCreationCode, context.GetFrame().Url, 0, out var returnValue, out _) || returnValue == null)
        {
            throw new ArgumentException("Cannot create JavaScript promise object.");
        }

        var promise = returnValue?.GetValue("promise");

        if(returnValue == null ||promise == null)
        {
            throw new ArgumentException("Cannot create JavaScript promise object.");
        }

        var promiseFunction = new JavaScriptPromiseContext(uuid, context, returnValue);

        JavaScriptEngineBridge.JavaScriptPromiseContexts.Add(promiseFunction);

        return promise;
    }
}