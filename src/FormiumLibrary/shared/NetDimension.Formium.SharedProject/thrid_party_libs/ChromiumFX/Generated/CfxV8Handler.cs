// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxV8Handler : CfxBaseClient {

        internal static CfxV8Handler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.V8Handler.cfx_v8handler_get_gc_handle(nativePtr);
            return (CfxV8Handler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            execute_native = execute;

            execute_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(execute_native);
        }

        // execute
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void execute_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, UIntPtr argumentsCount, IntPtr arguments, out int arguments_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static execute_delegate execute_native;
        private static IntPtr execute_native_ptr;

        internal static void execute(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, UIntPtr argumentsCount, IntPtr arguments, out int arguments_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Handler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                arguments_release = 1;
                retval = default(IntPtr);
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxV8HandlerExecuteEventArgs();
            e.m_name_str = name_str;
            e.m_name_length = name_length;
            e.m_object = @object;
            e.m_arguments = new IntPtr[(ulong)argumentsCount];
            if(e.m_arguments.Length > 0) {
                System.Runtime.InteropServices.Marshal.Copy(arguments, e.m_arguments, 0, (int)argumentsCount);
            }
            self.m_Execute?.Invoke(self, e);
            e.m_isInvalid = true;
            object_release = e.m_object_wrapped == null? 1 : 0;
            arguments_release = e.m_arguments_managed == null? 1 : 0;
            if(e.m_exception_wrapped != null && e.m_exception_wrapped.Length > 0) {
                var exception_pinned = new PinnedString(e.m_exception_wrapped);
                exception_str = exception_pinned.Obj.PinnedPtr;
                exception_length = exception_pinned.Length;
                exception_gc_handle = exception_pinned.Obj.GCHandlePtr();
            } else {
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
            }
            retval = CfxV8Value.Unwrap(e.m_returnValue);
            __retval = e.m_returnValue != null || e.m_exception_wrapped != null ? 1 : 0;
        }

        internal CfxV8Handler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxV8Handler() : base(CfxApi.V8Handler.cfx_v8handler_ctor) {}

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
                        CfxApi.V8Handler.cfx_v8handler_set_callback(NativePtr, 0, execute_native_ptr);
                    }
                    m_Execute += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Execute -= value;
                    if(m_Execute == null) {
                        CfxApi.V8Handler.cfx_v8handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxV8HandlerExecuteEventHandler m_Execute;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Execute != null) {
                m_Execute = null;
                CfxApi.V8Handler.cfx_v8handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

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

            internal CfxV8HandlerExecuteEventArgs() {}

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
