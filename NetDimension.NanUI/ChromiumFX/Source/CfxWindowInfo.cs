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

using System;

namespace Chromium
{
	/// <summary>
	/// Class representing window information.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>
	/// and <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/linux/cef/include/internal/cef_types_linux.h">linux/cef/include/internal/cef_types_linux.h</see>.
	/// </remarks>
	public class CfxWindowInfo : CfxStructure {

        static CfxWindowInfo() {
            switch(CfxApi.PlatformOS) {
                case CfxPlatformOS.Windows:
                    CfxApiLoader.LoadCfxWindowInfoWindowsApi();
                    break;
                case CfxPlatformOS.Linux:
                    CfxApiLoader.LoadCfxWindowInfoLinuxApi();
                    break;
            }
        }

        internal static CfxWindowInfo Wrap(IntPtr nativePtr) {
            return new CfxWindowInfo(nativePtr);
        }

        private CfxWindowInfoWindows windows;
        private CfxWindowInfoLinux linux;

        private CfxWindowInfo(IntPtr nativePtr) : base(nativePtr) {
            switch(CfxApi.PlatformOS) {
                case CfxPlatformOS.Windows:
                    windows = new CfxWindowInfoWindows(nativePtrUnchecked);
                    break;
                case CfxPlatformOS.Linux:
                    linux = new CfxWindowInfoLinux(nativePtrUnchecked);
                    break;
                default:
                    throw new CfxException("Unsupported platform.");
            }
        } 

        public CfxWindowInfo() 
            : base(
                CfxApi.PlatformOS == CfxPlatformOS.Linux ? CfxApi.cfx_window_info_linux_ctor : CfxApi.cfx_window_info_windows_ctor,
                CfxApi.PlatformOS == CfxPlatformOS.Linux ? CfxApi.cfx_window_info_linux_dtor : CfxApi.cfx_window_info_windows_dtor
            )
        {
            switch(CfxApi.PlatformOS) {
                case CfxPlatformOS.Windows:
                    windows = new CfxWindowInfoWindows(nativePtrUnchecked);
                    break;
                case CfxPlatformOS.Linux:
                    linux = new CfxWindowInfoLinux(nativePtrUnchecked);
                    break;
                default: 
                    throw new CfxException("Unsupported platform.");
            }
        }


