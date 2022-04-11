using Vanara.PInvoke;
using Vortice;
using Vortice.DCommon;
using Vortice.Direct2D1;
using Vortice.Mathematics;

using Xilium.CefGlue;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.Browser;

internal sealed class WinFormiumRenderHandlerUsingDeviceContext : CefRenderHandler
{
    private readonly Formium _owner;

    ID2D1Factory _d2dFactory = null;
    ID2D1DCRenderTarget _renderTarget = null;
    const int AcSrcOver = 0x00;
    const int AcSrcAlpha = 0x01;

    bool _isPopupShown = false;
    CefRectangle? _popupRect = null;


    private int _view_width;
    private int _view_height;
    private SafeHDC _screenDC;
    private SafeHDC _memDC;
    private Bitmap _cacheBmp;
    private HGDIOBJ _hBitmap;
    private HGDIOBJ _hOldBitmap;
    private ID2D1Bitmap _cachedPopupImage;

    public WinFormiumRenderHandlerUsingDeviceContext(Formium owner)
    {
        _owner = owner;

        D2D1.D2D1CreateFactory(FactoryType.SingleThreaded, out _d2dFactory);

    }

    public void CreateDeviceResource()
    {

        if (_renderTarget == null)
        {

            _screenDC = GetDC(HWND.NULL);
            _memDC = CreateCompatibleDC(_screenDC);

            _cacheBmp = new Bitmap(_view_width, _view_height);

            _hBitmap = _cacheBmp.GetHbitmap(System.Drawing.Color.FromArgb(0, 255, 255, 255));

            _hOldBitmap = SelectObject(_memDC, _hBitmap);

            var renderProps = new RenderTargetProperties()
            {
                Type = RenderTargetType.Hardware,
                Usage = RenderTargetUsage.ForceBitmapRemoting,
                PixelFormat = new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied),
                MinLevel = FeatureLevel.Default,
                DpiX = 96,
                DpiY = 96
            };

            _renderTarget = _d2dFactory.CreateDCRenderTarget(renderProps);

            _renderTarget.BindDC(_memDC.DangerousGetHandle(), new RawRect(0, 0, _view_width, _view_height));
        }


    }

    public void DiscardDeviceResources()
    {

        _renderTarget?.Dispose();
        _renderTarget = null;

        if (_memDC != null && !_hBitmap.IsNull && !_hOldBitmap.IsNull)
        {
            SelectObject(_memDC, _hOldBitmap);
            DeleteObject(_hBitmap);
        }

        if (_memDC != null)
        {
            DeleteDC(_memDC);
            _memDC.Close();
        }

        if (_screenDC != null)
        {
            ReleaseDC(HWND.NULL, _screenDC);
            _screenDC.Close();

        }



        System.GC.Collect();

    }





    protected override CefAccessibilityHandler GetAccessibilityHandler()
    {
        return null;
    }

    protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
    {
        var handle = _owner.HostWindowHandle;

        //var screen = Screen.FromHandle(handle);

        screenInfo.DeviceScaleFactor = DpiHelper.GetScaleFactorForWindow(handle);

        GetViewRect(browser, out var rectView);

        screenInfo.Rectangle = rectView;

        screenInfo.AvailableRectangle = rectView;//new CefRectangle(screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Width, screen.WorkingArea.Height);

        return true;
    }



    protected override void GetViewRect(CefBrowser browser, out CefRectangle rect)
    {
        var handle = _owner.HostWindowHandle;

        var scaleFactor = DpiHelper.GetScaleFactorForWindow(handle);


        rect = new CefRectangle();

        GetClientRect(handle, out var clientRect);

        rect.X = rect.Y = 0;


        if (IsIconic(handle) || clientRect.Width == 0 || clientRect.Height == 0)
        {
            var placement = new WINDOWPLACEMENT();

            GetWindowPlacement(_owner.HostWindowHandle, ref placement);

            clientRect = placement.rcNormalPosition;

            rect.Width = (int)(clientRect.Width / scaleFactor);

            rect.Height = (int)(clientRect.Height / scaleFactor);

        }
        else
        {
            rect.Width = (int)(clientRect.Width / scaleFactor);
            rect.Height = (int)(clientRect.Height / scaleFactor);
        }



        if (clientRect.Width != _view_width || clientRect.Height != _view_height)
        {
            _view_width = clientRect.Width;
            _view_height = clientRect.Height;

            DiscardDeviceResources();
        }
    }

    protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
    {
        return false;
    }

    protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
    {

        var scaleFactor = DpiHelper.GetScaleFactorForWindow(_owner.HostWindowHandle);


        var pt = new POINT((int)(viewX * scaleFactor), (int)(viewY * scaleFactor));

        ClientToScreen(_owner.HostWindowHandle, ref pt);

        screenX = pt.X;
        screenY = pt.Y;

        return true;
    }




    protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
    {
        if (_owner.FormHostWindow is HostWindow.LayeredStyleHostWindow)
        {
            var win = (HostWindow.LayeredStyleHostWindow)_owner.FormHostWindow;

            win.ChangeCompositionRange(selectedRange, characterBounds);
        }
    }


    protected override void OnPopupShow(CefBrowser browser, bool show)
    {
        _isPopupShown = show;

        if (show == false)
        {
            _popupRect = null;
            if (_cachedPopupImage != null)
            {
                _cachedPopupImage.Dispose();
                _cachedPopupImage = null;
                System.GC.Collect();
            }
        }

        base.OnPopupShow(browser, show);
    }


    protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
    {
        _popupRect = rect;
    }

    protected override void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr sharedHandle)
    {

    }


    protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            return;
        }

        var handle = _owner.HostWindowHandle;


        CreateDeviceResource();

        _renderTarget.BeginDraw();


        if (type == CefPaintElementType.View)
        {

            var bmp = _renderTarget.CreateBitmap(new SizeI(width, height), buffer, width * 4, new BitmapProperties(new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)));

            if (!_isPopupShown)
            {
                _renderTarget.Clear(new ColorBgra(0));
            }

            _renderTarget.DrawBitmap(bmp);

            bmp.Dispose();
        }
        else if (type == CefPaintElementType.Popup)
        {
            var bmp = _renderTarget.CreateBitmap(new SizeI(width, height), buffer, width * 4, new BitmapProperties(new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)));

            if (_cachedPopupImage != null)
            {
                _cachedPopupImage.Dispose();
                _cachedPopupImage = null;
                //System.GC.Collect();
            }

            _cachedPopupImage = _renderTarget.CreateSharedBitmap(bmp, new BitmapProperties
            {
                PixelFormat = new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)
            });

            bmp.Dispose();
        }

        if (_cachedPopupImage != null && _isPopupShown && _popupRect.HasValue)
        {
            var scaleFactor = DpiHelper.GetScaleFactorForWindow(_owner.HostWindowHandle);
            var x = _popupRect.Value.X * scaleFactor;
            var y = _popupRect.Value.Y * scaleFactor;

            var popupWidth = _popupRect.Value.Width * scaleFactor;
            var popupHeight = _popupRect.Value.Height * scaleFactor;

            var right = x + popupWidth;
            var bottom = y + popupHeight;

            _renderTarget.DrawBitmap(_cachedPopupImage, new Vortice.RawRectF(x, y, right, bottom), 1f, BitmapInterpolationMode.Linear, new Vortice.RawRectF(0, 0, popupWidth, popupHeight));
        }


        var d2dRetval = _renderTarget.EndDraw();

        if (d2dRetval.Failure)
        {
            DiscardDeviceResources();
        }


        GetWindowRect(handle, out var rect);

        var size = rect.Size;
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

        UpdateLayeredWindow(_owner.HostWindowHandle, _screenDC, location, size, _memDC, Point.Empty, COLORREF.None, blend, UpdateLayeredWindowFlags.ULW_ALPHA);




        //System.GC.Collect();
    }



    protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
    {

    }

    protected override void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
    {
        base.OnTextSelectionChanged(browser, selectedText, selectedRange);
    }


}
