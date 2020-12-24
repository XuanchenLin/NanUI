using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetDimension.NanUI.Browser;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    public sealed class JavaScriptCommunicationBridge : ProcessMessageBridgeHandler
    {
        internal const string EVALUATE_JS_MESSAGE = MessageBridge.MESSAGE_PREFIX + "EvaluateJavaScript";

        internal const string EVALUATE_JS_CALLBACK = MessageBridge.MESSAGE_PREFIX + "EvaluateJavaScriptCallback";

        internal const string JS_OBJECT_MAPPING_MESSAGE = MessageBridge.MESSAGE_PREFIX + "MapJavaScriptObjects";

        internal const string GET_OBJECT_PROPERTY = MessageBridge.MESSAGE_PREFIX + "GetObjectProperty";

        internal const string SET_OBJECT_PROPERTY = MessageBridge.MESSAGE_PREFIX + "SetObjectProperty";

        internal const string EXECUTE_JAVASCRIPT_FUNCTION = MessageBridge.MESSAGE_PREFIX + "ExecuteJavaScriptFunction";

        internal const string EXECUTE_EXT_JAVASCRIPT_FUNCION = MessageBridge.MESSAGE_PREFIX + "ExecuteExtensionJavaScriptFunction";

        internal const string ROOT_OBJECT_KEY_TARGET = "Formium";

        internal bool IsObjectsMapped { get; set; }


        public JavaScriptCommunicationBridge()
        {
            RegisterJavascriptMessageHandler(OnGetObjectProperty);
            RegisterJavascriptMessageHandler(OnSetObjectProperty);
            RegisterJavascriptMessageHandler(OnExecuteFunction);

            RegisterJavascriptMessageHandler(OnExecuteExtensionFunction);
        }

        #region MessageHandler

        private MessageBridgeResponse OnExecuteExtensionFunction(MessageBridgeRequest request)
        {

            if (request.Name == EXECUTE_EXT_JAVASCRIPT_FUNCION)
            {
                var owner = BrowserSideBridge.Owner;

                var extensionName = request.Arguments[0].GetString();
                var functionName = request.Arguments[1].GetString();
                var arguments = JavaScriptValue.FromJson(request.Arguments[2].GetString()).ToArray();
                var uuid = new Guid(request.Arguments[3].GetString());


                var extension = WinFormium.Runtime.Container.GetInstance<JavaScriptExtensionBase>(extensionName);

                if (extension == null)
                {
                    return MessageBridgeResponse.CreateFailureResponse($"JavaScript extension handler is not found.");
                }

                var function = extension.FunctionHandlers.SingleOrDefault(x => x.FuntionName.Equals(functionName));

                if (function == null)
                {
                    return MessageBridgeResponse.CreateFailureResponse($"{functionName} is not defined.");
                }

                if (function.FunctionType == JavaScriptExtensionFunctionHandlerType.BrowserSideFunction && function.BrowserSideFunction != null)
                {
                    JavaScriptValue retval = null;


                    owner.InvokeIfRequired(() => {
                        retval = function.BrowserSideFunction.Invoke(owner, arguments);
                    });

                    retval = retval ?? JavaScriptValue.CreateNull();

                    var response = MessageBridgeResponse.CreateSuccessResponse();
                    response.Arguments.Add(MessageValue.CreateString(retval.ToDefinition()));
                    return response;


                }
                else if (function.FunctionType == JavaScriptExtensionFunctionHandlerType.BrowserSideAsyncFunction && function.BrowserSideAsyncFunction != null)
                {
                    owner.InvokeIfRequired(() => {
                        function.BrowserSideAsyncFunction.Invoke(owner, arguments, new JavaScriptAsyncFunctionCallback(owner.GetMainFrame(), uuid, this));
                    });

                    var response = MessageBridgeResponse.CreateSuccessResponse();
                    return response;
                }


                return MessageBridgeResponse.CreateFailureResponse($"{functionName} is not defined.");
            }

            //return MessageBridgeResponse.CreateFailureResponse("Function is not defined.");

            return null;

        }

        private MessageBridgeResponse OnExecuteFunction(MessageBridgeRequest request)
        {
            if (request.Name == EXECUTE_JAVASCRIPT_FUNCTION)
            {
                var objectKey = request.Arguments[0].GetString();
                var propertyName = request.Arguments[1].GetString();

                var arguments = JavaScriptValue.FromJson(request.Arguments[2].GetString()).ToArray();


                if (RegisteredJavaScriptObjects.ContainsKey(objectKey))
                {
                    var targetObject = RegisteredJavaScriptObjects[objectKey];

                    if (targetObject != null && targetObject.HasValue(propertyName))
                    {
                        var value = targetObject.GetValue(propertyName);

                        if (value.IsFunction)
                        {
                            var functionInfo = value.JSFunctionDescriber;

                            if (functionInfo != null)
                            {
                                if (functionInfo.IsAsync)
                                {

                                    var uuid = new Guid(request.Arguments[3].GetString());
                                    var frame = BrowserSideBridge.Owner.GetMainFrame();
                                    value.AsyncMethod?.Invoke(arguments, new JavaScriptAsyncFunctionCallback(frame,/* objectKey, propertyName,*/ uuid, this));

                                    var response = MessageBridgeResponse.CreateSuccessResponse();

                                    return response;

                                }
                                else
                                {
                                    var retval = value.Method?.Invoke(arguments)??JavaScriptValue.CreateNull();
                                    var response = MessageBridgeResponse.CreateSuccessResponse();

                                    response.Arguments.Add(MessageValue.CreateString(retval.ToDefinition()));

                                    return response;

                                }
                            }
                        }
                    }

                }
            }

            //return MessageBridgeResponse.CreateFailureResponse("Function is not defined.");

            return null;
        }

        private MessageBridgeResponse OnGetObjectProperty(MessageBridgeRequest request)
        {
            if (request.Name == GET_OBJECT_PROPERTY)
            {
                var objectKey = request.Arguments[0].GetString();
                var propertyName = request.Arguments[1].GetString();

                if (RegisteredJavaScriptObjects.ContainsKey(objectKey))
                {

                    var targetObject = RegisteredJavaScriptObjects[objectKey];

                    if (targetObject != null && targetObject.HasValue(propertyName))
                    {
                        var value = targetObject.GetValue(propertyName);

                        if (value.IsProperty)
                        {
                            var result = value.Property?.Getter?.Invoke();

                            var response = MessageBridgeResponse.CreateSuccessResponse();

                            response.Arguments.Add(MessageValue.CreateString(result.ToDefinition()));

                            return response;
                        }
                    }
                }

                return MessageBridgeResponse.CreateFailureResponse("Getter is not defined.");
            }

            return null;
        }

        private MessageBridgeResponse OnSetObjectProperty(MessageBridgeRequest request)
        {
            if (request.Name == SET_OBJECT_PROPERTY)
            {
                var objectKey = request.Arguments[0].GetString();

                var propertyName = request.Arguments[1].GetString();

                var retval = JavaScriptValue.FromJson(request.Arguments[2].GetString());


                if (RegisteredJavaScriptObjects.ContainsKey(objectKey))
                {
                    var targetObject = RegisteredJavaScriptObjects[objectKey];

                    if (targetObject != null && targetObject.HasValue(propertyName))
                    {
                        var value = targetObject.GetValue(propertyName);

                        if (value.IsProperty)
                        {
                            value.Property?.Setter?.Invoke(retval);

                            return MessageBridgeResponse.CreateSuccessResponse();
                        }
                    }


                }

                return MessageBridgeResponse.CreateFailureResponse("Setter is not defined.");
            }

            return null;
        }
        #endregion

        #region BrowserSide
        internal Dictionary<string, JavaScriptValue> RegisteredJavaScriptObjects { get; } = new Dictionary<string, JavaScriptValue>();

        class JavaScriptExecutionCallBackTask : CefTask
        {
            private readonly CefFrame frame;
            private readonly MessageArrayValue arguments;
            private readonly int taskId;
            private readonly bool isSuccess;

            public JavaScriptExecutionCallBackTask(CefFrame frame, MessageArrayValue arguments)
            {
                this.frame = frame;
                this.arguments = arguments;

                taskId = arguments[0].GetInt();
                isSuccess = arguments[1].GetBool();

            }
            protected override void Execute()
            {
                if (JavaScriptObjectRepository.JavaScriptExecutionTasks.TryRemove(new Tuple<int, long>(taskId, frame.Identifier), out var callback))
                {

                    JavaScriptExecutionResult result;
                    if (isSuccess)
                    {
                        result = new JavaScriptExecutionResult(isSuccess, arguments[2].GetString(), null);
                    }
                    else
                    {
                        result = new JavaScriptExecutionResult(isSuccess, null, arguments[2].GetString());
                    }

                    callback.SetResult(result);
                }
            }
        }

        class BrowserSideJavaScriptObjectMappingTask : CefTask
        {
            private readonly JavaScriptCommunicationBridge jsbridge;
            private readonly CefFrame frame;

            public BrowserSideJavaScriptObjectMappingTask(JavaScriptCommunicationBridge bridge, CefFrame frame)
            {
                this.jsbridge = bridge;
                this.frame = frame;
            }

            protected override void Execute()
            {
                var message = BridgeMessage.Create(JS_OBJECT_MAPPING_MESSAGE);
                var args = JavaScriptValue.CreateObject();

                foreach (var obj in jsbridge.RegisteredJavaScriptObjects)
                {
                    if (obj.Value != null)
                    {
                        args.SetValue(obj.Key, obj.Value);
                    }
                }

                message.Arguments.Add(MessageValue.CreateString(args.ToDefinition()));

                jsbridge.SendProcessMessage(frame, message);

                jsbridge.IsObjectsMapped = true;
            }

        }

        public override void OnRenderSideMessageReceived(string message, CefFrame frame, MessageArrayValue arguments)
        {
            if (message == EVALUATE_JS_CALLBACK)
            {
                CefRuntime.PostTask(CefThreadId.UI, new JavaScriptExecutionCallBackTask(frame, arguments));
            }

            if (message == JS_OBJECT_MAPPING_MESSAGE)
            {
                CefRuntime.PostTask(CefThreadId.UI, new BrowserSideJavaScriptObjectMappingTask(this, frame));
            }


        }

        public override void OnBeforeBrowse(CefFrame frame)
        {
            ClearRelatedTasks(frame);

            IsObjectsMapped = false;
        }

        public override void OnBeforeClose(CefBrowser browser)
        {
            ClearRelatedTasks(browser.GetMainFrame());

            IsObjectsMapped = false;

        }

        private static void ClearRelatedTasks(CefFrame frame)
        {
            var tasks = JavaScriptObjectRepository.JavaScriptExecutionTasks.Where(x => x.Key.Item2 == frame.Identifier);

            var ids = new List<int>();

            foreach (var item in tasks)
            {

                var callback = item.Value;

                callback?.SetCanceled();

                JavaScriptObjectRepository.JavaScriptExecutionTasks.TryRemove(item.Key, out _);
            }

            GC.Collect();


        }
        #endregion

        #region RenderSide
        class JavaScriptExecuteionTask : CefTask
        {
            private readonly JavaScriptCommunicationBridge jsbridge;
            private readonly CefFrame frame;
            private int taskId;
            private int functionId;
            private JavaScriptValue arguments;

            public JavaScriptExecuteionTask(JavaScriptCommunicationBridge bridge, CefFrame frame, MessageArrayValue arguments)
            {
                this.jsbridge = bridge;
                this.frame = frame;
                taskId = arguments[0].GetInt();
                functionId = arguments[1].GetInt();
                this.arguments = JavaScriptValue.FromJson(arguments[2].GetString());
            }

            protected override void Execute()
            {
                var cachedFuncInfo = JavaScriptObjectRepository.RenderSideFunctions.SingleOrDefault(x => x.Id == functionId);

                if (cachedFuncInfo == null)
                {
                    return;
                }

                var func = cachedFuncInfo.Function;

                var context = cachedFuncInfo.Context;

                var msg = BridgeMessage.Create(EVALUATE_JS_CALLBACK);
                msg.Arguments.Add(MessageValue.CreateInt(taskId));

                context.Enter();

                CefV8Value[] argumentList = null;
                CefV8Value result = null;
                try
                {
                    argumentList = arguments.ToCefV8Arguments();
                    result = func.ExecuteFunctionWithContext(context, null, argumentList);
                }
                finally
                {
                    if (argumentList != null)
                    {
                        foreach (var value in argumentList)
                        {
                            value.Dispose();
                        }
                    }

                    context.Exit();
                }

                if (result != null)
                {
                    var jsvalue = result.ToJSValue();
                    msg.Arguments.Add(MessageValue.CreateBool(true));
                    msg.Arguments.Add(MessageValue.CreateString(jsvalue.ToDefinition()));

                    result.Dispose();
                }
                else
                {
                    msg.Arguments.Add(MessageValue.CreateBool(false));
                    msg.Arguments.Add(MessageValue.CreateString("Executing function failed."));
                }

                jsbridge.SendProcessMessage(frame, msg);

            }



        }

        class JavaScriptEvaluationTask : CefTask
        {
            private readonly JavaScriptCommunicationBridge jsbridge;
            private readonly CefFrame frame;
            private int taskId;
            private string code;

            public JavaScriptEvaluationTask(JavaScriptCommunicationBridge bridge, CefFrame frame, MessageArrayValue arguments)
            {
                this.jsbridge = bridge;
                this.frame = frame;
                taskId = arguments[0].GetInt();
                code = arguments[1].GetString();
            }

            protected override void Execute()
            {
                var context = frame.V8Context;

                var msg = BridgeMessage.Create(EVALUATE_JS_CALLBACK);
                msg.Arguments.Add(MessageValue.CreateInt(taskId));

                if (context.TryEval(code, frame.Url, 0, out CefV8Value retval, out CefV8Exception v8Exception))
                {
                    context.Enter();

                    try
                    {
                        var jsvalue = retval.ToJSValue();

                        msg.Arguments.Add(MessageValue.CreateBool(true));
                        msg.Arguments.Add(MessageValue.CreateString(jsvalue.ToDefinition()));

                    }
                    catch (Exception ex)
                    {

                        msg.Arguments.Add(MessageValue.CreateBool(false));
                        msg.Arguments.Add(MessageValue.CreateString(ex.Message));

                    }
                    finally
                    {
                        context.Exit();
                    }
                }
                else
                {

                    msg.Arguments.Add(MessageValue.CreateBool(false));
                    msg.Arguments.Add(MessageValue.CreateString(v8Exception.Message));
                }


                jsbridge.SendProcessMessage(frame, msg);

                retval?.Dispose();

                v8Exception?.Dispose();


            }
        }

        class RenderSideJavaScriptObjectMappingTask : CefTask
        {
            private const string OBJECT_KEY_EXTERNAL = "external";
            private readonly JavaScriptCommunicationBridge jsbridge;
            private readonly CefFrame frame;
            private readonly MessageArrayValue arguments;

            public RenderSideJavaScriptObjectMappingTask(JavaScriptCommunicationBridge bridge, CefFrame frame, MessageArrayValue arguments)
            {
                this.jsbridge = bridge;
                this.frame = frame;
                this.arguments = arguments;
            }
            protected override void Execute()
            {
                var json = arguments[0].GetString();


                var objects = JavaScriptValue.FromJson(json);

                if (!objects.IsObject)
                {
                    return;
                }

                var context = frame.V8Context;

                context.Enter();

                try
                {
                    var window = context.GetGlobal();

                    if (!window.HasValue(ROOT_OBJECT_KEY_TARGET))
                    {
                        window.SetValue(ROOT_OBJECT_KEY_TARGET, CefV8Value.CreateObject(), CefV8PropertyAttribute.DontDelete);
                    }

                    var targetObject = window.GetValue(ROOT_OBJECT_KEY_TARGET);

                    if (!targetObject.HasValue(OBJECT_KEY_EXTERNAL))
                    {
                        targetObject.DeleteValue(OBJECT_KEY_EXTERNAL);
                    }

                    var bridgeObject = CefV8Value.CreateObject();

                    targetObject.SetValue(OBJECT_KEY_EXTERNAL, bridgeObject, CefV8PropertyAttribute.DontDelete);

                    foreach (var key in objects.Keys)
                    {
                        var source = objects.GetValue(key);

                        CreateObject(key, bridgeObject, source, context);
                    }

                }
                finally
                {
                    context.Exit();
                }

            }

            private void CreateObject(string key, CefV8Value cefObject, JavaScriptValue source, CefV8Context context, string parentKey = null)
            {


                switch (source.ValueType)
                {
                    case JavaScriptValueType.Null:
                    case JavaScriptValueType.Bool:
                    case JavaScriptValueType.Int:
                    case JavaScriptValueType.Double:
                    case JavaScriptValueType.String:
                    case JavaScriptValueType.DateTime:
                        cefObject.SetValue(key, source.ToCefV8Value());
                        break;
                    case JavaScriptValueType.Object:

                        var accessor = new JavaScriptObjectAccessor(key, jsbridge, context, source);

                        var obj = CefV8Value.CreateObject(accessor);

                        foreach (var objectKey in source.Keys)
                        {

                            if (source.HasValue(objectKey))
                            {
                                var property = source.GetValue(objectKey);

                                CreateObject(objectKey, obj, property, context, key);
                            }
                        }

                        cefObject.SetValue(key, obj);

                        break;
                    case JavaScriptValueType.Array:

                        var lst = new List<CefV8Value>();

                        for (var i = 0; i < source.ArrayLength; i++)
                        {
                            var item = source.GetValue(i)?.ToCefV8Value();
                            lst.Add(item);
                        }

                        var array = CefV8Value.CreateArray(lst.Count);

                        cefObject.SetValue(key, array);

                        break;
                    case JavaScriptValueType.Property:
                        CefV8AccessControl accessControl = CefV8AccessControl.Default;
                        CefV8PropertyAttribute cefV8PropertyAttribute = CefV8PropertyAttribute.DontDelete;

                        if (source.JSPropertyDescriber.IsReadable)
                        {
                            accessControl |= CefV8AccessControl.AllCanRead;
                        }

                        if (source.JSPropertyDescriber.IsWritable)
                        {
                            accessControl |= CefV8AccessControl.AllCanWrite;
                        }
                        else
                        {
                            cefV8PropertyAttribute |= CefV8PropertyAttribute.ReadOnly;
                        }



                        cefObject.SetValue(key, accessControl, cefV8PropertyAttribute);

                        break;
                    case JavaScriptValueType.Function:

                        var function = CefV8Value.CreateFunction(key, new JavaScriptBridgeFunctionHandler(parentKey, key, jsbridge, context, source));

                        cefObject.SetValue(key, function);

                        break;

                }

            }

            class JavaScriptObjectAccessor : CefV8Accessor
            {
                private readonly string _objectKey;
                private readonly ProcessMessageBridgeHandler _bridge;
                private CefV8Context _context;
                private JavaScriptValue _objects;

                private List<JavaScriptValue> Properties { get; } = new List<JavaScriptValue>();

                public JavaScriptObjectAccessor(string objectKey, ProcessMessageBridgeHandler bridge, CefV8Context context, JavaScriptValue objects)
                {
                    this._objectKey = objectKey;
                    this._bridge = bridge;
                    this._context = context;
                    this._objects = objects;

                    if (objects.IsObject)
                    {
                        foreach (var key in objects.Keys)
                        {
                            var item = objects.GetValue(key);
                            if (item.IsProperty)
                            {
                                Properties.Add(item);
                            }
                        }
                    }

                }

                protected override bool Get(string name, CefV8Value obj, out CefV8Value returnValue, out string exception)
                {

                    var property = Properties.SingleOrDefault(t => t.Name == name);

                    if (property != null && property.JSPropertyDescriber.IsReadable)
                    {
                        var bid = _context.GetBrowser()?.Identifier ?? 0;
                        var fid = _context.GetFrame()?.Identifier ?? 0;

                        var request = MessageBridgeRequest.Create(GET_OBJECT_PROPERTY, bid, fid, _context.GetHashCode());

                        request.Arguments.Add(MessageValue.CreateString(_objectKey));
                        request.Arguments.Add(MessageValue.CreateString(name));

                        var response = _bridge.SendExecutionRequest(request);

                        if (response.IsSuccess)
                        {
                            returnValue = JavaScriptValue.FromJson(response.Arguments[0].GetString()).ToCefV8Value();
                            exception = null;
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

                protected override bool Set(string name, CefV8Value obj, CefV8Value value, out string exception)
                {
                    var property = Properties.SingleOrDefault(t => t.Name == name);
                    if (property != null && property.JSPropertyDescriber.IsWritable)
                    {

                        var bid = _context.GetBrowser()?.Identifier ?? 0;
                        var fid = _context.GetFrame()?.Identifier ?? 0;

                        var request = MessageBridgeRequest.Create(SET_OBJECT_PROPERTY, bid, fid, _context.GetHashCode());

                        request.Arguments.Add(MessageValue.CreateString(_objectKey));
                        request.Arguments.Add(MessageValue.CreateString(name));
                        request.Arguments.Add(MessageValue.CreateString(value.ToJSValue().ToDefinition()));

                        var response = _bridge.SendExecutionRequest(request);

                        if (response.IsSuccess)
                        {
                            exception = null;
                        }
                        else
                        {
                            exception = response.ExceptionMessage;
                        }

                        return true;

                    }

                    exception = null;

                    exception = $"{name} is not defined.";

                    return true;
                }
            }
        }

        internal class RenderSideJavaScriptExecutionCallbackTask : CefTask
        {
            private readonly JavaScriptCommunicationBridge jsbridge;
            private readonly CefFrame frame;
            private readonly MessageArrayValue arguments;

            public RenderSideJavaScriptExecutionCallbackTask(JavaScriptCommunicationBridge bridge, CefFrame frame, MessageArrayValue arguments)
            {
                this.jsbridge = bridge;
                this.frame = frame;
                this.arguments = arguments;


            }
            protected override void Execute()
            {
                //var objectKey = arguments[0].GetString();
                //var key = arguments[1].GetString();
                var isSuccess = arguments[0].GetBool();
                var args = JavaScriptValue.FromJson(arguments[1].GetString());
                var uuid = new Guid(arguments[2].GetString());


                var source = JavaScriptObjectRepository.AsyncFunctions.Where(x => /*x.ObjectName == objectKey && x.FunctionName == key &&*/ x.IsSuccess == isSuccess && x.UUID == uuid);

                foreach (var func in source)
                {
                    var context = func.Context;
                    try
                    {
                        context.Enter();
                        func.Function.ExecuteFunctionWithContext(context, null, args.ToCefV8Arguments());

                    }
                    finally
                    {
                        context.Exit();
                    }
                }

                foreach (var func in JavaScriptObjectRepository.AsyncFunctions.Where(x => /*x.ObjectName == objectKey && x.FunctionName == key &&*/ x.UUID == uuid))
                {
                    func.Function.Dispose();
                }

                JavaScriptObjectRepository.AsyncFunctions.RemoveWhere(x => /*x.ObjectName == objectKey && x.FunctionName == key &&*/ x.UUID == uuid);
            }
        }

        public override void OnBrowserSideMessageReceived(string message, CefFrame frame, MessageArrayValue arguments)
        {
            if (message == EVALUATE_JS_MESSAGE)
            {
                CefRuntime.PostTask(CefThreadId.Renderer, new JavaScriptEvaluationTask(this, frame, arguments));
            }

            if (message == EVALUATE_JS_CALLBACK)
            {
                CefRuntime.PostTask(CefThreadId.Renderer, new JavaScriptExecuteionTask(this, frame, arguments));
            }

            if (message == JS_OBJECT_MAPPING_MESSAGE)
            {
                CefRuntime.PostTask(CefThreadId.Renderer, new RenderSideJavaScriptObjectMappingTask(this, frame, arguments));
            }

            if (message == EXECUTE_JAVASCRIPT_FUNCTION)
            {
                CefRuntime.PostTask(CefThreadId.Renderer, new RenderSideJavaScriptExecutionCallbackTask(this, frame, arguments));
            }


        }

        public override void OnContextCreated(CefFrame frame, CefV8Context context)
        {
            if (frame.IsMain)
            {
                var msg = BridgeMessage.Create(JS_OBJECT_MAPPING_MESSAGE);
                SendProcessMessage(frame, msg);
            }
        }

        public override void OnContextReleased(CefFrame frame, CefV8Context context)
        {
            RemoveObjectRepositoryContent(frame.Browser);
        }

        public override void OnRenderProcessTerminated(CefBrowser browser)
        {
            RemoveObjectRepositoryContent(browser);
        }

        private void RemoveObjectRepositoryContent(CefBrowser browser)
        {
            foreach (var funcInfo in JavaScriptObjectRepository.RenderSideFunctions.Where(x => x.Context.GetBrowser().Identifier == browser.Identifier))
            {
                funcInfo.Function?.Dispose();
            }

            JavaScriptObjectRepository.RenderSideFunctions.RemoveWhere(x => x.Context.GetBrowser().Identifier == browser.Identifier);

            foreach (var funcInfo in JavaScriptObjectRepository.AsyncFunctions.Where(x => x.Context.GetBrowser().Identifier == browser.Identifier))
            {
                funcInfo.Function?.Dispose();
            }

            JavaScriptObjectRepository.AsyncFunctions.RemoveWhere(x => x.Context.GetBrowser().Identifier == browser.Identifier);

            GC.Collect();
        }
        #endregion

        public Task<JavaScriptExecutionResult> EvaluatorJavaScript(CefFrame frame, string code)
        {
            var tsc = new TaskCompletionSource<JavaScriptExecutionResult>();

            if (JavaScriptObjectRepository.JavaScriptExecutionTasks.TryAdd(new Tuple<int, long>(tsc.GetHashCode(), frame.Identifier), tsc))
            {
                var message = BridgeMessage.Create(EVALUATE_JS_MESSAGE);

                message.Arguments.Add(MessageValue.CreateInt(tsc.GetHashCode()));
                message.Arguments.Add(MessageValue.CreateString(code));

                SendProcessMessage(frame, message);

                return tsc.Task;
            }


            throw new InvalidOperationException("Same function already exists.");
        }

        public void RegisterJavaScriptObjectValue(string name, JavaScriptValue value)
        {
            if (!value.IsObject)
            {
                throw new ArgumentException($"The js type of {value} should be an object.");
            }

            RegisteredJavaScriptObjects.Add(name, value);

            RequireRemapObjects();
        }

        private void RequireRemapObjects()
        {
            if (IsObjectsMapped)
            {
                var frame = BrowserSideBridge?.Owner?.GetMainFrame();
                if (frame != null)
                {
                    var msg = BridgeMessage.Create(JS_OBJECT_MAPPING_MESSAGE);
                    SendProcessMessage(BrowserSideBridge.Owner.GetMainFrame(), msg);
                }

            }
        }
    }
}
