// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;
public abstract class FocusHandler : IFocusHandler
{
    void IFocusHandler.OnGotFocus(CefBrowser browser)
    {
        OnGotFocus(browser);
    }

    void IFocusHandler.OnTakeFocus(CefBrowser browser, bool next)
    {
        OnTakeFocus(browser, next);
    }

    bool IFocusHandler.OnSetFocus(CefBrowser browser, CefFocusSource source)
    {
        return OnSetFocus(browser, source);
    }

    internal protected virtual void OnGotFocus(CefBrowser browser)
    {
    }

    internal protected virtual void OnTakeFocus(CefBrowser browser, bool next)
    {
    }

    internal protected virtual bool OnSetFocus(CefBrowser browser, CefFocusSource source)
    {
        return false;
    }
}
