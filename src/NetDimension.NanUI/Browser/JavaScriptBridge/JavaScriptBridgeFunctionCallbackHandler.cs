using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    internal class JavaScriptBridgeFunctionCallbackHandler : CefV8Handler
    {
        //private readonly string _parentKey;
        //private readonly string _name;
        private readonly Guid _uuid;
        private readonly CefV8Context _context;

        public JavaScriptBridgeFunctionCallbackHandler(/*string parentKey, string name,*/ Guid uuid, CefV8Context context)
        {
            //_parentKey = parentKey;
            //_name = name;
            _uuid = uuid;
            _context = context;
        }

        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            if (arguments.Length == 1 && arguments[0].IsFunction && (name == "success" || name == "error"))
            {
                var info = new JavaScriptRenderSideAsyncFunction(_uuid,/* _parentKey, _name,*/ name== "success",  _context, arguments[0]);

                JavaScriptObjectRepository.AsyncFunctions.Add(info);

                returnValue = null;
                exception = null;

                return true;
            }

            returnValue = null;
            exception = $"{name} is not defined.";

            return true;


        }
    }
}
