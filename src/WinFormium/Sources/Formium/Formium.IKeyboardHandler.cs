// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : IKeyboardHandler
{
    #region interface
    bool IKeyboardHandler.OnKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, nint osEvent)
    {
        var retval = KeyboardHandler?.OnKeyEvent(browser, keyEvent, osEvent) ?? false;

        return retval ? retval : OnKeyEventCore(browser, keyEvent, osEvent);
    }

    bool IKeyboardHandler.OnPreKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, nint osEvent, out bool isKeyboardShortcut)
    {
        isKeyboardShortcut = false;

        var retval = KeyboardHandler?.OnPreKeyEvent(browser, keyEvent, osEvent, out isKeyboardShortcut) ?? false;

        return retval ? retval : OnPreKeyEventCore(browser, keyEvent, osEvent, out isKeyboardShortcut);
    }
    #endregion

    #region implements
    private bool OnKeyEventCore(CefBrowser browser, CefKeyEvent keyEvent, nint osEvent)
    {
        var args = new KeyEventEventArgs(browser, keyEvent);

        OnKeyEvent(args);

        return args.Handled;
    }

    private bool OnPreKeyEventCore(CefBrowser browser, CefKeyEvent keyEvent, nint os_event, out bool isKeyboardShortcut)
    {
        var args = new BeforeKeyEventEventArgs(browser, keyEvent);

        OnPreKeyEvent(args);

        isKeyboardShortcut = args.IsKeyboardShortcut;

        return args.Handled;
    }
    #endregion
}
