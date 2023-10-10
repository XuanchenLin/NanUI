// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Margin type for PDF printing.
/// </summary>
public enum CefPdfPrintMarginType
{
    /// <summary>
    /// Default margins of 1cm (~0.4 inches).
    /// </summary>
    Default,

    /// <summary>
    /// No margins.
    /// </summary>
    None,

    /// <summary>
    /// Custom margins using the |margin_*| values from cef_pdf_print_settings_t.
    /// </summary>
    Custom,
}
