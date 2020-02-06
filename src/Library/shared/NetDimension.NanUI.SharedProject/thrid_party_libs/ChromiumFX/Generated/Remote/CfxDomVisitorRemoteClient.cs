// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxDomVisitorRemoteClient {

        static CfxDomVisitorRemoteClient() {
            visit_native = visit;
            visit_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(visit_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.DomVisitor.cfx_domvisitor_set_callback(self, index, active ? visit_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void visit_delegate(IntPtr gcHandlePtr, IntPtr document, out int document_release);
        private static visit_delegate visit_native;
        private static IntPtr visit_native_ptr;

        internal static void visit(IntPtr gcHandlePtr, IntPtr document, out int document_release) {
            var call = new CfxDomVisitorVisitRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.document = document;
            call.RequestExecution();
            document_release = call.document_release;
        }

    }
}
