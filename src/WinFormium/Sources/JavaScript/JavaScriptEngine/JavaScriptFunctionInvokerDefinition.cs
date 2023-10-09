// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.JavaScript;

public class JavaScriptFunctionInvokerDefinition
{
    public required bool IsAsynchronous { get; init; }
    public required ProcessType Side { get; init; }

    public static JavaScriptFunctionInvokerDefinition FromJson(string json)
    {
        var retval = JsonSerializer.Deserialize<JavaScriptFunctionInvokerDefinition>(json);
        if (retval == null) throw new JsonException($"Failed to deserialize {nameof(JavaScriptFunctionInvokerDefinition)}");
        return retval;
    }


}
