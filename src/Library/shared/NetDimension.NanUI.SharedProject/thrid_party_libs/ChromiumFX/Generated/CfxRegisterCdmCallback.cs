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
    /// Implement this structure to receive notification when CDM registration is
    /// complete. The functions of this structure will be called on the browser
    /// process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
    /// </remarks>
    public class CfxRegisterCdmCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_cdm_registration_complete_native = on_cdm_registration_complete;

            on_cdm_registration_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_cdm_registration_complete_native);
        }

        // on_cdm_registration_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_cdm_registration_complete_delegate(IntPtr gcHandlePtr, int result, IntPtr error_message_str, int error_message_length);
        private static on_cdm_registration_complete_delegate on_cdm_registration_complete_native;
        private static IntPtr on_cdm_registration_complete_native_ptr;

        internal static void on_cdm_registration_complete(IntPtr gcHandlePtr, int result, IntPtr error_message_str, int error_message_length) {
            var self = (CfxRegisterCdmCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnCdmRegistrationCompleteEventArgs();
            e.m_result = result;
            e.m_error_message_str = error_message_str;
            e.m_error_message_length = error_message_length;
            self.m_OnCdmRegistrationComplete?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxRegisterCdmCallback() : base(CfxApi.RegisterCdmCallback.cfx_register_cdm_callback_ctor) {}

        /// <summary>
        /// Method that will be called when CDM registration is complete. |Result| will
        /// be CEF_CDM_REGISTRATION_ERROR_NONE if registration completed successfully.
        /// Otherwise, |Result| and |ErrorMessage| will contain additional information
        /// about why registration failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public event CfxOnCdmRegistrationCompleteEventHandler OnCdmRegistrationComplete {
            add {
                lock(eventLock) {
                    if(m_OnCdmRegistrationComplete == null) {
                        CfxApi.RegisterCdmCallback.cfx_register_cdm_callback_set_callback(NativePtr, 0, on_cdm_registration_complete_native_ptr);
                    }
                    m_OnCdmRegistrationComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnCdmRegistrationComplete -= value;
                    if(m_OnCdmRegistrationComplete == null) {
                        CfxApi.RegisterCdmCallback.cfx_register_cdm_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnCdmRegistrationCompleteEventHandler m_OnCdmRegistrationComplete;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnCdmRegistrationComplete != null) {
                m_OnCdmRegistrationComplete = null;
                CfxApi.RegisterCdmCallback.cfx_register_cdm_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be called when CDM registration is complete. |Result| will
        /// be CEF_CDM_REGISTRATION_ERROR_NONE if registration completed successfully.
        /// Otherwise, |Result| and |ErrorMessage| will contain additional information
        /// about why registration failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnCdmRegistrationCompleteEventHandler(object sender, CfxOnCdmRegistrationCompleteEventArgs e);

        /// <summary>
        /// Method that will be called when CDM registration is complete. |Result| will
        /// be CEF_CDM_REGISTRATION_ERROR_NONE if registration completed successfully.
        /// Otherwise, |Result| and |ErrorMessage| will contain additional information
        /// about why registration failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public class CfxOnCdmRegistrationCompleteEventArgs : CfxEventArgs {

            internal int m_result;
            internal IntPtr m_error_message_str;
            internal int m_error_message_length;
            internal string m_error_message;

            internal CfxOnCdmRegistrationCompleteEventArgs() {}

            /// <summary>
            /// Get the Result parameter for the <see cref="CfxRegisterCdmCallback.OnCdmRegistrationComplete"/> callback.
            /// </summary>
            public CfxCdmRegistrationError Result {
                get {
                    CheckAccess();
                    return (CfxCdmRegistrationError)m_result;
                }
            }
            /// <summary>
            /// Get the ErrorMessage parameter for the <see cref="CfxRegisterCdmCallback.OnCdmRegistrationComplete"/> callback.
            /// </summary>
            public string ErrorMessage {
                get {
                    CheckAccess();
                    m_error_message = StringFunctions.PtrToStringUni(m_error_message_str, m_error_message_length);
                    return m_error_message;
                }
            }

            public override string ToString() {
                return String.Format("Result={{{0}}}, ErrorMessage={{{1}}}", Result, ErrorMessage);
            }
        }

    }
}
