// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using NetDimension.NanUI.Forms.TransparencyForm;

namespace NetDimension.NanUI.Forms;

public class TransparencyFormStyle : FormStyle
{
    internal TransparencyFormStyle(Formium formium) : base(formium)
    {
        OffScreenRenderEnabled = true;
    }

    public TransparencyFormRenderType RenderType { get; set; } = TransparencyFormRenderType.Direct2D;
    public Padding ExcludedBorderArea { get; set; } = Padding.Empty;
    //public Padding ResizerGripSize { get; set; } = Padding.Empty;
    //public TransparencyFormResizerPosition ResizerPosition { get; set; } = TransparencyFormResizerPosition.Middle;
    internal protected override bool UseBrowserHitTest { get; set; } = false;
    protected internal override bool HasSystemTitleBar { get; set; } = false;

    //public Color BorderColor { get; set; } = Color.FromArgb(0xB2, 0xB2, blue: 0xB2);
    //public Color InactiveBorderColor { get; set; } = Color.Transparent;
    //public bool ShowBorder { get; set; } = false;


    public override CreateHostWindowDelegate CreateHostWindow()
    {
        return () =>
        {
            StandardWindowBase target;

            if (RenderType == TransparencyFormRenderType.DirectCompositon)
            {
                target = new DirectCompositionWindow(this);
            }
            else
            {
                target = new LayeredWindow(this);
            }

            return target;
        };
    }
}

public static class TransparencyFormStyleExtension
{
    public static TransparencyFormStyle UseTransparencyForm(this WindowStyleBuilder builder)
    {
        return new TransparencyFormStyle(builder.FormiumInstance);
    }
}
