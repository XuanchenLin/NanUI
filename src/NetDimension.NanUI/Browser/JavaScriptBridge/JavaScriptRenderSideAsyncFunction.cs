using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    internal class JavaScriptRenderSideAsyncFunction
    {
        //public string ObjectName { get; }
        //public string FunctionName { get; }
        public Guid UUID { get; }
        public CefV8Context Context { get; }
        public CefV8Value Function { get;  }
        public bool IsSuccess { get; }

        public JavaScriptRenderSideAsyncFunction(Guid uuid, /*string objectName, string functionName,*/ bool isSuccess, CefV8Context context, CefV8Value function)
        {
            UUID = uuid;
            //ObjectName = objectName;
            IsSuccess = isSuccess;
            //FunctionName = functionName;
            Context = context;
            Function = function;
        }

    }
}
