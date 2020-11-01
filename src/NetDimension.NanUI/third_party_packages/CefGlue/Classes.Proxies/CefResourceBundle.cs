namespace Xilium.CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Xilium.CefGlue.Interop;

    /// <summary>
    /// Class used for retrieving resources from the resource bundle (*.pak) files
    /// loaded by CEF during startup or via the CefResourceBundleHandler returned
    /// from CefApp::GetResourceBundleHandler. See CefSettings for additional options
    /// related to resource bundle loading. The methods of this class may be called
    /// on any thread unless otherwise indicated.
    /// </summary>
    public sealed unsafe partial class CefResourceBundle
    {
        /// <summary>
        /// Returns the global resource bundle instance.
        /// </summary>
        public static CefResourceBundle GetGlobal()
        {
            return CefResourceBundle.FromNative(cef_resource_bundle_t.get_global());
        }

        /// <summary>
        /// Returns the localized string for the specified |string_id| or an empty
        /// string if the value is not found. Include cef_pack_strings.h for a listing
        /// of valid string ID values.
        /// </summary>
        public string GetLocalizedString(int stringId)
        {
            var n_result = cef_resource_bundle_t.get_localized_string(_self, stringId);
            return cef_string_userfree.ToString(n_result);
        }

        /// <summary>
        /// Retrieves the contents of the specified scale independent |resource_id|.
        /// If the value is found then |data| and |data_size| will be populated and
        /// this method will return true. If the value is not found then this method
        /// will return false. The returned |data| pointer will remain resident in
        /// memory and should not be freed. Include cef_pack_resources.h for a listing
        /// of valid resource ID values.
        /// </summary>
        public bool GetDataResource(int resourceId, out void* data, out UIntPtr dataSize)
        {
            void* n_data;
            UIntPtr n_dataSize;
            var n_result = cef_resource_bundle_t.get_data_resource(_self, resourceId, &n_data, &n_dataSize);
            if (n_result != 0)
            {
                data = n_data;
                dataSize = n_dataSize;
                return true;
            }
            else
            {
                data = null;
                dataSize = UIntPtr.Zero;
                return false;
            }
        }

        /// <summary>
        /// Retrieves the contents of the specified |resource_id| nearest the scale
        /// factor |scale_factor|. Use a |scale_factor| value of SCALE_FACTOR_NONE for
        /// scale independent resources or call GetDataResource instead. If the value
        /// is found then |data| and |data_size| will be populated and this method will
        /// return true. If the value is not found then this method will return false.
        /// The returned |data| pointer will remain resident in memory and should not
        /// be freed. Include cef_pack_resources.h for a listing of valid resource ID
        /// values.
        /// </summary>
        public bool GetDataResourceForScale(int resourceId, CefScaleFactor scaleFactor, out void* data, out UIntPtr dataSize)
        {
            void* n_data;
            UIntPtr n_dataSize;
            var n_result = cef_resource_bundle_t.get_data_resource_for_scale(_self, resourceId, scaleFactor, &n_data, &n_dataSize);
            if (n_result != 0)
            {
                data = n_data;
                dataSize = n_dataSize;
                return true;
            }
            else
            {
                data = null;
                dataSize = UIntPtr.Zero;
                return false;
            }
        }
    }
}
