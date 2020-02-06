// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    public partial class CfrRuntime {

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
        /// platforms the CfrSettings.UserDataPath value will be used.
        /// 
        /// If "ExternalHandler" is set on Windows then the specified exe will be
        /// launched as the crashpad-handler instead of re-launching the main process
        /// exe. The value can be an absolute path or a path relative to the main exe
        /// directory. On Linux the CfrSettings.BrowserSubprocessPath value will be
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
        /// CfrSetCrashKeyValue function. These key/value pairs will be sent to the crash
        /// server along with the crash dump file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_crash_util_capi.h">cef/include/capi/cef_crash_util_capi.h</see>.
        /// </remarks>
        public static bool CrashReportingEnabled() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeCrashReportingEnabledRemoteCall();
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeCreateDirectoryRemoteCall();
            call.fullPath = fullPath;
            call.RequestExecution(connection);
            return call.__retval;
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
        public static bool CreateNewTempDirectory(string prefix, string newTempPath) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeCreateNewTempDirectoryRemoteCall();
            call.prefix = prefix;
            call.RequestExecution(connection);
            newTempPath = call.newTempPath;
            return call.__retval;
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
        public static bool CreateTempDirectoryInDirectory(string baseDir, string prefix, string newDir) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeCreateTempDirectoryInDirectoryRemoteCall();
            call.baseDir = baseDir;
            call.prefix = prefix;
            call.RequestExecution(connection);
            newDir = call.newDir;
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if called on the specified thread. Equivalent to using
        /// CfrTaskRunner.GetForThread(threadId).BelongsToCurrentThread().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool CurrentlyOn(CfxThreadId threadId) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeCurrentlyOnRemoteCall();
            call.threadId = (int)threadId;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeDeleteFileRemoteCall();
            call.path = path;
            call.recursive = recursive;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeDirectoryExistsRemoteCall();
            call.path = path;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeFormatUrlForSecurityDisplayRemoteCall();
            call.originUrl = originUrl;
            call.RequestExecution(connection);
            return call.__retval;
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
        public static bool GetTempDirectory(string tempDir) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeGetTempDirectoryRemoteCall();
            call.RequestExecution(connection);
            tempDir = call.tempDir;
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if the certificate status has any error, major or minor.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public static bool IsCertStatusError(CfxCertStatus status) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeIsCertStatusErrorRemoteCall();
            call.status = (int)status;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeIsCertStatusMinorErrorRemoteCall();
            call.status = (int)status;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeLoadCrlsetsFileRemoteCall();
            call.path = path;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Post a task for delayed execution on the specified thread. Equivalent to
        /// using CfrTaskRunner.GetForThread(threadId).PostDelayedTask(task,
        /// delay_ms).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool PostDelayedTask(CfxThreadId threadId, CfrTask task, long delayMs) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimePostDelayedTaskRemoteCall();
            call.threadId = (int)threadId;
            if(!CfrObject.CheckConnection(task, connection)) throw new ArgumentException("Render process connection mismatch.", "task");
            call.task = CfrObject.Unwrap(task).ptr;
            call.delayMs = delayMs;
            call.RequestExecution(connection);
            GC.KeepAlive(task);
            return call.__retval;
        }

        /// <summary>
        /// Post a task for execution on the specified thread. Equivalent to using
        /// CfrTaskRunner.GetForThread(threadId).PostTask(task).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool PostTask(CfxThreadId threadId, CfrTask task) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimePostTaskRemoteCall();
            call.threadId = (int)threadId;
            if(!CfrObject.CheckConnection(task, connection)) throw new ArgumentException("Render process connection mismatch.", "task");
            call.task = CfrObject.Unwrap(task).ptr;
            call.RequestExecution(connection);
            GC.KeepAlive(task);
            return call.__retval;
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
        ///       // Call CfrV8Handler.Execute() with the function name 'MyFunction'
        ///       // and no arguments.
        ///       native function MyFunction();
        ///       return MyFunction();
        ///     };
        ///     // Define the getter function for parameter 'example.test.myparam'.
        ///     example.test.__defineGetter__('myparam', function() {
        ///       // Call CfrV8Handler.Execute() with the function name 'GetMyParam'
        ///       // and no arguments.
        ///       native function GetMyParam();
        ///       return GetMyParam();
        ///     });
        ///     // Define the setter function for parameter 'example.test.myparam'.
        ///     example.test.__defineSetter__('myparam', function(b) {
        ///       // Call CfrV8Handler.Execute() with the function name 'SetMyParam'
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
        public static bool RegisterExtension(string extensionName, string javascriptCode, CfrV8Handler handler) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeRegisterExtensionRemoteCall();
            call.extensionName = extensionName;
            call.javascriptCode = javascriptCode;
            if(!CfrObject.CheckConnection(handler, connection)) throw new ArgumentException("Render process connection mismatch.", "handler");
            call.handler = CfrObject.Unwrap(handler).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets or clears a specific key-value pair from the crash metadata.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_crash_util_capi.h">cef/include/capi/cef_crash_util_capi.h</see>.
        /// </remarks>
        public static void SetCrashKeyValue(string key, string value) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeSetCrashKeyValueRemoteCall();
            call.key = key;
            call.value = value;
            call.RequestExecution(connection);
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRuntimeZipDirectoryRemoteCall();
            call.srcDir = srcDir;
            call.destFile = destFile;
            call.includeHiddenFiles = includeHiddenFiles;
            call.RequestExecution(connection);
            return call.__retval;
        }

    }
}
