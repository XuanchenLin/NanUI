// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
namespace Chromium.Remote
{
    /// <summary>
    /// Base class for all remote callback event args.
    /// </summary>
    public class CfrEventArgs : EventArgs {
        
        internal bool m_isInvalid = false;
        internal void CheckAccess() {
            if(m_isInvalid)
                throw new CfxException("Do not keep/use a reference to callback event arguments outside the scope of the event handler.");
        }
    }

    public delegate void CfrEventHandler(object sender, CfrEventArgs e);

}
