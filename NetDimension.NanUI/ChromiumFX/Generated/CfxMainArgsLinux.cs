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
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
    /// </remarks>
    internal sealed partial class CfxMainArgsLinux : CfxStructure {

        public CfxMainArgsLinux() : base(CfxApi.MainArgsLinux.cfx_main_args_linux_ctor, CfxApi.MainArgsLinux.cfx_main_args_linux_dtor) { CfxApi.CheckPlatformOS(CfxPlatformOS.Linux); }

        public int Argc {
            get {
                int value;
                CfxApi.MainArgsLinux.cfx_main_args_linux_get_argc(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.MainArgsLinux.cfx_main_args_linux_set_argc(nativePtrUnchecked, value);
            }
        }

        public IntPtr Argv {
            get {
                IntPtr value;
                CfxApi.MainArgsLinux.cfx_main_args_linux_get_argv(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.MainArgsLinux.cfx_main_args_linux_set_argv(nativePtrUnchecked, value);
            }
        }

    }
}
