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
