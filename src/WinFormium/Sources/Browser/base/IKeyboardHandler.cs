// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IKeyboardHandler
{
    bool OnPreKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, nint osEvent, out bool isKeyboardShortcut);
    bool OnKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, nint osEvent);
}
