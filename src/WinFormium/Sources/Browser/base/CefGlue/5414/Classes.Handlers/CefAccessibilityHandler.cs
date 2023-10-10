// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to receive accessibility notification when
/// accessibility events have been registered. The methods of this class will
/// be called on the UI thread.
/// </summary>
public abstract unsafe partial class CefAccessibilityHandler
{
    private void on_accessibility_tree_change(cef_accessibility_handler_t* self, cef_value_t* value)
    {
        CheckSelf(self);

        var mValue = CefValue.FromNativeOrNull(value);
        OnAccessibilityTreeChange(mValue);
    }
    
    /// <summary>
    /// Called after renderer process sends accessibility tree changes to the
    /// browser process.
    /// </summary>
    protected abstract void OnAccessibilityTreeChange(CefValue value);
    
    private void on_accessibility_location_change(cef_accessibility_handler_t* self, cef_value_t* value)
    {
        CheckSelf(self);

        var mValue = CefValue.FromNativeOrNull(value);
        OnAccessibilityLocationChange(mValue);
    }
    
    /// <summary>
    /// Called after renderer process sends accessibility location changes to the
    /// browser process.
    /// </summary>
    protected abstract void OnAccessibilityLocationChange(CefValue value);
}
