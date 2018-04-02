// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a V8 stack frame handle. V8 handles can only be
    /// accessed from the thread on which they are created. Valid threads for
    /// creating a V8 handle include the render process main thread (TID_RENDERER)
    /// and WebWorker threads. A task runner for posting tasks on the associated
    /// thread can be retrieved via the CfxV8Context.GetTaskRunner() function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfxV8StackFrame : CfxBaseLibrary {

        internal static CfxV8StackFrame Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxV8StackFrame)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxV8StackFrame(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxV8StackFrame(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns true (1) if the underlying handle is valid and it can be accessed
        /// on the current thread. Do not call any other functions if this function
        /// returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.V8StackFrame.cfx_v8stack_frame_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns the name of the resource script that contains the function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string ScriptName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the name of the resource script that contains the function or the
        /// sourceURL value if the script name is undefined and its source ends with a
        /// "//@ sourceURL=..." string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string ScriptNameOrSourceUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_or_source_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the name of the function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string FunctionName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8StackFrame.cfx_v8stack_frame_get_function_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the 1-based line number for the function call or 0 if unknown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int LineNumber {
            get {
                return CfxApi.V8StackFrame.cfx_v8stack_frame_get_line_number(NativePtr);
            }
        }

        /// <summary>
        /// Returns the 1-based column offset on the line for the function call or 0 if
        /// unknown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int Column {
            get {
                return CfxApi.V8StackFrame.cfx_v8stack_frame_get_column(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the function was compiled using eval().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsEval {
            get {
                return 0 != CfxApi.V8StackFrame.cfx_v8stack_frame_is_eval(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the function was called as a constructor via "new".
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsConstructor {
            get {
                return 0 != CfxApi.V8StackFrame.cfx_v8stack_frame_is_constructor(NativePtr);
            }
        }
    }
}
