// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a V8 value handle. V8 handles can only be accessed
    /// from the thread on which they are created. Valid threads for creating a V8
    /// handle include the render process main thread (TID_RENDERER) and WebWorker
    /// threads. A task runner for posting tasks on the associated thread can be
    /// retrieved via the CfrV8Context.GetTaskRunner() function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public partial class CfrV8Value : CfrBaseLibrary {

        internal static CfrV8Value Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrV8Value)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrV8Value(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrV8Value object of type undefined.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateUndefined() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateUndefinedRemoteCall();
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type null.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateNull() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateNullRemoteCall();
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateBool(bool value) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateBoolRemoteCall();
            call.value = value;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateInt(int value) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateIntRemoteCall();
            call.value = value;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type unsigned int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateUint(uint value) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateUintRemoteCall();
            call.value = value;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateDouble(double value) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateDoubleRemoteCall();
            call.value = value;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type Date. This function should only be
        /// called from within the scope of a CfrRenderProcessHandler,
        /// CfrV8Handler or CfrV8Accessor callback, or in combination with calling
        /// enter() and exit() on a stored CfrV8Context reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateDate(CfrTime date) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateDateRemoteCall();
            if(!CfrObject.CheckConnection(date, connection)) throw new ArgumentException("Render process connection mismatch.", "date");
            call.date = CfrObject.Unwrap(date).ptr;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateString(string value) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateStringRemoteCall();
            call.value = value;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type object with optional accessor
        /// and/or interceptor. This function should only be called from within the scope
        /// of a CfrRenderProcessHandler, CfrV8Handler or CfrV8Accessor
        /// callback, or in combination with calling enter() and exit() on a stored
        /// CfrV8Context reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateObject(CfrV8Accessor accessor, CfrV8Interceptor interceptor) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateObjectRemoteCall();
            if(!CfrObject.CheckConnection(accessor, connection)) throw new ArgumentException("Render process connection mismatch.", "accessor");
            call.accessor = CfrObject.Unwrap(accessor).ptr;
            if(!CfrObject.CheckConnection(interceptor, connection)) throw new ArgumentException("Render process connection mismatch.", "interceptor");
            call.interceptor = CfrObject.Unwrap(interceptor).ptr;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type array with the specified |length|.
        /// If |length| is negative the returned array will have length 0. This function
        /// should only be called from within the scope of a
        /// CfrRenderProcessHandler, CfrV8Handler or CfrV8Accessor callback,
        /// or in combination with calling enter() and exit() on a stored CfrV8Context
        /// reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateArray(int length) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateArrayRemoteCall();
            call.length = length;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type ArrayBuffer which wraps the
        /// provided |buffer| of size |length| bytes. The ArrayBuffer is externalized,
        /// meaning that it does not own |buffer|. The caller is responsible for freeing
        /// |buffer| when requested via a call to CfrV8ArrayBufferReleaseCallback::
        /// ReleaseBuffer. This function should only be called from within the scope of a
        /// CfrRenderProcessHandler, CfrV8Handler or CfrV8Accessor callback,
        /// or in combination with calling enter() and exit() on a stored CfrV8Context
        /// reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateArrayBuffer(RemotePtr buffer, ulong length, CfrV8ArrayBufferReleaseCallback releaseCallback) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateArrayBufferRemoteCall();
            if(buffer.connection != connection) throw new ArgumentException("Render process connection mismatch.", "buffer");
            call.buffer = buffer.ptr;
            call.length = length;
            if(!CfrObject.CheckConnection(releaseCallback, connection)) throw new ArgumentException("Render process connection mismatch.", "releaseCallback");
            call.releaseCallback = CfrObject.Unwrap(releaseCallback).ptr;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrV8Value object of type function. This function should only
        /// be called from within the scope of a CfrRenderProcessHandler,
        /// CfrV8Handler or CfrV8Accessor callback, or in combination with calling
        /// enter() and exit() on a stored CfrV8Context reference.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Value CreateFunction(string name, CfrV8Handler handler) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ValueCreateFunctionRemoteCall();
            call.name = name;
            if(!CfrObject.CheckConnection(handler, connection)) throw new ArgumentException("Render process connection mismatch.", "handler");
            call.handler = CfrObject.Unwrap(handler).ptr;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrV8Value(RemotePtr remotePtr) : base(remotePtr) {}

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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsUndefinedRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsNullRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsBoolRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsIntRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsUintRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsDoubleRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsDateRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsStringRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsObjectRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsArrayRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsArrayBufferRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsFunctionRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetBoolValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetIntValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetUintValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetDoubleValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Return a Date value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrTime DateValue {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetDateValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                if(call.__retval == IntPtr.Zero) throw new OutOfMemoryException("Render process out of memory.");
                return CfrTime.Wrap(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetStringValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueIsUserCreatedRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueHasExceptionRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
        public CfrV8Exception Exception {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetExceptionRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrV8Exception.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the user data, if any, assigned to this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrBaseRefCounted UserData {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetUserDataRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrBaseRefCounted.Cast(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetExternallyAllocatedMemoryRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetArrayLengthRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
        public CfrV8ArrayBufferReleaseCallback ArrayBufferReleaseCallback {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetArrayBufferReleaseCallbackRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrV8ArrayBufferReleaseCallback.Wrap(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetFunctionNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the function handler or NULL if not a CEF-created function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrV8Handler FunctionHandler {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ValueGetFunctionHandlerRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrV8Handler.Wrap(new RemotePtr(connection, call.__retval));
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
        public bool IsSame(CfrV8Value that) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueIsSameRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Clears the last exception and returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool ClearException() {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueClearExceptionRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueWillRethrowExceptionsRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueSetRethrowExceptionsRemoteCall();
            call.@this = RemotePtr.ptr;
            call.rethrow = rethrow;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if the object has a value with the specified identifier.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool HasValue(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueHasValueByKeyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if the object has a value with the specified identifier.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool HasValue(int index) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueHasValueByIndexRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueDeleteValueByKeyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueDeleteValueByIndexRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value with the specified identifier on success. Returns NULL if
        /// this function is called incorrectly or an exception is thrown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrV8Value GetValue(string key) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueGetValueByKeyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the value with the specified identifier on success. Returns NULL if
        /// this function is called incorrectly or an exception is thrown.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrV8Value GetValue(int index) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueGetValueByIndexRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
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
        public bool SetValue(string key, CfrV8Value value, CfxV8PropertyAttribute attribute) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueSetValueByKeyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.attribute = (int)attribute;
            call.RequestExecution(connection);
            return call.__retval;
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
        public bool SetValue(int index, CfrV8Value value) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueSetValueByIndexRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
            call.value = CfrObject.Unwrap(value).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Registers an identifier and returns true (1) on success. Access to the
        /// identifier will be forwarded to the CfrV8Accessor instance passed to
        /// CfrV8Value.CfrV8ValueCreateObject(). Returns false (0) if this
        /// function is called incorrectly or an exception is thrown. For read-only
        /// values this function will return true (1) even though assignment failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool SetValue(string key, CfxV8AccessControl settings, CfxV8PropertyAttribute attribute) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueSetValueByAccessorRemoteCall();
            call.@this = RemotePtr.ptr;
            call.key = key;
            call.settings = (int)settings;
            call.attribute = (int)attribute;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueGetKeysRemoteCall();
            call.@this = RemotePtr.ptr;
            call.keys = keys;
            call.RequestExecution(connection);
            StringFunctions.CopyCfxStringList(call.keys, keys);
            return call.__retval;
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
        public bool SetUserData(CfrBaseRefCounted userData) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueSetUserDataRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(userData, connection)) throw new ArgumentException("Render process connection mismatch.", "userData");
            call.userData = CfrBaseRefCounted.Unwrap(userData).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Adjusts the amount of registered external memory for the object. Used to
        /// give V8 an indication of the amount of externally allocated memory that is
        /// kept alive by JavaScript objects. V8 uses this information to decide when
        /// to perform global garbage collection. Each CfrV8Value tracks the amount
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
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueAdjustExternallyAllocatedMemoryRemoteCall();
            call.@this = RemotePtr.ptr;
            call.changeInBytes = changeInBytes;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Prevent the ArrayBuffer from using it's memory block by setting the length
        /// to zero. This operation cannot be undone. If the ArrayBuffer was created
        /// with CreateArrayBuffer then
        /// CfrV8ArrayBufferReleaseCallback.ReleaseBuffer will be called to
        /// release the underlying buffer.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool NeuterArrayBuffer() {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueNeuterArrayBufferRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Execute the function using the current V8 context. This function should
        /// only be called from within the scope of a CfrV8Handler or
        /// CfrV8Accessor callback, or in combination with calling enter() and
        /// exit() on a stored CfrV8Context reference. |object| is the receiver
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
        public CfrV8Value ExecuteFunction(CfrV8Value @object, CfrV8Value[] arguments) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueExecuteFunctionRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(@object, connection)) throw new ArgumentException("Render process connection mismatch.", "object");
            call.@object = CfrObject.Unwrap(@object).ptr;
            if(arguments != null) {
                call.arguments = new IntPtr[arguments.Length];
                for(int i = 0; i < arguments.Length; ++i) {
                    if(!CheckConnection(arguments[i], connection)) throw new ArgumentException("Render process connection mismatch.", "arguments[" + i + "]");
                    call.arguments[i] = CfrObject.Unwrap(arguments[i]).ptr;
                }
            }
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
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
        public CfrV8Value ExecuteFunctionWithContext(CfrV8Context context, CfrV8Value @object, CfrV8Value[] arguments) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ValueExecuteFunctionWithContextRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(context, connection)) throw new ArgumentException("Render process connection mismatch.", "context");
            call.context = CfrObject.Unwrap(context).ptr;
            if(!CfrObject.CheckConnection(@object, connection)) throw new ArgumentException("Render process connection mismatch.", "object");
            call.@object = CfrObject.Unwrap(@object).ptr;
            if(arguments != null) {
                call.arguments = new IntPtr[arguments.Length];
                for(int i = 0; i < arguments.Length; ++i) {
                    if(!CheckConnection(arguments[i], connection)) throw new ArgumentException("Render process connection mismatch.", "arguments[" + i + "]");
                    call.arguments[i] = CfrObject.Unwrap(arguments[i]).ptr;
                }
            }
            call.RequestExecution(connection);
            return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
        }
    }
}
