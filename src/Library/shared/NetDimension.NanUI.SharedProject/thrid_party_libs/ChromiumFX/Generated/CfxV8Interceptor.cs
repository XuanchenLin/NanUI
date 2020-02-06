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
    /// Structure that should be implemented to handle V8 interceptor calls. The
    /// functions of this structure will be called on the thread associated with the
    /// V8 interceptor. Interceptor's named property handlers (with first argument of
    /// type CfxString) are called when object is indexed by string. Indexed property
    /// handlers (with first argument of type int) are called when object is indexed
    /// by integer.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfxV8Interceptor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_byname_native = get_byname;
            get_byindex_native = get_byindex;
            set_byname_native = set_byname;
            set_byindex_native = set_byindex;

            get_byname_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_byname_native);
            get_byindex_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_byindex_native);
            set_byname_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(set_byname_native);
            set_byindex_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(set_byindex_native);
        }

        // get_byname
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_byname_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static get_byname_delegate get_byname_native;
        private static IntPtr get_byname_native_ptr;

        internal static void get_byname(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                retval = default(IntPtr);
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxGetByNameEventArgs();
            e.m_name_str = name_str;
            e.m_name_length = name_length;
            e.m_object = @object;
            self.m_GetByName?.Invoke(self, e);
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

        // get_byindex
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_byindex_delegate(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static get_byindex_delegate get_byindex_native;
        private static IntPtr get_byindex_native_ptr;

        internal static void get_byindex(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                retval = default(IntPtr);
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxGetByIndexEventArgs();
            e.m_index = index;
            e.m_object = @object;
            self.m_GetByIndex?.Invoke(self, e);
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

        // set_byname
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void set_byname_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static set_byname_delegate set_byname_native;
        private static IntPtr set_byname_native_ptr;

        internal static void set_byname(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                value_release = 1;
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxSetByNameEventArgs();
            e.m_name_str = name_str;
            e.m_name_length = name_length;
            e.m_object = @object;
            e.m_value = value;
            self.m_SetByName?.Invoke(self, e);
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

        // set_byindex
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void set_byindex_delegate(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static set_byindex_delegate set_byindex_native;
        private static IntPtr set_byindex_native_ptr;

        internal static void set_byindex(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var self = (CfxV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                object_release = 1;
                value_release = 1;
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxSetByIndexEventArgs();
            e.m_index = index;
            e.m_object = @object;
            e.m_value = value;
            self.m_SetByIndex?.Invoke(self, e);
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

        public CfxV8Interceptor() : base(CfxApi.V8Interceptor.cfx_v8interceptor_ctor) {}

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the interceptor. If retrieval succeeds, set
        /// |Retval| to the return value. If the requested value does not exist, don't
        /// set either |Retval| or |Exception|. If retrieval fails, set |Exception| to
        /// the exception that will be thrown. If the property has an associated
        /// accessor, it will be called only if you don't set |Retval|. Return true (1)
        /// if interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxGetByNameEventHandler GetByName {
            add {
                lock(eventLock) {
                    if(m_GetByName == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 0, get_byname_native_ptr);
                    }
                    m_GetByName += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetByName -= value;
                    if(m_GetByName == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetByNameEventHandler m_GetByName;

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
        /// set |Retval| to the return value. If the requested value does not exist,
        /// don't set either |Retval| or |Exception|. If retrieval fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxGetByIndexEventHandler GetByIndex {
            add {
                lock(eventLock) {
                    if(m_GetByIndex == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 1, get_byindex_native_ptr);
                    }
                    m_GetByIndex += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetByIndex -= value;
                    if(m_GetByIndex == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetByIndexEventHandler m_GetByIndex;

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Name|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. This setter will always
        /// be called, even when the property has an associated accessor. Return true
        /// (1) if interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxSetByNameEventHandler SetByName {
            add {
                lock(eventLock) {
                    if(m_SetByName == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 2, set_byname_native_ptr);
                    }
                    m_SetByName += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_SetByName -= value;
                    if(m_SetByName == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxSetByNameEventHandler m_SetByName;

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxSetByIndexEventHandler SetByIndex {
            add {
                lock(eventLock) {
                    if(m_SetByIndex == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 3, set_byindex_native_ptr);
                    }
                    m_SetByIndex += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_SetByIndex -= value;
                    if(m_SetByIndex == null) {
                        CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxSetByIndexEventHandler m_SetByIndex;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetByName != null) {
                m_GetByName = null;
                CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetByIndex != null) {
                m_GetByIndex = null;
                CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_SetByName != null) {
                m_SetByName = null;
                CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_SetByIndex != null) {
                m_SetByIndex = null;
                CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the interceptor. If retrieval succeeds, set
        /// |Retval| to the return value. If the requested value does not exist, don't
        /// set either |Retval| or |Exception|. If retrieval fails, set |Exception| to
        /// the exception that will be thrown. If the property has an associated
        /// accessor, it will be called only if you don't set |Retval|. Return true (1)
        /// if interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetByNameEventHandler(object sender, CfxGetByNameEventArgs e);

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the interceptor. If retrieval succeeds, set
        /// |Retval| to the return value. If the requested value does not exist, don't
        /// set either |Retval| or |Exception|. If retrieval fails, set |Exception| to
        /// the exception that will be thrown. If the property has an associated
        /// accessor, it will be called only if you don't set |Retval|. Return true (1)
        /// if interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxGetByNameEventArgs : CfxEventArgs {

            internal IntPtr m_name_str;
            internal int m_name_length;
            internal string m_name;
            internal IntPtr m_object;
            internal CfxV8Value m_object_wrapped;
            internal CfxV8Value m_retval_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetByNameEventArgs() {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfxV8Interceptor.GetByName"/> callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    m_name = StringFunctions.PtrToStringUni(m_name_str, m_name_length);
                    return m_name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Interceptor.GetByName"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfxV8Interceptor.GetByName"/> callback.
            /// </summary>
            public CfxV8Value Retval {
                set {
                    CheckAccess();
                    m_retval_wrapped = value;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Interceptor.GetByName"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Interceptor.GetByName"/> callback.
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
        /// Handle retrieval of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
        /// set |Retval| to the return value. If the requested value does not exist,
        /// don't set either |Retval| or |Exception|. If retrieval fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetByIndexEventHandler(object sender, CfxGetByIndexEventArgs e);

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
        /// set |Retval| to the return value. If the requested value does not exist,
        /// don't set either |Retval| or |Exception|. If retrieval fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxGetByIndexEventArgs : CfxEventArgs {

            internal int m_index;
            internal IntPtr m_object;
            internal CfxV8Value m_object_wrapped;
            internal CfxV8Value m_retval_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetByIndexEventArgs() {}

            /// <summary>
            /// Get the Index parameter for the <see cref="CfxV8Interceptor.GetByIndex"/> callback.
            /// </summary>
            public int Index {
                get {
                    CheckAccess();
                    return m_index;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Interceptor.GetByIndex"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfxV8Interceptor.GetByIndex"/> callback.
            /// </summary>
            public CfxV8Value Retval {
                set {
                    CheckAccess();
                    m_retval_wrapped = value;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Interceptor.GetByIndex"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Interceptor.GetByIndex"/> callback.
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
                return String.Format("Index={{{0}}}, Object={{{1}}}", Index, Object);
            }
        }

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Name|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. This setter will always
        /// be called, even when the property has an associated accessor. Return true
        /// (1) if interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfxSetByNameEventHandler(object sender, CfxSetByNameEventArgs e);

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Name|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. This setter will always
        /// be called, even when the property has an associated accessor. Return true
        /// (1) if interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxSetByNameEventArgs : CfxEventArgs {

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

            internal CfxSetByNameEventArgs() {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfxV8Interceptor.SetByName"/> callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    m_name = StringFunctions.PtrToStringUni(m_name_str, m_name_length);
                    return m_name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Interceptor.SetByName"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfxV8Interceptor.SetByName"/> callback.
            /// </summary>
            public CfxV8Value Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfxV8Value.Wrap(m_value);
                    return m_value_wrapped;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Interceptor.SetByName"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Interceptor.SetByName"/> callback.
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

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfxSetByIndexEventHandler(object sender, CfxSetByIndexEventArgs e);

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxSetByIndexEventArgs : CfxEventArgs {

            internal int m_index;
            internal IntPtr m_object;
            internal CfxV8Value m_object_wrapped;
            internal IntPtr m_value;
            internal CfxV8Value m_value_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxSetByIndexEventArgs() {}

            /// <summary>
            /// Get the Index parameter for the <see cref="CfxV8Interceptor.SetByIndex"/> callback.
            /// </summary>
            public int Index {
                get {
                    CheckAccess();
                    return m_index;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfxV8Interceptor.SetByIndex"/> callback.
            /// </summary>
            public CfxV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfxV8Value.Wrap(m_object);
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfxV8Interceptor.SetByIndex"/> callback.
            /// </summary>
            public CfxV8Value Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfxV8Value.Wrap(m_value);
                    return m_value_wrapped;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfxV8Interceptor.SetByIndex"/> callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxV8Interceptor.SetByIndex"/> callback.
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
                return String.Format("Index={{{0}}}, Object={{{1}}}, Value={{{2}}}", Index, Object, Value);
            }
        }

    }
}
