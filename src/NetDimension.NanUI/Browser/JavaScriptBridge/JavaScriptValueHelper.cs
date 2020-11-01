using System;
using System.Collections.Generic;
using System.Text.Json;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{

    public static class JavaScriptValueHelper
    {

        public static CefV8Value[] ToCefV8Arguments(this JavaScriptValue arguments)
        {
            if (!arguments.IsArray)
            {
                throw new ArgumentOutOfRangeException($"The parameter {nameof(arguments)} should be the type of JavaScript array.");
            }

            var retval = new List<CefV8Value>();

            for (int i = 0; i < arguments.ArrayLength; i++)
            {
                var source = arguments.GetValue(i);
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
                case JavaScriptValueType.DateTime:
                    return CefV8Value.CreateDate(source.GetDateTime());
                case JavaScriptValueType.Property:
                    break;
                case JavaScriptValueType.Function:
                    break;
                case JavaScriptValueType.Object:
                    var obj = CefV8Value.CreateObject();
                    foreach (var key in source.Keys)
                    {
                        var retval = source.GetValue(key)?.ToCefV8Value();
                        if (retval != null)
                        {
                            obj.SetValue(key, retval);
                        }
                    }
                    return obj;
                case JavaScriptValueType.Array:
                    var result = new List<CefV8Value>();
                    for (int i = 0; i < source.ArrayLength; i++)
                    {
                        var retval = source.GetValue(i)?.ToCefV8Value();
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

            return null;
        }

        //public static JSValue FromJson(this JSValue @this, string json)
        //{

        //}

        public static JavaScriptValue ToJSValue(this JavaScriptValue[] source)
        {
            var target = JavaScriptValue.CreateArray();
            for (int i = 0; i < source.Length; i++)
            {
                target.SetValue(i, source[i]);
            }

            return target;
        }

        public static JavaScriptValue ToJSValue(this CefV8Value source)
        {
            if(source==null || !source.IsValid)
            {
                throw new ArgumentNullException();
            }

            JavaScriptValue target;

            if (source.IsFunction)
            {
                var context = CefV8Context.GetEnteredContext();

                var info = new JavaScriptRenderSideFunction(context, source);

                JavaScriptObjectRepository.RenderSideFunctions.Add(info);

                target = JavaScriptValue.CreateFunction(info);

            }
            else if (source.IsArray)
            {
                target = JavaScriptValue.CreateArray();
                for (int i = 0; i < source.GetArrayLength(); i++)
                {
                    var item = source.GetValue(i);
                    if(item!=null && item.IsValid)
                    {
                        target.AddArrayValue(item.ToJSValue());
                    }
                }
            }
            else if (source.IsObject)
            {
                target = JavaScriptValue.CreateObject();
                foreach (var key in source.GetKeys())
                {
                    var item = source.GetValue(key);
                    if(item!=null && item.IsValid)
                    {
                        target.SetValue(key, item.ToJSValue());
                    }
                }
            }
            else if (source.IsBool)
            {
                target = JavaScriptValue.CreateBool(source.GetBoolValue());
            }
            else if (source.IsDate)
            {
                target = JavaScriptValue.CreateDateTime(source.GetDateValue());
            }
            else if (source.IsDouble)
            {
                target = JavaScriptValue.CreateNumber(source.GetDoubleValue());

            }
            else if (source.IsInt)
            {
                target = JavaScriptValue.CreateNumber(source.GetIntValue());

            }
            else if (source.IsUInt)
            {
                target = JavaScriptValue.CreateNumber(source.GetUIntValue());
            }
            else if (source.IsString)
            {
                target = JavaScriptValue.CreateString(source.GetStringValue());
            }
            else
            {
                target = JavaScriptValue.CreateNull();
            }


            return target;

        }


    }


}
