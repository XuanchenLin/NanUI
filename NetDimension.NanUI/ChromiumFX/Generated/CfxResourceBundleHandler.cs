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
	/// Structure used to implement a custom resource bundle structure. See
	/// CfxSettings for additional options related to resource bundle loading. The
	/// functions of this structure may be called on multiple threads.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
	/// </remarks>
	public class CfxResourceBundleHandler : CfxBase {

        static CfxResourceBundleHandler () {
            CfxApiLoader.LoadCfxResourceBundleHandlerApi();
        }

        internal static CfxResourceBundleHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_resource_bundle_handler_get_gc_handle(nativePtr);
            return (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // get_localized_string
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_resource_bundle_handler_get_localized_string_delegate(IntPtr gcHandlePtr, out int __retval, int string_id, ref IntPtr string_str, ref int string_length);
        private static cfx_resource_bundle_handler_get_localized_string_delegate cfx_resource_bundle_handler_get_localized_string;
        private static IntPtr cfx_resource_bundle_handler_get_localized_string_ptr;

        internal static void get_localized_string(IntPtr gcHandlePtr, out int __retval, int string_id, ref IntPtr string_str, ref int string_length) {
            var self = (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxGetLocalizedStringEventArgs(string_id, string_str, string_length);
            var eventHandler = self.m_GetLocalizedString;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_string_changed) {
                var string_pinned = new PinnedString(e.m_string_wrapped);
                string_str = string_pinned.Obj.PinnedPtr;
                string_length = string_pinned.Length;
            }
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_data_resource
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_resource_bundle_handler_get_data_resource_delegate(IntPtr gcHandlePtr, out int __retval, int resource_id, out IntPtr data, out int data_size);
        private static cfx_resource_bundle_handler_get_data_resource_delegate cfx_resource_bundle_handler_get_data_resource;
        private static IntPtr cfx_resource_bundle_handler_get_data_resource_ptr;

        internal static void get_data_resource(IntPtr gcHandlePtr, out int __retval, int resource_id, out IntPtr data, out int data_size) {
            var self = (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                data = default(IntPtr);
                data_size = default(int);
                return;
            }
            var e = new CfxGetDataResourceEventArgs(resource_id);
            var eventHandler = self.m_GetDataResource;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            data = e.m_data;
            data_size = e.m_data_size;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_data_resource_for_scale
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_resource_bundle_handler_get_data_resource_for_scale_delegate(IntPtr gcHandlePtr, out int __retval, int resource_id, int scale_factor, out IntPtr data, out int data_size);
        private static cfx_resource_bundle_handler_get_data_resource_for_scale_delegate cfx_resource_bundle_handler_get_data_resource_for_scale;
        private static IntPtr cfx_resource_bundle_handler_get_data_resource_for_scale_ptr;

        internal static void get_data_resource_for_scale(IntPtr gcHandlePtr, out int __retval, int resource_id, int scale_factor, out IntPtr data, out int data_size) {
            var self = (CfxResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                data = default(IntPtr);
                data_size = default(int);
                return;
            }
            var e = new CfxGetDataResourceForScaleEventArgs(resource_id, scale_factor);
            var eventHandler = self.m_GetDataResourceForScale;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            data = e.m_data;
            data_size = e.m_data_size;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxResourceBundleHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxResourceBundleHandler() : base(CfxApi.cfx_resource_bundle_handler_ctor) {}

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
                        if(cfx_resource_bundle_handler_get_localized_string == null) {
                            cfx_resource_bundle_handler_get_localized_string = get_localized_string;
                            cfx_resource_bundle_handler_get_localized_string_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_resource_bundle_handler_get_localized_string);
                        }
                        CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 0, cfx_resource_bundle_handler_get_localized_string_ptr);
                    }
                    m_GetLocalizedString += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLocalizedString -= value;
                    if(m_GetLocalizedString == null) {
                        CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_resource_bundle_handler_get_data_resource == null) {
                            cfx_resource_bundle_handler_get_data_resource = get_data_resource;
                            cfx_resource_bundle_handler_get_data_resource_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_resource_bundle_handler_get_data_resource);
                        }
                        CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 1, cfx_resource_bundle_handler_get_data_resource_ptr);
                    }
                    m_GetDataResource += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDataResource -= value;
                    if(m_GetDataResource == null) {
                        CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
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
                        if(cfx_resource_bundle_handler_get_data_resource_for_scale == null) {
                            cfx_resource_bundle_handler_get_data_resource_for_scale = get_data_resource_for_scale;
                            cfx_resource_bundle_handler_get_data_resource_for_scale_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_resource_bundle_handler_get_data_resource_for_scale);
                        }
                        CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 2, cfx_resource_bundle_handler_get_data_resource_for_scale_ptr);
                    }
                    m_GetDataResourceForScale += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDataResourceForScale -= value;
                    if(m_GetDataResourceForScale == null) {
                        CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetDataResourceForScaleEventHandler m_GetDataResourceForScale;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetLocalizedString != null) {
                m_GetLocalizedString = null;
                CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetDataResource != null) {
                m_GetDataResource = null;
                CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetDataResourceForScale != null) {
                m_GetDataResourceForScale = null;
                CfxApi.cfx_resource_bundle_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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
            internal IntPtr m_string_str;
            internal int m_string_length;
            internal string m_string_wrapped;
            internal bool m_string_changed;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetLocalizedStringEventArgs(int string_id, IntPtr string_str, int string_length) {
                m_string_id = string_id;
                m_string_str = string_str;
                m_string_length = string_length;
            }

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
            /// Get or set the String parameter for the <see cref="CfxResourceBundleHandler.GetLocalizedString"/> callback.
            /// </summary>
            public string String {
                get {
                    CheckAccess();
                    if(!m_string_changed && m_string_wrapped == null) {
                        m_string_wrapped = StringFunctions.PtrToStringUni(m_string_str, m_string_length);
                    }
                    return m_string_wrapped;
                }
                set {
                    CheckAccess();
                    m_string_wrapped = value;
                    m_string_changed = true;
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
                return String.Format("StringId={{{0}}}, String={{{1}}}", StringId, String);
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
            internal int m_data_size;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetDataResourceEventArgs(int resource_id) {
                m_resource_id = resource_id;
            }

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
            public int DataSize {
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
            internal int m_data_size;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetDataResourceForScaleEventArgs(int resource_id, int scale_factor) {
                m_resource_id = resource_id;
                m_scale_factor = scale_factor;
            }

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
            public int DataSize {
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
