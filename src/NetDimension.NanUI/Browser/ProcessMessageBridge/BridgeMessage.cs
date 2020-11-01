using System;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    public sealed class BridgeMessage
    {
        class JsonBody
        {
            public string Name { get; set; }
            public string Arguments { get; set; }
        }

        public string Name { get; }
        public MessageArrayValue Arguments { get; }


        private BridgeMessage(string name, bool isFromJson)
        {
            if (isFromJson)
            {
                var request = JsonSerializer.Deserialize<JsonBody>(name);
                Name = request.Name;

                var retval = MessageValue.FromJson(request.Arguments);

                if (retval.ValueType == MessageValueType.Array)
                {
                    Arguments = retval.GetArray();
                }
                else
                {
                    Arguments = new MessageArrayValue();
                }

            }
            else
            {
                Name = name;
                Arguments = new MessageArrayValue();
            }

        }

        public string ToJson(bool formatted = false)
        {
            var body = new JsonBody();
            body.Name = Name;
            body.Arguments = Arguments?.ToJson();

            return JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = formatted, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        }

        public static BridgeMessage Create(string message)
        {
            return new BridgeMessage(message, false);
        }

        public static BridgeMessage FromJson(string json)
        {
            return new BridgeMessage(json, true);
        }
    }
}
