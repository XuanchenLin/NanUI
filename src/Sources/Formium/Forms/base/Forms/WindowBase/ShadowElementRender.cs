// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;
internal class ShadowElementRender
{

    public static Size TemplateBoxSize => new Size(300, 300);

    public ShadowEffectConfiguration ShadowConfig { get; }
    public Color ActiveColor { get; }
    public Color InactiveColor { get; }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public Rectangle ShadowRectangle { get; private set; }
    public Rectangle BoxRectangle { get; private set; }

    public int ActualSize { get; }
    public int InsideOffsetSize { get; }
    public int ShadowSize { get; }

    Dictionary<bool, Dictionary<ShadowFragment, SKBitmap>> BitmapCache { get; } = new Dictionary<bool, Dictionary<ShadowFragment, SKBitmap>>();


    public ShadowElementRender(ShadowEffectConfiguration shadowConfig, Color activeColor, Color inactiveColor)
    {
        ShadowConfig = shadowConfig;
        ActiveColor = activeColor;
        InactiveColor = inactiveColor;


        var insideOffset = InsideOffsetSize = shadowConfig.InsideOffset;
        ShadowSize = ShadowConfig.Size;
        ActualSize = ShadowConfig.Size + insideOffset;

        Width = TemplateBoxSize.Width + shadowConfig.Size * 2;
        Height = TemplateBoxSize.Height + shadowConfig.Size * 2;

        ShadowRectangle = new Rectangle(0, 0, Width, Height);

        var x = (Width - TemplateBoxSize.Width) / 2;
        var y = (Height - TemplateBoxSize.Height) / 2;

        BoxRectangle = new Rectangle(x, y, TemplateBoxSize.Width, TemplateBoxSize.Height);


        BitmapCache[true] = GenerateBitmap(ActiveColor);
        BitmapCache[false] = GenerateBitmap(InactiveColor);

    }

