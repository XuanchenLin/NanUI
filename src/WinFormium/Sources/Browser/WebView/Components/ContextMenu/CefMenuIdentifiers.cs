// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.ContextMenu;

internal enum CefMenuIdentifiers
{
    NOT_FOUND = -1,

    // Navigation.
    MENU_ID_BACK = 100,
    MENU_ID_FORWARD = 101,
    MENU_ID_RELOAD = 102,
    MENU_ID_RELOAD_NOCACHE = 103,
    MENU_ID_STOPLOAD = 104,

    // Editing.
    MENU_ID_UNDO = 110,
    MENU_ID_REDO = 111,
    MENU_ID_CUT = 112,
    MENU_ID_COPY = 113,
    MENU_ID_PASTE = 114,
    MENU_ID_DELETE = 115,
    MENU_ID_SELECT_ALL = 116,

    // Miscellaneous.
    MENU_ID_FIND = 130,
    MENU_ID_PRINT = 131,
    MENU_ID_VIEW_SOURCE = 132,

    // All user-defined menu IDs should come between MENU_ID_USER_FIRST and
    // MENU_ID_USER_LAST to avoid overlapping the Chromium and CEF ID ranges
    // defined in the tools/gritsettings/resource_ids file.
    //MENU_ID_USER_FIRST = 26500,
    //MENU_ID_USER_LAST = 28500,

    MENU_ID_SHOW_DEVTOOLS = 28499,
    MENU_ID_HIDE_DEVTOOLS = 28498
}
