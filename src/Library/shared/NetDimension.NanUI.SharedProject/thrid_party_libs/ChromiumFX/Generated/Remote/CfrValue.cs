// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure that wraps other data value types. Complex types (binary,
    /// dictionary and list) will be referenced but not owned by this object. Can be
    /// used on any process and thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
    /// </remarks>
    public class CfrValue : CfrBaseLibrary {

        internal static CfrValue Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrValue)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrValue(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Creates a new object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public static CfrValue Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxValueCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrValue.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrValue(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if the underlying data is valid. This will always be true
        /// (1) for simple types. For complex types (binary, dictionary and list) the
        /// underlying data may become invalid if owned by another object (e.g. list or
        /// dictionary) and that other object is then modified or destroyed. This value
        /// object can be re-used by calling Set*() even if the underlying data is
        /// invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the underlying data is owned by another object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsOwned {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueIsOwnedRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the underlying data is read-only. Some APIs may expose
        /// read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValueType Type {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxValueType)call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Bool {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetBoolRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int Int {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetIntRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public double Double {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetDoubleRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public string String {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetStringRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type binary. The returned reference may
        /// become invalid if the value is owned by another object or if ownership is
        /// transferred to another object in the future. To maintain a reference to the
        /// value after assigning ownership to a dictionary or list pass this object to
        /// the set_value() function instead of passing the returned reference to
        /// set_binary().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrBinaryValue Binary {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetBinaryRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrBinaryValue.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the underlying value as type dictionary. The returned reference may
        /// become invalid if the value is owned by another object or if ownership is
        /// transferred to another object in the future. To maintain a reference to the
        /// value after assigning ownership to a dictionary or list pass this object to
        /// the set_value() function instead of passing the returned reference to
        /// set_dictionary().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrDictionaryValue Dictionary {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetDictionaryRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDictionaryValue.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the underlying value as type list. The returned reference may
        /// become invalid if the value is owned by another object or if ownership is
        /// transferred to another object in the future. To maintain a reference to the
        /// value after assigning ownership to a dictionary or list pass this object to
        /// the set_value() function instead of passing the returned reference to
        /// set_list().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue List {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxValueGetListRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrListValue.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns true (1) if this object and |that| object have the same underlying
        /// data. If true (1) modifications to this object will also affect |that|
        /// object and vice-versa.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfrValue that) {
            var connection = RemotePtr.connection;
            var call = new CfxValueIsSameRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this object and |that| object have an equivalent
        /// underlying value but are not necessarily the same object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsEqual(CfrValue that) {
            var connection = RemotePtr.connection;
            var call = new CfxValueIsEqualRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns a copy of this object. The underlying data will also be copied.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrValue Copy() {
            var connection = RemotePtr.connection;
            var call = new CfxValueCopyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return CfrValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Sets the underlying value as type null. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetNull() {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetNullRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type bool. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBool(bool value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetBoolRemoteCall();
            call.@this = RemotePtr.ptr;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type int. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetInt(int value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetIntRemoteCall();
            call.@this = RemotePtr.ptr;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type double. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDouble(double value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetDoubleRemoteCall();
            call.@this = RemotePtr.ptr;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type string. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetString(string value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type binary. Returns true (1) if the value was
        /// set successfully. This object keeps a reference to |value| and ownership of
        /// the underlying data remains unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBinary(CfrBinaryValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetBinaryRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type dict. Returns true (1) if the value was
        /// set successfully. This object keeps a reference to |value| and ownership of
        /// the underlying data remains unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDictionary(CfrDictionaryValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetDictionaryRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type list. Returns true (1) if the value was
        /// set successfully. This object keeps a reference to |value| and ownership of
        /// the underlying data remains unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetList(CfrListValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxValueSetListRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