    public void DrawShadowBitmap(SKCanvas canvas, ShadowElementPosition position, bool isActivated)
    {
        var state = isActivated;
        var template = BitmapCache[state];

        var width = canvas.DeviceClipBounds.Width;
        var height = canvas.DeviceClipBounds.Height;

        canvas.Clear(new SKColor(0x00000000));

        switch (position)
        {
            case ShadowElementPosition.Top:
                {
                    var tplBmp = template[ShadowFragment.Top];

                    var tplWidth = tplBmp.Width;
                    var tplHeight = tplBmp.Height;

                    canvas.DrawBitmap(tplBmp, SKRect.Create((tplWidth - ShadowSize) / 2, 0, ShadowSize, tplHeight), new SKRect(0, 0, width, height));

                    using var paint = new SKPaint();
                    paint.BlendMode = SKBlendMode.Src;

                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, 0, ShadowSize * 2, tplHeight), new SKRect(0, 0, ShadowSize * 2, height), paint);

                    canvas.DrawBitmap(tplBmp, SKRect.Create(tplWidth - ShadowSize * 2, 0, ShadowSize * 2, tplHeight), new SKRect(width - ShadowSize * 2, 0, width, height), paint);


                }
                break;
            case ShadowElementPosition.Bottom:
                {
                    var tplBmp = template[ShadowFragment.Bottom];

                    var tplWidth = tplBmp.Width;
                    var tplHeight = tplBmp.Height;

                    canvas.DrawBitmap(tplBmp, SKRect.Create((tplWidth - ShadowSize) / 2, 0, ShadowSize, tplHeight), new SKRect(0, 0, width, height));

                    using var paint = new SKPaint();
                    paint.BlendMode = SKBlendMode.Src;

                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, 0, ShadowSize * 2, tplHeight), new SKRect(0, 0, ShadowSize * 2, height), paint);

                    canvas.DrawBitmap(tplBmp, SKRect.Create(tplWidth - ShadowSize * 2, 0, ShadowSize * 2, tplHeight), new SKRect(width - ShadowSize * 2, 0, width, height), paint);

                }
                break;
            case ShadowElementPosition.Left:
                {

                    var tplBmp = template[ShadowFragment.Left];

                    var tplWidth = tplBmp.Width;
                    var tplHeight = tplBmp.Height;

                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, (tplHeight - ShadowSize) / 2, tplWidth, ShadowSize), new SKRect(0, 0, width, height));

                    using var paint = new SKPaint();
                    paint.BlendMode = SKBlendMode.Src;

                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, 0, tplWidth, ShadowSize * 2), new SKRect(0, 0, ActualSize, ShadowSize * 2), paint);


                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, tplHeight - ShadowSize * 2, tplWidth, ShadowSize * 2), new SKRect(0, height - ShadowSize * 2, ActualSize, height), paint);


                }
                break;

            case ShadowElementPosition.Right:
                {
                    var tplBmp = template[ShadowFragment.Right];

                    var tplWidth = tplBmp.Width;
                    var tplHeight = tplBmp.Height;

                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, (tplHeight - ShadowSize) / 2, tplWidth, ShadowSize), new SKRect(0, 0, width, height));

                    using var paint = new SKPaint();
                    paint.BlendMode = SKBlendMode.Src;

                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, 0, tplWidth, ShadowSize * 2), new SKRect(width - ActualSize, 0, ActualSize, ShadowSize * 2), paint);


                    canvas.DrawBitmap(tplBmp, SKRect.Create(0, tplHeight - ShadowSize * 2, tplWidth, ShadowSize * 2), new SKRect(width - ActualSize, height - ShadowSize * 2, ActualSize, height), paint);
                }
                break;
        }




    }



    private Dictionary<ShadowFragment, SKBitmap> GenerateBitmap(Color color)
    {
        var shadowBlur = ShadowConfig.Blur;
        var shadowOffset = ShadowConfig.Offset;

        var shadowOffsetX = ShadowConfig.OffsetX;
        var shadowOffsetY = ShadowConfig.OffsetY;



        var blur = shadowBlur;//(int)(shadowSize / 2f - (float)(Math.Ceiling((Width * Height * 1f) / ((Width * Height - rectWidth * rectHeight) * 1f)) * ((Width * Height - rectWidth * rectHeight) * 1f) / (Width * Height * 1f) * (shadowBlur / 100f)) - shadowOffset * ((Width * Height - rectWidth * rectHeight) * 1f) / (Width * Height * 1f));

        var boxRect = SKRect.Create(BoxRectangle.X, BoxRectangle.Y, BoxRectangle.Width, BoxRectangle.Height);
        var canvasRect = SKRect.Create(0, 0, ShadowRectangle.Width, ShadowRectangle.Height);
        var shadowColor = new SKColor(color.R, color.G, color.B, color.A);

        using var bitmap = new SKBitmap(new SKImageInfo
        {
            AlphaType = SKAlphaType.Premul,
            ColorType = SKColorType.Bgra8888,
            Width = Width,
            Height = Height
        });
        using var shadowCanvas = new SKCanvas(bitmap);
        using var shadowPaint = new SKPaint();

        if (blur <= 0)
        {
            shadowPaint.Color = shadowColor;
            shadowCanvas.DrawRoundRect(new SKRoundRect(canvasRect, shadowOffset), shadowPaint);
        }
        else
        {
            shadowPaint.ImageFilter = SKImageFilter.CreateDropShadowOnly(shadowOffsetX, shadowOffsetY, blur, blur, shadowColor);
            shadowCanvas.DrawRect(boxRect, shadowPaint);
        }

        var fragments = new Dictionary<ShadowFragment, SKRect>();

        fragments[ShadowFragment.Top] = new SKRect(0, 0, Width, ActualSize);
        fragments[ShadowFragment.Bottom] = new SKRect(0, Height - ActualSize, Width, Height);
        fragments[ShadowFragment.Left] = new SKRect(0, ShadowSize, ActualSize, Height - ShadowSize);
        fragments[ShadowFragment.Right] = new SKRect(Width - ActualSize, ShadowSize, Width, Height - ShadowSize);

        var partBuff = new Dictionary<ShadowFragment, SKBitmap>();

        foreach (var item in fragments)
        {
            var destRect = fragments[item.Key];
            destRect.Offset(-destRect.Left, -destRect.Top);

            var width = (int)destRect.Width;
            var height = (int)destRect.Height;

            var bmp = new SKBitmap(new SKImageInfo
            {
                AlphaType = SKAlphaType.Premul,
                ColorType = SKColorType.Bgra8888,
                Width = width,
                Height = height
            });

            using var canvas = new SKCanvas(bmp);
            using var paint = new SKPaint();
            paint.BlendMode = SKBlendMode.DstIn;

            canvas.DrawBitmap(bitmap, fragments[item.Key], destRect);

            switch (item.Key)
            {
                case ShadowFragment.Top:
                    {
                        paint.Shader = SKShader.CreateLinearGradient(new SKPoint(width / 2, ShadowSize), new SKPoint(width / 2, height), new SKColor[] { SKColors.White, SKColors.Transparent }, SKShaderTileMode.Repeat);

                        canvas.DrawRect(new SKRect(0, ShadowSize, width, height), paint);



                        //using var ms = new FileStream($"D:\\tpl_{item.Key}.png", FileMode.Create);
                        //bmp.Encode(ms, SKEncodedImageFormat.Png, 100);
                        //ms.Close();
                    }
                    break;
                case ShadowFragment.Bottom:
                    {
                        paint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0), new SKPoint(0, InsideOffsetSize), new SKColor[] { SKColors.Transparent, SKColors.White }, SKShaderTileMode.Repeat);

                        canvas.DrawRect(new SKRect(0, 0, width, InsideOffsetSize), paint);

                        //using var ms = new FileStream($"D:\\tpl_{item.Key}.png", FileMode.Create);
                        //bmp.Encode(ms, SKEncodedImageFormat.Png, 100);
                        //ms.Close();
                    }
                    break;
                case ShadowFragment.Right:
                case ShadowFragment.Left:
                    {

                        paint.Shader = SKShader.CreateLinearGradient(new SKPoint(width / 2, 0), new SKPoint(width / 2, InsideOffsetSize), new SKColor[] { SKColors.Transparent, SKColors.White }, SKShaderTileMode.Repeat);
                        canvas.DrawRect(new SKRect(0, 0, width, InsideOffsetSize), paint);


                        paint.Shader = SKShader.CreateLinearGradient(new SKPoint(width / 2, height - InsideOffsetSize), new SKPoint(width / 2, height), new SKColor[] { SKColors.White, SKColors.Transparent }, SKShaderTileMode.Clamp);
                        canvas.DrawRect(new SKRect(0, height - InsideOffsetSize, width, height), paint);


                        //using var ms = new FileStream($"D:\\tpl_{item.Key}.png", FileMode.Create);
                        //bmp.Encode(ms, SKEncodedImageFormat.Png, 100);
                        //ms.Close();
                    }
                    break;


            }


            partBuff[item.Key] = bmp;
        }

        return partBuff;


    }
}
