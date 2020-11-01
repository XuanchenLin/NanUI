using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI.JavaScript
{
    public sealed class JavaScriptProperty
    {
        public JavaScriptProperty()
        {

        }

        public bool Readable => Getter != null;
        public bool Writable => Setter != null;

        public Func<JavaScriptValue> Getter { get; set; }
        public Action<JavaScriptValue> Setter { get; set; }
    }
}
