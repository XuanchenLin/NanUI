// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormium;
public abstract class PrintHandler : IPrintHandler
{
    CefSize IPrintHandler.GetPdfPaperSize(CefBrowser browser, int deviceUnitsPerInch)
    {
        return GetPdfPaperSize(browser, deviceUnitsPerInch);
    }

    bool IPrintHandler.OnPrintDialog(CefBrowser browser, bool hasSelection, CefPrintDialogCallback callback)
    {
        return OnPrintDialog(browser, hasSelection, callback);
    }

    bool IPrintHandler.OnPrintJob(CefBrowser browser, string documentName, string pdfFilePath, CefPrintJobCallback callback)
    {
        return OnPrintJob(browser, documentName, pdfFilePath, callback);
    }

    void IPrintHandler.OnPrintReset(CefBrowser browser)
    {
        OnPrintReset(browser);
    }

    void IPrintHandler.OnPrintSettings(CefBrowser browser, CefPrintSettings settings, bool getDefaults)
    {
        OnPrintSettings(browser, settings, getDefaults);
    }

    void IPrintHandler.OnPrintStart(CefBrowser browser)
    {
        OnPrintStart(browser);
    }

    protected virtual void OnPrintStart(CefBrowser browser)
    {
    }

    protected virtual void OnPrintSettings(CefBrowser browser, CefPrintSettings settings, bool getDefaults)
    {
    }

    protected virtual bool OnPrintDialog(CefBrowser browser, bool hasSelection, CefPrintDialogCallback callback)
    {
        return false;
    }

    protected virtual bool OnPrintJob(CefBrowser browser, string documentName, string pdfFilePath, CefPrintJobCallback callback)
    {
        return false;
    }

    protected virtual void OnPrintReset(CefBrowser browser)
    {
    }

    protected virtual CefSize GetPdfPaperSize(CefBrowser browser, int deviceUnitsPerInch)
    {
        return new CefSize();
    }


}
