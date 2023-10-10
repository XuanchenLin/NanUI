// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface used for asynchronous continuation of JavaScript dialog
/// requests.
/// </summary>
public sealed unsafe partial class CefJSDialogCallback
{
    /// <summary>
    /// Continue the JS dialog request. Set |success| to true if the OK button was
    /// pressed. The |user_input| value should be specified for prompt dialogs.
    /// </summary>
    public void Continue(bool success, string userInput)
    {
        fixed (char* userInput_str = userInput)
        {
            var n_userInput = new cef_string_t(userInput_str, userInput != null ? userInput.Length : 0);

            cef_jsdialog_callback_t.cont(_self, success ? 1 : 0, &n_userInput);
        }
    }
}
