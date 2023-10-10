// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : IFocusHandler
{
    #region interface
    void IFocusHandler.OnGotFocus(CefBrowser browser)
    {
        FocusHandler?.OnGotFocus(browser);

        OnGotFocusCore(browser);
    }

    bool IFocusHandler.OnSetFocus(CefBrowser browser, CefFocusSource source)
    {
        var retval = FocusHandler?.OnSetFocus(browser, source) ?? false;

        return retval ? retval : OnSetFocusCore(browser, source);
    }

    void IFocusHandler.OnTakeFocus(CefBrowser browser, bool next)
    {
        FocusHandler?.OnTakeFocus(browser, next);

        OnTakeFocusCore(browser, next);
    }
    #endregion

    #region implements
    private void OnTakeFocusCore(CefBrowser browser, bool next)
    {
        var args = new BrowserEventArgs(browser);

        OnTakeFocus(args);

    }

    private void OnGotFocusCore(CefBrowser browser)
    {
        var args = new BrowserEventArgs(browser);


        OnGotFocus(args);
    }

    private bool OnSetFocusCore(CefBrowser browser, CefFocusSource source)
    {
        var args = new SetFocusEventArgs(browser,source);

        OnSetFocus(args);

        return args.Handled;
    }

    #endregion
}
