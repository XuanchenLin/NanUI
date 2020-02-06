using Chromium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    public abstract class ChromiumExtensionBase : CfrV8Handler
    {

        public ChromiumExtensionBase()
        {
            Execute += (@this, e) =>
            {
                string exception = null;
                var name = e.Name;

                var retval = OnExtensionExecute(e.Name, e.Arguments, e.Object, ref exception);
                e.Exception = exception;

                if (retval != null)
                {
                    e.SetReturnValue(retval);
                }
            };
        }

        public abstract string DefinitionJavascriptCode { get; }

        public abstract CfrV8Value OnExtensionExecute(string nativeFunctionName, CfrV8Value[] arguments, CfrV8Value @this, ref string exception);
    }
}
