using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{

    public abstract class JavaScriptExtensionBase
    {
        internal List<JavaScriptExtensionFunctionHandler> FunctionHandlers { get; } = new List<JavaScriptExtensionFunctionHandler>();
        public abstract string Name { get; }

        public abstract string JavaScriptCode { get; }

        internal protected void RegisterFunctionHandler(string functionName, Action<Formium, JavaScriptValue[], JavaScriptAsyncFunctionCallback> function)
        {
            if (FunctionHandlers.Any(x => x.FuntionName.Equals(functionName)))
            {
                throw new ArgumentException();
            }

            var handler = new JavaScriptExtensionFunctionHandler(functionName, function);

            FunctionHandlers.Add(handler);
        }

        internal protected void RegisterFunctionHandler(string functionName, Func<Formium, JavaScriptValue[], JavaScriptValue> function)
        {
            if (FunctionHandlers.Any(x => x.FuntionName.Equals(functionName)))
            {
                throw new ArgumentException();
            }

            var handler = new JavaScriptExtensionFunctionHandler(functionName, function);

            FunctionHandlers.Add(handler);
        }

        internal protected void RegisterFunctionHandler(string functionName, Action<JavaScriptValue[], JavaScriptRendererSideAsyncFunctionCallback> function)
        {
            if (FunctionHandlers.Any(x => x.FuntionName.Equals(functionName)))
            {
                throw new ArgumentException();
            }

            var handler = new JavaScriptExtensionFunctionHandler(functionName, function);

            FunctionHandlers.Add(handler);
        }

        internal protected void RegisterFunctionHandler(string functionName, Func<JavaScriptValue[], JavaScriptValue> function)
        {
            if (FunctionHandlers.Any(x => x.FuntionName.Equals(functionName)))
            {
                throw new ArgumentException();
            }

            var handler = new JavaScriptExtensionFunctionHandler(functionName, function);

            FunctionHandlers.Add(handler);
        }



        internal JavaScriptExtensionHandler GetHandler(JavaScriptCommunicationBridge bridge)
        {
            return new JavaScriptExtensionHandler(this, bridge);
        }
    }

    internal class JavaScriptExtensionHandler : CefV8Handler
    {

        public JavaScriptExtensionHandler(JavaScriptExtensionBase extension, JavaScriptCommunicationBridge bridge)
        {
            Extension = extension;
            JSBridge = bridge;
        }

        public JavaScriptExtensionBase Extension { get; }
        public JavaScriptCommunicationBridge JSBridge { get; }

        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            var context = CefV8Context.GetCurrentContext();

            var browser = context.GetBrowser();

            var frame = browser.GetMainFrame();

            var function = Extension.FunctionHandlers.SingleOrDefault(x => x.FuntionName.Equals(name));

            //WinFormium.GetLogger().Debug($"{name}");

            if (function == null)
            {

                exception = $"[NanUI]:{name} is not defined.";
                returnValue = null;


                return true;
            }



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


            exception = null;

            var uuid = Guid.NewGuid();



            if (function.FunctionType == JavaScriptExtensionFunctionHandlerType.RendererSideFunction || function.FunctionType == JavaScriptExtensionFunctionHandlerType.RendererSideAsyncFunction)
            {
                if(function.FunctionType == JavaScriptExtensionFunctionHandlerType.RendererSideFunction)
                {
                    var retval = function.RendererSideFunction.Invoke(args.ToArray());
                    returnValue = retval?.ToCefV8Value() ?? CefV8Value.CreateUndefined();
                }
                else
                {

                    function.RendererSideAsyncFunction.Invoke(args.ToArray(), new JavaScriptRendererSideAsyncFunctionCallback(frame, uuid, JSBridge));

                    var callback = CefV8Value.CreateObject();
                    var successFunc = CefV8Value.CreateFunction("success", new JavaScriptBridgeFunctionCallbackHandler(uuid, context));

                    var errorFunc = CefV8Value.CreateFunction("error", new JavaScriptBridgeFunctionCallbackHandler(uuid, context));


                    callback.SetValue("success", successFunc);
                    callback.SetValue("error", errorFunc);

                    returnValue = callback;
                }

                return true;
            }
            else
            {
                var request = MessageBridgeRequest.Create(JavaScriptCommunicationBridge.EXECUTE_EXT_JAVASCRIPT_FUNCION, browser.Identifier, frame.Identifier, context.GetHashCode());


                request.Arguments.Add(MessageValue.CreateString(Extension.Name));

                request.Arguments.Add(MessageValue.CreateString(name));

                request.Arguments.Add(MessageValue.CreateString(args.ToDefinition()));

                request.Arguments.Add(MessageValue.CreateString($"{uuid}"));


                var response = JSBridge.SendExecutionRequest(request);




                if (response.IsSuccess)
                {

                    if(function.FunctionType == JavaScriptExtensionFunctionHandlerType.BrowserSideFunction)
                    {

                        if (response.Arguments != null && response.Arguments.Count > 0)
                        {

                            var retval = JavaScriptValue.FromJson(response.Arguments[0].GetString())?.ToCefV8Value();


                            if (retval != null)
                            {
                                returnValue = retval;
                                return true;
                            }
                        }

                        
                    }
                    else
                    {
                        var callback = CefV8Value.CreateObject();
                        var successFunc = CefV8Value.CreateFunction("success", new JavaScriptBridgeFunctionCallbackHandler(uuid, context));

                        var errorFunc = CefV8Value.CreateFunction("error", new JavaScriptBridgeFunctionCallbackHandler(uuid, context));

                        callback.SetValue("success", successFunc);
                        callback.SetValue("error", errorFunc);

                        returnValue = callback;

                        return true;
                    }

                    returnValue = CefV8Value.CreateUndefined();

                }
                else
                {
                    returnValue = null;
                    exception = response.ExceptionMessage;
                }

            }

            return true;
        }
    }


    internal enum JavaScriptExtensionFunctionHandlerType
    {
        BrowserSideFunction,
        RendererSideFunction,
        BrowserSideAsyncFunction,
        RendererSideAsyncFunction
    }

    internal class JavaScriptExtensionFunctionHandler
    {
        public JavaScriptExtensionFunctionHandlerType FunctionType { get; }
        public string FuntionName { get; }
        public Action<Formium, JavaScriptValue[], JavaScriptAsyncFunctionCallback> BrowserSideAsyncFunction { get; }
        public Func<Formium, JavaScriptValue[], JavaScriptValue> BrowserSideFunction { get; }
        public Action<JavaScriptValue[], JavaScriptRendererSideAsyncFunctionCallback> RendererSideAsyncFunction { get; }
        public Func<JavaScriptValue[], JavaScriptValue> RendererSideFunction { get; }

        public JavaScriptExtensionFunctionHandler(string functionName, Action<Formium, JavaScriptValue[], JavaScriptAsyncFunctionCallback> asyncFuncion)
        {
            FuntionName = functionName;
            BrowserSideAsyncFunction = asyncFuncion;
            FunctionType = JavaScriptExtensionFunctionHandlerType.BrowserSideAsyncFunction;
        }

        public JavaScriptExtensionFunctionHandler(string functionName, Func<Formium, JavaScriptValue[], JavaScriptValue> function)
        {
            FuntionName = functionName;
            BrowserSideFunction = function;
            FunctionType = JavaScriptExtensionFunctionHandlerType.BrowserSideFunction;
        }

        public JavaScriptExtensionFunctionHandler(string functionName, Action<JavaScriptValue[], JavaScriptRendererSideAsyncFunctionCallback> asyncFunction)
        {
            FuntionName = functionName;
            RendererSideAsyncFunction = asyncFunction;
            FunctionType = JavaScriptExtensionFunctionHandlerType.RendererSideAsyncFunction;
        }

        public JavaScriptExtensionFunctionHandler(string functionName, Func<JavaScriptValue[], JavaScriptValue> function)
        {
            FuntionName = functionName;
            RendererSideFunction = function;
            FunctionType = JavaScriptExtensionFunctionHandlerType.RendererSideFunction;
        }


    }

}
