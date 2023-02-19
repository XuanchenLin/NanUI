using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class JavaScriptObjectAccessor : CefV8Accessor
{


    internal JavaScriptObjectAccessor(JavaScriptObject parentObject, CefV8Context context)
    {
        ParentObject = parentObject;
        Context = context;

        Properties = parentObject.PropertySymbols.Where(x => x.IsProperty).ToArray();
    }

    public JavaScriptObject ParentObject { get; }
    public CefV8Context Context { get; }

    public JavaScriptValue[] Properties { get; }

    protected override bool Get(string name, CefV8Value obj, out CefV8Value returnValue, out string exception)
    {
        var prop = (JavaScriptProperty)Properties.SingleOrDefault(x => x.Name == name);
        if (prop != null)
        {
            var request = new MessageRequest(JavaScriptProperties.JavaScriptPropertyHandler.OBJECT_GET_PROPERTY_VALUE, Context.GetBrowser().Identifier, Context.GetFrame().Identifier, Context.GetHashCode())
            {
                Data = JsonSerializer.Serialize(new JavaScriptObjectAccessorMessageParameter
                {
                    Name = name,
                    Uuid = prop.Uuid,
                    ObjectUuid = ParentObject.Uuid
                })
            };

            var response = FormiumMessageBridge.ExecuteRequest(request);

            if (response.IsSuccess)
            {
                if (string.IsNullOrEmpty(response.Data))
                {
                    returnValue = new JavaScriptValue().ToCefV8Value();
                }
                else
                {
                    returnValue = JavaScriptValue.FromJson(response.Data).ToCefV8Value();
                }
                exception = null;
            }
            else
            {
                exception = response.Result;
                returnValue = CefV8Value.CreateUndefined();
            }

        }
        else
        {
            returnValue = CefV8Value.CreateUndefined();
            exception = $"[NanUI]: Property {name} is not found in Object.";
        }


        return true;
    }

    protected override bool Set(string name, CefV8Value obj, CefV8Value value, out string exception)
    {
        var prop = (JavaScriptProperty)Properties.SingleOrDefault(x => x.Name == name);

        if (prop != null)
        {
            if (prop.Writable)
            {

                var request = new MessageRequest(JavaScriptProperties.JavaScriptPropertyHandler.OBJECT_SET_PROPERTY_VALUE, Context.GetBrowser().Identifier, Context.GetFrame().Identifier, Context.GetHashCode())
                {
                    Data = JsonSerializer.Serialize(new JavaScriptObjectAccessorMessageParameter
                    {
                        Name = name,
                        Uuid = prop.Uuid,
                        ObjectUuid = ParentObject.Uuid,
                        Value = value.ToJavaScriptValue().ToJson()
                    })
                };

                var response = FormiumMessageBridge.ExecuteRequest(request);

                if (response.IsSuccess)
                {
                    exception = null;
                }
                else
                {
                    exception = $"[NanUI]: {response.Result}";
                }



            }
            else
            {
                exception = $"[NanUI]: Property {name} is not writable.";
            }
        }
        else
        {
            exception = $"[NanUI]: Property {name} is not found in Object.";
        }

        return true;


    }
}

internal class JavaScriptObjectAccessorMessageParameter
{
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid Uuid { get; set; }
    public Guid ObjectUuid { get; set; }
}
