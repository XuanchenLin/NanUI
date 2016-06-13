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
	/// Browser initialization settings. Specify NULL or 0 to get the recommended
	/// default values. The consequences of using custom values may not be well
	/// tested. Many of these and other settings can also configured using command-
	/// line switches.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxBrowserSettings : CfxStructure {

        static CfxBrowserSettings () {
            CfxApiLoader.LoadCfxBrowserSettingsApi();
        }

        internal static CfxBrowserSettings Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxBrowserSettings(nativePtr);
        }

        internal static CfxBrowserSettings WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxBrowserSettings(nativePtr, CfxApi.cfx_browser_settings_dtor);
        }

        public CfxBrowserSettings() : base(CfxApi.cfx_browser_settings_ctor, CfxApi.cfx_browser_settings_dtor) {}
        internal CfxBrowserSettings(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxBrowserSettings(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        /// <summary>
        /// The maximum rate in frames per second (fps) that CfxRenderHandler.OnPaint
        /// will be called for a windowless browser. The actual fps may be lower if
        /// the browser cannot generate frames at the requested rate. The minimum
        /// value is 1 and the maximum value is 60 (default 30). This value can also be
        /// changed dynamically via CfxBrowserHost.SetWindowlessFrameRate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int WindowlessFrameRate {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_windowless_frame_rate(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_browser_settings_set_windowless_frame_rate(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The below values map to WebPreferences settings.
        /// Font settings.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string StandardFontFamily {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_standard_font_family(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_standard_font_family(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public string FixedFontFamily {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_fixed_font_family(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_fixed_font_family(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public string SerifFontFamily {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_serif_font_family(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_serif_font_family(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public string SansSerifFontFamily {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_sans_serif_font_family(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_sans_serif_font_family(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public string CursiveFontFamily {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_cursive_font_family(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_cursive_font_family(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public string FantasyFontFamily {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_fantasy_font_family(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_fantasy_font_family(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public int DefaultFontSize {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_default_font_size(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_browser_settings_set_default_font_size(nativePtrUnchecked, value);
            }
        }

        public int DefaultFixedFontSize {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_default_fixed_font_size(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_browser_settings_set_default_fixed_font_size(nativePtrUnchecked, value);
            }
        }

        public int MinimumFontSize {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_minimum_font_size(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_browser_settings_set_minimum_font_size(nativePtrUnchecked, value);
            }
        }

        public int MinimumLogicalFontSize {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_minimum_logical_font_size(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_browser_settings_set_minimum_logical_font_size(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Default encoding for Web content. If empty "ISO-8859-1" will be used. Also
        /// configurable using the "default-encoding" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string DefaultEncoding {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_default_encoding(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_default_encoding(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Controls the loading of fonts from remote sources. Also configurable using
        /// the "disable-remote-fonts" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState RemoteFonts {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_remote_fonts(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_remote_fonts(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether JavaScript can be executed. Also configurable using the
        /// "disable-javascript" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState Javascript {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_javascript(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_javascript(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether JavaScript can be used for opening windows. Also
        /// configurable using the "disable-javascript-open-windows" command-line
        /// switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState JavascriptOpenWindows {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_javascript_open_windows(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_javascript_open_windows(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether JavaScript can be used to close windows that were not
        /// opened via JavaScript. JavaScript can still be used to close windows that
        /// were opened via JavaScript or that have no back/forward history. Also
        /// configurable using the "disable-javascript-close-windows" command-line
        /// switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState JavascriptCloseWindows {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_javascript_close_windows(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_javascript_close_windows(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether JavaScript can access the clipboard. Also configurable
        /// using the "disable-javascript-access-clipboard" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState JavascriptAccessClipboard {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_javascript_access_clipboard(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_javascript_access_clipboard(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether DOM pasting is supported in the editor via
        /// execCommand("paste"). The |javascriptAccessClipboard| setting must also
        /// be enabled. Also configurable using the "disable-javascript-dom-paste"
        /// command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState JavascriptDomPaste {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_javascript_dom_paste(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_javascript_dom_paste(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether the caret position will be drawn. Also configurable using
        /// the "enable-caret-browsing" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState CaretBrowsing {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_caret_browsing(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_caret_browsing(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether any plugins will be loaded. Also configurable using the
        /// "disable-plugins" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState Plugins {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_plugins(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_plugins(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether file URLs will have access to all URLs. Also configurable
        /// using the "allow-universal-access-from-files" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState UniversalAccessFromFileUrls {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_universal_access_from_file_urls(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_universal_access_from_file_urls(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether file URLs will have access to other file URLs. Also
        /// configurable using the "allow-access-from-files" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState FileAccessFromFileUrls {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_file_access_from_file_urls(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_file_access_from_file_urls(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether web security restrictions (same-origin policy) will be
        /// enforced. Disabling this setting is not recommend as it will allow risky
        /// security behavior such as cross-site scripting (XSS). Also configurable
        /// using the "disable-web-security" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState WebSecurity {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_web_security(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_web_security(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether image URLs will be loaded from the network. A cached image
        /// will still be rendered if requested. Also configurable using the
        /// "disable-image-loading" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState ImageLoading {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_image_loading(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_image_loading(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether standalone images will be shrunk to fit the page. Also
        /// configurable using the "image-shrink-standalone-to-fit" command-line
        /// switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState ImageShrinkStandaloneToFit {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_image_shrink_standalone_to_fit(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_image_shrink_standalone_to_fit(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether text areas can be resized. Also configurable using the
        /// "disable-text-area-resize" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState TextAreaResize {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_text_area_resize(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_text_area_resize(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether the tab key can advance focus to links. Also configurable
        /// using the "disable-tab-to-links" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState TabToLinks {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_tab_to_links(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_tab_to_links(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether local storage can be used. Also configurable using the
        /// "disable-local-storage" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState LocalStorage {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_local_storage(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_local_storage(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether databases can be used. Also configurable using the
        /// "disable-databases" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState Databases {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_databases(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_databases(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether the application cache can be used. Also configurable using
        /// the "disable-application-cache" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState ApplicationCache {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_application_cache(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_application_cache(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Controls whether WebGL can be used. Note that WebGL requires hardware
        /// support and may not work on all systems even when enabled. Also
        /// configurable using the "disable-webgl" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxState Webgl {
            get {
                int value;
                CfxApi.cfx_browser_settings_get_webgl(nativePtrUnchecked, out value);
                return (CfxState)value;
            }
            set {
                CfxApi.cfx_browser_settings_set_webgl(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Opaque background color used for the browser before a document is loaded
        /// and when no document color is specified. By default the background color
        /// will be the same as CfxSettings.BackgroundColor. Only the RGB compontents
        /// of the specified value will be used. The alpha component must greater than
        /// 0 to enable use of the background color but will be otherwise ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxColor BackgroundColor {
            get {
                uint value;
                CfxApi.cfx_browser_settings_get_background_color(nativePtrUnchecked, out value);
                return CfxColor.Wrap(value);
            }
            set {
                CfxApi.cfx_browser_settings_set_background_color(nativePtrUnchecked, CfxColor.Unwrap(value));
            }
        }

        /// <summary>
        /// Comma delimited ordered list of language codes without any whitespace that
        /// will be used in the "Accept-Language" HTTP header. May be set globally
        /// using the CfxBrowserSettings.AcceptLanguageList value. If both values are
        /// empty then "en-US,en" will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string AcceptLanguageList {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_browser_settings_get_accept_language_list(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_browser_settings_set_accept_language_list(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

    }
}
