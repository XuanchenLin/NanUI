// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Drawing.Imaging;

namespace WinFormium.Browser.ContextMenu;
internal class ContextMenuStripRenderer : ToolStripProfessionalRenderer
{
    public bool IsDarkMode { get; }

    const int PADDING = 6;


    public ContextMenuStripRenderer(bool isDarkMode) :
        base(isDarkMode ? new ContextMenuStripColorTableDark() : new ContextMenuStripColorTableLight())
    {
        IsDarkMode = isDarkMode;
    }

    protected override void InitializeItem(ToolStripItem item)
    {
        base.InitializeItem(item);
    }

    protected override void Initialize(ToolStrip toolStrip)
    {
        toolStrip.Width += 20;

        base.Initialize(toolStrip);
    }

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {

        base.OnRenderToolStripBackground(e);
    }

    protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
    {

        base.OnRenderItemBackground(e);
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        base.OnRenderMenuItemBackground(e);
    }

    protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
    {
        if(e.Image==null || !IsDarkMode)
        {
            base.OnRenderItemImage(e);

            return;
        }


        if(!e.Item.Enabled)
        {
            base.OnRenderItemImage(e);

            return;
        }

        var brightness = 1.5f; // no change in brightness
        var contrast = 1.0f; // twice the contrast
        var gamma = 1.0f; // no change in gamma

        var adjustedBrightness = brightness - 1.0f;

        float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0},
            new float[] {0, contrast, 0, 0, 0},
            new float[] {0, 0, contrast, 0, 0},
            new float[] {0, 0, 0, 1.0f, 0},
            new float[] {adjustedBrightness, adjustedBrightness,
        adjustedBrightness, 0, 1}};

        var imageAttributes = new ImageAttributes();
        imageAttributes.ClearColorMatrix();
        imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray),
        ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(e.Image, e.ImageRectangle, 0,0,e.Image.Width, e.Image.Height, GraphicsUnit.Pixel, imageAttributes);

        //base.OnRenderItemImage(e);
    }



    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        if (IsDarkMode)
        {
            if (e.Item.Enabled)
            {
                e.TextColor = Color.FromArgb(0xff, 0xff, 0xff);
            }
            else
            {
                e.TextColor = Color.FromArgb(0xfa, 0xfa, 0xfa);
            }
        }
        else
        {
            if (e.Item.Enabled)
            {
                e.TextColor = Color.FromArgb(0x1a, 0x1a, 0x1a);
            }
            else
            {
                e.TextColor = Color.FromArgb(0xc3, 0xc3, 0xc3);
            }
        }

        //e.Item.Padding = new Padding(PADDING, PADDING / 2, PADDING, PADDING / 2);

        //e.Item.TextAlign = ContentAlignment.MiddleLeft;

        //e.TextRectangle = new Rectangle(e.TextRectangle.X, e.TextRectangle.Y, e.TextRectangle.Width + e.Item.Padding.Horizontal, e.TextRectangle.Height + e.Item.Padding.Vertical);

        //e.Item.Size = new Size(e.Item.Size.Width + e.Item.Padding.Horizontal, e.Item.Size.Height + e.Item.Padding.Vertical);

        base.OnRenderItemText(e);
    }

}
