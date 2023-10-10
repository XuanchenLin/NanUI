// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : IDragHandler
{
    #region interface
    bool IDragHandler.OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        var retval = DragHandler?.OnDragEnter(browser, dragData, mask) ?? false;

        return retval ? retval : OnDragEnterCore(browser, dragData, mask);
    }

    void IDragHandler.OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
        DragHandler?.OnDraggableRegionsChanged(browser, frame, regions);
    }
    #endregion

    #region implements
    private bool OnDragEnterCore(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        if (!AllowDrop) return true;

        var args = new DragEnterEventArgs(browser, dragData, mask);

        InvokeOnUIThread(OnDragEnter, args);

        return args.AllowDragEnter;
    }
    #endregion
}
