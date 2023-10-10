// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public static class JavaScriptFunctionInvokerExtensions
{
    public static JavaScriptFunctionInvoker ToFunction(this JavaScriptValue jsValue)
    {
        if (jsValue != null && jsValue.ValueType == JavaScriptValueType.Function && jsValue is JavaScriptFunctionInvoker)
        {

            return (JavaScriptFunctionInvoker)jsValue;

        }
        else
        {
            throw new InvalidOperationException($"This is not a {nameof(JavaScriptFunctionInvoker)}.");

        }
    }

    public static Task<JavaScriptResult> ExecuteAsync(this JavaScriptValue jsValue, params JavaScriptValue[] arguments)
    {
        if (jsValue.ValueType != JavaScriptValueType.Function && !(jsValue is JavaScriptFunctionInvoker)) throw new InvalidOperationException($"{nameof(ExecuteAsync)} is only allowed for JavaScriptFunction type.");

        return ((JavaScriptFunctionInvoker)jsValue).ExecuteAsync(arguments);
    }

    public static Task<JavaScriptResult> ExecuteAsync(this JavaScriptValue jsValue, JavaScriptArray? arguments = null)
    {
        if (jsValue.ValueType != JavaScriptValueType.Function && !(jsValue is JavaScriptFunctionInvoker)) throw new InvalidOperationException($"{nameof(ExecuteAsync)} is only allowed for JavaScriptFunction type.");

        return ((JavaScriptFunctionInvoker)jsValue).ExecuteAsync(arguments);
    }
}
