// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_touch_handle_state_t
{
    public int touch_handle_id;
    public CefTouchHandleStateFlags flags;
    public int enabled;
    public CefHorizontalAlignment orientation;
    public int mirror_vertical;
    public int mirror_horizontal;
    public cef_point_t origin;
    public float alpha;
}
