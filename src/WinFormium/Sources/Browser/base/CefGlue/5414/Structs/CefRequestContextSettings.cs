// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Request context initialization settings. Specify NULL or 0 to get the
/// recommended default values.
/// </summary>
public sealed class CefRequestContextSettings
{
    /// <summary>
    /// The location where cache data for this request context will be stored on
    /// disk. If this value is non-empty then it must be an absolute path that is
    /// either equal to or a child directory of CefSettings.root_cache_path. If
    /// this value is empty then browsers will be created in "incognito mode"
    /// where in-memory caches are used for storage and no data is persisted to
    /// disk. HTML5 databases such as localStorage will only persist across
    /// sessions if a cache path is specified. To share the global browser cache
    /// and related configuration set this value to match the
    /// CefSettings.cache_path value.
    /// </summary>
    public string CachePath { get; set; }

    /// <summary>
    /// To persist session cookies (cookies without an expiry date or validity
    /// interval) by default when using the global cookie manager set this value
    /// to true (1). Session cookies are generally intended to be transient and
    /// most Web browsers do not persist them. Can be set globally using the
    /// CefSettings.persist_session_cookies value. This value will be ignored if
    /// |cache_path| is empty or if it matches the CefSettings.cache_path value.
    /// </summary>
    public bool PersistSessionCookies { get; set; }

    /// <summary>
    /// To persist user preferences as a JSON file in the cache path directory set
    /// this value to true (1). Can be set globally using the
    /// CefSettings.persist_user_preferences value. This value will be ignored if
    /// |cache_path| is empty or if it matches the CefSettings.cache_path value.
    /// </summary>
    public bool PersistUserPreferences { get; set; }

    /// <summary>
    /// Comma delimited ordered list of language codes without any whitespace that
    /// will be used in the "Accept-Language" HTTP header. Can be set globally
    /// using the CefSettings.accept_language_list value or overridden on a per-
    /// browser basis using the CefBrowserSettings.accept_language_list value. If
    /// all values are empty then "en-US,en" will be used. This value will be
    /// ignored if |cache_path| matches the CefSettings.cache_path value.
    /// </summary>
    public string AcceptLanguageList { get; set; }

    /// <summary>
    /// Comma delimited list of schemes supported by the associated
    /// CefCookieManager. If |cookieable_schemes_exclude_defaults| is false (0)
    /// the default schemes ("http", "https", "ws" and "wss") will also be
    /// supported. Not specifying a |cookieable_schemes_list| value and setting
    /// |cookieable_schemes_exclude_defaults| to true (1) will disable all loading
    /// and saving of cookies. These values will be ignored if |cache_path|
    /// matches the CefSettings.cache_path value.
    /// </summary>
    public string CookieableSchemesList { get; set; }

    public bool CookieableSchemesExcludeDefaults { get; set; }

    internal unsafe cef_request_context_settings_t* ToNative()
    {
        var ptr = cef_request_context_settings_t.Alloc();
        cef_string_t.Copy(CachePath, &ptr->cache_path);
        ptr->persist_session_cookies = PersistSessionCookies ? 1 : 0;
        ptr->persist_user_preferences = PersistUserPreferences ? 1 : 0;
        cef_string_t.Copy(AcceptLanguageList, &ptr->accept_language_list);
        cef_string_t.Copy(CookieableSchemesList, &ptr->cookieable_schemes_list);
        ptr->cookieable_schemes_exclude_defaults = CookieableSchemesExcludeDefaults ? 1 : 0;
        return ptr;
    }

    private static unsafe void Clear(cef_request_context_settings_t* ptr)
    {
        libcef.string_clear(&ptr->cache_path);
        libcef.string_clear(&ptr->accept_language_list);
        libcef.string_clear(&ptr->cookieable_schemes_list);
    }

    internal static unsafe void Free(cef_request_context_settings_t* ptr)
    {
        Clear(ptr);
        cef_request_context_settings_t.Free(ptr);
    }
}
