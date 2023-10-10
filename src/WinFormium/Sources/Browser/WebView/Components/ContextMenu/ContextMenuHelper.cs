// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.ContextMenu;

internal class ContextMenuHelper
{
    const int MENU_ID_USER_FIRST = 26500;
    const int MENU_ID_USER_LAST = 28400;






    public static bool IsEditingItem(CefMenuIdentifiers contextMenuId)
    {
        var intValue = (int)contextMenuId;
        return IsEditingItem(intValue);
    }

    public static bool IsEditingItem(int intValue)
    {
        return intValue >= (int)CefMenuIdentifiers.MENU_ID_UNDO && intValue <= (int)CefMenuIdentifiers.MENU_ID_SELECT_ALL;
    }

    public static bool IsUserDefinedItem(int intValue)
    {
        return intValue > MENU_ID_USER_FIRST && intValue < MENU_ID_USER_LAST;
    }



}
