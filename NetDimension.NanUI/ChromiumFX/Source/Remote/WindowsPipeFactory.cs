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


using System.IO.Pipes;

namespace Chromium.Remote
{
	class WindowsPipeFactory : PipeFactory {

        internal override System.IO.Stream CreateServerPipeInputStream(string name) {
            var s = new NamedPipeServerStream(name, PipeDirection.In, 1);
            return new PipeBufferStream(s);
        }

        internal override System.IO.Stream CreateServerPipeOutputStream(string name) {
            var s = new NamedPipeServerStream(name, PipeDirection.Out, 1);
            return new PipeBufferStream(s);
        }

        internal override System.IO.Stream CreateClientPipeInputStream(string name) {
            var s = new NamedPipeClientStream(".", name, PipeDirection.In);
            return new PipeBufferStream(s);
        }

        internal override System.IO.Stream CreateClientPipeOutputStream(string name) {
            var s = new NamedPipeClientStream(".", name, PipeDirection.Out);
            return new PipeBufferStream(s);
        }

        internal override void WaitForConnection(System.IO.Stream serverStream) {
            if(serverStream is PipeBufferStream)
                ((NamedPipeServerStream)((PipeBufferStream)serverStream).pipe).WaitForConnection();
            else
                ((NamedPipeServerStream)serverStream).WaitForConnection();
        }

        internal override void Connect(System.IO.Stream clientStream) {
            if(clientStream is PipeBufferStream)
                ((NamedPipeClientStream)((PipeBufferStream)clientStream).pipe).Connect();
            else
                ((NamedPipeClientStream)clientStream).Connect();
        }
    }
}
