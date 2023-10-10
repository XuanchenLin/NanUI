// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class DialogHandler : IDialogHandler
{
    bool IDialogHandler.OnFileDialog(CefBrowser browser, CefFileDialogMode mode, string title, string defaultFilePath, string[] acceptFilters, CefFileDialogCallback callback)
    {
        return OnFileDialog(browser, mode, title, defaultFilePath, acceptFilters, callback);
    }

    protected virtual bool OnFileDialog(CefBrowser browser, CefFileDialogMode mode, string title, string defaultFilePath, string[] acceptFilters, CefFileDialogCallback callback)
    {
        return false;
    }


}
