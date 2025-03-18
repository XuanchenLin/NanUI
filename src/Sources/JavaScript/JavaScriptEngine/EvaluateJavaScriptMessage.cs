// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.JavaScript;

internal record EvaluateJavaScriptMessage
{
    public required int TaskId { get; init; }
    public required string Code { get; init; } = string.Empty;
    public required string Url { get; init; } = string.Empty;
    public required int Line { get; init; }
}

