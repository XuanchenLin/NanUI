// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing mouse event information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxMouseEvent : CfxStructure {

        public CfxMouseEvent() : base(CfxApi.MouseEvent.cfx_mouse_event_ctor, CfxApi.MouseEvent.cfx_mouse_event_dtor) {}

        /// <summary>
        /// X coordinate relative to the left side of the view.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int X {
            get {
                int value;
                CfxApi.MouseEvent.cfx_mouse_event_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.MouseEvent.cfx_mouse_event_set_x(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Y coordinate relative to the top side of the view.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int Y {
            get {
                int value;
                CfxApi.MouseEvent.cfx_mouse_event_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.MouseEvent.cfx_mouse_event_set_y(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Bit flags describing any pressed modifier keys. See
        /// CfxEventFlags for values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public uint Modifiers {
            get {
                uint value;
                CfxApi.MouseEvent.cfx_mouse_event_get_modifiers(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.MouseEvent.cfx_mouse_event_set_modifiers(nativePtrUnchecked, value);
            }
        }

    }
}
