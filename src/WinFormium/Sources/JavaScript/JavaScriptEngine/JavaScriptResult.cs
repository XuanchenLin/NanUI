// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public record JavaScriptResult
{
    internal CefFrame TargetFrame { get; }
    public bool Success { get; }
    public string? ExceptionText { get; }
    public JavaScriptValue ReturnValue { get; }

    internal JavaScriptResult(CefFrame frame, bool isSuccess, string? data, string? jsException)
    {
        TargetFrame = frame;
        Success = isSuccess;
        ExceptionText = jsException;

        if (isSuccess && data != null)
        {
            ReturnValue = JavaScriptValue.FromJson(data);

            ReturnValue.AssociateToFrame(frame);

        }
        else
        {
            ReturnValue = new JavaScriptValue();
        }
    }


}
