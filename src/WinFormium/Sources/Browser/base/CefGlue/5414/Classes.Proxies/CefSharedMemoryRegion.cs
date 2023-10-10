// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Class that wraps platform-dependent share memory region mapping.
/// </summary>
public sealed unsafe partial class CefSharedMemoryRegion
{
    /// <summary>
    /// Returns true if the mapping is valid.
    /// </summary>
    public bool IsValid
    {
        get => cef_shared_memory_region_t.is_valid(_self) != 0;
    }

    /// <summary>
    /// Returns the size of the mapping in bytes. Returns 0 for invalid instances.
    /// </summary>
    public nuint Size
    {
        get => cef_shared_memory_region_t.size(_self);
    }

    /// <summary>
    /// Returns the pointer to the memory. Returns nullptr for invalid instances.
    /// The returned pointer is only valid for the life span of this object.
    /// </summary>
    public IntPtr Memory()
    {
        return (IntPtr)cef_shared_memory_region_t.memory(_self);
    }

    // TODO: Return modern Span/Memory
}
