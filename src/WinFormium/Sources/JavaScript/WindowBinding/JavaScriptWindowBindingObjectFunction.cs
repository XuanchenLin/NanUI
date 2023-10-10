// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal sealed class JavaScriptWindowBindingObjectFunction
{
    public Guid Uuid { get; } = Guid.NewGuid();

    public JavaScriptWindowBindingObjectFunctionType FunctionType { get; init; }

    public required string FunctionName { get; init; }

    public Func<Formium, JavaScriptArray, JavaScriptValue?>? SynchronousFunctionOnLocal { get; }
    public Action<Formium, JavaScriptArray, JavaScriptPromise>? AsynchronousFunctionOnLocal { get; }
    public Func<JavaScriptArray, JavaScriptValue?>? SynchronousFunctionOnRemote { get; }
    public Action<JavaScriptArray, JavaScriptPromise>? AsynchronousFunctionOnRemote { get; }

    public JavaScriptWindowBindingObjectFunction(Func<Formium, JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        FunctionType = JavaScriptWindowBindingObjectFunctionType.SynchronousFunctionOnLocal;
        SynchronousFunctionOnLocal = functionDelegate;
    }

    public JavaScriptWindowBindingObjectFunction(Action<Formium, JavaScriptArray, JavaScriptPromise> functionDelegate)
    {
        FunctionType = JavaScriptWindowBindingObjectFunctionType.AsynchronousFunctionOnLocal;
        AsynchronousFunctionOnLocal = functionDelegate;
    }

    public JavaScriptWindowBindingObjectFunction(Func<JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        FunctionType = JavaScriptWindowBindingObjectFunctionType.SynchronousFunctionOnRemote;
        SynchronousFunctionOnRemote = functionDelegate;
    }

    public JavaScriptWindowBindingObjectFunction(Action<JavaScriptArray, JavaScriptPromise> functionDelegate)
    {
        FunctionType = JavaScriptWindowBindingObjectFunctionType.AsynchronousFunctionOnRemote;
        AsynchronousFunctionOnRemote = functionDelegate;
    }
}