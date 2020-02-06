// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure that wraps other data value types. Complex types (binary,
    /// dictionary and list) will be referenced but not owned by this object. Can be
    /// used on any process and thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
    /// </remarks>
    public class CfxValue : CfxBaseLibrary {

        internal static CfxValue Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxValue)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxValue(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxValue(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Creates a new object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public static CfxValue Create() {
            return CfxValue.Wrap(CfxApi.Value.cfx_value_create());
        }

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
                return 0 != CfxApi.Value.cfx_value_is_valid(NativePtr);
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
                return 0 != CfxApi.Value.cfx_value_is_owned(NativePtr);
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
                return 0 != CfxApi.Value.cfx_value_is_read_only(NativePtr);
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
                return (CfxValueType)CfxApi.Value.cfx_value_get_type(NativePtr);
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
                return 0 != CfxApi.Value.cfx_value_get_bool(NativePtr);
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
                return CfxApi.Value.cfx_value_get_int(NativePtr);
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
                return CfxApi.Value.cfx_value_get_double(NativePtr);
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
                return StringFunctions.ConvertStringUserfree(CfxApi.Value.cfx_value_get_string(NativePtr));
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
        public CfxBinaryValue Binary {
            get {
                return CfxBinaryValue.Wrap(CfxApi.Value.cfx_value_get_binary(NativePtr));
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
        public CfxDictionaryValue Dictionary {
            get {
                return CfxDictionaryValue.Wrap(CfxApi.Value.cfx_value_get_dictionary(NativePtr));
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
        public CfxListValue List {
            get {
                return CfxListValue.Wrap(CfxApi.Value.cfx_value_get_list(NativePtr));
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
        public bool IsSame(CfxValue that) {
            return 0 != CfxApi.Value.cfx_value_is_same(NativePtr, CfxValue.Unwrap(that));
        }

        /// <summary>
        /// Returns true (1) if this object and |that| object have an equivalent
        /// underlying value but are not necessarily the same object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsEqual(CfxValue that) {
            return 0 != CfxApi.Value.cfx_value_is_equal(NativePtr, CfxValue.Unwrap(that));
        }

        /// <summary>
        /// Returns a copy of this object. The underlying data will also be copied.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValue Copy() {
            return CfxValue.Wrap(CfxApi.Value.cfx_value_copy(NativePtr));
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
            return 0 != CfxApi.Value.cfx_value_set_null(NativePtr);
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
            return 0 != CfxApi.Value.cfx_value_set_bool(NativePtr, value ? 1 : 0);
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
            return 0 != CfxApi.Value.cfx_value_set_int(NativePtr, value);
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
            return 0 != CfxApi.Value.cfx_value_set_double(NativePtr, value);
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
            var value_pinned = new PinnedString(value);
            var __retval = CfxApi.Value.cfx_value_set_string(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
            return 0 != __retval;
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
        public bool SetBinary(CfxBinaryValue value) {
            return 0 != CfxApi.Value.cfx_value_set_binary(NativePtr, CfxBinaryValue.Unwrap(value));
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
        public bool SetDictionary(CfxDictionaryValue value) {
            return 0 != CfxApi.Value.cfx_value_set_dictionary(NativePtr, CfxDictionaryValue.Unwrap(value));
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
        public bool SetList(CfxListValue value) {
            return 0 != CfxApi.Value.cfx_value_set_list(NativePtr, CfxListValue.Unwrap(value));
        }
    }
}
