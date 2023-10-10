// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;


internal static class JavaScriptTypeConverterExtension
{
    public static DateTime ToDateTime(this CefBaseTime cefBaseTime)
    {
        return new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(cefBaseTime.Ticks / 1000).ToLocalTime();
    }

    public static CefBaseTime ToCefBaseTime(this DateTime dateTime)
    {
        var baseTime = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        var ticks = (dateTime.ToUniversalTime() - baseTime).TotalMilliseconds * 1000;

        return new CefBaseTime((long)ticks);
    }

    public static JavaScriptValue ToJavaScriptValue(this CefV8Value v8Value)
    {

        JavaScriptValue? jsValue;

        if (v8Value == null/* || !v8Value.IsValid*/)
        {
            jsValue = new JavaScriptValue();

            return jsValue;
        }

        if (v8Value.IsFunction)
        {
            //var context = CefV8Context.GetEnteredContext();

            jsValue = new JavaScriptFunctionInvokerOnRemote(/*context, */v8Value);
        }
        else if (v8Value.IsArray)
        {
            var array = new JavaScriptArray();

            for (var i = 0; i < v8Value.GetArrayLength(); i++)
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
            jsValue = new JavaScriptValue(v8Value.GetDateValue().ToDateTime());
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
        CefV8Context context;


        context = CefV8Context.GetEnteredContext();


        CefV8Value? returnValue = null;


        switch (source.ValueType)
        {
            case JavaScriptValueType.Null:
                returnValue = CefV8Value.CreateNull();
                break;
            case JavaScriptValueType.Bool:
                returnValue = CefV8Value.CreateBool(source.GetBoolean());
                break;
            case JavaScriptValueType.Number:
                if (source.GetInt() == source.GetDouble())
                {
                    returnValue = CefV8Value.CreateInt(source.GetInt());
                }
                else
                {
                    returnValue = CefV8Value.CreateDouble(source.GetDouble());
                }
                break;
            case JavaScriptValueType.String:
                returnValue = CefV8Value.CreateString(source.GetString()?? string.Empty);
                break;
            case JavaScriptValueType.Json:
                {
                    using var global = context.GetGlobal();

                    using var json = global.GetValue("JSON");

                    using var parse = json.GetValue("parse");

                    using var jsonValue = CefV8Value.CreateString(source.GetString() ?? string.Empty);

                    var retval = parse.ExecuteFunction(json, new CefV8Value[] { jsonValue });

                    jsonValue.Dispose();

                    returnValue = retval;
                }
                break;
            case JavaScriptValueType.Date:
                returnValue = CefV8Value.CreateDate(source.GetDateTime().ToCefBaseTime());
                break;
            case JavaScriptValueType.Object:
                {
                    var target = source.ToObject();

                    var obj = CefV8Value.CreateObject(new JavaScriptObjectAccessor(target, context));


                    foreach (var name in target.PropertyNames)
                    {
                        if (target.TryGetValue(name, out var retval) && retval != null)
                        {
                            var cefV8PropertyAttribute = CefV8PropertyAttribute.DontDelete;

                            if (retval.ValueType == JavaScriptValueType.Property)
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

                    returnValue = obj;
                }
                break;

            case JavaScriptValueType.Array:
                {
                    var result = new List<CefV8Value>();
                    var target = source.ToArray();

                    for (var i = 0; i < target.Count; i++)
                    {
                        var retval = target[i]?.ToCefV8Value();

                        if (retval != null)
                        {
                            result.Add(retval);
                        }
                    }

                    var array = CefV8Value.CreateArray(result.Count);

                    for (var i = 0; i < result.Count; i++)
                    {
                        array.SetValue(i, result[i]);
                    }

                    returnValue = array;
                }
                break;
            case JavaScriptValueType.Function:
                {

                    var func = CefV8Value.CreateFunction(source.Name, new JavaScriptFunctionInvokerHandler(source, context));

                    returnValue = func;
                }
                break;
            case JavaScriptValueType.Property:
                {

                }
                break;
        }

        if (returnValue == null)
            returnValue = CefV8Value.CreateUndefined();


        return returnValue;
    }
}
