using SkiaSharp;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;


namespace NetDimension.NanUI.HostWindow;

using Vortice;
using Vortice.Direct2D1;
using Vortice.Mathematics;

internal class WindowDropShadow : IDisposable
{

    const string SHADOW_WND_NAME = "NanUIDropShadowWnd";

    private GCHandle _gcHandle;
    private WindowProc _windowProc;
    private bool _disposed;



    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]

    static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]

    static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    internal static IntPtr SetWindowLongPtr(HWND hWnd, WindowLongFlags nIndex, IntPtr dwNewLong)
    {
        if (IntPtr.Size == 8)

            return SetWindowLong64(hWnd.DangerousGetHandle(), (int)nIndex, dwNewLong);

        else

            return SetWindowLong32(hWnd.DangerousGetHandle(), (int)nIndex, dwNewLong);
    }

    const int AcSrcOver = 0x00;
    const int AcSrcAlpha = 0x01;

    Gdi32.BLENDFUNCTION blendfunction = new Gdi32.BLENDFUNCTION()
    {
        BlendOp = AcSrcOver,
        BlendFlags = 0x00,
        SourceConstantAlpha = 0xff,
        AlphaFormat = AcSrcAlpha
    };

    public BorderlessWindow ParentWindow { get; }

    public HWND ParentHWnd { get; }
    public HWND HWnd { get; private set; }


    public WindowDropShadow(BorderlessWindow parentWindow)
    {

        ParentHWnd = new HWND(parentWindow.Handle);
        ParentWindow = parentWindow;

        CreateWindow();

    }

    private void CreateWindow()
    {
        var className = $"{SHADOW_WND_NAME}_{ParentWindow.Handle}";

        _windowProc = ShadowWindowProc;

        _gcHandle = GCHandle.Alloc(_windowProc);

        var windowClass = new WindowClass(className, HINSTANCE.NULL, _windowProc);

        var exStyles = WindowStylesEx.WS_EX_LEFT | WindowStylesEx.WS_EX_LTRREADING | WindowStylesEx.WS_EX_TOOLWINDOW | WindowStylesEx.WS_EX_NOPARENTNOTIFY | WindowStylesEx.WS_EX_LAYERED | WindowStylesEx.WS_EX_NOACTIVATE | WindowStylesEx.WS_EX_TRANSPARENT;

        var styles = WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_POPUP;

        HWnd = CreateWindowEx(exStyles, className, "NanUI Shadow Window", styles, 0, 0, 0, 0, HWND.NULL, HMENU.NULL, HINSTANCE.NULL, IntPtr.Zero);

        //D2D1.D2D1CreateFactory(FactoryType.SingleThreaded, out _d2dFactory);
    }


    #region Skia
    internal protected void RenderWithSkia(SKBitmap tplBitmap)
    {

        GetWindowRect(HWnd, out var rect);

        var width = rect.Width;
        var height = rect.Height;


        if (width <= 0 || height <= 0) return;


        using (var bmp = new Bitmap(width, height))
        {

            var bitmapData = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            var skBmpInfo = new SKImageInfo
            {
                AlphaType = SKAlphaType.Premul,
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888,
            };

            using (var surface = SKSurface.Create(skBmpInfo, bitmapData.Scan0, bitmapData.Stride))
            using (var canvas = surface.Canvas)
            {

                canvas.Clear(SKColors.Transparent);

                DrawShadowWithSKia(canvas, tplBitmap, bmp);
            }

            bmp.UnlockBits(bitmapData);

            UpdateLayeredWindowWithSkia(bmp);
        }

    }

    private void DrawShadowWithSKia(SKCanvas canvas, SKBitmap sourceBitmap, Bitmap destBitmap)
    {

        //GetWindowRect(HWnd, out var rect);

        //var width = rect.Width;
        //var height = rect.Height;


        var config = ParentWindow.ShadowEffects[ParentWindow.ShadowEffect];

        var cornerSize = ParentWindow.CornerSize;

        //var shadowOffset = config.Offset;
        //var shadowSize = config.Size;
        //var blur = config.Blur;

        var shadowSize = config.Width;

        var partSize = shadowSize + cornerSize;

        var sTopLeft = new SKRect(0, 0, partSize, shadowSize);
        var sTopRight = new SKRect(sourceBitmap.Width - partSize, 0, sourceBitmap.Width, shadowSize);
        var sTop = new SKRect(partSize, 0, sourceBitmap.Width - partSize, shadowSize);

        var sBottomLeft = new SKRect(0, sourceBitmap.Height - shadowSize, partSize, sourceBitmap.Height);
        var sBottomRight = new SKRect(sourceBitmap.Width - partSize, sourceBitmap.Height - shadowSize, sourceBitmap.Width, sourceBitmap.Height);
        var sBottom = new SKRect(partSize, sourceBitmap.Height - shadowSize, sourceBitmap.Width - partSize, sourceBitmap.Height);

        var sLeftTop = new SKRect(0, shadowSize, partSize, shadowSize + partSize);
        var sLeftBottom = new SKRect(0, sourceBitmap.Height - shadowSize - partSize, partSize, sourceBitmap.Height - shadowSize);
        var sLeft = new SKRect(0, shadowSize + partSize, partSize, sourceBitmap.Height - shadowSize - partSize);


        var sRightTop = new SKRect(sourceBitmap.Width - partSize, shadowSize, sourceBitmap.Width, shadowSize + partSize);
        var sRightBottom = new SKRect(sourceBitmap.Width - partSize, sourceBitmap.Height - shadowSize - partSize, sourceBitmap.Width, sourceBitmap.Height - shadowSize);
        var sRight = new SKRect(sourceBitmap.Width - partSize, shadowSize + partSize, sourceBitmap.Width, sourceBitmap.Height - shadowSize - partSize);



        var dTopLeft = new SKRect(0, 0, partSize, shadowSize);
        var dTopRight = new SKRect(destBitmap.Width - partSize, 0, destBitmap.Width, shadowSize);
        var dTop = new SKRect(partSize, 0, destBitmap.Width - partSize, shadowSize);

        var dBottomLeft = new SKRect(0, destBitmap.Height - shadowSize, partSize, destBitmap.Height);
        var dBottomRight = new SKRect(destBitmap.Width - partSize, destBitmap.Height - shadowSize, destBitmap.Width, destBitmap.Height);
        var dBottom = new SKRect(partSize, destBitmap.Height - shadowSize, destBitmap.Width - partSize, destBitmap.Height);

        var dLeftTop = new SKRect(0, shadowSize, partSize, shadowSize + partSize);
        var dLeftBottom = new SKRect(0, destBitmap.Height - shadowSize - partSize, partSize, destBitmap.Height - shadowSize);
        var dLeft = new SKRect(0, shadowSize + partSize, partSize, destBitmap.Height - shadowSize - partSize);

        var dRightTop = new SKRect(destBitmap.Width - partSize, shadowSize, destBitmap.Width, shadowSize + partSize);
        var dRightBottom = new SKRect(destBitmap.Width - partSize, destBitmap.Height - shadowSize - partSize, destBitmap.Width, destBitmap.Height - shadowSize);
        var dRight = new SKRect(destBitmap.Width - partSize, shadowSize + partSize, destBitmap.Width, destBitmap.Height - shadowSize - partSize);

        using (var paint = new SKPaint
        {

        })
        {
            canvas.DrawBitmap(sourceBitmap, sTopLeft, dTopLeft, paint);
            canvas.DrawBitmap(sourceBitmap, sTopRight, dTopRight, paint);
            canvas.DrawBitmap(sourceBitmap, sTop, dTop, paint);

            canvas.DrawBitmap(sourceBitmap, sBottomLeft, dBottomLeft, paint);
            canvas.DrawBitmap(sourceBitmap, sBottomRight, dBottomRight, paint);
            canvas.DrawBitmap(sourceBitmap, sBottom, dBottom, paint);

            canvas.DrawBitmap(sourceBitmap, sLeftTop, dLeftTop, paint);
            canvas.DrawBitmap(sourceBitmap, sLeftBottom, dLeftBottom, paint);
            canvas.DrawBitmap(sourceBitmap, sLeft, dLeft, paint);

            canvas.DrawBitmap(sourceBitmap, sRightTop, dRightTop, paint);
            canvas.DrawBitmap(sourceBitmap, sRightBottom, dRightBottom, paint);
            canvas.DrawBitmap(sourceBitmap, sRight, dRight, paint);

        }



        GetWindowRect(ParentHWnd, out var parentRect);

        var rectWidth = parentRect.Width;
        var rectHeight = parentRect.Height;


        using (var paint = new SKPaint
        {
            BlendMode = SKBlendMode.SrcIn,
            Color = SKColors.Transparent
        })
        {
            canvas.DrawRoundRect(new SKRoundRect(new SKRect(shadowSize + 1, shadowSize + 1, shadowSize + rectWidth - 1, shadowSize + rectHeight - 1), cornerSize), paint);
        }
    }




    internal protected void UpdateLayeredWindowWithSkia(Bitmap bmp)
    {
        HDC screenDC = GetDC(HWND.NULL);
        HDC memDC = HDC.NULL;

        HBITMAP hBITMAP = HBITMAP.NULL, hOldBitmap = HBITMAP.NULL;

        try
        {
            GetWindowRect(HWnd, out var rect);
            var size = rect.Size;
            var location = rect.Location;

            memDC = Gdi32.CreateCompatibleDC(screenDC);

            hBITMAP = new HBITMAP(bmp.GetHbitmap(System.Drawing.Color.FromArgb(0, 0, 0, 0)));
            hOldBitmap = Gdi32.SelectObject(memDC, hBITMAP);


            UpdateLayeredWindow(HWnd, screenDC, location, size, memDC, Point.Empty, COLORREF.None, blendfunction, UpdateLayeredWindowFlags.ULW_ALPHA);


        }
        finally
        {
            if (hBITMAP != HBITMAP.NULL)
            {
                Gdi32.SelectObject(memDC, hOldBitmap);
                Gdi32.DeleteObject(hBITMAP);
            }

            if (memDC != HDC.NULL)
            {
                Gdi32.DeleteDC(memDC);
            }

            if (screenDC != HDC.NULL)
            {
                ReleaseDC(IntPtr.Zero, screenDC);
            }

            bmp.Dispose();
        }




    }

    #endregion



    #region Direct2D

    ID2D1Factory _d2dFactory = null;
    private ID2D1Bitmap LoadD2D1BitmapFromBitmap(ID2D1RenderTarget renderTarget, Bitmap origin)
    {
        Bitmap destBitmap;


        if (origin.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
        {
            destBitmap = new Bitmap(origin.Width, origin.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(destBitmap))
            {
                g.DrawImage(origin, 0, 0);
                g.Flush();
            }
        }
        else
        {
            destBitmap = (Bitmap)origin.Clone();
        }

        var bmpData = destBitmap.LockBits(new Rectangle(0, 0, destBitmap.Width, destBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, destBitmap.PixelFormat);

        int buffSize = bmpData.Stride * destBitmap.Height;

        byte[] byteData = new byte[buffSize];

        Marshal.Copy(bmpData.Scan0, byteData, 0, buffSize);

        destBitmap.UnlockBits(bmpData);


        var bmpProps = new BitmapProperties
        {
            PixelFormat = new Vortice.DCommon.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, Vortice.DCommon.AlphaMode.Premultiplied),
            DpiX = 96,
            DpiY = 96
        };

        var d2d1Bmp = renderTarget.CreateBitmap(new SizeI(destBitmap.Width, destBitmap.Height), IntPtr.Zero, bmpData.Stride, bmpProps);

        d2d1Bmp.CopyFromMemory(byteData, bmpData.Stride);

        return d2d1Bmp;

    }

    ID2D1DCRenderTarget d2dRenderTarget = null;

    internal protected void RenderWithD2D(byte[] buff)
    {


        GetWindowRect(HWnd, out var rect);

        var width = rect.Width;
        var height = rect.Height;

        if (width <= 0 || height <= 0) return;

        var renderProps = new RenderTargetProperties()
        {
            Type = RenderTargetType.Hardware,
            Usage = RenderTargetUsage.None,
            PixelFormat = new Vortice.DCommon.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, Vortice.DCommon.AlphaMode.Premultiplied),
            MinLevel = FeatureLevel.Default
        };


        var screenDC = GetDC(HWND.NULL);

        var memDC = Gdi32.CreateCompatibleDC(screenDC);

        HBITMAP hBitmap = HBITMAP.NULL, hOldBitmap = HBITMAP.NULL;


        try
        {
            if (d2dRenderTarget == null)
                d2dRenderTarget = _d2dFactory.CreateDCRenderTarget(renderProps);

            using (var destBitmap = new Bitmap(width, height))
            using (var ms = new MemoryStream(buff))
            using (var sourceBitmap = new Bitmap(ms))
            using (var tplBmp = LoadD2D1BitmapFromBitmap(d2dRenderTarget, sourceBitmap))
            {

                hBitmap = destBitmap.GetHbitmap(System.Drawing.Color.FromArgb(0, 0, 0, 0));

                hOldBitmap = Gdi32.SelectObject(memDC, hBitmap);

                d2dRenderTarget.BindDC(memDC.DangerousGetHandle(), new RawRect(0, 0, width, height));

                var config = ParentWindow.ShadowEffects[ParentWindow.ShadowEffect];

                var cornerSize = ParentWindow.CornerSize;

                var shadowSize = config.Width;

                var partSize = shadowSize + cornerSize;

                var sTopLeft = new RawRectF(0, 0, partSize, shadowSize);
                var sTopRight = new RawRectF(sourceBitmap.Width - partSize, 0, sourceBitmap.Width, shadowSize);
                var sTop = new RawRectF(partSize, 0, sourceBitmap.Width - partSize, shadowSize);

                var sBottomLeft = new RawRectF(0, sourceBitmap.Height - shadowSize, partSize, sourceBitmap.Height);
                var sBottomRight = new RawRectF(sourceBitmap.Width - partSize, sourceBitmap.Height - shadowSize, sourceBitmap.Width, sourceBitmap.Height);
                var sBottom = new RawRectF(partSize, sourceBitmap.Height - shadowSize, sourceBitmap.Width - partSize, sourceBitmap.Height);

                var sLeftTop = new RawRectF(0, shadowSize, partSize, shadowSize + partSize);
                var sLeftBottom = new RawRectF(0, sourceBitmap.Height - shadowSize - partSize, partSize, sourceBitmap.Height - shadowSize);
                var sLeft = new RawRectF(0, shadowSize + partSize, shadowSize, sourceBitmap.Height - shadowSize - partSize);


                var sRightTop = new RawRectF(sourceBitmap.Width - partSize, shadowSize, sourceBitmap.Width, shadowSize + partSize);
                var sRightBottom = new RawRectF(sourceBitmap.Width - partSize, sourceBitmap.Height - shadowSize - partSize, sourceBitmap.Width, sourceBitmap.Height - shadowSize);
                var sRight = new RawRectF(sourceBitmap.Width - shadowSize, shadowSize + partSize, sourceBitmap.Width, sourceBitmap.Height - shadowSize - partSize);



                var dTopLeft = new RawRectF(0, 0, partSize, shadowSize);
                var dTopRight = new RawRectF(destBitmap.Width - partSize, 0, destBitmap.Width, shadowSize);
                var dTop = new RawRectF(partSize, 0, destBitmap.Width - partSize, shadowSize);

                var dBottomLeft = new RawRectF(0, destBitmap.Height - shadowSize, partSize, destBitmap.Height);
                var dBottomRight = new RawRectF(destBitmap.Width - partSize, destBitmap.Height - shadowSize, destBitmap.Width, destBitmap.Height);
                var dBottom = new RawRectF(partSize, destBitmap.Height - shadowSize, destBitmap.Width - partSize, destBitmap.Height);

                var dLeftTop = new RawRectF(0, shadowSize, partSize, shadowSize + partSize);
                var dLeftBottom = new RawRectF(0, destBitmap.Height - shadowSize - partSize, partSize, destBitmap.Height - shadowSize);
                var dLeft = new RawRectF(0, shadowSize + partSize, shadowSize, destBitmap.Height - shadowSize - partSize);

                var dRightTop = new RawRectF(destBitmap.Width - partSize, shadowSize, destBitmap.Width, shadowSize + partSize);
                var dRightBottom = new RawRectF(destBitmap.Width - partSize, destBitmap.Height - shadowSize - partSize, destBitmap.Width, destBitmap.Height - shadowSize);
                var dRight = new RawRectF(destBitmap.Width - shadowSize, shadowSize + partSize, destBitmap.Width, destBitmap.Height - shadowSize - partSize);


                GetWindowRect(ParentHWnd, out var parentRect);

                var rectWidth = parentRect.Width;
                var rectHeight = parentRect.Height;

                d2dRenderTarget.BeginDraw();

                d2dRenderTarget.Clear(new ColorBgra(0));

                using (var rectMask = _d2dFactory.CreateRectangleGeometry(Rect.FromLTRB(0, 0, width, height)))
                using (var rrectMask = _d2dFactory.CreateRoundedRectangleGeometry(new RoundedRectangle(Rect.FromLTRB(shadowSize, shadowSize, shadowSize + rectWidth, shadowSize + rectHeight), cornerSize, cornerSize)))
                using (var retvalMask = _d2dFactory.CreatePathGeometry())
                using (var layer = d2dRenderTarget.CreateLayer(new Size(width, height)))

                {

                    var sink = retvalMask.Open();
                    rectMask.CombineWithGeometry(rrectMask, CombineMode.Exclude, sink);
                    sink.Close();




                    var lparam = new LayerParameters
                    {
                        ContentBounds = new RawRectF(0, 0, width, height),
                        GeometricMask = retvalMask,
                        Opacity = 1,
                        MaskTransform = System.Numerics.Matrix3x2.Identity,
                        LayerOptions = LayerOptions.None,

                        MaskAntialiasMode = AntialiasMode.PerPrimitive
                    };


                    d2dRenderTarget.PushLayer(lparam, layer);


                    d2dRenderTarget.DrawBitmap(tplBmp, dTopLeft, 1.0f, BitmapInterpolationMode.Linear, sTopLeft);
                    d2dRenderTarget.DrawBitmap(tplBmp, dTopRight, 1.0f, BitmapInterpolationMode.Linear, sTopRight);
                    d2dRenderTarget.DrawBitmap(tplBmp, dTop, 1.0f, BitmapInterpolationMode.Linear, sTop);

                    d2dRenderTarget.DrawBitmap(tplBmp, dBottomLeft, 1.0f, BitmapInterpolationMode.Linear, sBottomLeft);
                    d2dRenderTarget.DrawBitmap(tplBmp, dBottomRight, 1.0f, BitmapInterpolationMode.Linear, sBottomRight);
                    d2dRenderTarget.DrawBitmap(tplBmp, dBottom, 1.0f, BitmapInterpolationMode.Linear, sBottom);

                    d2dRenderTarget.DrawBitmap(tplBmp, dLeftTop, 1.0f, BitmapInterpolationMode.Linear, sLeftTop);
                    d2dRenderTarget.DrawBitmap(tplBmp, dLeftBottom, 1.0f, BitmapInterpolationMode.Linear, sLeftBottom);
                    d2dRenderTarget.DrawBitmap(tplBmp, dLeft, 1.0f, BitmapInterpolationMode.Linear, sLeft);

                    d2dRenderTarget.DrawBitmap(tplBmp, dRightTop, 1.0f, BitmapInterpolationMode.Linear, sRightTop);
                    d2dRenderTarget.DrawBitmap(tplBmp, dRightBottom, 1.0f, BitmapInterpolationMode.Linear, sRightBottom);
                    d2dRenderTarget.DrawBitmap(tplBmp, dRight, 1.0f, BitmapInterpolationMode.Linear, sRight);

                    d2dRenderTarget.PopLayer();




                }

                if (d2dRenderTarget.EndDraw().Failure)
                {
                    d2dRenderTarget?.Dispose();
                    d2dRenderTarget = null;
                }

                UpdateLayeredWindowWithD2D(screenDC, memDC);

            }
        }
        finally
        {


            if (memDC != HDC.NULL && hOldBitmap != HBITMAP.NULL)
            {
                Gdi32.SelectObject(memDC, hOldBitmap);

            }

            if (hBitmap != HBITMAP.NULL)
            {
                Gdi32.DeleteObject(hBitmap);
            }

            if (memDC != HDC.NULL)
            {
                Gdi32.DeleteDC(memDC);
            }

            if (screenDC != HDC.NULL)
            {
                ReleaseDC(HWND.NULL, screenDC);
            }


        }
    }


    internal protected void UpdateLayeredWindowWithD2D(Gdi32.SafeHDC screenDC, Gdi32.SafeHDC memDC)
    {
        GetWindowRect(HWnd, out var rect);
        var size = rect.Size;
        var location = rect.Location;

        UpdateLayeredWindow(HWnd, screenDC, location, size, memDC, Point.Empty, COLORREF.None, blendfunction, UpdateLayeredWindowFlags.ULW_ALPHA);
    }


    #endregion


    private IntPtr ShadowWindowProc(HWND hWnd, uint umsg, IntPtr wParam, IntPtr lParam)
    {

        return DefWindowProc(hWnd, umsg, wParam, lParam);
    }


    internal void SetOwner(IntPtr owner)
    {
        SetWindowLongPtr(HWnd, WindowLongFlags.GWL_HWNDPARENT, owner);
    }

    internal void UpdateZOrder()
    {
        SetWindowPos(HWnd, ParentWindow.TopMost ? HWND.HWND_TOPMOST : HWND.HWND_NOTOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);

        SetWindowPos(HWnd, ParentHWnd, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);
    }


    internal SizeI GetShadowSize(int winWidth, int winHeight)
    {
        var config = ParentWindow.ShadowEffects[ParentWindow.ShadowEffect];

        var shadowSize = config.Width;

        return new SizeI(winWidth + shadowSize * 2, winHeight + shadowSize * 2);
    }
    internal Point GetShadowLocation(int x, int y, int cx, int cy)
    {
        var config = ParentWindow.ShadowEffects[ParentWindow.ShadowEffect];

        var shadowSize = config.Width;

        return new Point(x - shadowSize, y - shadowSize);
    }


    public void Show(bool isShow)
    {
        ShowWindow(HWnd, isShow ? ShowWindowCommand.SW_SHOWNOACTIVATE : ShowWindowCommand.SW_HIDE);
    }

    public void Close()
    {
        SetParent(HWnd, HWND.NULL);
        CloseWindow(HWnd);
    }




    public void Dispose()
    {
        if (_disposed)
            return;

        DestroyWindow(HWnd);


        _gcHandle.Free();

        _disposed = true;
        System.GC.SuppressFinalize(this);

    }


}
