// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a V8 stack trace handle. V8 handles can only be
    /// accessed from the thread on which they are created. Valid threads for
    /// creating a V8 handle include the render process main thread (TID_RENDERER)
    /// and WebWorker threads. A task runner for posting tasks on the associated
    /// thread can be retrieved via the CfxV8Context.GetTaskRunner() function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfxV8StackTrace : CfxBaseLibrary {

        internal static CfxV8StackTrace Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxV8StackTrace)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxV8StackTrace(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxV8StackTrace(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the stack trace for the currently active context. |frameLimit| is
        /// the maximum number of frames that will be captured.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8StackTrace GetCurrent(int frameLimit) {
            return CfxV8StackTrace.Wrap(CfxApi.V8StackTrace.cfx_v8stack_trace_get_current(frameLimit));
        }

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
                return 0 != CfxApi.V8StackTrace.cfx_v8stack_trace_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns the number of stack frames.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int FrameCount {
            get {
                return CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_count(NativePtr);
            }
        }

        /// <summary>
        /// Returns the stack frame at the specified 0-based index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8StackFrame GetFrame(int index) {
            return CfxV8StackFrame.Wrap(CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame(NativePtr, index));
        }
    }
}
