// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class JSDialogHandler : IJSDialogHandler
{
    bool IJSDialogHandler.OnBeforeUnloadDialog(CefBrowser browser, string messageText, bool isReload, CefJSDialogCallback callback)
    {
        return OnBeforeUnloadDialog(browser, messageText, isReload, callback);
    }

    void IJSDialogHandler.OnDialogClosed(CefBrowser browser)
    {
        OnDialogClosed(browser);
    }

    bool IJSDialogHandler.OnJSDialog(CefBrowser browser, string originUrl, CefJSDialogType dialogType, string message_text, string default_prompt_text, CefJSDialogCallback callback, out bool suppress_message)
    {
        return OnJSDialog(browser, originUrl, dialogType, message_text, default_prompt_text, callback, out suppress_message);
    }

    void IJSDialogHandler.OnResetDialogState(CefBrowser browser)
    {
        OnResetDialogState(browser);
    }

    protected virtual bool OnBeforeUnloadDialog(CefBrowser browser, string messageText, bool isReload, CefJSDialogCallback callback)
    {
        return false;
    }

    protected virtual void OnDialogClosed(CefBrowser browser)
    {
    }

    protected virtual bool OnJSDialog(CefBrowser browser, string originUrl, CefJSDialogType dialogType, string message_text, string default_prompt_text, CefJSDialogCallback callback, out bool suppress_message)
    {
        suppress_message = false;
        return false;
    }

    protected virtual void OnResetDialogState(CefBrowser browser)
    {
    }
}
