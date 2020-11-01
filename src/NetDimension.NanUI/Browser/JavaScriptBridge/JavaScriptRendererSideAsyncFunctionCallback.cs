using System;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    public sealed class JavaScriptRendererSideAsyncFunctionCallback
    {
        bool _isCalled = false;
        private readonly CefFrame _frame;
        private readonly Guid _uuid;
        private JavaScriptCommunicationBridge _jsBridge;

        public JavaScriptRendererSideAsyncFunctionCallback(CefFrame frame, Guid uuid, JavaScriptCommunicationBridge bridge)
        {
            this._frame = frame;
            this._uuid = uuid;
            _jsBridge = bridge;

        }

        public void Success(params JavaScriptValue[] retvals)
        {
            if (_isCalled)
            {
                throw new InvalidOperationException();
            }

            var retval = retvals?.ToJSValue() ?? JavaScriptValue.CreateArray();

            var arguments = new MessageArrayValue();

            arguments.Add(MessageValue.CreateBool(true));
            arguments.Add(MessageValue.CreateString(retval.ToDefinition()));
            arguments.Add(MessageValue.CreateString($"{_uuid}"));


            CefRuntime.PostTask(CefThreadId.Renderer, new JavaScriptCommunicationBridge.RenderSideJavaScriptExecutionCallbackTask(_jsBridge, _frame, arguments));

            _isCalled = true;

        }

        public void Error(string text = "Invalid operation")
        {
            if (_isCalled)
            {
                throw new InvalidOperationException();
            }

            var arguments = new MessageArrayValue();

            arguments.Add(MessageValue.CreateBool(false));
            arguments.Add(MessageValue.CreateString(text));
            arguments.Add(MessageValue.CreateString($"{_uuid}"));


            CefRuntime.PostTask(CefThreadId.Renderer, new JavaScriptCommunicationBridge.RenderSideJavaScriptExecutionCallbackTask(_jsBridge, _frame, arguments));

            _isCalled = true;

        }
    }

}
