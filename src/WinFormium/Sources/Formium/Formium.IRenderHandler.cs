// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;

namespace WinFormium;
public partial class Formium : IRenderHandler
{
    CefAccessibilityHandler? IRenderHandler.GetAccessibilityHandler()
    {
        return new FormiumAccessibilityHandler();
    }

    void IRenderHandler.OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint sharedHandle)
    {
        throw new NotImplementedException();
    }

    void IRenderHandler.GetTouchHandleSize(CefBrowser browser, CefHorizontalAlignment orientation, out CefSize size)
    {
        size = new CefSize(0, 0);
    }

    void IRenderHandler.OnTouchHandleStateChanged(CefBrowser browser, CefTouchHandleState state)
    {
    }

    bool IRenderHandler.GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
    {
        return false;
    }

    bool IRenderHandler.GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
    {
        return GetScreenInfo(screenInfo);
    }



    bool IRenderHandler.GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
    {
        return GetScreenPoint(viewX, viewY, ref screenX, ref screenY);
    }




    void IRenderHandler.GetViewRect(CefBrowser browser, out CefRectangle rect)
    {
        GetViewRect(out rect);
    }

    void IRenderHandler.OnPopupShow(CefBrowser browser, bool show)
    {
        OnPopupShow(show);
    }

    void IRenderHandler.OnPopupSize(CefBrowser browser, CefRectangle rect)
    {
        OnPopupSize(rect);
    }

    void IRenderHandler.OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
    {
        OnImeCompositionRangeChanged(selectedRange, characterBounds);
    }



    void IRenderHandler.OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint buffer, int width, int height)
    {
        OnOffscreenPaint(type, dirtyRects, buffer, width, height);
    }


    void IRenderHandler.OnScrollOffsetChanged(CefBrowser browser, double x, double y)
    {
    }

    void IRenderHandler.OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
    {
    }



    void IRenderHandler.OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
    {
        InvokeOnUIThread(()=> { OnVirtualKeyboardRequested(inputMode); });
    }



    bool IRenderHandler.StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
    {
        if (HostWindow == null) return false;

        InvokeOnUIThread(() => StartDragging(dragData, allowedOps, x, y));

        return true;
    }


    void IRenderHandler.UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
    {
    }




    internal float CurrentScaleFactor => GetCurrentScaleFactor();

    private float GetCurrentScaleFactor()
    {
        if (WindowHandle == (nint)0) return 1.0f;

        return SystemDpiManager.GetScaleFactorForWindow(WindowHandle);
    }

    private bool GetScreenInfo(CefScreenInfo screenInfo)
    {
        screenInfo.DeviceScaleFactor = GetCurrentScaleFactor();

        return true;
    }

    private bool GetScreenPoint(int viewX, int viewY, ref int screenX, ref int screenY)
    {
        if (WindowHandle == (nint)0) return false;


        var pt = new POINT((int)(Math.Ceiling(viewX * CurrentScaleFactor)), (int)(Math.Ceiling(viewY * CurrentScaleFactor)));

        ClientToScreen(WindowHandle, ref pt);

        screenX = pt.X;
        screenY = pt.Y;

        return true;
    }


    private void GetViewRect(out CefRectangle rect)
    {
        if (WindowHandle == (nint)0)
        {
            rect = new CefRectangle(0, 0, 0, 0);
            return;
        }

        rect = new CefRectangle();

        GetClientRect(WindowHandle, out var clientRect);

        //System.Diagnostics.Debug.WriteLine($"[OFFSCREEN] GetClientRect: {clientRect.Width}×{clientRect.Height}");

        rect.X = rect.Y = 0;

        if (IsIconic(WindowHandle) || clientRect.Width == 0 || clientRect.Height == 0)
        {
            var placement = new WINDOWPLACEMENT();

            GetWindowPlacement(WindowHandle, ref placement);

            clientRect = placement.rcNormalPosition;

            rect.Width = (int)(Math.Ceiling(clientRect.Width / CurrentScaleFactor));
            rect.Height = (int)(Math.Ceiling(clientRect.Height / CurrentScaleFactor));
        }
        else
        {
            rect.Width = (int)(Math.Ceiling(clientRect.Width / CurrentScaleFactor));
            rect.Height = (int)(Math.Ceiling(clientRect.Height / CurrentScaleFactor));
        }

        _offscreenViewRect = new CefRectangle
        {
            X = 0,
            Y = 0,
            Width = clientRect.Width,
            Height = clientRect.Height
        };

        //System.Diagnostics.Debug.WriteLine($"[OFFSCREEN] GetViewRect: {rect.Width}×{rect.Height}");
    }

    private void OnPopupShow(bool show)
    {
        _offscreenIsPopupShown = show;

        if (!show)
        {
            _offscreenPopupRect = null;
        }
    }

    private void OnPopupSize(CefRectangle rect)
    {
        _offscreenPopupRect = new CefRectangle
        {
            X = (int)(Math.Ceiling(rect.X * CurrentScaleFactor)),
            Y = (int)(Math.Ceiling(rect.Y * CurrentScaleFactor)),
            Width = (int)(Math.Ceiling(rect.Width * CurrentScaleFactor)),
            Height = (int)(Math.Ceiling(rect.Height * CurrentScaleFactor))
        };
    }

    CefRectangle? _offscreenPopupRect;
    CefRectangle? _offscreenViewRect;
    bool _offscreenIsPopupShown;
    //IntPtr? _viewBufferPtr;
    //IntPtr? _popupBufferPtr;

    private void OnOffscreenPaint(CefPaintElementType type, CefRectangle[] dirtyRects, nint buffer, int width, int height)
    {
        if (width <= 0 || height <= 0) return;

        CurrentFormStyle.OnOffscreenPaint?.Invoke(type,buffer,width,height, _offscreenIsPopupShown,_offscreenPopupRect);
    }


    private void OnVirtualKeyboardRequested(CefTextInputMode inputMode)
    {
        if (inputMode == CefTextInputMode.None)
        {
            SetFocusOnEditableElement(false);
        }
        else
        {
            SetFocusOnEditableElement(true);
        }
    }

    private void OnImeCompositionRangeChanged(CefRange selectedRange, CefRectangle[] characterBounds)
    {
        InvokeOnUIThread(() => ImeHandler?.ChangeCompositionRange(selectedRange, characterBounds));
    }

    private void StartDragging(CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
    {
        if (HostWindow == null) return;

        var dataObj = new DataObject();

        
        if(!string.IsNullOrEmpty(dragData.FragmentText))
            dataObj.SetText(dragData.FragmentText, TextDataFormat.Text);
        else if(!string.IsNullOrEmpty(dragData.FragmentHtml))
            dataObj.SetText(dragData.FragmentHtml, TextDataFormat.Html);


        var result = HostWindow.DoDragDrop(dataObj, GetDragDropEffects(allowedOps));

        var ops = GetCefDragOperationsMask(result);

        BrowserHost?.DragSourceEndedAt(x, y, ops);
        BrowserHost?.DragSourceSystemDragEnded();
    }

}

internal class FormiumAccessibilityHandler : CefAccessibilityHandler
{
    protected override void OnAccessibilityLocationChange(CefValue value)
    {
    }

    protected override void OnAccessibilityTreeChange(CefValue value)
    {
    }


}
