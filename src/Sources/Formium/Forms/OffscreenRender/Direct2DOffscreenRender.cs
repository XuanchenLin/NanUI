// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using Vortice.Direct2D1;
using Vortice.DXGI;


namespace NetDimension.NanUI.Forms.OffscreenRender;
internal class Direct2DOffscreenRender : IOffscreenRender, IDisposable
{
    const int AcSrcOver = 0x00;
    const int AcSrcAlpha = 0x01;

    public FramelessWindowBase TargetWindow { get; }
    public nint TargetWindowHandle { get; }

    private ID2D1Factory1 _d2d1Factory;
    private ID2D1DCRenderTarget? _renderTarget = null;
    private User32.SafeReleaseHDC? _screenDC;
    private SafeHDC? _memDC;

    private Bitmap? _cacheBmp;
    private HGDIOBJ? _hBitmap;
    private HGDIOBJ? _hOldBitmap;


    public Direct2DOffscreenRender(FramelessWindowBase targetWindow)
    {
        TargetWindow = targetWindow;
        TargetWindowHandle = targetWindow.Handle;

        _d2d1Factory = D2D1.D2D1CreateFactory<ID2D1Factory1>();
    }

    private void CreateRenderTarget(int width, int height)
    {
        if (_renderTarget == null)
        {

            _screenDC = User32.GetDC();
            _memDC = CreateCompatibleDC(_screenDC);

            _cacheBmp = new Bitmap(width, height);

            _hBitmap = _cacheBmp.GetHbitmap(Color.FromArgb(0, 255, 255, 255));

            _hOldBitmap = SelectObject(_memDC, _hBitmap.Value);

            _renderTarget = _d2d1Factory.CreateDCRenderTarget(new RenderTargetProperties
            {
                Type = RenderTargetType.Hardware,
                Usage = RenderTargetUsage.ForceBitmapRemoting,
                PixelFormat = new Vortice.DCommon.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, Vortice.DCommon.AlphaMode.Premultiplied),
                MinLevel = FeatureLevel.Default
            });

            _renderTarget.BindDC(_memDC.DangerousGetHandle(), new Rectangle(0, 0, width, height));
        }
    }

    //private void ResizeRenderTarget(int width, int height)
    //{
    //    if (_renderTarget == null || _memDC == null) return;

    //    if (_hOldBitmap != null)
    //    {
    //        SelectObject(_memDC, _hOldBitmap.Value);
    //        System.GC.SuppressFinalize(_hOldBitmap.Value);

    //    }

    //    if (_hBitmap != null)
    //    {
    //        DeleteObject(_hBitmap.Value);
    //        System.GC.SuppressFinalize(_hBitmap.Value);

    //    }

    //    if (_cacheBmp != null)
    //    {
    //        _cacheBmp.Dispose();
    //        System.GC.SuppressFinalize(_cacheBmp);
    //    }

    //    System.GC.Collect(System.GC.MaxGeneration, GCCollectionMode.Forced);


    //    _screenDC = GetDC();
    //    _memDC = CreateCompatibleDC(_screenDC);


    //    _cacheBmp = new Bitmap(width, height);

    //    _hBitmap = _cacheBmp.GetHbitmap(Color.FromArgb(0, 255, 255, 255));

    //    _hOldBitmap = SelectObject(_memDC, _hBitmap.Value);

    //    _renderTarget.BindDC(_memDC.DangerousGetHandle(), new Rectangle(0, 0, width, height));

    //}


    private void DiscardRenderTarget()
    {
        _renderTarget?.Dispose();
        _renderTarget = null;

        if (_memDC != null && _hOldBitmap != null)
        {
            SelectObject(_memDC, _hOldBitmap.Value);

            System.GC.SuppressFinalize(_hOldBitmap.Value);


            DeleteDC(_memDC);
            _memDC.Close();
            _memDC.Dispose();

        }

        if (_hBitmap != null)
        {
            DeleteObject(_hBitmap.Value);

            System.GC.SuppressFinalize(_hBitmap.Value);
        }

        if (_cacheBmp != null)
        {
            _cacheBmp.Dispose();
            System.GC.SuppressFinalize(_cacheBmp);
        }

        if (_screenDC != null)
        {
            User32.ReleaseDC(HWND.NULL, _screenDC);
            _screenDC.Close();
            _screenDC.Dispose();
        }

        System.GC.Collect(System.GC.MaxGeneration, GCCollectionMode.Forced);


    }


    Size? _lastWindowSize = Size.Empty;
    ID2D1Bitmap? _popupSharedBitmap = null;
    CefRectangle? _popupRect = null;

    //CefSize? _viewSize = null;
    //ID2D1Bitmap? _viewSharedBitmap = null;

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
        //else if (viewSize != _lastWindowSize)
        //{
        //    ResizeRenderTarget(width + 2, height + 2);
        //}

        var dc = _renderTarget!;

        dc.AntialiasMode = AntialiasMode.Aliased;

        dc.BeginDraw();


        if (type == CefPaintElementType.View)
        {
            dc.Clear(new Vortice.Mathematics.Color4(0x00, 0x00, 0x00, 0x00));

            using var bmp = dc.CreateBitmap(new Size(width, height), bufferPtr, width * 4, new BitmapProperties
            {
                PixelFormat = new Vortice.DCommon.PixelFormat
                {
                    AlphaMode = Vortice.DCommon.AlphaMode.Premultiplied,
                    Format = Format.B8G8R8A8_UNorm
                },
            });


            dc.DrawBitmap(bmp, new RectangleF(1, 1, width, height), 1.0f, BitmapInterpolationMode.NearestNeighbor,new RectangleF(0,0,width,height));

            //if (TargetWindow.ShowBorder)
            //{
            //    using var borderBrush = dc.CreateSolidColorBrush(new Vortice.Mathematics.Color(TargetWindow.BorderColor.R, TargetWindow.BorderColor.G, TargetWindow.BorderColor.B, TargetWindow.BorderColor.A));
            //    dc.DrawRectangle(new RectangleF(0, 0, windowSize.Width, windowSize.Height), borderBrush);
            //}


            bmp.Dispose();

        }
        else if (popupRect != null)
        {

            using var bmp = dc.CreateBitmap(new Size(width, height), bufferPtr, width * 4, new BitmapProperties
            {
                PixelFormat = new Vortice.DCommon.PixelFormat
                {
                    AlphaMode = Vortice.DCommon.AlphaMode.Premultiplied,
                    Format = Format.B8G8R8A8_UNorm
                },
            });

            if (_popupSharedBitmap != null)
            {
                _popupSharedBitmap.Dispose();
                _popupSharedBitmap = null;
                _popupRect = null;
            };


            _popupSharedBitmap = dc.CreateSharedBitmap(bmp);

            _popupRect = popupRect;

            bmp.Dispose();
        }

        if (isPopupShown && _popupSharedBitmap != null && _popupRect != null)
        {
            var x = _popupRect.Value.X + 1 * TargetWindow.WindowDpiAdapter.ScaleFactor;
            var y = _popupRect.Value.Y + 1 * TargetWindow.WindowDpiAdapter.ScaleFactor; ;

            var popupWidth = _popupRect.Value.Width;
            var popupHeight = _popupRect.Value.Height;

            dc.DrawBitmap(_popupSharedBitmap, new RectangleF(x, y, popupWidth, popupHeight), 1.0f, BitmapInterpolationMode.Linear, new RectangleF(0, 0, popupWidth, popupHeight));
        }
        else
        {
            _popupSharedBitmap?.Dispose();
            _popupSharedBitmap = null;
            _popupRect = null;

        }


        var hr = dc.EndDraw();

        if (hr.Failure)
        {
            DiscardRenderTarget();
        }

        User32.GetWindowRect(TargetWindowHandle, out var rect);

        var size = new Size(rect.Width, rect.Height);


        var location = rect.Location;

        if (rect.Width == 0 || rect.Height == 0)
            return;

        var blend = new BLENDFUNCTION
        {
            BlendOp = AcSrcOver,
            BlendFlags = 0,
            SourceConstantAlpha = 255,
            AlphaFormat = AcSrcAlpha
        };

        var retval = User32.UpdateLayeredWindow(TargetWindowHandle, _screenDC, location, size, _memDC, Point.Empty, COLORREF.None, blend, User32.UpdateLayeredWindowFlags.ULW_ALPHA);

        if (!retval)
        {
            var err = Kernel32.GetLastError();
        }

        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
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
            _renderTarget?.Dispose();
            _renderTarget = null;

            if (_memDC != null && _hOldBitmap != null)
            {
                SelectObject(_memDC, _hOldBitmap.Value);
                DeleteDC(_memDC);
                _memDC.Close();
            }

            if (_hBitmap != null)
            {
                DeleteObject(_hBitmap.Value);
            }

            if (_cacheBmp != null)
            {
                _cacheBmp.Dispose();
            }

            if (_screenDC != null)
            {
                User32.ReleaseDC(HWND.NULL, _screenDC);
                _screenDC.Close();
            }

            _d2d1Factory?.Dispose();
        }

        _isDisposed = true;
    }


    #endregion
}
