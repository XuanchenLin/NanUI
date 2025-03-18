// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using SharpGen.Runtime;

using Vortice.Direct2D1;
using Vortice.Direct3D11;
using Vortice.DirectComposition;
using Vortice.DXGI;

using D3D = Vortice.Direct3D;

namespace NetDimension.NanUI.Forms.OffscreenRender;
internal class DirectCompositionOffscreenRender : IOffscreenRender, IDisposable
{
    static readonly D3D.FeatureLevel[] FEATURE_LEVEL_SUPPORTED = new D3D.FeatureLevel[]
    {
            D3D.FeatureLevel.Level_11_1,
            D3D.FeatureLevel.Level_11_0,
            D3D.FeatureLevel.Level_10_1,
            D3D.FeatureLevel.Level_10_0,
            D3D.FeatureLevel.Level_9_3,
            D3D.FeatureLevel.Level_9_2,
            D3D.FeatureLevel.Level_9_1,
    };

    public Form TargetWindow { get; }
    public nint TargetWindowHandle { get; }

    private ID3D11Device? _d3dDevice;

    private IDXGIFactory2 _dxgiFactory;
    private IDXGIDevice _dxgiDevice;

    private ID2D1Factory1 _d2d1Factory;
    private ID2D1Device _d2dDevice;
    private ID2D1DeviceContext? _d2dDeviceContext;

    private IDCompositionDevice _dcompDevice;

    private IDXGISwapChain1? _swapChian;
    private IDXGISurface1? _surface;
    private ID2D1Bitmap1? _textureBitmap;

    private IDCompositionTarget? _target;


    public DirectCompositionOffscreenRender(Form targetForm)
    {
        TargetWindow = targetForm;
        TargetWindowHandle = targetForm.Handle;

        _d3dDevice = CreateD3D11Device();

        if (_d3dDevice == null)
            throw new ArgumentNullException(nameof(_d3dDevice));

        _dxgiDevice = _d3dDevice.QueryInterface<IDXGIDevice>();
        _dxgiFactory = DXGI.CreateDXGIFactory2<IDXGIFactory2>(false);

        _d2d1Factory = D2D1.D2D1CreateFactory<ID2D1Factory1>();
        _d2dDevice = _d2d1Factory.CreateDevice(_dxgiDevice);
        _d2dDeviceContext = _d2dDevice.CreateDeviceContext(DeviceContextOptions.None);

        _dcompDevice = DComp.DCompositionCreateDevice<IDCompositionDevice>(_dxgiDevice);


        _dxgiFactory.MakeWindowAssociation(TargetWindowHandle, WindowAssociationFlags.IgnoreAltEnter);

        var hr = _dcompDevice.CreateTargetForHwnd(TargetWindowHandle, new RawBool(TargetWindow.TopMost), out _target);

        if (hr.Failure)
        {
            hr.CheckError();
        }


    }
    private ID3D11Device? CreateD3D11Device()
    {
        ID3D11Device? d3dDevice;

        var hr = D3D11.D3D11CreateDevice(null, D3D.DriverType.Hardware, DeviceCreationFlags.BgraSupport, FEATURE_LEVEL_SUPPORTED, out d3dDevice);

        if (hr.Failure)
        {
            hr = D3D11.D3D11CreateDevice(null, D3D.DriverType.Warp, DeviceCreationFlags.BgraSupport, FEATURE_LEVEL_SUPPORTED, out d3dDevice);
        }

        if (hr.Failure)
        {
            hr.CheckError();
            return null;
        }

        return d3dDevice;
    }

    private void CreateSwapChianTarget(int width, int height)
    {
        _swapChian = _dxgiFactory.CreateSwapChainForComposition(_dxgiDevice, new SwapChainDescription1
        {
            Format = Format.B8G8R8A8_UNorm,
            BufferUsage = Usage.RenderTargetOutput,
            SwapEffect = SwapEffect.FlipSequential,
            BufferCount = 2,
            SampleDescription = new SampleDescription
            {
                Count = 1,
            },
            AlphaMode = AlphaMode.Premultiplied,
            Scaling = Scaling.Stretch, 
            Width = width,
            Height = height,
        });

        _surface = _swapChian?.GetBuffer<IDXGISurface1>(0);
        _textureBitmap = _d2dDeviceContext!.CreateBitmapFromDxgiSurface(_surface, new BitmapProperties1
        {
            BitmapOptions = BitmapOptions.Target | BitmapOptions.CannotDraw,
            PixelFormat = new Vortice.DCommon.PixelFormat
            {
                AlphaMode = Vortice.DCommon.AlphaMode.Premultiplied,
                Format = Format.B8G8R8A8_UNorm
            },
        });

        _dxgiFactory.MakeWindowAssociation(TargetWindowHandle, WindowAssociationFlags.IgnoreAll);

    }

    private void DiscardSwapChainTarget()
    {
        _textureBitmap?.Dispose();
        _surface?.Dispose();
        _swapChian?.Dispose();

        _textureBitmap = null;
        _surface = null;
        _swapChian = null;

        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
    }

