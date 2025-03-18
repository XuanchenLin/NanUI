// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using NetDimension.NanUI.Forms.OffscreenRender;

using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.Forms.TransparencyForm;

partial class _FackUnusedClass
{

}


internal class LayeredWindow : LayeredWindowTransparencyForm
{
    IOffscreenRender? offscreenRender { get; set; }
    protected override bool CanEnableIme { get; }

    public LayeredWindow(TransparencyFormStyle style)
    {
        Style = style;

        if (!style.Sizable)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }



        if (style.OffScreenRenderEnabled)
        {
            CanEnableIme = true;

            ImeMode = ImeMode.Disable;


        }
    }

    protected override void OnLoad(EventArgs e)
    {
        if (Style.OffScreenRenderEnabled)
        {
            if (Style.RenderType == TransparencyFormRenderType.Direct2D)
            {
                offscreenRender = new Direct2DOffscreenRender(this);
            }
            else
            {
                offscreenRender = new SkiaOffscreenRender(this);
            }


            Style.OnOffscreenPaint = OnOffscreenPaint;
        }
        base.OnLoad(e);
    }

    public TransparencyFormStyle Style { get; }
    protected override bool EnableHitTest { get; } = false;

    protected override void DefWndProc(ref Message m)
    {
        var retval = Style.OnDefWndProc?.Invoke(ref m) ?? false;

        if (!retval)
        {
            base.DefWndProc(ref m);
        }
    }

    protected override void WndProc(ref Message m)
    {
        var retval = NaviteMessageHandler(ref m);

        if (!retval)
        {
            retval = Style.OnWndProc?.Invoke(ref m) ?? false;
        }

            if (!retval)
        {
            base.WndProc(ref m);
        }
    }

    #region Native Hittest

    private bool NaviteMessageHandler(ref Message m)
    {
        if (Style.Sizable)
        {
            var msg = (WindowMessage)m.Msg;

            switch (msg)
            {
                case WindowMessage.WM_MOUSEMOVE:
                    return BrowserWmMouseMove(ref m);
                case WindowMessage.WM_SETCURSOR:
                    return BrowserWmSetCursor(ref m);
                case WindowMessage.WM_LBUTTONDOWN:
                    return BrowserLButtonDown(ref m);
            }
        }

        return false;
    }

    private bool BrowserLButtonDown(ref Message m)
    {
        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var mode = HitTest(point);

        if (mode == HitTestValues.HTNOWHERE) return false;

        ClientToScreen(Handle, ref point);

        if (Style.Sizable && mode != HitTestValues.HTCLIENT && WindowState == FormWindowState.Normal)
        {
            ReleaseCapture();

            PostMessage(Handle, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)mode, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }

        return false;
    }

    private bool BrowserWmSetCursor(ref Message m)
    {
        #region SETCURSOR
        void SetCursor(HitTestValues mode)
        {
            SafeHCURSOR? handle = null;

            switch (mode)
            {
                case HitTestValues.HTTOP:
                case HitTestValues.HTBOTTOM:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32645));
                    break;
                case HitTestValues.HTLEFT:
                case HitTestValues.HTRIGHT:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32644));
                    break;
                case HitTestValues.HTTOPLEFT:
                case HitTestValues.HTBOTTOMRIGHT:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32642));

                    break;
                case HitTestValues.HTTOPRIGHT:
                case HitTestValues.HTBOTTOMLEFT:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32643));
                    break;
                default:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32512));
                    break;
            }


            if (handle != null)
            {
                var oldCursor = User32.SetCursor(handle);

                oldCursor?.Close();
            }
        }
        #endregion

        if (WindowState != FormWindowState.Normal) return false;

        if (!Style.Sizable) return false;


        var pos = GetMessagePos();
        var point = new POINT(Macros.LOWORD(pos), Macros.HIWORD(pos));
        ScreenToClient(Handle, ref point);

        var retval = HitTest(point);

        if(retval != HitTestValues.HTCLIENT && retval != HitTestValues.HTNOWHERE)
        {
            SetCursor(retval);

            m.Result = (IntPtr)1;

            return true;
        }



        return false;
    }

    private bool BrowserWmMouseMove(ref Message m)
    {
        if (WindowState != FormWindowState.Normal) return false;

        var lparam = m.LParam;

        var point = new Point(Macros.GET_X_LPARAM(lparam), Macros.GET_Y_LPARAM(lparam));

        var retval = HitTest(point);

        return retval != HitTestValues.HTNOWHERE && retval != HitTestValues.HTCLIENT;
    }

    protected internal override HitTestValues HitTest(Point point)
    {
        var htSize = Convert.ToInt32(Math.Ceiling(4 * WindowDpiAdapter.ScaleFactor));

        var hitTestValue = HitTestValues.HTNOWHERE;

        GetWindowRect(WND, out var lpRect);

        OffsetRect(ref lpRect, -lpRect.left, -lpRect.top);

        var excludedBorders = Style.ExcludedBorderArea;

        var left = lpRect.left + excludedBorders.Left;
        var top = lpRect.top + excludedBorders.Top;
        var right = lpRect.right - excludedBorders.Right;
        var bottom = lpRect.bottom - excludedBorders.Bottom;

        var rect = new Rectangle(left, top, right - left, bottom - top);

        if (rect.Contains(point))
        {
            hitTestValue = HitTestValues.HTCLIENT;

            var x = point.X;
            var y = point.Y;

            if (x < rect.Left + htSize * 2 && y < rect.Top + htSize * 2)
            {
                hitTestValue = HitTestValues.HTTOPLEFT;
            }
            else if (x >= rect.Left + htSize * 2 && x <= rect.Right - htSize * 2 && y <= rect.Top + htSize)
            {
                hitTestValue = HitTestValues.HTTOP;
            }
            else if (x > rect.Right - htSize * 2 && y <= rect.Top + htSize * 2)
            {
                hitTestValue = HitTestValues.HTTOPRIGHT;
            }
            else if (x <= rect.Left + htSize && y >= rect.Top + htSize * 2 && y <= rect.Bottom - htSize * 2)
            {
                hitTestValue = HitTestValues.HTLEFT;
            }
            else if (x >= rect.Right - htSize && y >= rect.Top * 2 + htSize && y <= rect.Bottom - htSize * 2)
            {
                hitTestValue = HitTestValues.HTRIGHT;
            }
            else if (x <= rect.Left + htSize * 2 && y >= rect.Bottom - htSize * 2)
            {
                hitTestValue = HitTestValues.HTBOTTOMLEFT;
            }
            else if (x > rect.Left + htSize * 2 && x < rect.Right - htSize * 2 && y >= rect.Bottom - htSize)
            {
                hitTestValue = HitTestValues.HTBOTTOM;
            }
            else if (x >= rect.Right - htSize * 2 && y >= rect.Bottom - htSize * 2)
            {
                hitTestValue = HitTestValues.HTBOTTOMRIGHT;
            }
        }

        //System.Diagnostics.Debug.WriteLine(hitTestValue);

        return hitTestValue;
    }

    #endregion


    private void OnOffscreenPaint(CefPaintElementType type, IntPtr bufferPtr, int width, int height, bool isPopupShown, CefRectangle? popupRect = null)
    {
        offscreenRender?.Paint(type, bufferPtr, width, height, isPopupShown, popupRect);
    }
}
