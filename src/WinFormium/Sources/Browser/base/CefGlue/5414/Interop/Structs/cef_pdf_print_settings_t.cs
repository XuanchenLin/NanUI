// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_pdf_print_settings_t
{
    public int landscape;
    public int print_background;
    public double scale;
    public double paper_width;
    public double paper_height;
    public int prefer_css_page_size;
    public CefPdfPrintMarginType margin_type;
    public double margin_top;
    public double margin_right;
    public double margin_bottom;
    public double margin_left;
    public cef_string_t page_ranges;
    public int display_header_footer;
    public cef_string_t header_template;
    public cef_string_t footer_template;

    internal static void Clear(cef_pdf_print_settings_t* ptr)
    {
        libcef.string_clear(&ptr->page_ranges);
        libcef.string_clear(&ptr->header_template);
        libcef.string_clear(&ptr->footer_template);
    }

    #region Alloc & Free
    private static int _sizeof;

    static cef_pdf_print_settings_t()
    {
        _sizeof = Marshal.SizeOf(typeof(cef_pdf_print_settings_t));
    }

    public static cef_pdf_print_settings_t* Alloc()
    {
        var ptr = (cef_pdf_print_settings_t*)Marshal.AllocHGlobal(_sizeof);
        *ptr = new cef_pdf_print_settings_t();
        return ptr;
    }

    public static void Free(cef_pdf_print_settings_t* ptr)
    {
        Marshal.FreeHGlobal((IntPtr)ptr);
    }
    #endregion
}
