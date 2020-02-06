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
    /// Structure that should be implemented to handle V8 accessor calls. Accessor
    /// identifiers are registered by calling CfxV8Value.SetValue(). The
    /// functions of this structure will be called on the thread associated with the
    /// V8 accessor.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfxV8Accessor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_native = get;
            set_native = set;

            get_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_native);
            set_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(set_native);
        }

        // get
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static get_delegate get_native;
        private static IntPtr get_native_ptr;

        internal static void get(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Accessor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                retval = default(IntPtr);
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxV8AccessorGetEventArgs();
            e.m_name_str = name_str;
            e.m_name_length = name_length;
            e.m_object = @object;
            self.m_Get?.Invoke(self, e);
            e.m_isInvalid = true;
            object_release = e.m_object_wrapped == null? 1 : 0;
            retval = CfxV8Value.Unwrap(e.m_retval_wrapped);
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
            __retval = e.m_returnValue ? 1 : 0;
        }

        // set
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void set_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static set_delegate set_native;
        private static IntPtr set_native_ptr;

        internal static void set(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Accessor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                value_release = 1;
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxV8AccessorSetEventArgs();
            e.m_name_str = name_str;
            e.m_name_length = name_length;
            e.m_object = @object;
            e.m_value = value;
            self.m_Set?.Invoke(self, e);
            e.m_isInvalid = true;
            object_release = e.m_object_wrapped == null? 1 : 0;
            value_release = e.m_value_wrapped == null? 1 : 0;
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
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxV8Accessor() : base(CfxApi.V8Accessor.cfx_v8accessor_ctor) {}

        /// <summary>
        /// Handle retrieval the accessor value identified by |Name|. |Object| is the
        /// receiver ('this' object) of the accessor. If retrieval succeeds set
        /// |Retval| to the return value. If retrieval fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor retrieval was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxV8AccessorGetEventHandler Get {
            add {
                lock(eventLock) {
                    if(m_Get == null) {
                        CfxApi.V8Accessor.cfx_v8accessor_set_callback(NativePtr, 0, get_native_ptr);
                    }
                    m_Get += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Get -= value;
                    if(m_Get == null) {
                        CfxApi.V8Accessor.cfx_v8accessor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxV8AccessorGetEventHandler m_Get;

        /// <summary>
        /// Handle assignment of the accessor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the accessor. |Value| is the new value
        /// being assigned to the accessor. If assignment fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor assignment was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxV8AccessorSetEventHandler Set {
            add {
                lock(eventLock) {
                    if(m_Set == null) {
                        CfxApi.V8Accessor.cfx_v8accessor_set_callback(NativePtr, 1, set_native_ptr);
                    }
                    m_Set += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Set -= value;
                    if(m_Set == null) {
                        CfxApi.V8Accessor.cfx_v8accessor_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxV8AccessorSetEventHandler m_Set;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Get != null) {
                m_Get = null;
                CfxApi.V8Accessor.cfx_v8accessor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_Set != null) {
                m_Set = null;
                CfxApi.V8Accessor.cfx_v8accessor_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Handle retrieval the accessor value identified by |Name|. |Object| is the
        /// receiver ('this' object) of the accessor. If retrieval succeeds set
        /// |Retval| to the return value. If retrieval fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor retrieval was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfxV8AccessorGetEventHandler(object sender, CfxV8AccessorGetEventArgs e);

        /// <summary>
        /// Handle retrieval the accessor value identified by |Name|. |Object| is the
        /// receiver ('this' object) of the accessor. If retrieval succeeds set
        /// |Retval| to the return value. If retrieval fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor retrieval was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxV8AccessorGetEventArgs : CfxEventArgs {

            internal IntPtr m_name_str;
            internal int m_name_length;
            internal string m_name;
            internal IntPtr m_object;
            internal CfxV8Value m_object_wrapped;
            internal CfxV8Value m_retval_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxV8AccessorGetEventArgs() {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfxV8Accessor.Get"/> callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    m_name = StringFunctions.PtrToStringUni(m_name_str, m_name_length);
                    return m_name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Accessor.Get"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfxV8Accessor.Get"/> callback.
            /// </summary>
            public CfxV8Value Retval {
                set {
                    CheckAccess();
                    m_retval_wrapped = value;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Accessor.Get"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Accessor.Get"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}", Name, Object);
            }
        }

        /// <summary>
        /// Handle assignment of the accessor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the accessor. |Value| is the new value
        /// being assigned to the accessor. If assignment fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor assignment was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfxV8AccessorSetEventHandler(object sender, CfxV8AccessorSetEventArgs e);

        /// <summary>
        /// Handle assignment of the accessor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the accessor. |Value| is the new value
        /// being assigned to the accessor. If assignment fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor assignment was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxV8AccessorSetEventArgs : CfxEventArgs {

            internal IntPtr m_name_str;
            internal int m_name_length;
            internal string m_name;
            internal IntPtr m_object;
            internal CfxV8Value m_object_wrapped;
            internal IntPtr m_value;
            internal CfxV8Value m_value_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxV8AccessorSetEventArgs() {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfxV8Accessor.Set"/> callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    m_name = StringFunctions.PtrToStringUni(m_name_str, m_name_length);
                    return m_name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Accessor.Set"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfxV8Accessor.Set"/> callback.
            /// </summary>
            public CfxV8Value Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfxV8Value.Wrap(m_value);
                    return m_value_wrapped;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Accessor.Set"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Accessor.Set"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}, Value={{{2}}}", Name, Object, Value);
            }
        }

    }
}
