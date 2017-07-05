// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used for asynchronous continuation of geolocation
    /// permission requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
    /// </remarks>
    public class CfxGeolocationCallback : CfxBaseLibrary {

        internal static CfxGeolocationCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxGeolocationCallback)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxGeolocationCallback(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxGeolocationCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Call to allow or deny geolocation access.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
        /// </remarks>
        public void Continue(bool allow) {
            CfxApi.GeolocationCallback.cfx_geolocation_callback_cont(NativePtr, allow ? 1 : 0);
        }
    }
}
