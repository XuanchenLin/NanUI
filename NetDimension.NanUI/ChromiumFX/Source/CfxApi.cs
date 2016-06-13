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
	partial class CfxApi
    {

        internal static IntPtr libcfxPtr;
        internal static IntPtr libcefPtr;

        internal static CfxPlatformOS PlatformOS { get; private set; }

        internal static string libCefDirPath;
        internal static string libCfxDirPath;
        internal static bool librariesLoaded;

        internal static int CW_USEDEFAULT;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate IntPtr cfx_ctor_delegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate IntPtr cfx_ctor_with_gc_handle_delegate(IntPtr gc_handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate void cfx_dtor_delegate(IntPtr nativePtr);

        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate void cfx_set_callback_delegate(IntPtr nativePtr, int index, IntPtr callback);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate IntPtr cfx_get_gc_handle_delegate(IntPtr nativePtr);


        //CFX_EXPORT int cfx_api_initialize(void *libcef, void *gc_handle_free, int *platform, int *cw_usedefault, void **release, void **string_get_ptr, void **string_destroy, void **get_function_pointer)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate int cfx_api_initialize_delegate(IntPtr libcef, IntPtr gc_handle_free, out int platform, out int cw_usedefault, out IntPtr release, out IntPtr string_get_ptr, out IntPtr string_destroy, out IntPtr get_function_pointer);

        //static int cfx_release(cef_base_t* base)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate int cfx_release_delegate(IntPtr nativePtr);
        public static cfx_release_delegate cfx_release;

        //static char16* cfx_string_get_ptr(cef_string_t* cefstr,  unsigned int *length)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate IntPtr cfx_string_get_ptr_delegate(IntPtr cefstr, ref int length);
        public static cfx_string_get_ptr_delegate cfx_string_get_ptr;

        //static void cfx_string_destroy(cef_string_t* cefstr)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate void cfx_string_destroy_delegate(IntPtr str);
        public static cfx_string_destroy_delegate cfx_string_destroy;

        //static void* cfx_get_function_pointer(int index)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate IntPtr cfx_get_function_pointer_delegate(int index);
        public static cfx_get_function_pointer_delegate cfx_get_function_pointer;


        //CEF_EXPORT void cef_string_userfree_utf16_free(cef_string_userfree_utf16_t str);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate void cef_string_userfree_utf16_free_delegate(IntPtr str);
        public static cef_string_userfree_utf16_free_delegate cef_string_userfree_utf16_free;
        

        //static void(CEF_CALLBACK *cfx_free_gc_handle)(gc_handle_t gc_handle)
        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_free_gc_handle_delegate(IntPtr gc_handle);
        private static cfx_free_gc_handle_delegate cfx_free_gc_handle;
        
        private static void FreeGcHandle(IntPtr gc_handle) {
            GCHandle.FromIntPtr(gc_handle).Free();
        }

        private static object loadLock = new object();
        internal static void Probe() {
            if(!librariesLoaded) {
                lock(loadLock) {
                    if(!librariesLoaded) Load();
                }
            }
        }

        private static void Load()
        {

            CfxDebug.Announce();

            string libCfx, libCef;

            FindLibraries(out libCef, out libCfx);

            var loader = NativeFunctionLoader.Create();
            
            var libcfxPath = System.IO.Path.Combine(libCfxDirPath, libCfx);
            var libcefPath = System.IO.Path.Combine(libCefDirPath, libCef);

            libcefPtr = loader.LoadNativeLibrary(libcefPath);
            if(libcefPtr == IntPtr.Zero) {
                throw new CfxException("Unable to load libcef library " + libcefPath);
            }

            libcfxPtr = loader.LoadNativeLibrary(libcfxPath);
            if (libcfxPtr == IntPtr.Zero) {
                throw new CfxException("Unable to load libcfx library " + libcfxPath);
            }

            cfx_free_gc_handle = FreeGcHandle;

            int platform;
            IntPtr release;
            IntPtr string_get_pointer;
            IntPtr string_destroy;
            IntPtr get_function_pointer;

            cfx_api_initialize_delegate api_initialize = (cfx_api_initialize_delegate)LoadDelegate(loader, libcfxPtr, "cfx_api_initialize", typeof(cfx_api_initialize_delegate));
            int retval = api_initialize(libcefPtr, Marshal.GetFunctionPointerForDelegate(cfx_free_gc_handle), out platform, out CW_USEDEFAULT, out release, out string_get_pointer, out string_destroy, out get_function_pointer);

            if(retval != 0) {
                switch(retval) {
                    case 1:
                        throw new CfxException("Unable to get native function cef_api_hash from libcef library");
                    case 2:
                        cfx_api_hash_delegate api_hash = (cfx_api_hash_delegate)LoadDelegate(loader, libcefPtr, "cef_api_hash", typeof(cfx_api_hash_delegate));
                        var apiHash = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(api_hash(0));
                        throw new CfxException("API hash mismatch: incompatible libcef.dll (" + apiHash + ")");
                }
            }

            PlatformOS = (CfxPlatformOS)platform;

            cfx_release = (cfx_release_delegate)Marshal.GetDelegateForFunctionPointer(release, typeof(cfx_release_delegate));
            cfx_string_get_ptr = (cfx_string_get_ptr_delegate)Marshal.GetDelegateForFunctionPointer(string_get_pointer, typeof(cfx_string_get_ptr_delegate));
            cfx_string_destroy = (cfx_string_destroy_delegate)Marshal.GetDelegateForFunctionPointer(string_destroy, typeof(cfx_string_destroy_delegate));
            cfx_get_function_pointer = (cfx_get_function_pointer_delegate)Marshal.GetDelegateForFunctionPointer(get_function_pointer, typeof(cfx_get_function_pointer_delegate));

            cef_string_userfree_utf16_free = (cef_string_userfree_utf16_free_delegate)LoadDelegate(loader, libcefPtr, "cef_string_userfree_utf16_free", typeof(cef_string_userfree_utf16_free_delegate));

            CfxApiLoader.LoadCfxRuntimeApi();
            librariesLoaded = true;

        }


        private static void FindLibraries(out string libCef, out string libCfx) {
            
            if(libCfxDirPath == null)
                libCfxDirPath = System.IO.Path.GetDirectoryName(new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            libCfx = GetLibCfxName(libCfxDirPath);

            if(libCfx == null) {
                if(libCefDirPath != null) {
                    libCfxDirPath = libCefDirPath;
                    libCfx = GetLibCfxName(libCfxDirPath);
                }
                if(libCfx == null) {
                    if(CfxRuntime.PlatformArch == CfxPlatformArch.x64) {
                        libCfxDirPath = System.IO.Path.Combine(libCfxDirPath, "cef64");
                        libCfx = GetLibCfxName(libCfxDirPath);
                        if(libCfx == null) {
                            libCfxDirPath = libCfxDirPath.Substring(libCfxDirPath.Length - 2);
                            libCfx = GetLibCfxName(libCfxDirPath);
                        }
                    } else {
                        libCfxDirPath = System.IO.Path.Combine(libCfxDirPath, "cef");
                        libCfx = GetLibCfxName(libCfxDirPath);
                    }
                }
            }

            if(libCfx == null) {
                throw new CfxException("libcfx library not found.");
            }

            libCef = "libcef" + libCfx.Substring(libCfx.LastIndexOf('.'));

            if(libCefDirPath == null)
                libCefDirPath = libCfxDirPath;

            if(!System.IO.File.Exists(System.IO.Path.Combine(libCefDirPath, libCef))) {
                if(CfxRuntime.PlatformArch == CfxPlatformArch.x64) {
                    libCefDirPath = System.IO.Path.Combine(libCefDirPath, "cef64");
                    if(!System.IO.File.Exists(System.IO.Path.Combine(libCefDirPath, libCef))) {
                        libCefDirPath = libCefDirPath.Substring(0, libCefDirPath.Length - 2);
                    }
                } else {
                    libCefDirPath = System.IO.Path.Combine(libCefDirPath, "cef");
                }
            }
            
            if(!System.IO.File.Exists(System.IO.Path.Combine(libCefDirPath, libCef))) {
                throw new CfxException("libcef library not found.");
            }

            libCefDirPath = System.IO.Path.GetFullPath(libCefDirPath);
            libCfxDirPath = System.IO.Path.GetFullPath(libCfxDirPath);

        }

        private static string GetLibCfxName(string directory) {
            string name;
            if(CfxRuntime.PlatformArch== CfxPlatformArch.x86)
                name = "libcfx";
            else
                name = "libcfx64";

            if(System.IO.File.Exists(System.IO.Path.Combine(directory, name + ".dll")))
                return name + ".dll";

            if(System.IO.File.Exists(System.IO.Path.Combine(directory, name + ".so")))
                return name + ".so";

            return null;
        }


        internal static void CheckPlatformOS(CfxPlatformOS p) {
            if(p != PlatformOS) {
                throw new CfxException("Platform check failed - platform specific type or function doesn't match current platform.");
            }
        }

        internal static Delegate GetDelegate(CfxApiLoader.FunctionIndex apiIndex, Type delegateType) {
            IntPtr functionPtr = cfx_get_function_pointer((int)apiIndex);
            if(functionPtr == IntPtr.Zero) {
                throw new CfxException("Unable to load native function " + apiIndex.ToString() + ".");
            }
            return Marshal.GetDelegateForFunctionPointer(functionPtr, delegateType);
        }

        private static Delegate LoadDelegate(NativeFunctionLoader loader, IntPtr hModule, string procName, Type delegateType) {
            IntPtr functionPtr = loader.GetFunctionPointer(hModule, procName);
            if(functionPtr == IntPtr.Zero) {
                throw new CfxException("Unable to load native function " + procName + ".");
            }
            return Marshal.GetDelegateForFunctionPointer(functionPtr, delegateType);
        }
    }

}
