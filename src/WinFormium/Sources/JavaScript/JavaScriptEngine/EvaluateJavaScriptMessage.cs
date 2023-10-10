// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal record EvaluateJavaScriptMessage
{
    public required int TaskId { get; init; }
    public required string Code { get; init; } = string.Empty;
    public required string Url { get; init; } = string.Empty;
    public required int Line { get; init; }
}

