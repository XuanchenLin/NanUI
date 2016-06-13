// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Structure representing PDF print settings.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxPdfPrintSettings : CfxStructure {

        static CfxPdfPrintSettings () {
            CfxApiLoader.LoadCfxPdfPrintSettingsApi();
        }

        public CfxPdfPrintSettings() : base(CfxApi.cfx_pdf_print_settings_ctor, CfxApi.cfx_pdf_print_settings_dtor) {}

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
                CfxApi.cfx_pdf_print_settings_get_header_footer_title(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_pdf_print_settings_set_header_footer_title(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
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
                CfxApi.cfx_pdf_print_settings_get_header_footer_url(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_pdf_print_settings_set_header_footer_url(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
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
                CfxApi.cfx_pdf_print_settings_get_page_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_page_width(nativePtrUnchecked, value);
            }
        }

        public int PageHeight {
            get {
                int value;
                CfxApi.cfx_pdf_print_settings_get_page_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_page_height(nativePtrUnchecked, value);
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
                CfxApi.cfx_pdf_print_settings_get_margin_top(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_margin_top(nativePtrUnchecked, value);
            }
        }

        public double MarginRight {
            get {
                double value;
                CfxApi.cfx_pdf_print_settings_get_margin_right(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_margin_right(nativePtrUnchecked, value);
            }
        }

        public double MarginBottom {
            get {
                double value;
                CfxApi.cfx_pdf_print_settings_get_margin_bottom(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_margin_bottom(nativePtrUnchecked, value);
            }
        }

        public double MarginLeft {
            get {
                double value;
                CfxApi.cfx_pdf_print_settings_get_margin_left(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_margin_left(nativePtrUnchecked, value);
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
                CfxApi.cfx_pdf_print_settings_get_margin_type(nativePtrUnchecked, out value);
                return (CfxPdfPrintMarginType)value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_margin_type(nativePtrUnchecked, (int)value);
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
                CfxApi.cfx_pdf_print_settings_get_header_footer_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_header_footer_enabled(nativePtrUnchecked, value ? 1 : 0);
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
                CfxApi.cfx_pdf_print_settings_get_selection_only(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_selection_only(nativePtrUnchecked, value ? 1 : 0);
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
                CfxApi.cfx_pdf_print_settings_get_landscape(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_landscape(nativePtrUnchecked, value ? 1 : 0);
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
                CfxApi.cfx_pdf_print_settings_get_backgrounds_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_pdf_print_settings_set_backgrounds_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

    }
}
