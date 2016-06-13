// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Initialization settings. Specify NULL or 0 to get the recommended default
	/// values. Many of these and other settings can also configured using command-
	/// line switches.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxSettings : CfxStructure {

        static CfxSettings () {
            CfxApiLoader.LoadCfxSettingsApi();
        }

        public CfxSettings() : base(CfxApi.cfx_settings_ctor, CfxApi.cfx_settings_dtor) {}

        /// <summary>
        /// Set to true (1) to use a single process for the browser and renderer. This
        /// run mode is not officially supported by Chromium and is less stable than
        /// the multi-process default. Also configurable using the "single-process"
        /// command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool SingleProcess {
            get {
                int value;
                CfxApi.cfx_settings_get_single_process(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_single_process(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to disable the sandbox for sub-processes. See
        /// cef_sandbox_win.h for requirements to enable the sandbox on Windows. Also
        /// configurable using the "no-sandbox" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool NoSandbox {
            get {
                int value;
                CfxApi.cfx_settings_get_no_sandbox(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_no_sandbox(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// The path to a separate executable that will be launched for sub-processes.
        /// By default the browser process executable is used. See the comments on
        /// CfxExecuteProcess() for details. Also configurable using the
        /// "browser-subprocess-path" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string BrowserSubprocessPath {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_browser_subprocess_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_browser_subprocess_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Set to true (1) to have the browser process message loop run in a separate
        /// thread. If false (0) than the CfxDoMessageLoopWork() function must be
        /// called from your application message loop. This option is only supported on
        /// Windows.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool MultiThreadedMessageLoop {
            get {
                int value;
                CfxApi.cfx_settings_get_multi_threaded_message_loop(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_multi_threaded_message_loop(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to enable windowless (off-screen) rendering support. Do not
        /// enable this value if the application does not use windowless rendering as
        /// it may reduce rendering performance on some systems.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool WindowlessRenderingEnabled {
            get {
                int value;
                CfxApi.cfx_settings_get_windowless_rendering_enabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_windowless_rendering_enabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to disable configuration of browser process features using
        /// standard CEF and Chromium command-line arguments. Configuration can still
        /// be specified using CEF data structures or via the
        /// CfxApp.OnBeforeCommandLineProcessing() method.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool CommandLineArgsDisabled {
            get {
                int value;
                CfxApi.cfx_settings_get_command_line_args_disabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_command_line_args_disabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// The location where cache data will be stored on disk. If empty then
        /// browsers will be created in "incognito mode" where in-memory caches are
        /// used for storage and no data is persisted to disk. HTML5 databases such as
        /// localStorage will only persist across sessions if a cache path is
        /// specified. Can be overridden for individual CfxRequestContext instances via
        /// the CfxRequestContextSettings.CachePath value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string CachePath {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_cache_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_cache_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The location where user data such as spell checking dictionary files will
        /// be stored on disk. If empty then the default platform-specific user data
        /// directory will be used ("~/.cef_user_data" directory on Linux,
        /// "~/Library/Application Support/CEF/User Data" directory on Mac OS X,
        /// "Local Settings\Application Data\CEF\User Data" directory under the user
        /// profile directory on Windows).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string UserDataPath {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_user_data_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_user_data_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// To persist session cookies (cookies without an expiry date or validity
        /// interval) by default when using the global cookie manager set this value to
        /// true (1). Session cookies are generally intended to be transient and most
        /// Web browsers do not persist them. A |cachePath| value must also be
        /// specified to enable this feature. Also configurable using the
        /// "persist-session-cookies" command-line switch. Can be overridden for
        /// individual CfxRequestContext instances via the
        /// CfxRequestContextSettings.PersistSessionCookies value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool PersistSessionCookies {
            get {
                int value;
                CfxApi.cfx_settings_get_persist_session_cookies(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_persist_session_cookies(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// To persist user preferences as a JSON file in the cache path directory set
        /// this value to true (1). A |cachePath| value must also be specified
        /// to enable this feature. Also configurable using the
        /// "persist-user-preferences" command-line switch. Can be overridden for
        /// individual CfxRequestContext instances via the
        /// CfxRequestContextSettings.PersistUserPreferences value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool PersistUserPreferences {
            get {
                int value;
                CfxApi.cfx_settings_get_persist_user_preferences(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_persist_user_preferences(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Value that will be returned as the User-Agent HTTP header. If empty the
        /// default User-Agent string will be used. Also configurable using the
        /// "user-agent" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string UserAgent {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_user_agent(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_user_agent(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Value that will be inserted as the product portion of the default
        /// User-Agent string. If empty the Chromium product version will be used. If
        /// |userAgent| is specified this value will be ignored. Also configurable
        /// using the "product-version" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string ProductVersion {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_product_version(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_product_version(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The locale string that will be passed to WebKit. If empty the default
        /// locale of "en-US" will be used. This value is ignored on Linux where locale
        /// is determined using environment variable parsing with the precedence order:
        /// LANGUAGE, LC_ALL, LC_MESSAGES and LANG. Also configurable using the "lang"
        /// command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string Locale {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_locale(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_locale(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The directory and file name to use for the debug log. If empty a default
        /// log file name and location will be used. On Windows and Linux a "debug.log"
        /// file will be written in the main executable directory. On Mac OS X a
        /// "~/Library/Logs/&lt;app name>_debug.log" file will be written where &lt;app name>
        /// is the name of the main app executable. Also configurable using the
        /// "log-file" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string LogFile {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_log_file(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_log_file(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The log severity. Only messages of this severity level or higher will be
        /// logged. Also configurable using the "log-severity" command-line switch with
        /// a value of "verbose", "info", "warning", "error", "error-report" or
        /// "disable".
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxLogSeverity LogSeverity {
            get {
                int value;
                CfxApi.cfx_settings_get_log_severity(nativePtrUnchecked, out value);
                return (CfxLogSeverity)value;
            }
            set {
                CfxApi.cfx_settings_set_log_severity(nativePtrUnchecked, (int)value);
            }
        }

        /// <summary>
        /// Custom flags that will be used when initializing the V8 JavaScript engine.
        /// The consequences of using custom flags may not be well tested. Also
        /// configurable using the "js-flags" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string JavascriptFlags {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_javascript_flags(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_javascript_flags(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The fully qualified path for the resources directory. If this value is
        /// empty the cef.pak and/or devtools_resources.pak files must be located in
        /// the module directory on Windows/Linux or the app bundle Resources directory
        /// on Mac OS X. Also configurable using the "resources-dir-path" command-line
        /// switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string ResourcesDirPath {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_resources_dir_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_resources_dir_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The fully qualified path for the locales directory. If this value is empty
        /// the locales directory must be located in the module directory. This value
        /// is ignored on Mac OS X where pack files are always loaded from the app
        /// bundle Resources directory. Also configurable using the "locales-dir-path"
        /// command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string LocalesDirPath {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_locales_dir_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_locales_dir_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Set to true (1) to disable loading of pack files for resources and locales.
        /// A resource bundle handler must be provided for the browser and render
        /// processes via CfxApp.GetResourceBundleHandler() if loading of pack files
        /// is disabled. Also configurable using the "disable-pack-loading" command-
        /// line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool PackLoadingDisabled {
            get {
                int value;
                CfxApi.cfx_settings_get_pack_loading_disabled(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_pack_loading_disabled(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to a value between 1024 and 65535 to enable remote debugging on the
        /// specified port. For example, if 8080 is specified the remote debugging URL
        /// will be http://localhost:8080. CEF can be remotely debugged from any CEF or
        /// Chrome browser window. Also configurable using the "remote-debugging-port"
        /// command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int RemoteDebuggingPort {
            get {
                int value;
                CfxApi.cfx_settings_get_remote_debugging_port(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_settings_set_remote_debugging_port(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// The number of stack trace frames to capture for uncaught exceptions.
        /// Specify a positive value to enable the CfxRenderProcessHandler::
        /// OnUncaughtException() callback. Specify 0 (default value) and
        /// OnUncaughtException() will not be called. Also configurable using the
        /// "uncaught-exception-stack-size" command-line switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public int UncaughtExceptionStackSize {
            get {
                int value;
                CfxApi.cfx_settings_get_uncaught_exception_stack_size(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_settings_set_uncaught_exception_stack_size(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// By default CEF V8 references will be invalidated (the IsValid() method will
        /// return false) after the owning context has been released. This reduces the
        /// need for external record keeping and avoids crashes due to the use of V8
        /// references after the associated context has been released.
        /// CEF currently offers two context safety implementations with different
        /// performance characteristics. The default implementation (value of 0) uses a
        /// map of hash values and should provide better performance in situations with
        /// a small number contexts. The alternate implementation (value of 1) uses a
        /// hidden value attached to each context and should provide better performance
        /// in situations with a large number of contexts.
        /// If you need better performance in the creation of V8 references and you
        /// plan to manually track context lifespan you can disable context safety by
        /// specifying a value of -1.
        /// Also configurable using the "context-safety-implementation" command-line
        /// switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool ContextSafetyImplementation {
            get {
                int value;
                CfxApi.cfx_settings_get_context_safety_implementation(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_context_safety_implementation(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to ignore errors related to invalid SSL certificates.
        /// Enabling this setting can lead to potential security vulnerabilities like
        /// "man in the middle" attacks. Applications that load content from the
        /// internet should not enable this setting. Also configurable using the
        /// "ignore-certificate-errors" command-line switch. Can be overridden for
        /// individual CfxRequestContext instances via the
        /// CfxRequestContextSettings.IgnoreCertificateErrors value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool IgnoreCertificateErrors {
            get {
                int value;
                CfxApi.cfx_settings_get_ignore_certificate_errors(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_settings_set_ignore_certificate_errors(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Opaque background color used for accelerated content. By default the
        /// background color will be white. Only the RGB compontents of the specified
        /// value will be used. The alpha component must greater than 0 to enable use
        /// of the background color but will be otherwise ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxColor BackgroundColor {
            get {
                uint value;
                CfxApi.cfx_settings_get_background_color(nativePtrUnchecked, out value);
                return CfxColor.Wrap(value);
            }
            set {
                CfxApi.cfx_settings_set_background_color(nativePtrUnchecked, CfxColor.Unwrap(value));
            }
        }

        /// <summary>
        /// Comma delimited ordered list of language codes without any whitespace that
        /// will be used in the "Accept-Language" HTTP header. May be overridden on a
        /// per-browser basis using the CfxBrowserSettings.AcceptLanguageList value.
        /// If both values are empty then "en-US,en" will be used. Can be overridden
        /// for individual CfxRequestContext instances via the
        /// CfxRequestContextSettings.AcceptLanguageList value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string AcceptLanguageList {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_settings_get_accept_language_list(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_settings_set_accept_language_list(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

    }
}