    private void ResizeTarget(int width, int height)
    {


        if (_d2dDeviceContext == null || _swapChian == null) return;

        _d2dDeviceContext.Target = null;

        _textureBitmap?.Dispose();
        _surface?.Dispose();
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

        var hr = _swapChian!.ResizeBuffers(0, width, height);


        if (hr.Failure)
        {
            hr.CheckError();
        }
        else
        {
            _surface = _swapChian?.GetBuffer<IDXGISurface1>(0);
            _textureBitmap = _d2dDeviceContext!.CreateBitmapFromDxgiSurface(_surface, new BitmapProperties1
            {
                BitmapOptions = BitmapOptions.Target | BitmapOptions.CannotDraw,
                PixelFormat = new Vortice.DCommon.PixelFormat
                {
                    AlphaMode = Vortice.DCommon.AlphaMode.Premultiplied,
                    Format = Format.B8G8R8A8_UNorm
                },
            });
        }


        //DiscardSwapChainTarget();

        //CreateSwapChianTarget(new Size(width, height));

        //RenderTarget();

    }


    Size _lastWindowSize = Size.Empty;
    ID2D1Bitmap? _popupSharedBitmap = null;
    CefRectangle? _popupRect = null;

    //CefSize? _viewSize = null;
    //ID2D1Bitmap? _viewSharedBitmap = null;

    void IOffscreenRender.Paint(CefPaintElementType type, nint bufferPtr, int width, int height, bool isPopupShown, CefRectangle? popupRect)
    {
        if (width <= 0 || height <= 0) return;

        if (type == CefPaintElementType.Popup && _swapChian == null) return;

        //User32.GetClientRect(TargetWindowHandle, out var windowRect);

        //var winWidth = windowRect.Width;
        //var winHeight = windowRect.Height;

        if (type == CefPaintElementType.View)
        {

            var viewSize = new Size(width, height);

            if (_swapChian == null)
            {
                CreateSwapChianTarget(width, height);
            }
            else if (viewSize != _lastWindowSize)
            {
                ResizeTarget(width, height);
            }

            _lastWindowSize = viewSize;
        }


        var dc = _d2dDeviceContext!;

        dc.AntialiasMode = AntialiasMode.Aliased;
        dc.UnitMode = UnitMode.Pixels;

        dc.Target = _textureBitmap;

        // draw begin

        dc.BeginDraw();


        if (type == CefPaintElementType.View)
        {
            dc.Clear(new Vortice.Mathematics.Color4(0, 0, 0, 0));

            using var bmp = dc.CreateBitmap(new Size(width, height), bufferPtr, width * 4, new BitmapProperties
            {
                PixelFormat = new Vortice.DCommon.PixelFormat
                {
                    AlphaMode = Vortice.DCommon.AlphaMode.Premultiplied,
                    Format = Format.B8G8R8A8_UNorm
                },
            });

            //if (_viewSharedBitmap != null)
            //{
            //    _viewSharedBitmap.Dispose();
            //    _viewSharedBitmap = null;
            //    _viewSize = null;
            //};

            //_viewSharedBitmap = dc.CreateSharedBitmap(bmp);
            //_viewSize = new CefSize(width, height);
            dc.DrawBitmap(bmp);


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

        //if (_viewSharedBitmap != null && _viewSize != null)
        //{
        //    dc.DrawBitmap(_viewSharedBitmap, new RectangleF(0, 0, _viewSize.Value.Width, _viewSize.Value.Height), 1.0f, Vortice.Direct2D1.BitmapInterpolationMode.Linear, new RectangleF(0, 0, _viewSize.Value.Width, _viewSize.Value.Height));

        //    if (!isPopupShown)
        //    {
        //        _viewSharedBitmap.Dispose();
        //        _viewSharedBitmap = null;
        //        _viewSize = null;
        //    }
        //}



        if (isPopupShown && _popupSharedBitmap != null && _popupRect != null)
        {
            var x = _popupRect.Value.X;
            var y = _popupRect.Value.Y;

            var popupWidth = _popupRect.Value.Width;
            var popupHeight = _popupRect.Value.Height;

            dc.DrawBitmap(_popupSharedBitmap, new RectangleF(x, y, popupWidth, popupHeight), 1.0f, Vortice.Direct2D1.BitmapInterpolationMode.Linear, new RectangleF(0, 0, popupWidth, popupHeight));


        }
        else
        {
            _popupSharedBitmap?.Dispose();
            _popupSharedBitmap = null;
            _popupRect = null;
        }

        //var splashImage = ShouldDrawSpalsh?.Invoke();

        //if (splashImage != null)
        //{

        //}


        dc.EndDraw();
        // draw end

        var hr = _swapChian!.Present(1, PresentFlags.None);

        using var _visual = _dcompDevice.CreateVisual();

        _visual.SetContent(_swapChian);

        _target!.SetRoot(_visual);

        if (hr.Failure)
        {
            DiscardSwapChainTarget();
        }

        _dcompDevice.Commit();

        GC.Collect(System.GC.MaxGeneration, GCCollectionMode.Forced);

    }

    #region IDispose
    bool _isDisposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            // release unmanaged resources
            _target?.Dispose();
            _dcompDevice?.Dispose();
            _d2dDeviceContext?.Dispose();
            _d2dDevice?.Dispose();
            _d2d1Factory?.Dispose();
            _dxgiDevice?.Dispose();
            _dxgiFactory?.Dispose();
            _d3dDevice?.Dispose();

        }

        _isDisposed = true;
    }
    #endregion
}
