using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

internal static class ApiHelper
{
    const string KERNEL32 = "kernel32.dll";




    private static IntPtr LoadLibraryFromSystemPathIfAvailable(string libraryName)
    {


        IntPtr module = IntPtr.Zero;

        // KB2533623 introduced the LOAD_LIBRARY_SEARCH_SYSTEM32 flag. It also introduced
        // the AddDllDirectory function. We test for presence of AddDllDirectory as an 
        // indirect evidence for the support of LOAD_LIBRARY_SEARCH_SYSTEM32 flag. 
        IntPtr kernel32 = Kernel32.GetModuleHandle(KERNEL32);
        if (kernel32 != IntPtr.Zero)
        {
            if (Kernel32.GetProcAddress(kernel32, "AddDllDirectory") != IntPtr.Zero)
            {
                module = Kernel32.LoadLibraryEx(libraryName, IntPtr.Zero, Kernel32.LOAD_LIBRARY_SEARCH_SYSTEM32);
            }
            else
            {
                // LOAD_LIBRARY_SEARCH_SYSTEM32 is not supported on this OS. 
                // Fall back to using plain ol' LoadLibrary
                module = Kernel32.LoadLibrary(libraryName);
            }
        }
        return module;
    }

    private static readonly ConcurrentDictionary<string, bool> availableApis = new ConcurrentDictionary<string, bool>();

    /// <summary>
    /// Checks if requested API is available in the give library that exist on the machine
    /// </summary>
    /// <param name="libName"> library name</param>
    /// <param name="procName">function name</param>
    /// <returns>return 'true' if given procName available in the installed libName(dll) </returns>
    public static bool IsApiAvailable(string libName, string procName)
    {
        bool isAvailable = false;

        if (!string.IsNullOrEmpty(libName) && !string.IsNullOrEmpty(procName))
        {

            var key = $"{libName.ToLower()}+{procName}";

            if (availableApis.TryGetValue(key, out isAvailable))
            {
                return isAvailable;
            }

            //load library from system path.
            IntPtr hmod = LoadLibraryFromSystemPathIfAvailable(libName);
            if (hmod != IntPtr.Zero)
            {
                IntPtr pfnProc = Kernel32.GetProcAddress(hmod, procName);
                if (pfnProc != IntPtr.Zero)
                {
                    isAvailable = true;
                }
            }

            Kernel32.FreeLibrary(hmod);
            availableApis[key] = isAvailable;
        }

        return isAvailable;
    }
}
