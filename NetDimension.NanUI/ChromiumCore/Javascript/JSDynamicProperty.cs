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

using Chromium.Remote;
using Chromium.Remote.Event;
using System;
using System.Windows.Forms;

namespace NetDimension.NanUI.ChromiumCore
{

	/// <summary>
	/// Represents a dynamic javascript property in the render process 
	/// to be added to a JSObject.
	/// </summary>
	public class JSDynamicProperty : JSProperty {


        /// <summary>
        /// Called if a script attempts to get the value of
        /// this dynamic property. It's up to the
        /// application to decide how to handle the request. See also
        /// description of CfrV8AccessorGetEventArgs.
        /// If the application does not subscribe to this event, the 
        /// default action will be to return «undefined».
        /// </summary>
        public event CfrV8AccessorGetEventHandler PropertyGet;

        /// <summary>
        /// Called if a script attempts to set the value of
        /// this dynamic property. It's up to the 
        /// application to decide how to handle the request. See also
        /// description of CfrV8AccessorSetEventArgs.
        /// If the application does not subscribe to this event, the 
        /// default action will be to silently ignore the request.
        /// </summary>
        public event CfrV8AccessorSetEventHandler PropertySet;

        /// <summary>
        /// Creates a new dynamic javascript property to be added to a JSObject.
        /// </summary>
        public JSDynamicProperty()
            : base(JSPropertyType.Dynamic, JSInvokeMode.Inherit) {
        }

        /// <summary>
        /// Creates a new dynamic javascript property to be added to a JSObject.
        /// </summary>
        public JSDynamicProperty(JSInvokeMode invokeMode)
            : base(JSPropertyType.Dynamic, invokeMode) {
        }

        internal void RaisePropertySet(CfrV8AccessorSetEventArgs e) {
            var h = PropertySet;
            if(h == null) {
                //TODO: this causes the browser to crash.
                //so for the time being, we silently ignore
                //set requests when there is no application 
                //defined set event.
                //e.Exception = "Property is readonly.";
                e.SetReturnValue(true);
            } else {
                if(WillInvoke) {
                    Browser.RenderThreadInvoke((MethodInvoker)(() => h.Invoke(this, e)));
                } else {
                    h.Invoke(this, e);
                }
            }
        }

        internal void RaisePropertyGet(CfrV8AccessorGetEventArgs e) {
            var h = PropertyGet;
            if(h == null) {
                e.Retval = CfrV8Value.CreateUndefined();
                e.SetReturnValue(true);
            } else {
                if(WillInvoke) {
                    Browser.RenderThreadInvoke((MethodInvoker)(() => h.Invoke(this, e)));
                } else {
                    h.Invoke(this, e);
                }
            }
        }

        internal override CfrV8Value CreateV8Value() {
            throw new NotImplementedException();
        }
    }
}
