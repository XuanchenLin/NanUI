// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class CursorChangeEventArgs : EventArgs
{
    private nint cursorHandle;
    private CefCursorInfo customCursorInfo;

    public CursorChangeEventArgs(CefBrowser browser, nint cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
    {
        Browser = browser;
        this.cursorHandle = cursorHandle;
        CursorType = type;
        this.customCursorInfo = customCursorInfo;
    }

    public CefBrowser Browser { get; }
    public CefCursorType CursorType { get; }

    public Cursor GetCursor()
    {
        if (cursorHandle != IntPtr.Zero && CursorType != CefCursorType.None && CursorType != CefCursorType.Custom)
        {
            return new Cursor(cursorHandle);
        }
        else if (IsCustomCursor)
        {
            using var buff = new MemoryStream(customCursorInfo.GetBuffer());
            var cursor = new Cursor(buff);
            return cursor;
        }
        return Cursors.Default;
    }

    public void SetCursor(Cursor cursor)
    {
        User32.SetCursor(new User32.SafeHCURSOR(cursor.Handle));
    }

    public bool IsCustomCursor => CursorType == CefCursorType.Custom;

    public bool Handled { get; set; }
}
