// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
public struct CefColor
{
    private uint _value;

    public CefColor(uint argb)
    {
        _value = argb;
    }

    public CefColor(byte alpha, byte red, byte green, byte blue)
    {
        _value = unchecked((uint)((alpha << 24) | (red << 16) | (green << 8) | blue));
    }

    public byte A { get { return unchecked((byte)(_value >> 24)); } }

    public byte R { get { return unchecked((byte)(_value >> 16)); } }

    public byte G { get { return unchecked((byte)(_value >> 8)); } }

    public byte B { get { return unchecked((byte)(_value)); } }

    public uint ToArgb()
    {
        return _value;
    }
}
