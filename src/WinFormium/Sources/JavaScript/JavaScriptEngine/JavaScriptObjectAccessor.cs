// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class JavaScriptObjectAccessor : CefV8Accessor
{
    internal JavaScriptObjectAccessor(JavaScriptObject parentObject, CefV8Context context)
    {
        ParentObject = parentObject;
        Context = context;

        Properties = parentObject.PropertySymbols.Where(x => x.ValueType == JavaScriptValueType.Property).ToArray();
    }

    public JavaScriptObject ParentObject { get; }
    public CefV8Context Context { get; }

    public JavaScriptValue[] Properties { get; }

    protected override bool Get(string name, CefV8Value obj, out CefV8Value returnValue, out string exception)
    {
        var prop = (JavaScriptProperty?)Properties.SingleOrDefault(x => x.Name == name);

        if (prop != null)
        {
            var browser = Context.GetBrowser();
            var frame = Context.GetFrame();

            var response = MessageBridge.ExecuteRequest(new MessageBridgeRequest
            {
                Name = JavaScriptEngineBridge.GET_JAVASCRIPT_OBJECT_PROPERTY_MESSAGE,
                BrowserId = browser.Identifier,
                FrameId = frame.Identifier,
                IsRemote = true,
                Payload = JsonSerializer.Serialize(new AccessJavaScriptObjectPropertyMessage
                {
                    PropertyUuid = prop.Uuid,
                    ObjectUuid = ParentObject.Uuid,
                    PropertyName = name,
                })

            });

            if (response.IsSuccess)
            {
                if (string.IsNullOrEmpty(response.Data))
                {
                    returnValue = CefV8Value.CreateNull();
                }
                else
                {
                    returnValue = JavaScriptValue.FromJson(response.Data).ToCefV8Value();
                }

                exception = null;
            }
            else
            {
                exception = $"[{nameof(WinFormium)}]: {response.Exception}";
                returnValue = CefV8Value.CreateUndefined();
            }

        }
        else
        {
            returnValue = CefV8Value.CreateUndefined();
            exception = $"[{nameof(WinFormium)}]: Property {name} is not found in Object.";
        }


        return true;
    }

    protected override bool Set(string name, CefV8Value obj, CefV8Value value, out string exception)
    {
        var prop = (JavaScriptProperty?)Properties.SingleOrDefault(x => x.Name == name);

        if (prop != null)
        {
            if (prop.Writable)
            {
                var browser = Context.GetBrowser();
                var frame = Context.GetFrame();

                var response = MessageBridge.ExecuteRequest(new MessageBridgeRequest
                {
                    Name = JavaScriptEngineBridge.SET_JAVASCRIPT_OBJECT_PROPERTY_MESSAGE,
                    BrowserId = browser.Identifier,
                    FrameId = frame.Identifier,
                    IsRemote = true,
                    Payload = JsonSerializer.Serialize(new AccessJavaScriptObjectPropertyMessage
                    {
                        PropertyUuid = prop.Uuid,
                        ObjectUuid = ParentObject.Uuid,
                        PropertyName = name,
                        Data = value.ToJavaScriptValue().ToJson()
                    })

                });

                if (response.IsSuccess)
                {
                    exception = null;
                }
                else
                {
                    exception = $"[NanUI]: {response.Exception}";
                }
            }
            else
            {
                exception = $"[NanUI]: Property {name} is not writable.";
            }
        }
        else
        {
            exception = $"[NanUI]: Property {name} is not defined in Object.";
        }

        return true;
    }

}