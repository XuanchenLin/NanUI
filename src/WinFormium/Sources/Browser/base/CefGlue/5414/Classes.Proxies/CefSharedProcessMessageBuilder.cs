// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Class that builds a CefProcessMessage containing a shared memory region.
/// This class is not thread-safe but may be used exclusively on a different
/// thread from the one which constructed it.
/// </summary>
public sealed unsafe partial class CefSharedProcessMessageBuilder
{
    /// <summary>
    /// Creates a new CefSharedProcessMessageBuilder with the specified |name| and
    /// shared memory region of specified |byte_size|.
    /// </summary>
    public static CefSharedProcessMessageBuilder Create(string name, nuint byteSize)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            var n_result = cef_shared_process_message_builder_t.create(&n_name, byteSize);
            return CefSharedProcessMessageBuilder.FromNative(n_result);
        }
    }

    /// <summary>
    /// Returns true if the builder is valid.
    /// </summary>
    public bool IsValid
    {
        get => cef_shared_process_message_builder_t.is_valid(_self) != 0;
    }

    /// <summary>
    /// Returns the size of the shared memory region in bytes. Returns 0 for
    /// invalid instances.
    /// </summary>
    public nuint Size
    {
        get => cef_shared_process_message_builder_t.size(_self);
    }

    /// <summary>
    /// Returns the pointer to the writable memory. Returns nullptr for invalid
    /// instances. The returned pointer is only valid for the life span of this
    /// object.
    /// </summary>
    public IntPtr Memory()
    {
        return (IntPtr)cef_shared_process_message_builder_t.memory(_self);
    }

    /// <summary>
    /// Creates a new CefProcessMessage from the data provided to the builder.
    /// Returns nullptr for invalid instances. Invalidates the builder instance.
    /// </summary>
    public CefProcessMessage Build()
    {
        return CefProcessMessage.FromNativeOrNull(
            cef_shared_process_message_builder_t.build(_self)
            );
    }
}
