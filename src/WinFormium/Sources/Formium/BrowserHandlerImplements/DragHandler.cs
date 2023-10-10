// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public class DragHandler : IDragHandler
{
    bool IDragHandler.OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        return OnDragEnter(browser, dragData, mask);
    }

    void IDragHandler.OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
        OnDraggableRegionsChanged(browser, frame, regions);

    }

    internal protected virtual bool OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        return false;
    }

    internal protected virtual void OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
    }
}
