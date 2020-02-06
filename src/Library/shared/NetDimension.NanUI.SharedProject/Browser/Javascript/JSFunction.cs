// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Windows.Forms;
using Chromium.Remote;
using Chromium.Remote.Event;

namespace NetDimension.NanUI.Browser
{

    /// <summary>
    /// Represents a javascript function in the render process to be added as 
    /// a property to a browser frame's global object or to a JSObject.
    /// </summary>
    public class JSFunction : JSProperty {

        private CfrV8Handler v8Handler;
        
        /// <summary>
        /// Javascript callback event for this function.
        /// </summary>
        public event CfrV8HandlerExecuteEventHandler Execute;

        /// <summary>
        /// Creates a new javascript function to be added as a property 
        /// to a browser frame's global object or to a child object.
        /// </summary>
        public JSFunction()
            : base(JSPropertyType.Function, JSInvokeMode.Inherit) {
        }

        /// <summary>
        /// Creates a new javascript function to be added as a property 
        /// to a browser frame's global object or to a child object.
        /// </summary>
        public JSFunction(JSInvokeMode invokeMode)
            : base(JSPropertyType.Function, invokeMode) {
        }

        internal void SetV8Handler(CfrV8Handler handler) {
            handler.Execute += new CfrV8HandlerExecuteEventHandler(handler_Execute);
        }

        private void handler_Execute(object sender, CfrV8HandlerExecuteEventArgs e) {
            var eventHandler = Execute;
            if(eventHandler != null) {
                if(WillInvoke) {
                    Browser.RenderThreadInvoke((MethodInvoker)(() => { eventHandler(this, e); }));
                } else {
                    eventHandler(this, e);
                }
            }
        }

        internal override CfrV8Value CreateV8Value() {
            v8Handler = new CfrV8Handler();
            v8Handler.Execute += new CfrV8HandlerExecuteEventHandler(handler_Execute);
            return CfrV8Value.CreateFunction(Name, v8Handler);
        }
    }
}
