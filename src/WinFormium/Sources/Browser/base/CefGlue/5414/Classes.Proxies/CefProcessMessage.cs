// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Class representing a message. Can be used on any process and thread.
/// </summary>
public sealed unsafe partial class CefProcessMessage
{
    /// <summary>
    /// Create a new CefProcessMessage object with the specified name.
    /// </summary>
    public static CefProcessMessage Create(string name)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            return CefProcessMessage.FromNative(
                cef_process_message_t.create(&n_name)
                );
        }
    }

    /// <summary>
    /// Returns true if this object is valid. Do not call any other methods if
    /// this function returns false.
    /// </summary>
    public bool IsValid
    {
        get { return cef_process_message_t.is_valid(_self) != 0; }
    }

    /// <summary>
    /// Returns true if the values of this object are read-only. Some APIs may
    /// expose read-only objects.
    /// </summary>
    public bool IsReadOnly
    {
        get { return cef_process_message_t.is_read_only(_self) != 0; }
    }

    /// <summary>
    /// Returns a writable copy of this object.
    /// Returns nullptr when message contains a shared memory region.
    /// </summary>
    public CefProcessMessage? Copy()
    {
        return CefProcessMessage.FromNativeOrNull(
            cef_process_message_t.copy(_self)
            );
    }

    /// <summary>
    /// Returns the message name.
    /// </summary>
    public string Name
    {
        get
        {
            var n_result = cef_process_message_t.get_name(_self);
            return cef_string_userfree.ToString(n_result);
            // FIXME: caching ?
        }
    }

    /// <summary>
    /// Returns the list of arguments.
    /// Returns nullptr when message contains a shared memory region.
    /// </summary>
    public CefListValue? Arguments
    {
        get
        {
            return CefListValue.FromNativeOrNull(
                cef_process_message_t.get_argument_list(_self)
                );
            // FIXME: caching ?
        }
    }

    /// <summary>
    /// Returns the shared memory region.
    /// Returns nullptr when message contains an argument list.
    /// </summary>
    public CefSharedMemoryRegion? GetSharedMemoryRegion()
    {
        return CefSharedMemoryRegion.FromNativeOrNull(
            cef_process_message_t.get_shared_memory_region(_self)
            );
    }
}
