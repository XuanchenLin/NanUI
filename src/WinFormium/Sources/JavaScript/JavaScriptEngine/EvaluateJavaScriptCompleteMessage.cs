// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.JavaScript;

internal record EvaluateJavaScriptCompleteMessage
{
    public required int TaskId { get; init; }
    public required bool Success { get; init; }
    public string? Data { get; init; }
    public string? Message { get; init; }
    public JavaScriptException? Exception { get; init; }

}

