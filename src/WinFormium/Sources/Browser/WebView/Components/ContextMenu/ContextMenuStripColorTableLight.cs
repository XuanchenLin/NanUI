// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.ContextMenu;

internal class ContextMenuStripColorTableLight : ProfessionalColorTable
{
    static readonly Color MENU_BACK_COLOR = Color.FromArgb(0xfa, 0xfa, 0xf9);

    static readonly Color MENU_BORDER_COLOR = Color.FromArgb(0xc7, 0xc7, blue: 0xc7);

    static readonly Color MENU_HIGHLIGHT_COLOR = Color.FromArgb(0xed, 0xed, blue: 0xed);

    public override Color MenuBorder => MENU_BORDER_COLOR;

    public override Color MenuItemBorder => Color.Transparent;



    public override Color MenuItemSelected => MENU_HIGHLIGHT_COLOR;

    public override Color MenuItemSelectedGradientBegin => MENU_HIGHLIGHT_COLOR;
    public override Color MenuItemSelectedGradientEnd => MENU_HIGHLIGHT_COLOR;


    public override Color ToolStripDropDownBackground => MENU_BACK_COLOR;
    public override Color ImageMarginGradientBegin => MENU_BACK_COLOR;
    public override Color ImageMarginGradientMiddle => MENU_BACK_COLOR;
    public override Color ImageMarginGradientEnd => MENU_BACK_COLOR;
}
