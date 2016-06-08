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
using System;

namespace NetDimension.NanUI.ChromiumCore
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
    /// Modes for the JSProperty.InvokeMode property.
    /// </summary>
    public enum JSInvokeMode {
        /// <summary>
        /// Inherit from parent object. This is the default mode
        /// for javascript properties.
        /// </summary>
        Inherit,
        /// <summary>
        /// Callbacks from the render process are executed on the 
        /// thread that owns the browser's underlying window handle
        /// within the context of the calling remote thread.
        /// This is the default mode for the webbrowser object.
        /// </summary>
        Invoke,
        /// <summary>
        /// Callback from the render process are executed on the
        /// worker thread which marshals the callback.
        /// </summary>
        DontInvoke
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

        private IChromiumWebBrowser m_browser;
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
        public IChromiumWebBrowser Browser {
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
                throw new HtmlUIException("Can't add a javascript object to itself.");
            }
            CheckUnboundState();
            Name = propertyName;
            m_parent = parent;
        }

        internal void SetBrowser(string propertyName, IChromiumWebBrowser browser) {
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
                throw new HtmlUIException("This property already belongs to an JSObject.");
            }
            if(m_browser != null) {
                throw new HtmlUIException("This property already belongs to a browser frame's global object.");
            }
        }
    }
}
