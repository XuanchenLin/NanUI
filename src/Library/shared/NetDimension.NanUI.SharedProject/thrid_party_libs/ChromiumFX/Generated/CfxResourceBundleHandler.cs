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
    /// Structure used to implement a custom resource bundle structure. See
    /// CfxSettings for additional options related to resource bundle loading. The
    /// functions of this structure may be called on multiple threads.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
    /// </remarks>
    public class CfxResourceBundleHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_localized_string_native = get_localized_string;
            get_data_resource_native = get_data_resource;
            get_data_resource_for_scale_native = get_data_resource_for_scale;

            get_localized_string_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_localized_string_native);
            get_data_resource_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_data_resource_native);
            get_data_resource_for_scale_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_data_resource_for_scale_native);
        }

        // get_localized_string
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_localized_string_delegate(IntPtr gcHandlePtr, out int __retval, int string_id, out IntPtr string_str, out int string_length, out IntPtr string_gc_handle);
        private static get_localized_string_delegate get_localized_string_native;
        private static IntPtr get_localized_string_native_ptr;

        internal static void get_localized_string(IntPtr gcHandlePtr, out int __retval, int string_id, out IntPtr string_str, out int string_length, out IntPtr string_gc_handle) {
            var self = (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                string_str = IntPtr.Zero;
                string_length = 0;
                string_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxGetLocalizedStringEventArgs();
            e.m_string_id = string_id;
            self.m_GetLocalizedString?.Invoke(self, e);
            e.m_isInvalid = true;
            if(e.m_string_wrapped != null && e.m_string_wrapped.Length > 0) {
                var string_pinned = new PinnedString(e.m_string_wrapped);
                string_str = string_pinned.Obj.PinnedPtr;
                string_length = string_pinned.Length;
                string_gc_handle = string_pinned.Obj.GCHandlePtr();
            } else {
                string_str = IntPtr.Zero;
                string_length = 0;
                string_gc_handle = IntPtr.Zero;
            }
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_data_resource
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_data_resource_delegate(IntPtr gcHandlePtr, out int __retval, int resource_id, out IntPtr data, out UIntPtr data_size);
        private static get_data_resource_delegate get_data_resource_native;
        private static IntPtr get_data_resource_native_ptr;

        internal static void get_data_resource(IntPtr gcHandlePtr, out int __retval, int resource_id, out IntPtr data, out UIntPtr data_size) {
            var self = (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                data = default(IntPtr);
                data_size = default(UIntPtr);
                return;
            }
            var e = new CfxGetDataResourceEventArgs();
            e.m_resource_id = resource_id;
            self.m_GetDataResource?.Invoke(self, e);
            e.m_isInvalid = true;
            data = e.m_data;
            data_size = e.m_data_size;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_data_resource_for_scale
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_data_resource_for_scale_delegate(IntPtr gcHandlePtr, out int __retval, int resource_id, int scale_factor, out IntPtr data, out UIntPtr data_size);
        private static get_data_resource_for_scale_delegate get_data_resource_for_scale_native;
        private static IntPtr get_data_resource_for_scale_native_ptr;

        internal static void get_data_resource_for_scale(IntPtr gcHandlePtr, out int __retval, int resource_id, int scale_factor, out IntPtr data, out UIntPtr data_size) {
            var self = (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                data = default(IntPtr);
                data_size = default(UIntPtr);
                return;
            }
            var e = new CfxGetDataResourceForScaleEventArgs();
            e.m_resource_id = resource_id;
            e.m_scale_factor = scale_factor;
            self.m_GetDataResourceForScale?.Invoke(self, e);
            e.m_isInvalid = true;
            data = e.m_data;
            data_size = e.m_data_size;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxResourceBundleHandler() : base(CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_ctor) {}

        /// <summary>
        /// Called to retrieve a localized translation for the specified |StringId|.
        /// To provide the translation set |String| to the translation string and
        /// return true (1). To use the default translation return false (0). Include
        /// cef_pack_strings.h for a listing of valid string ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetLocalizedStringEventHandler GetLocalizedString {
            add {
                lock(eventLock) {
                    if(m_GetLocalizedString == null) {
                        CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 0, get_localized_string_native_ptr);
                    }
                    m_GetLocalizedString += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLocalizedString -= value;
                    if(m_GetLocalizedString == null) {
                        CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetLocalizedStringEventHandler m_GetLocalizedString;

        /// <summary>
        /// Called to retrieve data for the specified scale independent |ResourceId|.
        /// To provide the resource data set |Data| and |DataSize| to the data pointer
        /// and size respectively and return true (1). To use the default resource data
        /// return false (0). The resource data will not be copied and must remain
        /// resident in memory. Include cef_pack_resources.h for a listing of valid
        /// resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetDataResourceEventHandler GetDataResource {
            add {
                lock(eventLock) {
                    if(m_GetDataResource == null) {
                        CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 1, get_data_resource_native_ptr);
                    }
                    m_GetDataResource += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDataResource -= value;
                    if(m_GetDataResource == null) {
                        CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetDataResourceEventHandler m_GetDataResource;

        /// <summary>
        /// Called to retrieve data for the specified |ResourceId| nearest the scale
        /// factor |ScaleFactor|. To provide the resource data set |Data| and
        /// |DataSize| to the data pointer and size respectively and return true (1).
        /// To use the default resource data return false (0). The resource data will
        /// not be copied and must remain resident in memory. Include
        /// cef_pack_resources.h for a listing of valid resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetDataResourceForScaleEventHandler GetDataResourceForScale {
            add {
                lock(eventLock) {
                    if(m_GetDataResourceForScale == null) {
                        CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 2, get_data_resource_for_scale_native_ptr);
                    }
                    m_GetDataResourceForScale += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDataResourceForScale -= value;
                    if(m_GetDataResourceForScale == null) {
                        CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetDataResourceForScaleEventHandler m_GetDataResourceForScale;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetLocalizedString != null) {
                m_GetLocalizedString = null;
                CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetDataResource != null) {
                m_GetDataResource = null;
                CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetDataResourceForScale != null) {
                m_GetDataResourceForScale = null;
                CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called to retrieve a localized translation for the specified |StringId|.
        /// To provide the translation set |String| to the translation string and
        /// return true (1). To use the default translation return false (0). Include
        /// cef_pack_strings.h for a listing of valid string ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetLocalizedStringEventHandler(object sender, CfxGetLocalizedStringEventArgs e);

        /// <summary>
        /// Called to retrieve a localized translation for the specified |StringId|.
        /// To provide the translation set |String| to the translation string and
        /// return true (1). To use the default translation return false (0). Include
        /// cef_pack_strings.h for a listing of valid string ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetLocalizedStringEventArgs : CfxEventArgs {

            internal int m_string_id;
            internal string m_string_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetLocalizedStringEventArgs() {}

            /// <summary>
            /// Get the StringId parameter for the <see cref="CfxResourceBundleHandler.GetLocalizedString"/> callback.
            /// </summary>
            public int StringId {
                get {
                    CheckAccess();
                    return m_string_id;
                }
            }
            /// <summary>
            /// Set the String out parameter for the <see cref="CfxResourceBundleHandler.GetLocalizedString"/> callback.
            /// </summary>
            public string String {
                set {
                    CheckAccess();
                    m_string_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceBundleHandler.GetLocalizedString"/> callback.
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
                return String.Format("StringId={{{0}}}", StringId);
            }
        }

        /// <summary>
        /// Called to retrieve data for the specified scale independent |ResourceId|.
        /// To provide the resource data set |Data| and |DataSize| to the data pointer
        /// and size respectively and return true (1). To use the default resource data
        /// return false (0). The resource data will not be copied and must remain
        /// resident in memory. Include cef_pack_resources.h for a listing of valid
        /// resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetDataResourceEventHandler(object sender, CfxGetDataResourceEventArgs e);

        /// <summary>
        /// Called to retrieve data for the specified scale independent |ResourceId|.
        /// To provide the resource data set |Data| and |DataSize| to the data pointer
        /// and size respectively and return true (1). To use the default resource data
        /// return false (0). The resource data will not be copied and must remain
        /// resident in memory. Include cef_pack_resources.h for a listing of valid
        /// resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetDataResourceEventArgs : CfxEventArgs {

            internal int m_resource_id;
            internal IntPtr m_data;
            internal UIntPtr m_data_size;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetDataResourceEventArgs() {}

            /// <summary>
            /// Get the ResourceId parameter for the <see cref="CfxResourceBundleHandler.GetDataResource"/> callback.
            /// </summary>
            public int ResourceId {
                get {
                    CheckAccess();
                    return m_resource_id;
                }
            }
            /// <summary>
            /// Set the Data out parameter for the <see cref="CfxResourceBundleHandler.GetDataResource"/> callback.
            /// </summary>
            public IntPtr Data {
                set {
                    CheckAccess();
                    m_data = value;
                }
            }
            /// <summary>
            /// Set the DataSize out parameter for the <see cref="CfxResourceBundleHandler.GetDataResource"/> callback.
            /// </summary>
            public UIntPtr DataSize {
                set {
                    CheckAccess();
                    m_data_size = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceBundleHandler.GetDataResource"/> callback.
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
                return String.Format("ResourceId={{{0}}}", ResourceId);
            }
        }

        /// <summary>
        /// Called to retrieve data for the specified |ResourceId| nearest the scale
        /// factor |ScaleFactor|. To provide the resource data set |Data| and
        /// |DataSize| to the data pointer and size respectively and return true (1).
        /// To use the default resource data return false (0). The resource data will
        /// not be copied and must remain resident in memory. Include
        /// cef_pack_resources.h for a listing of valid resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetDataResourceForScaleEventHandler(object sender, CfxGetDataResourceForScaleEventArgs e);

        /// <summary>
        /// Called to retrieve data for the specified |ResourceId| nearest the scale
        /// factor |ScaleFactor|. To provide the resource data set |Data| and
        /// |DataSize| to the data pointer and size respectively and return true (1).
        /// To use the default resource data return false (0). The resource data will
        /// not be copied and must remain resident in memory. Include
        /// cef_pack_resources.h for a listing of valid resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetDataResourceForScaleEventArgs : CfxEventArgs {

            internal int m_resource_id;
            internal int m_scale_factor;
            internal IntPtr m_data;
            internal UIntPtr m_data_size;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetDataResourceForScaleEventArgs() {}

            /// <summary>
            /// Get the ResourceId parameter for the <see cref="CfxResourceBundleHandler.GetDataResourceForScale"/> callback.
            /// </summary>
            public int ResourceId {
                get {
                    CheckAccess();
                    return m_resource_id;
                }
            }
            /// <summary>
            /// Get the ScaleFactor parameter for the <see cref="CfxResourceBundleHandler.GetDataResourceForScale"/> callback.
            /// </summary>
            public CfxScaleFactor ScaleFactor {
                get {
                    CheckAccess();
                    return (CfxScaleFactor)m_scale_factor;
                }
            }
            /// <summary>
            /// Set the Data out parameter for the <see cref="CfxResourceBundleHandler.GetDataResourceForScale"/> callback.
            /// </summary>
            public IntPtr Data {
                set {
                    CheckAccess();
                    m_data = value;
                }
            }
            /// <summary>
            /// Set the DataSize out parameter for the <see cref="CfxResourceBundleHandler.GetDataResourceForScale"/> callback.
            /// </summary>
            public UIntPtr DataSize {
                set {
                    CheckAccess();
                    m_data_size = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceBundleHandler.GetDataResourceForScale"/> callback.
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
                return String.Format("ResourceId={{{0}}}, ScaleFactor={{{1}}}", ResourceId, ScaleFactor);
            }
        }

    }
}
