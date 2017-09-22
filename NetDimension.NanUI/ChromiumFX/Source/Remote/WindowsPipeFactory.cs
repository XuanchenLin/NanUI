// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.IO;
using System.IO.Pipes;

namespace Chromium.Remote {
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
