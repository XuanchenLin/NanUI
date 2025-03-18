// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.Forms;
internal partial class ShadowElementWindow
{
    const string SHADOW_WND_NAME = "ShivaShadowElementWindow";

    public SafeHWND WND { get; private set; }

    public SafeHWND ParentWND { get; }

    private WindowClass _windowClass;

    internal bool IsTopMost { get; }


    public ShadowElementPosition Position { get; }
    public WindowShadowDecorator ShadowDecorator { get; }
    public ShadowEffectConfiguration ShadowConfiguration => ShadowDecorator.ShadowElementConfiguration;

    public ShadowElementWindow(ShadowElementPosition elemetPossition, WindowShadowDecorator windowShadowDecorator)
    {
        Position = elemetPossition;
        ShadowDecorator = windowShadowDecorator;

        ParentWND = new SafeHWND(ShadowDecorator.TargetWindow.Handle);

        IsTopMost = ShadowDecorator.TargetWindow.TopMost;


        var className = $"{SHADOW_WND_NAME}_{ShadowDecorator.TargetWindow.Handle}_{Position}";

        _windowClass = new WindowClass(className, HINSTANCE.NULL, WndProc, hbrBkgd: HBRUSH.NULL);

        var exStyles = WindowStylesEx.WS_EX_LAYERED | WindowStylesEx.WS_EX_NOACTIVATE | WindowStylesEx.WS_EX_TRANSPARENT | WindowStylesEx.WS_EX_NOREDIRECTIONBITMAP;

        var styles = WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_POPUP | WindowStyles.WS_CLIPSIBLINGS;

        WND = CreateWindowEx(dwExStyle: exStyles, lpClassName: _windowClass.ClassName, lpWindowName: SHADOW_WND_NAME, dwStyle: styles, X: 0, Y: 0, nWidth: 0, nHeight: 0, hWndParent: HWND.NULL, hMenu: HMENU.NULL, hInstance: HINSTANCE.NULL, lpParam: (nint)0);


    }

    ShadowBitmapState? _bitmapBuff = null;

    public void UpdateBitmap(RECT windowRect, bool isActivated, bool forceRefresh = false)
    {
        var tpl = ShadowDecorator.ShadowElementRender;
        var shadowConfig = ShadowConfiguration;

        if (tpl == null) return;

        var shadowRect = windowRect;
        InflateRect(ref shadowRect, shadowConfig.Size, shadowConfig.Size);

        var elementRect = GetShadowElementRect(windowRect, shadowRect);

        var shouldRedraw = forceRefresh || _bitmapBuff == null || _bitmapBuff.Width != elementRect.Width || _bitmapBuff.Height != elementRect.Height;


        if (shouldRedraw)
        {
            var width = elementRect.Width;
            var height = elementRect.Height;


            var imgInfo = new SKImageInfo()
            {
                AlphaType = SKAlphaType.Premul,
                ColorType = SKColorType.Bgra8888,
                Height = height,
                Width = width
            };

            using var bitmap = new Bitmap(width, height);

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            using var surface = SKSurface.Create(imgInfo, bitmapData.Scan0, bitmapData.Stride);
            using var canvas = surface.Canvas;

            tpl.DrawShadowBitmap(canvas, Position, isActivated);

            bitmap.UnlockBits(bitmapData);


            _bitmapBuff = new ShadowBitmapState(elementRect);

            UpdateLayer(elementRect, bitmap);



            SetWindowPos(WND, ParentWND, _bitmapBuff.X, _bitmapBuff.Y, _bitmapBuff.Width, _bitmapBuff.Height, SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE);

        }
        else if (_bitmapBuff != null)
        {
            _bitmapBuff.UpdateRectangle(elementRect);


            SetWindowPos(WND, ParentWND, _bitmapBuff.X, _bitmapBuff.Y, _bitmapBuff.Width, _bitmapBuff.Height, SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOSIZE);
        }

    }



    private RECT GetShadowElementRect(RECT windowRect, RECT shadowRect)
    {
        var shadowConfig = ShadowConfiguration;

        var insideOffset = shadowConfig.InsideOffset;

        switch (Position)
        {
            case ShadowElementPosition.Top:
                return new RECT(shadowRect.left, shadowRect.top, shadowRect.right, windowRect.top + insideOffset);
            case ShadowElementPosition.Right:
                return new RECT(windowRect.right - insideOffset, windowRect.top, shadowRect.right, windowRect.bottom);
            case ShadowElementPosition.Bottom:
                return new RECT(shadowRect.left, windowRect.bottom - insideOffset, shadowRect.right, shadowRect.bottom);
            case ShadowElementPosition.Left:
                return new RECT(shadowRect.left, windowRect.top, windowRect.left + insideOffset, windowRect.bottom);
        }

        throw new ArgumentOutOfRangeException("position");
    }

    private nint WndProc(HWND hWnd, uint umsg, nint wParam, nint lParam)
    {
        return DefWindowProc(hWnd, umsg, wParam, lParam);
    }



    private void UpdateLayer(RECT rect, Bitmap bitmap)
    {
        var windowRect = rect;

        if (windowRect.Width <= 0 || windowRect.Height <= 0) return;

        var screenDC = GetDC();
        var memDC = CreateCompatibleDC(screenDC);

        var hBitmap = HBITMAP.NULL;

        var hOldBitmap = HBITMAP.NULL;

        try
        {
            hBitmap = new HBITMAP(bitmap.GetHbitmap(Color.FromArgb(0x00, 0x00, 0x00, 0x00)));
            hOldBitmap = SelectObject(memDC, hBitmap);


            var location = new POINT(windowRect.X, windowRect.Y);
            var size = new SIZE(windowRect.Width, windowRect.Height);


            UpdateLayeredWindow(WND, screenDC, location, size, memDC, POINT.Empty, COLORREF.Default, ShadowDecorator.DefaultBlendFunciton, UpdateLayeredWindowFlags.ULW_ALPHA);
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
                ReleaseDC(HWND.NULL, screenDC);
            }

            bitmap.Dispose();

            System.GC.SuppressFinalize(bitmap);

        }




    }


    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]

    static extern nint SetWindowLong32(nint hWnd, int nIndex, nint dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]

    static extern nint SetWindowLong64(nint hWnd, int nIndex, nint dwNewLong);
    internal static nint SetWindowLongPtr(HWND hWnd, WindowLongFlags nIndex, nint dwNewLong)
    {
        if (IntPtr.Size == 8)
        {
            return SetWindowLong64(hWnd.DangerousGetHandle(), (int)nIndex, dwNewLong);
        }
        else
        {
            return SetWindowLong32(hWnd.DangerousGetHandle(), (int)nIndex, dwNewLong);
        }
    }

    public void SetOwner(HWND owner)
    {
        var retval = SetWindowLongPtr(WND, WindowLongFlags.GWL_HWNDPARENT, owner.DangerousGetHandle());
    }

    public void UpdateZOrder()
    {
        if (ParentWND == (nint)0) return;

        SetWindowPos(WND, IsTopMost ? HWND.HWND_TOPMOST : HWND.HWND_NOTOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);

        SetWindowPos(WND, ParentWND, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);
    }

    public void Close()
    {
        SetParent(WND, HWND.NULL);
        CloseWindow(WND);
    }

    private bool _disposed;
    public void Dispose()
    {
        Dispose(true);

        System.GC.SuppressFinalize(this);

    }

    private void Dispose(bool isDisposed)
    {

        if (_disposed)
            return;

        DestroyWindow(WND);

        _disposed = isDisposed;
    }

}
