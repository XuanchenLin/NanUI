// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Runtime.InteropServices;

namespace Chromium {
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
