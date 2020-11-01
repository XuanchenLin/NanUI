using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.NanUI
{
    public class RuntimeBuilderContext
    {

        public IDictionary<object, object> Properties { get; }


        internal RuntimeBuilderContext(IDictionary<object, object> properties)
        {
            Properties = properties;
        }
    }
}
