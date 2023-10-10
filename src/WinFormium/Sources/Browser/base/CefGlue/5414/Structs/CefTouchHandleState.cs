// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
public readonly struct CefTouchHandleState
{
    private readonly cef_touch_handle_state_t _value;

    internal unsafe CefTouchHandleState(cef_touch_handle_state_t* value)
    {
        _value = *value;
    }

    /// <summary>
    /// Touch handle id. Increments for each new touch handle.
    /// </summary>
    public int TouchHandleId => _value.touch_handle_id;

    /// <summary>
    /// Combination of cef_touch_handle_state_flags_t values indicating what state
    /// is set.
    /// </summary>
    public CefTouchHandleStateFlags Flags => _value.flags;

    /// <summary>
    /// Enabled state. Only set if |flags| contains CEF_THS_FLAG_ENABLED.
    /// </summary>
    public bool Enabled => _value.enabled != 0;

    /// <summary>
    /// Orientation state. Only set if |flags| contains CEF_THS_FLAG_ORIENTATION.
    /// </summary>
    public CefHorizontalAlignment Orientation => _value.orientation;
    public bool MirrorVertical => _value.mirror_vertical != 0;
    public bool MirrorHorizontal => _value.mirror_horizontal != 0;

    /// <summary>
    /// Origin state. Only set if |flags| contains CEF_THS_FLAG_ORIGIN.
    /// </summary>
    public CefPoint Origin => new CefPoint(_value.origin.x, _value.origin.y);

    /// <summary>
    /// Alpha state. Only set if |flags| contains CEF_THS_FLAG_ALPHA.
    /// </summary>
    public float Alpha => _value.alpha;
}
