// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985


using WinFormium.Forms.SystemForm;

namespace WinFormium.Forms;

public sealed class SystemFormStyle : FormStyle
{
    private bool _useDirectCompositon = false;


    internal protected override bool UseBrowserHitTest { get; set; }
    internal Func<Bitmap?>? ShouldDrawSpalsh { get; set; }

    internal SystemFormStyle(Formium formium) : base(formium)
    {
    }

    public bool TitleBar { get; set; } = true;

    protected internal override bool HasSystemTitleBar { get; set; }


    public override CreateHostWindowDelegate CreateHostWindow()
    {
        return () =>
        {
            StandardWindowBase target;

            if (TitleBar)
            {
                UseBrowserHitTest = false;
                HasSystemTitleBar = true;
                target = new SystemStandardWindow(this);

            }
            else
            {
                UseBrowserHitTest = true;
                HasSystemTitleBar = false;
                target = new SystemBorderlessWindow(this);
            }

            return target;
        };
    }
}

public static class SystemFormStyleExtension
{
    public static SystemFormStyle UseSystemForm(this WindowStyleBuilder builder)
    {
        return new SystemFormStyle(builder.FormiumInstance);
    }
}

