using System.Diagnostics;

using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser;

internal sealed class WinFormiumDragHandler : CefDragHandler
{
    private readonly Formium _owner;

    private WinFormiumDragHandler() { }

    internal WinFormiumDragHandler(Formium owner)
    {
        _owner = owner;
    }

    protected override bool OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
    {
        var e = new DragEnterEventArgs(dragData, mask);

        _owner.InvokeIfRequired(() => _owner.OnDragEnter(e));

        return e.Handled;
    }

    protected override void OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
    {
        if (_owner.WebView.DraggableRegion != null)
        {
            _owner.WebView.DraggableRegion.Dispose();
            _owner.WebView.DraggableRegion = null;
        }

        _owner.WebView.DraggableRegion = new Region(new Rectangle(0, 0, 0, 0));

        if (regions.Length > 0)
        {

            var scaleFactor = DpiHelper.GetScaleFactorForWindow(_owner.HostWindowHandle);
            //DpiHelper.GetScaleFactorForCurrentWindow(_owner.WebView.BrowserHost.GetWindowHandle());

            //var targetRegion = _core.DraggableRegion = new Region();

            foreach (var region in regions)
            {
                var rect = new Rectangle((int)(region.Bounds.X * scaleFactor), (int)(region.Bounds.Y * scaleFactor), (int)(region.Bounds.Width * scaleFactor), (int)(region.Bounds.Height * scaleFactor));
                
                if (region.Draggable)
                {
                    _owner.WebView.DraggableRegion.Union(rect);
                }
                else
                {
                    _owner.WebView.DraggableRegion.Exclude(rect);
                }

            }
        }

    }
}

public class DragEnterEventArgs : EventArgs
{
    internal DragEnterEventArgs(CefDragData dragData, CefDragOperationsMask mask)
    {
        DragData = dragData;
        Mask = mask;
    }

    public bool Handled { get; set; } = false;

    public CefDragData DragData { get; }

    public CefDragOperationsMask Mask { get; }
}
