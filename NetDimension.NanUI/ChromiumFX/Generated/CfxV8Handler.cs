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
	using Event;

	/// <summary>
	/// Structure that should be implemented to handle V8 function calls. The
	/// functions of this structure will be called on the thread associated with the
	/// V8 function.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
	/// </remarks>
	public class CfxV8Handler : CfxBase {

        static CfxV8Handler () {
            CfxApiLoader.LoadCfxV8HandlerApi();
        }

        internal static CfxV8Handler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_v8handler_get_gc_handle(nativePtr);
            return (CfxV8Handler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // execute
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_v8handler_execute_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, int argumentsCount, IntPtr arguments, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static cfx_v8handler_execute_delegate cfx_v8handler_execute;
        private static IntPtr cfx_v8handler_execute_ptr;

        internal static void execute(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, int argumentsCount, IntPtr arguments, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Handler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                retval = default(IntPtr);
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxV8HandlerExecuteEventArgs(name_str, name_length, @object, arguments, argumentsCount);
            var eventHandler = self.m_Execute;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_object_wrapped == null) CfxApi.cfx_release(e.m_object);
            if(e.m_arguments_managed == null) {
                for(int i = 0; i < argumentsCount; ++i) {
                    CfxApi.cfx_release(e.m_arguments[i]);
                }
            }
            if(e.m_exception_wrapped != null && e.m_exception_wrapped.Length > 0) {
                var exception_pinned = new PinnedString(e.m_exception_wrapped);
                exception_str = exception_pinned.Obj.PinnedPtr;
                exception_length = exception_pinned.Length;
                exception_gc_handle = exception_pinned.Obj.ToIntPtr();
            } else {
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
            }
            retval = CfxV8Value.Unwrap(e.m_returnValue);
            __retval = e.m_returnValue != null || e.m_exception_wrapped != null ? 1 : 0;
        }

        internal CfxV8Handler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxV8Handler() : base(CfxApi.cfx_v8handler_ctor) {}

        /// <summary>
        /// Handle execution of the function identified by |Name|. |Object| is the
        /// receiver ('this' object) of the function. |Arguments| is the list of
        /// arguments passed to the function. If execution succeeds set |Retval| to the
        /// function return value. If execution fails set |Exception| to the exception
        /// that will be thrown. Return true (1) if execution was handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxV8HandlerExecuteEventHandler Execute {
            add {
                lock(eventLock) {
                    if(m_Execute == null) {
                        if(cfx_v8handler_execute == null) {
                            cfx_v8handler_execute = execute;
                            cfx_v8handler_execute_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_v8handler_execute);
                        }
                        CfxApi.cfx_v8handler_set_managed_callback(NativePtr, 0, cfx_v8handler_execute_ptr);
                    }
                    m_Execute += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Execute -= value;
                    if(m_Execute == null) {
                        CfxApi.cfx_v8handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxV8HandlerExecuteEventHandler m_Execute;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Execute != null) {
                m_Execute = null;
                CfxApi.cfx_v8handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Handle execution of the function identified by |Name|. |Object| is the
		/// receiver ('this' object) of the function. |Arguments| is the list of
		/// arguments passed to the function. If execution succeeds set |Retval| to the
		/// function return value. If execution fails set |Exception| to the exception
		/// that will be thrown. Return true (1) if execution was handled.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
		/// </remarks>
		public delegate void CfxV8HandlerExecuteEventHandler(object sender, CfxV8HandlerExecuteEventArgs e);

        /// <summary>
        /// Handle execution of the function identified by |Name|. |Object| is the
        /// receiver ('this' object) of the function. |Arguments| is the list of
        /// arguments passed to the function. If execution succeeds set |Retval| to the
        /// function return value. If execution fails set |Exception| to the exception
        /// that will be thrown. Return true (1) if execution was handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxV8HandlerExecuteEventArgs : CfxEventArgs {

            internal IntPtr m_name_str;
            internal int m_name_length;
            internal string m_name;
            internal IntPtr m_object;
            internal CfxV8Value m_object_wrapped;
            internal IntPtr[] m_arguments;
            internal CfxV8Value[] m_arguments_managed;
            internal string m_exception_wrapped;

            internal CfxV8Value m_returnValue;
            private bool returnValueSet;

            internal CfxV8HandlerExecuteEventArgs(IntPtr name_str, int name_length, IntPtr @object, IntPtr arguments, int argumentsCount) {
                m_name_str = name_str;
                m_name_length = name_length;
                m_object = @object;
                m_arguments = new IntPtr[argumentsCount];
                if(argumentsCount > 0) {
                    System.Runtime.InteropServices.Marshal.Copy(arguments, m_arguments, 0, argumentsCount);
                }
            }

            /// <summary>
            /// Get the Name parameter for the <see cref="CfxV8Handler.Execute"/> callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    m_name = StringFunctions.PtrToStringUni(m_name_str, m_name_length);
                    return m_name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Handler.Execute"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Arguments parameter for the <see cref="CfxV8Handler.Execute"/> callback.
            /// </summary>
            public CfxV8Value[] Arguments {
                get {
                    CheckAccess();
                    if(m_arguments_managed == null) {
                        m_arguments_managed = new CfxV8Value[m_arguments.Length];
                        for(int i = 0; i < m_arguments.Length; ++i) {
                            m_arguments_managed[i] = CfxV8Value.Wrap(m_arguments[i]);
                        }
                    }
                    return m_arguments_managed;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Handler.Execute"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Handler.Execute"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxV8Value returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}, Arguments={{{2}}}", Name, Object, Arguments);
            }
        }

    }
}
