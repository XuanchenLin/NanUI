// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Represents a source from which media can be routed. Instances of this object
/// are retrieved via CefMediaRouter::GetSource. The methods of this class may
/// be called on any browser process thread unless otherwise indicated.
/// </summary>
public sealed unsafe partial class CefMediaSource
{
    /// <summary>
    /// Returns the ID (media source URN or URL) for this source.
    /// </summary>
    public string Id
    {
        get
        {
            var n_result = cef_media_source_t.get_id(_self);
            return cef_string_userfree.ToString(n_result);
        }
    }

    /// <summary>
    /// Returns true if this source outputs its content via Cast.
    /// </summary>
    public bool IsCastSource => cef_media_source_t.is_cast_source(_self) != 0;

    /// <summary>
    /// Returns true if this source outputs its content via DIAL.
    /// </summary>
    public bool IsDialSource => cef_media_source_t.is_dial_source(_self) != 0;
}
