// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Forms;

partial class _FackUnusedClass
{

}


public abstract class StandardWindowForm : StandardWindowBase
{
    public bool EnableOffscreenRender { get; }
    protected bool EnableDirectComposition { get; set; }


    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;

            if (EnableOffscreenRender && EnableDirectComposition)
            {
                cp.ExStyle |= (int)User32.WindowStylesEx.WS_EX_NOREDIRECTIONBITMAP;
            }

            return cp;
        }
    }


    public StandardWindowForm(bool enableOffscreenRender, bool enableDirectComposition)
    {
        EnableOffscreenRender = enableOffscreenRender;

        EnableDirectComposition = enableDirectComposition;

    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        base.SetBoundsCore(x, y, width, height, specified);
    }

    protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
    {
        var rect = base.GetScaledBounds(bounds, factor, specified);

        //System.Diagnostics.Debug.WriteLine($"GetScaledBounds: rect[before] -> {rect}");
        //System.Diagnostics.Debug.WriteLine($"GetScaledBounds: bounds -> {bounds}");

        if (!GetStyle(ControlStyles.FixedWidth) && (specified & BoundsSpecified.Width) != BoundsSpecified.None)
        {
            var clientWidth = bounds.Width;// - sz.Width;
            rect.Width = (int)Math.Round((double)(clientWidth * factor.Width));// + sz.Width;
        }
        if (!GetStyle(ControlStyles.FixedHeight) && (specified & BoundsSpecified.Height) != BoundsSpecified.None)
        {
            var clientHeight = bounds.Height;// - sz.Height;
            rect.Height = (int)Math.Round((double)(clientHeight * factor.Height));// + sz.Height;
        }

        //System.Diagnostics.Debug.WriteLine($"GetScaledBounds: rect[after] -> {rect}");

        return rect;
    }
}
