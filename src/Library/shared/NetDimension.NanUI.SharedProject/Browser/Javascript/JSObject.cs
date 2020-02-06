// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using Chromium;
using Chromium.Remote;
using Chromium.Remote.Event;

namespace NetDimension.NanUI.Browser
{

    /// <summary>
    /// Represents a javascript object in the render process to be added as 
    /// a property to a browser frame's global object or to another JSObject.
    /// </summary>
    public class JSObject : JSProperty, IDictionary<string, JSProperty> {


        private readonly Dictionary<string, JSProperty> jsProperties = new Dictionary<string, JSProperty>();
        private CfrV8Accessor v8Accessor;

        /// <summary>
        /// Creates a new javascript object to be added as a property 
        /// to a browser frame's global object or a child object.
        /// </summary>
        public JSObject()
            : base(JSPropertyType.Object, JSInvokeMode.Inherit) {

        }

        /// <summary>
        /// Creates a new javascript object to be added as a property 
        /// to a browser frame's global object or a child object.
        /// </summary>
        public JSObject(JSInvokeMode invokeMode)
            : base(JSPropertyType.Object, invokeMode) {
        }

        /// <summary>
        /// Adds the specified javascript property to this object.
        /// </summary>
        public void Add(string name, JSProperty property) {
            if(jsProperties.ContainsKey(name))
                throw new WebBrowserException("A property with this name already exists.");
            property.SetParent(name, this);
            jsProperties.Add(name, property);
        }

        /// <summary>
        /// Determines whether this javascript object contains a property with the specified name.
        /// </summary>
        public bool ContainsKey(string name) {
            return jsProperties.ContainsKey(name);
        }

        /// <summary>
        /// Gets a collection containing the property names in this javascript object.
        /// </summary>
        public ICollection<string> Keys {
            get { return jsProperties.Keys; }
        }

        /// <summary>
        /// Removes the property with the specified name from this javascript object.
        /// </summary>
        public bool Remove(string name) {
            if(jsProperties.ContainsKey(name)) {
                jsProperties[name].ClearParent();
            }
            return jsProperties.Remove(name);
        }

        /// <summary>
        /// Gets the property with the specified name.
        /// </summary>
        public bool TryGetValue(string name, out JSProperty property) {
            return jsProperties.TryGetValue(name, out property);
        }

        /// <summary>
        /// Gets a collection containing the properties in this javascript object.
        /// </summary>
        public ICollection<JSProperty> Values {
            get { return jsProperties.Values; }
        }

        /// <summary>
        /// Gets or sets the property with the specified name.
        /// </summary>
        public JSProperty this[string name] {
            get {
                return jsProperties[name];
            }
            set {
                if(jsProperties.ContainsKey(name)) {
                    jsProperties[name].ClearParent();
                }
                jsProperties[name] = value;
            }
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<string, JSProperty> item) {
            throw new System.NotSupportedException();
        }

        /// <summary>
        /// Removes all properties from this javascript object.
        /// </summary>
        public void Clear() {
            jsProperties.Clear();
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public bool Contains(KeyValuePair<string, JSProperty> item) {
            throw new System.NotSupportedException();
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public void CopyTo(KeyValuePair<string, JSProperty>[] array, int arrayIndex) {
            throw new System.NotSupportedException();
        }

        /// <summary>
        /// Gets the number of properties contained in this javascript object.
        /// </summary>
        public int Count {
            get { return jsProperties.Count; }
        }

        /// <summary>
        /// Always false.
        /// </summary>
        public bool IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public bool Remove(KeyValuePair<string, JSProperty> item) {
            throw new System.NotSupportedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the properties in this javascript object.
        /// </summary>
        public IEnumerator<KeyValuePair<string, JSProperty>> GetEnumerator() {
            return jsProperties.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the properties in this javascript object.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return jsProperties.GetEnumerator();
        }

        /// <summary>
        /// Add a javascript function as a property to this object.
        /// </summary>
        public JSFunction AddFunction(string functionName) {
            var f = new JSFunction();
            Add(functionName, f);
            return f;
        }

        /// <summary>
        /// Add a javascript function as a property to this object.
        /// </summary>
        public JSFunction AddFunction(string functionName, JSInvokeMode invokeMode) {
            var f = new JSFunction(invokeMode);
            Add(functionName, f);
            return f;
        }

        /// <summary>
        /// Add another javascript object as a property to this object.
        /// </summary>
        public JSObject AddObject(string objectName) {
            var o = new JSObject();
            Add(objectName, o);
            return o;
        }

        /// <summary>
        /// Add another javascript object as a property to this object.
        /// </summary>
        public JSObject AddObject(string objectName, JSInvokeMode invokeMode) {
            var o = new JSObject(invokeMode);
            Add(objectName, o);
            return o;
        }
        
        /// <summary>
        /// Add a dynamic javascript property to this object.
        /// </summary>
        public JSDynamicProperty AddDynamicProperty(string propertyName) {
            var p = new JSDynamicProperty();
            Add(propertyName, p);
            return p;
        }

        /// <summary>
        /// Add a dynamic javascript property to this object.
        /// </summary>
        public JSDynamicProperty AddDynamicProperty(string propertyName, JSInvokeMode invokeMode) {
            var p = new JSDynamicProperty(invokeMode);
            Add(propertyName, p);
            return p;
        }

        internal override CfrV8Value CreateV8Value() {
            v8Accessor = new CfrV8Accessor();
            v8Accessor.Get += v8Accessor_Get;
            v8Accessor.Set += v8Accessor_Set;
            var o = CfrV8Value.CreateObject(v8Accessor);
            foreach(var p in jsProperties) {
                if(p.Value.PropertyType == JSPropertyType.Dynamic) {
                    o.SetValue(p.Key, CfxV8AccessControl.Default, CfxV8PropertyAttribute.DontDelete);
                } else {
                    o.SetValue(p.Key, p.Value.GetV8Value(v8Context), CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);
                }
            }
            return o;
        }

        void v8Accessor_Set(object sender, CfrV8AccessorSetEventArgs e) {
            JSProperty property;
            if(jsProperties.TryGetValue(e.Name, out property)) {
                ((JSDynamicProperty)property).RaisePropertySet(e);
            } else {
                //this should never be reached
                e.SetReturnValue(false);
            }
        }

        void v8Accessor_Get(object sender, CfrV8AccessorGetEventArgs e) {
            JSProperty property;
            if(jsProperties.TryGetValue(e.Name, out property)) {
                ((JSDynamicProperty)property).RaisePropertyGet(e);
            } else {
                //this should never be reached
                e.SetReturnValue(false);
            }
        }
    }
}
