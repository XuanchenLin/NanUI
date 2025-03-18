// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

partial class _FackUnusedClass
{

}

internal abstract class DirectCompositionTransparencyForm : FramelessWindowBase
{
    protected override bool IsWindowTransparent => true;

    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;

            cp.ExStyle |= (int)User32.WindowStylesEx.WS_EX_NOREDIRECTIONBITMAP;


            return cp;
        }
    }

    public DirectCompositionTransparencyForm()
    : base(FramelessWindowType.GDI)
    {
        ShowBorder = false;
    }
}
