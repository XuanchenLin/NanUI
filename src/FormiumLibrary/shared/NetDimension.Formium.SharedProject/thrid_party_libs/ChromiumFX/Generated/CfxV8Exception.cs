// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a V8 exception. The functions of this structure may be
    /// called on any render process thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfxV8Exception : CfxBaseLibrary {

        internal static CfxV8Exception Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxV8Exception)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxV8Exception(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxV8Exception(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the exception message.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string Message {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8Exception.cfx_v8exception_get_message(NativePtr));
            }
        }

        /// <summary>
        /// Returns the line of source code that the exception occurred within.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string SourceLine {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8Exception.cfx_v8exception_get_source_line(NativePtr));
            }
        }

        /// <summary>
        /// Returns the resource name for the script from where the function causing
        /// the error originates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string ScriptResourceName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8Exception.cfx_v8exception_get_script_resource_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the 1-based number of the line where the error occurred or 0 if the
        /// line number is unknown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int LineNumber {
            get {
                return CfxApi.V8Exception.cfx_v8exception_get_line_number(NativePtr);
            }
        }

        /// <summary>
        /// Returns the index within the script of the first character where the error
        /// occurred.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int StartPosition {
            get {
                return CfxApi.V8Exception.cfx_v8exception_get_start_position(NativePtr);
            }
        }

        /// <summary>
        /// Returns the index within the script of the last character where the error
        /// occurred.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int EndPosition {
            get {
                return CfxApi.V8Exception.cfx_v8exception_get_end_position(NativePtr);
            }
        }

        /// <summary>
        /// Returns the index within the line of the first character where the error
        /// occurred.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int StartColumn {
            get {
                return CfxApi.V8Exception.cfx_v8exception_get_start_column(NativePtr);
            }
        }

        /// <summary>
        /// Returns the index within the line of the last character where the error
        /// occurred.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int EndColumn {
            get {
                return CfxApi.V8Exception.cfx_v8exception_get_end_column(NativePtr);
            }
        }
    }
}
