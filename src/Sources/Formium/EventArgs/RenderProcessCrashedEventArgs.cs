// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

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
