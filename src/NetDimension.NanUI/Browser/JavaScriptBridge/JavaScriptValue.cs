using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript
{
    internal enum JavaScriptValueType
    {
        Undefined = 0,
        Null,
        Bool,
        Int,
        Double,
        String,
        DateTime,
        Object,
        Array,
        Function,
        Property
    }

    public sealed class JavaScriptValue
    {
        internal readonly object RawValue = null;

        internal JavaScriptValueType ValueType = JavaScriptValueType.Undefined;
        public bool IsUndefined { get; private set; }
        public bool IsNull { get; private set; }
        public bool IsBool { get; private set; }
        public bool IsNumber { get; private set; }
        public bool IsString { get; private set; }
        public bool IsDateTime { get; private set; }
        public bool IsObject { get; private set; }
        public bool IsArray { get; private set; }
        public bool IsFunction { get; private set; }
        public bool IsProperty { get; private set; }

        internal bool IsInternal { get; set; } = false;

        internal Func<JavaScriptValue[], JavaScriptValue> Method { get; set; }
        internal Action<JavaScriptValue[], JavaScriptAsyncFunctionCallback> AsyncMethod { get; set; }
        internal JavaScriptRenderSideFunction RenderSideMethod { get; set; }
        internal JavaScriptFunctionInfo JSFunctionDescriber { get; set; }
        internal JavaScriptProperty Property { get; set; }

        internal JavaScriptPropertyInfo JSPropertyDescriber { get; set; }
        internal IDictionary<string, JavaScriptValue> ObjectValue { get; private set; }
        internal IList<JavaScriptValue> ArrayValue { get; private set; }
        public string Name { get; private set; }

        private JavaScriptValue()
        {
            IsNull = true;
        }

        private JavaScriptValue(object value, JavaScriptValueType type)
        {
            RawValue = value;
            ValueType = type;

            switch (type)
            {
                case JavaScriptValueType.Null:
                    IsNull = true;
                    RawValue = null;
                    break;
                case JavaScriptValueType.Bool:
                    IsBool = true;
                    break;
                case JavaScriptValueType.Int:
                    IsNumber = true;
                    break;
                case JavaScriptValueType.Double:
                    IsNumber = true;
                    var number = (double)value;
                    if (Math.Abs(number % 1) < double.Epsilon)
                    {
                        ValueType = JavaScriptValueType.Int;
                        RawValue = (int)number;
                    }
                    break;
                case JavaScriptValueType.String:
                    IsString = true;
                    break;
                case JavaScriptValueType.DateTime:
                    IsDateTime = true;
                    break;
                case JavaScriptValueType.Object:
                    IsObject = true;
                    ObjectValue = new Dictionary<string, JavaScriptValue>();
                    break;
                case JavaScriptValueType.Array:
                    IsArray = true;
                    ArrayValue = new List<JavaScriptValue>();
                    break;
                case JavaScriptValueType.Function:
                    IsFunction = true;
                    break;
                default:
                    break;
            }
        }

        private JavaScriptValue(Func<JavaScriptValue[], JavaScriptValue> function)
        {
            IsFunction = true;
            ValueType = JavaScriptValueType.Function;
            Method = function;
            JSFunctionDescriber = new JavaScriptFunctionInfo
            {
                IsAsync = false,
            };
        }

        private JavaScriptValue(Action<JavaScriptValue[], JavaScriptAsyncFunctionCallback> asyncFunction)
        {
            IsFunction = true;
            ValueType = JavaScriptValueType.Function;
            AsyncMethod = asyncFunction;
            JSFunctionDescriber = new JavaScriptFunctionInfo
            {
                IsAsync = true,
            };
        }

        private JavaScriptValue(JavaScriptRenderSideFunction func)
        {
            IsFunction = true;
            ValueType = JavaScriptValueType.Function;
            Name = func.Name;
            RenderSideMethod = func;

        }

        private JavaScriptValue(JavaScriptFunctionInfo info)
        {
            IsFunction = true;
            ValueType = JavaScriptValueType.Function;
            Name = info.Name;

            JSFunctionDescriber = info;
        }

        private JavaScriptValue(JavaScriptProperty property)
        {
            IsProperty = true;
            ValueType = JavaScriptValueType.Property;
            //Name=name;
            Property = property;

        }

        private JavaScriptValue(JavaScriptPropertyInfo info)
        {
            IsProperty = true;
            ValueType = JavaScriptValueType.Property;
            JSPropertyDescriber = info;


        }

        private void CheckIsArray()
        {
            if (!IsArray || ArrayValue == null)
            {
                throw new InvalidOperationException("The type of current value is not a array.");
            }
        }

        private void CheckIsObject()
        {
            if (!IsObject || ObjectValue == null)
            {
                throw new InvalidOperationException("The type of current value is not a object.");
            }
        }

        public void SetValue(int index, JavaScriptValue value)
        {
            if (value == null)
            {
                return;
            } 

            if (value.IsProperty)
            {
                throw new ArgumentException("Can not add property to an array.");
            }

            CheckIsArray();

            if (index >= ArrayValue.Count)
            {
                ArrayValue.Add(value);
            }
            else
            {
                ArrayValue[index] = value;
            }
        }

        public void AddArrayValue(JavaScriptValue value)
        {
            if (value == null)
            {
                return;
            }

            if (value.IsProperty)
            {
                throw new ArgumentException("Can not add property to an array.");
            }

            CheckIsArray();

            ArrayValue.Add(value);
        }

        public JavaScriptValue[] ToArray()
        {
            CheckIsArray();
            var arrayList = new List<JavaScriptValue>();

            for (int i = 0; i < ArrayLength; i++)
            {
                arrayList.Add(GetValue(i));
            }

            return arrayList.ToArray();
        }


        public JavaScriptValue GetValue(int index)
        {
            CheckIsArray();
            return ArrayValue[index];
        }

        public bool DeleteValue(int index)
        {
            CheckIsArray();
            if (index >= ArrayValue.Count)
                return false;

            ArrayValue.RemoveAt(index);
            return true;
        }

        public bool HasValue(string propertyName)
        {
            CheckIsObject();
            return ObjectValue.ContainsKey(propertyName);
        }

        public void SetValue(string propertyName, JavaScriptValue value)
        {
            CheckIsObject();
            value.Name = propertyName;
            ObjectValue[propertyName] = value;
        }

        public JavaScriptValue GetValue(string propertyName)
        {
            CheckIsObject();
            return ObjectValue[propertyName];
        }

        public bool DeleteValue(string propertyName)
        {
            CheckIsObject();
            return ObjectValue.Remove(propertyName);
        }

        public string[] Keys
        {
            get
            {
                CheckIsObject();
                return ObjectValue.Keys.ToArray();
            }
        }

        public int ArrayLength
        {
            get
            {
                CheckIsArray();
                return ArrayValue.Count;
            }
        }

        internal bool WillExecuteInRenderSide
        {
            get
            {
                return RenderSideMethod != null;
            }
        }


        public Task<JavaScriptExecutionResult> ExecuteFunctionAsync(CefFrame frame, JavaScriptValue[] arguments = null)
        {
            CheckIsRendererFunction();

            var tsc = new TaskCompletionSource<JavaScriptExecutionResult>();

            if (JavaScriptObjectRepository.JavaScriptExecutionTasks.TryAdd(new Tuple<int, long>(tsc.GetHashCode(), frame.Identifier), tsc))
            {
                var jsvalue = arguments == null ? JavaScriptValue.CreateArray() : arguments.ToJSValue();

                var message = BridgeMessage.Create(JavaScriptCommunicationBridge.EVALUATE_JS_CALLBACK);

                message.Arguments.Add(MessageValue.CreateInt(tsc.GetHashCode()));

                message.Arguments.Add(MessageValue.CreateInt(JSFunctionDescriber.Id));

                message.Arguments.Add(MessageValue.CreateString(jsvalue.ToDefinition()));

                JavaScriptCommunicationBridge.SendProcessMessage(CefProcessId.Renderer, frame, message);

                return tsc.Task;
            }


            throw new InvalidOperationException("Same function already exists.");
        }

        public string GetString()
        {
            switch (ValueType)
            {
                case JavaScriptValueType.Bool:
                case JavaScriptValueType.Int:
                case JavaScriptValueType.Double:
                case JavaScriptValueType.DateTime:
                    return $"{RawValue}";
                case JavaScriptValueType.String:
                    return (string)RawValue;
                case JavaScriptValueType.Object:
                    return $"[object]";
                case JavaScriptValueType.Array:
                    return $"[array]";
                case JavaScriptValueType.Function:
                    return $"[function]";
                default:
                    return null;
            }
        }

        public int GetInt()
        {
            if (ValueType == JavaScriptValueType.Double || ValueType == JavaScriptValueType.Int)
            {
                return (int)RawValue;
            }

            if (ValueType == JavaScriptValueType.Bool)
            {
                return ((bool)RawValue) ? 1 : 0;
            }

            return 0;
        }

        public double GetDouble()
        {
            if (ValueType == JavaScriptValueType.Double || ValueType == JavaScriptValueType.Int)
            {
                return Convert.ToDouble(RawValue);
            }

            if (ValueType == JavaScriptValueType.Bool)
            {
                return ((bool)RawValue) ? 1 : 0;
            }

            return 0;
        }

        public DateTime GetDateTime()
        {
            if (ValueType == JavaScriptValueType.String)
            {


                if (DateTime.TryParse((string)RawValue, out var retval))
                {
                    return retval;
                }
            }

            if (ValueType == JavaScriptValueType.DateTime)
            {
                return (DateTime)RawValue;
            }

            return default;
        }

        public bool GetBool()
        {
            if (ValueType == JavaScriptValueType.Int || ValueType == JavaScriptValueType.Double)
            {
                return (int)RawValue != 0;
            }

            if (ValueType == JavaScriptValueType.Bool)
            {
                return (bool)RawValue;
            }


            return false;
        }

        public string GetString(string propertyName)
        {
            return GetValue(propertyName)?.GetString();
        }

        public int GetInt(string propertyName)
        {
            return GetValue(propertyName)?.GetInt() ?? default;
        }

        public double GetDouble(string propertyName)
        {
            return GetValue(propertyName)?.GetDouble() ?? default;
        }

        public DateTime GetDateTime(string propertyName)
        {
            return GetValue(propertyName)?.GetDateTime() ?? default;
        }

        public bool GetBool(string propertyName)
        {
            return GetValue(propertyName)?.GetBool() ?? default;
        }


        public string GetString(int index)
        {
            return GetValue(index)?.GetString();
        }

        public int GetInt(int index)
        {
            return GetValue(index)?.GetInt() ?? default;
        }

        public double GetDouble(int index)
        {
            return GetValue(index)?.GetDouble() ?? default;
        }

        public DateTime GetDateTime(int index)
        {
            return GetValue(index)?.GetDateTime() ?? default;
        }

        public bool GetBool(int index)
        {
            return GetValue(index)?.GetBool() ?? default;
        }

        private void CheckIsRendererFunction()
        {
            if (!IsFunction)
            {
                throw new InvalidOperationException("The type of current value is not a function.");
            }

            if (JSFunctionDescriber == null || JSFunctionDescriber.Side != CefProcessType.Renderer)
            {
                throw new InvalidOperationException("This method must be called only in browser side.");
            }
        }

        private JavaScriptValueDefinition GetDefinition()
        {
            var def = new JavaScriptValueDefinition();
            def.ValueType = ValueType;

            switch (ValueType)
            {
                case JavaScriptValueType.Property:
                    if (Property != null)
                    {
                        def.Definition = new JavaScriptPropertyInfo
                        {
                            Name = Name,
                            Id = this.GetHashCode(),
                            IsReadable = Property.Readable,
                            IsWritable = Property.Writable
                        };
                    }
                    else if (JSPropertyDescriber != null)
                    {
                        def.Definition = JSPropertyDescriber;
                    }
                    break;
                case JavaScriptValueType.Function:

                    if (Method != null)
                    {
                        def.Definition = new JavaScriptFunctionInfo
                        {
                            Name = Name,
                            IsAsync = false,
                            Id = this.GetHashCode(),
                            Side = CefProcessType.Browser
                        };
                    }
                    else if (AsyncMethod != null)
                    {
                        def.Definition = new JavaScriptFunctionInfo
                        {
                            Name = Name,
                            IsAsync = true,
                            Id = this.GetHashCode(),
                            Side = CefProcessType.Browser
                        };
                    }
                    else if (RenderSideMethod != null)
                    {
                        def.Definition = new JavaScriptFunctionInfo
                        {
                            Name = Name,
                            Id = RenderSideMethod.Id,
                            Side = CefProcessType.Renderer
                        };

                    }
                    break;
                case JavaScriptValueType.Null:
                case JavaScriptValueType.Bool:
                case JavaScriptValueType.Int:
                case JavaScriptValueType.Double:
                case JavaScriptValueType.String:
                case JavaScriptValueType.DateTime:
                    def.Definition = RawValue;
                    break;
                case JavaScriptValueType.Object:
                    var obj = new Dictionary<string, JavaScriptValueDefinition>();
                    foreach (var item in ObjectValue)
                    {
                        obj[item.Key] = item.Value.GetDefinition();
                    }
                    def.Definition = obj;
                    break;
                case JavaScriptValueType.Array:
                    var array = new List<JavaScriptValueDefinition>();
                    foreach (var item in ArrayValue)
                    {
                        array.Add(item.GetDefinition());
                    }
                    def.Definition = array;
                    break;

            }

            return def;
        }

        public string ToDefinition()
        {
            return JsonSerializer.Serialize(GetDefinition(), new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        }

        internal static JavaScriptValue FromJson(string json)
        {
            return FromDefinition(JsonSerializer.Deserialize<JavaScriptValueDefinition>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, }));
        }


        internal static JavaScriptValue FromDefinition(JavaScriptValueDefinition source)
        {

            if (source.Definition == null)
                return null;

            var valueType = source.ValueType;
            var definition = (JsonElement)source.Definition;

            object value = null;

            switch (definition.ValueKind)
            {
                case JsonValueKind.String:
                    if (valueType == JavaScriptValueType.DateTime)
                    {
                        value = definition.GetDateTime();
                    }
                    else
                    {
                        value = definition.GetString();
                    }
                    break;
                case JsonValueKind.Number:
                    if (valueType == JavaScriptValueType.Int)
                    {
                        value = definition.GetInt32();
                    }
                    else if (valueType == JavaScriptValueType.Double)
                    {
                        value = definition.GetDouble();
                    }

                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    value = definition.GetBoolean();
                    break;
                case JsonValueKind.Null:
                    value = null;
                    break;
                default:
                    value = definition.ToString();
                    break;
            }


            switch (valueType)
            {
                case JavaScriptValueType.Property:
                    {

                        var propertyInfo = JsonSerializer.Deserialize<JavaScriptPropertyInfo>((string)value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                        return new JavaScriptValue(propertyInfo);
                    }
                case JavaScriptValueType.Function:


                    var functionInfo = JsonSerializer.Deserialize<JavaScriptFunctionInfo>((string)value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                    return new JavaScriptValue(functionInfo);

                case JavaScriptValueType.Null:
                case JavaScriptValueType.Bool:
                case JavaScriptValueType.Int:
                case JavaScriptValueType.Double:
                case JavaScriptValueType.String:
                case JavaScriptValueType.DateTime:
                    return new JavaScriptValue(value, valueType);
                case JavaScriptValueType.Object:

                    var obj = new JavaScriptValue(null, valueType);

                    var properties = JsonSerializer.Deserialize<Dictionary<string, JavaScriptValueDefinition>>((string)value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                    foreach (var property in properties)
                    {
                        obj.SetValue(property.Key, JavaScriptValue.FromDefinition(property.Value));
                    }

                    return obj;
                case JavaScriptValueType.Array:
                    var array = new JavaScriptValue(null, valueType);

                    var items = JsonSerializer.Deserialize<List<JavaScriptValueDefinition>>((string)value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    foreach (var item in items)
                    {
                        array.AddArrayValue(FromDefinition(item));
                    }

                    return array;


            }

            return null;
        }



        public static JavaScriptValue CreateNull()
        {
            return new JavaScriptValue();
        }

        public static JavaScriptValue CreateBool(bool value)
        {
            return new JavaScriptValue(value, JavaScriptValueType.Bool);
        }

        public static JavaScriptValue CreateNumber(double value)
        {
            return new JavaScriptValue(value, JavaScriptValueType.Double);
        }

        public static JavaScriptValue CreateNumber(int value)
        {
            return new JavaScriptValue(value, JavaScriptValueType.Int);
        }

        public static JavaScriptValue CreateNumber(float value)
        {
            return new JavaScriptValue(value, JavaScriptValueType.Double);
        }

        public static JavaScriptValue CreateString(string value)
        {
            return new JavaScriptValue(value, JavaScriptValueType.String);
        }

        public static JavaScriptValue CreateDateTime(DateTime value)
        {
            return new JavaScriptValue(value, JavaScriptValueType.DateTime);
        }

        public static JavaScriptValue CreateFunction(Func<JavaScriptValue[], JavaScriptValue> function)
        {
            return new JavaScriptValue(function);
        }

        public static JavaScriptValue CreateFunction(Action<JavaScriptValue[], JavaScriptAsyncFunctionCallback> asyncFunction)
        {
            return new JavaScriptValue(asyncFunction);
        }

        public static JavaScriptValue CreateProperty(Func<JavaScriptValue> getter, Action<JavaScriptValue> setter = null)
        {
            return new JavaScriptValue(new JavaScriptProperty
            {
                Getter = getter,
                Setter = setter
            });
        }

        public static JavaScriptValue CreateProperty(JavaScriptProperty property)
        {
            return new JavaScriptValue(property);
        }

        internal static JavaScriptValue CreateFunction(JavaScriptRenderSideFunction info)
        {
            return new JavaScriptValue(info);
        }

        public static JavaScriptValue CreateObject()
        {
            return new JavaScriptValue(null, JavaScriptValueType.Object);
        }

        public static JavaScriptValue CreateArray()
        {
            return new JavaScriptValue(null, JavaScriptValueType.Array);
        }


    }

}
