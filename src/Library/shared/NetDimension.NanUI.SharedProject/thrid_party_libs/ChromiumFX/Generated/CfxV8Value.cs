// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a V8 value handle. V8 handles can only be accessed
    /// from the thread on which they are created. Valid threads for creating a V8
    /// handle include the render process main thread (TID_RENDERER) and WebWorker
    /// threads. A task runner for posting tasks on the associated thread can be
    /// retrieved via the CfxV8Context.GetTaskRunner() function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public partial class CfxV8Value : CfxBaseLibrary {

        internal static CfxV8Value Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxV8Value)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxV8Value(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxV8Value(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxV8Value object of type undefined.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateUndefined() {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_undefined());
        }

        /// <summary>
        /// Create a new CfxV8Value object of type null.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateNull() {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_null());
        }

        /// <summary>
        /// Create a new CfxV8Value object of type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateBool(bool value) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_bool(value ? 1 : 0));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateInt(int value) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_int(value));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type unsigned int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateUint(uint value) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_uint(value));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateDouble(double value) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_double(value));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type Date. This function should only be
        /// called from within the scope of a CfxRenderProcessHandler,
        /// CfxV8Handler or CfxV8Accessor callback, or in combination with calling
        /// enter() and exit() on a stored CfxV8Context reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateDate(CfxTime date) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_date(CfxTime.Unwrap(date)));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateString(string value) {
            var value_pinned = new PinnedString(value);
            var __retval = CfxApi.V8Value.cfx_v8value_create_string(value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
            return CfxV8Value.Wrap(__retval);
        }

        /// <summary>
        /// Create a new CfxV8Value object of type object with optional accessor
        /// and/or interceptor. This function should only be called from within the scope
        /// of a CfxRenderProcessHandler, CfxV8Handler or CfxV8Accessor
        /// callback, or in combination with calling enter() and exit() on a stored
        /// CfxV8Context reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateObject(CfxV8Accessor accessor, CfxV8Interceptor interceptor) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_object(CfxV8Accessor.Unwrap(accessor), CfxV8Interceptor.Unwrap(interceptor)));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type array with the specified |length|.
        /// If |length| is negative the returned array will have length 0. This function
        /// should only be called from within the scope of a
        /// CfxRenderProcessHandler, CfxV8Handler or CfxV8Accessor callback,
        /// or in combination with calling enter() and exit() on a stored CfxV8Context
        /// reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateArray(int length) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_array(length));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type ArrayBuffer which wraps the
        /// provided |buffer| of size |length| bytes. The ArrayBuffer is externalized,
        /// meaning that it does not own |buffer|. The caller is responsible for freeing
        /// |buffer| when requested via a call to CfxV8ArrayBufferReleaseCallback::
        /// ReleaseBuffer. This function should only be called from within the scope of a
        /// CfxRenderProcessHandler, CfxV8Handler or CfxV8Accessor callback,
        /// or in combination with calling enter() and exit() on a stored CfxV8Context
        /// reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateArrayBuffer(IntPtr buffer, ulong length, CfxV8ArrayBufferReleaseCallback releaseCallback) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_create_array_buffer(buffer, (UIntPtr)length, CfxV8ArrayBufferReleaseCallback.Unwrap(releaseCallback)));
        }

        /// <summary>
        /// Create a new CfxV8Value object of type function. This function should only
        /// be called from within the scope of a CfxRenderProcessHandler,
        /// CfxV8Handler or CfxV8Accessor callback, or in combination with calling
        /// enter() and exit() on a stored CfxV8Context reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfxV8Value CreateFunction(string name, CfxV8Handler handler) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.V8Value.cfx_v8value_create_function(name_pinned.Obj.PinnedPtr, name_pinned.Length, CfxV8Handler.Unwrap(handler));
            name_pinned.Obj.Free();
            return CfxV8Value.Wrap(__retval);
        }

        /// <summary>
        /// Returns true (1) if the underlying handle is valid and it can be accessed
        /// on the current thread. Do not call any other functions if this function
        /// returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is undefined.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsUndefined {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_undefined(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is null.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsNull {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_null(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsBool {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_bool(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsInt {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_int(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is unsigned int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsUint {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_uint(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsDouble {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_double(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is Date.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsDate {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_date(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsString {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_string(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsObject {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_object(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is array.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsArray {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_array(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is an ArrayBuffer.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsArrayBuffer {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_array_buffer(NativePtr);
            }
        }

        /// <summary>
        /// True if the value type is function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsFunction {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_function(NativePtr);
            }
        }

        /// <summary>
        /// Return a bool value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool BoolValue {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_get_bool_value(NativePtr);
            }
        }

        /// <summary>
        /// Return an int value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int IntValue {
            get {
                return CfxApi.V8Value.cfx_v8value_get_int_value(NativePtr);
            }
        }

        /// <summary>
        /// Return an unsigned int value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public uint UintValue {
            get {
                return CfxApi.V8Value.cfx_v8value_get_uint_value(NativePtr);
            }
        }

        /// <summary>
        /// Return a double value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public double DoubleValue {
            get {
                return CfxApi.V8Value.cfx_v8value_get_double_value(NativePtr);
            }
        }

        /// <summary>
        /// Return a Date value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxTime DateValue {
            get {
                var __retval = CfxApi.V8Value.cfx_v8value_get_date_value(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxTime.WrapOwned(__retval);
            }
        }

        /// <summary>
        /// Return a string value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string StringValue {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8Value.cfx_v8value_get_string_value(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this is a user created object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsUserCreated {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_is_user_created(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the last function call resulted in an exception. This
        /// attribute exists only in the scope of the current CEF value object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool HasException {
            get {
                return 0 != CfxApi.V8Value.cfx_v8value_has_exception(NativePtr);
            }
        }

        /// <summary>
        /// Returns the exception resulting from the last function call. This attribute
        /// exists only in the scope of the current CEF value object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Exception Exception {
            get {
                return CfxV8Exception.Wrap(CfxApi.V8Value.cfx_v8value_get_exception(NativePtr));
            }
        }

        /// <summary>
        /// Returns the user data, if any, assigned to this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxBaseRefCounted UserData {
            get {
                return CfxBaseRefCounted.Cast(CfxApi.V8Value.cfx_v8value_get_user_data(NativePtr));
            }
        }

        /// <summary>
        /// Returns the amount of externally allocated memory registered for the
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int ExternallyAllocatedMemory {
            get {
                return CfxApi.V8Value.cfx_v8value_get_externally_allocated_memory(NativePtr);
            }
        }

        /// <summary>
        /// Returns the number of elements in the array.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int ArrayLength {
            get {
                return CfxApi.V8Value.cfx_v8value_get_array_length(NativePtr);
            }
        }

        /// <summary>
        /// Returns the ReleaseCallback object associated with the ArrayBuffer or NULL
        /// if the ArrayBuffer was not created with CreateArrayBuffer.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8ArrayBufferReleaseCallback ArrayBufferReleaseCallback {
            get {
                return CfxV8ArrayBufferReleaseCallback.Wrap(CfxApi.V8Value.cfx_v8value_get_array_buffer_release_callback(NativePtr));
            }
        }

        /// <summary>
        /// Returns the function name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public string FunctionName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.V8Value.cfx_v8value_get_function_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the function handler or NULL if not a CEF-created function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Handler FunctionHandler {
            get {
                return CfxV8Handler.Wrap(CfxApi.V8Value.cfx_v8value_get_function_handler(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxV8Value that) {
            return 0 != CfxApi.V8Value.cfx_v8value_is_same(NativePtr, CfxV8Value.Unwrap(that));
        }

        /// <summary>
        /// Clears the last exception and returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool ClearException() {
            return 0 != CfxApi.V8Value.cfx_v8value_clear_exception(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if this object will re-throw future exceptions. This
        /// attribute exists only in the scope of the current CEF value object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool WillRethrowExceptions() {
            return 0 != CfxApi.V8Value.cfx_v8value_will_rethrow_exceptions(NativePtr);
        }

        /// <summary>
        /// Set whether this object will re-throw future exceptions. By default
        /// exceptions are not re-thrown. If a exception is re-thrown the current
        /// context should not be accessed again until after the exception has been
        /// caught and not re-thrown. Returns true (1) on success. This attribute
        /// exists only in the scope of the current CEF value object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool SetRethrowExceptions(bool rethrow) {
            return 0 != CfxApi.V8Value.cfx_v8value_set_rethrow_exceptions(NativePtr, rethrow ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if the object has a value with the specified identifier.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool HasValue(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.V8Value.cfx_v8value_has_value_bykey(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns true (1) if the object has a value with the specified identifier.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool HasValue(int index) {
            return 0 != CfxApi.V8Value.cfx_v8value_has_value_byindex(NativePtr, index);
        }

        /// <summary>
        /// Deletes the value with the specified identifier and returns true (1) on
        /// success. Returns false (0) if this function is called incorrectly or an
        /// exception is thrown. For read-only and don't-delete values this function
        /// will return true (1) even though deletion failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool DeleteValue(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.V8Value.cfx_v8value_delete_value_bykey(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Deletes the value with the specified identifier and returns true (1) on
        /// success. Returns false (0) if this function is called incorrectly, deletion
        /// fails or an exception is thrown. For read-only and don't-delete values this
        /// function will return true (1) even though deletion failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool DeleteValue(int index) {
            return 0 != CfxApi.V8Value.cfx_v8value_delete_value_byindex(NativePtr, index);
        }

        /// <summary>
        /// Returns the value with the specified identifier on success. Returns NULL if
        /// this function is called incorrectly or an exception is thrown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Value GetValue(string key) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.V8Value.cfx_v8value_get_value_bykey(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
            return CfxV8Value.Wrap(__retval);
        }

        /// <summary>
        /// Returns the value with the specified identifier on success. Returns NULL if
        /// this function is called incorrectly or an exception is thrown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Value GetValue(int index) {
            return CfxV8Value.Wrap(CfxApi.V8Value.cfx_v8value_get_value_byindex(NativePtr, index));
        }

        /// <summary>
        /// Associates a value with the specified identifier and returns true (1) on
        /// success. Returns false (0) if this function is called incorrectly or an
        /// exception is thrown. For read-only values this function will return true
        /// (1) even though assignment failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool SetValue(string key, CfxV8Value value, CfxV8PropertyAttribute attribute) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.V8Value.cfx_v8value_set_value_bykey(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, CfxV8Value.Unwrap(value), (int)attribute);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Associates a value with the specified identifier and returns true (1) on
        /// success. Returns false (0) if this function is called incorrectly or an
        /// exception is thrown. For read-only values this function will return true
        /// (1) even though assignment failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool SetValue(int index, CfxV8Value value) {
            return 0 != CfxApi.V8Value.cfx_v8value_set_value_byindex(NativePtr, index, CfxV8Value.Unwrap(value));
        }

        /// <summary>
        /// Registers an identifier and returns true (1) on success. Access to the
        /// identifier will be forwarded to the CfxV8Accessor instance passed to
        /// CfxV8Value.CfxV8ValueCreateObject(). Returns false (0) if this
        /// function is called incorrectly or an exception is thrown. For read-only
        /// values this function will return true (1) even though assignment failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool SetValue(string key, CfxV8AccessControl settings, CfxV8PropertyAttribute attribute) {
            var key_pinned = new PinnedString(key);
            var __retval = CfxApi.V8Value.cfx_v8value_set_value_byaccessor(NativePtr, key_pinned.Obj.PinnedPtr, key_pinned.Length, (int)settings, (int)attribute);
            key_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Read the keys for the object's values into the specified vector. Integer-
        /// based keys will also be returned as strings.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool GetKeys(System.Collections.Generic.List<string> keys) {
            PinnedString[] keys_handles;
            var keys_unwrapped = StringFunctions.UnwrapCfxStringList(keys, out keys_handles);
            var __retval = CfxApi.V8Value.cfx_v8value_get_keys(NativePtr, keys_unwrapped);
            StringFunctions.FreePinnedStrings(keys_handles);
            StringFunctions.CfxStringListCopyToManaged(keys_unwrapped, keys);
            CfxApi.Runtime.cfx_string_list_free(keys_unwrapped);
            return 0 != __retval;
        }

        /// <summary>
        /// Sets the user data for this object and returns true (1) on success. Returns
        /// false (0) if this function is called incorrectly. This function can only be
        /// called on user created objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool SetUserData(CfxBaseRefCounted userData) {
            return 0 != CfxApi.V8Value.cfx_v8value_set_user_data(NativePtr, CfxBaseRefCounted.Unwrap(userData));
        }

        /// <summary>
        /// Adjusts the amount of registered external memory for the object. Used to
        /// give V8 an indication of the amount of externally allocated memory that is
        /// kept alive by JavaScript objects. V8 uses this information to decide when
        /// to perform global garbage collection. Each CfxV8Value tracks the amount
        /// of external memory associated with it and automatically decreases the
        /// global total by the appropriate amount on its destruction.
        /// |changeInBytes| specifies the number of bytes to adjust by. This function
        /// returns the number of bytes associated with the object after the
        /// adjustment. This function can only be called on user created objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int AdjustExternallyAllocatedMemory(int changeInBytes) {
            return CfxApi.V8Value.cfx_v8value_adjust_externally_allocated_memory(NativePtr, changeInBytes);
        }

        /// <summary>
        /// Prevent the ArrayBuffer from using it's memory block by setting the length
        /// to zero. This operation cannot be undone. If the ArrayBuffer was created
        /// with CreateArrayBuffer then
        /// CfxV8ArrayBufferReleaseCallback.ReleaseBuffer will be called to
        /// release the underlying buffer.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool NeuterArrayBuffer() {
            return 0 != CfxApi.V8Value.cfx_v8value_neuter_array_buffer(NativePtr);
        }

        /// <summary>
        /// Execute the function using the current V8 context. This function should
        /// only be called from within the scope of a CfxV8Handler or
        /// CfxV8Accessor callback, or in combination with calling enter() and
        /// exit() on a stored CfxV8Context reference. |object| is the receiver
        /// ('this' object) of the function. If |object| is NULL the current context's
        /// global object will be used. |arguments| is the list of arguments that will
        /// be passed to the function. Returns the function return value on success.
        /// Returns NULL if this function is called incorrectly or an exception is
        /// thrown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Value ExecuteFunction(CfxV8Value @object, CfxV8Value[] arguments) {
            UIntPtr arguments_length;
            IntPtr[] arguments_ptrs;
            if(arguments != null) {
                arguments_length = (UIntPtr)arguments.Length;
                arguments_ptrs = new IntPtr[arguments.Length];
                for(int i = 0; i < arguments.Length; ++i) {
                    arguments_ptrs[i] = CfxV8Value.Unwrap(arguments[i]);
                }
            } else {
                arguments_length = UIntPtr.Zero;
                arguments_ptrs = null;
            }
            PinnedObject arguments_pinned = new PinnedObject(arguments_ptrs);
            var __retval = CfxApi.V8Value.cfx_v8value_execute_function(NativePtr, CfxV8Value.Unwrap(@object), arguments_length, arguments_pinned.PinnedPtr);
            arguments_pinned.Free();
            return CfxV8Value.Wrap(__retval);
        }

        /// <summary>
        /// Execute the function using the specified V8 context. |object| is the
        /// receiver ('this' object) of the function. If |object| is NULL the specified
        /// context's global object will be used. |arguments| is the list of arguments
        /// that will be passed to the function. Returns the function return value on
        /// success. Returns NULL if this function is called incorrectly or an
        /// exception is thrown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfxV8Value ExecuteFunctionWithContext(CfxV8Context context, CfxV8Value @object, CfxV8Value[] arguments) {
            UIntPtr arguments_length;
            IntPtr[] arguments_ptrs;
            if(arguments != null) {
                arguments_length = (UIntPtr)arguments.Length;
                arguments_ptrs = new IntPtr[arguments.Length];
                for(int i = 0; i < arguments.Length; ++i) {
                    arguments_ptrs[i] = CfxV8Value.Unwrap(arguments[i]);
                }
            } else {
                arguments_length = UIntPtr.Zero;
                arguments_ptrs = null;
            }
            PinnedObject arguments_pinned = new PinnedObject(arguments_ptrs);
            var __retval = CfxApi.V8Value.cfx_v8value_execute_function_with_context(NativePtr, CfxV8Context.Unwrap(context), CfxV8Value.Unwrap(@object), arguments_length, arguments_pinned.PinnedPtr);
            arguments_pinned.Free();
            return CfxV8Value.Wrap(__retval);
        }
    }
}
