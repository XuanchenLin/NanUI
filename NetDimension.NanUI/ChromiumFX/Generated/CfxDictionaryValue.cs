// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Structure representing a dictionary value. Can be used on any process and
	/// thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
	/// </remarks>
	public class CfxDictionaryValue : CfxBase {

        static CfxDictionaryValue () {
            CfxApiLoader.LoadCfxDictionaryValueApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxDictionaryValue Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxDictionaryValue)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxDictionaryValue(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxDictionaryValue(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Creates a new object that is not owned by any other object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public static CfxDictionaryValue Create() {
            return CfxDictionaryValue.Wrap(CfxApi.cfx_dictionary_value_create());
        }

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
                return 0 != CfxApi.cfx_dictionary_value_is_valid(NativePtr);
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
                return 0 != CfxApi.cfx_dictionary_value_is_owned(NativePtr);
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
                return 0 != CfxApi.cfx_dictionary_value_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Returns the number of values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int Size {
            get {
                return CfxApi.cfx_dictionary_value_get_size(NativePtr);
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
        public bool IsSame(CfxDictionaryValue that) {
            return 0 != CfxApi.cfx_dictionary_value_is_same(NativePtr, CfxDictionaryValue.Unwrap(that));
        }

        /// <summary>
        /// Returns true (1) if this object and |that| object have an equivalent
        /// underlying value but are not necessarily the same object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsEqual(CfxDictionaryValue that) {
            return 0 != CfxApi.cfx_dictionary_value_is_equal(NativePtr, CfxDictionaryValue.Unwrap(that));
        }

        /// <summary>
        /// Returns a writable copy of this object. If |excludeNullChildren| is true
        /// (1) any NULL dictionaries or lists will be excluded from the copy.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxDictionaryValue Copy(bool excludeEmptyChildren) {
            return CfxDictionaryValue.Wrap(CfxApi.cfx_dictionary_value_copy(NativePtr, excludeEmptyChildren ? 1 : 0));
        }

        /// <summary>
        /// Removes all values. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Clear() {
            return 0 != CfxApi.cfx_dictionary_value_clear(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if the current dictionary has a value for the given key.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool HasKey(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_has_key(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Reads all keys for this dictionary into the specified vector.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool GetKeys(System.Collections.Generic.List<string> keys) {
            PinnedString[] keys_handles;
            var keys_unwrapped = StringFunctions.UnwrapCfxStringList(keys, out keys_handles);
            var __retval = CfxApi.cfx_dictionary_value_get_keys(NativePtr, keys_unwrapped);
            StringFunctions.FreePinnedStrings(keys_handles);
            StringFunctions.CfxStringListCopyToManaged(keys_unwrapped, keys);
            CfxApi.cfx_string_list_free(keys_unwrapped);
            return 0 != __retval;
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
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_remove(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the value type for the specified key.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValueType GetType(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_type(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return (CfxValueType)__retval;
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
        public CfxValue GetValue(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_value(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return CfxValue.Wrap(__retval);
        }

        /// <summary>
        /// Returns the value at the specified key as type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool GetBool(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_bool(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int GetInt(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_int(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return __retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public double GetDouble(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_double(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return __retval;
        }

        /// <summary>
        /// Returns the value at the specified key as type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public string GetString(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_string(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Returns the value at the specified key as type binary. The returned value
        /// will reference existing data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue GetBinary(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_binary(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return CfxBinaryValue.Wrap(__retval);
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
        public CfxDictionaryValue GetDictionary(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_dictionary(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return CfxDictionaryValue.Wrap(__retval);
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
        public CfxListValue GetList(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_get_list(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return CfxListValue.Wrap(__retval);
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
        public bool SetValue(string key, CfxValue value) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_value(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, CfxValue.Unwrap(value));
            key_pinned.Obj.Free();
            return 0 != __retval;
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
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_null(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return 0 != __retval;
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
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_bool(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, value ? 1 : 0);
            key_pinned.Obj.Free();
            return 0 != __retval;
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
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_int(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
            return 0 != __retval;
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
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_double(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
            return 0 != __retval;
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
            var key_pinned = new PinnedString(key);
            var value_pinned = new PinnedString(value);
            var __retval = CfxApi.cfx_dictionary_value_set_string(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            key_pinned.Obj.Free();
            value_pinned.Obj.Free();
            return 0 != __retval;
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
        public bool SetBinary(string key, CfxBinaryValue value) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_binary(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, CfxBinaryValue.Unwrap(value));
            key_pinned.Obj.Free();
            return 0 != __retval;
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
        public bool SetDictionary(string key, CfxDictionaryValue value) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_dictionary(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, CfxDictionaryValue.Unwrap(value));
            key_pinned.Obj.Free();
            return 0 != __retval;
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
        public bool SetList(string key, CfxListValue value) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.cfx_dictionary_value_set_list(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, CfxListValue.Unwrap(value));
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
