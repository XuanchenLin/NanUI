// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Browser;
internal class WebViewDialogHandler : CefDialogHandler
{
    public IDialogHandler Handler { get; }

    public WebViewDialogHandler(IDialogHandler handler)
    {
        Handler = handler;
    }

    protected override bool OnFileDialog(CefBrowser browser, CefFileDialogMode mode, string title, string defaultFilePath, string[] acceptFilters, CefFileDialogCallback callback)
    {
        return Handler.OnFileDialog(browser, mode, title, defaultFilePath, acceptFilters, callback);
    }
}
