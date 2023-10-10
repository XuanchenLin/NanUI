// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Forms.KioskForm;

partial class _FackUnusedClass
{

}


internal class KioskWindow : StandardWindowBase
{
    public KisokFormStyle Style { get; }


    public KioskWindow(KisokFormStyle style)
    {
        Style = style;

        FormBorderStyle = FormBorderStyle.None;

        ShowInTaskbar = false;
    }



    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);


        if (Style.DisableTaskBar)
        {
            var taskBarHwnd = User32.FindWindow("Shell_traywnd", null);

            User32.ShowWindow(taskBarHwnd, ShowWindowCommand.SW_HIDE);
        }


    }



    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        if (Style.DisableTaskBar)
        {
            var taskBarHwnd = User32.FindWindow("Shell_traywnd", null);

            User32.ShowWindow(taskBarHwnd, ShowWindowCommand.SW_SHOWNORMAL);
        }
    }

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
