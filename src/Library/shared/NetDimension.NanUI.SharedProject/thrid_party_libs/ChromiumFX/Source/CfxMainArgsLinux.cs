// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromium {
    partial class CfxMainArgsLinux {

        internal static CfxMainArgsLinux Create() {
            var args = Environment.GetCommandLineArgs();
            var mainArgs = new CfxMainArgsLinux();
            mainArgs.Argc = args.Length;
            if(args.Length > 0) {
                mainArgs.managedArgv = new IntPtr[args.Length];
                for(int i = 0; i < args.Length; ++i) {
                    mainArgs.managedArgv[i] = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(args[i]);
                }
                mainArgs.argvPinned = new PinnedObject(mainArgs.managedArgv);
                mainArgs.Argv = mainArgs.argvPinned.PinnedPtr;
            } 
            return mainArgs;
        }

        private IntPtr[] managedArgv;
        private PinnedObject argvPinned;

        // Must be called explicitly, otherwise leaks
        internal void Free() {
            if(managedArgv == null) return;
            argvPinned.Free();
            for(int i = 0; i < managedArgv.Length; ++i) {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(managedArgv[i]);
            }
            managedArgv = null;
        }
    }
}
