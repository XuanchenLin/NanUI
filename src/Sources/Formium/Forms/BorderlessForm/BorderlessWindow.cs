// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms.BorderlessForm;

partial class _FackUnusedClass
{

}

internal class BorderlessWindow : WindowBorderlessForm
{
    public BorderlessFormStyle Style { get; }

    public BorderlessWindow(BorderlessFormStyle style)
    {
        Style = style;

        EnableHitTest = Style.Sizable;

        ShadowColor = Style.ShadowColor;
        InactiveShadowColor = Style.InactiveShadowColor;

        ShowBorder = Style.ShowBorder;

        if (!style.Sizable)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        if (ShowBorder)
        {
            BorderColor = Style.BorderColor;
            InactiveBorderColor = Style.InactiveBorderColor;
        }

        WindowShadowEffect = Style.WindowShadowEffect;
    }

    protected override bool EnableHitTest { get; }

    protected override void DefWndProc(ref Message m)
    {
        var retval = Style.OnDefWndProc?.Invoke(ref m) ?? false;

        if (!retval)
        {
            base.DefWndProc(ref m);
        }
    }

    protected override void WndProc(ref Message m)
    {
        var retval = Style.OnWndProc?.Invoke(ref m) ?? false;

        if (!retval)
        {
            base.WndProc(ref m);
        }

    }
}
