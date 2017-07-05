// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
namespace Chromium {
    internal struct PinnedString {

        public PinnedObject Obj;
        public int Length;

        public PinnedString(string s) {
            Obj = new PinnedObject(s);
            Length = s != null ? s.Length : 0;
        }
    }
}
