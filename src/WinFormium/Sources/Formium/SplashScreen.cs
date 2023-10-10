// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
internal class SplashScreen : Panel
{
    private readonly Action<PaintEventArgs> _drawAction;

    protected Form TargetControl { get; }

    public Image? CachedImage { get; private set; }

    //private Rectangle CanvasBounds {
    //    get {
    //        User32.GetClientRect(TargetControl.Handle, out var rect);

    //        return rect;
    //    }
    //}



    public SplashScreen(Form parent, Action<PaintEventArgs> drawAction)
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

        TargetControl = parent;
        BackColor = Color.White;
        _drawAction = drawAction;

        Dock= DockStyle.Fill;

        Margin = Padding.Empty;
    }



    //private void PaintRequest()
    //{
    //    if (Visible == false) return;


    //    var bounds = CanvasBounds;

    //    var width = bounds.Width;
    //    var height = bounds.Height;

    //    using var bitmap = new Bitmap(width, height);
    //    var bitmapData = bitmap.LockBits(new Rectangle(Point.Empty, new Size(width, height)), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

    //    using var surface = SKSurface.Create(new SKImageInfo
    //    {
    //        ColorType = SKColorType.Bgra8888,
    //        AlphaType = SKAlphaType.Premul,
    //        Width = width,
    //        Height = height,
    //    }, bitmapData.Scan0, bitmapData.Stride);
    //    using var canvas = surface.Canvas;

    //    await Task.Run(() => _drawAction(canvas));

    //    bitmap.UnlockBits(bitmapData);

    //    var ms = new MemoryStream();
    //    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

    //    var oldImage = CachedImage;

    //    CachedImage = Image.FromStream(ms);



    //    BackgroundImage = CachedImage;

    //    if (oldImage != null)
    //    {
    //        oldImage.Dispose();
    //    }
    //}


    protected override void OnPaint(PaintEventArgs e)
    {

        if (Visible)
        {
            _drawAction.Invoke(e);
        }

    }


}
