// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;

namespace WinFormium;
public partial class Formium
{
    internal OffscreenImeHandler? ImeHandler { get; set; }

    internal void RegisterOffscreenModeEvents()
    {
        if (HostWindow == null) throw new NullReferenceException();

        HostWindow.KeyDown += (_,args)=> OffscreenKeyDown(args);
        HostWindow.KeyUp += (_, args) => OffscreenKeyUp(args);
        HostWindow.KeyPress += (_, args) => OffscreenKeyPress(args);

        HostWindow.MouseMove += (_, args) => OffscreenMouseMove(args);
        HostWindow.MouseLeave += (_, args) => OffscreenMouseLeave();

        HostWindow.MouseDown += (_, args) => OffscreenMouseDown(args);
        HostWindow.MouseUp += (_, args) => OffscreenMouseUp(args);

        HostWindow.MouseClick += (_, args) => OffscreenMouseClick(args);

        HostWindow.MouseWheel += (_, args) => OffscreenMouseWheel(args);

    }

    private void CancelImeComposition(CefBrowserHost host)
    {
        ImeHandler?.OnImeCancelComposition();

        host.ImeCommitText(string.Empty, new CefRange(int.MaxValue, int.MaxValue), 0);

        host.ImeSetComposition(string.Empty, 0, new CefCompositionUnderline(), new CefRange(int.MaxValue, int.MaxValue), new CefRange(0, 0));


        host.ImeFinishComposingText(false);

        //SendMessage(WindowHandle, WindowMessage.WM_IME_KEYDOWN, 0);
    }

