// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    /// <summary>
    /// Structure used to implement a custom resource bundle structure. See
    /// CfrSettings for additional options related to resource bundle loading. The
    /// functions of this structure may be called on multiple threads.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_bundle_handler_capi.h">cef/include/capi/cef_resource_bundle_handler_capi.h</see>.
    /// </remarks>
    public class CfrResourceBundleHandler : CfrBaseClient {


        private CfrResourceBundleHandler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrResourceBundleHandler() : base(new CfxResourceBundleHandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

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
        public event CfrGetLocalizedStringEventHandler GetLocalizedString {
            add {
                if(m_GetLocalizedString == null) {
                    var call = new CfxResourceBundleHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetLocalizedString += value;
            }
            remove {
                m_GetLocalizedString -= value;
                if(m_GetLocalizedString == null) {
                    var call = new CfxResourceBundleHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetLocalizedStringEventHandler m_GetLocalizedString;


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
        public event CfrGetDataResourceEventHandler GetDataResource {
            add {
                if(m_GetDataResource == null) {
                    var call = new CfxResourceBundleHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetDataResource += value;
            }
            remove {
                m_GetDataResource -= value;
                if(m_GetDataResource == null) {
                    var call = new CfxResourceBundleHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetDataResourceEventHandler m_GetDataResource;


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
        public event CfrGetDataResourceForScaleEventHandler GetDataResourceForScale {
            add {
                if(m_GetDataResourceForScale == null) {
                    var call = new CfxResourceBundleHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetDataResourceForScale += value;
            }
            remove {
                m_GetDataResourceForScale -= value;
                if(m_GetDataResourceForScale == null) {
                    var call = new CfxResourceBundleHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetDataResourceForScaleEventHandler m_GetDataResourceForScale;


    }

    namespace Event {

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
        public delegate void CfrGetLocalizedStringEventHandler(object sender, CfrGetLocalizedStringEventArgs e);

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
        public class CfrGetLocalizedStringEventArgs : CfrEventArgs {

            private CfxResourceBundleHandlerGetLocalizedStringRemoteEventCall call;

            internal string m_string_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrGetLocalizedStringEventArgs(CfxResourceBundleHandlerGetLocalizedStringRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the StringId parameter for the <see cref="CfrResourceBundleHandler.GetLocalizedString"/> render process callback.
            /// </summary>
            public int StringId {
                get {
                    CheckAccess();
                    return call.string_id;
                }
            }
            /// <summary>
            /// Set the String out parameter for the <see cref="CfrResourceBundleHandler.GetLocalizedString"/> render process callback.
            /// </summary>
            public string String {
                set {
                    CheckAccess();
                    m_string_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrResourceBundleHandler.GetLocalizedString"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("StringId={{{0}}}", StringId);
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
        public delegate void CfrGetDataResourceEventHandler(object sender, CfrGetDataResourceEventArgs e);

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
        public class CfrGetDataResourceEventArgs : CfrEventArgs {

            private CfxResourceBundleHandlerGetDataResourceRemoteEventCall call;


            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrGetDataResourceEventArgs(CfxResourceBundleHandlerGetDataResourceRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the ResourceId parameter for the <see cref="CfrResourceBundleHandler.GetDataResource"/> render process callback.
            /// </summary>
            public int ResourceId {
                get {
                    CheckAccess();
                    return call.resource_id;
                }
            }
            /// <summary>
            /// Set the Data out parameter for the <see cref="CfrResourceBundleHandler.GetDataResource"/> render process callback.
            /// </summary>
            public RemotePtr Data {
                set {
                    CheckAccess();
                    call.data = value.ptr;
                }
            }
            /// <summary>
            /// Set the DataSize out parameter for the <see cref="CfrResourceBundleHandler.GetDataResource"/> render process callback.
            /// </summary>
            public ulong DataSize {
                set {
                    CheckAccess();
                    call.data_size = (UIntPtr)value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrResourceBundleHandler.GetDataResource"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
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
        public delegate void CfrGetDataResourceForScaleEventHandler(object sender, CfrGetDataResourceForScaleEventArgs e);

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
        public class CfrGetDataResourceForScaleEventArgs : CfrEventArgs {

            private CfxResourceBundleHandlerGetDataResourceForScaleRemoteEventCall call;


            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrGetDataResourceForScaleEventArgs(CfxResourceBundleHandlerGetDataResourceForScaleRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the ResourceId parameter for the <see cref="CfrResourceBundleHandler.GetDataResourceForScale"/> render process callback.
            /// </summary>
            public int ResourceId {
                get {
                    CheckAccess();
                    return call.resource_id;
                }
            }
            /// <summary>
            /// Get the ScaleFactor parameter for the <see cref="CfrResourceBundleHandler.GetDataResourceForScale"/> render process callback.
            /// </summary>
            public CfxScaleFactor ScaleFactor {
                get {
                    CheckAccess();
                    return (CfxScaleFactor)call.scale_factor;
                }
            }
            /// <summary>
            /// Set the Data out parameter for the <see cref="CfrResourceBundleHandler.GetDataResourceForScale"/> render process callback.
            /// </summary>
            public RemotePtr Data {
                set {
                    CheckAccess();
                    call.data = value.ptr;
                }
            }
            /// <summary>
            /// Set the DataSize out parameter for the <see cref="CfrResourceBundleHandler.GetDataResourceForScale"/> render process callback.
            /// </summary>
            public ulong DataSize {
                set {
                    CheckAccess();
                    call.data_size = (UIntPtr)value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrResourceBundleHandler.GetDataResourceForScale"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("ResourceId={{{0}}}, ScaleFactor={{{1}}}", ResourceId, ScaleFactor);
            }
        }

    }
}
