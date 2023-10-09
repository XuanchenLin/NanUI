// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface used for asynchronous continuation of permission prompts.
/// </summary>
public sealed unsafe partial class CefPermissionPromptCallback
{
    /// <summary>
    /// Complete the permissions request with the specified |result|.
    /// </summary>
    public void Continue(CefPermissionRequestResult result)
    {
        cef_permission_prompt_callback_t.cont(_self, result);
    }
}
