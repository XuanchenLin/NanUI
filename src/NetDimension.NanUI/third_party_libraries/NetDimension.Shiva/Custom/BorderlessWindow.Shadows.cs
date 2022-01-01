namespace NetDimension.NanUI.HostWindow;

using SkiaSharp;

using static Vanara.PInvoke.User32;

partial class _FackUnuseClass
{

}


internal record ShadowState
{
    public int Width { get; set; }
    public int Height { get; set; }
    public bool IsActive { get; set; }
};

public class ShadowEffectConfiguration
{
    int shadowOffset = 0;
    int shadowSize = 0;
    int shadowBlur = 100;

    public int Offset
    {
        get => shadowOffset;
        set
        {
            if (value >= -10 && value <= 10)
            {
                shadowOffset = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(Offset)} should be -10 to 10.");
            }
        }
    }
    public int Blur
    {
        get => shadowBlur;
        set
        {
            if (value >= 0 && value <= 100)
            {
                shadowBlur = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(Blur)} should be 0 to 100.");
            }
        }
    }
    public int Size
    {
        get => shadowSize;
        set
        {
            if (value >= 0 && value <= 80)
            {
                shadowSize = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(Size)} should be 0 to 80.");
            }
        }
    }

    public int Width => Size + Math.Abs(Offset);
}



internal partial class BorderlessWindow
{
    WindowDropShadow _shadow = null;

    internal bool UseDirect2DAsRenderer => false;


    internal protected readonly Dictionary<ShadowEffect, ShadowEffectConfiguration> ShadowEffects = new Dictionary<ShadowEffect, ShadowEffectConfiguration>()
    {
        [ShadowEffect.None] = new ShadowEffectConfiguration { Offset = 0, Size = 0, Blur = 0 },
        [ShadowEffect.Glow] = new ShadowEffectConfiguration { Offset = 0, Size = 10, Blur = 100 },
        [ShadowEffect.Small] = new ShadowEffectConfiguration { Offset = 2, Size = 12, Blur = 100 },
        [ShadowEffect.Normal] = new ShadowEffectConfiguration { Offset = 2, Size = 24, Blur = 100 },
        [ShadowEffect.Big] = new ShadowEffectConfiguration { Offset = 6, Size = 36, Blur = 100 },
        [ShadowEffect.Huge] = new ShadowEffectConfiguration { Offset = 8, Size = 48, Blur = 100 },
        [ShadowEffect.DropShadow] = new ShadowEffectConfiguration { Offset = 4, Size = 66, Blur = 100 },
        [ShadowEffect.Custom] = new ShadowEffectConfiguration { Offset = 0, Size = 0, Blur = 0 }
    };


    private byte[] _cachedShadowBitmap = null;
    private byte[] _cachedInactiveShadowBitmap = null;

    private bool _isShadowInitialized = false;

    private bool _isWindowMinimized = false;

    private bool _isWindowMaximized = false;

    private bool _isShadowEnabled = false;

    protected bool IsWindowMaximized => _isWindowMaximized;

    protected bool IsWindowMinimized => _isWindowMinimized;

    internal byte[] CachedShadowBitmap => _cachedShadowBitmap;
    internal byte[] CachedInactiveShadowBitmap => _cachedInactiveShadowBitmap;

    protected virtual void CustomizeShadowEffect(ShadowEffectConfiguration shadowEffectConfiguration)
    {

    }

    internal protected void InitializeDropShadows()
    {
        CacheShadowBitmap();

        if (_isShadowInitialized) return;


        _shadow = new WindowDropShadow(this);

        if (Owner != null)
        {
            SetShadowOwner(Owner.Handle);
        }

        UpdateShadowZOrder();

        _isShadowInitialized = true;


    }

    internal protected void RedrawShadow()
    {
        CacheShadowBitmap();
        _lastShadowState = null;
        DrawShadowBitmap();
        UpdateShadowZOrder();
    }

    internal protected void SetWindowFocus()
    {
        DrawShadowBitmap();
    }

    internal protected void KillWindowFocus()
    {
        DrawShadowBitmap();
    }

    internal protected void SetApplicationFocus()
    {
        DrawShadowBitmap();
    }

    internal protected void KillApplicationFocus()
    {
        DrawShadowBitmap();
    }

    internal protected void EnableShadow(bool enable)
    {

        if (enable)
        {
            _isShadowEnabled = true;
            if (_lastShadowState != null)
            {
                ShowShadow(enable);
            }
            else
            {
                ShowShadow(true, true, 150);
            }
        }
        else
        {
            ShowShadow(enable);
            _isShadowEnabled = false;
        }
    }

