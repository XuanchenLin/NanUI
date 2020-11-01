using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    internal class JavaScriptBridgeFunctionHandler : CefV8Handler
    {
        private readonly string _parentKey;
        private readonly string _name;
        private readonly ProcessMessageBridgeHandler _bridge;
        private readonly CefV8Context _context;
        private readonly JavaScriptFunctionInfo _functionInfo;

        public JavaScriptBridgeFunctionHandler(string parentKey, string name, ProcessMessageBridgeHandler bridge, CefV8Context context, JavaScriptValue source)
        {
            this._parentKey = parentKey;
            this._name = name;
            this._bridge = bridge;
            this._context = context;
            this._functionInfo = source?.JSFunctionDescriber;


        }
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            if (name == _name)
            {
                var bid = _context.GetBrowser()?.Identifier ?? 0;
                var fid = _context.GetFrame()?.Identifier ?? 0;

                var request = MessageBridgeRequest.Create(JavaScriptCommunicationBridge.EXECUTE_JAVASCRIPT_FUNCTION, bid, fid, _context.GetHashCode());

                request.Arguments.Add(MessageValue.CreateString(_parentKey));
                request.Arguments.Add(MessageValue.CreateString(_name));

                var args = JavaScriptValue.CreateArray();

                var index = 0;

                foreach (var arg in arguments)
                {
                    var value = arg.ToJSValue();

                    if (value != null)
                    {
                        args.SetValue(index++, value);
                    }
                }

                request.Arguments.Add(MessageValue.CreateString(args.ToDefinition()));

                var guid = Guid.NewGuid();

                request.Arguments.Add(MessageValue.CreateString($"{guid}"));

                var response = _bridge.SendExecutionRequest(request);

                if (response.IsSuccess)
                {
                    if (_functionInfo.IsAsync)
                    {
                        var callback = CefV8Value.CreateObject();

                        var successFunc = CefV8Value.CreateFunction("success", new JavaScriptBridgeFunctionCallbackHandler(/*_parentKey, _name,*/ guid, _context));

                        var errorFunc = CefV8Value.CreateFunction("error", new JavaScriptBridgeFunctionCallbackHandler(/*_parentKey, _name,*/ guid, _context));

                        callback.SetValue("success", successFunc);
                        callback.SetValue("error", errorFunc);

                        returnValue = callback;
                        exception = null;
                    }
                    else
                    {
                        var retval = JavaScriptValue.FromJson(response.Arguments[0].GetString())?.ToCefV8Value();

                        exception = null;

                        if (retval != null)
                        {
                            returnValue = retval;
                        }
                        else
                        {
                            returnValue = CefV8Value.CreateUndefined();
                        }
                    }

                }
                else
                {
                    exception = response.ExceptionMessage;
                    returnValue = null;
                }

                return true;
            }

            returnValue = null;
            exception = $"{name} is not defined.";

            return true;
        }
    }
}
