using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vortice;
using Vortice.Direct2D1;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
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
        private IntPtr _screenDC;
        private IntPtr _memDC;
        private Bitmap _cacheBmp;
        private IntPtr _hBitmap;
        private IntPtr _hOldBitmap;
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

                _screenDC = User32.GetDC(IntPtr.Zero);
                _memDC = Gdi32.CreateCompatibleDC(_screenDC);

                _cacheBmp = new Bitmap(_view_width, _view_height);

                _hBitmap = _cacheBmp.GetHbitmap(Color.FromArgb(0, 0, 0, 0));
                _hOldBitmap = Gdi32.SelectObject(_memDC, _hBitmap);



                var renderProps = new RenderTargetProperties()
                {
                    Type = RenderTargetType.Hardware,
                    Usage = RenderTargetUsage.ForceBitmapRemoting,
                    PixelFormat = new Vortice.Direct2D1.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied),
                    MinLevel = FeatureLevel.Default,
                    DpiX = 96,
                    DpiY = 96
                };

                _renderTarget = _d2dFactory.CreateDCRenderTarget(renderProps);

                _renderTarget.BindDC(_memDC, new Vortice.RawRect(0, 0, _view_width, _view_height));
            }


        }

        public void DiscardDeviceResources()
        {

            _renderTarget?.Dispose();
            _renderTarget = null;

            if (_memDC != IntPtr.Zero && _hBitmap != IntPtr.Zero && _hOldBitmap != IntPtr.Zero)
            {
                Gdi32.SelectObject(_memDC, _hOldBitmap);
                Gdi32.DeleteObject(_hBitmap);
            }

            if (_memDC != IntPtr.Zero)
            {
                Gdi32.DeleteDC(_memDC);
            }

            if (_screenDC != IntPtr.Zero)
            {
                User32.ReleaseDC(IntPtr.Zero, _screenDC);
            }

            _hOldBitmap = IntPtr.Zero;
            _hBitmap = IntPtr.Zero;
            _memDC = IntPtr.Zero;
            _screenDC = IntPtr.Zero;

            GC.Collect();

        }





        protected override CefAccessibilityHandler GetAccessibilityHandler()
        {
            return null;
        }

        protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
        {
            var handle = _owner.HostWindowHandle;

            var screen = Screen.FromHandle(handle);

            screenInfo.DeviceScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(handle);

            GetViewRect(browser, out var rectView);

            screenInfo.Rectangle = rectView;

            screenInfo.AvailableRectangle = rectView;//new CefRectangle(screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Width, screen.WorkingArea.Height);

            return true;
        }



        protected override void GetViewRect(CefBrowser browser, out CefRectangle rect)
        {
            var handle = _owner.HostWindowHandle;

            var scaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(handle);


            var clientRect = new RECT();
            rect = new CefRectangle();


            User32.GetClientRect(handle, ref clientRect);

            rect.X = rect.Y = 0;


            if (User32.IsIconic(handle) || clientRect.Width == 0 || clientRect.Height == 0)
            {
                var placement = new WINDOWPLACEMENT();

                User32.GetWindowPlacement(_owner.HostWindowHandle, ref placement);

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

            var scaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(_owner.HostWindowHandle);


            var pt = new POINT((int)(viewX * scaleFactor), (int)(viewY * scaleFactor));

            User32.ClientToScreen(_owner.HostWindowHandle, ref pt);

            screenX = pt.x;
            screenY = pt.y;

            return true;
        }


        protected override void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr sharedHandle)
        {

        }

        protected override void OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
        {
            _owner.InvokeIfRequired(() => _owner.HostWindowInternal.Cursor = new Cursor(cursorHandle));

        }

        protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
        {

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
                    GC.Collect();
                }
            }

            base.OnPopupShow(browser, show);
        }


        protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
        {
            _popupRect = rect;
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

                var bmp = _renderTarget.CreateBitmap(new Vortice.Mathematics.Size(width, height), buffer, width * 4, new BitmapProperties(new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)));

                if (!_isPopupShown)
                {
                    _renderTarget.Clear(Color.Transparent);
                }

                _renderTarget.DrawBitmap(bmp);

                bmp.Dispose();
            }
            else if (type == CefPaintElementType.Popup)
            {
                var bmp = _renderTarget.CreateBitmap(new Vortice.Mathematics.Size(width, height), buffer, width * 4, new BitmapProperties(new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)));

                if (_cachedPopupImage != null)
                {
                    _cachedPopupImage.Dispose();
                    _cachedPopupImage = null;
                    GC.Collect();
                }

                _cachedPopupImage = _renderTarget.CreateSharedBitmap(bmp, new BitmapProperties
                {
                    PixelFormat = new Vortice.Direct2D1.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)
                });

                bmp.Dispose();
            }

            if (_cachedPopupImage != null && _isPopupShown && _popupRect.HasValue)
            {
                var scaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(_owner.HostWindowHandle);
                var x = _popupRect.Value.X * scaleFactor;
                var y = _popupRect.Value.Y * scaleFactor;

                var popupWidth = _popupRect.Value.Width * scaleFactor;
                var popupHeight = _popupRect.Value.Height * scaleFactor;

                var right = x + popupWidth;
                var bottom = y + popupHeight;

                _renderTarget.DrawBitmap(_cachedPopupImage, new Vortice.RawRectF(x, y, right, bottom), 1f, BitmapInterpolationMode.Linear, new Vortice.RawRectF(0, 0, popupWidth, popupHeight));
            }

            if (_renderTarget.EndDraw().Failure)
            {
                DiscardDeviceResources();
            }

            unsafe
            {
                var rect = new RECT();
                User32.GetWindowRect(handle, ref rect);

                var newLocation = new POINT(rect.left, rect.top);
                var newSize = new SIZE(rect.Width, rect.Height);
                var zeroPoint = new POINT(0, 0);

                if (rect.Width == 0 || rect.Height == 0)
                    return;

                var blend = new BLENDFUNCTION
                {
                    BlendOp = AcSrcOver,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = AcSrcAlpha
                };

                var ulwi = new UPDATELAYEREDWINDOWINFO
                {
                    cbSize = Marshal.SizeOf(typeof(UPDATELAYEREDWINDOWINFO)),
                    hdcDst = _screenDC,
                    pptDst = &newLocation,
                    psize = &newSize,
                    hdcSrc = _memDC,
                    pptSrc = &zeroPoint,
                    //crKey = new COLORREF(0),
                    pblend = &blend,
                    dwFlags = BlendFlags.ULW_ALPHA,
                    prcDirty = null

                };

                User32.UpdateLayeredWindowIndirect(_owner.HostWindowHandle, ref ulwi);
            }

            GC.Collect();
        }



        protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
        {
            
        }

        protected override void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
        {
            base.OnTextSelectionChanged(browser, selectedText, selectedRange);
        }


    }
}
