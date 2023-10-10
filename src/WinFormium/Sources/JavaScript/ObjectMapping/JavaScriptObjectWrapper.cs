// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public abstract class JavaScriptObjectWrapper
{
    internal JavaScriptObject HostObject { get; } = new();

    protected void AddField(string name, JavaScriptValue value)
    {
        HostObject.Add(name, value);
    }

    protected void DefineProperty(string name, Func<JavaScriptValue> getter, Action<JavaScriptValue>? setter = null)
    {
        HostObject.DefineProperty(name, getter, setter);
    }

    protected void AddSynchronousFunction(string name, Func<JavaScriptArray, JavaScriptValue?> functionInvoker)
    {
        HostObject.Add(name, functionInvoker);
    }

    protected void AddAsynchronousFunction(string name, Action<JavaScriptArray,JavaScriptPromise> functionInvoker)
    {
        HostObject.Add(name, functionInvoker);
    }
}
