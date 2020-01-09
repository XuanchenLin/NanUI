// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to represent post data for a web request. The functions of
    /// this structure may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
    /// </remarks>
    public class CfrPostData : CfrBaseLibrary {

        internal static CfrPostData Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrPostData)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrPostData(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrPostData object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public static CfrPostData Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxPostDataCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrPostData.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrPostData(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxPostDataIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the underlying POST data includes elements that are not
        /// represented by this CfrPostData object (for example, multi-part file
        /// upload data). Modifying CfrPostData objects with excluded elements may
        /// result in the request failing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool HasExcludedElements {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxPostDataHasExcludedElementsRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxPostDataGetElementCountRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Retrieve the post data elements.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfrPostDataElement[] Elements {
            get {
                var call = new CfxPostDataGetElementsRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                if(call.__retval == null) return null;
                var retval = new CfrPostDataElement[call.__retval.Length];
                for(int i = 0; i < retval.Length; ++i) {
                    retval[i] = CfrPostDataElement.Wrap(new RemotePtr(connection, call.__retval[i]));
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
        public bool RemoveElement(CfrPostDataElement element) {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataRemoveElementRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(element, connection)) throw new ArgumentException("Render process connection mismatch.", "element");
            call.element = CfrObject.Unwrap(element).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Add the specified post data element.  Returns true (1) if the add succeeds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool AddElement(CfrPostDataElement element) {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataAddElementRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(element, connection)) throw new ArgumentException("Render process connection mismatch.", "element");
            call.element = CfrObject.Unwrap(element).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Remove all existing post data elements.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void RemoveElements() {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataRemoveElementsRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }
    }
}
