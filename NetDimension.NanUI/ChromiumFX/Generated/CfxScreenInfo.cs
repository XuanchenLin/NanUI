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
	/// Screen information used when window rendering is disabled. This structure is
	/// passed as a parameter to CfxRenderHandler.GetScreenInfo and should be filled
	/// in by the client.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxScreenInfo : CfxStructure {

        static CfxScreenInfo () {
            CfxApiLoader.LoadCfxScreenInfoApi();
        }

        internal static CfxScreenInfo Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxScreenInfo(nativePtr);
        }

        internal static CfxScreenInfo WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxScreenInfo(nativePtr, CfxApi.cfx_screen_info_dtor);
        }

        public CfxScreenInfo() : base(CfxApi.cfx_screen_info_ctor, CfxApi.cfx_screen_info_dtor) {}
        internal CfxScreenInfo(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxScreenInfo(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        /// <summary>
        /// Device scale factor. Specifies the ratio between physical and logical
        /// pixels.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public float DeviceScaleFactor {
            get {
                float value;
                CfxApi.cfx_screen_info_get_device_scale_factor(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_screen_info_set_device_scale_factor(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The screen depth in bits per pixel.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int Depth {
            get {
                int value;
                CfxApi.cfx_screen_info_get_depth(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_screen_info_set_depth(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The bits per color component. This assumes that the colors are balanced
        /// equally.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int DepthPerComponent {
            get {
                int value;
                CfxApi.cfx_screen_info_get_depth_per_component(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_screen_info_set_depth_per_component(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// This can be true for black and white printers.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool IsMonochrome {
            get {
                int value;
                CfxApi.cfx_screen_info_get_is_monochrome(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_screen_info_set_is_monochrome(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// This is set from the rcMonitor member of MONITORINFOEX, to whit:
        /// "A RECT structure that specifies the display monitor rectangle,
        /// expressed in virtual-screen coordinates. Note that if the monitor
        /// is not the primary display monitor, some of the rectangle's
        /// coordinates may be negative values."
        /// The |rect| and |availableRect| properties are used to determine the
        /// available surface for rendering popup views.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxRect Rect {
            get {
                IntPtr value;
                CfxApi.cfx_screen_info_get_rect(nativePtrUnchecked, out value);
                return CfxRect.Wrap(value);
            }
            set {
                CfxApi.cfx_screen_info_set_rect(nativePtrUnchecked, CfxRect.Unwrap(value));
            }
        }

        /// <summary>
        /// This is set from the rcWork member of MONITORINFOEX, to whit:
        /// "A RECT structure that specifies the work area rectangle of the
        /// display monitor that can be used by applications, expressed in
        /// virtual-screen coordinates. Windows uses this rectangle to
        /// maximize an application on the monitor. The rest of the area in
        /// rcMonitor contains system windows such as the task bar and side
        /// bars. Note that if the monitor is not the primary display monitor,
        /// some of the rectangle's coordinates may be negative values".
        /// The |rect| and |availableRect| properties are used to determine the
        /// available surface for rendering popup views.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxRect AvailableRect {
            get {
                IntPtr value;
                CfxApi.cfx_screen_info_get_available_rect(nativePtrUnchecked, out value);
                return CfxRect.Wrap(value);
            }
            set {
                CfxApi.cfx_screen_info_set_available_rect(nativePtrUnchecked, CfxRect.Unwrap(value));
            }
        }

    }
}
