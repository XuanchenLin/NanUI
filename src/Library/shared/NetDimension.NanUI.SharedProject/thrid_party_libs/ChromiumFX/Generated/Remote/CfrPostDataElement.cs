// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to represent a single element in the request post data. The
    /// functions of this structure may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
    /// </remarks>
    public class CfrPostDataElement : CfrBaseLibrary {

        internal static CfrPostDataElement Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrPostDataElement)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrPostDataElement(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrPostDataElement object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public static CfrPostDataElement Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxPostDataElementCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrPostDataElement.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrPostDataElement(RemotePtr remotePtr) : base(remotePtr) {}

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
                var call = new CfxPostDataElementIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Return the type of this post data element.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfxPostdataElementType Type {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxPostDataElementGetTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxPostdataElementType)call.__retval;
            }
        }

        /// <summary>
        /// Return the file name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string File {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxPostDataElementGetFileRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Return the number of bytes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public ulong BytesCount {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxPostDataElementGetBytesCountRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Remove all contents from the post data element.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void SetToEmpty() {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataElementSetToEmptyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// The post data element will represent a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void SetToFile(string fileName) {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataElementSetToFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.fileName = fileName;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// The post data element will represent bytes.  The bytes passed in will be
        /// copied.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void SetToBytes(ulong size, RemotePtr bytes) {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataElementSetToBytesRemoteCall();
            call.@this = RemotePtr.ptr;
            call.size = size;
            if(bytes.connection != connection) throw new ArgumentException("Render process connection mismatch.", "bytes");
            call.bytes = bytes.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Read up to |size| bytes into |bytes| and return the number of bytes
        /// actually read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public ulong GetBytes(ulong size, RemotePtr bytes) {
            var connection = RemotePtr.connection;
            var call = new CfxPostDataElementGetBytesRemoteCall();
            call.@this = RemotePtr.ptr;
            call.size = size;
            if(bytes.connection != connection) throw new ArgumentException("Render process connection mismatch.", "bytes");
            call.bytes = bytes.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
