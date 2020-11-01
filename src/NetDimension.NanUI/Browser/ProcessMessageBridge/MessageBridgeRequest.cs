using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    public sealed class MessageBridgeRequest
    {
        class JsonBody
        {
            public string Name { get; set; }
            public int BrowserId { get; set; }
            public long FrameId { get; set; }
            public int ContextId { get; set; }
            public string Arguments { get; set; }
        }
        public string Name { get;  }
        public int BrowserId { get;  }
        public long FrameId { get;  }
        public int ContextId { get; }

        public MessageArrayValue Arguments { get;  }

        private MessageBridgeRequest(string name, int browserId, long frameId,int contextId)
        {

            Name = name;
            BrowserId = browserId;
            FrameId = frameId;
            ContextId = contextId;

            Arguments = new MessageArrayValue();
        }

        private MessageBridgeRequest(string json)
        {
            var retval = JsonSerializer.Deserialize<JsonBody>(json);
            Name = retval.Name;
            BrowserId = retval.BrowserId;
            FrameId = retval.FrameId;
            ContextId = retval.ContextId;
            BrowserId = retval.BrowserId;
            FrameId = retval.FrameId;
            Arguments = MessageValue.FromJson(retval.Arguments)?.GetArray() ?? (MessageArrayValue)MessageValue.CreateArray();
        }

        public string ToJson(bool formatted = false)
        {
            var body = new JsonBody();
            body.Name = Name;
            body.BrowserId = BrowserId;
            body.FrameId = FrameId;
            body.ContextId = ContextId;
            body.Arguments = Arguments?.ToJson(formatted);

            return JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = formatted, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        }


        public static MessageBridgeRequest Create(string name, int browserId, long frameId, int contextId)
        {
            return new MessageBridgeRequest(name, browserId, frameId, contextId);
        }

        

        public static MessageBridgeRequest Create(string json)
        {
            return new MessageBridgeRequest(json);


        }

        
    }
}
