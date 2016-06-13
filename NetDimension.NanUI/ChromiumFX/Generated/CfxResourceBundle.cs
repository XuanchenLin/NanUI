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
	/// Structure used for retrieving resources from the resource bundle (*.pak)
	/// files loaded by CEF during startup or via the CfxResourceBundleHandler
	/// returned from CfxApp.GetResourceBundleHandler. See CfxSettings for
	/// additional options related to resource bundle loading. The functions of this
	/// structure may be called on any thread unless otherwise indicated.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_capi.h">cef/include/capi/cef_resource_bundle_capi.h</see>.
	/// </remarks>
	public class CfxResourceBundle : CfxBase {

        static CfxResourceBundle () {
            CfxApiLoader.LoadCfxResourceBundleApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxResourceBundle Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxResourceBundle)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxResourceBundle(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxResourceBundle(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the global resource bundle instance.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_capi.h">cef/include/capi/cef_resource_bundle_capi.h</see>.
        /// </remarks>
        public static CfxResourceBundle GetGlobal() {
            return CfxResourceBundle.Wrap(CfxApi.cfx_resource_bundle_get_global());
        }

        /// <summary>
        /// Returns the localized string for the specified |stringId| or an NULL
        /// string if the value is not found. Include cef_pack_strings.h for a listing
        /// of valid string ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_capi.h">cef/include/capi/cef_resource_bundle_capi.h</see>.
        /// </remarks>
        public string GetLocalizedString(int stringId) {
            return StringFunctions.ConvertStringUserfree(CfxApi.cfx_resource_bundle_get_localized_string(NativePtr, stringId));
        }

        /// <summary>
        /// Retrieves the contents of the specified scale independent |resourceId|. If
        /// the value is found then |data| and |dataSize| will be populated and this
        /// function will return true (1). If the value is not found then this function
        /// will return false (0). The returned |data| pointer will remain resident in
        /// memory and should not be freed. Include cef_pack_resources.h for a listing
        /// of valid resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_capi.h">cef/include/capi/cef_resource_bundle_capi.h</see>.
        /// </remarks>
        public bool GetDataResource(int resourceId, out IntPtr data, out int dataSize) {
            return 0 != CfxApi.cfx_resource_bundle_get_data_resource(NativePtr, resourceId, out data, out dataSize);
        }

        /// <summary>
        /// Retrieves the contents of the specified |resourceId| nearest the scale
        /// factor |scaleFactor|. Use a |scaleFactor| value of SCALE_FACTOR_NONE for
        /// scale independent resources or call GetDataResource instead. If the value
        /// is found then |data| and |dataSize| will be populated and this function
        /// will return true (1). If the value is not found then this function will
        /// return false (0). The returned |data| pointer will remain resident in
        /// memory and should not be freed. Include cef_pack_resources.h for a listing
        /// of valid resource ID values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_capi.h">cef/include/capi/cef_resource_bundle_capi.h</see>.
        /// </remarks>
        public bool GetDataResourceForScale(int resourceId, CfxScaleFactor scaleFactor, out IntPtr data, out int dataSize) {
            return 0 != CfxApi.cfx_resource_bundle_get_data_resource_for_scale(NativePtr, resourceId, (int)scaleFactor, out data, out dataSize);
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
