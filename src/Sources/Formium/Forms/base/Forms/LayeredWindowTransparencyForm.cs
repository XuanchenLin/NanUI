// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Drawing.Imaging;

using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.Forms;

partial class _FackUnusedClass
{

}

public abstract class LayeredWindowTransparencyForm : FramelessWindowBase
{
    protected override bool IsWindowTransparent => true;
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;

            cp.ExStyle |= (int)(WindowStylesEx.WS_EX_LAYERED);

            return cp;

        }
    }

    //protected override void WndProc(ref Message m)
    //{
    //    var msg = (WindowMessage)m.Msg;
    //    switch (msg)
    //    {
    //        case WindowMessage.WM_WINDOWPOSCHANGING:
    //            {
    //                var wp = m.LParam.ToStructure<WINDOWPOS>();

    //                var flag = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE;

    //                if ((wp.flags & flag) != flag)
    //                {
    //                    RenderLayeredBitmapInternal(new RECT(wp.x, wp.y, wp.x + wp.cx, wp.y + wp.cy));
    //                }
    //            }
    //            break;
    //        case WindowMessage.WM_ACTIVATE:
    //            {
    //                Invalidate();
    //            }
    //            break;
    //        case WindowMessage.WM_PAINT:
    //        case WindowMessage.WM_SHOWWINDOW:
    //            {
    //                RenderLayeredBitmapInternal(forceRedraw: true);
    //            }
    //            break;

    //    }


    //    base.WndProc(ref m);

    //}


    public LayeredWindowTransparencyForm()
: base(FramelessWindowType.GDI)
    {
        ShowBorder = true;
    }

    #region LayeredWindow staffs
    const int AcSrcOver = 0x00;
    const int AcSrcAlpha = 0x01;

    protected virtual void OnLayeredBitmapPaint(SKCanvas canvas)
    {

    }


    Size _lastWindowSize = Size.Empty;

    private void RenderLayeredBitmapInternal(RECT? rect = null, bool forceRedraw = false)
    {
        if (WND == HWND.NULL) return;

        RECT windowRect;

        if (rect == null)
        {
            GetWindowRect(WND, out windowRect);
        }
        else
        {
            windowRect = rect.Value;
        }


        var width = windowRect.Width;
        var height = windowRect.Height;

        if (width <= 0 || height <= 0) return;

        if (forceRedraw || _lastWindowSize.Width != width || _lastWindowSize.Height != height)
        {
            using var bitmap = new Bitmap(width, height);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

            using var surface = SKSurface.Create(new SKImageInfo()
            {
                AlphaType = SKAlphaType.Premul,
                ColorType = SKColorType.Bgra8888,
                Height = height,
                Width = width
            }, bitmapData.Scan0, bitmapData.Stride);

            using var canvas = surface.Canvas;

            OnLayeredBitmapPaint(canvas);

            bitmap.UnlockBits(bitmapData);

            UpdateFormLayeredBitmap(windowRect, bitmap);

            System.GC.Collect();

            _lastWindowSize = new Size(width, height);

        }
    }

    protected void UpdateFormLayeredBitmap(Rectangle rectangle, Bitmap bitmap)
    {

        var windowRect = new RECT(rectangle);

        using var screenDC = GetDC();
        using var memDC = CreateCompatibleDC(screenDC);

        var hBitmap = HBITMAP.NULL;
        var hOldBitmap = HBITMAP.NULL;

        try
        {
            hBitmap = new HBITMAP(bitmap.GetHbitmap(Color.FromArgb(0x00, 0x00, 0x00, 0x00)));
            hOldBitmap = SelectObject(memDC, hBitmap);

            var location = new POINT(windowRect.X, windowRect.Y);
            var size = new SIZE(windowRect.Width, windowRect.Height);

            UpdateLayeredWindow(WND, screenDC, location, size, memDC, POINT.Empty, COLORREF.Default, new BLENDFUNCTION
            {
                AlphaFormat = AcSrcAlpha,
                BlendOp = AcSrcOver,
                SourceConstantAlpha = 0xff,
                BlendFlags = 0x00
            }, UpdateLayeredWindowFlags.ULW_ALPHA);

        }
        finally
        {
            if (hBitmap != HBITMAP.NULL)
            {
                SelectObject(memDC, hOldBitmap);
                DeleteObject(hBitmap);
            }

            if (memDC != HDC.NULL)
            {
                DeleteDC(memDC);
            }

            if (screenDC != HDC.NULL)
            {
                ReleaseDC(IntPtr.Zero, screenDC);
            }

        }

        var windowpos = new WINDOWPOS
        {
            hwnd = WND,
            hwndInsertAfter = HWND.NULL,
            x = windowRect.X,
            y = windowRect.Y,
            cx = windowRect.Width,
            cy = windowRect.Height,
            flags = SetWindowPosFlags.SWP_NOSENDCHANGING | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOMOVE
        };
        var pointer = Marshal.AllocCoTaskMem(Marshal.SizeOf(windowpos));
        Marshal.StructureToPtr(windowpos, pointer, false);
        SendMessage(WND, (uint)WindowMessage.WM_WINDOWPOSCHANGED, IntPtr.Zero, pointer);
        Marshal.FreeCoTaskMem(pointer);

    }


    #endregion


}
