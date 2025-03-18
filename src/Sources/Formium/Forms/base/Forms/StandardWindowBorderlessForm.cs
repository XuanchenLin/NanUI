// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;
partial class _FackUnusedClass
{

}


public abstract class StandardWindowBorderlessForm : FramelessWindowBase
{
    public bool EnableOffscreenRender { get; }

    protected bool EnableDirectComposition { get; }


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


    public StandardWindowBorderlessForm(bool enableOffscreenRender, bool enableDirectComposition)
        : base(FramelessWindowType.DWM)
    {
        EnableOffscreenRender = enableOffscreenRender;

        EnableDirectComposition = enableDirectComposition;
    }
}
