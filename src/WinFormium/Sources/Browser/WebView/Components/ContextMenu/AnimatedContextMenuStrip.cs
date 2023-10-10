// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.ComponentModel;

namespace WinFormium.Browser.ContextMenu;
internal class AnimatedContextMenuStrip : ContextMenuStrip
{
    private const uint AW_HOR_POSITIVE = 0x1;
    private const uint AW_HOR_NEGATIVE = 0x2;
    private const uint AW_VER_POSITIVE = 0x4;
    private const uint AW_VER_NEGATIVE = 0x8;
    private const uint AW_CENTER = 0x10;
    private const uint AW_HIDE = 0x10000;
    private const uint AW_ACTIVATE = 0x20000;
    private const uint AW_SLIDE = 0x40000;
    private const uint AW_BLEND = 0x80000;

    public bool DarkMode { get; set; } = false;

    public AnimatedContextMenuStrip() {


    }

    public AnimatedContextMenuStrip(IContainer container) : this()
    {
        if (container == null)
        {
            throw new ArgumentNullException("container is null");
        }
        container.Add(this);
    }

    protected override  void OnOpening(CancelEventArgs e)
    {
        base.OnOpening(e);


        Opacity = 0;

        FadeOut();

        //User32.AnimateWindow(Handle, 50, AW_SLIDE | AW_VER_POSITIVE);

    }


    async void FadeOut()
    {
        if (InvokeRequired)
        {
            Invoke(new Action(FadeOut));
            return;
        }

        Opacity += 0.1d;
        await Task.Delay(10);

        if (Opacity >= 1)
        {
            return;
        };

        FadeOut();
    }


}
