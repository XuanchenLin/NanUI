// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using Chromium.Remote;

namespace NetDimension.NanUI.Browser
{

    /// <summary>
    /// The type of a javascript property.
    /// </summary>
    public enum JSPropertyType {
        Dynamic,
        Function,
        Object
    }


    /// <summary>
    /// Represents a javascript property in the render process to be added to 
    /// a browser frame's global object or to a child object.
    /// </summary>
    public abstract class JSProperty {

        /// <summary>
        /// The type of this property.
        /// </summary>
        public JSPropertyType PropertyType { get; private set; }

        /// <summary>
        /// The invoke mode for this property. See also JSInvokeMode.
        /// Changes to the invoke mode will be effective after the next
        /// time the browser creates a V8 context for the target frame.
        /// </summary>
        public JSInvokeMode InvokeMode { get; set; }

        /// <summary>
        /// Indicates whether render process callbacks on this javascript
        /// property will be executed on the thread that owns the 
        /// browser's underlying window handle.
        /// Depends on the invoke mode and, if invoke mode is inherit, 
        /// also on the parent object's and/or browser's invoke mode.
        /// </summary>
        public bool WillInvoke {
            get {
                switch(InvokeMode) {
                    case JSInvokeMode.Invoke:
                        return true;
                    case JSInvokeMode.DontInvoke:
                        return false;
                    default:
                        if(m_parent != null)
                            return m_parent.WillInvoke;
                        if(m_browser != null)
                            return m_browser.RemoteCallbacksWillInvoke;
                        return true;
                }
            }
        }

        /// <summary>
        /// The name of this property.
        /// May be null if this property is still unbound.
        /// </summary>
        public string Name { get; private set; }

        private BrowserCore m_browser;
        private JSObject m_parent;

        internal CfrV8Context v8Context { get; private set; }
        private CfrV8Value v8Value;

        internal JSProperty(JSPropertyType type, JSInvokeMode invokeMode) {
            PropertyType = type;
            InvokeMode = invokeMode;
        }

        /// <summary>
        /// The browser this javascript property or the parent javascript object belongs to.
        /// May be null if this property or it's parent is still unbound.
        /// </summary>
        public BrowserCore Browser {
            get {

                if(m_browser != null)
                    return m_browser;

                if(m_parent != null)
                    return m_parent.Browser;

                return null;
            }
        }

        /// <summary>
        /// The parent javascript object of this property.
        /// May be null if this property is still unbound.
        /// </summary>
        public JSObject Parent {
            get {
                return m_parent;
            }
        }


        /* protected AND internal */
        internal abstract CfrV8Value CreateV8Value();

        internal CfrV8Value GetV8Value(CfrV8Context context) {
            if(v8Value == null || !Object.ReferenceEquals(v8Context, context)) {
                v8Context = context;
                v8Value = CreateV8Value();
            }
            return v8Value;
        }

        internal void SetParent(string propertyName, JSObject parent) {
            if(Object.ReferenceEquals(parent, this)) {
                throw new WebBrowserException("Can't add a javascript object to itself.");
            }
            CheckUnboundState();
            Name = propertyName;
            m_parent = parent;
        }

        internal void SetBrowser(string propertyName, BrowserCore browser) {
            CheckUnboundState();
            Name = propertyName;
            m_browser = browser;
        }

        internal void ClearParent() {
            Name = null;
            m_parent = null;
            m_browser = null;
        }

        private void CheckUnboundState() {
            if(m_parent != null) {
                throw new WebBrowserException("This property already belongs to an JSObject.");
            }
            if(m_browser != null) {
                throw new WebBrowserException("This property already belongs to a browser frame's global object.");
            }
        }
    }
}
