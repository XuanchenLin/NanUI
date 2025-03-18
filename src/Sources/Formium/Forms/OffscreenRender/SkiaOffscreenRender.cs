// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms.OffscreenRender;
internal class SkiaOffscreenRender : IOffscreenRender, IDisposable
{
    const int AcSrcOver = 0x00;
    const int AcSrcAlpha = 0x01;

    public FramelessWindowBase TargetWindow { get; }
    public nint TargetWindowHandle { get; }
    public Func<Bitmap?>? ShouldDrawSpalsh { get; set; }

    public SkiaOffscreenRender(FramelessWindowBase targetWindow)
    {
        TargetWindow = targetWindow;
        TargetWindowHandle = targetWindow.Handle;
    }

    Size? _lastWindowSize = Size.Empty;

    SKBitmap? _renderTarget;

    SKBitmap? _popupSharedBitmap = null;
    CefRectangle? _popupRect = null;


    void IOffscreenRender.Paint(CefPaintElementType type, nint bufferPtr, int width, int height, bool isPopupShown, CefRectangle? popupRect)
    {
        if (width <= 0 || height <= 0) return;

        if (type == CefPaintElementType.Popup && _renderTarget == null) return;

        if (type == CefPaintElementType.View)
        {
            var currentWinSize = new Size(width + 2, height + 2);

            if (_lastWindowSize != currentWinSize)
            {
                DiscardRenderTarget();
                _lastWindowSize = currentWinSize;
            }
        }

        if (_lastWindowSize == null || _lastWindowSize == Size.Empty) return;

        var windowSize = _lastWindowSize.Value;

        if (_renderTarget == null)
        {
            CreateRenderTarget(windowSize.Width, windowSize.Height);
        }

        using var dc = new SKCanvas(_renderTarget);


        if (type == CefPaintElementType.View)
        {
            dc.Clear(new SKColor(0, 0, 0, 0));

            using var bmp = new SKBitmap();
            bmp.InstallPixels(new SKImageInfo
            {
                AlphaType = SKAlphaType.Premul,
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888
            }, bufferPtr);


            //if (TargetWindow.ShowBorder)
            //{
            //    dc.DrawRect(new SKRect(0, 0, windowSize.Width, windowSize.Height), new SKPaint
            //    {
            //        Color = new SKColor(TargetWindow.BorderColor.R, TargetWindow.BorderColor.G, TargetWindow.BorderColor.B, TargetWindow.BorderColor.A),
            //    });
            //}


            dc.DrawBitmap(bmp, new SKRect(1, 1, width + 1, height + 1));

            bmp.Dispose();
        }
        else if (popupRect != null)
        {
            using var bmp = new SKBitmap();
            bmp.InstallPixels(new SKImageInfo
            {
                AlphaType = SKAlphaType.Premul,
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888
            }, bufferPtr);

            if (_popupSharedBitmap != null)
            {
                _popupSharedBitmap.Dispose();
                _popupSharedBitmap = null;
                _popupRect = null;
            };

            _popupSharedBitmap = bmp.Copy();

            _popupRect = popupRect;

            bmp.Dispose();
        }

        if (isPopupShown && _popupSharedBitmap != null && _popupRect != null)
        {
            var x = _popupRect.Value.X + 1 * TargetWindow.WindowDpiAdapter.ScaleFactor;
            var y = _popupRect.Value.Y + 1 * TargetWindow.WindowDpiAdapter.ScaleFactor;

            var popupWidth = _popupRect.Value.Width;
            var popupHeight = _popupRect.Value.Height;

            dc.DrawBitmap(_popupSharedBitmap, x, y);
        }
        else
        {
            _popupSharedBitmap?.Dispose();
            _popupSharedBitmap = null;
            _popupRect = null;
        }

        dc.Flush();

        dc.Dispose();

        User32.GetWindowRect(TargetWindowHandle, out var rect);

        var size = new Size(rect.Width, rect.Height);

        var location = rect.Location;

        var blend = new BLENDFUNCTION
        {
            BlendOp = AcSrcOver,
            BlendFlags = 0,
            SourceConstantAlpha = 255,
            AlphaFormat = AcSrcAlpha
        };

        using var screenDC = User32.GetDC();
        using var memDC = CreateCompatibleDC(screenDC);

        using var bitmap = new Bitmap(_renderTarget!.Width, _renderTarget!.Height, _renderTarget!.Width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, _renderTarget!.GetPixels());
        var hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
        var hOldBitmap = SelectObject(memDC, hBitmap);

        User32.UpdateLayeredWindow(TargetWindowHandle, screenDC, location, size, memDC, Point.Empty, COLORREF.None, blend, User32.UpdateLayeredWindowFlags.ULW_ALPHA);

        SelectObject(memDC, hOldBitmap);
        DeleteDC(memDC);
        memDC.Close();
        memDC.Dispose();

        DeleteObject(hBitmap);
        bitmap.Dispose();

        User32.ReleaseDC(HWND.NULL, screenDC);
        screenDC.Close();
        screenDC.Dispose();

        GC.Collect(System.GC.MaxGeneration, GCCollectionMode.Forced);


    }

    private void DiscardRenderTarget()
    {
        _renderTarget?.Dispose();
        _renderTarget = null;


    }

    private void CreateRenderTarget(int width, int height)
    {
        if (_renderTarget == null)
        {
            _renderTarget = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Premul);
        }
    }

    #region IDispose
    bool _isDisposed = false;

    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            // release unmanaged resources
        }

        _isDisposed = true;
    }


    #endregion
}
