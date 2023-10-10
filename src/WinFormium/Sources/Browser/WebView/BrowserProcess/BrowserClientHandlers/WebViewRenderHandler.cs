// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewRenderHandler : CefRenderHandler
{
    public IRenderHandler Handler { get; }

    public WebViewRenderHandler(IRenderHandler handler)
    {
        Handler = handler;
    }

    protected override CefAccessibilityHandler GetAccessibilityHandler()
    {
        return Handler.GetAccessibilityHandler();
    }

    protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
    {
        return Handler.GetRootScreenRect(browser, ref rect);
    }

    protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
    {
        return Handler.GetScreenInfo(browser, screenInfo);
    }

    protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
    {
        return Handler.GetScreenPoint(browser, viewX, viewY, ref screenX, ref screenY);
    }

    protected override void GetTouchHandleSize(CefBrowser browser, CefHorizontalAlignment orientation, out CefSize size)
    {
        Handler.GetTouchHandleSize(browser, orientation, out size);
    }

    protected override void GetViewRect(CefBrowser browser, out CefRectangle rect)
    {
        Handler.GetViewRect(browser, out rect);
    }

    protected override void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint sharedHandle)
    {
        Handler.OnAcceleratedPaint(browser, type, dirtyRects, sharedHandle);
    }

    protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
    {
        Handler.OnImeCompositionRangeChanged(browser, selectedRange, characterBounds);
    }

    protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint buffer, int width, int height)
    {
        Handler.OnPaint(browser, type, dirtyRects, buffer, width, height);
    }

    protected override void OnPopupShow(CefBrowser browser, bool show)
    {
        Handler.OnPopupShow(browser, show);
    }

    protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
    {
        Handler.OnPopupSize(browser, rect);
    }

    protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
    {
        Handler.OnScrollOffsetChanged(browser, x, y);
    }

    protected override void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
    {
        Handler.OnTextSelectionChanged(browser, selectedText, selectedRange);
    }

    protected override void OnTouchHandleStateChanged(CefBrowser browser, CefTouchHandleState state)
    {
        Handler.OnTouchHandleStateChanged(browser, state);
    }

    protected override void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
    {
        Handler.OnVirtualKeyboardRequested(browser, inputMode);
    }

    protected override bool StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
    {
        return Handler.StartDragging(browser, dragData, allowedOps, x, y);
    }

    protected override void UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
    {
        Handler.UpdateDragCursor(browser, operation);
    }
}
