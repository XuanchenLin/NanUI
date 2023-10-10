// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public sealed class JavaScriptException
{
    public required int StartColumn { get; init; }
    public required int StartPosition { get; init; }
    public required int EndColumn { get; init; }
    public required int EndPosition { get; init; }
    public required int LineNumber { get; init; }
    public required string ScriptResourceName { get; init; }
    public required string SourceLine { get; init; }

}
