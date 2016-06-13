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
	/// <summary>
	/// Collection of global static CEF functions acessible in the render process.
	/// A thread must be in a remote context in order to access these function.
	/// </summary>
	public static partial class CfrRuntime {

        /// <summary>
        /// This function should be called from the render process startup callback
        /// provided to CfxRuntime.Initialize() in the browser process. It will
        /// call into the render process passing in the provided |application| 
        /// object and block until the render process exits. 
        /// The |application| object will receive CEF framework callbacks 
        /// from within the render process.
        /// </summary>
        public static int ExecuteProcess(CfrApp application) {
            var call = new CfxRuntimeExecuteProcessRenderProcessCall();
            call.application = CfrObject.Unwrap(application);
            // Looks like this almost never returns with a value
            // from the call into the render process. Probably the
            // IPC connection doesn't get a chance to send over the
            // return value from CfxRuntime.ExecuteProcess() when the
            // render process exits. So we don't throw an exception but
            // use a return value of -2 to indicate connection lost.
            try {
                call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                return call.__retval;
            } catch(CfxException) {
                return -2;
            }
        }
    }
}
