// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.Forms.SystemForm;

partial class _FackUnusedClass
{

}

internal class SystemStandardWindow : StandardWindowForm
{

    public SystemStandardWindow(SystemFormStyle style)
        : base(false, false)
    {
        Style = style;

        if (!style.Sizable)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }

    public SystemFormStyle Style { get; }

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
