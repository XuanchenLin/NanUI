// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing IME composition underline information. This is a thin
    /// wrapper around Blink's WebCompositionUnderline class and should be kept in
    /// sync with that.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxCompositionUnderline : CfxStructure {

        public CfxCompositionUnderline() : base(CfxApi.CompositionUnderline.cfx_composition_underline_ctor, CfxApi.CompositionUnderline.cfx_composition_underline_dtor) {}

        /// <summary>
        /// Underline character range.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxRange Range {
            get {
                IntPtr value;
                CfxApi.CompositionUnderline.cfx_composition_underline_get_range(nativePtrUnchecked, out value);
                return CfxRange.Wrap(value);
            }
            set {
                CfxApi.CompositionUnderline.cfx_composition_underline_set_range(nativePtrUnchecked, CfxRange.Unwrap(value));
            }
        }

        /// <summary>
        /// Text color.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxColor Color {
            get {
                uint value;
                CfxApi.CompositionUnderline.cfx_composition_underline_get_color(nativePtrUnchecked, out value);
                return CfxColor.Wrap(value);
            }
            set {
                CfxApi.CompositionUnderline.cfx_composition_underline_set_color(nativePtrUnchecked, CfxColor.Unwrap(value));
            }
        }

        /// <summary>
        /// Background color.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxColor BackgroundColor {
            get {
                uint value;
                CfxApi.CompositionUnderline.cfx_composition_underline_get_background_color(nativePtrUnchecked, out value);
                return CfxColor.Wrap(value);
            }
            set {
                CfxApi.CompositionUnderline.cfx_composition_underline_set_background_color(nativePtrUnchecked, CfxColor.Unwrap(value));
            }
        }

        /// <summary>
        /// Set to true (1) for thick underline.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool Thick {
            get {
                int value;
                CfxApi.CompositionUnderline.cfx_composition_underline_get_thick(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.CompositionUnderline.cfx_composition_underline_set_thick(nativePtrUnchecked, value ? 1 : 0);
            }
        }

    }
}
