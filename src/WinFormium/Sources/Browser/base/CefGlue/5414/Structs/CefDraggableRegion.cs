// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
public sealed class CefDraggableRegion
{
    internal static unsafe CefDraggableRegion FromNative(cef_draggable_region_t* ptr)
    {
        return new CefDraggableRegion(ptr);
    }

    private readonly CefRectangle _bounds;
    private readonly bool _draggable;

    private unsafe CefDraggableRegion(cef_draggable_region_t* ptr)
    {
        _bounds = new CefRectangle(
            ptr->bounds.x,
            ptr->bounds.y,
            ptr->bounds.width,
            ptr->bounds.height
            );
        _draggable = ptr->draggable != 0;
    }

    public CefRectangle Bounds { get { return _bounds; } }

    public bool Draggable { get { return _draggable; } }
}
