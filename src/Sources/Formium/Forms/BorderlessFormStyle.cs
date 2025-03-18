// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using NetDimension.NanUI.Forms.BorderlessForm;

namespace NetDimension.NanUI.Forms;
public sealed class BorderlessFormStyle : FormStyle
{
    internal BorderlessFormStyle(Formium formium) : base(formium)
    {
    }

    public Color ShadowColor { get; set; } = ColorTranslator.FromHtml("#99303030");

    public Color InactiveShadowColor { get; set; } = Color.Transparent;
    public ShadowEffect WindowShadowEffect { get; set; } = ShadowEffect.Normal;

    public bool ShowBorder { get; set; } = false;

    public Color BorderColor { get; set; } = Color.FromArgb(0xB2, 0xB2, blue: 0xB2);

    public Color InactiveBorderColor { get; set; } = Color.Transparent;
    internal protected override bool UseBrowserHitTest { get; set; } = true;
    protected internal override bool HasSystemTitleBar { get; set; } = false;

    public override CreateHostWindowDelegate CreateHostWindow()
    {
        return () =>
        {
            var target = new BorderlessWindow(this);




            return target;
        };
    }
}

public static class BorderlessFormStyleExtension
{
    public static BorderlessFormStyle UseBorderlessForm(this WindowStyleBuilder builder)
    {
        return new BorderlessFormStyle(builder.FormiumInstance);
    }
}

