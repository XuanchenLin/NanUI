// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxResourceBundle : CfxBaseLibrary {

        internal static CfxResourceBundle Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxResourceBundle)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxResourceBundle(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
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
            return CfxResourceBundle.Wrap(CfxApi.ResourceBundle.cfx_resource_bundle_get_global());
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
            return StringFunctions.ConvertStringUserfree(CfxApi.ResourceBundle.cfx_resource_bundle_get_localized_string(NativePtr, stringId));
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
        public bool GetDataResource(int resourceId, out IntPtr data, out ulong dataSize) {
            UIntPtr dataSize_tmp = UIntPtr.Zero;
            var __retval = CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource(NativePtr, resourceId, out data, out dataSize_tmp);
            dataSize = (ulong)dataSize_tmp;
            return 0 != __retval;
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
        public bool GetDataResourceForScale(int resourceId, CfxScaleFactor scaleFactor, out IntPtr data, out ulong dataSize) {
            UIntPtr dataSize_tmp = UIntPtr.Zero;
            var __retval = CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_for_scale(NativePtr, resourceId, (int)scaleFactor, out data, out dataSize_tmp);
            dataSize = (ulong)dataSize_tmp;
            return 0 != __retval;
        }
    }
}
