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
	/// Structure representing a V8 context handle. V8 handles can only be accessed
	/// from the thread on which they are created. Valid threads for creating a V8
	/// handle include the render process main thread (TID_RENDERER) and WebWorker
	/// threads. A task runner for posting tasks on the associated thread can be
	/// retrieved via the CfxV8Context.GetTaskRunner() function.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
	/// </remarks>
	public class CfxV8Context : CfxBase {

        static CfxV8Context () {
            CfxApiLoader.LoadCfxV8ContextApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxV8Context Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxV8Context)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxV8Context(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxV8Context(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the current (top) context object in the V8 context stack.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Context GetCurrentContext() {
            return CfxV8Context.Wrap(CfxApi.cfx_v8context_get_current_context());
        }

        /// <summary>
        /// Returns the entered (bottom) context object in the V8 context stack.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Context GetEnteredContext() {
            return CfxV8Context.Wrap(CfxApi.cfx_v8context_get_entered_context());
        }

        /// <summary>
        /// Returns true (1) if V8 is currently inside a context.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static bool InContext() {
            return 0 != CfxApi.cfx_v8context_in_context();
        }

        /// <summary>
        /// Returns the task runner associated with this context. V8 handles can only
        /// be accessed from the thread on which they are created. This function can be
        /// called on any render process thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxTaskRunner TaskRunner {
            get {
                return CfxTaskRunner.Wrap(CfxApi.cfx_v8context_get_task_runner(NativePtr));
            }
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
                return 0 != CfxApi.cfx_v8context_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns the browser for this context. This function will return an NULL
        /// reference for WebWorker contexts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxBrowser Browser {
            get {
                return CfxBrowser.Wrap(CfxApi.cfx_v8context_get_browser(NativePtr));
            }
        }

        /// <summary>
        /// Returns the frame for this context. This function will return an NULL
        /// reference for WebWorker contexts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxFrame Frame {
            get {
                return CfxFrame.Wrap(CfxApi.cfx_v8context_get_frame(NativePtr));
            }
        }

        /// <summary>
        /// Returns the global object for this context. The context must be entered
        /// before calling this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Value Global {
            get {
                return CfxV8Value.Wrap(CfxApi.cfx_v8context_get_global(NativePtr));
            }
        }

        /// <summary>
        /// Enter this context. A context must be explicitly entered before creating a
        /// V8 Object, Array, Function or Date asynchronously. exit() must be called
        /// the same number of times as enter() before releasing this context. V8
        /// objects belong to the context in which they are created. Returns true (1)
        /// if the scope was entered successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool Enter() {
            return 0 != CfxApi.cfx_v8context_enter(NativePtr);
        }

        /// <summary>
        /// Exit this context. Call this function only after calling enter(). Returns
        /// true (1) if the scope was exited successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool Exit() {
            return 0 != CfxApi.cfx_v8context_exit(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxV8Context that) {
            return 0 != CfxApi.cfx_v8context_is_same(NativePtr, CfxV8Context.Unwrap(that));
        }

        /// <summary>
        /// Evaluates the specified JavaScript code using this context's global object.
        /// On success |retval| will be set to the return value, if any, and the
        /// function will return true (1). On failure |exception| will be set to the
        /// exception, if any, and the function will return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool Eval(string code, out CfxV8Value retval, out CfxV8Exception exception) {
            var code_pinned = new PinnedString(code);
            IntPtr retval_ptr;
            IntPtr exception_ptr;
            var __retval = CfxApi.cfx_v8context_eval(NativePtr, code_pinned.Obj.PinnedPtr, code_pinned.Length, out retval_ptr, out exception_ptr);
            code_pinned.Obj.Free();
            retval = CfxV8Value.Wrap(retval_ptr);
            exception = CfxV8Exception.Wrap(exception_ptr);
            return 0 != __retval;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
