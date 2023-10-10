// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Class that manages custom preference registrations.
/// </summary>
public sealed unsafe partial class CefPreferenceRegistrar
{
    internal void ReleaseObject()
    {
        _self = null;
    }

    /// <summary>
    /// Register a preference with the specified |name| and |default_value|. To
    /// avoid conflicts with built-in preferences the |name| value should contain
    /// an application-specific prefix followed by a period (e.g. "myapp.value").
    /// The contents of |default_value| will be copied. The data type for the
    /// preference will be inferred from |default_value|'s type and cannot be
    /// changed after registration. Returns true on success. Returns false if
    /// |name| is already registered or if |default_value| has an invalid type.
    /// This method must be called from within the scope of the
    /// CefBrowserProcessHandler::OnRegisterCustomPreferences callback.
    /// </summary>
    public bool AddPreference(string name, CefValue defaultValue)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            return cef_preference_registrar_t.add_preference(_self,
                &n_name,
                defaultValue.ToNative()) != 0;
        }
    }
}
