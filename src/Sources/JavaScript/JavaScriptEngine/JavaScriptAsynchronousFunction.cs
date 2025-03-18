// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.JavaScript;

public class JavaScriptAsynchronousFunction : JavaScriptValue
{
    internal Action<JavaScriptArray, JavaScriptPromise> FunctionDelegate { get; }

    internal JavaScriptAsynchronousFunction(CefFrame frame, Action<JavaScriptArray, JavaScriptPromise> action)
    : base(JavaScriptValueType.Function)
    {
        Frame = frame;
        FunctionDelegate = action;
    }

    public JavaScriptAsynchronousFunction(Action<JavaScriptArray, JavaScriptPromise> action)
: base(JavaScriptValueType.Function)
    {
        FunctionDelegate = action;
    }

    internal override JavaScriptValueDefinition ToDefinition()
    {
        return new JavaScriptValueDefinition
        {
            Name = Name,
            Uuid = Uuid,
            ValueType = ValueType,
            ValueDefinition = new JavaScriptFunctionInvokerDefinition
            {
                IsAsynchronous = true,
                Side = ProcessType.Main
            },
        };
    }
}
