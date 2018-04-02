// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a dictionary value. Can be used on any process and
    /// thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
    /// </remarks>
    public class CfrDictionaryValue : CfrBaseLibrary {

        internal static CfrDictionaryValue Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrDictionaryValue)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrDictionaryValue(remotePtr);
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
        public static CfrDictionaryValue Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxDictionaryValueCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrDictionaryValue.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrDictionaryValue(RemotePtr remotePtr) : base(remotePtr) {}

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
                var call = new CfxDictionaryValueIsValidRemoteCall();
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
                var call = new CfxDictionaryValueIsOwnedRemoteCall();
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
                var call = new CfxDictionaryValueIsReadOnlyRemoteCall();
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
                var call = new CfxDictionaryValueGetSizeRemoteCall();
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
        public bool IsSame(CfrDictionaryValue that) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueIsSameRemoteCall();
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
        public bool IsEqual(CfrDictionaryValue that) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueIsEqualRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns a writable copy of this object. If |excludeNullChildren| is true
        /// (1) any NULL dictionaries or lists will be excluded from the copy.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrDictionaryValue Copy(bool excludeEmptyChildren) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueCopyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.excludeEmptyChildren = excludeEmptyChildren;
            call.RequestExecution(connection);
            return CfrDictionaryValue.Wrap(new RemotePtr(connection, call.__retval));
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
            var call = new CfxDictionaryValueClearRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if the current dictionary has a value for the given key.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool HasKey(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueHasKeyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Reads all keys for this dictionary into the specified vector.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool GetKeys(System.Collections.Generic.List<string> keys) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetKeysRemoteCall();
            call.@this = RemotePtr.ptr;
            call.keys = keys;
            call.RequestExecution(connection);
            StringFunctions.CopyCfxStringList(call.keys, keys);
            return call.__retval;
        }

        /// <summary>
        /// Removes the value at the specified key. Returns true (1) is the value was
        /// removed successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Remove(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueRemoveRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value type for the specified key.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValueType GetType(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetTypeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return (CfxValueType)call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified key. For simple types the returned value
        /// will copy existing data and modifications to the value will not modify this
        /// object. For complex types (binary, dictionary and list) the returned value
        /// will reference existing data and modifications to the value will modify
        /// this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrValue GetValue(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetValueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return CfrValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value at the specified key as type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool GetBool(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetBoolRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int GetInt(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetIntRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public double GetDouble(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetDoubleRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public string GetString(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type binary. The returned value
        /// will reference existing data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrBinaryValue GetBinary(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetBinaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return CfrBinaryValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value at the specified key as type dictionary. The returned
        /// value will reference existing data and modifications to the value will
        /// modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrDictionaryValue GetDictionary(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetDictionaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return CfrDictionaryValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value at the specified key as type list. The returned value
        /// will reference existing data and modifications to the value will modify
        /// this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue GetList(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueGetListRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return CfrListValue.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Sets the value at the specified key. Returns true (1) if the value was set
        /// successfully. If |value| represents simple data then the underlying data
        /// will be copied and modifications to |value| will not modify this object. If
        /// |value| represents complex data (binary, dictionary or list) then the
        /// underlying data will be referenced and modifications to |value| will modify
        /// this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetValue(string key, CfrValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetValueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type null. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetNull(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetNullRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type bool. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBool(string key, bool value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetBoolRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type int. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetInt(string key, int value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetIntRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type double. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDouble(string key, double value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetDoubleRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type string. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetString(string key, string value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type binary. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBinary(string key, CfrBinaryValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetBinaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type dict. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDictionary(string key, CfrDictionaryValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetDictionaryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified key as type list. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetList(string key, CfrListValue value) {
            var connection = RemotePtr.connection;
            var call = new CfxDictionaryValueSetListRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
