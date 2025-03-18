// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class BrowserMessageEventArgs : EventArgs
{
    public BrowserMessageEventArgs(string message, JavaScriptValue value)
    {
        Message = message;
        Value = value;
    }

    public string Message { get; }
    public JavaScriptValue Value { get; }
}
