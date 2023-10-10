// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public delegate StandardWindowBase CreateHostWindowDelegate();

public delegate bool WndProcDelegate(ref Message m);

public delegate void OnOffscreenPaintDelegate(CefPaintElementType type, IntPtr bufferPtr, int width, int height,bool isPopupShown, CefRectangle? popupRect = null);

public interface IFormStyle
{
    WndProcDelegate? OnWndProc { get; set; }
    WndProcDelegate? OnDefWndProc { get; set; }
    OnOffscreenPaintDelegate? OffscreenPaint { get; set; }

}
