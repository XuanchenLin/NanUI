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
