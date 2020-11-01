using System;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{

    public sealed class JavaScriptAsyncFunctionCallback
    {
        bool _isCalled = false;
        private readonly CefFrame _frame;
        //private readonly string _objectKey;
        //private readonly string _name;
        private readonly Guid _uuid;
        private JavaScriptCommunicationBridge _jsBridge;

        public JavaScriptAsyncFunctionCallback(CefFrame frame, /*string objectKey, string name, */Guid uuid, JavaScriptCommunicationBridge bridge)
        {
            this._frame = frame;
            //this._objectKey = objectKey;
            //this._name = name;
            this._uuid = uuid;
            _jsBridge = bridge;
        }

        public void Success(params JavaScriptValue[] retvals)
        {
            if (_isCalled)
            {
                throw new InvalidOperationException();
            }


            var message = BridgeMessage.Create(JavaScriptCommunicationBridge.EXECUTE_JAVASCRIPT_FUNCTION);

            message.Arguments.Add(MessageValue.CreateBool(true));

            var retval = retvals?.ToJSValue() ?? JavaScriptValue.CreateArray();

            message.Arguments.Add(MessageValue.CreateString(retval.ToDefinition()));
            message.Arguments.Add(MessageValue.CreateString($"{_uuid}"));


            _jsBridge.SendProcessMessage(_frame, message);

            _isCalled = true;
        }

        public void Error(string text = "Invalid operation")
        {
            if (_isCalled)
            {
                throw new InvalidOperationException();
            }

            var message = BridgeMessage.Create(JavaScriptCommunicationBridge.EXECUTE_JAVASCRIPT_FUNCTION);
            //message.Arguments.Add(MessageValue.CreateString(_objectKey));
            //message.Arguments.Add(MessageValue.CreateString(_name));
            message.Arguments.Add(MessageValue.CreateBool(false));
            message.Arguments.Add(MessageValue.CreateString(text));
            message.Arguments.Add(MessageValue.CreateString($"{_uuid}"));

            _jsBridge.SendProcessMessage(_frame, message);

            _isCalled = true;
        }
    }

}
