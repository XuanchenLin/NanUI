// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

partial class _FackUnusedClass
{

}


internal abstract class WindowBorderlessForm : FramelessWindowBase
{
    internal WindowShadowDecorator ShadowDecorator { get; }

    protected Color ShadowColor { get => ShadowDecorator.ShadowActiveColor; set => ShadowDecorator.ShadowActiveColor = value; }

    protected Color InactiveShadowColor { get => ShadowDecorator.ShadowInactiveColor; set => ShadowDecorator.ShadowInactiveColor = value; }

    protected ShadowEffect WindowShadowEffect { get => ShadowDecorator.WindowShadowEffect; set => ShadowDecorator.WindowShadowEffect = value; }




    public WindowBorderlessForm()
        : base(FramelessWindowType.GDI)
    {
        ShadowDecorator = new WindowShadowDecorator(this);
    }


}
