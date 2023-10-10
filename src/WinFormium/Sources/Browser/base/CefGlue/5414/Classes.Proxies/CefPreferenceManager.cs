// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Manage access to preferences. Many built-in preferences are registered by
/// Chromium. Custom preferences can be registered in
/// CefBrowserProcessHandler::OnRegisterCustomPreferences.
/// </summary>
public unsafe partial class CefPreferenceManager
{
    /// <summary>
    /// Returns the global preference manager object.
    /// </summary>
    public static CefPreferenceManager GetGlobalPreferenceManager()
    {
        var n = cef_preference_manager_t.get_global();
        return CefPreferenceManager.FromNative(n);
    }

    /// <summary>
    /// Returns true if a preference with the specified |name| exists. This method
    /// must be called on the browser process UI thread.
    /// </summary>
    public bool HasPreference(string name)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            return cef_preference_manager_t.has_preference(_self, &n_name) != 0;
        }
    }

    /// <summary>
    /// Returns the value for the preference with the specified |name|. Returns
    /// NULL if the preference does not exist. The returned object contains a copy
    /// of the underlying preference value and modifications to the returned
    /// object will not modify the underlying preference value. This method must
    /// be called on the browser process UI thread.
    /// </summary>
    public CefValue? GetPreference(string name)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            var n_value = cef_preference_manager_t.get_preference(_self, &n_name);
            return CefValue.FromNativeOrNull(n_value);
        }
    }

    /// <summary>
    /// Returns all preferences as a dictionary. If |include_defaults| is true
    /// then preferences currently at their default value will be included. The
    /// returned object contains a copy of the underlying preference values and
    /// modifications to the returned object will not modify the underlying
    /// preference values. This method must be called on the browser process UI
    /// thread.
    /// </summary>
    public CefDictionaryValue GetAllPreferences(bool includeDefaults)
    {
        var n_result = cef_preference_manager_t.get_all_preferences(_self, includeDefaults ? 1 : 0);
        return CefDictionaryValue.FromNative(n_result);
    }

    /// <summary>
    /// Returns true if the preference with the specified |name| can be modified
    /// using SetPreference. As one example preferences set via the command-line
    /// usually cannot be modified. This method must be called on the browser
    /// process UI thread.
    /// </summary>
    public bool CanSetPreference(string name)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            return cef_preference_manager_t.can_set_preference(_self, &n_name) != 0;
        }
    }

    /// <summary>
    /// Set the |value| associated with preference |name|. Returns true if the
    /// value is set successfully and false otherwise. If |value| is NULL the
    /// preference will be restored to its default value. If setting the
    /// preference fails then |error| will be populated with a detailed
    /// description of the problem. This method must be called on the browser
    /// process UI thread.
    /// </summary>
    public bool SetPreference(string name, CefValue? value, out string error)
    {
        fixed (char* name_str = name)
        {
            var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);
            var n_value = value != null ? value.ToNative() : null;
            cef_string_t n_error;

            var n_result = cef_request_context_t.set_preference(_self, &n_name, n_value, &n_error);

            error = cef_string_t.ToString(&n_error);
            return n_result != 0;
        }
    }
}
