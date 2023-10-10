// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal record ExecuteJavaScriptFunctionMessage
{
    public int TaskId { get; init; }
    public Guid FunctionId { get; set; }
    public long FrameId { get; set; }
    public bool Success { get; set; }
    public string? Data { get; set; }
    public string? ExceptionText { get; set; }
}
