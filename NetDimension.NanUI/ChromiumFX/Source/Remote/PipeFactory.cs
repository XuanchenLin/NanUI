// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.IO;

namespace Chromium.Remote {

    internal abstract class PipeFactory {

        private static PipeFactory singleton;

        internal static PipeFactory Instance {
            get {
                if(singleton == null) {
                    switch(Environment.OSVersion.Platform) {
                        case PlatformID.Win32NT:
                            singleton = new WindowsPipeFactory();
                            break;
                        default:
                            throw new CfxException("Unsupported platform: " + Environment.OSVersion.VersionString);
                    }
                }
                return singleton;
            }
        }


        internal abstract Stream CreateServerPipeInputStream(string name);
        internal abstract Stream CreateServerPipeOutputStream(string name);
        internal abstract Stream CreateClientPipeInputStream(string name);
        internal abstract Stream CreateClientPipeOutputStream(string name);

        internal abstract void WaitForConnection(Stream serverStream);
        internal abstract void Connect(Stream clientStream);

    }
}
