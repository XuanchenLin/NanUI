// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a list value. Can be used on any process and thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
    /// </remarks>
    public class CfrListValue : CfrBaseLibrary {

        internal static CfrListValue Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrListValue)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrListValue(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Creates a new object that is not owned by any other object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public static CfrListValue Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxListValueCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrListValue.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrListValue(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if this object is valid. This object may become invalid if
        /// the underlying data is owned by another object (e.g. list or dictionary)
        /// and that other object is then modified or destroyed. Do not call any other
        /// functions if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxListValueIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if this object is currently owned by another object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsOwned {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxListValueIsOwnedRemoteCall();
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
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxListValueIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the number of values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public ulong Size {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxListValueGetSizeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
        public bool IsSame(CfrListValue that) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueIsSameRemoteCall();
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
        public bool IsEqual(CfrListValue that) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueIsEqualRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue Copy() {
            var connection = RemotePtr.connection;
            var call = new CfxListValueCopyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return CfrListValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Sets the number of values. If the number of values is expanded all new
        /// value slots will default to type null. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetSize(ulong size) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetSizeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.size = size;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Removes all values. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Clear() {
            var connection = RemotePtr.connection;
            var call = new CfxListValueClearRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Removes the value at the specified index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Remove(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueRemoveRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value type at the specified index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValueType GetType(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetTypeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return (CfxValueType)call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index. For simple types the returned
        /// value will copy existing data and modifications to the value will not
        /// modify this object. For complex types (binary, dictionary and list) the
        /// returned value will reference existing data and modifications to the value
        /// will modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrValue GetValue(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetValueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return CfrValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value at the specified index as type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool GetBool(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetBoolRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int GetInt(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetIntRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public double GetDouble(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetDoubleRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public string GetString(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type binary. The returned value
        /// will reference existing data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrBinaryValue GetBinary(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetBinaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return CfrBinaryValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value at the specified index as type dictionary. The returned
        /// value will reference existing data and modifications to the value will
        /// modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrDictionaryValue GetDictionary(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetDictionaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return CfrDictionaryValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value at the specified index as type list. The returned value
        /// will reference existing data and modifications to the value will modify
        /// this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue GetList(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueGetListRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return CfrListValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Sets the value at the specified index. Returns true (1) if the value was
        /// set successfully. If |value| represents simple data then the underlying
        /// data will be copied and modifications to |value| will not modify this
        /// object. If |value| represents complex data (binary, dictionary or list)
        /// then the underlying data will be referenced and modifications to |value|
        /// will modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetValue(ulong index, CfrValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetValueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type null. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetNull(ulong index) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetNullRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type bool. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBool(ulong index, bool value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetBoolRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type int. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetInt(ulong index, int value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetIntRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type double. Returns true (1) if
        /// the value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDouble(ulong index, double value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetDoubleRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type string. Returns true (1) if
        /// the value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetString(ulong index, string value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type binary. Returns true (1) if
        /// the value was set successfully. If |value| is currently owned by another
        /// object then the value will be copied and the |value| reference will not
        /// change. Otherwise, ownership will be transferred to this object and the
        /// |value| reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBinary(ulong index, CfrBinaryValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetBinaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type dict. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDictionary(ulong index, CfrDictionaryValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetDictionaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type list. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetList(ulong index, CfrListValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxListValueSetListRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
