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
	/// Structure representing geoposition information. The properties of this
	/// structure correspond to those of the JavaScript Position object although
	/// their types may differ.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxGeoposition : CfxStructure {

        static CfxGeoposition () {
            CfxApiLoader.LoadCfxGeopositionApi();
        }

        internal static CfxGeoposition Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxGeoposition(nativePtr);
        }

        internal static CfxGeoposition WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxGeoposition(nativePtr, CfxApi.cfx_geoposition_dtor);
        }

        public CfxGeoposition() : base(CfxApi.cfx_geoposition_ctor, CfxApi.cfx_geoposition_dtor) {}
        internal CfxGeoposition(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxGeoposition(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        /// <summary>
        /// Latitude in decimal degrees north (WGS84 coordinate frame).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double Latitude {
            get {
                double value;
                CfxApi.cfx_geoposition_get_latitude(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_latitude(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Longitude in decimal degrees west (WGS84 coordinate frame).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double Longitude {
            get {
                double value;
                CfxApi.cfx_geoposition_get_longitude(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_longitude(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Altitude in meters (above WGS84 datum).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double Altitude {
            get {
                double value;
                CfxApi.cfx_geoposition_get_altitude(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_altitude(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Accuracy of horizontal position in meters.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double Accuracy {
            get {
                double value;
                CfxApi.cfx_geoposition_get_accuracy(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_accuracy(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Accuracy of altitude in meters.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double AltitudeAccuracy {
            get {
                double value;
                CfxApi.cfx_geoposition_get_altitude_accuracy(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_altitude_accuracy(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Heading in decimal degrees clockwise from true north.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double Heading {
            get {
                double value;
                CfxApi.cfx_geoposition_get_heading(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_heading(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Horizontal component of device velocity in meters per second.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public double Speed {
            get {
                double value;
                CfxApi.cfx_geoposition_get_speed(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_geoposition_set_speed(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Time of position measurement in milliseconds since Epoch in UTC time. This
        /// is taken from the host computer's system clock.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxTime Timestamp {
            get {
                IntPtr value;
                CfxApi.cfx_geoposition_get_timestamp(nativePtrUnchecked, out value);
                return CfxTime.Wrap(value);
            }
            set {
                CfxApi.cfx_geoposition_set_timestamp(nativePtrUnchecked, CfxTime.Unwrap(value));
            }
        }

        /// <summary>
        /// Error code, see enum above.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxGeopositionErrorCode ErrorCode {
            get {
                int value;
                CfxApi.cfx_geoposition_get_error_code(nativePtrUnchecked, out value);
                return (CfxGeopositionErrorCode)value;
            }
            set {
                CfxApi.cfx_geoposition_set_error_code(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Human-readable error message.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string ErrorMessage {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_geoposition_get_error_message(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_geoposition_set_error_message(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

    }
}
