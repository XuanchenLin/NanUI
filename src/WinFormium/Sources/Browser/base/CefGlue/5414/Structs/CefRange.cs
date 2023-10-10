// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
public struct CefRange
{
    private int _from;
    private int _to;

    public CefRange(int from, int to)
    {
        _from = from;
        _to = to;
    }

    public int From
    {
        get { return _from; }
        set { _from = value; }
    }

    public int To
    {
        get { return _to; }
        set { _to = value; }
    }
}
