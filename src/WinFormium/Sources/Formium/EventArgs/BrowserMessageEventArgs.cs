// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

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