    private void OffscreenMouseWheel(MouseEventArgs e)
    {
        var pt = e.Location;

        GetPointInCurrentView(ref pt);

        BrowserHost?.SendMouseWheelEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), 0, e.Delta);

    }


    private void OffscreenMouseDown(MouseEventArgs e)
    {
        var pt = e.Location;


        GetPointInCurrentView(ref pt);

        CefMouseButtonType? buttonType = null;

        switch (e.Button)
        {
            case MouseButtons.Right:
                buttonType = CefMouseButtonType.Right;
                break;
            case MouseButtons.Middle:
                buttonType = CefMouseButtonType.Middle;
                break;
            case MouseButtons.Left:
                buttonType = CefMouseButtonType.Left;
                break;
        }

        if (buttonType.HasValue)
        {
            BrowserHost?.SendMouseClickEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), buttonType.Value, false, e.Clicks);
        }
    }

    private void OffscreenMouseUp(MouseEventArgs e)
    {
        var pt = e.Location;


        GetPointInCurrentView(ref pt);

        CefMouseButtonType? buttonType = null;

        switch (e.Button)
        {
            case MouseButtons.Right:
                buttonType = CefMouseButtonType.Right;
                break;
            case MouseButtons.Middle:
                buttonType = CefMouseButtonType.Middle;
                break;
            case MouseButtons.Left:
                buttonType = CefMouseButtonType.Left;
                break;
        }

        if (buttonType.HasValue)
        {
            BrowserHost?.SendMouseClickEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), buttonType.Value, true, e.Clicks);
        }
    }

    private void OffscreenMouseClick(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.XButton1)
        {
            if (Browser?.CanGoBack == true)
                Browser?.GoBack();
        }

        if (e.Button == MouseButtons.XButton2)
        {
            if (Browser?.CanGoForward == true)
                Browser?.GoForward();
        }

    }

    private void OffscreenMouseLeave()
    {
        BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(0, 0, CefEventFlags.None), true);
    }

    private void OffscreenMouseMove(MouseEventArgs e)
    {
        var pt = e.Location;

        GetPointInCurrentView(ref pt);

        BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), false);
    }

    private void OffscreenKeyDown(KeyEventArgs e)
    {
        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.KeyDown,
            WindowsKeyCode = (int)e.KeyCode,
            NativeKeyCode = (int)e.KeyValue,
            Modifiers = GetKeyboardModifiers(e.Modifiers),
            FocusOnEditableField = _isOnEditableField,
        });
    }

    private void OffscreenKeyUp(KeyEventArgs e)
    {
        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.KeyUp,
            WindowsKeyCode = (int)e.KeyCode,
            NativeKeyCode = (int)e.KeyValue,
            Modifiers = GetKeyboardModifiers(e.Modifiers),
            FocusOnEditableField = !_isOnEditableField,
        });
    }



    private void OffscreenKeyPress(KeyPressEventArgs e)
    {
        e.Handled = true;

        BrowserHost?.SendKeyEvent(new CefKeyEvent
        {
            EventType = CefKeyEventType.Char,
            WindowsKeyCode = e.KeyChar,
            Character = e.KeyChar,
            UnmodifiedCharacter = e.KeyChar,
            FocusOnEditableField = _isOnEditableField,
        });
    }


    private void GetPointInCurrentView(ref Point point)
    {
        var scaleFactor = SystemDpiManager.GetScaleFactorForWindow(WindowHandle);

        point.X = (int)(point.X / scaleFactor);
        point.Y = (int)(point.Y / scaleFactor);
    }

    private static CefEventFlags GetMouseModifiers(MouseButtons mouseButtons)
    {
        var modifiers = new CefEventFlags();

        if (mouseButtons == MouseButtons.Left)
            modifiers |= CefEventFlags.LeftMouseButton;

        if (mouseButtons == MouseButtons.Middle)
            modifiers |= CefEventFlags.MiddleMouseButton;

        if (mouseButtons == MouseButtons.Right)
            modifiers |= CefEventFlags.RightMouseButton;

        return modifiers;
    }


    private static CefEventFlags GetKeyboardModifiers(Keys modifiers)
    {
        var result = new CefEventFlags();

        if (modifiers == Keys.Alt)
            result |= CefEventFlags.AltDown;

        if (modifiers == Keys.Control)
            result |= CefEventFlags.ControlDown;

        if (modifiers == Keys.Shift)
            result |= CefEventFlags.ShiftDown;

        return result;
    }

    private bool _isOnEditableField = false;

    internal void SetFocusOnEditableElement(bool onEditableElement)
    {

        if (HostWindow == null) return;

        _isOnEditableField = onEditableElement;

        if (onEditableElement == true)
        {
            HostWindow.ImeMode  = ImeMode.Inherit;
        }
        else
        {
            HostWindow.ImeMode = ImeMode.Disable;
        }
    }

    private static DragDropEffects GetDragDropEffects(CefDragOperationsMask mask)
    {
        if (mask.HasFlag(CefDragOperationsMask.Every))
        {
            return DragDropEffects.Scroll | DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Link;
        }
        if (mask.HasFlag(CefDragOperationsMask.Copy))
        {
            return DragDropEffects.Copy;
        }
        if (mask.HasFlag(CefDragOperationsMask.Move))
        {
            return DragDropEffects.Move;
        }
        if (mask.HasFlag(CefDragOperationsMask.Link))
        {
            return DragDropEffects.Link;
        }
        return DragDropEffects.None;

    }

    private static CefDragOperationsMask GetCefDragOperationsMask(DragDropEffects dragDropEffects)
    {
        var operations = CefDragOperationsMask.None;

        if (dragDropEffects.HasFlag(DragDropEffects.All))
        {
            operations |= CefDragOperationsMask.Every;
        }
        if (dragDropEffects.HasFlag(DragDropEffects.Copy))
        {
            operations |= CefDragOperationsMask.Copy;
        }
        if (dragDropEffects.HasFlag(DragDropEffects.Move))
        {
            operations |= CefDragOperationsMask.Move;
        }
        if (dragDropEffects.HasFlag(DragDropEffects.Link))
        {
            operations |= CefDragOperationsMask.Link;
        }

        return operations;
    }


    private bool BrowserImeMessageHandler(ref Message m)
    {
        var msg = (WindowMessage)m.Msg;

        switch (msg)
        {
            case WindowMessage.WM_IME_SETCONTEXT:
                {
                    ImeHandler?.OnIMESetContext(ref m);
                }
                return true;
            case WindowMessage.WM_IME_STARTCOMPOSITION:
                {
                    ImeHandler?.OnImeStartComposition();
                }
                return true;
            case WindowMessage.WM_IME_COMPOSITION:
                {
                    ImeHandler?.OnImeComposition(msg, m.WParam, m.LParam);
                }
                return true;
            case WindowMessage.WM_IME_ENDCOMPOSITION:
                {
                    ImeHandler?.OnImeCancelComposition();
                }
                return false;
        }

        return false;
    }


}
