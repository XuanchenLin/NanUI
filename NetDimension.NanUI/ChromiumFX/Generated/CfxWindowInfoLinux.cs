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
	/// Class representing window information.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
	/// </remarks>
	internal sealed class CfxWindowInfoLinux : CfxStructure {

        static CfxWindowInfoLinux () {
            if(CfxApi.PlatformOS == CfxPlatformOS.Linux) {
                CfxApiLoader.LoadCfxWindowInfoLinuxApi();
            }
        }

        internal static CfxWindowInfoLinux Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxWindowInfoLinux(nativePtr);
        }

        internal static CfxWindowInfoLinux WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxWindowInfoLinux(nativePtr, CfxApi.cfx_window_info_linux_dtor);
        }

        public CfxWindowInfoLinux() : base(CfxApi.cfx_window_info_linux_ctor, CfxApi.cfx_window_info_linux_dtor) { CfxApi.CheckPlatformOS(CfxPlatformOS.Linux); }
        internal CfxWindowInfoLinux(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxWindowInfoLinux(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public uint X {
            get {
                uint value;
                CfxApi.cfx_window_info_linux_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_x(nativePtrUnchecked, value);
            }
        }

        public uint Y {
            get {
                uint value;
                CfxApi.cfx_window_info_linux_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_y(nativePtrUnchecked, value);
            }
        }

        public uint Width {
            get {
                uint value;
                CfxApi.cfx_window_info_linux_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_width(nativePtrUnchecked, value);
            }
        }

        public uint Height {
            get {
                uint value;
                CfxApi.cfx_window_info_linux_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_height(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Pointer for the parent window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public IntPtr ParentWindow {
            get {
                IntPtr value;
                CfxApi.cfx_window_info_linux_get_parent_window(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_parent_window(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// Set to true (1) to create the browser using windowless (off-screen)
        /// rendering. No window will be created for the browser and all rendering will
        /// occur via the CfxRenderHandler interface. The |parentWindow| value will be
        /// used to identify monitor info and to act as the parent window for dialogs,
        /// context menus, etc. If |parentWindow| is not provided then the main screen
        /// monitor will be used and some functionality that requires a parent window
        /// may not function correctly. In order to create windowless browsers the
        /// CfxSettings.WindowlessRenderingEnabled value must be set to true.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool WindowlessRenderingEnabled {
            get {
                int value;
                CfxApi.cfx_window_info_linux_get_windowless_rendering_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_windowless_rendering_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to enable transparent painting in combination with
        /// windowless rendering. When this value is true a transparent background
        /// color will be used (RGBA=0x00000000). When this value is false the
        /// background will be white and opaque.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool TransparentPaintingEnabled {
            get {
                int value;
                CfxApi.cfx_window_info_linux_get_transparent_painting_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_transparent_painting_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Pointer for the new browser window. Only used with windowed rendering.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public IntPtr Window {
            get {
                IntPtr value;
                CfxApi.cfx_window_info_linux_get_window(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_window_info_linux_set_window(nativePtrUnchecked, value);
            }
        }

    }
}
