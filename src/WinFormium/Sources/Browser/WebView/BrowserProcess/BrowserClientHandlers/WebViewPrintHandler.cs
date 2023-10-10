// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewPrintHandler : CefPrintHandler
{
    public IPrintHandler Handler { get; }

    public WebViewPrintHandler(IPrintHandler handler)
    {
        Handler = handler;
    }

    protected override CefSize GetPdfPaperSize(CefBrowser browser, int deviceUnitsPerInch)
    {
        return Handler.GetPdfPaperSize(browser, deviceUnitsPerInch);
    }

    protected override bool OnPrintDialog(CefBrowser browser, bool hasSelection, CefPrintDialogCallback callback)
    {
        return Handler.OnPrintDialog(browser, hasSelection, callback);
    }

    protected override bool OnPrintJob(CefBrowser browser, string documentName, string pdfFilePath, CefPrintJobCallback callback)
    {
        return Handler.OnPrintJob(browser, documentName, pdfFilePath, callback);
    }

    protected override void OnPrintReset(CefBrowser browser)
    {
        Handler.OnPrintReset(browser);
    }

    protected override void OnPrintSettings(CefBrowser browser, CefPrintSettings settings, bool getDefaults)
    {
        Handler.OnPrintSettings(browser, settings, getDefaults);
    }

    protected override void OnPrintStart(CefBrowser browser)
    {
        Handler.OnPrintStart(browser);
    }
}