        /// <summary>
        /// Create the browser as a child window.
        /// </summary>
        public void SetAsChild(IntPtr parentWindow, int left, int top, int width, int height) {
            if(CfxApi.PlatformOS == CfxPlatformOS.Windows)
                Style = WindowStyle.WS_CHILD | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_TABSTOP | WindowStyle.WS_VISIBLE;
            ParentWindow = parentWindow;
            X = left;
            Y = top;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Create the browser as a popup window.
        /// </summary>
        public void SetAsPopup(IntPtr parentWindow, string windowName) {
            if(CfxApi.PlatformOS != CfxPlatformOS.Windows)
                throw new CfxException("Unsupported platform.");

            Style = WindowStyle.WS_OVERLAPPEDWINDOW | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_VISIBLE;
            ParentWindow = parentWindow;
            X = CfxApi.CW_USEDEFAULT;
            Y = CfxApi.CW_USEDEFAULT;
            Width = CfxApi.CW_USEDEFAULT;
            Height = CfxApi.CW_USEDEFAULT;
            WindowName = windowName;
        }

        /// <summary>
        /// Create the browser using windowless (off-screen) rendering. No window
        /// will be created for the browser and all rendering will occur via the
        /// CefRenderHandler interface. The |parent| value will be used to identify
        /// monitor info and to act as the parent window for dialogs, context menus,
        /// etc. If |parent| is not provided then the main screen monitor will be used
        /// and some functionality that requires a parent window may not function
        /// correctly. If |transparent| is true a transparent background color will be
        /// used (RGBA=0x00000000). If |transparent| is false the background will be
        /// white and opaque. In order to create windowless browsers the
        /// CefSettings.windowless_rendering_enabled value must be set to true.
        /// </summary>
        public void SetAsWindowless(IntPtr parentWindow, bool transparent) {
            ParentWindow = parentWindow;
            WindowlessRenderingEnabled = true;
            TransparentPaintingEnabled = transparent;
        }

        /// <summary>
        /// Create the browser using windowless (off-screen) rendering. No window
        /// will be created for the browser and all rendering will occur via the
        /// CefRenderHandler interface. The main screen monitor will be used as parent
        /// and some functionality that requires a parent window may not function
        /// correctly. If |transparent| is true a transparent background color will be
        /// used (RGBA=0x00000000). If |transparent| is false the background will be
        /// white and opaque. In order to create windowless browsers the
        /// CefSettings.windowless_rendering_enabled value must be set to true.
        /// </summary>
        public void SetAsWindowless(bool transparent) {
            WindowlessRenderingEnabled = true;
            TransparentPaintingEnabled = transparent;
        }

        /// <summary>
        /// Standard parameters required by CreateWindowEx()
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
        /// </remarks>
        public int ExStyle {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.ExStyle;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.ExStyle = value;
                        break;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
        }

        public string WindowName {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.WindowName;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.WindowName = value;
                        break;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
        }

        public WindowStyle Style {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return (WindowStyle)windows.Style;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.Style = (int)value;
                        break;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
        }

        public int X {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.X;
                    case CfxPlatformOS.Linux:
                        return unchecked((int)linux.X);
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.X = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.X = unchecked((uint)value);
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

        public int Y {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.Y;
                    case CfxPlatformOS.Linux:
                        return unchecked((int)linux.Y);
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.Y = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.Y = unchecked((uint)value);
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

        public int Width {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.Width;
                    case CfxPlatformOS.Linux:
                        return unchecked((int)linux.Width);
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.Width = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.Width = unchecked((uint)value);
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

        public int Height {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.Height;
                    case CfxPlatformOS.Linux:
                        return unchecked((int)linux.Height);
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.Height = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.Height = unchecked((uint)value);
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

        public IntPtr ParentWindow {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.ParentWindow;
                    case CfxPlatformOS.Linux:
                        return linux.ParentWindow;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.ParentWindow = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.ParentWindow = value;
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

        public IntPtr Menu {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.Menu;
                    default:
                        throw new CfxException("Windows platform only.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.Menu = value;
                        break;
                    default:
                        throw new CfxException("Windows platform only.");
                }
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
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>
        /// and <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/linux/cef/include/internal/cef_types_linux.h">linux/cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool WindowlessRenderingEnabled {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.WindowlessRenderingEnabled;
                    case CfxPlatformOS.Linux:
                        return linux.WindowlessRenderingEnabled;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.WindowlessRenderingEnabled = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.WindowlessRenderingEnabled = value;
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
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
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>
        /// and <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/linux/cef/include/internal/cef_types_linux.h">linux/cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public bool TransparentPaintingEnabled {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.TransparentPaintingEnabled;
                    case CfxPlatformOS.Linux:
                        return linux.TransparentPaintingEnabled;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.TransparentPaintingEnabled = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.TransparentPaintingEnabled = value;
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

        /// <summary>
        /// Handle for the new browser window. Only used with windowed rendering.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>
        /// and <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/linux/cef/include/internal/cef_types_linux.h">linux/cef/include/internal/cef_types_linux.h</see>.
        /// </remarks>
        public IntPtr Window {
            get {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        return windows.Window;
                    case CfxPlatformOS.Linux:
                        return linux.Window;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
            set {
                switch(CfxApi.PlatformOS) {
                    case CfxPlatformOS.Windows:
                        windows.Window = value;
                        break;
                    case CfxPlatformOS.Linux:
                        linux.Window = value;
                        break;
                    default:
                        throw new CfxException("Unsupported platform.");
                }
            }
        }

    }
}
