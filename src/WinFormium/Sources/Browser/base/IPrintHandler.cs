// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormium.Browser;

public interface IPrintHandler
{
    CefSize GetPdfPaperSize(CefBrowser browser, int deviceUnitsPerInch);
    bool OnPrintDialog(CefBrowser browser, bool hasSelection, CefPrintDialogCallback callback);
    bool OnPrintJob(CefBrowser browser, string documentName, string pdfFilePath, CefPrintJobCallback callback);
    void OnPrintReset(CefBrowser browser);
    void OnPrintSettings(CefBrowser browser, CefPrintSettings settings, bool getDefaults);
    void OnPrintStart(CefBrowser browser);
}
