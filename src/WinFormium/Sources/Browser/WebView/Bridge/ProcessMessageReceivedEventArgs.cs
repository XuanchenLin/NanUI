// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;

internal class ProcessMessageReceivedEventArgs
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefProcessId ProcessId { get; }
    public CefProcessMessage Message { get; }

    public ProcessMessageReceivedEventArgs(CefBrowser browser, CefFrame frame, CefProcessId processId, CefProcessMessage message)
    {
        Browser = browser;
        Frame = frame;
        ProcessId = processId;
        Message = message;
    }

}
