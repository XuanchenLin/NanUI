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
	/// Implement this structure to receive geolocation updates. The functions of
	/// this structure will be called on the browser process UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_capi.h">cef/include/capi/cef_geolocation_capi.h</see>.
	/// </remarks>
	public class CfxGetGeolocationCallback : CfxBase {

        static CfxGetGeolocationCallback () {
            CfxApiLoader.LoadCfxGetGeolocationCallbackApi();
        }

        internal static CfxGetGeolocationCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_get_geolocation_callback_get_gc_handle(nativePtr);
            return (CfxGetGeolocationCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_location_update
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_get_geolocation_callback_on_location_update_delegate(IntPtr gcHandlePtr, IntPtr position);
        private static cfx_get_geolocation_callback_on_location_update_delegate cfx_get_geolocation_callback_on_location_update;
        private static IntPtr cfx_get_geolocation_callback_on_location_update_ptr;

        internal static void on_location_update(IntPtr gcHandlePtr, IntPtr position) {
            var self = (CfxGetGeolocationCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxGetGeolocationCallbackOnLocationUpdateEventArgs(position);
            var eventHandler = self.m_OnLocationUpdate;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxGetGeolocationCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxGetGeolocationCallback() : base(CfxApi.cfx_get_geolocation_callback_ctor) {}

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
                        if(cfx_get_geolocation_callback_on_location_update == null) {
                            cfx_get_geolocation_callback_on_location_update = on_location_update;
                            cfx_get_geolocation_callback_on_location_update_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_get_geolocation_callback_on_location_update);
                        }
                        CfxApi.cfx_get_geolocation_callback_set_managed_callback(NativePtr, 0, cfx_get_geolocation_callback_on_location_update_ptr);
                    }
                    m_OnLocationUpdate += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLocationUpdate -= value;
                    if(m_OnLocationUpdate == null) {
                        CfxApi.cfx_get_geolocation_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetGeolocationCallbackOnLocationUpdateEventHandler m_OnLocationUpdate;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnLocationUpdate != null) {
                m_OnLocationUpdate = null;
                CfxApi.cfx_get_geolocation_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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
