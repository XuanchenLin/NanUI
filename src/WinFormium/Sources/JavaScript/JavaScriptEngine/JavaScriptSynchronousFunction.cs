// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public class JavaScriptSynchronousFunction : JavaScriptValue
{
    internal Func<JavaScriptArray, JavaScriptValue?> FunctionDelegate { get; }

    internal JavaScriptSynchronousFunction(CefFrame frame, Func<JavaScriptArray, JavaScriptValue?> func)
    : base(JavaScriptValueType.Function)
    {
        Frame = frame;
        FunctionDelegate = func;
    }

    public JavaScriptSynchronousFunction(Func<JavaScriptArray, JavaScriptValue?> func)
: base(JavaScriptValueType.Function)
    {
        FunctionDelegate = func;
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
                IsAsynchronous = false,
                Side = ProcessType.Main
            },
        };
    }

}
