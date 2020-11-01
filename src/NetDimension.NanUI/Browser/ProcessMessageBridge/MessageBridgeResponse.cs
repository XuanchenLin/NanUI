using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    public class MessageBridgeResponse
    {
        class JsonBody
        {

            public string Arguments { get; set; }
            public bool IsSuccess { get; set; }
            public string ExceptionMessage { get; set; }
        }


        public bool IsSuccess { get; internal set; }
        public string ExceptionMessage { get; internal set; }
        public MessageArrayValue Arguments { get; }

        private MessageBridgeResponse()
        {
            Arguments = new MessageArrayValue();
        }

        private MessageBridgeResponse(string json)
        {
            var retval = JsonSerializer.Deserialize<JsonBody>(json);

            IsSuccess = retval.IsSuccess;
            ExceptionMessage = retval.ExceptionMessage;
            Arguments = MessageValue.FromJson(retval.Arguments)?.GetArray() ?? (MessageArrayValue)MessageValue.CreateArray();
        }

        public string ToJson(bool formatted = false)
        {
            var body = new JsonBody();
            body.IsSuccess = IsSuccess;
            body.ExceptionMessage = ExceptionMessage;
            body.Arguments = Arguments?.ToJson(formatted);

            return JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = formatted, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        }
        
        public static MessageBridgeResponse CreateFailureResponse(string message)
        {
            return new MessageBridgeResponse() { IsSuccess =false, ExceptionMessage = message };
        }

        public static MessageBridgeResponse CreateSuccessResponse()
        {
            return new MessageBridgeResponse() { IsSuccess = true };
        }

        public static MessageBridgeResponse CreateSuccessResponse(string json)
        {
            return new MessageBridgeResponse(json);
        }
        
    }
}
