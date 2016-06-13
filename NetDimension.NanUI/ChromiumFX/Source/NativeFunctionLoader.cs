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
using System.Runtime.InteropServices;

namespace Chromium
{
	internal abstract class NativeFunctionLoader {

        internal static NativeFunctionLoader Create() {
            // use path separator character instead of Environment.OSVersion.Platform
            // for platform detection
            if(System.IO.Path.DirectorySeparatorChar.Equals('\\'))
                return new WindowsFunctionLoader();
            else
                return new UnixFunctionLoader();
        }

        /// <summary>
        /// Dynamically loads a native library.
        /// </summary>
        /// <param name="name">The library name without extension.</param>
        /// <returns>The library handle or IntPtr.Zero if load fails.</returns>
        internal abstract IntPtr LoadNativeLibrary(string name);

        /// <summary>
        /// Gets a pointer for a function in a dynamically loaded native library.
        /// </summary>
        /// <param name="libraryHandle">The library handle.</param>
        /// <param name="name">The function name.</param>
        /// <returns>A pointer to the function or IntPtr.Zero if the function fails.</returns>
        internal abstract IntPtr GetFunctionPointer(IntPtr libraryHandle, string name);

    }

    // for windows
    internal class WindowsFunctionLoader : NativeFunctionLoader {

        [DllImport("kernel32.dll", SetLastError = false)]
        private static extern IntPtr LoadLibrary(string filename);

        [DllImport("kernel32.dll", SetLastError = false)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        internal override IntPtr LoadNativeLibrary(string name) {
            return LoadLibrary(name);
        }

        internal override IntPtr GetFunctionPointer(IntPtr libraryHandle, string name) {
            return GetProcAddress(libraryHandle, name);
        }
    }

    // for linux and mac osx
    internal class UnixFunctionLoader : NativeFunctionLoader {

        [DllImport("dl")]
        static extern IntPtr dlopen([MarshalAs(UnmanagedType.LPTStr)] string filename, int flags);

        [DllImport("dl")]
        static extern IntPtr dlsym(IntPtr handle, [MarshalAs(UnmanagedType.LPTStr)] string symbol);

        const int RTLD_NOW = 2;

        internal override IntPtr LoadNativeLibrary(string name) {
            return dlopen(name, RTLD_NOW);
        }

        internal override IntPtr GetFunctionPointer(IntPtr libraryHandle, string name) {
            return dlsym(libraryHandle, name);
        }
    }

}
