// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.JavaScript;

internal class JavaScriptFunctionInvokerOnRemote : JavaScriptValue
{
    //public CefV8Context Context { get; }
    public CefV8Value FunctionBody { get; }

    internal JavaScriptFunctionInvokerOnRemote(/*CefV8Context context, */CefV8Value func)
    : base(JavaScriptValueType.Function)
    {
        //Context = context;
        FunctionBody = func;
    }

    internal override JavaScriptValueDefinition ToDefinition()
    {
        return new JavaScriptValueDefinition
        {
            Name = Name,
            Uuid = Uuid,
            ValueType = ValueType,
            ValueDefinition = new JavaScriptFunctionInvokerDefinition { IsAsynchronous = false, Side = ProcessType.Renderer }
        };
    }

    protected override void Dispose(bool isDisposing)
    {
        FunctionBody.Dispose();
    }
}
