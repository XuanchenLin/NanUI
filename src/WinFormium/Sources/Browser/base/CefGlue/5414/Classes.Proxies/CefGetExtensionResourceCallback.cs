// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface used for asynchronous continuation of
/// CefExtensionHandler::GetExtensionResource.
/// </summary>
public sealed unsafe partial class CefGetExtensionResourceCallback
{
    /// <summary>
    /// Continue the request. Read the resource contents from |stream|.
    /// </summary>
    public void Continue(CefStreamReader stream)
    {
        var n_stream = stream.ToNative();
        cef_get_extension_resource_callback_t.cont(_self, n_stream);
    }
    
    /// <summary>
    /// Cancel the request.
    /// </summary>
    public void Cancel()
    {
        cef_get_extension_resource_callback_t.cancel(_self);
    }
    
}
