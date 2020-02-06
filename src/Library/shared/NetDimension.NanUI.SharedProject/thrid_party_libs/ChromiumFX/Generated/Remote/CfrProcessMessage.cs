// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a message. Can be used on any process and thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
    /// </remarks>
    public class CfrProcessMessage : CfrBaseLibrary {

        internal static CfrProcessMessage Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrProcessMessage)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrProcessMessage(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrProcessMessage object with the specified name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public static CfrProcessMessage Create(string name) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxProcessMessageCreateRemoteCall();
            call.name = name;
            call.RequestExecution(connection);
            return CfrProcessMessage.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrProcessMessage(RemotePtr remotePtr) : base(remotePtr) {}

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
                var connection = RemotePtr.connection;
                var call = new CfxProcessMessageIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxProcessMessageIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxProcessMessageGetNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the list of arguments.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public CfrListValue ArgumentList {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxProcessMessageGetArgumentListRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrListValue.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public CfrProcessMessage Copy() {
            var connection = RemotePtr.connection;
            var call = new CfxProcessMessageCopyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return CfrProcessMessage.Wrap(new RemotePtr(connection, call.__retval));
        }
    }
}
