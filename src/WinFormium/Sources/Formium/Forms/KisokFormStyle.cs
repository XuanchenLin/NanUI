// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Forms.KioskForm;

namespace WinFormium.Forms;
public sealed class KisokFormStyle : FormStyle
{
    internal KisokFormStyle(Formium formium) : base(formium)
    {
        ShowInTaskbar = false;
        Sizable = false;
        Maximizable = false;
        Minimizable = false;

        WindowState = FormiumWindowState.Maximized;
    }

    public bool DisableTaskBar { get; set; } = false;

    public Screen? TargetScreen { get; set; }
    internal protected override bool UseBrowserHitTest { get; set; } = false;
    protected internal override bool HasSystemTitleBar { get; set; } = false;

    public override CreateHostWindowDelegate CreateHostWindow()
    {
        return () => {
            var target = new KioskWindow(this);

            return target;
        };
    }

    protected internal override void OverwriteHostWindowProperties(Form form)
    {


        var scr = Screen.PrimaryScreen!;


        if (TargetScreen != null)
        {
            scr = TargetScreen;
        }

        form.Location = new Point(scr.Bounds.Left, scr.Bounds.Top);

    }
}

public static class KisokFormStyleExtension
{
    public static KisokFormStyle UseKisokForm(this WindowStyleBuilder builder)
    {
        return new KisokFormStyle(builder.FormiumInstance);
    }
}




