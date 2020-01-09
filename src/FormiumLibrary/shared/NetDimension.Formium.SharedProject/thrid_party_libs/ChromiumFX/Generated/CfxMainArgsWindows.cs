// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing CfxExecuteProcess arguments.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_win.h">cef/include/internal/cef_types_win.h</see>.
    /// </remarks>
    internal sealed class CfxMainArgsWindows : CfxStructure {

        public CfxMainArgsWindows() : base(CfxApi.MainArgsWindows.cfx_main_args_windows_ctor, CfxApi.MainArgsWindows.cfx_main_args_windows_dtor) { CfxApi.CheckPlatformOS(CfxPlatformOS.Windows); }

        public IntPtr Instance {
            get {
                IntPtr value;
                CfxApi.MainArgsWindows.cfx_main_args_windows_get_instance(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.MainArgsWindows.cfx_main_args_windows_set_instance(nativePtrUnchecked, value);
            }
        }

    }
}
