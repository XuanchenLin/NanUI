// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to receive string values asynchronously.
/// </summary>
public abstract unsafe partial class CefStringVisitor
{
    private void visit(cef_string_visitor_t* self, cef_string_t* @string)
    {
        CheckSelf(self);

        Visit(cef_string_t.ToString(@string));
    }

    /// <summary>
    /// Method that will be executed.
    /// </summary>
    protected abstract void Visit(string value);

}
