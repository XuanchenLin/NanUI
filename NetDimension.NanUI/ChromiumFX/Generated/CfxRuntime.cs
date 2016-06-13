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
	public partial class CfxRuntime {

        /// <summary>
        /// Add an entry to the cross-origin access whitelist.
        /// The same-origin policy restricts how scripts hosted from different origins
        /// (scheme + domain + port) can communicate. By default, scripts can only access
        /// resources with the same origin. Scripts hosted on the HTTP and HTTPS schemes
        /// (but no other schemes) can use the "Access-Control-Allow-Origin" header to
        /// allow cross-origin requests. For example, https://source.example.com can make
        /// XMLHttpRequest requests on http://target.example.com if the
        /// http://target.example.com request returns an "Access-Control-Allow-Origin:
        /// https://source.example.com" response header.
        /// Scripts in separate frames or iframes and hosted from the same protocol and
        /// domain suffix can execute cross-origin JavaScript if both pages set the
        /// document.domain value to the same domain suffix. For example,
        /// scheme://foo.example.com and scheme://bar.example.com can communicate using
        /// JavaScript if both domains set document.domain="example.com".
        /// This function is used to allow access to origins that would otherwise violate
        /// the same-origin policy. Scripts hosted underneath the fully qualified
        /// |sourceOrigin| URL (like http://www.example.com) will be allowed access to
        /// all resources hosted on the specified |targetProtocol| and |targetDomain|.
        /// If |targetDomain| is non-NULL and |allowTargetSubdomains| if false (0)
        /// only exact domain matches will be allowed. If |targetDomain| contains a top-
        /// level domain component (like "example.com") and |allowTargetSubdomains| is
        /// true (1) sub-domain matches will be allowed. If |targetDomain| is NULL and
        /// |allowTargetSubdomains| if true (1) all domains and IP addresses will be
        /// allowed.
        /// This function cannot be used to bypass the restrictions on local or display
        /// isolated schemes. See the comments on CfxRegisterCustomScheme for more
        /// information.
        /// This function may be called on any thread. Returns false (0) if
        /// |sourceOrigin| is invalid or the whitelist cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_origin_whitelist_capi.h">cef/include/capi/cef_origin_whitelist_capi.h</see>.
        /// </remarks>
        public static bool AddCrossOriginWhitelistEntry(string sourceOrigin, string targetProtocol, string targetDomain, bool allowTargetSubdomains) {
            var sourceOrigin_pinned = new PinnedString(sourceOrigin);
            var targetProtocol_pinned = new PinnedString(targetProtocol);
            var targetDomain_pinned = new PinnedString(targetDomain);
            var __retval = CfxApi.cfx_add_cross_origin_whitelist_entry(sourceOrigin_pinned.Obj.PinnedPtr, sourceOrigin_pinned.Length, targetProtocol_pinned.Obj.PinnedPtr, targetProtocol_pinned.Length, targetDomain_pinned.Obj.PinnedPtr, targetDomain_pinned.Length, allowTargetSubdomains ? 1 : 0);
            sourceOrigin_pinned.Obj.Free();
            targetProtocol_pinned.Obj.Free();
            targetDomain_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Add a plugin directory. This change may not take affect until after
        /// cef_refresh_web_plugins() is called. Can be called on any thread in the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void AddWebPluginDirectory(string dir) {
            var dir_pinned = new PinnedString(dir);
            CfxApi.cfx_add_web_plugin_directory(dir_pinned.Obj.PinnedPtr, dir_pinned.Length);
            dir_pinned.Obj.Free();
        }

        /// <summary>
        /// Add a plugin path (directory + file). This change may not take affect until
        /// after cef_refresh_web_plugins() is called. Can be called on any thread in the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void AddWebPluginPath(string path) {
            var path_pinned = new PinnedString(path);
            CfxApi.cfx_add_web_plugin_path(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Returns CEF API hashes for the libcef library. The returned string is owned
        /// by the library and should not be freed. The |entry| parameter describes which
        /// hash value will be returned:
        /// 0 - CEF_API_HASH_PLATFORM
        /// 1 - CEF_API_HASH_UNIVERSAL
        /// 2 - CEF_COMMIT_HASH
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/cef_version.h">cef/include/cef_version.h</see>.
        /// </remarks>
        public static string ApiHash(int entry) {
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(CfxApi.cfx_api_hash(entry));
        }

        /// <summary>
        /// Start tracing events on all processes. Tracing is initialized asynchronously
        /// and |callback| will be executed on the UI thread after initialization is
        /// complete.
        /// If CfxBeginTracing was called previously, or if a CfxEndTracingAsync call is
        /// pending, CfxBeginTracing will fail and return false (0).
        /// |categories| is a comma-delimited list of category wildcards. A category can
        /// have an optional '-' prefix to make it an excluded category. Having both
        /// included and excluded categories in the same list is not supported.
        /// Example: "test_MyTest*" Example: "test_MyTest*,test_OtherStuff" Example:
        /// "-excluded_category1,-excluded_category2"
        /// This function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public static bool BeginTracing(string categories, CfxCompletionCallback callback) {
            var categories_pinned = new PinnedString(categories);
            var __retval = CfxApi.cfx_begin_tracing(categories_pinned.Obj.PinnedPtr, categories_pinned.Length, CfxCompletionCallback.Unwrap(callback));
            categories_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Remove all entries from the cross-origin access whitelist. Returns false (0)
        /// if the whitelist cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_origin_whitelist_capi.h">cef/include/capi/cef_origin_whitelist_capi.h</see>.
        /// </remarks>
        public static bool ClearCrossOriginWhitelist() {
            return 0 != CfxApi.cfx_clear_cross_origin_whitelist();
        }

        /// <summary>
        /// Clear all scheme handler factories registered with the global request
        /// context. Returns false (0) on error. This function may be called on any
        /// thread in the browser process. Using this function is equivalent to calling c
        /// ef_request_tContext::cef_request_context_get_global_context()->clear_scheme_h
        /// andler_factories().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public static bool ClearSchemeHandlerFactories() {
            return 0 != CfxApi.cfx_clear_scheme_handler_factories();
        }

        /// <summary>
        /// Creates a URL from the specified |parts|, which must contain a non-NULL spec
        /// or a non-NULL host and path (at a minimum), but not both. Returns false (0)
        /// if |parts| isn't initialized as described.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static bool CreateUrl(CfxUrlParts parts, ref string url) {
            var url_pinned = new PinnedString(url);
            IntPtr url_str = url_pinned.Obj.PinnedPtr;
            int url_length = url_pinned.Length;
            var __retval = CfxApi.cfx_create_url(CfxUrlParts.Unwrap(parts), ref url_str, ref url_length);
            if(url_str != url_pinned.Obj.PinnedPtr) {
                if(url_length > 0) {
                    url = System.Runtime.InteropServices.Marshal.PtrToStringUni(url_str, url_length);
                    // free the native string?
                } else {
                    url = null;
                }
            }
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns true (1) if called on the specified thread. Equivalent to using
        /// CfxTaskRunner.GetForThread(threadId).BelongsToCurrentThread().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool CurrentlyOn(CfxThreadId threadId) {
            return 0 != CfxApi.cfx_currently_on((int)threadId);
        }

        /// <summary>
        /// Perform a single iteration of CEF message loop processing. This function is
        /// used to integrate the CEF message loop into an existing application message
        /// loop. Care must be taken to balance performance against excessive CPU usage.
        /// This function should only be called on the main application thread and only
        /// if cef_initialize() is called with a CfxSettings.MultiThreadedMessageLoop
        /// value of false (0). This function will not block.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public static void DoMessageLoopWork() {
            CfxApi.cfx_do_message_loop_work();
        }

        /// <summary>
        /// Call during process startup to enable High-DPI support on Windows 7 or newer.
        /// Older versions of Windows should be left DPI-unaware because they do not
        /// support DirectWrite and GDI fonts are kerned very badly.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public static void EnableHighDpiSupport() {
            CfxApi.cfx_enable_highdpi_support();
        }

        /// <summary>
        /// Stop tracing events on all processes.
        /// This function will fail and return false (0) if a previous call to
        /// CfxEndTracingAsync is already pending or if CfxBeginTracing was not called.
        /// |tracingFile| is the path at which tracing data will be written and
        /// |callback| is the callback that will be executed once all processes have sent
        /// their trace data. If |tracingFile| is NULL a new temporary file path will be
        /// used. If |callback| is NULL no trace data will be written.
        /// This function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public static bool EndTracing(string tracingFile, CfxEndTracingCallback callback) {
            var tracingFile_pinned = new PinnedString(tracingFile);
            var __retval = CfxApi.cfx_end_tracing(tracingFile_pinned.Obj.PinnedPtr, tracingFile_pinned.Length, CfxEndTracingCallback.Unwrap(callback));
            tracingFile_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// This function should be called from the application entry point function to
        /// execute a secondary process. It can be used to run secondary processes from
        /// the browser client executable (default behavior) or from a separate
        /// executable specified by the CfxSettings.BrowserSubprocessPath value. If
        /// called for the browser process (identified by no "type" command-line value)
        /// it will return immediately with a value of -1. If called for a recognized
        /// secondary process it will block until the process should exit and then return
        /// the process exit code. The |application| parameter may be NULL. The
        /// |windowsSandboxInfo| parameter is only used on Windows and may be NULL (see
        /// cef_sandbox_win.h for details).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        private static int ExecuteProcessPrivate(CfxMainArgs args, CfxApp application, IntPtr windowsSandboxInfo) {
            return CfxApi.cfx_execute_process(CfxMainArgs.Unwrap(args), CfxApp.Unwrap(application), windowsSandboxInfo);
        }

        /// <summary>
        /// Force a plugin to shutdown. Can be called on any thread in the browser
        /// process but will be executed on the IO thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void ForceWebPluginShutdown(string path) {
            var path_pinned = new PinnedString(path);
            CfxApi.cfx_force_web_plugin_shutdown(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// This is a convenience function for formatting a URL in a concise and human-
        /// friendly way to help users make security-related decisions (or in other
        /// circumstances when people need to distinguish sites, origins, or otherwise-
        /// simplified URLs from each other). Internationalized domain names (IDN) may be
        /// presented in Unicode if |languages| accepts the Unicode representation. The
        /// returned value will (a) omit the path for standard schemes, excepting file
        /// and filesystem, and (b) omit the port if it is the default for the scheme. Do
        /// not use this for URLs which will be parsed or sent to other applications.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string FormatUrlForSecurityDisplay(string originUrl, string languages) {
            var originUrl_pinned = new PinnedString(originUrl);
            var languages_pinned = new PinnedString(languages);
            var __retval = CfxApi.cfx_format_url_for_security_display(originUrl_pinned.Obj.PinnedPtr, originUrl_pinned.Length, languages_pinned.Obj.PinnedPtr, languages_pinned.Length);
            originUrl_pinned.Obj.Free();
            languages_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Get the extensions associated with the given mime type. This should be passed
        /// in lower case. There could be multiple extensions for a given mime type, like
        /// "html,htm" for "text/html", or "txt,text,html,..." for "text/*". Any existing
        /// elements in the provided vector will not be erased.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static void GetExtensionsForMimeType(string mimeType, System.Collections.Generic.List<string> extensions) {
            var mimeType_pinned = new PinnedString(mimeType);
            PinnedString[] extensions_handles;
            var extensions_unwrapped = StringFunctions.UnwrapCfxStringList(extensions, out extensions_handles);
            CfxApi.cfx_get_extensions_for_mime_type(mimeType_pinned.Obj.PinnedPtr, mimeType_pinned.Length, extensions_unwrapped);
            mimeType_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(extensions_handles);
            StringFunctions.CfxStringListCopyToManaged(extensions_unwrapped, extensions);
            CfxApi.cfx_string_list_free(extensions_unwrapped);
        }

        /// <summary>
        /// Request a one-time geolocation update. This function bypasses any user
        /// permission checks so should only be used by code that is allowed to access
        /// location information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_capi.h">cef/include/capi/cef_geolocation_capi.h</see>.
        /// </remarks>
        public static bool GetGeolocation(CfxGetGeolocationCallback callback) {
            return 0 != CfxApi.cfx_get_geolocation(CfxGetGeolocationCallback.Unwrap(callback));
        }

        /// <summary>
        /// Returns the mime type for the specified file extension or an NULL string if
        /// unknown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string GetMimeType(string extension) {
            var extension_pinned = new PinnedString(extension);
            var __retval = CfxApi.cfx_get_mime_type(extension_pinned.Obj.PinnedPtr, extension_pinned.Length);
            extension_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Retrieve the path associated with the specified |key|. Returns true (1) on
        /// success. Can be called on any thread in the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_path_util_capi.h">cef/include/capi/cef_path_util_capi.h</see>.
        /// </remarks>
        public static bool GetPath(CfxPathKey key, ref string path) {
            var path_pinned = new PinnedString(path);
            IntPtr path_str = path_pinned.Obj.PinnedPtr;
            int path_length = path_pinned.Length;
            var __retval = CfxApi.cfx_get_path((int)key, ref path_str, ref path_length);
            if(path_str != path_pinned.Obj.PinnedPtr) {
                if(path_length > 0) {
                    path = System.Runtime.InteropServices.Marshal.PtrToStringUni(path_str, path_length);
                    // free the native string?
                } else {
                    path = null;
                }
            }
            path_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// This function should be called on the main application thread to initialize
        /// the CEF browser process. The |application| parameter may be NULL. A return
        /// value of true (1) indicates that it succeeded and false (0) indicates that it
        /// failed. The |windowsSandboxInfo| parameter is only used on Windows and may
        /// be NULL (see cef_sandbox_win.h for details).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        private static bool InitializePrivate(CfxMainArgs args, CfxSettings settings, CfxApp application, IntPtr windowsSandboxInfo) {
            return 0 != CfxApi.cfx_initialize(CfxMainArgs.Unwrap(args), CfxSettings.Unwrap(settings), CfxApp.Unwrap(application), windowsSandboxInfo);
        }

        /// <summary>
        /// Query if a plugin is unstable. Can be called on any thread in the browser
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void IsWebPluginUnstable(string path, CfxWebPluginUnstableCallback callback) {
            var path_pinned = new PinnedString(path);
            CfxApi.cfx_is_web_plugin_unstable(path_pinned.Obj.PinnedPtr, path_pinned.Length, CfxWebPluginUnstableCallback.Unwrap(callback));
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Launches the process specified via |commandLine|. Returns true (1) upon
        /// success. Must be called on the browser process TID_PROCESS_LAUNCHER thread.
        /// Unix-specific notes: - All file descriptors open in the parent process will
        /// be closed in the
        /// child process except for stdin, stdout, and stderr.
        /// - If the first argument on the command line does not contain a slash,
        /// PATH will be searched. (See man execvp.)
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_util_capi.h">cef/include/capi/cef_process_util_capi.h</see>.
        /// </remarks>
        public static bool LaunchProcess(CfxCommandLine commandLine) {
            return 0 != CfxApi.cfx_launch_process(CfxCommandLine.Unwrap(commandLine));
        }

        /// <summary>
        /// Returns the current system trace time or, if none is defined, the current
        /// high-res time. Can be used by clients to synchronize with the time
        /// information in trace events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public static long NowFromSystemTraceTime() {
            return CfxApi.cfx_now_from_system_trace_time();
        }

        /// <summary>
        /// Parses |string| which represents a CSS color value. If |strict| is true (1)
        /// strict parsing rules will be applied. Returns true (1) on success or false
        /// (0) on error. If parsing succeeds |color| will be set to the color value
        /// otherwise |color| will remain unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static bool ParseCssColor(string @string, bool strict, ref CfxColor color) {
            var string_pinned = new PinnedString(@string);
            var __retval = CfxApi.cfx_parse_csscolor(string_pinned.Obj.PinnedPtr, string_pinned.Length, strict ? 1 : 0, ref color.color);
            string_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Parses the specified |jsonString| and returns a dictionary or list
        /// representation. If JSON parsing fails this function returns NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static CfxValue ParseJson(string jsonString, CfxJsonParserOptions options) {
            var jsonString_pinned = new PinnedString(jsonString);
            var __retval = CfxApi.cfx_parse_json(jsonString_pinned.Obj.PinnedPtr, jsonString_pinned.Length, (int)options);
            jsonString_pinned.Obj.Free();
            return CfxValue.Wrap(__retval);
        }

        /// <summary>
        /// Parses the specified |jsonString| and returns a dictionary or list
        /// representation. If JSON parsing fails this function returns NULL and
        /// populates |errorCodeOut| and |errorMsgOut| with an error code and a
        /// formatted error message respectively.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static CfxValue ParseJsonAndReturnError(string jsonString, CfxJsonParserOptions options, out CfxJsonParserError errorCodeOut, ref string errorMsgOut) {
            var jsonString_pinned = new PinnedString(jsonString);
            int errorCodeOut_tmp;
            var errorMsgOut_pinned = new PinnedString(errorMsgOut);
            IntPtr errorMsgOut_str = errorMsgOut_pinned.Obj.PinnedPtr;
            int errorMsgOut_length = errorMsgOut_pinned.Length;
            var __retval = CfxApi.cfx_parse_jsonand_return_error(jsonString_pinned.Obj.PinnedPtr, jsonString_pinned.Length, (int)options, out errorCodeOut_tmp, ref errorMsgOut_str, ref errorMsgOut_length);
            jsonString_pinned.Obj.Free();
            errorCodeOut = (CfxJsonParserError)errorCodeOut_tmp;
            if(errorMsgOut_str != errorMsgOut_pinned.Obj.PinnedPtr) {
                if(errorMsgOut_length > 0) {
                    errorMsgOut = System.Runtime.InteropServices.Marshal.PtrToStringUni(errorMsgOut_str, errorMsgOut_length);
                    // free the native string?
                } else {
                    errorMsgOut = null;
                }
            }
            errorMsgOut_pinned.Obj.Free();
            return CfxValue.Wrap(__retval);
        }

        /// <summary>
        /// Parse the specified |url| into its component parts. Returns false (0) if the
        /// URL is NULL or invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static bool ParseUrl(string url, CfxUrlParts parts) {
            var url_pinned = new PinnedString(url);
            var __retval = CfxApi.cfx_parse_url(url_pinned.Obj.PinnedPtr, url_pinned.Length, CfxUrlParts.Unwrap(parts));
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Post a task for delayed execution on the specified thread. Equivalent to
        /// using CfxTaskRunner.GetForThread(threadId).PostDelayedTask(task,
        /// delay_ms).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool PostDelayedTask(CfxThreadId threadId, CfxTask task, long delayMs) {
            return 0 != CfxApi.cfx_post_delayed_task((int)threadId, CfxTask.Unwrap(task), delayMs);
        }

        /// <summary>
        /// Post a task for execution on the specified thread. Equivalent to using
        /// CfxTaskRunner.GetForThread(threadId).PostTask(task).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool PostTask(CfxThreadId threadId, CfxTask task) {
            return 0 != CfxApi.cfx_post_task((int)threadId, CfxTask.Unwrap(task));
        }

        /// <summary>
        /// Quit the CEF message loop that was started by calling cef_run_message_loop().
        /// This function should only be called on the main application thread and only
        /// if cef_run_message_loop() was used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public static void QuitMessageLoop() {
            CfxApi.cfx_quit_message_loop();
        }

        /// <summary>
        /// Cause the plugin list to refresh the next time it is accessed regardless of
        /// whether it has already been loaded. Can be called on any thread in the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void RefreshWebPlugins() {
            CfxApi.cfx_refresh_web_plugins();
        }

        /// <summary>
        /// Register a new V8 extension with the specified JavaScript extension code and
        /// handler. Functions implemented by the handler are prototyped using the
        /// keyword 'native'. The calling of a native function is restricted to the scope
        /// in which the prototype of the native function is defined. This function may
        /// only be called on the render process main thread.
        /// Example JavaScript extension code: &lt;pre>
        /// // create the 'example' global object if it doesn't already exist.
        /// if (!example)
        /// example = {};
        /// // create the 'example.test' global object if it doesn't already exist.
        /// if (!example.test)
        /// example.test = {};
        /// (function() {
        /// // Define the function 'example.test.myfunction'.
        /// example.test.myfunction = function() {
        /// // Call CfxV8Handler.Execute() with the function name 'MyFunction'
        /// // and no arguments.
        /// native function MyFunction();
        /// return MyFunction();
        /// };
        /// // Define the getter function for parameter 'example.test.myparam'.
        /// example.test.__defineGetter__('myparam', function() {
        /// // Call CfxV8Handler.Execute() with the function name 'GetMyParam'
        /// // and no arguments.
        /// native function GetMyParam();
        /// return GetMyParam();
        /// });
        /// // Define the setter function for parameter 'example.test.myparam'.
        /// example.test.__defineSetter__('myparam', function(b) {
        /// // Call CfxV8Handler.Execute() with the function name 'SetMyParam'
        /// // and a single argument.
        /// native function SetMyParam();
        /// if(b) SetMyParam(b);
        /// });
        /// // Extension definitions can also contain normal JavaScript variables
        /// // and functions.
        /// var myint = 0;
        /// example.test.increment = function() {
        /// myint += 1;
        /// return myint;
        /// };
        /// })();
        /// &lt;/pre> Example usage in the page: &lt;pre>
        /// // Call the function.
        /// example.test.myfunction();
        /// // Set the parameter.
        /// example.test.myparam = value;
        /// // Get the parameter.
        /// value = example.test.myparam;
        /// // Call another function.
        /// example.test.increment();
        /// &lt;/pre>
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static bool RegisterExtension(string extensionName, string javascriptCode, CfxV8Handler handler) {
            var extensionName_pinned = new PinnedString(extensionName);
            var javascriptCode_pinned = new PinnedString(javascriptCode);
            var __retval = CfxApi.cfx_register_extension(extensionName_pinned.Obj.PinnedPtr, extensionName_pinned.Length, javascriptCode_pinned.Obj.PinnedPtr, javascriptCode_pinned.Length, CfxV8Handler.Unwrap(handler));
            extensionName_pinned.Obj.Free();
            javascriptCode_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Register a scheme handler factory with the global request context. An NULL
        /// |domainName| value for a standard scheme will cause the factory to match all
        /// domain names. The |domainName| value will be ignored for non-standard
        /// schemes. If |schemeName| is a built-in scheme and no handler is returned by
        /// |factory| then the built-in scheme handler factory will be called. If
        /// |schemeName| is a custom scheme then you must also implement the
        /// CfxApp.OnRegisterCustomSchemes() function in all processes. This
        /// function may be called multiple times to change or remove the factory that
        /// matches the specified |schemeName| and optional |domainName|. Returns false
        /// (0) if an error occurs. This function may be called on any thread in the
        /// browser process. Using this function is equivalent to calling CfxRequestCo
        /// ntext::cef_request_context_get_global_context()->register_scheme_handler_fact
        /// ory().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public static bool RegisterSchemeHandlerFactory(string schemeName, string domainName, CfxSchemeHandlerFactory factory) {
            var schemeName_pinned = new PinnedString(schemeName);
            var domainName_pinned = new PinnedString(domainName);
            var __retval = CfxApi.cfx_register_scheme_handler_factory(schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, domainName_pinned.Obj.PinnedPtr, domainName_pinned.Length, CfxSchemeHandlerFactory.Unwrap(factory));
            schemeName_pinned.Obj.Free();
            domainName_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Register a plugin crash. Can be called on any thread in the browser process
        /// but will be executed on the IO thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void RegisterWebPluginCrash(string path) {
            var path_pinned = new PinnedString(path);
            CfxApi.cfx_register_web_plugin_crash(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Remove an entry from the cross-origin access whitelist. Returns false (0) if
        /// |sourceOrigin| is invalid or the whitelist cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_origin_whitelist_capi.h">cef/include/capi/cef_origin_whitelist_capi.h</see>.
        /// </remarks>
        public static bool RemoveCrossOriginWhitelistEntry(string sourceOrigin, string targetProtocol, string targetDomain, bool allowTargetSubdomains) {
            var sourceOrigin_pinned = new PinnedString(sourceOrigin);
            var targetProtocol_pinned = new PinnedString(targetProtocol);
            var targetDomain_pinned = new PinnedString(targetDomain);
            var __retval = CfxApi.cfx_remove_cross_origin_whitelist_entry(sourceOrigin_pinned.Obj.PinnedPtr, sourceOrigin_pinned.Length, targetProtocol_pinned.Obj.PinnedPtr, targetProtocol_pinned.Length, targetDomain_pinned.Obj.PinnedPtr, targetDomain_pinned.Length, allowTargetSubdomains ? 1 : 0);
            sourceOrigin_pinned.Obj.Free();
            targetProtocol_pinned.Obj.Free();
            targetDomain_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Remove a plugin path (directory + file). This change may not take affect
        /// until after cef_refresh_web_plugins() is called. Can be called on any thread
        /// in the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void RemoveWebPluginPath(string path) {
            var path_pinned = new PinnedString(path);
            CfxApi.cfx_remove_web_plugin_path(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Run the CEF message loop. Use this function instead of an application-
        /// provided message loop to get the best balance between performance and CPU
        /// usage. This function should only be called on the main application thread and
        /// only if cef_initialize() is called with a
        /// CfxSettings.MultiThreadedMessageLoop value of false (0). This function
        /// will block until a quit message is received by the system.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public static void RunMessageLoop() {
            CfxApi.cfx_run_message_loop();
        }

        /// <summary>
        /// Set to true (1) before calling Windows APIs like TrackPopupMenu that enter a
        /// modal message loop. Set to false (0) after exiting the modal message loop.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public static void SetOsModalLoop(bool osModalLoop) {
            CfxApi.cfx_set_osmodal_loop(osModalLoop ? 1 : 0);
        }

        /// <summary>
        /// This function should be called on the main application thread to shut down
        /// the CEF browser process before the application exits.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        private static void ShutdownPrivate() {
            CfxApi.cfx_shutdown();
        }

        /// <summary>
        /// Unregister an internal plugin. This may be undone the next time
        /// cef_refresh_web_plugins() is called. Can be called on any thread in the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void UnregisterInternalWebPlugin(string path) {
            var path_pinned = new PinnedString(path);
            CfxApi.cfx_unregister_internal_web_plugin(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Unescapes |text| and returns the result. Unescaping consists of looking for
        /// the exact pattern "%XX" where each X is a hex digit and converting to the
        /// character with the numerical value of those digits (e.g. "i%20=%203%3b"
        /// unescapes to "i = 3;"). If |convertToUtf8| is true (1) this function will
        /// attempt to interpret the initial decoded result as UTF-8. If the result is
        /// convertable into UTF-8 it will be returned as converted. Otherwise the
        /// initial decoded result will be returned.  The |unescapeRule| parameter
        /// supports further customization the decoding process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string UriDecode(string text, bool convertToUtf8, CfxUriUnescapeRule unescapeRule) {
            var text_pinned = new PinnedString(text);
            var __retval = CfxApi.cfx_uridecode(text_pinned.Obj.PinnedPtr, text_pinned.Length, convertToUtf8 ? 1 : 0, (int)unescapeRule);
            text_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Escapes characters in |text| which are unsuitable for use as a query
        /// parameter value. Everything except alphanumerics and -_.!~*'() will be
        /// converted to "%XX". If |usePlus| is true (1) spaces will change to "+". The
        /// result is basically the same as encodeURIComponent in Javacript.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string UriEncode(string text, bool usePlus) {
            var text_pinned = new PinnedString(text);
            var __retval = CfxApi.cfx_uriencode(text_pinned.Obj.PinnedPtr, text_pinned.Length, usePlus ? 1 : 0);
            text_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Returns CEF version information for the libcef library. The |entry|
        /// parameter describes which version component will be returned:
        /// 0 - CEF_VERSION_MAJOR
        /// 1 - CEF_COMMIT_NUMBER
        /// 2 - CHROME_VERSION_MAJOR
        /// 3 - CHROME_VERSION_MINOR
        /// 4 - CHROME_VERSION_BUILD
        /// 5 - CHROME_VERSION_PATCH
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/cef_version.h">cef/include/cef_version.h</see>.
        /// </remarks>
        public static int VersionInfo(int entry) {
            return CfxApi.cfx_version_info(entry);
        }

        /// <summary>
        /// Visit web plugin information. Can be called on any thread in the browser
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void VisitWebPluginInfo(CfxWebPluginInfoVisitor visitor) {
            CfxApi.cfx_visit_web_plugin_info(CfxWebPluginInfoVisitor.Unwrap(visitor));
        }

        /// <summary>
        /// Generates a JSON string from the specified root |node| which should be a
        /// dictionary or list value. Returns an NULL string on failure. This function
        /// requires exclusive access to |node| including any underlying data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string WriteJson(CfxValue node, CfxJsonWriterOptions options) {
            return StringFunctions.ConvertStringUserfree(CfxApi.cfx_write_json(CfxValue.Unwrap(node), (int)options));
        }

        public class Linux {

            /// <summary>
            /// Return the singleton X11 display shared with Chromium. The display is not
            /// thread-safe and must only be accessed on the browser process UI thread.
            /// </summary>
            /// <remarks>
            /// See also the original CEF documentation in
            /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types_linux.h">cef/include/internal/cef_types_linux.h</see>.
            /// </remarks>
            public static IntPtr GetXDisplay() {
                CfxApi.CheckPlatformOS(CfxPlatformOS.Linux);
                return CfxApi.cfx_get_xdisplay();
            }

        }
    }
}
