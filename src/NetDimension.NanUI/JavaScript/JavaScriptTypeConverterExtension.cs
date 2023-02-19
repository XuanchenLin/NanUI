using NetDimension.NanUI.JavaScript.Renderer;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

internal static class JavaScriptTypeConverterExtension
{
    public static JavaScriptValue ToJavaScriptValue(this CefV8Value v8Value)
    {

        JavaScriptValue jsValue;

        if (v8Value == null/* || !v8Value.IsValid*/)
        {
            jsValue = JavaScriptValue.CreateUndefined();

            return jsValue;
        }

        if (v8Value.IsFunction)
        {
            var context = CefV8Context.GetEnteredContext();

            jsValue = JavaScriptRenderSideFunction.Create(context, v8Value);

            JavaScriptObjectRepositoryOnRenderSide.StoredFunctions.Add((JavaScriptRenderSideFunction)jsValue);

        }
        else if (v8Value.IsArray)
        {
            var array = new JavaScriptArray();

            for (int i = 0; i < v8Value.GetArrayLength(); i++)
            {
                array.Add(v8Value.GetValue(i).ToJavaScriptValue());
            }

            jsValue = array;

        }
        else if (v8Value.IsObject)
        {
            var obj = new JavaScriptObject();

            foreach (var key in v8Value.GetKeys())
            {
                var item = v8Value.GetValue(key);

                if (item != null && item.IsValid)
                {
                    obj.Add(key, item.ToJavaScriptValue());
                }
            }

            jsValue = obj;

        }
        else if (v8Value.IsBool)
        {
            jsValue = new JavaScriptValue(v8Value.GetBoolValue());
        }
        else if (v8Value.IsDate)
        {
            jsValue = new JavaScriptValue(v8Value.GetDateValue());
        }
        else if (v8Value.IsDouble)
        {
            var v = v8Value.GetDoubleValue();

            if (Math.Abs(v % 1) < double.Epsilon)
            {
                jsValue = new JavaScriptValue(v8Value.GetIntValue());
            }
            else
            {
                jsValue = new JavaScriptValue(v);
            }

        }
        else if (v8Value.IsInt || v8Value.IsUInt)
        {
            jsValue = new JavaScriptValue(v8Value.GetIntValue());
        }
        else if (v8Value.IsString)
        {
            jsValue = new JavaScriptValue(v8Value.GetStringValue());
        }
        else
        {
            jsValue = new JavaScriptValue();
        }

        return jsValue;
    }

    public static CefV8Value[] ToCefV8Arguments(this JavaScriptArray array)
    {
        var retval = new List<CefV8Value>();

        for (var i = 0; i < array.Count; i++)
        {
            var source = array[i];

            retval.Add(source.ToCefV8Value());
        }

        return retval.ToArray();
    }

    public static CefV8Value ToCefV8Value(this JavaScriptValue source)
    {



        switch (source.ValueType)
        {
            case JavaScriptValueType.Null:
                return CefV8Value.CreateNull();
            case JavaScriptValueType.Bool:
                return CefV8Value.CreateBool(source.GetBool());
            case JavaScriptValueType.Int:
                return CefV8Value.CreateInt(source.GetInt());
            case JavaScriptValueType.Double:
                return CefV8Value.CreateDouble(source.GetDouble());
            case JavaScriptValueType.String:
                return CefV8Value.CreateString(source.GetString());
            case JavaScriptValueType.JSON:
                {
                    var context = CefV8Context.GetEnteredContext();

                    var json = context.GetGlobal().GetValue("JSON");

                    var parse = json.GetValue("parse");

                    var jsonValue = CefV8Value.CreateString(source.GetString());

                    var retval = parse.ExecuteFunction(null, new CefV8Value[] { jsonValue });

                    jsonValue.Dispose();

                    return retval;
                }
            case JavaScriptValueType.DateTime:
                return CefV8Value.CreateDate(source.GetDateTime());
            case JavaScriptValueType.Object:
                {

                    var context = CefV8Context.GetEnteredContext();

                    var target = source.ToObject();

                    var obj = CefV8Value.CreateObject(new JavaScriptObjectAccessor(target, context));


                    foreach (var name in target.PropertyNames)
                    {
                        if (target.TryGetValue(name, out var retval) && retval != null)
                        {
                            var cefV8PropertyAttribute = CefV8PropertyAttribute.DontDelete;

                            if (retval.IsProperty)
                            {
                                var accessControl = CefV8AccessControl.AllCanRead;

                                var prop = (JavaScriptProperty)retval;
                                if (prop.Writable)
                                {
                                    accessControl |= CefV8AccessControl.AllCanWrite;
                                }
                                else
                                {
                                    cefV8PropertyAttribute |= CefV8PropertyAttribute.ReadOnly;
                                }

                                obj.SetValue(name, accessControl, cefV8PropertyAttribute);
                            }
                            else
                            {
                                obj.SetValue(name, retval.ToCefV8Value(), cefV8PropertyAttribute);
                            }

                        }
                    }

                    return obj;
                }

            case JavaScriptValueType.Array:
                {
                    var result = new List<CefV8Value>();
                    var target = source.ToArray();

                    for (int i = 0; i < target.Count; i++)
                    {
                        var retval = target[i]?.ToCefV8Value();

                        if (retval != null)
                        {
                            result.Add(retval);
                        }
                    }

                    var array = CefV8Value.CreateArray(result.Count);

                    for (int i = 0; i < result.Count; i++)
                    {
                        array.SetValue(i, result[i]);
                    }

                    return array;
                }
            case JavaScriptValueType.Function:
                {
                    var context = CefV8Context.GetEnteredContext();

                    var func = CefV8Value.CreateFunction(source.Name, new BrowserSideFunctionHandler(source, context));

                    return func;
                }
            case JavaScriptValueType.Property:
                {

                }
                break;
        }

        return CefV8Value.CreateUndefined();
    }
}
