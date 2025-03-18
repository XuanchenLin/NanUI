// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Diagnostics.CodeAnalysis;

namespace NetDimension.NanUI.JavaScript;

internal class JavaScriptPromiseContext : IDisposable
{
    public required Guid Uuid { get; init; }
    public CefV8Context Context { get; }
    public CefV8Value Resolve { get; }
    public CefV8Value Reject { get; }

    [SetsRequiredMembers]
    public JavaScriptPromiseContext(Guid uuid, CefV8Context context, CefV8Value promiseFunction)
    {
        Uuid = uuid;
        Context = context;
        Resolve = promiseFunction.GetValue("resolve");
        Reject = promiseFunction.GetValue("reject");
    }

    public void Dispose()
    {
        Resolve?.Dispose();
        Reject?.Dispose();
    }
}