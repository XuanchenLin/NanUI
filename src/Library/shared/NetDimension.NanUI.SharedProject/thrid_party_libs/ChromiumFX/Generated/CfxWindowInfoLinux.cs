// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Class representing window information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
    /// </remarks>
    internal sealed class CfxWindowInfoLinux : CfxStructure {

        internal static CfxWindowInfoLinux Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxWindowInfoLinux(nativePtr);
        }

        internal static CfxWindowInfoLinux WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxWindowInfoLinux(nativePtr, CfxApi.WindowInfoLinux.cfx_window_info_linux_dtor);
        }

        public CfxWindowInfoLinux() : base(CfxApi.WindowInfoLinux.cfx_window_info_linux_ctor, CfxApi.WindowInfoLinux.cfx_window_info_linux_dtor) { CfxApi.CheckPlatformOS(CfxPlatformOS.Linux); }
        internal CfxWindowInfoLinux(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxWindowInfoLinux(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public uint X {
            get {
                uint value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_x(nativePtrUnchecked, value);
            }
        }

        public uint Y {
            get {
                uint value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_y(nativePtrUnchecked, value);
            }
        }

        public uint Width {
            get {
                uint value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_width(nativePtrUnchecked, value);
            }
        }

        public uint Height {
            get {
                uint value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_height(nativePtrUnchecked, value);
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
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_parent_window(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_parent_window(nativePtrUnchecked, value);
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
        /// Transparent painting is enabled by default but can be disabled by setting
        /// CfxBrowserSettings.BackgroundColor to an opaque value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool WindowlessRenderingEnabled {
            get {
                int value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_windowless_rendering_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_windowless_rendering_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to enable shared textures for windowless rendering. Only
        /// valid if windowless_rendering_enabled above is also set to true. Currently
        /// only supported on Windows (D3D11).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool SharedTextureEnabled {
            get {
                int value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_shared_texture_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_shared_texture_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to enable the ability to issue BeginFrame requests from the
        /// client application by calling CfxBrowserHost.SendExternalBeginFrame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool ExternalBeginFrameEnabled {
            get {
                int value;
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_external_begin_frame_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_external_begin_frame_enabled(nativePtrUnchecked, value ? 1 : 0);
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
                CfxApi.WindowInfoLinux.cfx_window_info_linux_get_window(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoLinux.cfx_window_info_linux_set_window(nativePtrUnchecked, value);
            }
        }

    }
}
