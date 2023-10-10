// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class DragEnterEventArgs : EventArgs
{
    public DragEnterEventArgs(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        Browser = browser;
        DragData = dragData;
        Mask = mask;
    }

    public CefBrowser Browser { get; }
    public CefDragData DragData { get; }
    public CefDragOperationsMask Mask { get; }
    public bool AllowDragEnter { get; set; } =false;
}
