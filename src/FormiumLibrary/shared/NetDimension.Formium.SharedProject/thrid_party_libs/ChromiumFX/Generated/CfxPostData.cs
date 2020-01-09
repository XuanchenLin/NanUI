// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent post data for a web request. The functions of
    /// this structure may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
    /// </remarks>
    public class CfxPostData : CfxBaseLibrary {

        internal static CfxPostData Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxPostData)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxPostData(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxPostData(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxPostData object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public static CfxPostData Create() {
            return CfxPostData.Wrap(CfxApi.PostData.cfx_post_data_create());
        }

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.PostData.cfx_post_data_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the underlying POST data includes elements that are not
        /// represented by this CfxPostData object (for example, multi-part file
        /// upload data). Modifying CfxPostData objects with excluded elements may
        /// result in the request failing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool HasExcludedElements {
            get {
                return 0 != CfxApi.PostData.cfx_post_data_has_excluded_elements(NativePtr);
            }
        }

        /// <summary>
        /// Returns the number of existing post data elements.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public ulong ElementCount {
            get {
                return (ulong)CfxApi.PostData.cfx_post_data_get_element_count(NativePtr);
            }
        }

        /// <summary>
        /// Retrieve the post data elements.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfxPostDataElement[] Elements {
            get {
                var count = ElementCount;
                if(count == 0) return new CfxPostDataElement[0];
                IntPtr[] ptrs = new IntPtr[count];
                var ptrs_p = new PinnedObject(ptrs);
                CfxApi.PostData.cfx_post_data_get_elements(NativePtr, (UIntPtr)count, ptrs_p.PinnedPtr);
                ptrs_p.Free();
                CfxPostDataElement[] retval = new CfxPostDataElement[count];
                for(ulong i = 0; i < count; ++i) {
                    retval[i] = CfxPostDataElement.Wrap(ptrs[i]);
                }
                return retval;
            }
        }

        /// <summary>
        /// Remove the specified post data element.  Returns true (1) if the removal
        /// succeeds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool RemoveElement(CfxPostDataElement element) {
            return 0 != CfxApi.PostData.cfx_post_data_remove_element(NativePtr, CfxPostDataElement.Unwrap(element));
        }

        /// <summary>
        /// Add the specified post data element.  Returns true (1) if the add succeeds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool AddElement(CfxPostDataElement element) {
            return 0 != CfxApi.PostData.cfx_post_data_add_element(NativePtr, CfxPostDataElement.Unwrap(element));
        }

        /// <summary>
        /// Remove all existing post data elements.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void RemoveElements() {
            CfxApi.PostData.cfx_post_data_remove_elements(NativePtr);
        }
    }
}
