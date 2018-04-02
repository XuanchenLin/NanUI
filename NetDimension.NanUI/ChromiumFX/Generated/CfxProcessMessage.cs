// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a message. Can be used on any process and thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
    /// </remarks>
    public class CfxProcessMessage : CfxBaseLibrary {

        internal static CfxProcessMessage Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxProcessMessage)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxProcessMessage(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxProcessMessage(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxProcessMessage object with the specified name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public static CfxProcessMessage Create(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.ProcessMessage.cfx_process_message_create(name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return CfxProcessMessage.Wrap(__retval);
        }

        /// <summary>
        /// Returns true (1) if this object is valid. Do not call any other functions
        /// if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.ProcessMessage.cfx_process_message_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the values of this object are read-only. Some APIs may
        /// expose read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.ProcessMessage.cfx_process_message_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Returns the message name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public string Name {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.ProcessMessage.cfx_process_message_get_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the list of arguments.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public CfxListValue ArgumentList {
            get {
                return CfxListValue.Wrap(CfxApi.ProcessMessage.cfx_process_message_get_argument_list(NativePtr));
            }
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public CfxProcessMessage Copy() {
            return CfxProcessMessage.Wrap(CfxApi.ProcessMessage.cfx_process_message_copy(NativePtr));
        }
    }
}