    ShadowState _lastShadowState = null;

    private void DrawShadowBitmap()
    {
        if (ShadowEffect == ShadowEffect.None) return;
        if (!_isShadowInitialized) return;

        if (!_isShadowEnabled) return;

        var state = new ShadowState
        {
            Width = Width,
            Height = Height,
            IsActive = IsWindowFocused
        };

        if (_lastShadowState == state)
            return;

        if (UseDirect2DAsRenderer)
        {
            UseD2DShadowBitmap();
        }
        else
        {
            UseSkiaShadowBitmap();
        }

        UseSkiaShadowBitmap();

        _lastShadowState = state;

        System.GC.Collect();
    }



    private void UseSkiaShadowBitmap()
    {
        SKBitmap bitmap;

        if (IsWindowFocused)
        {
            bitmap = SKBitmap.Decode(CachedShadowBitmap);
        }
        else
        {
            bitmap = SKBitmap.Decode(CachedInactiveShadowBitmap);
        }

        RenderShadowBitmapWithSkia(bitmap);
    }

    private void RenderShadowBitmapWithSkia(SKBitmap bitmap)
    {
        if (!_isShadowInitialized) return;

        UpdateShadowZOrder();

        using (bitmap)
        {
            _shadow.RenderWithSkia(bitmap);
        }
    }


    #region Direct2d implements
    private void UseD2DShadowBitmap()
    {
        if (IsWindowFocused)
        {
            RenderShadowBitmapWithD2D(CachedShadowBitmap);
        }
        else
        {
            RenderShadowBitmapWithD2D(CachedInactiveShadowBitmap);
        }
    }

    private void RenderShadowBitmapWithD2D(byte[] buff)
    {
        if (!_isShadowInitialized) return;

        UpdateShadowZOrder();

        _shadow.RenderWithD2D(buff);
    }
    #endregion



    const int SIZE_RESTORED = 0;
    const int SIZE_MINIMIZED = 1;
    const int SIZE_MAXIMIZED = 2;

    FormWindowState? _lastWindowState = null;

    private bool IsShadowShownWithForm => _lastWindowState.HasValue;

    internal void ResizeShadow(ref Message m)
    {



        if (WindowState != FormWindowState.Normal)
        {
            _lastWindowState = WindowState;
        }

        if (m.WParam == (IntPtr)SIZE_MINIMIZED)
        {
            _isWindowMinimized = true;
        }

        if (m.WParam == (IntPtr)SIZE_MAXIMIZED)
        {
            _isWindowMaximized = true;
        }


        if (m.WParam == (IntPtr)SIZE_RESTORED)
        {

            DrawShadowBitmap();

            if (_lastWindowState != FormWindowState.Normal)
            {
                if (_lastWindowState == null)
                {

                    ShowShadow(true, true, 250);
                }
                else
                {
                    ShowShadow(true, true);

                }
            }
            else
            {
                ShowShadow(true);

            }
        }
        else
        {
            ShowShadow(false);
        }

    }


    private void UpdateShadowPos(WINDOWPOS windowpos)
    {
        if (!_isShadowInitialized) return;

        var pt = _shadow.GetShadowLocation(windowpos.x, windowpos.y, windowpos.cx, windowpos.cy);

        var size = _shadow.GetShadowSize(windowpos.cx, windowpos.cy);

        var flags = SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOZORDER;

        //if ((windowpos.flags & SetWindowPosFlags.SWP_NOSIZE) == SetWindowPosFlags.SWP_NOSIZE)
        //{
        //    flags |= SetWindowPosFlags.SWP_NOSIZE;
        //}

        //if ((windowpos.flags & SetWindowPosFlags.SWP_NOMOVE) == SetWindowPosFlags.SWP_NOMOVE)
        //{
        //    flags |= SetWindowPosFlags.SWP_NOMOVE;
        //}

        SetWindowPos(_shadow.HWnd, hWnd, pt.X, pt.Y, size.Width, size.Height, flags);
    }





    internal protected void SetShadowOwner(IntPtr owner)
    {
        _shadow.SetOwner(owner);
    }

    internal protected void UpdateShadowZOrder()
    {
        if (!_isShadowInitialized) return;

        _shadow.UpdateZOrder();
    }

    internal protected void DestroyShadows()
    {
        if (!_isShadowInitialized) return;

        _shadow.Close();
        _shadow.Dispose();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
        base.OnVisibleChanged(e);
        if (IsShadowShownWithForm)
        {
            var isWindowShown = Visible;

            EnableShadow(isWindowShown);
        }
    }

    bool _isShadowAnimationDelayed = false;

    delegate void ShowShadowDelegate(bool isShow, bool delayed = false);

