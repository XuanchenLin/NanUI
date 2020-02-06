// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Chromium.Remote;

namespace Chromium {
    partial class CfxApi {

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
        public delegate IntPtr cfx_ctor_with_gc_handle_delegate(IntPtr gc_handle, int wrapper_kind);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate void cfx_dtor_delegate(IntPtr nativePtr);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate void cfx_set_callback_delegate(IntPtr nativePtr, int index, IntPtr callback);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate IntPtr cfx_get_gc_handle_delegate(IntPtr nativePtr);

        //CFX_EXPORT int cfx_api_initialize(void *libcef, void *gc_handle_switch, int *platform, int *cw_usedefault, void **release, void **string_get_ptr, void **string_destroy, void **get_function_pointer)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, SetLastError = false)]
        public delegate int cfx_api_initialize_delegate(IntPtr libcef, IntPtr gc_handle_switch, out int platform, out int cw_usedefault, out IntPtr release, out IntPtr string_get_ptr, out IntPtr string_destroy, out IntPtr get_function_pointer);

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


        //static void (CEF_CALLBACK *cfx_gc_handle_switch)(gc_handle_t*, int)
        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_gc_handle_switch_delegate(ref IntPtr gc_handle, gc_handle_switch_mode mode);
        private static cfx_gc_handle_switch_delegate cfx_gc_handle_switch;

        [Flags]
        internal enum gc_handle_switch_mode {
            GC_HANDLE_FREE = 0,
            GC_HANDLE_UPGRADE = 1,
            GC_HANDLE_DOWNGRADE = 2,
            GC_HANDLE_REMOTE = 4
        }

        internal static void SwitchGcHandle(ref IntPtr gc_handle, gc_handle_switch_mode mode) {

            if((mode & gc_handle_switch_mode.GC_HANDLE_REMOTE) != 0) {
                mode -= 4;
                if(mode == gc_handle_switch_mode.GC_HANDLE_FREE) {
                    var call = new FreeGcHandleRemoteCall();
                    call.gc_handle = gc_handle;
                    call.RequestExecution(RemoteClient.connection);
                } else {
                    var call = new SwitchGcHandleRemoteCall();
                    call.gc_handle = gc_handle;
                    call.mode = (int)mode;
                    call.RequestExecution(RemoteClient.connection);
                    gc_handle = call.gc_handle;
                }
                return;
            }

            var h = GCHandle.FromIntPtr(gc_handle);
            if(mode == gc_handle_switch_mode.GC_HANDLE_FREE) {
                h.Free();
                return;
            }

            var t = h.Target;
            if(t == null) {
                // handle is weak, and target is gone
                // nothing to do here
                return;
            }

            // downgrade to weak or upgrade to strong
            var h1 = GCHandle.Alloc(t, mode == gc_handle_switch_mode.GC_HANDLE_DOWNGRADE ? GCHandleType.Weak : GCHandleType.Normal);
            gc_handle = GCHandle.ToIntPtr(h1);
            h.Free();
        }

        private static object loadLock = new object();
        internal static void Probe() {
            if(!librariesLoaded) {
                lock(loadLock) {
                    if(!librariesLoaded) Load();
                }
            }
        }

        private static void Load() {

            CfxDebug.Announce();

            string libCfx, libCef;

            FindLibraries(out libCef, out libCfx);

            var loader = NativeFunctionLoader.Create();

            var libcfxPath = System.IO.Path.Combine(libCfxDirPath, libCfx);
            var libcefPath = System.IO.Path.Combine(libCefDirPath, libCef);

            // as of 3.2883, this must be in the path due to libcef dependencies.

            var path = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", libCefDirPath + ";" + path);

            libcefPtr = loader.LoadNativeLibrary(libcefPath);
            if(libcefPtr == IntPtr.Zero) {
                throw new CfxException("Unable to load libcef library " + libcefPath);
            }

            libcfxPtr = loader.LoadNativeLibrary(libcfxPath);
            if(libcfxPtr == IntPtr.Zero) {
                throw new CfxException("Unable to load libcfx library " + libcfxPath);
            }

            cfx_gc_handle_switch = SwitchGcHandle;

            int platform;
            IntPtr release;
            IntPtr string_get_pointer;
            IntPtr string_destroy;
            IntPtr get_function_pointer;

            cfx_api_initialize_delegate api_initialize = (cfx_api_initialize_delegate)LoadDelegate(loader, libcfxPtr, "cfx_api_initialize", typeof(cfx_api_initialize_delegate));
            int retval = api_initialize(
                libcefPtr,
                Marshal.GetFunctionPointerForDelegate(cfx_gc_handle_switch),
                out platform,
                out CW_USEDEFAULT,
                out release,
                out string_get_pointer,
                out string_destroy,
                out get_function_pointer
            );

            if(retval != 0) {
                switch(retval) {
                    case 1:
                        throw new CfxException("Unable to get native function cef_api_hash from libcef library");
                    case 2:
                        Runtime.cfx_api_hash_delegate api_hash = (Runtime.cfx_api_hash_delegate)LoadDelegate(loader, libcefPtr, "cef_api_hash", typeof(Runtime.cfx_api_hash_delegate));
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
                libCfxDirPath = System.IO.Path.GetDirectoryName(new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().EscapedCodeBase).LocalPath);

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
            if(CfxRuntime.PlatformArch == CfxPlatformArch.x86)
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
