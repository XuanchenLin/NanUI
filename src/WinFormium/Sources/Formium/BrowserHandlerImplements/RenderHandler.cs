// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class RenderHandler : IRenderHandler
{
    CefAccessibilityHandler? IRenderHandler.GetAccessibilityHandler()
    {
        return GetAccessibilityHandler();
    }

    bool IRenderHandler.GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
    {
        return GetRootScreenRect(browser, ref rect);
    }

    bool IRenderHandler.GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
    {
        return GetScreenInfo(browser, screenInfo);
    }

    bool IRenderHandler.GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
    {
        return GetScreenPoint(browser, viewX, viewY, ref screenX, ref screenY);
    }

    void IRenderHandler.GetTouchHandleSize(CefBrowser browser, CefHorizontalAlignment orientation, out CefSize size)
    {
        GetTouchHandleSize(browser, orientation, out size);
    }

    void IRenderHandler.GetViewRect(CefBrowser browser, out CefRectangle rect)
    {
        GetViewRect(browser, out rect);
    }

    void IRenderHandler.OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr sharedHandle)
    {
        OnAcceleratedPaint(browser, type, dirtyRects, sharedHandle);
    }

    void IRenderHandler.OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
    {
        OnImeCompositionRangeChanged(browser, selectedRange, characterBounds);
    }

    void IRenderHandler.OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
    {
        OnPaint(browser, type, dirtyRects, buffer, width, height);
    }

    void IRenderHandler.OnPopupShow(CefBrowser browser, bool show)
    {
        OnPopupShow(browser, show);
    }

    void IRenderHandler.OnPopupSize(CefBrowser browser, CefRectangle rect)
    {
        OnPopupSize(browser, rect);
    }

    void IRenderHandler.OnScrollOffsetChanged(CefBrowser browser, double x, double y)
    {
        OnScrollOffsetChanged(browser, x, y);
    }

    void IRenderHandler.OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
    {
        OnTextSelectionChanged(browser, selectedText, selectedRange);
    }

    void IRenderHandler.OnTouchHandleStateChanged(CefBrowser browser, CefTouchHandleState state)
    {
        OnTouchHandleStateChanged(browser, state);
    }

    void IRenderHandler.OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
    {
        OnVirtualKeyboardRequested(browser, inputMode);
    }

    bool IRenderHandler.StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
    {
        return StartDragging(browser, dragData, allowedOps, x, y);
    }

    void IRenderHandler.UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
    {
        UpdateDragCursor(browser, operation);
    }

    protected virtual CefAccessibilityHandler? GetAccessibilityHandler()
    {
        return null;
    }

    protected virtual bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
    {
        return false;
    }

    protected virtual bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
    {
        return false;
    }

    protected virtual bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
    {
        return false;
    }

    protected virtual void GetTouchHandleSize(CefBrowser browser, CefHorizontalAlignment orientation, out CefSize size)
    {
        size = default;
    }

    protected virtual void GetViewRect(CefBrowser browser, out CefRectangle rect)
    {
        rect = default;
    }

    protected virtual void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr sharedHandle)
    {
    }

    protected virtual void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
    {
    }

    protected virtual void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
    {
    }

    protected virtual void OnPopupShow(CefBrowser browser, bool show)
    {
    }

    protected virtual void OnPopupSize(CefBrowser browser, CefRectangle rect)
    {
    }

    protected virtual void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
    {
    }

    protected virtual void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
    {
    }

    protected virtual void OnTouchHandleStateChanged(CefBrowser browser, CefTouchHandleState state)
    {
    }

    protected virtual void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
    {
    }

    protected virtual bool StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
    {
        return false;
    }

    protected virtual void UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
    {
    }


}
