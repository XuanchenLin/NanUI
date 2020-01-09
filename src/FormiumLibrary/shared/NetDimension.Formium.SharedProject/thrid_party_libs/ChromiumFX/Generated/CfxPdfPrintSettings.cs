// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing PDF print settings.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxPdfPrintSettings : CfxStructure {

        public CfxPdfPrintSettings() : base(CfxApi.PdfPrintSettings.cfx_pdf_print_settings_ctor, CfxApi.PdfPrintSettings.cfx_pdf_print_settings_dtor) {}

        /// <summary>
        /// Page title to display in the header. Only used if |headerFooterEnabled|
        /// is set to true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string HeaderFooterTitle {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_title(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_title(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// URL to display in the footer. Only used if |headerFooterEnabled| is set
        /// to true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string HeaderFooterUrl {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_url(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_url(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Output page size in microns. If either of these values is less than or
        /// equal to zero then the default paper size (A4) will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int PageWidth {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_width(nativePtrUnchecked, value);
            }
        }

        public int PageHeight {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_page_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_page_height(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The percentage to scale the PDF by before printing (e.g. 50 is 50%).
        /// If this value is less than or equal to zero the default value of 100
        /// will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int ScaleFactor {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_scale_factor(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_scale_factor(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Margins in millimeters. Only used if |marginType| is set to
        /// PDF_PRINT_MARGIN_CUSTOM.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double MarginTop {
            get {
                double value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_top(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_top(nativePtrUnchecked, value);
            }
        }

        public double MarginRight {
            get {
                double value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_right(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_right(nativePtrUnchecked, value);
            }
        }

        public double MarginBottom {
            get {
                double value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_bottom(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_bottom(nativePtrUnchecked, value);
            }
        }

        public double MarginLeft {
            get {
                double value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_left(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_left(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Margin type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxPdfPrintMarginType MarginType {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_margin_type(nativePtrUnchecked, out value);
                return (CfxPdfPrintMarginType)value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_margin_type(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Set to true (1) to print headers and footers or false (0) to not print
        /// headers and footers.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool HeaderFooterEnabled {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_header_footer_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_header_footer_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to print the selection only or false (0) to print all.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool SelectionOnly {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_selection_only(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_selection_only(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) for landscape mode or false (0) for portrait mode.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool Landscape {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_landscape(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_landscape(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to print background graphics or false (0) to not print
        /// background graphics.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool BackgroundsEnabled {
            get {
                int value;
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_get_backgrounds_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.PdfPrintSettings.cfx_pdf_print_settings_set_backgrounds_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

    }
}
