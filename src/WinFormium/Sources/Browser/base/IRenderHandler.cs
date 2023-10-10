// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IRenderHandler
{
    CefAccessibilityHandler? GetAccessibilityHandler();
    bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect);
    void GetViewRect(CefBrowser browser, out CefRectangle rect);
    bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY);
    bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo);
    void OnPopupShow(CefBrowser browser, bool show);
    void OnPopupSize(CefBrowser browser, CefRectangle rect);
    void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint buffer, int width, int height);
    void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint sharedHandle);
    void GetTouchHandleSize(CefBrowser browser, CefHorizontalAlignment orientation, out CefSize size);
    void OnTouchHandleStateChanged(CefBrowser browser, CefTouchHandleState state);
    bool StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y);
    void UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation);
    void OnScrollOffsetChanged(CefBrowser browser, double x, double y);
    void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds);
    void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange);
    void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode);
}
