// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Structure representing PDF print settings. These values match the parameters
/// supported by the DevTools Page.printToPDF function. See
/// https://chromedevtools.github.io/devtools-protocol/tot/Page/#method-printToPDF
/// </summary>
public sealed class CefPdfPrintSettings
{
    /// <summary>
    /// Set to true (1) for landscape mode or false (0) for portrait mode.
    /// </summary>
    public bool Landscape { get; set; }

    /// <summary>
    /// Set to true (1) to print background graphics.
    /// </summary>
    public bool PrintBackground { get; set; }

    /// <summary>
    /// The percentage to scale the PDF by before printing (e.g. .5 is 50%).
    /// If this value is less than or equal to zero the default value of 1.0
    /// will be used.
    /// </summary>
    public double Scale { get; set; }

    /// <summary>
    /// Output paper size in inches. If either of these values is less than or
    /// equal to zero then the default paper size (letter, 8.5 x 11 inches) will
    /// be used.
    /// </summary>
    public double PaperWidth { get; set; }
    public double PaperHeight { get; set; }

    /// <summary>
    /// Set to true (1) to prefer page size as defined by css. Defaults to false
    /// (0), in which case the content will be scaled to fit the paper size.
    /// </summary>
    public bool PreferCssPageSize { get; set; }

    /// <summary>
    /// Margin type.
    /// </summary>
    public CefPdfPrintMarginType MarginType { get; set; }

    /// <summary>
    /// Margins in inches. Only used if |margin_type| is set to
    /// PDF_PRINT_MARGIN_CUSTOM.
    /// </summary>
    public double MarginTop { get; set; }
    public double MarginRight { get; set; }
    public double MarginBottom { get; set; }
    public double MarginLeft { get; set; }

    /// <summary>
    /// Paper ranges to print, one based, e.g., '1-5, 8, 11-13'. Pages are printed
    /// in the document order, not in the order specified, and no more than once.
    /// Defaults to empty string, which implies the entire document is printed.
    /// The page numbers are quietly capped to actual page count of the document,
    /// and ranges beyond the end of the document are ignored. If this results in
    /// no pages to print, an error is reported. It is an error to specify a range
    /// with start greater than end.
    /// </summary>
    public string PageRanges { get; set; }

    /// <summary>
    /// Set to true (1) to display the header and/or footer. Modify
    /// |header_template| and/or |footer_template| to customize the display.
    /// </summary>
    public bool DisplayHeaderFooter { get; set; }

    /// <summary>
    /// HTML template for the print header. Only displayed if
    /// |display_header_footer| is true (1). Should be valid HTML markup with
    /// the following classes used to inject printing values into them:
    ///
    /// - date: formatted print date
    /// - title: document title
    /// - url: document location
    /// - pageNumber: current page number
    /// - totalPages: total pages in the document
    ///
    /// For example, "<span class=title></span>" would generate a span containing
    /// the title.
    /// </summary>
    public string HeaderTemplate { get; set; }

    /// <summary>
    /// HTML template for the print footer. Only displayed if
    /// |display_header_footer| is true (1). Uses the same format as
    /// |header_template|.
    /// </summary>
    public string FooterTemplate { get; set; }

    internal unsafe cef_pdf_print_settings_t* ToNative()
    {
        var ptr = cef_pdf_print_settings_t.Alloc();

        ptr->landscape = Landscape ? 1 : 0;
        ptr->print_background = PrintBackground ? 1 : 0;
        ptr->scale = Scale;
        ptr->paper_width = PaperWidth;
        ptr->paper_height = PaperHeight;
        ptr->prefer_css_page_size = PreferCssPageSize ? 1 : 0;
        ptr->margin_type = MarginType;
        ptr->margin_top = MarginTop;
        ptr->margin_right = MarginRight;
        ptr->margin_bottom = MarginBottom;
        ptr->margin_left = MarginLeft;
        cef_string_t.Copy(PageRanges, &ptr->page_ranges);
        ptr->display_header_footer = DisplayHeaderFooter ? 1 : 0;
        cef_string_t.Copy(HeaderTemplate, &ptr->header_template);
        cef_string_t.Copy(FooterTemplate, &ptr->footer_template);

        return ptr;
    }
}
