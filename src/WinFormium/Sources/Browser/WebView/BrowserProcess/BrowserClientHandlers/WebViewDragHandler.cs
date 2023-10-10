// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewDragHandler : CefDragHandler
{
    public IDragHandler Handler { get; }

    public WebViewDragHandler(IDragHandler handler)
    {
        Handler = handler;
    }

    protected override bool OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        return Handler.OnDragEnter(browser, dragData, mask);
    }

    protected override void OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
        Handler.OnDraggableRegionsChanged(browser, frame, regions);
    }

}
