// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Collections.Concurrent;

using static Vanara.PInvoke.Kernel32;

namespace WinFormium;

internal class Win32APIAvailableHelper
{
    const string KERNEL32 = "kernel32.dll";
    private static readonly ConcurrentDictionary<string, bool> availableApis = new ConcurrentDictionary<string, bool>();

    private static SafeHINSTANCE? LoadLibraryFromSystemPathIfAvailable(string libraryName)
    {


        SafeHINSTANCE? module = null;

        // KB2533623 introduced the LOAD_LIBRARY_SEARCH_SYSTEM32 flag. It also introduced
        // the AddDllDirectory function. We test for presence of AddDllDirectory as an
        // indirect evidence for the support of LOAD_LIBRARY_SEARCH_SYSTEM32 flag.

        var kernel32 = GetModuleHandle(KERNEL32);
        if (!kernel32.IsNull)
        {
            if (GetProcAddress(kernel32, "AddDllDirectory") != IntPtr.Zero)
            {
                module = LoadLibraryEx(libraryName, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_SEARCH_SYSTEM32);
            }
            else
            {
                // LOAD_LIBRARY_SEARCH_SYSTEM32 is not supported on this OS.
                // Fall back to using plain ol' LoadLibrary
                module = LoadLibrary(libraryName);
            }
        }
        return module;
    }

    public static bool IsAvailable(string libName, string procName)
    {
        var isAvailable = false;

        if (!string.IsNullOrEmpty(libName) && !string.IsNullOrEmpty(procName))
        {

            var key = $"{libName.ToLower()}+{procName}";

            if (availableApis.TryGetValue(key, out isAvailable))
            {
                return isAvailable;
            }

            //load library from system path.
            var hmod = LoadLibraryFromSystemPathIfAvailable(libName);

            if (hmod != null)
            {
                var pfnProc = GetProcAddress(hmod, procName);
                if (pfnProc != IntPtr.Zero)
                {
                    isAvailable = true;
                }
            }

            FreeLibrary(hmod);
            availableApis[key] = isAvailable;
        }

        return isAvailable;
    }

}
