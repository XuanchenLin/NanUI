using NetDimension.NanUI.Browser.MessagePipe;
using NetDimension.NanUI.JavaScript.Renderer;

using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptProperties;

class JavaScriptPropertyHandlerOnBrowserSide : MessageHandlerOnBrowserSide
{

    JavaScriptPropertyHandler MessageHandler => (JavaScriptPropertyHandler)this.MessageHandlerWrapper;


    public JavaScriptPropertyHandlerOnBrowserSide(MessageHandlerWrapperBase messageHandlerWrapper)
        : base(messageHandlerWrapper)

    {
        RegisterMessageHandler(OnObjectGetProperty);
        RegisterMessageHandler(OnObjectSetProperty);
    }

    private MessageResponse OnObjectGetProperty(MessageRequest request)
    {
        if (request.Name == JavaScriptPropertyHandler.OBJECT_GET_PROPERTY_VALUE)
        {
            var data = JsonSerializer.Deserialize<JavaScriptObjectAccessorMessageParameter>(request.Data);

            var name = data.Name;
            var propUuid = data.Uuid;
            var objUuid = data.ObjectUuid;
            //JavaScriptValue value = JavaScriptValue.FromJson((string)data.Value);

            var target = JavaScriptProperty.Bag.SingleOrDefault(x => x.Uuid == propUuid);

            if (target != null)
            {
                var result = target.Getter.Invoke();
                return new MessageResponse()
                {
                    Data = result.ToJson()
                };
            }
            else
            {
                return new MessageResponse(false, $"[NanUI]: Property {name} is not defined.");
            }
        }

        return null;//new MessageResponse(false, $"[NanUI]: Property is not defined.");
    }
    private MessageResponse OnObjectSetProperty(MessageRequest request)
    {
        if (request.Name == JavaScriptPropertyHandler.OBJECT_SET_PROPERTY_VALUE)
        {
            var data = JsonSerializer.Deserialize<JavaScriptObjectAccessorMessageParameter>(request.Data);

            var name = data.Name;
            var propUuid = data.Uuid;
            var objUuid = data.ObjectUuid;
            var value = JavaScriptValue.FromJson((string)data.Value);

            var target = JavaScriptProperty.Bag.SingleOrDefault(x => x.Uuid == propUuid);

            if (target != null)
            {
                if (target.Setter == null)
                {
                    return new MessageResponse(false, $"[NanUI]: Property {name} is not writable.");
                }

                target.Setter.Invoke(value);

                return new MessageResponse()
                {
                    Data = JavaScriptValue.CreateUndefined().ToJson()
                };
            }
            else
            {
                return new MessageResponse(false, $"[NanUI]: Property {name} is not defined.");
            }
        }

        return null;// new MessageResponse(false, $"[NanUI]: Property is not defined.");
    }


    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame)
    {
    }

    public override void OnBeforeClose(CefBrowser browser)
    {
    }
    public override void OnRenderProcessTerminated(CefBrowser browser)
    {
    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
    }


}
