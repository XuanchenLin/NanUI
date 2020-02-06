// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing touch event information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxTouchEvent : CfxStructure {

        public CfxTouchEvent() : base(CfxApi.TouchEvent.cfx_touch_event_ctor, CfxApi.TouchEvent.cfx_touch_event_dtor) {}

        /// <summary>
        /// Id of a touch point. Must be unique per touch, can be any number except -1.
        /// Note that a maximum of 16 concurrent touches will be tracked; touches
        /// beyond that will be ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int Id {
            get {
                int value;
                CfxApi.TouchEvent.cfx_touch_event_get_id(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_id(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// X coordinate relative to the left side of the view.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float X {
            get {
                float value;
                CfxApi.TouchEvent.cfx_touch_event_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_x(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Y coordinate relative to the top side of the view.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float Y {
            get {
                float value;
                CfxApi.TouchEvent.cfx_touch_event_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_y(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// X radius in pixels. Set to 0 if not applicable.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float RadiusX {
            get {
                float value;
                CfxApi.TouchEvent.cfx_touch_event_get_radius_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_radius_x(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Y radius in pixels. Set to 0 if not applicable.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float RadiusY {
            get {
                float value;
                CfxApi.TouchEvent.cfx_touch_event_get_radius_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_radius_y(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Rotation angle in radians. Set to 0 if not applicable.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float RotationAngle {
            get {
                float value;
                CfxApi.TouchEvent.cfx_touch_event_get_rotation_angle(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_rotation_angle(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The normalized pressure of the pointer input in the range of [0,1].
        /// Set to 0 if not applicable.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float Pressure {
            get {
                float value;
                CfxApi.TouchEvent.cfx_touch_event_get_pressure(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_pressure(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The state of the touch point. Touches begin with one CEF_TET_PRESSED event
        /// followed by zero or more CEF_TET_MOVED events and finally one
        /// CEF_TET_RELEASED or CEF_TET_CANCELLED event. Events not respecting this
        /// order will be ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxTouchEventType Type {
            get {
                int value;
                CfxApi.TouchEvent.cfx_touch_event_get_type(nativePtrUnchecked, out value);
                return (CfxTouchEventType)value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_type(nativePtrUnchecked, (int)value);
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
                CfxApi.TouchEvent.cfx_touch_event_get_modifiers(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_modifiers(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The device type that caused the event.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxPointerType PointerType {
            get {
                int value;
                CfxApi.TouchEvent.cfx_touch_event_get_pointer_type(nativePtrUnchecked, out value);
                return (CfxPointerType)value;
            }
            set {
                CfxApi.TouchEvent.cfx_touch_event_set_pointer_type(nativePtrUnchecked, (int)value);
            }
        }

    }
}