    bool _isShadowShown = false;

    internal protected void ShowShadow(bool isShow, bool delayed = false, int duration = 180)
    {
        if (!_isShadowInitialized) return;

        if (isShow == _isShadowShown) return;

        if (ShadowEffect == ShadowEffect.None) return;


        void SetShadowVisibleImmediately()
        {

            if (isShow)
            {
                DrawShadowBitmap();

                _lastWindowState = FormWindowState.Normal;
            }

            _shadow.Show(isShow);

            _isShadowShown = isShow;
        }

        if (_isShadowAnimationDelayed)
            return;

        if (isShow && delayed)
        {
            _isShadowAnimationDelayed = true;

            Task.Run(async () =>
            {
                await Task.Delay(duration);

                if (_isShadowAnimationDelayed)
                {
                    _isShadowAnimationDelayed = false;

                    SetShadowVisibleImmediately();
                }
            });
        }
        else
        {
            SetShadowVisibleImmediately();
        }
    }



    internal protected void CacheShadowBitmap()
    {
        var config = ShadowEffects[_windowShadowStyle];

        if (_windowShadowStyle == ShadowEffect.Custom)
        {
            CustomizeShadowEffect(config);
        }

        if (ShadowEffect == ShadowEffect.None || config.Size == 0)
        {
            _cachedShadowBitmap = null;

            _cachedInactiveShadowBitmap = null;
            return;
        }

        var cornerSize = CornerSize;

        var shadowOffset = config.Offset;
        var shadowSize = config.Size;
        var shadowBlur = config.Blur;

        if (_minimumSize == null)
        {
            var partSize = shadowSize * 2 + cornerSize * 2 + shadowOffset;

            base.MinimumSize = new Size(partSize * 2, partSize * 2);
        }

        _cachedShadowBitmap = CreateShadowBitmap(_shadowColor, cornerSize, shadowOffset, shadowSize, shadowBlur);

        var inactiveColor = _inactiveShadowColor == null ? Color.FromArgb(Convert.ToByte(_shadowColor.A * 0.6f), _shadowColor) : _inactiveShadowColor.Value;

        _cachedInactiveShadowBitmap = CreateShadowBitmap(inactiveColor, cornerSize, shadowOffset, shadowSize, shadowBlur);
    }

    private byte[] CreateShadowBitmap(Color color, int cornerSize, int offset, int size, int blur)
    {
        const int rectWidth = 400;
        const int rectHeight = 400;

        var shadowOffset = Math.Abs(offset);

        var shadowSize = size;

        var width = rectWidth + shadowSize * 2 + shadowOffset * 2;
        var height = rectHeight + shadowSize * 2 + shadowOffset * 2;

        var shadowBlur = (int)(shadowSize / 2f - (float)(Math.Ceiling((width * height * 1f) / ((width * height - rectWidth * rectHeight) * 1f)) * ((width * height - rectWidth * rectHeight) * 1f) / (width * height * 1f) * (blur / 100f)) - shadowOffset * ((width * height - rectWidth * rectHeight) * 1f) / (width * height * 1f));

        var top = (height - rectHeight) / 2;
        var left = (width - rectWidth) / 2;

        byte[] bytes = null;

        using (var ms = new MemoryStream())
        using (var bitmap = new Bitmap(width, height))
        {
            var buff = bitmap.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            var imgInfo = new SKImageInfo()
            {
                AlphaType = SKAlphaType.Premul,
                ColorType = SKColorType.Bgra8888,
                Height = height,
                Width = width
            };

            var rect = new SKRect(left, top, left + rectWidth, top + rectHeight);

            var rrect = new SKRoundRect(rect, cornerSize);

            using (var surface = SKSurface.Create(imgInfo, buff.Scan0, buff.Stride))
            using (var canvas = surface.Canvas)
            {
                using (var paint = new SKPaint())
                {
                    var shadowColor = new SKColor(color.R, color.G, color.B, color.A);

                    if (blur == 0 && shadowOffset == 0)
                    {
                        paint.Color = shadowColor;

                        canvas.DrawRoundRect(new SKRoundRect(new SKRect(0, 0, width, height), cornerSize), paint);
                    }
                    else
                    {
                        paint.ImageFilter = SKImageFilter.CreateDropShadowOnly(offset, offset, shadowBlur, shadowBlur, shadowColor);

                        paint.Color = SKColors.White;

                        canvas.DrawRoundRect(rrect, paint);
                    }
                }
            }

            bitmap.UnlockBits(buff);

            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            bytes = ms.ToArray();
        }

        System.GC.Collect();


        return bytes;
    }




}
