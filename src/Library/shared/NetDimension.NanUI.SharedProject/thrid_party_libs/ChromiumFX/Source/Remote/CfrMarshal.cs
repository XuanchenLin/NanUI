// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Runtime.InteropServices;


namespace Chromium.Remote {

    public partial class CfrRuntime {

        /// <summary>
        /// Provides access to the remote process unmanaged memory.
        /// </summary>
        public static class Marshal {

            /// <summary>
            /// Call Marshal.AllocHGlobal in the target process.
            /// A thread must be in a remote context in order to access this function.
            /// </summary>
            public static RemotePtr AllocHGlobal(int cb) {
                var call = new CfrMarshalAllocHGlobalRemoteCall();
                call.cb = cb;
                call.RequestExecution();
                return new RemotePtr(CfxRemoteCallContext.CurrentContext.connection, call.__retval);
            }

            /// <summary>
            /// Call Marshal.FreeHGlobal in the target process.
            /// </summary>
            public static void FreeHGlobal(RemotePtr hglobal) {
                var call = new CfrMarshalFreeHGlobalRemoteCall();
                call.hglobal = hglobal.ptr;
                call.RequestExecution(hglobal.connection);
            }

            /// <summary>
            /// Call Marshal.Copy in the target process.
            /// </summary>
            public static void Copy(byte[] source, int startIndex, RemotePtr destination, int length) {
                var call = new CfrMarshalCopyToNativeRemoteCall();
                call.source = source;
                call.startIndex = startIndex;
                call.destination = destination.ptr;
                call.length = length;
                call.RequestExecution(destination.connection);
            }

            /// <summary>
            /// Call Marshal.Copy in the target process.
            /// </summary>
            public static void Copy(RemotePtr source, byte[] destination, int startIndex, int length) {
                var call = new CfrMarshalCopyToManagedRemoteCall();
                call.source = source.ptr;
                call.startIndex = startIndex;
                call.length = length;
                call.RequestExecution(source.connection);
                Array.Copy(call.destination, startIndex, destination, startIndex, length);
            }

            /// <summary>
            /// Call Marshal.Copy in the target process.
            /// </summary>
            public static void Copy(RemotePtr source, RemotePtr[] destination, int startIndex, int length) {
                var call = new CfrMarshalCopyToManagedIntPtrArrayRemoteCall();
                call.source = source.ptr;
                call.startIndex = startIndex;
                call.length = length;
                call.RequestExecution(source.connection);
                for(int i = 0; i < length; ++i) {
                    destination[startIndex + i] = new RemotePtr(source.connection, call.destination[startIndex + i]);
                }
            }

            /// <summary>
            /// Call Marshal.PtrToStringUni in the target process.
            /// </summary>
            public static string PtrToStringUni(RemotePtr str, int length) {
                var call = new CfrMarshalPtrToStringUniRemoteCall();
                call.str = str.ptr;
                call.length = length;
                call.RequestExecution(str.connection);
                return call.__retval;
            }
        }
    }
    
    internal class CfrMarshalAllocHGlobalRemoteCall : RemoteCall {

        internal int cb;
        internal IntPtr __retval;

        internal CfrMarshalAllocHGlobalRemoteCall() : base(RemoteCallId.CfrMarshalAllocHGlobalRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(cb);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out cb);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = Marshal.AllocHGlobal(cb);
        }
    }


    internal class CfrMarshalFreeHGlobalRemoteCall : RemoteCall {

        internal IntPtr hglobal;

        internal CfrMarshalFreeHGlobalRemoteCall() : base(RemoteCallId.CfrMarshalFreeHGlobalRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(hglobal);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out hglobal);
        }

        protected override void RemoteProcedure() {
            Marshal.FreeHGlobal(hglobal);
        }
    }


    internal class CfrMarshalCopyToNativeRemoteCall : RemoteCall {

        internal byte[] source;
        internal int startIndex;
        internal IntPtr destination;
        internal int length;

        internal CfrMarshalCopyToNativeRemoteCall() : base(RemoteCallId.CfrMarshalCopyToNativeRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(source);
            h.Write(startIndex);
            h.Write(destination);
            h.Write(length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out source);
            h.Read(out startIndex);
            h.Read(out destination);
            h.Read(out length);
        }

        protected override void RemoteProcedure() {
            Marshal.Copy(source, startIndex, destination, length);
        }
    }

    internal class CfrMarshalCopyToManagedRemoteCall : RemoteCall {

        internal IntPtr source;
        internal byte[] destination;
        internal int startIndex;
        internal int length;

        internal CfrMarshalCopyToManagedRemoteCall() : base(RemoteCallId.CfrMarshalCopyToManagedRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(source);
            h.Write(startIndex);
            h.Write(length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out source);
            h.Read(out startIndex);
            h.Read(out length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(destination);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out destination);
        }

        protected override void RemoteProcedure() {
            destination = new byte[startIndex + length];
            Marshal.Copy(source, destination, startIndex, length);
        }
    }

    internal class CfrMarshalCopyToManagedIntPtrArrayRemoteCall : RemoteCall {

        internal IntPtr source;
        internal IntPtr[] destination;
        internal int startIndex;
        internal int length;

        internal CfrMarshalCopyToManagedIntPtrArrayRemoteCall() : base(RemoteCallId.CfrMarshalCopyToManagedIntPtrArrayRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(source);
            h.Write(startIndex);
            h.Write(length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out source);
            h.Read(out startIndex);
            h.Read(out length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(destination);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out destination);
        }

        protected override void RemoteProcedure() {
            destination = new IntPtr[startIndex + length];
            Marshal.Copy(source, destination, startIndex, length);
        }
    }

    internal class CfrMarshalPtrToStringUniRemoteCall : RemoteCall {

        internal IntPtr str;
        internal int length;
        internal string __retval;

        internal CfrMarshalPtrToStringUniRemoteCall() : base(RemoteCallId.CfrMarshalPtrToStringUniRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(str);
            h.Write(length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out str);
            h.Read(out length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = Marshal.PtrToStringUni(str, length);
        }
    }

}

