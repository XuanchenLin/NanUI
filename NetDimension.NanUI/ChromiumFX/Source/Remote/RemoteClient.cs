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




namespace Chromium.Remote
{

	internal class RemoteClient {

        internal static RemoteConnection connection;

        internal static int ExecuteProcess(string pipeName) {

            //System.Diagnostics.Debugger.Launch();

            var pipeIn = PipeFactory.Instance.CreateClientPipeInputStream(pipeName + "so");
            var pipeOut = PipeFactory.Instance.CreateClientPipeOutputStream(pipeName + "si");

            connection = new RemoteConnection(pipeIn, pipeOut, true);

            var call = new ExecuteRemoteProcessRemoteCall();
            call.RequestExecution(connection);
            return call.__retval;

        }
    }

    internal class ExecuteRemoteProcessRemoteCall : BrowserProcessCall {

        internal int __retval;

        internal ExecuteRemoteProcessRemoteCall() 
            : base(RemoteCallId.ExecuteRemoteProcessRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) { }
        protected override void ReadArgs(StreamHandler h) { }

        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteService.renderProcessMainCallback();
        }
    }
}
