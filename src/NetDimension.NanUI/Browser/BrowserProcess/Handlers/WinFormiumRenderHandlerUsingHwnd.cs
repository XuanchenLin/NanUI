using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vortice.Direct2D1;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumRenderHandlerUsingHwnd : CefRenderHandler
    {

        ID2D1Factory _d2dFactory = null;
        ID2D1HwndRenderTarget _renderTarget = null;

        bool _isPopupShown = false;
        CefRectangle? _popupRect = null;
        private int _view_width;
        private int _view_height;


        private readonly Formium _owner;

        public WinFormiumRenderHandlerUsingHwnd(Formium owner)
        {
            _owner = owner;

            D2D1.D2D1CreateFactory(FactoryType.SingleThreaded, out _d2dFactory);
        }




        public void CreateDeviceResource()
        {
            if (_renderTarget == null)
            {
                var renderProps = new RenderTargetProperties()
                {
                    Type = RenderTargetType.Hardware,
                    Usage = RenderTargetUsage.None,
                    PixelFormat = new PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied),
                    MinLevel = FeatureLevel.Default,
                    DpiX = 96,
                    DpiY = 96
                };

                var hwndRenderTargetProperties = new HwndRenderTargetProperties()
                {
                    Hwnd = _owner.HostWindowHandle,
                    PresentOptions = PresentOptions.RetainContents,
                    PixelSize = new Vortice.Mathematics.Size(_owner.HostWindowInternal.ClientRectangle.Width, _owner.HostWindowInternal.ClientRectangle.Height)
                };

                _renderTarget = _d2dFactory.CreateHwndRenderTarget(renderProps, hwndRenderTargetProperties);
            }
        }

        public void DiscardDeviceResources()
        {
            _renderTarget.Dispose();
            _renderTarget = null;

            GC.Collect();
        }





        protected override CefAccessibilityHandler GetAccessibilityHandler()
        {
            return null;
        }


        //Screen _lastScreen = null;

        protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
        {

            var handle = _owner.HostWindowHandle;

            var screen = Screen.FromHandle(handle);

            screenInfo.DeviceScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(handle);

            GetViewRect(browser, out var rectView);

            screenInfo.Rectangle = rectView;

            screenInfo.AvailableRectangle = rectView;

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


            if (User32.IsIconic(handle)||clientRect.Width ==0 || clientRect.Height == 0)
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

                _renderTarget?.Resize(new Vortice.Mathematics.Size(_view_width, _view_height));
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

        ID2D1Bitmap _cachedPopupImage = null;

        protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
        {

            if (width <= 0 || height <= 0)
            {
                return;
            }

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

            //var layer = _renderTarget.CreateLayer();
            //var layerParameter = new LayerParameters
            //{
            //    ContentBounds = new Vortice.RawRectF(0, 0, width, height),
            //    Opacity = 1
            //};
            //_renderTarget.PushLayer(ref layerParameter, layer);

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

            //_renderTarget.PopLayer();

            //layer.Dispose();

            if (_renderTarget.EndDraw().Failure)
            {
                DiscardDeviceResources();
            }

        }


        protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
        {

        }

        protected override void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
        {
            base.OnTextSelectionChanged(browser, selectedText, selectedRange);
        }

        protected override void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
        {
            base.OnVirtualKeyboardRequested(browser, inputMode);
        }
    }
}
