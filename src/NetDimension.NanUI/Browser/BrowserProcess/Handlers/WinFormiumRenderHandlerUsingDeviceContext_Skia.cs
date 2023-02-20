using System.Drawing;

using SkiaSharp;

using Vanara.PInvoke;

using Xilium.CefGlue;

using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.Browser;

internal class WinFormiumRenderHandlerUsingDeviceContext : CefRenderHandler
{
    private readonly Formium _owner;

    bool _isPopupShown = false;
    CefRectangle? _popupRect = null;


    private int _view_width;
    private int _view_height;



    public WinFormiumRenderHandlerUsingDeviceContext(Formium owner)
    {
        _owner = owner;
    }


    protected override CefAccessibilityHandler GetAccessibilityHandler()
    {
        return null;
    }

    protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
    {
        var handle = _owner.HostWindowHandle;

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

            rect.Width = (int)(Math.Ceiling( clientRect.Width / scaleFactor));

            rect.Height = (int)(Math.Ceiling(clientRect.Height / scaleFactor));

        }
        else
        {
            rect.Width = (int)(Math.Ceiling(clientRect.Width / scaleFactor));
            rect.Height = (int)(Math.Ceiling(clientRect.Height / scaleFactor));
        }



        if (clientRect.Width != _view_width || clientRect.Height != _view_height)
        {
            _view_width = clientRect.Width;
            _view_height = clientRect.Height;

            //DiscardDeviceResources();
        }
    }

    protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
    {
        return false;
    }


    protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
    {

        var scaleFactor = DpiHelper.GetScaleFactorForWindow(_owner.HostWindowHandle);


        var pt = new POINT((int)(Math.Ceiling(viewX * scaleFactor)), (int)(Math.Ceiling(viewY * scaleFactor)));

        ClientToScreen(_owner.HostWindowHandle, ref pt);

        screenX = pt.X;
        screenY = pt.Y;

        return true;
    }


    protected override void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, nint sharedHandle)
    {
        throw new NotImplementedException();
    }

    protected override void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
    {
        if (_owner.FormHostWindow is HostWindow.LayeredStyleHostWindow)
        {
            var win = (HostWindow.LayeredStyleHostWindow)_owner.FormHostWindow;

            win.InvokeIfRequired(() => {
                if (inputMode == CefTextInputMode.None)
                {
                    win.ImeMode = ImeMode.Disable;
                }
                else
                {
                    win.ImeMode = ImeMode.On;
                }
            });



        }
    }


    protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
    {
        if (_owner.FormHostWindow is HostWindow.LayeredStyleHostWindow)
        {
            var win = (HostWindow.LayeredStyleHostWindow)_owner.FormHostWindow;

            win.InvokeIfRequired(() =>
            {
                win.ChangeCompositionRange(selectedRange, characterBounds);

            });

        }
    }


    protected override void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
    {
        base.OnTextSelectionChanged(browser, selectedText, selectedRange);
    }


    protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
    {
        var scaleFactor = DpiHelper.GetScaleFactorForWindow(_owner.HostWindowHandle);

        _popupRect = new CefRectangle {
            X = (int)(Math.Ceiling( rect.X * scaleFactor)),
            Y = (int)(Math.Ceiling(rect.Y * scaleFactor)),
            Width = (int)(Math.Ceiling(rect.Width * scaleFactor)),
            Height = (int)(Math.Ceiling(rect.Height * scaleFactor))
        };

        System.Diagnostics.Debug.WriteLine($"PopupRect:{rect.Width}x{rect.Height}");
        System.Diagnostics.Debug.WriteLine($"ScaledPopupRect:{_popupRect.Value.Width}x{_popupRect.Value.Height}");
    }

    protected override void OnPopupShow(CefBrowser browser, bool show)
    {
        _isPopupShown = show;

        if (show == false)
        {
            _popupRect = null;

            if (_popupBitmapData != null)
            {
                _popupBitmapData = null;
            }
        }

        System.Diagnostics.Debug.WriteLine($"PopupShow");


        base.OnPopupShow(browser, show);
    }

    byte[] _popupBitmapData= null;
    byte[] _viewBitmapData = null;

    Size _viewSize = Size.Empty;


    protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
    {


        if (width <= 0 || height <= 0)
        {
            return;
        }

        var handle = _owner.HostWindowHandle;




        if (type == CefPaintElementType.Popup)
        {
            unsafe
            {
                var stride = width * height * 4;
                using var ms = new UnmanagedMemoryStream((byte*)buffer.ToPointer(), stride);

                _popupBitmapData = new byte[stride];

                ms.Read(_popupBitmapData, 0, stride);

                ms.Close();

                System.Diagnostics.Debug.WriteLine($"RequestPopupSize:{width}x{height}");
            }


        }
        else if (type == CefPaintElementType.View)
        {
            unsafe
            {

                if (_viewBitmapData != null)
                {
                    _viewBitmapData = null;
                }

                _viewSize= new Size(width,height);

                var stride = width * height * 4;
                using var ms = new UnmanagedMemoryStream((byte*)buffer.ToPointer(), stride);

                _viewBitmapData = new byte[stride];

                ms.Read(_viewBitmapData, 0, stride);

                ms.Close();


            }
        }

        if (_viewSize == Size.Empty || _viewBitmapData == null || _view_width ==0 || _view_height==0) return;





        using var sharedBmp = new Bitmap(_view_width, _view_height);

        var bitmapData = sharedBmp.LockBits(new Rectangle(0, 0, _view_width, _view_height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

        using var surface = SKSurface.Create(new SKImageInfo
        {
            AlphaType = SKAlphaType.Premul,
            Width = _view_width,
            Height = _view_height,
            ColorType = SKColorType.Bgra8888,
        }, bitmapData.Scan0, bitmapData.Stride);

        using var canvas = surface.Canvas;

        canvas.Clear(SKColors.Transparent);

        //draw view

        using var viewBitmap = new SKBitmap();
        using var viewBmpData = SKData.CreateCopy(_viewBitmapData);

        viewBitmap.InstallPixels(new SKImageInfo
        {
            AlphaType = SKAlphaType.Premul,
            Width = _viewSize.Width,
            Height = _viewSize.Height,
            ColorType = SKColorType.Bgra8888
        }, viewBmpData.Data);

        canvas.DrawBitmap(viewBitmap, 0, 0);


        // draw popup
        if (_popupBitmapData != null && _isPopupShown && _popupRect.HasValue)
        {
            System.Diagnostics.Debug.WriteLine($"SHOWN:{_isPopupShown} POPUP:{_popupRect.Value.Width}x{_popupRect.Value.Height} DATA:{_popupBitmapData != null}");

            using var popupBitmap = new SKBitmap();
            using var popupBmpdata = SKData.CreateCopy(_popupBitmapData);

            popupBitmap.InstallPixels(new SKImageInfo
            {
                AlphaType = SKAlphaType.Premul,
                ColorType = SKColorType.Bgra8888,
                Width = _popupRect.Value.Width,
                Height = _popupRect.Value.Height,

            }, popupBmpdata.Data);

            canvas.DrawBitmap(popupBitmap, _popupRect.Value.X, _popupRect.Value.Y);
        }


        sharedBmp.UnlockBits(bitmapData);


        var screenDC = GetDC(HWND.NULL);
        var memDC = CreateCompatibleDC(screenDC);

        var hBITMAP = new HBITMAP(sharedBmp.GetHbitmap(Color.FromArgb(0, 0, 0, 0)));
        var hOldBitmap = SelectObject(memDC, hBITMAP);
        try
        {
            GetWindowRect(handle, out var rect);

            var size = rect.Size;
            var location = rect.Location;


            if (rect.Width == 0 || rect.Height == 0)
                return;

            const int AcSrcOver = 0x00;
            const int AcSrcAlpha = 0x01;

            var blend = new BLENDFUNCTION
            {
                BlendOp = AcSrcOver,
                BlendFlags = 0,
                SourceConstantAlpha = 255,
                AlphaFormat = AcSrcAlpha
            };




            UpdateLayeredWindow(_owner.HostWindowHandle, screenDC, location, size, memDC, Point.Empty, COLORREF.None, blend, UpdateLayeredWindowFlags.ULW_ALPHA);


        }
        finally
        {
            if (hBITMAP != HBITMAP.NULL)
            {
                SelectObject(memDC, hOldBitmap);
                DeleteObject(hBITMAP);
            }

            if (memDC != HDC.NULL)
            {
                DeleteDC(memDC);
            }

            if (screenDC != HDC.NULL)
            {
                ReleaseDC(IntPtr.Zero, screenDC);
            }

            sharedBmp.Dispose();

        }

        viewBitmap?.Dispose();





    }




    protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
    {
    }
}

