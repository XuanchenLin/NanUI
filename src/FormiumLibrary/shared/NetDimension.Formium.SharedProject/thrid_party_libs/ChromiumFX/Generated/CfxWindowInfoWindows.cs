// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing window information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
    /// </remarks>
    internal sealed class CfxWindowInfoWindows : CfxStructure {

        internal static CfxWindowInfoWindows Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxWindowInfoWindows(nativePtr);
        }

        internal static CfxWindowInfoWindows WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxWindowInfoWindows(nativePtr, CfxApi.WindowInfoWindows.cfx_window_info_windows_dtor);
        }

        public CfxWindowInfoWindows() : base(CfxApi.WindowInfoWindows.cfx_window_info_windows_ctor, CfxApi.WindowInfoWindows.cfx_window_info_windows_dtor) { CfxApi.CheckPlatformOS(CfxPlatformOS.Windows); }
        internal CfxWindowInfoWindows(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxWindowInfoWindows(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int ExStyle {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_ex_style(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_ex_style(nativePtrUnchecked, value);
            }
        }

        public string WindowName {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window_name(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window_name(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        public int Style {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_style(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_style(nativePtrUnchecked, value);
            }
        }

        public int X {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_x(nativePtrUnchecked, value);
            }
        }

        public int Y {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_y(nativePtrUnchecked, value);
            }
        }

        public int Width {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_width(nativePtrUnchecked, value);
            }
        }

        public int Height {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_height(nativePtrUnchecked, value);
            }
        }

        public IntPtr ParentWindow {
            get {
                IntPtr value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_parent_window(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_parent_window(nativePtrUnchecked, value);
            }
        }

        public IntPtr Menu {
            get {
                IntPtr value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_menu(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_menu(nativePtrUnchecked, value);
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
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
        /// </remarks>
        public bool WindowlessRenderingEnabled {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_windowless_rendering_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_windowless_rendering_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to enable shared textures for windowless rendering. Only
        /// valid if windowless_rendering_enabled above is also set to true. Currently
        /// only supported on Windows (D3D11).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
        /// </remarks>
        public bool SharedTextureEnabled {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_shared_texture_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_shared_texture_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to enable the ability to issue BeginFrame requests from the
        /// client application by calling CfxBrowserHost.SendExternalBeginFrame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
        /// </remarks>
        public bool ExternalBeginFrameEnabled {
            get {
                int value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_external_begin_frame_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_external_begin_frame_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Handle for the new browser window. Only used with windowed rendering.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
        /// </remarks>
        public IntPtr Window {
            get {
                IntPtr value;
                CfxApi.WindowInfoWindows.cfx_window_info_windows_get_window(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.WindowInfoWindows.cfx_window_info_windows_set_window(nativePtrUnchecked, value);
            }
        }

    }
}
