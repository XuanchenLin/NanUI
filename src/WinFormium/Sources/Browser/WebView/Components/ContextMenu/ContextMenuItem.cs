// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.Browser.ContextMenu;

public class ContextMenuItem
{
    public string? Text { get; set; }

    public int CommandId { get; set; }

    public Image? Icon { get; set; }

    public bool IsEnabled { get; set; }
    public bool IsSeperator { get; set; }
    public bool? IsChecked { get; set; }
    public CefMenuItemType MenuItemType { get; set; } = CefMenuItemType.Command;
    public List<ContextMenuItem>? SubMenus { get; set; }

    public Keys? ShortKeys { get; set; }
}
