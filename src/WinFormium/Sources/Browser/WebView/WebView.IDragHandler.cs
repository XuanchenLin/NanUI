// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal partial class WebView : IDragHandler
{
    #region interface
    bool IDragHandler.OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        return WebViewHost.DragHandler?.OnDragEnter(browser, dragData, mask) ?? false;
    }

    void IDragHandler.OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
        WebViewHost.DragHandler?.OnDraggableRegionsChanged(browser, frame, regions);

        OnDraggableRegionsChanged(browser, frame, regions);
    }
    #endregion



    private void OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
        var draggableRegion = new Region(new Rectangle(0, 0, 0, 0));

        if (WindowHandle != IntPtr.Zero && regions != null && regions.Length > 0)
        {
            var scaleFactor = SystemDpiManager.GetScaleFactorForWindow(WindowHandle);


            foreach (var region in regions)
            {
                var rect = new Rectangle((int)(region.Bounds.X * scaleFactor), (int)(region.Bounds.Y * scaleFactor), (int)(region.Bounds.Width * scaleFactor), (int)(region.Bounds.Height * scaleFactor));

                if (region.Draggable)
                {
                    draggableRegion.Union(rect);
                }
                else
                {
                    draggableRegion.Exclude(rect);
                }

            }

            //foreach (var region in regions.Where(x=>x.Draggable == false))
            //{
            //    var rect = new Rectangle((int)(region.Bounds.X * scaleFactor), (int)(region.Bounds.Y * scaleFactor), (int)(region.Bounds.Width * scaleFactor), (int)(region.Bounds.Height * scaleFactor));

            //    draggableRegion.Exclude(rect);
            //}
        }

        WebViewHost.DraggableRegion?.Dispose();

        WebViewHost.DraggableRegion = draggableRegion;
    }
}
