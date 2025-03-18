// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.CefGlue.Interop;
using System.Diagnostics;

namespace NetDimension.NanUI.CefGlue;
/// <summary>
/// Structure representing mouse event information.
/// </summary>
public unsafe struct CefMouseEvent
{
    private int _x;
    private int _y;
    private CefEventFlags _modifiers;

    public CefMouseEvent(int x, int y, CefEventFlags modifiers)
    {
        _x = x;
        _y = y;
        _modifiers = modifiers;
    }

    internal CefMouseEvent(cef_mouse_event_t* ptr)
    {
        Debug.Assert(ptr != null);

        _x = ptr->x;
        _y = ptr->y;
        _modifiers = ptr->modifiers;
    }

    internal cef_mouse_event_t ToNative()
    {
        return new cef_mouse_event_t(_x, _y, _modifiers);
    }

    public int X
    {
        get { return _x; }
        set { _x = value; }
    }

    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public CefEventFlags Modifiers
    {
        get { return _modifiers; }
        set { _modifiers = value; }
    }
}
