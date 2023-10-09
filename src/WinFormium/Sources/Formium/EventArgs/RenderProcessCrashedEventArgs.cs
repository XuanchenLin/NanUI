// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium;

public class RenderProcessCrashedEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public CefTerminationStatus Status { get; }
    public RenderProcessCrashedEventArgs(CefBrowser browser,CefTerminationStatus status)
    {
        Browser = browser;
        Status = status;
    }

    public bool RestartProcess { get; set; } = false;
}
