// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    public partial class CfxRuntime {

        /// <summary>
        /// Add an entry to the cross-origin access whitelist.
        /// 
        /// The same-origin policy restricts how scripts hosted from different origins
        /// (scheme + domain + port) can communicate. By default, scripts can only access
        /// resources with the same origin. Scripts hosted on the HTTP and HTTPS schemes
        /// (but no other schemes) can use the "Access-Control-Allow-Origin" header to
        /// allow cross-origin requests. For example, https://source.example.com can make
        /// XMLHttpRequest requests on http://target.example.com if the
        /// http://target.example.com request returns an "Access-Control-Allow-Origin:
        /// https://source.example.com" response header.
        /// 
        /// Scripts in separate frames or iframes and hosted from the same protocol and
        /// domain suffix can execute cross-origin JavaScript if both pages set the
        /// document.domain value to the same domain suffix. For example,
        /// scheme://foo.example.com and scheme://bar.example.com can communicate using
        /// JavaScript if both domains set document.domain="example.com".
        /// 
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
        /// 
        /// This function cannot be used to bypass the restrictions on local or display
        /// isolated schemes. See the comments on CfxRegisterCustomScheme for more
        /// information.
        /// 
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
            var __retval = CfxApi.Runtime.cfx_add_cross_origin_whitelist_entry(sourceOrigin_pinned.Obj.PinnedPtr, sourceOrigin_pinned.Length, targetProtocol_pinned.Obj.PinnedPtr, targetProtocol_pinned.Length, targetDomain_pinned.Obj.PinnedPtr, targetDomain_pinned.Length, allowTargetSubdomains ? 1 : 0);
            sourceOrigin_pinned.Obj.Free();
            targetProtocol_pinned.Obj.Free();
            targetDomain_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns CEF API hashes for the libcef library. The returned string is owned
        /// by the library and should not be freed. The |entry| parameter describes which
        /// hash value will be returned:
        /// 0 - CEF_API_HASH_PLATFORM
        /// 1 - CEF_API_HASH_UNIVERSAL
        /// 2 - CEF_COMMIT_HASH (from cef_version.h)
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/cef_api_hash.h">cef/include/cef_api_hash.h</see>.
        /// </remarks>
        public static string ApiHash(int entry) {
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(CfxApi.Runtime.cfx_api_hash(entry));
        }

        /// <summary>
        /// Decodes the base64 encoded string |data|. The returned value will be NULL if
        /// the decoding fails.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static CfxBinaryValue Base64Decode(string data) {
            var data_pinned = new PinnedString(data);
            var __retval = CfxApi.Runtime.cfx_base64decode(data_pinned.Obj.PinnedPtr, data_pinned.Length);
            data_pinned.Obj.Free();
            return CfxBinaryValue.Wrap(__retval);
        }

        /// <summary>
        /// Encodes |data| as a base64 string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string Base64Encode(IntPtr data, ulong dataSize) {
            return StringFunctions.ConvertStringUserfree(CfxApi.Runtime.cfx_base64encode(data, (UIntPtr)dataSize));
        }

        /// <summary>
        /// Start tracing events on all processes. Tracing is initialized asynchronously
        /// and |callback| will be executed on the UI thread after initialization is
        /// complete.
        /// 
        /// If CfxBeginTracing was called previously, or if a CfxEndTracingAsync call is
        /// pending, CfxBeginTracing will fail and return false (0).
        /// 
        /// |categories| is a comma-delimited list of category wildcards. A category can
        /// have an optional '-' prefix to make it an excluded category. Having both
        /// included and excluded categories in the same list is not supported.
        /// 
        /// Example: "test_MyTest*" Example: "test_MyTest*,test_OtherStuff" Example:
        /// "-excluded_category1,-excluded_category2"
        /// 
        /// This function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public static bool BeginTracing(string categories, CfxCompletionCallback callback) {
            var categories_pinned = new PinnedString(categories);
            var __retval = CfxApi.Runtime.cfx_begin_tracing(categories_pinned.Obj.PinnedPtr, categories_pinned.Length, CfxCompletionCallback.Unwrap(callback));
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
            return 0 != CfxApi.Runtime.cfx_clear_cross_origin_whitelist();
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
            return 0 != CfxApi.Runtime.cfx_clear_scheme_handler_factories();
        }

        /// <summary>
        /// Crash reporting is configured using an INI-style config file named
        /// "crash_reporter.cfg". On Windows and Linux this file must be placed next to
        /// the main application executable. On macOS this file must be placed in the
        /// top-level app bundle Resources directory (e.g.
        /// "&lt;appname>.app/Contents/Resources"). File contents are as follows:
        /// 
        ///  # Comments start with a hash character and must be on their own line.
        /// 
        ///  [Config]
        ///  ProductName=&lt;Value of the "prod" crash key; defaults to "cef">
        ///  ProductVersion=&lt;Value of the "ver" crash key; defaults to the CEF version>
        ///  AppName=&lt;Windows only; App-specific folder name component for storing crash
        ///           information; default to "CEF">
        ///  ExternalHandler=&lt;Windows only; Name of the external handler exe to use
        ///                   instead of re-launching the main exe; default to empty>
        ///  BrowserCrashForwardingEnabled=&lt;macOS only; True if browser process crashes
        ///                                 should be forwarded to the system crash
        ///                                 reporter; default to false>
        ///  ServerURL=&lt;crash server URL; default to empty>
        ///  RateLimitEnabled=&lt;True if uploads should be rate limited; default to true>
        ///  MaxUploadsPerDay=&lt;Max uploads per 24 hours, used if rate limit is enabled;
        ///                    default to 5>
        ///  MaxDatabaseSizeInMb=&lt;Total crash report disk usage greater than this value
        ///                       will cause older reports to be deleted; default to 20>
        ///  MaxDatabaseAgeInDays=&lt;Crash reports older than this value will be deleted;
        ///                        default to 5>
        /// 
        ///  [CrashKeys]
        ///  my_key1=&lt;small|medium|large>
        ///  my_key2=&lt;small|medium|large>
        /// 
        /// Config section:
        /// 
        /// If "ProductName" and/or "ProductVersion" are set then the specified values
        /// will be included in the crash dump metadata. On macOS if these values are set
        /// to NULL then they will be retrieved from the Info.plist file using the
        /// "CFBundleName" and "CFBundleShortVersionString" keys respectively.
        /// 
        /// If "AppName" is set on Windows then crash report information (metrics,
        /// database and dumps) will be stored locally on disk under the
        /// "C:\Users\[CurrentUser]\AppData\Local\[AppName]\User Data" folder. On other
        /// platforms the CfxSettings.UserDataPath value will be used.
        /// 
        /// If "ExternalHandler" is set on Windows then the specified exe will be
        /// launched as the crashpad-handler instead of re-launching the main process
        /// exe. The value can be an absolute path or a path relative to the main exe
        /// directory. On Linux the CfxSettings.BrowserSubprocessPath value will be
        /// used. On macOS the existing subprocess app bundle will be used.
        /// 
        /// If "BrowserCrashForwardingEnabled" is set to true (1) on macOS then browser
        /// process crashes will be forwarded to the system crash reporter. This results
        /// in the crash UI dialog being displayed to the user and crash reports being
        /// logged under "~/Library/Logs/DiagnosticReports". Forwarding of crash reports
        /// from non-browser processes and Debug builds is always disabled.
        /// 
        /// If "ServerURL" is set then crashes will be uploaded as a multi-part POST
        /// request to the specified URL. Otherwise, reports will only be stored locally
        /// on disk.
        /// 
        /// If "RateLimitEnabled" is set to true (1) then crash report uploads will be
        /// rate limited as follows:
        ///  1. If "MaxUploadsPerDay" is set to a positive value then at most the
        ///     specified number of crashes will be uploaded in each 24 hour period.
        ///  2. If crash upload fails due to a network or server error then an
        ///     incremental backoff delay up to a maximum of 24 hours will be applied for
        ///     retries.
        ///  3. If a backoff delay is applied and "MaxUploadsPerDay" is > 1 then the
        ///     "MaxUploadsPerDay" value will be reduced to 1 until the client is
        ///     restarted. This helps to avoid an upload flood when the network or
        ///     server error is resolved.
        /// Rate limiting is not supported on Linux.
        /// 
        /// If "MaxDatabaseSizeInMb" is set to a positive value then crash report storage
        /// on disk will be limited to that size in megabytes. For example, on Windows
        /// each dump is about 600KB so a "MaxDatabaseSizeInMb" value of 20 equates to
        /// about 34 crash reports stored on disk. Not supported on Linux.
        /// 
        /// If "MaxDatabaseAgeInDays" is set to a positive value then crash reports older
        /// than the specified age in days will be deleted. Not supported on Linux.
        /// 
        /// CrashKeys section:
        /// 
        /// A maximum of 26 crash keys of each size can be specified for use by the
        /// application. Crash key values will be truncated based on the specified size
        /// (small = 64 bytes, medium = 256 bytes, large = 1024 bytes). The value of
        /// crash keys can be set from any thread or process using the
        /// CfxSetCrashKeyValue function. These key/value pairs will be sent to the crash
        /// server along with the crash dump file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_crash_util_capi.h">cef/include/capi/cef_crash_util_capi.h</see>.
        /// </remarks>
        public static bool CrashReportingEnabled() {
            return 0 != CfxApi.Runtime.cfx_crash_reporting_enabled();
        }

        /// <summary>
        /// Creates a new context object that shares storage with |other| and uses an
        /// optional |handler|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public static CfxRequestContext CreateContextShared(CfxRequestContext other, CfxRequestContextHandler handler) {
            return CfxRequestContext.Wrap(CfxApi.Runtime.cfx_create_context_shared(CfxRequestContext.Unwrap(other), CfxRequestContextHandler.Unwrap(handler)));
        }

        /// <summary>
        /// Creates a directory and all parent directories if they don't already exist.
        /// Returns true (1) on successful creation or if the directory already exists.
        /// The directory is only readable by the current user. Calling this function on
        /// the browser process UI or IO threads is not allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool CreateDirectory(string fullPath) {
            var fullPath_pinned = new PinnedString(fullPath);
            var __retval = CfxApi.Runtime.cfx_create_directory(fullPath_pinned.Obj.PinnedPtr, fullPath_pinned.Length);
            fullPath_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Creates a new directory. On Windows if |prefix| is provided the new directory
        /// name is in the format of "prefixyyyy". Returns true (1) on success and sets
        /// |newTempPath| to the full path of the directory that was created. The
        /// directory is only readable by the current user. Calling this function on the
        /// browser process UI or IO threads is not allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool CreateNewTempDirectory(string prefix, out string newTempPath) {
            var prefix_pinned = new PinnedString(prefix);
            IntPtr newTempPath_str;
            int newTempPath_length;
            var __retval = CfxApi.Runtime.cfx_create_new_temp_directory(prefix_pinned.Obj.PinnedPtr, prefix_pinned.Length, out newTempPath_str, out newTempPath_length);
            prefix_pinned.Obj.Free();
            if(newTempPath_length > 0) {
                newTempPath = System.Runtime.InteropServices.Marshal.PtrToStringUni(newTempPath_str, newTempPath_length);
                // free the native string?
            } else {
                newTempPath = null;
            }
            return 0 != __retval;
        }

        /// <summary>
        /// Creates a directory within another directory. Extra characters will be
        /// appended to |prefix| to ensure that the new directory does not have the same
        /// name as an existing directory. Returns true (1) on success and sets |newDir|
        /// to the full path of the directory that was created. The directory is only
        /// readable by the current user. Calling this function on the browser process UI
        /// or IO threads is not allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool CreateTempDirectoryInDirectory(string baseDir, string prefix, out string newDir) {
            var baseDir_pinned = new PinnedString(baseDir);
            var prefix_pinned = new PinnedString(prefix);
            IntPtr newDir_str;
            int newDir_length;
            var __retval = CfxApi.Runtime.cfx_create_temp_directory_in_directory(baseDir_pinned.Obj.PinnedPtr, baseDir_pinned.Length, prefix_pinned.Obj.PinnedPtr, prefix_pinned.Length, out newDir_str, out newDir_length);
            baseDir_pinned.Obj.Free();
            prefix_pinned.Obj.Free();
            if(newDir_length > 0) {
                newDir = System.Runtime.InteropServices.Marshal.PtrToStringUni(newDir_str, newDir_length);
                // free the native string?
            } else {
                newDir = null;
            }
            return 0 != __retval;
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
        public static bool CreateUrl(CfxUrlParts parts, out string url) {
            IntPtr url_str;
            int url_length;
            var __retval = CfxApi.Runtime.cfx_create_url(CfxUrlParts.Unwrap(parts), out url_str, out url_length);
            if(url_length > 0) {
                url = System.Runtime.InteropServices.Marshal.PtrToStringUni(url_str, url_length);
                // free the native string?
            } else {
                url = null;
            }
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
            return 0 != CfxApi.Runtime.cfx_currently_on((int)threadId);
        }

        /// <summary>
        /// Deletes the given path whether it's a file or a directory. If |path| is a
        /// directory all contents will be deleted.  If |recursive| is true (1) any sub-
        /// directories and their contents will also be deleted (equivalent to executing
        /// "rm -rf", so use with caution). On POSIX environments if |path| is a symbolic
        /// link then only the symlink will be deleted. Returns true (1) on successful
        /// deletion or if |path| does not exist. Calling this function on the browser
        /// process UI or IO threads is not allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool DeleteFile(string path, bool recursive) {
            var path_pinned = new PinnedString(path);
            var __retval = CfxApi.Runtime.cfx_delete_file(path_pinned.Obj.PinnedPtr, path_pinned.Length, recursive ? 1 : 0);
            path_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns true (1) if the given path exists and is a directory. Calling this
        /// function on the browser process UI or IO threads is not allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool DirectoryExists(string path) {
            var path_pinned = new PinnedString(path);
            var __retval = CfxApi.Runtime.cfx_directory_exists(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Perform a single iteration of CEF message loop processing. This function is
        /// provided for cases where the CEF message loop must be integrated into an
        /// existing application message loop. Use of this function is not recommended
        /// for most users; use either the cef_run_message_loop() function or
        /// CfxSettings.MultiThreadedMessageLoop if possible. When using this function
        /// care must be taken to balance performance against excessive CPU usage. It is
        /// recommended to enable the CfxSettings.ExternalMessagePump option when using
        /// this function so that
        /// CfxBrowserProcessHandler.OnScheduleMessagePumpWork() callbacks can
        /// facilitate the scheduling process. This function should only be called on the
        /// main application thread and only if cef_initialize() is called with a
        /// CfxSettings.MultiThreadedMessageLoop value of false (0). This function
        /// will not block.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public static void DoMessageLoopWork() {
            CfxApi.Runtime.cfx_do_message_loop_work();
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
            CfxApi.Runtime.cfx_enable_highdpi_support();
        }

        /// <summary>
        /// Stop tracing events on all processes.
        /// 
        /// This function will fail and return false (0) if a previous call to
        /// CfxEndTracingAsync is already pending or if CfxBeginTracing was not called.
        /// 
        /// |tracingFile| is the path at which tracing data will be written and
        /// |callback| is the callback that will be executed once all processes have sent
        /// their trace data. If |tracingFile| is NULL a new temporary file path will be
        /// used. If |callback| is NULL no trace data will be written.
        /// 
        /// This function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public static bool EndTracing(string tracingFile, CfxEndTracingCallback callback) {
            var tracingFile_pinned = new PinnedString(tracingFile);
            var __retval = CfxApi.Runtime.cfx_end_tracing(tracingFile_pinned.Obj.PinnedPtr, tracingFile_pinned.Length, CfxEndTracingCallback.Unwrap(callback));
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
            return CfxApi.Runtime.cfx_execute_process(CfxMainArgs.Unwrap(args), CfxApp.Unwrap(application), windowsSandboxInfo);
        }

        /// <summary>
        /// This is a convenience function for formatting a URL in a concise and human-
        /// friendly way to help users make security-related decisions (or in other
        /// circumstances when people need to distinguish sites, origins, or otherwise-
        /// simplified URLs from each other). Internationalized domain names (IDN) may be
        /// presented in Unicode if the conversion is considered safe. The returned value
        /// will (a) omit the path for standard schemes, excepting file and filesystem,
        /// and (b) omit the port if it is the default for the scheme. Do not use this
        /// for URLs which will be parsed or sent to other applications.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string FormatUrlForSecurityDisplay(string originUrl) {
            var originUrl_pinned = new PinnedString(originUrl);
            var __retval = CfxApi.Runtime.cfx_format_url_for_security_display(originUrl_pinned.Obj.PinnedPtr, originUrl_pinned.Length);
            originUrl_pinned.Obj.Free();
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
            CfxApi.Runtime.cfx_get_extensions_for_mime_type(mimeType_pinned.Obj.PinnedPtr, mimeType_pinned.Length, extensions_unwrapped);
            mimeType_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(extensions_handles);
            StringFunctions.CfxStringListCopyToManaged(extensions_unwrapped, extensions);
            CfxApi.Runtime.cfx_string_list_free(extensions_unwrapped);
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
            var __retval = CfxApi.Runtime.cfx_get_mime_type(extension_pinned.Obj.PinnedPtr, extension_pinned.Length);
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
        public static bool GetPath(CfxPathKey key, out string path) {
            IntPtr path_str;
            int path_length;
            var __retval = CfxApi.Runtime.cfx_get_path((int)key, out path_str, out path_length);
            if(path_length > 0) {
                path = System.Runtime.InteropServices.Marshal.PtrToStringUni(path_str, path_length);
                // free the native string?
            } else {
                path = null;
            }
            return 0 != __retval;
        }

        /// <summary>
        /// Get the temporary directory provided by the system.
        /// 
        /// WARNING: In general, you should use the temp directory variants below instead
        /// of this function. Those variants will ensure that the proper permissions are
        /// set so that other users on the system can't edit them while they're open
        /// (which could lead to security issues).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool GetTempDirectory(out string tempDir) {
            IntPtr tempDir_str;
            int tempDir_length;
            var __retval = CfxApi.Runtime.cfx_get_temp_directory(out tempDir_str, out tempDir_length);
            if(tempDir_length > 0) {
                tempDir = System.Runtime.InteropServices.Marshal.PtrToStringUni(tempDir_str, tempDir_length);
                // free the native string?
            } else {
                tempDir = null;
            }
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
            return 0 != CfxApi.Runtime.cfx_initialize(CfxMainArgs.Unwrap(args), CfxSettings.Unwrap(settings), CfxApp.Unwrap(application), windowsSandboxInfo);
        }

        /// <summary>
        /// Returns true (1) if the certificate status has any error, major or minor.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public static bool IsCertStatusError(CfxCertStatus status) {
            return 0 != CfxApi.Runtime.cfx_is_cert_status_error((int)status);
        }

        /// <summary>
        /// Returns true (1) if the certificate status represents only minor errors (e.g.
        /// failure to verify certificate revocation).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public static bool IsCertStatusMinorError(CfxCertStatus status) {
            return 0 != CfxApi.Runtime.cfx_is_cert_status_minor_error((int)status);
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
            CfxApi.Runtime.cfx_is_web_plugin_unstable(path_pinned.Obj.PinnedPtr, path_pinned.Length, CfxWebPluginUnstableCallback.Unwrap(callback));
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Launches the process specified via |commandLine|. Returns true (1) upon
        /// success. Must be called on the browser process TID_PROCESS_LAUNCHER thread.
        /// 
        /// Unix-specific notes: - All file descriptors open in the parent process will
        /// be closed in the
        ///   child process except for stdin, stdout, and stderr.
        /// - If the first argument on the command line does not contain a slash,
        ///   PATH will be searched. (See man execvp.)
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_util_capi.h">cef/include/capi/cef_process_util_capi.h</see>.
        /// </remarks>
        public static bool LaunchProcess(CfxCommandLine commandLine) {
            return 0 != CfxApi.Runtime.cfx_launch_process(CfxCommandLine.Unwrap(commandLine));
        }

        /// <summary>
        /// Loads the existing "Certificate Revocation Lists" file that is managed by
        /// Google Chrome. This file can generally be found in Chrome's User Data
        /// directory (e.g. "C:\Users\[User]\AppData\Local\Google\Chrome\User Data\" on
        /// Windows) and is updated periodically by Chrome's component updater service.
        /// Must be called in the browser process after the context has been initialized.
        /// See https://dev.chromium.org/Home/chromium-security/crlsets for background.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static void LoadCrlsetsFile(string path) {
            var path_pinned = new PinnedString(path);
            CfxApi.Runtime.cfx_load_crlsets_file(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
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
            return CfxApi.Runtime.cfx_now_from_system_trace_time();
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
            var __retval = CfxApi.Runtime.cfx_parse_json(jsonString_pinned.Obj.PinnedPtr, jsonString_pinned.Length, (int)options);
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
        public static CfxValue ParseJsonAndReturnError(string jsonString, CfxJsonParserOptions options, out CfxJsonParserError errorCodeOut, out string errorMsgOut) {
            var jsonString_pinned = new PinnedString(jsonString);
            int errorCodeOut_tmp;
            IntPtr errorMsgOut_str;
            int errorMsgOut_length;
            var __retval = CfxApi.Runtime.cfx_parse_jsonand_return_error(jsonString_pinned.Obj.PinnedPtr, jsonString_pinned.Length, (int)options, out errorCodeOut_tmp, out errorMsgOut_str, out errorMsgOut_length);
            jsonString_pinned.Obj.Free();
            errorCodeOut = (CfxJsonParserError)errorCodeOut_tmp;
            if(errorMsgOut_length > 0) {
                errorMsgOut = System.Runtime.InteropServices.Marshal.PtrToStringUni(errorMsgOut_str, errorMsgOut_length);
                // free the native string?
            } else {
                errorMsgOut = null;
            }
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
            var __retval = CfxApi.Runtime.cfx_parse_url(url_pinned.Obj.PinnedPtr, url_pinned.Length, CfxUrlParts.Unwrap(parts));
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
            var __retval = CfxApi.Runtime.cfx_post_delayed_task((int)threadId, CfxTask.Unwrap(task), delayMs);
            GC.KeepAlive(task);
            return 0 != __retval;
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
            var __retval = CfxApi.Runtime.cfx_post_task((int)threadId, CfxTask.Unwrap(task));
            GC.KeepAlive(task);
            return 0 != __retval;
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
            CfxApi.Runtime.cfx_quit_message_loop();
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
            CfxApi.Runtime.cfx_refresh_web_plugins();
        }

        /// <summary>
        /// Register a new V8 extension with the specified JavaScript extension code and
        /// handler. Functions implemented by the handler are prototyped using the
        /// keyword 'native'. The calling of a native function is restricted to the scope
        /// in which the prototype of the native function is defined. This function may
        /// only be called on the render process main thread.
        /// 
        /// Example JavaScript extension code: &lt;pre>
        ///   // create the 'example' global object if it doesn't already exist.
        ///   if (!example)
        ///     example = {};
        ///   // create the 'example.test' global object if it doesn't already exist.
        ///   if (!example.test)
        ///     example.test = {};
        ///   (function() {
        ///     // Define the function 'example.test.myfunction'.
        ///     example.test.myfunction = function() {
        ///       // Call CfxV8Handler.Execute() with the function name 'MyFunction'
        ///       // and no arguments.
        ///       native function MyFunction();
        ///       return MyFunction();
        ///     };
        ///     // Define the getter function for parameter 'example.test.myparam'.
        ///     example.test.__defineGetter__('myparam', function() {
        ///       // Call CfxV8Handler.Execute() with the function name 'GetMyParam'
        ///       // and no arguments.
        ///       native function GetMyParam();
        ///       return GetMyParam();
        ///     });
        ///     // Define the setter function for parameter 'example.test.myparam'.
        ///     example.test.__defineSetter__('myparam', function(b) {
        ///       // Call CfxV8Handler.Execute() with the function name 'SetMyParam'
        ///       // and a single argument.
        ///       native function SetMyParam();
        ///       if(b) SetMyParam(b);
        ///     });
        /// 
        ///     // Extension definitions can also contain normal JavaScript variables
        ///     // and functions.
        ///     var myint = 0;
        ///     example.test.increment = function() {
        ///       myint += 1;
        ///       return myint;
        ///     };
        ///   })();
        /// &lt;/pre> Example usage in the page: &lt;pre>
        ///   // Call the function.
        ///   example.test.myfunction();
        ///   // Set the parameter.
        ///   example.test.myparam = value;
        ///   // Get the parameter.
        ///   value = example.test.myparam;
        ///   // Call another function.
        ///   example.test.increment();
        /// &lt;/pre>
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static bool RegisterExtension(string extensionName, string javascriptCode, CfxV8Handler handler) {
            var extensionName_pinned = new PinnedString(extensionName);
            var javascriptCode_pinned = new PinnedString(javascriptCode);
            var __retval = CfxApi.Runtime.cfx_register_extension(extensionName_pinned.Obj.PinnedPtr, extensionName_pinned.Length, javascriptCode_pinned.Obj.PinnedPtr, javascriptCode_pinned.Length, CfxV8Handler.Unwrap(handler));
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
            var __retval = CfxApi.Runtime.cfx_register_scheme_handler_factory(schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, domainName_pinned.Obj.PinnedPtr, domainName_pinned.Length, CfxSchemeHandlerFactory.Unwrap(factory));
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
            CfxApi.Runtime.cfx_register_web_plugin_crash(path_pinned.Obj.PinnedPtr, path_pinned.Length);
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Register the Widevine CDM plugin.
        /// 
        /// The client application is responsible for downloading an appropriate
        /// platform-specific CDM binary distribution from Google, extracting the
        /// contents, and building the required directory structure on the local machine.
        /// The CfxBrowserHost.StartDownload function and CfxZipArchive structure
        /// can be used to implement this functionality in CEF. Contact Google via
        /// https://www.widevine.com/contact.html for details on CDM download.
        /// 
        /// |path| is a directory that must contain the following files:
        ///   1. manifest.json file from the CDM binary distribution (see below).
        ///   2. widevinecdm file from the CDM binary distribution (e.g.
        ///      widevinecdm.dll on on Windows, libwidevinecdm.dylib on OS X,
        ///      libwidevinecdm.so on Linux).
        /// 
        /// If any of these files are missing or if the manifest file has incorrect
        /// contents the registration will fail and |callback| will receive a |result|
        /// value of CEF_CDM_REGISTRATION_ERROR_INCORRECT_CONTENTS.
        /// 
        /// The manifest.json file must contain the following keys:
        ///   A. "os": Supported OS (e.g. "mac", "win" or "linux").
        ///   B. "arch": Supported architecture (e.g. "ia32" or "x64").
        ///   C. "x-cdm-module-versions": Module API version (e.g. "4").
        ///   D. "x-cdm-interface-versions": Interface API version (e.g. "8").
        ///   E. "x-cdm-host-versions": Host API version (e.g. "8").
        ///   F. "version": CDM version (e.g. "1.4.8.903").
        ///   G. "x-cdm-codecs": List of supported codecs (e.g. "vp8,vp9.0,avc1").
        /// 
        /// A through E are used to verify compatibility with the current Chromium
        /// version. If the CDM is not compatible the registration will fail and
        /// |callback| will receive a |result| value of
        /// CEF_CDM_REGISTRATION_ERROR_INCOMPATIBLE.
        /// 
        /// |callback| will be executed asynchronously once registration is complete.
        /// 
        /// On Linux this function must be called before cef_initialize() and the
        /// registration cannot be changed during runtime. If registration is not
        /// supported at the time that cef_register_widevine_cdm() is called then
        /// |callback| will receive a |result| value of
        /// CEF_CDM_REGISTRATION_ERROR_NOT_SUPPORTED.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public static void RegisterWidevineCdm(string path, CfxRegisterCdmCallback callback) {
            var path_pinned = new PinnedString(path);
            CfxApi.Runtime.cfx_register_widevine_cdm(path_pinned.Obj.PinnedPtr, path_pinned.Length, CfxRegisterCdmCallback.Unwrap(callback));
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
            var __retval = CfxApi.Runtime.cfx_remove_cross_origin_whitelist_entry(sourceOrigin_pinned.Obj.PinnedPtr, sourceOrigin_pinned.Length, targetProtocol_pinned.Obj.PinnedPtr, targetProtocol_pinned.Length, targetDomain_pinned.Obj.PinnedPtr, targetDomain_pinned.Length, allowTargetSubdomains ? 1 : 0);
            sourceOrigin_pinned.Obj.Free();
            targetProtocol_pinned.Obj.Free();
            targetDomain_pinned.Obj.Free();
            return 0 != __retval;
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
            CfxApi.Runtime.cfx_run_message_loop();
        }

        /// <summary>
        /// Sets or clears a specific key-value pair from the crash metadata.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_crash_util_capi.h">cef/include/capi/cef_crash_util_capi.h</see>.
        /// </remarks>
        public static void SetCrashKeyValue(string key, string value) {
            var key_pinned = new PinnedString(key);
            var value_pinned = new PinnedString(value);
            CfxApi.Runtime.cfx_set_crash_key_value(key_pinned.Obj.PinnedPtr, key_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            key_pinned.Obj.Free();
            value_pinned.Obj.Free();
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
            CfxApi.Runtime.cfx_set_osmodal_loop(osModalLoop ? 1 : 0);
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
            CfxApi.Runtime.cfx_shutdown();
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
            CfxApi.Runtime.cfx_unregister_internal_web_plugin(path_pinned.Obj.PinnedPtr, path_pinned.Length);
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
            var __retval = CfxApi.Runtime.cfx_uridecode(text_pinned.Obj.PinnedPtr, text_pinned.Length, convertToUtf8 ? 1 : 0, (int)unescapeRule);
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
            var __retval = CfxApi.Runtime.cfx_uriencode(text_pinned.Obj.PinnedPtr, text_pinned.Length, usePlus ? 1 : 0);
            text_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Returns CEF version information for the libcef library. The |entry|
        /// parameter describes which version component will be returned:
        /// 0 - CEF_VERSION_MAJOR
        /// 1 - CEF_VERSION_MINOR
        /// 2 - CEF_VERSION_PATCH
        /// 3 - CEF_COMMIT_NUMBER
        /// 4 - CHROME_VERSION_MAJOR
        /// 5 - CHROME_VERSION_MINOR
        /// 6 - CHROME_VERSION_BUILD
        /// 7 - CHROME_VERSION_PATCH
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/cef_version.h">cef/include/cef_version.h</see>.
        /// </remarks>
        public static int VersionInfo(int entry) {
            return CfxApi.Runtime.cfx_version_info(entry);
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
            CfxApi.Runtime.cfx_visit_web_plugin_info(CfxWebPluginInfoVisitor.Unwrap(visitor));
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
            return StringFunctions.ConvertStringUserfree(CfxApi.Runtime.cfx_write_json(CfxValue.Unwrap(node), (int)options));
        }

        /// <summary>
        /// Writes the contents of |srcDir| into a zip archive at |destFile|. If
        /// |includeHiddenFiles| is true (1) files starting with "." will be included.
        /// Returns true (1) on success.  Calling this function on the browser process UI
        /// or IO threads is not allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_file_util_capi.h">cef/include/capi/cef_file_util_capi.h</see>.
        /// </remarks>
        public static bool ZipDirectory(string srcDir, string destFile, bool includeHiddenFiles) {
            var srcDir_pinned = new PinnedString(srcDir);
            var destFile_pinned = new PinnedString(destFile);
            var __retval = CfxApi.Runtime.cfx_zip_directory(srcDir_pinned.Obj.PinnedPtr, srcDir_pinned.Length, destFile_pinned.Obj.PinnedPtr, destFile_pinned.Length, includeHiddenFiles ? 1 : 0);
            srcDir_pinned.Obj.Free();
            destFile_pinned.Obj.Free();
            return 0 != __retval;
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
                return CfxApi.Runtime.cfx_get_xdisplay();
            }

        }
    }
}
