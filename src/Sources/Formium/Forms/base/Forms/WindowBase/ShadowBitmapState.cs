// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

internal class ShadowBitmapState
{
    internal RECT Rectangle { get; private set; }

    public ShadowBitmapState(RECT rectangle)
    {
        Rectangle = rectangle;
    }

    public int Width => Rectangle.Width;
    public int Height => Rectangle.Height;

    public int X => Rectangle.X;

    public int Y => Rectangle.Y;

    public void UpdateRectangle(RECT rectangle)
    {
        Rectangle = rectangle;
        IsDirty = false;

    }


    public bool IsDirty { get; private set; } = true;
}
