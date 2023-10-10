// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
public struct CefRectangle
{
    private int _x;
    private int _y;
    private int _width;
    private int _height;

    public CefRectangle(int x, int y, int width, int height)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
    }

    internal CefRectangle(cef_rect_t rect)
    {
        _x = rect.x;
        _y = rect.y;
        _width = rect.width;
        _height = rect.height;
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

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }

    internal cef_rect_t AsNative()
        => new cef_rect_t(_x, _y, _width, _height);
}
