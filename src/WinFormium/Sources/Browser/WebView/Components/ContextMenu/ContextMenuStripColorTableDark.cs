// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.ContextMenu;

internal class ContextMenuStripColorTableDark : ProfessionalColorTable
{
    static readonly Color MENU_BACK_COLOR = Color.FromArgb(0x2e, 0x2e, 0x2e);

    static readonly Color MENU_BORDER_COLOR = Color.FromArgb(0x42, 0x42, blue: 0x42);

    static readonly Color MENU_HIGHLIGHT_COLOR = Color.FromArgb(0x4d, 0x4d, blue: 0x4d);

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
