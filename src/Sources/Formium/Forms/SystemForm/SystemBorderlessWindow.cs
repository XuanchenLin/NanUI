// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.Forms.OffscreenRender;

namespace NetDimension.NanUI.Forms.SystemForm;

partial class _FackUnusedClass
{

}

internal class SystemBorderlessWindow : StandardWindowBorderlessForm
{
    private WindowAccentCompositor? _compositor;


    internal IOffscreenRender? OffscreenRender { get; }

    protected override bool CanEnableIme { get; }

    public SystemBorderlessWindow(SystemFormStyle style)
        : base(style.OffScreenRenderEnabled, style.UseDirectComposition)
    {
        Style = style;


        if (!style.Sizable)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        else
        {
            EnableHitTest = true;
        }



        if (style.OffScreenRenderEnabled)
        {
            CanEnableIme = true;

            ImeMode = ImeMode.Disable;

            if (style.UseDirectComposition)
            {
                OffscreenRender = new DirectCompositionOffscreenRender(this);
            }
            else
            {
                OffscreenRender = new Direct3DOffscreenRender(this);
            }

            style.OnOffscreenPaint = OnOffscreenPaint;

        }

    }

    public SystemFormStyle Style { get; }

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


    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (Style.OffScreenRenderEnabled && Style.BackdropType != SystemFormBackdropType.None)
        {
            if (Style.BackdropType != SystemFormBackdropType.Surface)
            {
                DwmSetWindowAttribute(Handle, DWMWINDOWATTRIBUTE.DWMWA_USE_HOSTBACKDROPBRUSH, true);

                if (Style.BackdropType == SystemFormBackdropType.Acrylic)
                {
                    _compositor = new WindowAccentCompositor(this);
                    _compositor.Color = Color.Transparent;
                    _compositor.IsEnabled = true;

                }
                else
                {
                    switch (Style.BackdropType)
                    {
                        case SystemFormBackdropType.Mica:
                            DwmSetWindowAttribute(Handle, DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, DWM_SYSTEMBACKDROP_TYPE.DWMSBT_MAINWINDOW);
                            break;
                        case SystemFormBackdropType.Transient:
                            DwmSetWindowAttribute(Handle, DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, DWM_SYSTEMBACKDROP_TYPE.DWMSBT_TRANSIENTWINDOW);
                            break;
                        case SystemFormBackdropType.MicaAlt:
                            DwmSetWindowAttribute(Handle, DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, DWM_SYSTEMBACKDROP_TYPE.DWMSBT_TABBEDWINDOW);
                            break;
                    }
                }
            }
        }
    }

    private void OnOffscreenPaint(CefPaintElementType type, IntPtr bufferPtr, int width, int height,bool isPopupShown, CefRectangle? popupRect = null)
    {
        OffscreenRender?.Paint(type, bufferPtr, width, height, isPopupShown, popupRect);
    }


}
