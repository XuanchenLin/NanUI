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
    /// Implement this structure to receive geolocation updates. The functions of
    /// this structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_capi.h">cef/include/capi/cef_geolocation_capi.h</see>.
    /// </remarks>
    public class CfxGetGeolocationCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_location_update_native = on_location_update;

            on_location_update_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_location_update_native);
        }

        // on_location_update
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_location_update_delegate(IntPtr gcHandlePtr, IntPtr position);
        private static on_location_update_delegate on_location_update_native;
        private static IntPtr on_location_update_native_ptr;

        internal static void on_location_update(IntPtr gcHandlePtr, IntPtr position) {
            var self = (CfxGetGeolocationCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxGetGeolocationCallbackOnLocationUpdateEventArgs(position);
            self.m_OnLocationUpdate?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxGetGeolocationCallback() : base(CfxApi.GetGeolocationCallback.cfx_get_geolocation_callback_ctor) {}

        /// <summary>
        /// Called with the 'best available' location information or, if the location
        /// update failed, with error information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_capi.h">cef/include/capi/cef_geolocation_capi.h</see>.
        /// </remarks>
        public event CfxGetGeolocationCallbackOnLocationUpdateEventHandler OnLocationUpdate {
            add {
                lock(eventLock) {
                    if(m_OnLocationUpdate == null) {
                        CfxApi.GetGeolocationCallback.cfx_get_geolocation_callback_set_callback(NativePtr, 0, on_location_update_native_ptr);
                    }
                    m_OnLocationUpdate += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLocationUpdate -= value;
                    if(m_OnLocationUpdate == null) {
                        CfxApi.GetGeolocationCallback.cfx_get_geolocation_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetGeolocationCallbackOnLocationUpdateEventHandler m_OnLocationUpdate;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnLocationUpdate != null) {
                m_OnLocationUpdate = null;
                CfxApi.GetGeolocationCallback.cfx_get_geolocation_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called with the 'best available' location information or, if the location
        /// update failed, with error information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_capi.h">cef/include/capi/cef_geolocation_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetGeolocationCallbackOnLocationUpdateEventHandler(object sender, CfxGetGeolocationCallbackOnLocationUpdateEventArgs e);

        /// <summary>
        /// Called with the 'best available' location information or, if the location
        /// update failed, with error information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_capi.h">cef/include/capi/cef_geolocation_capi.h</see>.
        /// </remarks>
        public class CfxGetGeolocationCallbackOnLocationUpdateEventArgs : CfxEventArgs {

            internal IntPtr m_position;
            internal CfxGeoposition m_position_wrapped;

            internal CfxGetGeolocationCallbackOnLocationUpdateEventArgs(IntPtr position) {
                m_position = position;
            }

            /// <summary>
            /// Get the Position parameter for the <see cref="CfxGetGeolocationCallback.OnLocationUpdate"/> callback.
            /// </summary>
            public CfxGeoposition Position {
                get {
                    CheckAccess();
                    if(m_position_wrapped == null) m_position_wrapped = CfxGeoposition.Wrap(m_position);
                    return m_position_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Position={{{0}}}", Position);
            }
        }

    }
}
